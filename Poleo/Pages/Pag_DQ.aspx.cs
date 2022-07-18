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
    public partial class Pag_DQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateContent();
        }

        protected void btnVentasDQ_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DQ_VentasFinder objVentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();
                int year = objVentasFinder.SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                //VentasBLL objVentasBLL = new VentasBLL();
                DQ_VentasBLL objVentasDQBLL = new DQ_VentasBLL();
                string name = objVentasDQBLL.CreateFileSales(year, Server);//objVentasDQBLL.GetSalesDairyQueen(Server, year);
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

        protected void btnContabilidadDQ_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DQ_VentasFinder objVentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();
                int year = objVentasFinder.SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;

                //VentasBLL objVentasBLL = new VentasBLL();
                DQ_VentasBLL objVentasDQBLL = new DQ_VentasBLL();
                string name = objVentasDQBLL.CreateFileSales(year, Server);//objVentasDQBLL.GetSalesDairyQueen(Server, year);
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

        protected void btnVentasDQText_Click(object sender, EventArgs e)
        {
            this.btnVentasDQ_Click(sender, null);
        }

        protected void btnContabilidadDQText_Click(object sender, EventArgs e)
        {
            this.btnContabilidadDQ_Click(sender, null);
        }

        protected void btnRanking_Click(object sender, EventArgs e)
        {
            DQ_VentasFinder objDQ_VentasFinder = new DQ_VentasFinder();
            DQ_RankingBLL objDQ_RankingBLL = new DQ_RankingBLL();

            objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();

            string name = objDQ_RankingBLL.CreateFileRanking(objDQ_VentasFinder, Server);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            lblMesajeError.Visible = false;
            Response.End();
        }

        protected void ibtRanking_Click(object sender, EventArgs e)
        {
            btnRanking_Click(sender, null);
        }

        protected void btnIndicador_Click(object sender, EventArgs e)
        {
            try
            {
                DQ_VentasFinder objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();

                DQ_IndicadorBLL objDQ_IndicadorBLL = new DQ_IndicadorBLL();

                string name = objDQ_IndicadorBLL.CreateFileIndicador(objDQ_VentasFinder, Server);
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

        protected void ibtIndicador_Click(object sender, EventArgs e)
        {
            btnIndicador_Click(sender, null);
        }

        protected void btnVentasArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                //tblVentasA.Visible = true;
                //rptSalesArticulos.Visible = true;

                DQ_VentasFinder objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();

                DQ_VentasBLL objDQ_VentasBLL = new DQ_VentasBLL();
                //IList<DQ_Ventas> lstDQ_Ventas = new List<DQ_Ventas>();

                //lstDQ_Ventas = objDQ_VentasBLL.SelectVentasDQArticulos(objDQ_VentasFinder);

                //rptSalesArticulos.DataSource = lstDQ_Ventas;
                //rptSalesArticulos.DataBind();

                string name = objDQ_VentasBLL.CreateFileSalesArticles(objDQ_VentasFinder, Server);
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

        protected void ibtVentasArticulos_Click(object sender, EventArgs e)
        {
            btnVentasArticulos_Click(sender, null);
        }

        protected void btnVentasScren_Click(object sender, EventArgs e)
        {
            DQ_VentasFinder objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();
            DQ_VentasBLL objDQ_VentasBLL = new DQ_VentasBLL();
            IList<DQ_Ventas> lstDQ_Ventas = new List<DQ_Ventas>();
            //IList<DQ_Ventas> lstDQ_VentasTotal = new List<DQ_Ventas>();

            panelscreen.Visible = true;

            lstDQ_Ventas = objDQ_VentasBLL.SelectSalesScreen(objDQ_VentasFinder);
            //lstDQ_VentasTotal = objDQ_VentasBLL.SelectSalesScreenTotal(objDQ_VentasFinder);

            rptVentas.DataSource = lstDQ_Ventas;
            rptVentas.DataBind();
            //rptTotal.DataSource = lstDQ_VentasTotal;
            //rptTotal.DataBind();

           
          

        }

        protected void ibtVentasScren_Click(object sender, EventArgs e)
        {
            btnVentasScren_Click(sender, e);
        }

        protected void btnLinealVentasyOrdenes_Click(object sender, EventArgs e)
        {
            try
            {
                DQ_VentasFinder objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();
                int year = objDQ_VentasFinder.SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);

                if (year < 0)
                    year = DateTime.Now.Year;
                
                DQ_LinealVentasBLL objDQ_LinealVentasyOrdenesBLL = new DQ_LinealVentasBLL();

                string name = objDQ_LinealVentasyOrdenesBLL.GenerateVentas_Lineal(objDQ_VentasFinder , Server, year);
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



        protected void btnContabilidad_Click(object sender, EventArgs e)
        {
            try
            {
                DQ_VentasFinder objDQ_VentasFinder = (DQ_VentasFinder)ctrFilter.GetFiltersField();
                int year = objDQ_VentasFinder.SelectYear.Value;//int.Parse(DDLYears.SelectedItem.Text);
                DateTime mount = DateTime.Now.AddMonths(-1);
                if (year < 0)
                    year = DateTime.Now.Year;

                DQ_LinealVentasBLL objDQ_LinealVentasyOrdenesBLL = new DQ_LinealVentasBLL();

                string name = objDQ_LinealVentasyOrdenesBLL.GenerateContabilidad(objDQ_VentasFinder, Server, year, mount.Month); ;
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

        protected void ibtnLinealVentasyOrdenes_Click(object sender, EventArgs e)
        {
            btnLinealVentasyOrdenes_Click(sender, e);
        }

        protected void ibtnContabilidad_Click(object sender, EventArgs e)
        {
            btnContabilidad_Click(sender, e);
        }

        #region TBL
        private void CreateContent()
        {
            int IdUser = (int)Session["_IdUser"];
            IList<int> lstObjects = new List<int>();
            ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();

            lstObjects = objObjectsXUserBLL.SelectObjectsByUser(IdUser);

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("/XML/XmlButtonsDQ.xml"));

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

            if (c > 1 && c <= CountBtn)
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
                case "btnVentasDQText":
                    btnReport.Click += new EventHandler(btnVentasDQText_Click);
                    break;
                case "btnRanking":
                    btnReport.Click += new EventHandler(btnRanking_Click);
                    break;
                case "btnIndicador":
                    btnReport.Click += new EventHandler(btnIndicador_Click);
                    break;
                case "btnVentasArticulos":
                    btnReport.Click += new EventHandler(btnVentasArticulos_Click);
                    break;
                case "btnVentasScren":
                    btnReport.Click += new EventHandler(btnVentasScren_Click);
                    break;
                case "btnLinealVentasyOrdenes":
                    btnReport.Click += new EventHandler(btnLinealVentasyOrdenes_Click);
                    break;
                case "btnContabilidadDQText":
                    btnReport.Click += new EventHandler(btnContabilidad_Click);
                    break;
            }

            return btnReport;
        }

        private ImageButton AsignMethodImgBtn(ImageButton imgBtnReport)
        {
            switch (imgBtnReport.ID)
            {
                case "btnVentasDQ":
                    imgBtnReport.Click += new ImageClickEventHandler(btnVentasDQ_Click);
                    break;
                case "ibtRanking":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtRanking_Click);
                    break;
                case "ibtIndicador":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtIndicador_Click);
                    break;
                case "ibtVentasArticulos":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtVentasArticulos_Click);
                    break;
                case "ibtVentasScren":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtVentasScren_Click);
                    break;
                case "ibtnLinealVentasyOrdenes":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtnLinealVentasyOrdenes_Click);
                    break;
                case "btnContabilidadDQ":
                    imgBtnReport.Click += new ImageClickEventHandler(ibtnContabilidad_Click);
                    break;
            }

            return imgBtnReport;
        }
        #endregion
    }
}