using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class ProductoVendido
    {
        private int _idProductoVendido;
        private int _idProducto;
        private int _stock;
        private int _idVenta;

        //Constructor
        public ProductoVendido(int idProductoVendido, int idProducto, int stock, int idVenta)
        {
            this._idProductoVendido = idProductoVendido;
            this._idProducto = idProducto;
            this._stock = stock;
            this._idVenta = idVenta;
        }

        //Getters y Setters
        public int IdProductoVendido
        {
            get { return this._idProductoVendido; }
            set { this._idProductoVendido = value; }
        }
        public int IdProducto
        {
            get { return this._idProducto; }
            set { this._idProducto = value; }
        }
        public int Stock
        {
            get { return this._stock; }
            set { this._stock = value; }
        }
        public int IdVenta
        {
            get { return this._idVenta; }
            set { this._idVenta = value; }
        }

    }
}
