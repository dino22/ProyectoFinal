﻿using ProyectoFinalConsola.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Handlers
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> TraerProductoVendido(int idUsuario)
        {
            List<ProductoVendido> productoVendido = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT P.Descripciones, P.Costo, P.PrecioVenta, P.Stock, U.NombreUsuario FROM Producto P INNER JOIN Usuario U ON U.Id = P.IdUsuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendidos = new ProductoVendido();

                                productoVendidos.IdProductoVendido = Convert.ToInt32(dataReader["Id"]);
                                productoVendidos.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendidos.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendidos.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return productoVendido;
        }

        public List<ProductoVendido> TraerProductoVendidos()
        {
            List<ProductoVendido> productoVendido = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendidos = new ProductoVendido();

                                productoVendidos.IdProductoVendido = Convert.ToInt32(dataReader["Id"]);
                                productoVendidos.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendidos.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendidos.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return productoVendido;
        }

        public void AgregarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                string queryInsert = "INSERT INTO ProductoVendido (Stock, IdProcuto, IdVenta)" +
                    " VALUES (@Stock, @IdProducto, @IdVenta)";

                SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.Int) { Value = productoVendido.Stock };
                SqlParameter idProductoParameter = new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.IdProducto };
                SqlParameter idVentaParameter = new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta };
                
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(idProductoParameter);
                    sqlCommand.Parameters.Add(idVentaParameter);
                    sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        public void QuitarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM ProductoVendido WHERE Id = @idProductoVendido";

                SqlParameter sqlParameter = new SqlParameter("idUsuario", SqlDbType.BigInt);
                sqlParameter.Value = productoVendido.IdProductoVendido;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.ExecuteScalar();
                }

                sqlConnection.Close();
            }
        }
        
    }
}
