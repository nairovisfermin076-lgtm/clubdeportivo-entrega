namespace CLUB_DEPORTIVO
{
    internal static class Program
    {
        // Mensaje de error de conexión, si existe se mostrará en el formulario de login
        public static string? ConnectionErrorMessage;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Prueba temporal de conexión a la base de datos antes de iniciar la UI
            try
            {
                using var conn = Conexion.getInstancia().CrearConexion();
                conn.Open();
                conn.Close();
                // Conexión exitosa: no mostrar notificación y continuar al login
            }
            catch (Exception ex)
            {
                // Guardar mensaje de error para mostrarlo en el login (no modal)
                ConnectionErrorMessage = ex.Message;
            }

            // Ejecutar la aplicación mostrando el formulario de login.
            Application.Run(new frmLogin());
        }
    }
}