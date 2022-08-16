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
    public class VentaHandler : DbHandler
    {
        public List<Venta> TraerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.IdVenta = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return ventas;
        }

        public void AgregarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryInsert = "INSERT INTO Venta (Comentarios) VALUES (@Comentarios)";

                    SqlParameter comentarioParameter = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios };


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(comentarioParameter);

                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void QuitarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Venta WHERE Id = @idVenta";

                    SqlParameter sqlParameter = new SqlParameter("idComentario", SqlDbType.BigInt);
                    sqlParameter.Value = venta.Comentarios;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ModificarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "UPDATE Venta SET Comentarios = @nuevoComentario WHERE Id = @idVenta";

                    SqlParameter parametroNuevoComentario = new SqlParameter();

                    parametroNuevoComentario.ParameterName = "nuevaComentario";
                    parametroNuevoComentario.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNuevoComentario.Value = venta.Comentarios;

                    SqlParameter parametroVentaId = new SqlParameter();

                    parametroVentaId.ParameterName = "idVenta";
                    parametroVentaId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroVentaId.Value = venta.IdVenta;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroVentaId);
                        sqlCommand.Parameters.Add(parametroNuevoComentario);
                        //sqlCommand.ExecuteNonQuery();
                        int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
