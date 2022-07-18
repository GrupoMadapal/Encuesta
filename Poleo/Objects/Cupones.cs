using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Cupones
    {
        private string descripcion;
        private string codigo;
        private DateTime? validity;
        private bool active;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public DateTime? Validity
        {
            get { return validity; }
            set { validity = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        #region Reporte Cupones
        private DateTime ord_Dt;
        private string couponCode;
        private int countOrdenCupon;
        private int order_Count;
        private decimal net_Sales;
        private decimal porcOrderCupon;
        private decimal menu_Amt;
        private decimal disc_Amt;
        private decimal net_Amt;
        private decimal tax_Amt;
        private decimal cust_Amt;

        public DateTime Ord_Dt
        {
            get { return ord_Dt; }
            set { ord_Dt = value; }
        }

        public string CouponCode
        {
            get { return couponCode; }
            set { couponCode = value; }
        }

        public int CountOrdenCupon
        {
            get { return countOrdenCupon; }
            set { countOrdenCupon = value; }
        }

        public int Order_Count
        {
            get { return order_Count; }
            set { order_Count = value; }
        }

        public decimal Net_Sales
        {
            get { return net_Sales; }
            set { net_Sales = value; }
        }

        public decimal PorcOrderCupon
        {
            get { return porcOrderCupon; }
            set { porcOrderCupon = value; }
        }

        public decimal Menu_Amt
        {
            get { return menu_Amt; }
            set { menu_Amt = value; }
        }

        public decimal Disc_Amt
        {
            get { return disc_Amt; }
            set { disc_Amt = value; }
        }

        public decimal Net_Amt
        {
            get { return net_Amt; }
            set { net_Amt = value; }
        }

        public decimal Tax_Amt
        {
            get { return tax_Amt; }
            set { tax_Amt = value; }
        }

        public decimal Cust_Amt
        {
            get { return cust_Amt; }
            set { cust_Amt = value; }
        }
        #endregion
    }
}