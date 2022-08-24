using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        /*private int _id;
        private int _idProducto;
        private int _stock;
        private int _idVenta;

        //Constructor
        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            this._id = id;
            this._idProducto = idProducto;
            this._stock = stock;
            this._idVenta = idVenta;
        }

        //Getters y Setters
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
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
        }*/

    }
}
