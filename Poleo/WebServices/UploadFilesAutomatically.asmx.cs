using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Poleo.BLL;
using Poleo.Controls;

namespace Poleo.WebServices
{
    /// <summary>
    /// Descripción breve de UploadFilesAutomatically
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class UploadFilesAutomatically : System.Web.Services.WebService
    {
        [WebMethod(false, EnableSession=false)]
        public void UploadFiles(int IdTransfer)
        {
            InventoryPurchasesExtractsBLL objInventoryPurchasesExtractsBLL = new InventoryPurchasesExtractsBLL();
            MoveFileTABSBLL objMoveFileTABSBLL = new MoveFileTABSBLL();
            UpLoadFile objUpLoadFile = new UpLoadFile();

            objMoveFileTABSBLL.MoveFiles(IdTransfer);
            objUpLoadFile.blockForm = true;
            objUpLoadFile.btnUpLoadAUTO_Click(null, null);
            objInventoryPurchasesExtractsBLL.ValidateInvoice();
        }

        [WebMethod]
        public int? ExecuteTransfer()
        {
            TAB_sBLL objTAB_sBLL = new TAB_sBLL();
            //bool executeTransfer = false;
            int? IdTransfer = null;

            IdTransfer = objTAB_sBLL.ValidTransferStore();

            return IdTransfer;
        }
    }
}
