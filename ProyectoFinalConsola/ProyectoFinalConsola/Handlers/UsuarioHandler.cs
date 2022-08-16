using ProyectoFinalConsola.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Handlers
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> TraerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {   
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.IdUsuario = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return usuarios;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                string queryInsert = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                    " VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

                SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter nombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter mailParameter = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(mailParameter);
                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void QuitarUsuario(Usuario usuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Usuario WHERE Id = @idUsuario";

                SqlParameter sqlParameter = new SqlParameter("idUsuario", SqlDbType.BigInt);
                sqlParameter.Value = usuario.IdUsuario;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                sqlConnection.Close();
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE Usuario SET Contraseña = @nuevaContraseña WHERE Id = @idUsuairo";

                SqlParameter parametroNuevaCopntraseña = new SqlParameter();

                parametroNuevaCopntraseña.ParameterName = "nuevaContraseña";
                parametroNuevaCopntraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                parametroNuevaCopntraseña.Value = usuario.Contraseña;

                SqlParameter parametroUsuarioId = new SqlParameter();

                parametroUsuarioId.ParameterName = "idUsuario";
                parametroUsuarioId.SqlDbType = System.Data.SqlDbType.BigInt;
                parametroUsuarioId.Value = usuario.IdUsuario;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroUsuarioId);
                    sqlCommand.Parameters.Add(parametroNuevaCopntraseña);
                    //sqlCommand.ExecuteNonQuery();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }
    }
}
