using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalConsola.Model;

namespace ProyectoFinalConsola.Handlers
{
    public class LoginHandler : DbHandler
    {
        public void ValidarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string querySelect = "SELEC NombreUsuario, Contraseña FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrseña";

                    SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                    nombreUsuarioParameter.Value = usuario.NombreUsuario;

                    SqlParameter contraseñaParameter = new SqlParameter("contraseña", SqlDbType.VarChar);
                    contraseñaParameter.Value = usuario.Contraseña;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreUsuarioParameter);
                        sqlCommand.Parameters.Add(contraseñaParameter);
                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
