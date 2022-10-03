using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaA
{
    internal class Usuario
    {
        private string userName;
        private string clave;
        private int intentos;

        public Usuario()
        {

        }

        public Usuario(string userName, string clave,int intentos)
        {
            this.userName = userName;
            this.clave = clave;
            this.intentos = intentos;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public int Intentos
        {
            get { return intentos; }
            set { intentos = value; }
        }

        public bool IniciarSession()
        {
            if (UserName.Equals("ADMIN") && Clave.Equals("12345"))
            {
                return true;
            }
            else
            {
                intentos++;
                return false;
            }
            
        }

        public bool VerificarIntentos (){
            if (this.intentos>3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
