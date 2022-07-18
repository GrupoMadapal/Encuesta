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
    public class OrdersFreeBLL
    {

        public IList<OrderCupons> SelectFreeOrders(VentasFinder param)
        {
            OrdersFreeDAL DAL = new OrdersFreeDAL();
            return DAL.SelectFreeOrders(param);
        }

        public String Generateordersfree(VentasFinder objVentasFinder, HttpServerUtility Server)
        {
            String NombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                this.RellenaOrdersFree(objVentasFinder, xlWorkBook.Worksheets.Add());
                NombreArchivo = "OrdenesGratis.xlsx";
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

        private void RellenaOrdersFree(VentasFinder objVentasFinder, Excel.Worksheet xlWorksheet)
        {
            Excel.Range rangoHead = xlWorksheet.Range["A1", "F1"];
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "ORDEN";
            xlWorksheet.Cells[1, 3] = "FECHA";
            xlWorksheet.Cells[1, 4] = "CLIENTE";
            xlWorksheet.Cells[1, 5] = "TELEFONO";
            xlWorksheet.Cells[1, 6] = "PRECIO";
            rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            IList<OrderCupons> lstordersfree = this.SelectFreeOrders(objVentasFinder);
            int it = 2;
            foreach (OrderCupons item in lstordersfree)
            {
                xlWorksheet.Cells[it, 1] = item.Location_Code;
                xlWorksheet.Cells[it, 2] = item.Order_Number;
                xlWorksheet.Cells[it, 3] = item.Order_Date;
                xlWorksheet.Cells[it, 4] = item.Customer_Name;
                xlWorksheet.Cells[it, 5] = item.Phone;
                xlWorksheet.Cells[it, 6] = item.OrderPaymentDueAmt;

                it++;
            }

            Excel.Range
                columna = xlWorksheet.Range["F2", "F9999"];
            columna.NumberFormat = "$ #,##0.00";
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["A1", "F" + it];
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
