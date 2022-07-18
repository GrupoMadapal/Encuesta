using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.Objects;
using Poleo.BLL;

namespace Poleo.Pages
{
    public partial class Pag_Training : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadStore();
        }

        private void LoadStore()
        {
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();

            lstTienda = objTiendaBLL.SelectTiendas(new Tienda());

            gvwStore.DataSource = lstTienda;
            gvwStore.DataBind();
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            Info_MasterIndBLL objInfo_MasterIndBLL = new Info_MasterIndBLL();
            VentasFinder objVentasFinder = new VentasFinder();

            objVentasFinder = (VentasFinder)CtrlFilter.GetFiltersField();

            foreach (GridViewRow row in gvwStore.Rows)
            {
                Info_MasterInd findInfo_MasterInd = new Info_MasterInd();
                Info_MasterInd objInfo_MasterInd = new Info_MasterInd();

                Label lblNumberStore = (Label)row.FindControl("lblNumberStore");
                Label lblNameStore = (Label)row.FindControl("lblNameStore");
                TextBox txtTraining = (TextBox)row.FindControl("txtTraining");
                Label lblMessage = (Label)row.FindControl("lblMessage");

                objInfo_MasterInd.Store_Number = lblNumberStore.Text;
                objInfo_MasterInd.Date_Ini = objVentasFinder.DateIni.Value;
                objInfo_MasterInd.Date_End = objVentasFinder.DateEnd.Value;
                objInfo_MasterInd.Training = decimal.Parse(txtTraining.Text);
                objInfo_MasterInd.DateRegister = DateTime.Now;

                findInfo_MasterInd = objInfo_MasterIndBLL.SelectObjInfoMasterInd(objInfo_MasterInd);

                if (findInfo_MasterInd == null)
                {
                    objInfo_MasterIndBLL.InsertInfoMasterInd(objInfo_MasterInd);
                    lblMessage.Text = "El registro se guardo correctamente";
                    lblMessage.CssClass = string.Empty;
                }
                else if (findInfo_MasterInd.Training == null)
                {
                    objInfo_MasterIndBLL.UpdateObjInfoMasterInd(objInfo_MasterInd);
                    lblMessage.Text = "El registro se guardo correctamente";
                    lblMessage.CssClass = string.Empty;
                }
                else
                {
                    lblMessage.Text = "Ya existe un registro para esta tienda";
                    lblMessage.CssClass = "LabelRed";
                }
            }
        }
    }
}