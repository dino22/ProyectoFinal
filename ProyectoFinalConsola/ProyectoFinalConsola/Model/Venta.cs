using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class Venta
    {
        private int _idVenta;
        public string _comentarios;

        //Constructor
        public Venta(int idVenta, string comentarios)
        {
            this._idVenta = idVenta;
            this._comentarios = comentarios;
        }

        //Getters y Setters
        public int IdVenta
        {
            get { return this._idVenta; }
            set { this._idVenta = value; }
        }
        public string Comentarios
        {
            get { return this._comentarios; }
            set { this._comentarios = value; }
        }

    }
}
