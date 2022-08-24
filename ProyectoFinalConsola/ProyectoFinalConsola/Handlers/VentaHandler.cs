using ProyectoFinalConsola.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProyectoFinalConsola.Handlers
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> TraerVenta(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT U.NombreUsuario, PV.Stock, P.Descripciones, P.Costo, P.PrecioVenta, V.Comentarios FROM ProductoVendido PV INNER JOIN Producto P ON P.Id = PV.IdProducto INNER JOIN Usuario U ON U.Id = P.IdUsuario INNER JOIN Venta V ON V.Id = PV.IdVenta WHERE U.Id = @idUsuario";

                SqlParameter idUsuarioParameter = new SqlParameter("IdUsuario", System.Data.SqlDbType.BigInt) { Value = idUsuario };
                
                sqlConnection.Open();
                
                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlCommand.Parameters.Add(idUsuarioParameter);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                Producto producto = new Producto();
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);

                                Usuario usuario = new Usuario();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();

                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return ventas;
        }
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

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
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

                    parametroNuevoComentario.ParameterName = "nuevoComentario";
                    parametroNuevoComentario.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNuevoComentario.Value = venta.Comentarios;

                    SqlParameter parametroVentaId = new SqlParameter();

                    parametroVentaId.ParameterName = "idVenta";
                    parametroVentaId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroVentaId.Value = venta.Id;

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
