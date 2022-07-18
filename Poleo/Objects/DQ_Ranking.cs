using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DQ_Ranking
    {
        private string nameStore;
        private string numberStore;
        private decimal realSales;
        private int totalCake;
        private decimal extraTopping;
        private decimal coste;
        private int extraToppingPce;
        private decimal costePor;
        private int orders;
        private decimal totalSalesCake;
        private decimal increaseSales;
        private decimal increaseOrder;
        private decimal increaseCake;
        private decimal ticketPromedio;
        private int position;

        public string NameStore
        {
            get { return nameStore; }
            set { nameStore = value; }
        }

        public string NumberStore
        {
            get { return numberStore; }
            set { numberStore = value; }
        }

        public decimal RealSales
        {
            get { return realSales; }
            set { realSales = value; }
        }

        public int TotalCake
        {
            get { return totalCake; }
            set { totalCake = value; }
        }

        public decimal ExtraTopping
        {
            get { return extraTopping; }
            set { extraTopping = value; }
        }

        public decimal Coste
        {
            get { return coste; }
            set { coste = value; }
        }

        public int ExtraToppingPce
        {
            get { return extraToppingPce; }
            set { extraToppingPce = value; }
        }

        public decimal CostePor
        {
            get { return costePor; }
            set { costePor = value; }
        }

        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public decimal TotalSalesCake
        {
            get { return totalSalesCake; }
            set { totalSalesCake = value; }
        }

        public decimal IncreaseSales
        {
            get { return increaseSales; }
            set { increaseSales = value; }
        }

        public decimal IncreaseOrder
        {
            get { return increaseOrder; }
            set { increaseOrder = value; }
        }

        public decimal IncreaseCake
        {
            get { return increaseCake; }
            set { increaseCake = value; }
        }

        public decimal TicketPromedio
        {
            get { return ticketPromedio; }
            set { ticketPromedio = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}