// See https://aka.ms/new-console-template for more information
using ProyectoFinalConsola.Handlers;
using ProyectoFinalConsola.Model;

namespace ProyectoFinalConsola
{
    class ProbarObjetos
    {
        static void Main(string[] args)
        {
            LoginHandler usuarioIn = new LoginHandler();

            usuarioIn.ValidarUsuario(Usuario usuario);


            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.TraerProductos();

            
            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.TraerUsuarios();

            
            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.TraerProductoVendidos();


            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.TraerVentas();
        }
    }
}