using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class Producto
    {
        private int _idProducto;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

        //Constructor
        public Producto(int idProducto, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            this._idProducto = idProducto;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsuario = idUsuario;
        }

        //Getters y Setters
        public int IdProducto
        {
            get { return this._idProducto; }
            set { this._idProducto = value; }
        }
        public string Descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }
        public double Costo
        {
            get { return this._costo; }
            set { this._costo = value; }
        }
        public double PrecioVenta
        {
            get { return this._precioVenta; }
            set { this._precioVenta = value; }
        }
        public int Stock
        {
            get { return this._stock; }
            set { this._stock = value; }
        }
        public int IdUsuario
        {
            get { return this._idUsuario; }
            set { this._idUsuario = value; }
        }

    }
}
