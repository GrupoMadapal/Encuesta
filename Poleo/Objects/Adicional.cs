using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Adicional
    {
        private string location_Code;
        private string nombre_tienda;
        private int quantity;

        public string Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        public string Nombre_tienda
        {
            get { return nombre_tienda; }
            set { nombre_tienda = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}