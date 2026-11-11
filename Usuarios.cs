using MySql.Data.MySqlClient;
using System.Data;

namespace CLUB_DEPORTIVO
{
    internal class Usuarios
    {
        public DataTable Log_Usu(string usuario, string contrasenia)
        {
            var tabla = new DataTable();

            using var sqlCon = Conexion.getInstancia().CrearConexion();
            using var comando = new MySqlCommand("ingresoLogin", sqlCon) { CommandType = CommandType.StoredProcedure };

            comando.Parameters.Add("p_usuario", MySqlDbType.VarChar).Value = usuario;
            comando.Parameters.Add("p_clave", MySqlDbType.VarChar).Value = contrasenia;

            sqlCon.Open();
            using var resultado = comando.ExecuteReader();
            tabla.Load(resultado);
            return tabla;
        }
    }
}
