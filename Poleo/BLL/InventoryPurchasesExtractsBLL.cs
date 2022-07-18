using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class InventoryPurchasesExtractsBLL
    {
        #region BLL
        private IList<InventoryPurchasesExtracts> FindInvoicesWithQtyZero(int WeekNumber, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            InventoryPurchasesDAL dal = new InventoryPurchasesDAL();
            InventoryPurchasesExtracts param = new InventoryPurchasesExtracts();
            
            IList<InventoryPurchasesExtracts> lstInventoryPurchasesExtracts = new List<InventoryPurchasesExtracts>();

            DateTime DateIni = objAnioBLL.FirstDateOfWeek(Year, WeekNumber);
            DateTime DateEnd = DateIni.AddDays(6);

            param.System_Date = DateIni;
            param.DateEnd = DateEnd;
            param.Amount = 0;

            lstInventoryPurchasesExtracts = dal.SelectInvoicesQty0(param);//dal.SelectInvoicesQty0(param);

            return lstInventoryPurchasesExtracts;
        }

        private void CorrectedInvoicesQtyZero(int WeekNumber, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            InventoryPurchasesExtracts param = new InventoryPurchasesExtracts();

            DateTime DateIni = objAnioBLL.FirstDateOfWeek(Year, WeekNumber);
            DateTime DateEnd = DateIni.AddDays(6);

            param.System_Date = DateIni;
            param.DateEnd = DateEnd;
            param.Amount = 0;

            UpdateInvoicesQty0(param);
        }

        private void InsertIPEInvoiceErrorByIPE(IList<InventoryPurchasesExtracts> lstInventoryPurchasesExtracts)
        {
            foreach (InventoryPurchasesExtracts objInventoryPurchasesExtracts in lstInventoryPurchasesExtracts)
            {
                IPEInvoiceError objIPEInvoiceError = new IPEInvoiceError();
                IPEInvoiceErrorBLL objIPEInvoiceErrorBLL = new IPEInvoiceErrorBLL();

                objIPEInvoiceError.Numer_Tienda = objInventoryPurchasesExtracts.Location_Code;
                objIPEInvoiceError.Number_Invoice = objInventoryPurchasesExtracts.InvoiceNumber;
                objIPEInvoiceError.Date_Invoice = objInventoryPurchasesExtracts.System_Date;

                objIPEInvoiceErrorBLL.InsertIPEInvoiceError(objIPEInvoiceError);
            }
        }

        public void ValidateInvoice()
        {
            AnioBLL objAnioBLL = new AnioBLL();
            IList<InventoryPurchasesExtracts> lstInventoryPurchasesExtracts = new List<InventoryPurchasesExtracts>();
            DateTime date = DateTime.Now;

            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                int numberWeek = objAnioBLL.WeekId(date.AddDays(-1));

                lstInventoryPurchasesExtracts = FindInvoicesWithQtyZero(numberWeek, date.Year);

                if (lstInventoryPurchasesExtracts.Count > 0)
                {
                    InsertIPEInvoiceErrorByIPE(lstInventoryPurchasesExtracts);
                    CorrectedInvoicesQtyZero(numberWeek, date.Year);
                }
            }
        }
        #endregion

        #region DAL
        private void UpdateInvoicesQty0(InventoryPurchasesExtracts param)
        {
            InventoryPurchasesDAL dal = new InventoryPurchasesDAL();
            dal.UpdateInvoicesQty0(param);
        }
        #endregion
    }
}