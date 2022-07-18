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
    public class ReporteComprasBLL
    {
        public IList<InventoryPurchaseDetailsExtracts> SelectReporteCompras(VentasFinder param)
        {
            InventoryPurchaseDetailsExtractsDAL DAL = new InventoryPurchaseDetailsExtractsDAL();
            return DAL.SelectReporteCompras(param);
        }

        public string GenerateReporteCompras(VentasFinder objVentasFinder, HttpServerUtility Server)
        {
            String NombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();

            object misValue = System.Reflection.Missing.Value;
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                this.RellenaReporteCompras(objVentasFinder, xlWorkBook.Worksheets.Add());
                NombreArchivo = "ReporteCompras.xlsx";
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

        private void RellenaReporteCompras(VentasFinder objVentasFinder, Excel.Worksheet xlWorksheet)
        {
            Excel.Range rangoHead = xlWorksheet.Range["A1" , "O1"];
            xlWorksheet.Cells[1, 1] = "RecordType";
            xlWorksheet.Cells[1, 2] = "DatabaseVersion";
            xlWorksheet.Cells[1, 3] = "Location_Code";
            xlWorksheet.Cells[1, 4] = "System_Date";
            xlWorksheet.Cells[1, 5] = "PurchaseID";
            xlWorksheet.Cells[1, 6] = "VendorName";
            xlWorksheet.Cells[1, 7] = "VendorCode";
            xlWorksheet.Cells[1, 8] = "InvoiceNumber";
            xlWorksheet.Cells[1, 9] = "Type";
            xlWorksheet.Cells[1, 10] = "VendorItemCode";
            xlWorksheet.Cells[1, 11] = "InventoryCode";
            xlWorksheet.Cells[1, 12] = "Quantity";
            xlWorksheet.Cells[1, 13] = "OrderUnit";
            xlWorksheet.Cells[1, 14] = "Price";
            xlWorksheet.Cells[1, 15] = "Extended_Price";

            rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            IList<InventoryPurchaseDetailsExtracts> lstReporteCompras = this.SelectReporteCompras(objVentasFinder);
            int it = 2;
            foreach (InventoryPurchaseDetailsExtracts item in lstReporteCompras)
            {
                xlWorksheet.Cells[it, 1] = item.RecordType;
                xlWorksheet.Cells[it, 2] = item.DatabaseVersion;
                xlWorksheet.Cells[it, 3] = item.Location_Code;
                xlWorksheet.Cells[it, 4] = item.System_Date;
                xlWorksheet.Cells[it, 5] = item.PurchaseID;
                xlWorksheet.Cells[it, 6] = item.VendorName;
                xlWorksheet.Cells[it, 7] = item.VendorCode;
                xlWorksheet.Cells[it, 8] = item.InvoiceNumber;
                xlWorksheet.Cells[it, 9] = item.Type;
                xlWorksheet.Cells[it, 10] = item.VendorItemCode;
                xlWorksheet.Cells[it, 11] = item.InventoryCode;
                xlWorksheet.Cells[it, 12] = item.Quantity;
                xlWorksheet.Cells[it, 13] = item.OrderUnit;
                xlWorksheet.Cells[it, 14] = item.Price;
                xlWorksheet.Cells[it, 15] = item.Extended_Price;

                it++;
            }
        }



    void releaseObject(object obj)
          {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

          }

    }
}