using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;

using Poleo.Tools;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Poleo.BLL
{
    public class DetalleOpenPayBLL
    {

        public IList<OrderCupons> SelectDetalleOpenPay(VentasFinder param)
        {
            OrdersFreeDAL DAL = new OrdersFreeDAL();
            return DAL.SelectDetalleOpenPay(param);
        }

        public String GenerateDetallesOpenPay(VentasFinder objVentasFinder, HttpServerUtility Server)
        {
            String NombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                this.RellenaDetallesOpenPay(objVentasFinder, xlWorkBook.Worksheets.Add());
                NombreArchivo = "DetallesOpenPay.xlsx";
                if (File.Exists(Server.MapPath("/indicadores") + "/" + NombreArchivo))
                {
                    File.Delete(Server.MapPath("/indicadores") + "/" + NombreArchivo);
                }
                xlWorkBook.SaveAs(Server.MapPath("/indicadores") + "/" + NombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
            }
            releaseObject(xlApp);
            return NombreArchivo;
        }

        private void RellenaDetallesOpenPay(VentasFinder objVentasFinder, Excel.Worksheet xlWorksheet)
        {
            Excel.Range rangoHead = xlWorksheet.Range["A1", "N1"];
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "ORDEN";
            xlWorksheet.Cells[1, 3] = "FECHA";
            xlWorksheet.Cells[1, 4] = "CLIENTE";
            xlWorksheet.Cells[1, 5] = "COMENTARIOS";
            xlWorksheet.Cells[1, 6] = "STATUS";
            xlWorksheet.Cells[1, 7] = "RASON DE CANCELACIÓN";
            xlWorksheet.Cells[1, 8] = "PRECIO FINAL DE ORDEN";
            xlWorksheet.Cells[1, 9] = "NUMERO DE CALLE";
            xlWorksheet.Cells[1, 10] = "NOMBRE DE CALLE";
            xlWorksheet.Cells[1, 11] = "DIRECCION ORDEN LINEA 2";
            xlWorksheet.Cells[1, 12] = "DIRECCION ORDEN LINEA 4";
            xlWorksheet.Cells[1, 13] = "CODIGO POSTAL";
            xlWorksheet.Cells[1, 14] = "CIUDAD";

            rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            IList<OrderCupons> lstDetallesOpenPay= this.SelectDetalleOpenPay(objVentasFinder);
            int it = 2;
           
            foreach (OrderCupons item in lstDetallesOpenPay)
            {
                xlWorksheet.Cells[it, 1] = item.Location_Code;
                xlWorksheet.Cells[it, 2] = item.Order_Number;
                xlWorksheet.Cells[it, 3] = item.Order_Date;
                xlWorksheet.Cells[it, 4] = item.Customer_Name;
                xlWorksheet.Cells[it, 5] = item.Comments;
                xlWorksheet.Cells[it, 6] = item.Order_Status_Code;
                xlWorksheet.Cells[it, 7] = item.Cancel_Reason;
                xlWorksheet.Cells[it, 8] = item.OrderFinalPrice;
                xlWorksheet.Cells[it, 9] = item.OrderStreetNumber;
                xlWorksheet.Cells[it, 10] = item.OrderStreetName;
                xlWorksheet.Cells[it, 11] = item.OrderAddressLine2;
                xlWorksheet.Cells[it, 12] = item.OrderAddressLine4 ;
                xlWorksheet.Cells[it, 13] = item.OrderPostalCode;
                xlWorksheet.Cells[it, 14] = item.OrderCityName;

           



                it++;
            }

            Excel.Range
            
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 100;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["H2", "H2"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["H2", "H9999"];
            columna.NumberFormat = "$ #,##0.00";
            columna = xlWorksheet.Range["J2", "J2"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["K2", "K2"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["L2", "L2"];
            columna.ColumnWidth = 50;
            columna = xlWorksheet.Range["N2", "N2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["A1", "N" + it];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;


            releaseObject(xlWorksheet);
        }


        void releaseObject(object obj)
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

    }
}