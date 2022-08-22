// See https://aka.ms/new-console-template for more information
using ProyectoFinalConsola.Handlers;
using ProyectoFinalConsola.Model;

namespace ProyectoFinalConsola
{
    class ProbarObjetos
    {
        static void Main(string[] args)
        {
            int idUsuario = 2;


            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.TraerProducto(idUsuario);

            
            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.TraerUsuario(idUsuario);

            
            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.TraerProductoVendido(idUsuario);


            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.TraerVenta(idUsuario);
        }
    }
}