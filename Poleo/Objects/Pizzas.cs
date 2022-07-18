using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Pizzas
    {
        private String tienda = String.Empty;

        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }
        
        private String producto = String.Empty;

        public String Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        private int cantidad = 0;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private String size = string.Empty;

        public String Size
        {
            get { return size; }
            set { size = value; }
        }
        private String code = string.Empty;

        public String Code
        {
            get { return code; }
            set { code = value; }
        }
        private String descripcion = String.Empty;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


       

    }
}