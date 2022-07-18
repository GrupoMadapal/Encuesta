using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Poleo.BLL;

namespace Poleo.WebServices
{
    /// <summary>
    /// Descripción breve de LoadInfoSalesDP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class LoadInfoSalesDP : System.Web.Services.WebService
    {
        [WebMethod(false, EnableSession= false)]
        public void LoadInfo()
        {
            SalesDPDataBLL objSalesDPDataBLL = new SalesDPDataBLL();
            SalesDPViewBLL objSalesDPViewBLL = new SalesDPViewBLL();

            objSalesDPDataBLL.LoadInfoSalesDP();
            objSalesDPViewBLL.LoadInfo();
        }

        [WebMethod]
        public bool ExecuteLoadInfo()
        {
            SalesDPDataBLL objSalesDPDataBLL = new SalesDPDataBLL();

            return objSalesDPDataBLL.ValidLoadInfo();
        }
    }
}
 