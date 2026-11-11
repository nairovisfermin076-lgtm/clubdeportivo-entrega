namespace CLUB_DEPORTIVO
{
    partial class frmAltaSocios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbx1 = new PictureBox();
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDocumento = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDocumento = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            txtMail = new TextBox();
            lblMail = new Label();
            chkAptoMedico = new CheckBox();
            chkFichaPersonal = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Image = Properties.Resources.ESCUDO_CLUB;
            pbx1.Location = new Point(263, 12);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(208, 110);
            pbx1.SizeMode = PictureBoxSizeMode.Zoom;
            pbx1.TabIndex = 2;
            pbx1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 125);
            label1.Name = "label1";
            label1.Size = new Size(209, 15);
            label1.TabIndex = 3;
            label1.Text = "INGRESE LOS DATOS DEL SOLICITANTE";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(266, 143);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(60, 19);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "SOCIO";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(367, 143);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(81, 19);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "NO SOCIO";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(28, 176);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "NOMBRE";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(262, 176);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(60, 15);
            lblApellido.TabIndex = 7;
            lblApellido.Text = "APELLIDO";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(242, 222);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(80, 15);
            lblDocumento.TabIndex = 8;
            lblDocumento.Text = "DOCUMENTO";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(90, 173);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(154, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(332, 173);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(160, 23);
            txtApellido.TabIndex = 10;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(332, 214);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(160, 23);
            txtDocumento.TabIndex = 11;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Location = new Point(117, 347);
            button1.Name = "button1";
            button1.Size = new Size(127, 28);
            button1.TabIndex = 12;
            button1.Text = "GUARDAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 255, 128);
            button2.Location = new Point(309, 347);
            button2.Name = "button2";
            button2.Size = new Size(122, 28);
            button2.TabIndex = 13;
            button2.Text = "LIMPIAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Location = new Point(486, 347);
            button3.Name = "button3";
            button3.Size = new Size(122, 28);
            button3.TabIndex = 14;
            button3.Text = "VOLVER";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(28, 219);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(32, 15);
            lblTipo.TabIndex = 16;
            lblTipo.Text = "TIPO";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "DNI", "PASAPORTE", "C.I. ", "OTRO" });
            cmbTipo.Location = new Point(90, 216);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 23);
            cmbTipo.TabIndex = 17;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(509, 176);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(21, 15);
            lblTelefono.TabIndex = 18;
            lblTelefono.Text = "Tel";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(537, 175);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(152, 23);
            txtTelefono.TabIndex = 19;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(540, 217);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(149, 23);
            txtMail.TabIndex = 20;
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(509, 222);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(30, 15);
            lblMail.TabIndex = 21;
            lblMail.Text = "Mail";
            // 
            // chkAptoMedico
            // 
            chkAptoMedico.AutoSize = true;
            chkAptoMedico.Location = new Point(231, 267);
            chkAptoMedico.Name = "chkAptoMedico";
            chkAptoMedico.Size = new Size(95, 19);
            chkAptoMedico.TabIndex = 22;
            chkAptoMedico.Text = "Apto Medico";
            chkAptoMedico.UseVisualStyleBackColor = true;
            chkAptoMedico.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkFichaPersonal
            // 
            chkFichaPersonal.AutoSize = true;
            chkFichaPersonal.Location = new Point(413, 267);
            chkFichaPersonal.Name = "chkFichaPersonal";
            chkFichaPersonal.Size = new Size(102, 19);
            chkFichaPersonal.TabIndex = 23;
            chkFichaPersonal.Text = "Ficha Personal";
            chkFichaPersonal.UseVisualStyleBackColor = true;
            // 
            // frmAltaSocios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(740, 450);
            Controls.Add(chkFichaPersonal);
            Controls.Add(chkAptoMedico);
            Controls.Add(lblMail);
            Controls.Add(txtMail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtDocumento);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblDocumento);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(pbx1);
            Name = "frmAltaSocios";
            Text = "ALTA SOCIO/NO SOCIO";
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbx1;
        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDocumento;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDocumento;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private TextBox txtMail;
        private Label lblMail;
        private CheckBox chkAptoMedico;
        private CheckBox chkFichaPersonal;
    }
}