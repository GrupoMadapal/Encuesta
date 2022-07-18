using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Tienda
    {
        private String nombre_Tienda = string.Empty;
        public String Nombre_tienda
        {
            get { return nombre_Tienda; }
            set { nombre_Tienda = value; }
        }

        private String numero_tienda = string.Empty;
        public String Number_tienda
        {
            get { return numero_tienda; }
            set { numero_tienda = value; }
        }

        private String tipo = String.Empty;
        public String Tipo
        {
            get {

                return tipo; 
            }
            set { tipo = value; }
        }

        private String ubicacion = string.Empty;
        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        private String gerente = String.Empty;
        public String Gerente
        {
            get { return gerente; }
            set { gerente = value; }
        }
        
        private String namefull = String.Empty;
        public String Namefull
        {
            get { return namefull; }
            set { namefull = value; }
        }

        private String code = String.Empty;
        public String Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}