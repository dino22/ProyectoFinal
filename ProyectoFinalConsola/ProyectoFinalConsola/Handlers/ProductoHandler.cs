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
    public class ProductoHandler : DbHandler
    {
        public List<Producto> TraerProducto(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idUsuario";
                    sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    sqlConnection.Close();

                    foreach(DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();
                        producto.Id = Convert.ToInt32(row["id"]);
                        producto.Descripciones = row["Descripciones"].ToString();
                        producto.Costo = Convert.ToInt32(row["Costo"]);
                        producto.PrecioVenta = Convert.ToInt32(row["PrecioVenta"]);
                        producto.Stock = Convert.ToInt32(row["Stock"]);
                        producto.IdUsuario = Convert.ToInt32(row["idUsuario"]);

                        productos.Add(producto);
                    }

                }
            }
            return productos;
        }

        public void AgregarProducto(Producto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                string queryInsert = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    " VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Int) { Value = producto.Costo };
                SqlParameter precioVentaParameter = new SqlParameter("PrecioVenta", SqlDbType.VarChar) { Value = producto.PrecioVenta };
                SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock };
                SqlParameter idUsuarioParameter = new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripcionesParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioVentaParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(idUsuarioParameter);
                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void QuitarProducto(Producto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Productio WHERE Id = @idProducto";

                SqlParameter sqlParameter = new SqlParameter("idProducto", SqlDbType.BigInt);
                sqlParameter.Value = producto.Id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                sqlConnection.Close();
            }
        }

        public void ModificarProducto(Producto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE Producto SET Descripciones = @nuevaDescripcion WHERE Id = @idProducto";

                SqlParameter parametroNuevaCopntraseña = new SqlParameter();

                parametroNuevaCopntraseña.ParameterName = "nuevaDescripcion";
                parametroNuevaCopntraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                parametroNuevaCopntraseña.Value = producto.Descripciones;

                SqlParameter parametroUsuarioId = new SqlParameter();

                parametroUsuarioId.ParameterName = "idProducto";
                parametroUsuarioId.SqlDbType = System.Data.SqlDbType.BigInt;
                parametroUsuarioId.Value = producto.Id;

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
