using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola.Model
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        //Constructor
        public Usuario(int idUsuario, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this._idUsuario = idUsuario;
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contraseña = contraseña;
            this._mail = mail;
        }

        //Getters y Setters
        public int IdUsuario
        {
            get { return this._idUsuario; }
            set { this._idUsuario = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public string NombreUsuario
        {
            get { return this._nombreUsuario; }
            set { this._nombreUsuario = value; }
        }
        public string Contraseña
        {
            get { return this._contraseña; }
            set { this._contraseña = value; }
        }
        public string Mail
        {
            get { return this._mail; }
            set { this._mail = value; }
        }

    }
}
