using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.BLL;
using Poleo.Objects;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace Poleo.Pages
{
    public partial class Pag_Dominos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            CreateContent();
            //}
        }

        private VentasFinder ValidateFiltersField()
        //ventasfinder contiene (fechainicial, fechafinal, numtienda, tipotienda, ubicacion, numsemana, indicadorfull)
        {
            VentasFinder objVentasFinder = new VentasFinder();

            objVentasFinder = (VentasFinder)ctrFilter.GetFiltersField();
            objVentasFinder.IndicadorFull = true;//CheckBox1.Checked;

            return objVentasFinder;
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                VentasBLL objVentasBLL = new VentasBLL();
                string name = objVentasBLL.CreateFileSales(year, Server);//objVentasBLL.GenerfireateAutomaticFile(Server, year);
                //Llamar a metodo crearArchivoVentas
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnContabilidadDP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DQ_VentasFinder objDQ_VentasFinder = new DQ_VentasFinder();
                DQ_RankingBLL objDQ_RankingBLL = new DQ_RankingBLL();
                VentasBLL objVentasBLL = new VentasBLL();

                string name = objVentasBLL.CreateFileContabilidad(Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnExcelVentas_Click(object sender, EventArgs e)
        {
            this.btnExcel_Click(sender, null);
        }

        protected void btnExcelContabilidadDP_Click(object sender, EventArgs e)
        {
            this.btnContabilidadDP_Click(sender, null);
        }

        protected void btnExcelRapido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                VentasBLL objVentasBLL = new VentasBLL();
                string name = objVentasBLL.CrearArchivoVentas(year, Server);
                //Llamar a metodo crearArchivoVentas
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnExcelVentasRapido_Click(object sender, EventArgs e)
        {
            this.btnExcelRapido_Click(sender, null);
        }

        protected void BtnIndicadorExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                IndicadorBLL BLL = new IndicadorBLL();
                string name = BLL.generateFormatIndicador(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.StackTrace + " - " + ex.InnerException;
                lblMesajeError.Visible = true;
            }
        }

        protected void BtnIndicadorExcelText_Click(object sender, EventArgs e)
        {
            this.BtnIndicadorExcel_Click(sender, null);
        }

        protected void btnVentasResumen_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                VentasBLL objVentasBLL = new VentasBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();
                string name = objVentasBLL.GenerateResumenVentasV2(objVentasFinder, Server, year);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnVentasResumenText_Click(object sender, EventArgs e)
        {
            this.btnVentasResumen_Click(sender, null);
        }

        protected void btnImgRanking_Click(object sender, ImageClickEventArgs e)
        {
            this.btnRanking_Click(sender, null);
        }

        protected void btnRanking_Click(object sender, EventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                RankingFinder objRankingfinder = new RankingFinder();
                objRankingfinder.DateIni = objVentasFinder.DateIni.Value;
                objRankingfinder.DateEnd = objVentasFinder.DateEnd.Value;
                objRankingfinder.Tienda = objVentasFinder.NumTienda;
                objRankingfinder.TipoTienda = objVentasFinder.TipoTienda;
                objRankingfinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
                objRankingfinder.NumSemana = objVentasFinder.NumeroSemana;
                objRankingfinder.SelectYear = objVentasFinder.SelectYear;

                RankingBLL objRankingBLL = new RankingBLL();
                string name = objRankingBLL.generateReportRanking(objRankingfinder, Server);
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
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        #region btnCupon
        //Commented by Hector Sanchez M. - 20161012
        //Moved to Pag_CuponesDP.aspx
        //protected void btnimgCupon_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        VentasFinder objVentasFinder = ValidateFiltersField();
        //        OrdenesFinder objOrdenesFinder = new OrdenesFinder();
        //        objOrdenesFinder.DateIni = objVentasFinder.DateIni.Value;
        //        objOrdenesFinder.DateEnd = objVentasFinder.DateEnd.Value;
        //        objOrdenesFinder.NumTienda = objVentasFinder.NumTienda;
        //        objOrdenesFinder.TipoTienda = objVentasFinder.TipoTienda;
        //        objOrdenesFinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
        //        //objOrdenesFinder.CodigoCupon = ctrFilter.GetValueCupons();//ddlCupon.SelectedValue == "-1" ? string.Empty : ddlCupon.SelectedValue; //txtCupon.Text; - Changed by Hector Sanchez M. 20151217

        //        OrdenesBLL objOrdenesBLL = new OrdenesBLL();
        //        string name = objOrdenesBLL.CreateExcelFileCupones(objOrdenesFinder, Server);
        //        string attachment = "attachment; filename=" + name;
        //        lblMesajeError.Visible = false;
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", attachment);
        //        Response.ContentType = "application/ms-excel";
        //        Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMesajeError.Text = ex.Message;
        //        lblMesajeError.Visible = true;
        //    }
        //}

        //protected void btnCupon_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        VentasFinder objVentasFinder = ValidateFiltersField();
        //        OrdenesFinder objOrdenesFinder = new OrdenesFinder();
        //        objOrdenesFinder.DateIni = objVentasFinder.DateIni.Value;
        //        objOrdenesFinder.DateEnd = objVentasFinder.DateEnd.Value;
        //        objOrdenesFinder.NumTienda = objVentasFinder.NumTienda;
        //        objOrdenesFinder.TipoTienda = objVentasFinder.TipoTienda;
        //        objOrdenesFinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
        //        //objOrdenesFinder.CodigoCupon = ctrFilter.GetValueCupons();//ddlCupon.SelectedValue == "-1" ? string.Empty : ddlCupon.SelectedValue;//txtCupon.Text; - Changed by Hector Sanchez M. 20151217

        //        OrdenesBLL objOrdenesBLL = new OrdenesBLL();
        //        string name = objOrdenesBLL.CreateExcelFileCupones(objOrdenesFinder, Server);
        //        string attachment = "attachment; filename=" + name;
        //        lblMesajeError.Visible = false;
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition", attachment);
        //        Response.ContentType = "application/ms-excel";
        //        Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMesajeError.Text = ex.Message;
        //        lblMesajeError.Visible = true;
        //    }
        //}
        #endregion

        protected void btnIndMaestro_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                IndicadorMaestroBLL BLL = new IndicadorMaestroBLL();
                string name = BLL.generateFileVentas(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnIndMaestroText_Click(object sender, EventArgs e)
        {
            this.btnIndMaestro_Click(sender, null);
        }

        protected void btnTransacciones_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                DepositosBLL objDepositosBLL = new DepositosBLL();
                string name = objDepositosBLL.generateFileVentas(objVentasFinder, Server);
                lblMesajeError.Visible = false;
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnTransaccionesText_Click(object sender, EventArgs e)
        {
            this.btnTransacciones_Click(sender, null);
        }

        protected void btnFiltro2_Click(object sender, ImageClickEventArgs e)
        {
            this.btnFiltro_Click(sender, null);
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                VentasFinder objVentasFinder = ValidateFiltersField();
                idCTLVentas.Visible = true;
                idCTLVentas.FechaIni = objVentasFinder.DateIni.ToString();
                idCTLVentas.FechaEnd = objVentasFinder.DateEnd.ToString();
                idCTLVentas.Tienda = objVentasFinder.NumTienda;
                idCTLVentas.TipoTienda = objVentasFinder.TipoTienda;
                idCTLVentas.Ubicacion = objVentasFinder.UbicacionTienda;
                idCTLVentas.llenaControl();
                //PizzasCtrl.Visible = true;
                //PizzasCtrl.objFilter = objVentasFinder;
                //PizzasCtrl.fillDataGrid();
                //ComCtrl.Visible = true;
                //ComCtrl.objFilter = objVentasFinder;
                //ComCtrl.fillDataGrid();
                lblMesajeError.Visible = false;
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        //Added by Hector Sanchez M. 20160122
        protected void btnTiempoServicio_Click(object sender, EventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value;

                if (year < 0)
                    year = DateTime.Now.Year;

                TiempoServicioBLL objTiempoServicioBLL = new TiempoServicioBLL();
                string name = objTiempoServicioBLL.CreateExcelFileTiempoServicio(Server, year);
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
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }

        }

        #region btnPorcCoupon
        //Added by Hector Sanchez M. 20160407
        //Commented by Hector Sanchez M. 20161012
        //Moved to Pag_CuponesDP.aspx
        //protected void btnPorcCoupon_Click(object sender, EventArgs e)
        //{
        //    VentasFinder objVentasFinder = new VentasFinder();
        //    CuponesBLL objCuponesBLL = new CuponesBLL();

        //    objVentasFinder = ValidateFiltersField();
        //    string name = objCuponesBLL.CresteExcelFileCuponesPorc(Server, objVentasFinder);
        //    string attachment = "attachment; filename=" + name;
        //    lblMesajeError.Visible = false;
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", attachment);
        //    Response.ContentType = "application/ms-excel";
        //    Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
        //    Response.End();
        //}
        #endregion

        //Added by Hector Sanchez M. 20160502
        protected void btnEntradaHorno_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            EntradaHornoBLL objEntradaHornoBLL = new EntradaHornoBLL();

            objVentasFinder = ValidateFiltersField();
            string name = objEntradaHornoBLL.CreateExcelFileEntradaHorno(Server, objVentasFinder.SelectYear.Value);
            string attachment = "attachment; filename=" + name;
            lblMesajeError.Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            Response.End();
        }

        //Added by Hector Sanchez M. 20160712
        protected void btnOrdenesInternet_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            VentasBLL objVentasBLL = new VentasBLL();

            objVentasFinder = ValidateFiltersField();

            string name = objVentasBLL.GenerateFileOrdersInternet(objVentasFinder, Server);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            lblMesajeError.Visible = false;
            Response.End();
        }

        //Added by Hector Sanchez M. 20170201
        protected void btnProductosAdc_Click(object sender, EventArgs e)
        {
            VentasFinder objVentasFinder = new VentasFinder();
            AdicionalBLL objAdicionalBLL = new AdicionalBLL();

            objVentasFinder = ValidateFiltersField();

            string name = objAdicionalBLL.GenerateFileCanelazos(objVentasFinder, Server);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            lblMesajeError.Visible = false;
            Response.End();
        }

        //Added by Hector Sanchez M. 20181203
        protected void btnUseInventory_Click(object sender, ImageClickEventArgs e)
        {
            int year = ValidateFiltersField().SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

            if (year < 0)
                year = DateTime.Now.Year;

            VentasFinder objVentasFinder = new VentasFinder();
            DOT_InventoryBLL objDOT_InventoryBLL = new DOT_InventoryBLL();
            VentasBLL objVentasBLL = new VentasBLL();

            objVentasFinder = ValidateFiltersField();

            //string name = objDOT_InventoryBLL.GenerateFileUseInventory(objVentasFinder, Server);
            string name = objVentasBLL.GenerateInventoryDayBefore(objVentasFinder, Server, year);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            lblMesajeError.Visible = false;
            Response.End();
        }

        protected void btnUseInventoryText_Click(object sender, EventArgs e)
        {
            this.btnUseInventory_Click(sender, null);
        }

        //ADDED by LEO serviceTime
        /* protected void btnServiceTimeText_Click(object sender, EventArgs e)
         {
             this.btnServiceTime_Click(sender, null);
         }

         protected void btnServiceTime_Click(object sender, EventArgs e)
         {
             try
             {
                 int year = ValidateFiltersField().SelectYear.Value;

                 if (year < 0)
                     year = DateTime.Now.Year;

                 ServiceTimeBLL objServiceTimeBLL = new ServiceTimeBLL();
                 string name = objServiceTimeBLL.CreateFileServiceTime(year, Server);
                 string attachment = "attachment; filename=" + name;
                 Response.ClearContent();
                 Response.AddHeader("content-disposition", attachment);
                 Response.ContentType = "application/ms-excel";
                 Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                 lblMesajeError.Visible = false;
                 Response.End();

             }
             catch (Exception ex)
             {
                 lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                 lblMesajeError.Visible = true;
             }
         }*/

        //ADDED by LEO pruebas
        /*
        protected void btnCantidadesText_Click(object sender, EventArgs e)
        {
            this.btnCantidades_Click(sender, null);
        }

        protected void btnCantidades_Click(object sender, EventArgs e)
        {

            try
            {
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                A_CantidadesBLL objCantidadesBLL = new A_CantidadesBLL();
                string name = objCantidadesBLL.CreateFileSales(year, Server);//objVentasBLL.GenerateAutomaticFile(Server, year);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        
        }   */

        protected void btnVentas_Prueba_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                Ventas_LunesBLL objVentas_PruebaBLL = new Ventas_LunesBLL();
                string name = objVentas_PruebaBLL.GenerateVentas_Prueba(Server, year);//objVentas_PruebaBLL.GenerateVentas_Prueba(objVentasFinder, Server, year)
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnVentas_PruebaText_Click(object sender, EventArgs e)
        {
            this.btnVentas_Prueba_Click(sender, null);
        }

        protected void btnLinealVentas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                VentasLinealBLL objVentasLinealBLL = new VentasLinealBLL();

                VentasFinder objVentasFinder = ValidateFiltersField();
                string name = objVentasLinealBLL.GenerateVentas_PruebaLineal(objVentasFinder, Server, year);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnLinealVentasText_Click(object sender, EventArgs e)
        {
            this.btnLinealVentas_Click(sender, null);
        }

        protected void btnCostosXEmployee_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                CostosXEmployeeBLL objCostosXEmployeeBLL = new CostosXEmployeeBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objCostosXEmployeeBLL.generateFileCostos(Server, objVentasFinder);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnCostosXEmployeeText_Click(object sender, EventArgs e)
        {
            this.btnCostosXEmployee_Click(sender, null);
        }

        protected void btnCostosXEmployee2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                CostosXEmployee2BLL objCostosXEmployee2BLL = new CostosXEmployee2BLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objCostosXEmployee2BLL.generateFileCostos2(Server, objVentasFinder);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnCostosXEmployeeText2_Click(object sender, EventArgs e)
        {
            this.btnCostosXEmployee2_Click(sender, null);
        }

        protected void btnTiemposHoy_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                TiemposHoyBLL objTiemposHoyBLL = new TiemposHoyBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objTiemposHoyBLL.generateFileDeliveryOrdersToday(Server, objVentasFinder);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnTiemposHoyText_Click(object sender, EventArgs e)
        {
            this.btnTiemposHoy_Click(sender, null);
        }

        protected void btnTiemposHistorial_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                TiemposHistorialBLL objTiemposHistory = new TiemposHistorialBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objTiemposHistory.generateFileDeliveryOrdersHistory(Server, objVentasFinder);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnTiemposHistorialText_Click(object sender, EventArgs e)
        {
            this.btnTiemposHistorial_Click(sender, null);
        }


        //Boton Activado para el excel 08/02/2021//Ariadna Cadena

        protected void btnExcelOrdenesGratis_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                OrdersFreeBLL objOrdenesGatisBLL = new OrdersFreeBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objOrdenesGatisBLL.Generateordersfree(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnExcelOrdenesGratisText_Click(object sender, EventArgs e)
        {
            this.btnExcelOrdenesGratis_Click(sender, null);
        }

        //Boton Activado para el excel 09/01/2021//Ariadna Cadena


        protected void btnOrdenesEditadas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                OrdenesEditadasBLL objOrdenesGatisBLL = new OrdenesEditadasBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objOrdenesGatisBLL.GenerateOrdenesEditadas(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnOrdenesEditadasText_Click(object sender, EventArgs e)
        {
            this.btnOrdenesEditadas_Click(sender, null);
        }

        protected void btnConPagoOpenPay_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int year = ValidateFiltersField().SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                ConPagoOpenPayBLL objVentasBLL = new ConPagoOpenPayBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();
                string name = objVentasBLL.GenerateConPagoOpenPay(objVentasFinder, Server, year);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnConPagoOpenPayText_Click(object sender, EventArgs e)
        {
            this.btnConPagoOpenPay_Click(sender, null);
        }

        protected void btnDetalleOpenPay_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DetalleOpenPayBLL objOrdenesGatisBLL = new DetalleOpenPayBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objOrdenesGatisBLL.GenerateDetallesOpenPay(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnDetalleOpenPayText_Click(object sender, EventArgs e)
        {
            this.btnDetalleOpenPay_Click(sender, null);
        }

        protected void btnReporteCompras_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ReporteComprasBLL objOrdenesGatisBLL = new ReporteComprasBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objOrdenesGatisBLL.GenerateReporteCompras(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnReporteComprasText_Click(object sender, EventArgs e)
        {
            this.btnReporteCompras_Click(sender, null);
        }
        protected void btnOrdenesCanceladas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                OrdenesCanceladasBLL objOrdenesGatisBLL = new OrdenesCanceladasBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string name = objOrdenesGatisBLL.GenerateOrdenesCanceladas(objVentasFinder, Server);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                lblMesajeError.Visible = true;
            }
        }

        protected void btnOrdenesCanceladasText_Click(object sender, EventArgs e)
        {
            this.btnOrdenesCanceladas_Click(sender, null);
        }

     

        #region TBL
        private void CreateContent()
        {
            int IdUser = (int)Session["_IdUser"];
            IList<int> lstObjects = new List<int>();
            ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();

            lstObjects = objObjectsXUserBLL.SelectObjectsByUser(IdUser);

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("/XML/XmlButtonsDP.xml"));

            XmlNodeList lstButtons = doc.SelectNodes("Buttons/Button");

            HtmlTableRow Row = null;
            int CountBtn = int.Parse(ConfigurationManager.AppSettings["Maxbtn"].ToString());
            int c = 1;

            foreach (XmlNode button in lstButtons)
            {
                string rol = button.SelectSingleNode("Rol").InnerText;
                

                if (string.IsNullOrEmpty(rol) || lstObjects.Contains(int.Parse(rol)))
                {
                    if (c == 1)
                        Row = new HtmlTableRow();

                    HtmlTableCell Cell = new HtmlTableCell();
                    Button reportBtn = new Button();
                    ImageButton reportImgBtn = new ImageButton();
                    HtmlTable tableContentBtn = new HtmlTable();

                    reportBtn = Tools.ToolsControls.CreateBtnReport(button.SelectSingleNode("Control"));
                    reportImgBtn = Tools.ToolsControls.CreateBtnImgReport(button.SelectSingleNode("Image"));
                    AsignMethodBtn(reportBtn);
                    AsignMethodImgBtn(reportImgBtn);

                    tableContentBtn = CreateTblContentBtn(reportBtn, reportImgBtn);
                    Cell.Controls.Add(tableContentBtn);
                    Row.Cells.Add(Cell);

                    Cell.Attributes.Add("style", "padding-bottom: 15px;padding-left: 15px;");

                    if (c == CountBtn)
                    {
                        tblContent.Rows.Add(Row);
                        c = 1;
                    }
                    else
                        c++;
                }
            }

            if (c > 1 && c < CountBtn)
                tblContent.Rows.Add(Row);
        }

        private HtmlTable CreateTblContentBtn(Button btnReport, ImageButton imgBtnReport)
        {
            HtmlTable tblContentBtn = new HtmlTable();
            HtmlTableRow rowContent = new HtmlTableRow();
            HtmlTableCell cellContentImg = new HtmlTableCell();
            HtmlTableCell cellContentBtn = new HtmlTableCell();

            cellContentImg = AddCellImgBtn(imgBtnReport);
            cellContentBtn = AddCellBtn(btnReport);

            rowContent.Cells.Add(cellContentImg);
            rowContent.Cells.Add(cellContentBtn);

            //rowContent.Attributes.Add("style", "white-space:nowrap;");

            tblContentBtn.Rows.Add(rowContent);

            return tblContentBtn;
        }

        private HtmlTableCell AddCellImgBtn(ImageButton imgBtnReport)
        {
            HtmlTableCell CellImg = new HtmlTableCell();

            CellImg.Attributes.Add("class", "btnExcelTD");

            CellImg.Controls.Add(imgBtnReport);

            return CellImg;
        }

        private HtmlTableCell AddCellBtn(Button btnReport)
        {
            HtmlTableCell CellBtn = new HtmlTableCell();

            //CellBtn.Attributes.Add("class", "elementes");

            CellBtn.Controls.Add(btnReport);

            return CellBtn;
        }

        private Button AsignMethodBtn(Button btnReport)
        {
            switch (btnReport.ID)
            {
                case "btnExcelVentasRapido":
                    btnReport.Click += new EventHandler(btnExcelVentasRapido_Click);
                    break;
                case "btnExcelVentas":
                    btnReport.Click += new EventHandler(btnExcelVentas_Click);
                    break;
                case "BtnIndicadorExcelText":
                    btnReport.Click += new EventHandler(BtnIndicadorExcelText_Click);
                    break;
                case "btnVentasResumenText":
                    btnReport.Click += new EventHandler(btnVentasResumenText_Click);
                    break;
                case "btnRanking":
                    btnReport.Click += new EventHandler(btnRanking_Click);
                    break;
                case "btnIndMaestroText":
                    btnReport.Click += new EventHandler(btnIndMaestroText_Click);
                    break;
                case "btnTransaccionesText":
                    btnReport.Click += new EventHandler(btnTransaccionesText_Click);
                    break;
                case "btnFiltro":
                    btnReport.Click += new EventHandler(btnFiltro_Click);
                    break;
                case "btnEntradaHorno":
                    btnReport.Click += new EventHandler(btnEntradaHorno_Click);
                    break;
                case "btnTiempoServicio":
                    btnReport.Click += new EventHandler(btnTiempoServicio_Click);
                    break;
                case "btnOrdenesInternet":
                    btnReport.Click += new EventHandler(btnOrdenesInternet_Click);
                    break;
                case "btnProductosAdc":
                    btnReport.Click += new EventHandler(btnProductosAdc_Click);
                    break;
                case "btnUseInventory":
                    btnReport.Click += new EventHandler(btnUseInventoryText_Click);
                    break;
                case "btnVentas_Prueba":
                    btnReport.Click += new EventHandler(btnVentas_PruebaText_Click);
                    break;
                case "btnLinealVentas":
                    btnReport.Click += new EventHandler(btnLinealVentasText_Click);
                    break;
                case "btnCostosXEmployee":
                    btnReport.Click += new EventHandler(btnCostosXEmployeeText_Click);
                    break;
                case "btnCostosXEmployee2":
                    btnReport.Click += new EventHandler(btnCostosXEmployeeText2_Click);
                    break;
                case "btnTiemposHoy":
                    btnReport.Click += new EventHandler(btnTiemposHoyText_Click);
                    break;
                case "btnTiemposHistorial":
                    btnReport.Click += new EventHandler(btnTiemposHistorialText_Click);
                    break;
                case "btnExcelOrdenesGratis":
                    btnReport.Click += new EventHandler(btnExcelOrdenesGratisText_Click);
                    break;
                case "btnOrdenesEditadas":
                    btnReport.Click += new EventHandler(btnOrdenesEditadasText_Click);
                    break;
                case "btnOrdenesCanceladas":
                    btnReport.Click += new EventHandler(btnOrdenesCanceladasText_Click);
                    break;
                case "btnConPagoOpenPay":
                    btnReport.Click += new EventHandler(btnConPagoOpenPayText_Click);
                    break;
                case "btnDetalleOpenPay":
                    btnReport.Click += new EventHandler(btnDetalleOpenPayText_Click);
                    break;
                case "btnReporteCompras":
                    btnReport.Click += new EventHandler(btnReporteComprasText_Click);
                    break;
                case "btnExcelContabilidadDP":
                    btnReport.Click += new EventHandler(btnExcelContabilidadDP_Click);
                    break;

            }

            return btnReport;
        }

        private ImageButton AsignMethodImgBtn(ImageButton imgBtnReport)
        {
            switch (imgBtnReport.ID)
            {
                case "btnExcelRapido":
                    imgBtnReport.Click += new ImageClickEventHandler(btnExcelRapido_Click);
                    break;
                case "btnExcel":
                    imgBtnReport.Click += new ImageClickEventHandler(btnExcel_Click);
                    break;
                case "BtnIndicadorExcel":
                    imgBtnReport.Click += new ImageClickEventHandler(BtnIndicadorExcel_Click);
                    break;
                case "btnVentasResumen":
                    imgBtnReport.Click += new ImageClickEventHandler(btnVentasResumen_Click);
                    break;
                case "btnImgRanking":
                    imgBtnReport.Click += new ImageClickEventHandler(btnImgRanking_Click);
                    break;
                case "btnIndMaestro":
                    imgBtnReport.Click += new ImageClickEventHandler(btnIndMaestro_Click);
                    break;
                case "btnTransacciones":
                    imgBtnReport.Click += new ImageClickEventHandler(btnTransacciones_Click);
                    break;
                case "btnFiltro2":
                    imgBtnReport.Click += new ImageClickEventHandler(btnFiltro2_Click);
                    break;
                case "ibtEntradaHorno":
                    imgBtnReport.Click += new ImageClickEventHandler(btnEntradaHorno_Click);
                    break;
                case "ibtTiempoServicio":
                    imgBtnReport.Click += new ImageClickEventHandler(btnTiempoServicio_Click);
                    break;
                case"ibtOrdenesInternet":
                    imgBtnReport.Click += new ImageClickEventHandler(btnOrdenesInternet_Click);
                    break;
                case "ibtProductosAdc":
                    imgBtnReport.Click += new ImageClickEventHandler(btnProductosAdc_Click);
                    break;
                case "ibtUseInventory":
                    imgBtnReport.Click += new ImageClickEventHandler(btnUseInventory_Click);
                    break;
                case "ibtnVentas_Prueba":
                    imgBtnReport.Click += new ImageClickEventHandler(btnVentas_Prueba_Click);
                    break;
                case "ibtnLinealVentas":
                    imgBtnReport.Click += new ImageClickEventHandler(btnLinealVentas_Click);
                    break;
                case "ibtnCostosXEmployee":
                    imgBtnReport.Click += new ImageClickEventHandler(btnCostosXEmployee_Click);
                    break;
                case "ibtnCostosXEmployee2":
                    imgBtnReport.Click += new ImageClickEventHandler(btnCostosXEmployee2_Click);
                    break;
                case "ibtnTiemposHoy":
                    imgBtnReport.Click += new ImageClickEventHandler(btnTiemposHoy_Click);
                    break;
                case "ibtnTiemposHistorial":
                    imgBtnReport.Click += new ImageClickEventHandler(btnTiemposHistorial_Click);
                    break;
                case "ibtnExcelOrdenesGratis":
                   imgBtnReport.Click += new ImageClickEventHandler(btnExcelOrdenesGratis_Click);
                   break;
                case "ibtnOrdenesEditadas":
                    imgBtnReport.Click += new ImageClickEventHandler(btnOrdenesEditadasText_Click);
                    break;
                case "ibtnOrdenesCanceladas":
                    imgBtnReport.Click += new ImageClickEventHandler(btnOrdenesCanceladasText_Click);
                    break;
                case "ibtnConPagoOpenPay":
                    imgBtnReport.Click += new ImageClickEventHandler(btnConPagoOpenPayText_Click);
                    break;
                case "ibtnDetalleOpenPay":
                    imgBtnReport.Click += new ImageClickEventHandler(btnDetalleOpenPayText_Click);
                    break;
                case "ibtnReporteCompras":
                    imgBtnReport.Click += new ImageClickEventHandler(btnReporteComprasText_Click);
                    break;
                case "ibtnExcelContabilidadDP":
                    imgBtnReport.Click+= new ImageClickEventHandler(btnExcelContabilidadDP_Click);
                    break;




            }

            return imgBtnReport;
        }
        #endregion
    }
}