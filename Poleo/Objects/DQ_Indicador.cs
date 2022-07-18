using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DQ_Indicador
    {
        private decimal totalSales;
        private decimal target;
        private int salesLastWeek;
        private int salesLastYear;
        private int transactions;
        private int transactionsLastWeek;
        private int transactionsLastYear;
        private decimal totalPurchaseInvoice;
        private decimal totalCosteMerma;
        private decimal realSales;
        private int orders;
        private decimal costeIdeal;
        private string articulo;

        public decimal TotalSales
        {
            get { return totalSales; }
            set { totalSales = value; }
        }

        public decimal Target
        {
            get { return target; }
            set { target = value; }
        }

        public int SalesLastWeek
        {
            get { return salesLastWeek; }
            set { salesLastWeek = value; }
        }

        public int SalesLastYear
        {
            get { return salesLastYear; }
            set { salesLastYear = value; }
        }

        public int Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }

        public int TransactionsLastWeek
        {
            get { return transactionsLastWeek; }
            set { transactionsLastWeek = value; }
        }

        public int TransactionsLastYear
        {
            get { return transactionsLastYear; }
            set { transactionsLastYear = value; }
        }

        public decimal TotalPurchaseInvoice
        {
            get { return totalPurchaseInvoice; }
            set { totalPurchaseInvoice = value; }
        }

        public decimal TotalCosteMerma
        {
            get { return totalCosteMerma; }
            set { totalCosteMerma = value; }
        }

        public decimal RealSales
        {
            get { return realSales; }
            set { realSales = value; }
        }

        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public decimal CosteIdeal
        {
            get { return costeIdeal; }
            set { costeIdeal = value; }
        }
    }
}