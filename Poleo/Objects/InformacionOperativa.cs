using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class InformacionOperativa
    {
        private decimal tomaOrden = 0;

        public decimal TomaOrden
        {
            get { return tomaOrden; }
            set { tomaOrden = value; }
        }
        private Decimal produccion = 0;

        public Decimal Produccion
        {
            get { return produccion; }
            set { produccion = value; }
        }
        private Decimal repisa = 0;

        public Decimal Repisa
        {
            get { return repisa; }
            set { repisa = value; }
        }
        private Decimal fueraTienda = 0;

        public Decimal FueraTienda
        {
            get { return fueraTienda; }
            set { fueraTienda = value; }
        }
        private Decimal entrega = 0;

        public Decimal Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }
    }
}