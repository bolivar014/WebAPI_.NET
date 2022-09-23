using System.Data;
using System.Data.SqlClient;
using WebApi_TEST.Models;

namespace WebApi_TEST.Data
{
    public class UsuarioData
    {
        // Evento para registrar USUARIOS en base de datos
        public static bool Registrar(Usuario objUsuario)
        {
            // Creamos conexión en DB desde data.Conexion
            using(SqlConnection objConexion = new SqlConnection(Conexion.conexionDB))
            {
                // Ejecutamos SP usp_registrar y enviamos sus respectivos argumentos
                SqlCommand cmd = new SqlCommand("usp_registrar", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", objUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", objUsuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", objUsuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", objUsuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", objUsuario.Ciudad);

                // Ejecutamos evento
                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch ( Exception ex )
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Usuario objUsuario)
        {
            using (SqlConnection objConexion = new SqlConnection(Conexion.conexionDB))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", objUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", objUsuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", objUsuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", objUsuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", objUsuario.Ciudad);

                // Ejecutamos evento
                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
