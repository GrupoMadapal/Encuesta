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
    public class OrdenesEditadasBLL
    {

        public IList<OrderCupons> SelectOrdenesEditadas(VentasFinder param)
        {
            OrdersFreeDAL DAL = new OrdersFreeDAL();
            return DAL.SelectOrdenesEditadas(param);
        }

        public String GenerateOrdenesEditadas(VentasFinder objVentasFinder, HttpServerUtility Server)
        {
            String NombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                this.RellenaOrdenesEditadas(objVentasFinder, xlWorkBook.Worksheets.Add());
                NombreArchivo = "OrdenesEditadas.xlsx";
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

        private void RellenaOrdenesEditadas(VentasFinder objVentasFinder, Excel.Worksheet xlWorksheet)
        {
            Excel.Range rangoHead = xlWorksheet.Range["A1", "E1"];
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "ORDEN";
            xlWorksheet.Cells[1, 3] = "FECHA";
            xlWorksheet.Cells[1, 4] = "NUM EMPLEADO";
            xlWorksheet.Cells[1, 5] = "EMPLEADO";
            rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);


            IList<OrderCupons> lstordersfree = this.SelectOrdenesEditadas(objVentasFinder);
            int it = 2;
            foreach (OrderCupons item in lstordersfree)
            {
                xlWorksheet.Cells[it, 1] = item.Location_Code;
                xlWorksheet.Cells[it, 2] = item.Order_Number;
                xlWorksheet.Cells[it, 3] = item.Order_Date;
                xlWorksheet.Cells[it, 4] = item.Num_Empleado;
                xlWorksheet.Cells[it, 5] = item.NombreEmpleado;

                it++;
            }

            Excel.Range
                columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["A1", "E" + it];
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