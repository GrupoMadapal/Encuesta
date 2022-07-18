using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class SalesLastYear
    {

        private int ordenes = 0;

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }
        private Decimal ventasReales = 0;

        public Decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }
        private int numDias = 0;

        public int NumDias
        {
            get { return numDias; }
            set { numDias = value; }
        }
    }
}