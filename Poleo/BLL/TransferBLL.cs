using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;
using System.Configuration;

namespace Poleo.BLL
{
    public class TransferBLL
    {
        #region BLL
        public bool ValidTransferByStore(string Number_Tienda, DateTime date, int IdShchedule)
        {
            //IList<ShcheduleTransfer> lstShcheduleTransfer = new List<ShcheduleTransfer>();
            //ShcheduleTransferBLL objShcheduleTransferBLL = new ShcheduleTransferBLL();

            //lstShcheduleTransfer = objShcheduleTransferBLL.SelectShcheduleTransfer();

            //foreach (ShcheduleTransfer objShcheduleTransfer in lstShcheduleTransfer)
            //{
                IList<Transfer> lstTransfer = new List<Transfer>();
                Transfer TransferFinder = new Transfer();

                TransferFinder.Numer_Tienda = Number_Tienda;
                TransferFinder.DateTransferIni = date;//DateTime.Now;
                TransferFinder.IDScheduleTransfer = IdShchedule;//objShcheduleTransfer.IDScheduleTransfer;

                lstTransfer = SelectTransfer(TransferFinder);

                if (lstTransfer.Count > 0)
                    return true;//lstTransfer[0];
                else
                    return false;
            //}

            //return null;
        }

        public void InsertUpdateTransfer(Transfer param)
        {
            IList<Transfer> lstTransfer = new List<Transfer>();

            lstTransfer = SelectTransfer(param);

            if (lstTransfer.Count > 0)
            {
                int Attempt = lstTransfer[0].AttemptsTransfer;

                Attempt++;
                param = lstTransfer[0];
                param.AttemptsTransfer = Attempt;

                UpdateTransfer(param);
            }
            else
            {
                param.AttemptsTransfer = 1;
                InsertTransfer(param);
            }
        }

        public bool ValidateAttemps(string Number_Tienda, int IdShchedule, DateTime date)
        {
            IList<Transfer> lstTransfer = new List<Transfer>();
            Transfer TransferFinder = new Transfer();
            int TAttempts = 0;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TransferAttempts"].ToString()))
                TAttempts = int.Parse(ConfigurationManager.AppSettings["TransferAttempts"].ToString());

            TransferFinder.Numer_Tienda = Number_Tienda;
            TransferFinder.DateTransferIni = date;
            TransferFinder.IDScheduleTransfer = IdShchedule;

            lstTransfer = SelectTransfer(TransferFinder);

            if (lstTransfer[0].AttemptsTransfer < TAttempts)
                return true;
            else
                return false;
        }
        #endregion

        #region DAL
        public IList<Transfer> SelectTransfer(Transfer param)
        {
            TransferDAL dal = new TransferDAL();
            return dal.SelectTransfer(param);
        }

        public Transfer SelectLastTransfer(Transfer param)
        {
            TransferDAL dal = new TransferDAL();
            return dal.SelectLastTransfer(param);
        }

        private void InsertTransfer(Transfer param)
        {
            TransferDAL dal = new TransferDAL();
            dal.InsertTransfer(param);
        }

        private void UpdateTransfer(Transfer param)
        {
            TransferDAL dal = new TransferDAL();
            dal.UpdateTransfer(param);
        }
        #endregion
    }
}