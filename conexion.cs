using MySql.Data.MySqlClient;
using System;

namespace CLUB_DEPORTIVO
{
    public class Conexion
    {
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;

        private static readonly Lazy<Conexion> instance = new Lazy<Conexion>(() => new Conexion());

        private Conexion()
        {
            baseDatos = "club";
            servidor = "localhost";
            puerto = "3306";
            usuario = "root";
            clave = "Nahi.2302";
        }

        public MySqlConnection CrearConexion()
        {
            // Construir connection string de forma más explícita
            var builder = new MySqlConnectionStringBuilder
            {
                Server = servidor,
                Port = uint.Parse(puerto),
                Database = baseDatos,
                UserID = usuario,
                Password = clave
            };

            return new MySqlConnection(builder.ConnectionString);
        }

        // para evaluar la instancia de la conectividad (thread-safe)
        public static Conexion getInstancia()
        {
            return instance.Value;
        }
    }
}

    

