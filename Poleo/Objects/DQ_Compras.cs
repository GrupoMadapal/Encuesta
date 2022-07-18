using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DQ_Compras
    {
        private DateTime dateIni;
        private DateTime dateEnd;
        private string sucursal;
        private int galones;

        public DateTime DateIni
        {
            get { return dateIni; }
            set { dateIni = value; }
        }

        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        public string Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        public int Galones
        {
            get { return galones; }
            set { galones = value; }
        }
    }
}