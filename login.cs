namespace CLUB_DEPORTIVO
{
    public partial class frmLogin : Form
    {
        // (No events) El login abrirá el menú y se esconderá mientras el menú esté abierto.

        public frmLogin()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Si Program indicó un error de conexión, mostrar notificación no modal
            if (!string.IsNullOrWhiteSpace(Program.ConnectionErrorMessage))
            {
                NotificationForm.ShowNotificationNonModal($"Error al conectar con la base de datos:\n{Program.ConnectionErrorMessage}", 5000);
                // Limpiar el mensaje para no mostrarlo repetidamente
                Program.ConnectionErrorMessage = null;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.ForeColor = Color.DimGray;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO" || txtContrasena.Text == "CONTRASEÑA")
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }
            try
            {
                var usuarios = new Usuarios();
                var tabla = usuarios.Log_Usu(txtUsuario.Text.Trim(), txtContrasena.Text);

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    // Credenciales válidas: limpiar campos de entrada antes de abrir el menú
                    txtUsuario.Text = "USUARIO";
                    txtUsuario.ForeColor = Color.DimGray;
                    txtContrasena.Text = "CONTRASEÑA";
                    txtContrasena.ForeColor = Color.DimGray;
                    txtContrasena.UseSystemPasswordChar = false;

                    // Abrir menú principal y mantener el login detrás
                    var menu = new Resources.menu_principal();
                    this.Hide();
                    menu.ShowDialog();
                    this.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Limpiar solo el campo de contraseña después de un intento fallido
                    txtContrasena.Text = "CONTRASEÑA";
                    txtContrasena.ForeColor = Color.DimGray;
                    txtContrasena.UseSystemPasswordChar = false;
                    txtContrasena.Focus();
                }
            }
            catch (Exception ex)
            {
                // Mostrar error no modal en el login
                NotificationForm.ShowNotificationNonModal($"Error al validar credenciales:\n{ex.Message}", 5000);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar toda la aplicación al presionar SALIR
            Application.Exit();
        }
    }
}