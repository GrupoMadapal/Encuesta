using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.WebServices;
using Poleo.Tools;
using Poleo.Objects;
using Poleo.BLL;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace Poleo
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadGrid();

        }

        protected void btnTestWS_Click(object sender, EventArgs e)
        {
            UploadFilesAutomatically objUploadFilesAutomatically = new UploadFilesAutomatically();
            int? IdTransfer = null;

            IdTransfer = objUploadFilesAutomatically.ExecuteTransfer();

            if(IdTransfer != null)
            {
                objUploadFilesAutomatically.UploadFiles(IdTransfer.Value);
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //string hms = ToolsTime.ConvertSecondsToHMS(decimal.Parse(txtTime.Text));

            //string hms = ToolsTime.ConvertSecondsToHMS(int.Parse(txtTime.Text)); //TimeSpan.FromSeconds(double.Parse(txtTime.Text));//.FromMinutes(double.Parse(txtTime.Text));

            //lblTime.Text = hms;

            //SalesDPDataBLL objSalesDPDataBLL = new SalesDPDataBLL();

            //objSalesDPDataBLL.LoadInfoSalesDP();

            LoadInfoSalesDP wsrobj = new LoadInfoSalesDP();

            wsrobj.LoadInfo();
        }

        protected void btnXLS_Click(object sender, EventArgs e)
        {
            string name = CreateFile(Server);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
            Response.End();
        }

        protected void btnTestxlFile_Click(object sender, EventArgs e)
        {
            try
            {
                int year = DateTime.Now.Year;

                VentasBLL objVentasBLL = new VentasBLL();
                objVentasBLL.GenerateAutomaticFile(Server, year);
                string name = "VentasDiarias" + year.ToString() + ".xlsx";
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                //lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                //lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                //lblMesajeError.Visible = true;
            }
        }

        protected void btnTestxlFileDQ_Click(object sender, EventArgs e)
        {
            try
            {
                int year = DateTime.Now.Year;

                //VentasBLL objVentasBLL = new VentasBLL();
                DQ_VentasBLL objVentasDQBLL = new DQ_VentasBLL();
                string name = objVentasDQBLL.GetSalesDairyQueen(Server, year);
                string attachment = "attachment; filename=" + name;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                //lblMesajeError.Visible = false;
                Response.End();
            }
            catch (Exception ex)
            {
                //lblMesajeError.Text = ex.Message;
                //lblMesajeError.Visible = true;
            }
        }

        private string CreateFile(HttpServerUtility server)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            if (xlApp != null)
            {
                Excel.Workbook objWorkbook;
                objWorkbook = xlApp.Workbooks.Add(misValue);

                objWorkbook = GenerateWorksheetsFile(server, objWorkbook);

                nombreArchivo = "testxls.xlsx";

                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }

                objWorkbook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                objWorkbook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(objWorkbook);
                releaseObject(xlApp);
            }

            return nombreArchivo;
        }

        private Excel.Workbook GenerateWorksheetsFile(HttpServerUtility server, Excel.Workbook objWorkbook)
        {
            CreatedContentWorksheets(objWorkbook.Worksheets.Add());

            return objWorkbook;
        }

        private void CreatedContentWorksheets(Excel.Worksheet xlWorksheet)
        {
            xlWorksheet.Name = "test";

            Excel.Range rangeText = null;

            rangeText = xlWorksheet.Range["B5", "D5"];
            rangeText.Merge();
            rangeText.Value = "Hola Mundo";
            rangeText.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            xlWorksheet.Cells[6, 6] = "Ejemplo";

            releaseObject(xlWorksheet);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show ("Excepción ocurrió mientras que la liberación de objeto" + ex.ToString ());
            }
            finally
            {
                GC.Collect();
            }
        }

        protected void LoadGrid()
        {
            IList<Cupones> lstCupones = new List<Cupones>();
            CuponesBLL objCuponesBLL = new CuponesBLL();
            Cupones objCupones = new Cupones();

            objCupones.Active = true;

            lstCupones = objCuponesBLL.SelectCuponsByDDL(objCupones);

            lstCupons.DataSource = lstCupones;
            lstCupons.DataTextField = "Descripcion";
            lstCupons.DataValueField = "Codigo";
            lstCupons.DataBind();
            //gvTest.DataSource = lstCupones;
            //gvTest.DataBind();
        }
    }
}