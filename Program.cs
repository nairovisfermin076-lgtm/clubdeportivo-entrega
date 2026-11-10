internal static class Program
{
    [STAThread] static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var cfg = new ConnectionForm();
        if (cfg.ShowDialog() != DialogResult.OK) return;
        try { Conexion.Configure(cfg.ConnectionString); Conexion.Test(); Application.Run(new LoginForm()); }
        catch (Exception ex) { MessageBox.Show("No se pudo iniciar la aplicación: " + ex.Message, "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}

// Abstracción y encapsulamiento: Persona define el contrato común y protege sus datos.
public abstract class Persona
{
    public long Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Documento { get; private set; }
    public bool AptoFisico { get; private set; }
    protected Persona(long id, string nombre, string apellido, string documento, bool apto)
    { Id=id; Nombre=nombre; Apellido=apellido; Documento=documento; AptoFisico=apto; }
    public abstract string ObtenerCondicion();
}
// Herencia: Socio y NoSocio especializan Persona. Polimorfismo: implementan distinto el método abstracto.
public sealed class Socio : Persona
{
    public Socio(long id,string n,string a,string d,bool apto):base(id,n,a,d,apto){}
    public override string ObtenerCondicion() => "SOCIO";
}
public sealed class NoSocio : Persona
{
    public NoSocio(long id,string n,string a,string d,bool apto):base(id,n,a,d,apto){}
    public override string ObtenerCondicion() => "NO SOCIO";
}
public abstract class Pago
{
    public decimal Importe { get; protected set; }
    protected Pago(decimal importe) { if (importe <= 0) throw new ArgumentOutOfRangeException(nameof(importe)); Importe=importe; }
    public abstract DateTime CalcularVencimiento(DateTime inicio);
}
public sealed class PagoMensual : Pago
{
    public PagoMensual(decimal importe):base(importe){}
    public override DateTime CalcularVencimiento(DateTime inicio) => inicio.AddMonths(1).AddDays(-1);
}
public sealed class PagoDiario : Pago
{
    public PagoDiario(decimal importe):base(importe){}
    public override DateTime CalcularVencimiento(DateTime inicio) => inicio.Date;
}

public sealed class ConnectionForm : Form
{
    readonly TextBox server=new(){Text="localhost",Width=190};
    readonly NumericUpDown port=new(){Minimum=1,Maximum=65535,Value=3306,Width=190};
    readonly TextBox database=new(){Text="club_deportivo",Width=190};
    readonly TextBox user=new(){Text="root",Width=190};
    readonly TextBox password=new(){UseSystemPasswordChar=true,Width=190};
    public string ConnectionString { get; private set; } = "";
    public ConnectionForm()
    {
        Text="Configuración de conexión MySQL"; Width=470; Height=330; StartPosition=FormStartPosition.CenterScreen;
        var p=new TableLayoutPanel{Dock=DockStyle.Fill,Padding=new Padding(18),ColumnCount=2};
        Add(p,"Servidor",server); Add(p,"Puerto",port); Add(p,"Base de datos",database); Add(p,"Usuario",user); Add(p,"Contraseña",password);
        var test=new Button{Text="Probar conexión y continuar",AutoSize=true}; test.Click+=Probar; Add(p,"",test); Controls.Add(p); AcceptButton=test;
    }
    static void Add(TableLayoutPanel p,string label,Control c){int r=p.RowCount++;p.RowStyles.Add(new RowStyle(SizeType.AutoSize));p.Controls.Add(new Label{Text=label,AutoSize=true,Padding=new Padding(0,7,0,0)},0,r);p.Controls.Add(c,1,r);}
    void Probar(object? sender,EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(server.Text)||string.IsNullOrWhiteSpace(database.Text)||string.IsNullOrWhiteSpace(user.Text)){MessageBox.Show("Completá servidor, base de datos y usuario.");return;}
        var b=new MySqlConnectionStringBuilder{Server=server.Text.Trim(),Port=(uint)port.Value,Database=database.Text.Trim(),UserID=user.Text.Trim(),Password=password.Text};
        try { using var c=new MySqlConnection(b.ConnectionString); c.Open(); using var q=new MySqlCommand("SELECT 1",c); q.ExecuteScalar(); ConnectionString=b.ConnectionString; DialogResult=DialogResult.OK; Close(); }
        catch(Exception ex){MessageBox.Show("No se pudo conectar. Revisá los datos y que MySQL esté iniciado.\n"+ex.Message,"Conexión fallida",MessageBoxButtons.OK,MessageBoxIcon.Warning);}
    }
}
public static class Conexion
{
    static string connectionString="";
    public static void Configure(string value)=>connectionString=value;
    public static MySqlConnection Open(){if(string.IsNullOrWhiteSpace(connectionString))throw new InvalidOperationException("Primero configurá la conexión.");var c=new MySqlConnection(connectionString);c.Open();return c;}
    public static void Test(){using var c=Open();using var q=new MySqlCommand("SELECT 1",c);q.ExecuteScalar();}
    public static string Hash(string s)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(s)));
}
public sealed class LoginForm:Form
{
    TextBox user=new(){Width=220}, pass=new(){Width=220,UseSystemPasswordChar=true};
    public LoginForm()
    {
        Text="Club Deportivo - Ingreso"; Width=390; Height=230; StartPosition=FormStartPosition.CenterScreen;
        var p=new TableLayoutPanel{Dock=DockStyle.Fill,Padding=new Padding(25),ColumnCount=2};
        p.Controls.Add(new Label{Text="Usuario",AutoSize=true},0,0); p.Controls.Add(user,1,0);
        p.Controls.Add(new Label{Text="Contraseña",AutoSize=true},0,1); p.Controls.Add(pass,1,1);
        var b=new Button{Text="Ingresar"}; b.Click+=(_,_)=>Ingresar(); p.Controls.Add(b,1,2); Controls.Add(p); AcceptButton=b;
    }
    void Ingresar()
    {
        if(string.IsNullOrWhiteSpace(user.Text)||string.IsNullOrEmpty(pass.Text)){MessageBox.Show("Completá usuario y contraseña.");return;}
        try{
            using var c=Conexion.Open(); using var q=new MySqlCommand("SELECT nombre_usuario,rol FROM usuarios WHERE nombre_usuario=@u AND password_hash=@p AND activo=1",c);
            q.Parameters.AddWithValue("@u",user.Text.Trim()); q.Parameters.AddWithValue("@p",Conexion.Hash(pass.Text));
            using var r=q.ExecuteReader(); if(!r.Read()){MessageBox.Show("Credenciales incorrectas.");return;}
            string n=r.GetString(r.GetOrdinal("nombre_usuario")), rol=r.GetString(r.GetOrdinal("rol")); Hide();
            using(var f=new MainForm(n,rol)) f.ShowDialog(); Close();
        }catch(Exception ex){MessageBox.Show("Error al ingresar: "+ex.Message);}
    }
}
public sealed class MainForm:Form
{
    public MainForm(string usuario,string rol)
    {
        Text="Sistema de gestión - Club Deportivo"; Width=700; Height=440; StartPosition=FormStartPosition.CenterScreen;
        Controls.Add(new Label{Text=$"CLUB DEPORTIVO | {usuario} ({rol})",Dock=DockStyle.Top,Height=65,
            TextAlign=ContentAlignment.MiddleCenter,Font=new Font("Segoe UI",14,FontStyle.Bold)});
        var p=new FlowLayoutPanel{Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,Padding=new Padding(35)};
        Add(p,"Alta de persona / socio",()=>new AltaForm().ShowDialog(this));
        Add(p,"Cobro de cuota / pago diario",()=>new CobroForm().ShowDialog(this));
        Add(p,"Consultar vencimientos",()=>new VencimientosForm().ShowDialog(this));
        Add(p,"Salir",Close); Controls.Add(p);
    }
    static void Add(Control p,string s,Action a){var b=new Button{Text=s,Width=300,Height=45,Margin=new Padding(5)};b.Click+=(_,_)=>a();p.Controls.Add(b);}
}
public sealed class AltaForm:Form
{
    TextBox nombre=F(),apellido=F(),tdoc=F(),doc=F(),tel=F(),mail=F();
    ComboBox condicion=new(){DropDownStyle=ComboBoxStyle.DropDownList,Width=210};
    CheckBox apto=new(){Text="Apto físico vigente"},ficha=new(){Text="Ficha personal completa"};
    public AltaForm()
    {
        Text="Alta de persona";Width=500;Height=480;StartPosition=FormStartPosition.CenterParent;
        condicion.Items.AddRange(new object[]{"SOCIO","NO_SOCIO"});condicion.SelectedIndex=0;
        var p=new TableLayoutPanel{Dock=DockStyle.Fill,Padding=new Padding(18),ColumnCount=2,AutoScroll=true};
        Row(p,"Nombre",nombre);Row(p,"Apellido",apellido);Row(p,"Tipo documento",tdoc);Row(p,"Documento",doc);
        Row(p,"Teléfono",tel);Row(p,"Correo",mail);Row(p,"Condición",condicion);Row(p,"",apto);Row(p,"",ficha);
        var b=new Button{Text="Guardar"};b.Click+=(_,_)=>Guardar();Row(p,"",b);
        var clear=new Button{Text="Limpiar"};clear.Click+=(_,_)=>{foreach(var x in new[]{nombre,apellido,tdoc,doc,tel,mail})x.Clear();condicion.SelectedIndex=0;apto.Checked=ficha.Checked=false;};Row(p,"",clear);
        Controls.Add(p);
    }
    static TextBox F()=>new(){Width=210};
    static void Row(TableLayoutPanel p,string s,Control c){int r=p.RowCount++;p.RowStyles.Add(new RowStyle(SizeType.AutoSize));p.Controls.Add(new Label{Text=s,AutoSize=true,Padding=new Padding(0,7,0,0)},0,r);p.Controls.Add(c,1,r);}
    void Guardar()
    {
        if(new[]{nombre.Text,apellido.Text,tdoc.Text,doc.Text,tel.Text,mail.Text}.Any(string.IsNullOrWhiteSpace)){MessageBox.Show("Todos los datos son obligatorios.");return;}
        if(!mail.Text.Contains('@')){MessageBox.Show("Correo inválido.");return;}
        if(!apto.Checked||!ficha.Checked){MessageBox.Show("Marcá apto físico y ficha personal.");return;}
        using var c=Conexion.Open();using var tx=c.BeginTransaction();
        try{
            bool esSocio=condicion.SelectedItem?.ToString()=="SOCIO";
            Persona personaModelo = esSocio ? new Socio(0,nombre.Text.Trim(),apellido.Text.Trim(),doc.Text.Trim(),apto.Checked) : new NoSocio(0,nombre.Text.Trim(),apellido.Text.Trim(),doc.Text.Trim(),apto.Checked);
            using var q=new MySqlCommand("INSERT INTO personas(nombre,apellido,tipo_documento,documento,telefono,email,es_socio,apto_fisico,ficha_completa) VALUES(@n,@a,@td,@d,@t,@e,@s,1,1)",c,tx);
            q.Parameters.AddWithValue("@n",nombre.Text.Trim());q.Parameters.AddWithValue("@a",apellido.Text.Trim());q.Parameters.AddWithValue("@td",tdoc.Text.Trim());
            q.Parameters.AddWithValue("@d",doc.Text.Trim());q.Parameters.AddWithValue("@t",tel.Text.Trim());q.Parameters.AddWithValue("@e",mail.Text.Trim());q.Parameters.AddWithValue("@s",personaModelo.ObtenerCondicion()=="SOCIO");
            q.ExecuteNonQuery();long id=q.LastInsertedId;
            if(esSocio){using var s=new MySqlCommand("INSERT INTO socios(id_persona) VALUES(@id)",c,tx);s.Parameters.AddWithValue("@id",id);s.ExecuteNonQuery();
                using var k=new MySqlCommand("INSERT INTO carnets(id_socio,fecha_emision) VALUES(@id,CURRENT_DATE)",c,tx);k.Parameters.AddWithValue("@id",s.LastInsertedId);k.ExecuteNonQuery();}
            tx.Commit();MessageBox.Show(esSocio?"Socio registrado y carnet generado.":"Persona no socia registrada.");Close();
        }catch(MySqlException ex) when(ex.Number==1062){tx.Rollback();MessageBox.Show("El documento ya está registrado.");}
        catch(Exception ex){tx.Rollback();MessageBox.Show("No se pudo guardar: "+ex.Message);}
    }
}
public sealed class CobroForm:Form
{
    TextBox doc=new(){Width=180};Label persona=new(){AutoSize=true,Text="Buscá por documento."};
    ComboBox tipo=new(){DropDownStyle=ComboBoxStyle.DropDownList,Width=180};NumericUpDown monto=new(){Minimum=1,Maximum=100000000,DecimalPlaces=2,Value=15000,Width=180};long id;
    public CobroForm()
    {
        Text="Registrar pago";Width=470;Height=300;StartPosition=FormStartPosition.CenterParent;
        tipo.Items.AddRange(new object[]{"MENSUAL","DIARIA"});tipo.SelectedIndex=0;tipo.SelectedIndexChanged+=(_,_)=>monto.Value=tipo.SelectedIndex==0?15000:2000;
        var p=new TableLayoutPanel{Dock=DockStyle.Fill,Padding=new Padding(20),ColumnCount=2};
        Row(p,"Documento",doc);var b=new Button{Text="Buscar"};b.Click+=(_,_)=>Buscar();Row(p,"",b);Row(p,"Persona",persona);Row(p,"Tipo",tipo);Row(p,"Importe",monto);
        var pay=new Button{Text="Registrar pago"};pay.Click+=(_,_)=>Pagar();Row(p,"",pay);Controls.Add(p);
    }
    static void Row(TableLayoutPanel p,string s,Control c){int r=p.RowCount++;p.RowStyles.Add(new RowStyle(SizeType.AutoSize));p.Controls.Add(new Label{Text=s,AutoSize=true,Padding=new Padding(0,7,0,0)},0,r);p.Controls.Add(c,1,r);}
    void Buscar(){using var c=Conexion.Open();using var q=new MySqlCommand("SELECT id_persona,nombre,apellido,es_socio FROM personas WHERE documento=@d",c);q.Parameters.AddWithValue("@d",doc.Text.Trim());using var r=q.ExecuteReader();
        if(!r.Read()){id=0;persona.Text="No encontrada.";return;}id=r.GetInt64(r.GetOrdinal("id_persona"));persona.Text=$"{r.GetString(r.GetOrdinal("nombre"))} {r.GetString(r.GetOrdinal("apellido"))} - {(r.GetBoolean(r.GetOrdinal("es_socio"))?"SOCIO":"NO SOCIO")}";}
    void Pagar(){if(id==0){MessageBox.Show("Buscá primero una persona.");return;}DateTime hoy=DateTime.Today, inicio=hoy;
        using var c=Conexion.Open();
        if(tipo.SelectedIndex==0){using var prev=new MySqlCommand("SELECT MAX(fecha_vencimiento) FROM pagos WHERE id_persona=@id AND tipo_pago='MENSUAL'",c);prev.Parameters.AddWithValue("@id",id);var last=prev.ExecuteScalar();if(last!=null && last!=DBNull.Value){DateTime anterior=Convert.ToDateTime(last);inicio=anterior.AddDays(1);}}
        Pago pago = tipo.SelectedIndex==0 ? new PagoMensual(monto.Value) : new PagoDiario(monto.Value);
        DateTime vence=pago.CalcularVencimiento(inicio);
        using var q=new MySqlCommand("INSERT INTO pagos(id_persona,tipo_pago,monto,fecha_pago,fecha_inicio,fecha_vencimiento) VALUES(@id,@t,@m,@h,@i,@v)",c);
        q.Parameters.AddWithValue("@id",id);q.Parameters.AddWithValue("@t",tipo.SelectedItem!.ToString());q.Parameters.AddWithValue("@m",pago.Importe);q.Parameters.AddWithValue("@h",hoy);q.Parameters.AddWithValue("@i",inicio);q.Parameters.AddWithValue("@v",vence);q.ExecuteNonQuery();
        MessageBox.Show($"Pago registrado. Vence: {vence:dd/MM/yyyy}");Close();}
}
public sealed class VencimientosForm:Form
{
    DataGridView grid=new(){Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill};
    public VencimientosForm()
    {
        Text="Vencimientos";Width=850;Height=450;StartPosition=FormStartPosition.CenterParent;
        var top=new FlowLayoutPanel{Dock=DockStyle.Top,Height=45};var b=new Button{Text="Actualizar"};b.Click+=(_,_)=>Cargar();top.Controls.Add(new Label{Text="Socios cuya cuota vence hoy",AutoSize=true,Padding=new Padding(5,10,10,0)});top.Controls.Add(b);
        Controls.Add(grid);Controls.Add(top);Load+=(_,_)=>Cargar();
    }
    void Cargar(){using var c=Conexion.Open();using var a=new MySqlDataAdapter("CALL sp_vencimientos()",c);
        var t=new DataTable();a.Fill(t);grid.DataSource=t;}
}
