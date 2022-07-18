using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.BLL;
using Poleo.Objects;
using System.IO;
using System.Configuration;

namespace Poleo.Pages
{
    public partial class Pag_CuponesDP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLstCupones();
            }
        }

        private void LoadLstCupones() 
        {
            IList<Cupones> lstCupones = new List<Cupones>();
            CuponesBLL objCuponesBLL = new CuponesBLL();
            Cupones objCupones = new Cupones();

            objCupones.Active = chkActive.Checked;

            lstCupones = objCuponesBLL.SelectCuponsByDDL(objCupones);

            cblCupones.DataSource = lstCupones;
            cblCupones.DataTextField = "Descripcion";
            cblCupones.DataValueField = "Codigo";
            cblCupones.DataBind();
        }

        protected void btnLoadFile_Click(object sender, EventArgs e)
        {
            DirectoryInfo objDirectoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings["FileC2D"].ToString());
            CuponesBLL objCuponesBLL = new CuponesBLL();

            FileInfo[] arrFileInfo = objDirectoryInfo.GetFiles("*.tab");//itemDirectoryInfo.GetFiles("*.tab");
            foreach (FileInfo objFileInfo in arrFileInfo)
            {
                StreamReader objStreamReader = new StreamReader(File.OpenRead(objFileInfo.FullName));

                objCuponesBLL.UpdateCupons(objStreamReader);
            }

            LoadLstCupones();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CuponesBLL objCuponesBLL = new CuponesBLL();

            objCuponesBLL.UpdateValidityCupons();

            LoadLstCupones();
        }

        protected void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadLstCupones();
        }

        private VentasFinder ValidateFiltersField()
        {
            VentasFinder objVentasFinder = new VentasFinder();

            objVentasFinder = (VentasFinder)ctrFilter.GetFiltersField();

            return objVentasFinder;
        }

        protected void btnCupon_Click(object sender, EventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                OrdenesFinder objOrdenesFinder = new OrdenesFinder();
                objOrdenesFinder.DateIni = objVentasFinder.DateIni.Value;
                objOrdenesFinder.DateEnd = objVentasFinder.DateEnd.Value;
                objOrdenesFinder.NumTienda = objVentasFinder.NumTienda;
                objOrdenesFinder.TipoTienda = objVentasFinder.TipoTienda;
                objOrdenesFinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
                objOrdenesFinder.LstCuponCode = GetSelectCodeCupons();
                //objOrdenesFinder.CodigoCupon = ctrFilter.GetValueCupons();//ddlCupon.SelectedValue == "-1" ? string.Empty : ddlCupon.SelectedValue;//txtCupon.Text; - Changed by Hector Sanchez M. 20151217

                OrdenesBLL objOrdenesBLL = new OrdenesBLL();
                string name = objOrdenesBLL.CreateExcelFileCupones(objOrdenesFinder, Server);
                string attachment = "attachment; filename=" + name;
                lblMesajeError.Visible = false;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnPorcCoupon_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            CuponesBLL objCuponesBLL = new CuponesBLL();

            objVentasFinder = ValidateFiltersField();
            objVentasFinder.LstCuponCode = GetSelectCodeCupons();
            string name = objCuponesBLL.CresteExcelFileCuponesPorc(Server, objVentasFinder);
            string attachment = "attachment; filename=" + name;
            lblMesajeError.Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            Response.End();
        }

        private IList<string> GetSelectCodeCupons()
        {
            IList<string> codeCupons = null;

            foreach (ListItem objListItem in cblCupones.Items)
            {
                if (objListItem.Selected)
                {
                    if (codeCupons == null)
                        codeCupons = new List<string>();

                    codeCupons.Add(objListItem.Value);
                }
            }


            return codeCupons;
        }

        protected void btnIncentivoCoupon_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            CuponesIncentivosBLL objIncentiveCouponsBLL = new CuponesIncentivosBLL();

            objVentasFinder = ValidateFiltersField();
            objVentasFinder.LstCuponCode = GetSelectCodeCupons();
            string name = objIncentiveCouponsBLL.CreateExcelFileIncentiveCoupons(Server, objVentasFinder);
            string attachment = "attachment; filename=" + name;
            lblMesajeError.Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            Response.End();
        }


        protected void btnIncentivoCouponSLP_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            CuponesIncentivosSLPBLL objIncentiveCouponsSLPBLL = new CuponesIncentivosSLPBLL();

            objVentasFinder = ValidateFiltersField();
            objVentasFinder.LstCuponCode = GetSelectCodeCupons();
            string name = objIncentiveCouponsSLPBLL.CreateExcelFileCouponsSLP(Server, objVentasFinder);
            string attachment = "attachment; filename=" + name;
            lblMesajeError.Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            Response.End();
        }
    }
}