using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class RowVentas
    {
        private int numeroSemana = 0;

        public int NumeroSemana
        {
            get { return numeroSemana; }
            set { numeroSemana = value; }
        }
        private List<ColVentas> lstColVentas = new List<ColVentas>();

        public List<ColVentas> LstColVentas
        {
            get { return lstColVentas; }
            set { lstColVentas = value; }
        }
        private Decimal totalSemana = 0;

        public Decimal TotalSemana
        {
            get { return totalSemana; }
            set { totalSemana = value; }
        }
    }
}