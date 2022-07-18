using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ColVentas
    {
        private int numDia = 0;

        public int NumDia
        {
            get { return numDia; }
            set { numDia = value; }
        }
        private Ventas ventasDia = new Ventas();

        public Ventas VentasDia
        {
            get { return ventasDia; }
            set { ventasDia = value; }
        }
        private DateTime fecha = DateTime.Now;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}