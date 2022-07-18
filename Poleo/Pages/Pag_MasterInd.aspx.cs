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
    public partial class Pag_MasterInd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            Info_MasterIndBLL objInfo_MasterIndBLL = new Info_MasterIndBLL();
            Info_MasterInd objInfo_MasterInd = new Info_MasterInd();
            VentasFinder objVentasFinder = new VentasFinder();

            lblMesajeError.Text = string.Empty;
            lblMesaje.Text = string.Empty;
            objVentasFinder = (VentasFinder)CtrlFilter.GetFiltersField();

            if (objVentasFinder.NumTienda != string.Empty)
            {
                objInfo_MasterInd.Store_Number = objVentasFinder.NumTienda;
                objInfo_MasterInd.Date_Ini = objVentasFinder.DateIni.Value;
                objInfo_MasterInd.Date_End = objVentasFinder.DateEnd.Value;
                objInfo_MasterInd.Full_Template = decimal.Parse(txtFullTemplate.Text);
                objInfo_MasterInd.Training = decimal.Parse(txtTraining.Text);
                objInfo_MasterInd.Communication = decimal.Parse(txtCommunication.Text);
                objInfo_MasterInd.DateRegister = DateTime.Now;

                if (objInfo_MasterIndBLL.SelectObjInfoMasterInd(objInfo_MasterInd) == null)
                {
                    objInfo_MasterIndBLL.InsertInfoMasterInd(objInfo_MasterInd);
                    lblMesaje.Text = "La información de la tienda " + objInfo_MasterInd.Store_Number + ", para le semana " + objVentasFinder.NumeroSemana + ", se guardo correctamente.";
                }
                else
                {
                    lblMesajeError.Text = "Ya existe información para la tienda " + objInfo_MasterInd.Store_Number + ", en la semana " + objVentasFinder.NumeroSemana + ".";
                }
            }
            else
            {
                lblMesajeError.Text = "Seleccione una tienda.";
            }
        }
    }
}