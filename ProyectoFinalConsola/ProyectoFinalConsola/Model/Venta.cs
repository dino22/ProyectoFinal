using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class Venta
    {
        private int _id;
        public string _comentarios;

        //Constructor
        public Venta(int id, string comentarios)
        {
            this._id = id;
            this._comentarios = comentarios;
        }

        //Getters y Setters
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string Comentarios
        {
            get { return this._comentarios; }
            set { this._comentarios = value; }
        }

    }
}
