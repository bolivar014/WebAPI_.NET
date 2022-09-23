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
            using (SqlConnection objConexion = new SqlConnection(Conexion.conexionDB))
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
                } catch (Exception ex)
                {
                    return false;
                }
            }
        }
        // Evento para Actualizar USUARIOS en base de datos
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

        // Evento para listar usuarios
        public static List<Usuario> Listar()
        {
            List<Usuario> objListaUsuarios = new List<Usuario>();
            using (SqlConnection objConexion = new SqlConnection(Conexion.conexionDB))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    objConexion.Open();
                    // cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objListaUsuarios.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            });
                        }

                        // 
                        return objListaUsuarios;
                    }
                } catch (Exception ex)
                {
                    return objListaUsuarios;
                }
            }
        }

        // Retornamos usuario a consultar...
        public static Usuario Obtener(int idUsuario)
        {
            Usuario objUsuario = new Usuario();
            using (SqlConnection objConexion = new SqlConnection(Conexion.conexionDB))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idUsuario);

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            };
                        }

                        // 
                        return objUsuario;
                    }
                }
                catch (Exception ex)
                {
                    return objUsuario;
                }
            }
        }

        // 
        public static bool Eliminar(int idUsuario)
        {
            using(SqlConnection objConexion = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idUsuario);

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
