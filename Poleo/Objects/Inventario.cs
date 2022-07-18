using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Inventario
    {
        private String code = String.Empty;

        public String Code
        {
            get { return code; }
            set { code = value; }
        }
        private String producto = String.Empty;

        public String Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        private Decimal precioUnitario = 0;

        public Decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }
        private Decimal beginning_Qty = 0;

        public Decimal Beginning_Qty
        {
            get { return beginning_Qty; }
            set { beginning_Qty = value; }
        }
        private Decimal delivered_Qty = 0;

        public Decimal Delivered_Qty
        {
            get { return delivered_Qty; }
            set { delivered_Qty = value; }
        }
        private Decimal starting_Qty = 0;

        public Decimal Starting_Qty
        {
            get { return starting_Qty; }
            set { starting_Qty = value; }
        }
        private Decimal ending_Qty = 0;

        public Decimal Ending_Qty
        {
            get { return ending_Qty; }
            set { ending_Qty = value; }
        }
        private Decimal actual_usage = 0;

        public Decimal Actual_Usage
        {
            get { return actual_usage; }
            set { actual_usage = value; }
        }
        private Decimal ideal_Usage = 0;

        public Decimal Ideal_Usage
        {
            get { return ideal_Usage; }
            set { ideal_Usage = value; }
        }
        private Decimal inventario_Inicial = 0;

        public Decimal Inventario_Inicial
        {
            get { return inventario_Inicial; }
            set { inventario_Inicial = value; }
        }

        private Decimal inventario_Final = 0;

        public Decimal Inventario_Final
        {
            get { return inventario_Final; }
            set { inventario_Final = value; }
        }

    }
}