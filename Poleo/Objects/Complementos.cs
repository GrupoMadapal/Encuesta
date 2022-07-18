using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Complementos
    {
        private String tienda = string.Empty;

        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }
        private String producto = string.Empty;

        public String Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        private String categoria = String.Empty;

        public String Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        private int cantidad = 0;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}