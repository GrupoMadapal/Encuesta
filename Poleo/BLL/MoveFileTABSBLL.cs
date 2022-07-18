using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;

namespace Poleo.BLL
{
    public class MoveFileTABSBLL
    {
        public void MoveFiles(int IdShcheduleTransfer)
        {
            TAB_sBLL objTAB_sBLL = new TAB_sBLL();
            TAB_s objTAB_s = new TAB_s();
            TransferBLL objTransferBLL = new TransferBLL();
            ConfigFilesTABSBLL objConfigFilesTABSBLL = new ConfigFilesTABSBLL();
            IList<ConfigFilesTABS> lstConfigFilesTABS = new List<ConfigFilesTABS>();

            lstConfigFilesTABS = objConfigFilesTABSBLL.SelectConfigFilesTABs();

            foreach (ConfigFilesTABS objConfigFilesTABS in lstConfigFilesTABS)
            {
                objTAB_s = objTAB_sBLL.SelectMoveFiles(objConfigFilesTABS.DirOrigen);

                if (objTAB_s != null)
                {
                    objTAB_sBLL.MoveFilesTABS(objConfigFilesTABS.DirDestino, objTAB_s);

                    Transfer objTransfer = new Transfer();

                    objTransfer.IDScheduleTransfer = IdShcheduleTransfer;
                    objTransfer.Numer_Tienda = objConfigFilesTABS.Numer_Tienda;
                    objTransfer.DateTransferIni = DateTime.Now;
                    objTransfer.SuccessfulTransfer = true;
                    objTransferBLL.InsertUpdateTransfer(objTransfer);
                }
            }
        }
    }
}