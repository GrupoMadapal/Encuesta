using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DQ_VentasArticulos : DQ_Ventas
    {
        private decimal ventasTotalesArtic;
        private decimal articCostoDinero;
        private decimal costoPorc;
        private decimal ventasTotalesPasteles;
        private decimal pastelesCostoDinero;
        private decimal pastelesCostoPorc;
        private decimal ventasTotalesOtros;
        private decimal otrosCostoDinero;
        private decimal otrosCostoPorc;

        public decimal VentasTotalesArtic
        {
            get { return ventasTotalesArtic; }
            set { ventasTotalesArtic = value; }
        }

        public decimal VentasTotalesPasteles
        {
            get { return ventasTotalesPasteles; }
            set { ventasTotalesPasteles = value; }
        }

        public decimal VentasTotalesOtros
        {
            get { return ventasTotalesOtros; }
            set { ventasTotalesOtros = value; }
        }

        public decimal ArticCostoDinero
        {
            get { return articCostoDinero; }
            set { articCostoDinero = value; }
        }
        public decimal CostoPorc
        {
            get { return costoPorc; }
            set { costoPorc = value; }
        }
        public decimal PastelesCostoDinero
        {
            get { return pastelesCostoDinero; }
            set { pastelesCostoDinero = value; }
        }
        public decimal PastelesCostoPorc
        {
            get { return pastelesCostoPorc; }
            set { pastelesCostoPorc = value; }
        }
        public decimal OtrosCostoDinero
        {
            get { return otrosCostoDinero; }
            set { otrosCostoDinero = value; }
        }
        public decimal OtrosCostoPorc
        {
            get { return otrosCostoPorc; }
            set { otrosCostoPorc = value; }
        }
    }
}