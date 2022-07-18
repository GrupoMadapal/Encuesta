using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.DAL
{
    public class IPEInvoiceErrorBLL
    {
        #region BLL
        private void InsertIPEInvoiceError(IList<IPEInvoiceError> lstIPEInvoiceError)
        {
            foreach (IPEInvoiceError objIPEInvoiceError in lstIPEInvoiceError)
            {
                InsertIPEInvoiceError(objIPEInvoiceError);
            }
        }
        #endregion

        #region DAL
        public void InsertIPEInvoiceError(IPEInvoiceError param)
        {
            IPEInvoiceErrorDAL dal = new IPEInvoiceErrorDAL();
            dal.InsertIPEInvoiceError(param);
        }
        #endregion
    }
}