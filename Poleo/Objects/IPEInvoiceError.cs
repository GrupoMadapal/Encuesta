using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class IPEInvoiceError
    {
        private int idIPEInvoiceError;
		private string numer_Tienda;
		private string number_Invoice;
        private DateTime date_Invoice;

        public int IdIPEInvoiceError
        {
            get { return idIPEInvoiceError; }
            set { idIPEInvoiceError = value; }
        }

        public string Numer_Tienda
        {
            get { return numer_Tienda; }
            set { numer_Tienda = value; }
        }

        public string Number_Invoice
        {
            get { return number_Invoice; }
            set { number_Invoice = value; }
        }

        public DateTime Date_Invoice
        {
            get { return date_Invoice; }
            set { date_Invoice = value; }
        }
    }
}