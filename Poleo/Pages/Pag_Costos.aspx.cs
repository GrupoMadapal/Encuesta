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
    public partial class Pag_Costos : System.Web.UI.Page
    {
        public string CorreoTienda
        {
            get { return (string)Session["correoTienda_"]; }
            set { Session["correoTienda_"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateContent();
        }

        private VentasFinder ValidateFiltersField()
        {
            VentasFinder objVentasFinder = new VentasFinder();

            objVentasFinder = (VentasFinder)ctrFilter.GetFiltersField();
            objVentasFinder.IndicadorFull = true;//CheckBox1.Checked;

            return objVentasFinder;
        }

        private string GetLocationCodeUser()
        {
            CorreoTienda = Session["correoTiendaS_"] as string;
            string locationCode = CorreoTienda.Substring(2);
            return locationCode;
        }

        protected void btnCostosXEmployee_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                
                CostosXEmployeeBLL objCostosXEmployeeBLL = new CostosXEmployeeBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string locationCode = GetLocationCodeUser();
                string name = objCostosXEmployeeBLL.generateFileCostos1Store(Server, objVentasFinder, locationCode);
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

                string locationCode = GetLocationCodeUser();
                string name = objCostosXEmployee2BLL.generateFileCostos2_1Store(Server, objVentasFinder, locationCode);
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

                string locationCode = GetLocationCodeUser();
                string name = objTiemposHoyBLL.generateFileDeliveryOrdersToday1Store(Server, objVentasFinder, locationCode);
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

                string locationCode = GetLocationCodeUser();
                string name = objTiemposHistory.generateFileDeliveryOrdersHistory1Store(Server, objVentasFinder, locationCode);
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

        /*protected void btnCuponesIncentivosText_Click(object sender, EventArgs e)
        {
            try
            {
                CuponesIncentivosBLL objCuponesIncentivosBLL = new CuponesIncentivosBLL();
                VentasFinder objVentasFinder = ValidateFiltersField();

                string locationCode = GetLocationCodeUser();
                string name = objCuponesIncentivosBLL.CreateExcelFileIncentiveCoupons1Store(Server, objVentasFinder, locationCode);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                lblMesajeError.Visible = false;
                Response.End();
            }
            catch
            {

            }
        }

        protected void btnCuponesIncentivos_Click(object sender, ImageClickEventArgs e)
        {
            this.btnCuponesIncentivos_Click(sender, null);            
        }*/

        #region TBL
        private void CreateContent()
        {
            int IdUser = (int)Session["_IdUser"];
            IList<int> lstObjects = new List<int>();
            ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();

            lstObjects = objObjectsXUserBLL.SelectObjectsByUser(IdUser);

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("/XML/XmlButtonsC.xml"));

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
                /*case "btnCuponesIncentivos":
                    btnReport.Click += new EventHandler(btnCuponesIncentivosText_Click);
                    break;*/
            }

            return btnReport;
        }

        private ImageButton AsignMethodImgBtn(ImageButton imgBtnReport)
        {
            switch (imgBtnReport.ID)
            {
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
                /*case "ibtnCuponesIncentivos":
                    imgBtnReport.Click += new ImageClickEventHandler(btnCuponesIncentivos_Click);
                    break;*/

            }

            return imgBtnReport;
        }
        #endregion
    }
}