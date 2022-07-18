using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace Poleo.BLL
{
    public class OrdenesBLL
    {
        public IList<OrderDetail> selectOrdenesPorCupon(OrdenesFinder  param)
        {
            OrdenesDAL objOrdenesDal = new OrdenesDAL();
            return objOrdenesDal.selectOrdenesPorCupon(param);
        }
        public String CreateExcelFileCupones(OrdenesFinder objFinder,HttpServerUtility server)
        {
            String nombreArchivo=string.Empty;
             Excel.Application xlApp = new Excel.Application();
             object misValue = System.Reflection.Missing.Value;
             if (xlApp != null)
             {
                 Excel.Workbook xlWorkBook;
                 xlWorkBook = xlApp.Workbooks.Add(misValue);
                 this.SheetsCupons(objFinder, xlWorkBook.Worksheets.Add());
                 nombreArchivo ="Cupones.xlsx";
                 if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                 {
                     File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                 }
                 xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                 xlWorkBook.Close(true, misValue, misValue);
                 xlApp.Quit();
                 releaseObject(xlWorkBook);
             }             
             releaseObject(xlApp);
             return nombreArchivo;
        }
        private void SheetsCupons(OrdenesFinder objOrderCuponsFinder,Excel.Worksheet xlWorksheet)
        {
            xlWorksheet.Cells[2, 1] = "FECHA";
            xlWorksheet.Cells[2, 2] = "SUCURSAL";
            xlWorksheet.Cells[2, 3] = "NUMERO DE ORDEN";
            xlWorksheet.Cells[2, 4] = "PRODUCTO";
            xlWorksheet.Cells[2, 5] = "CANTIDAD";
            xlWorksheet.Cells[2, 6] = "CUPON";
            xlWorksheet.Cells[2, 7] = "DESCRIPCION";
            xlWorksheet.Cells[2, 8] = "TOTAL";
            IList<OrderDetail> lstOrderDetail = this.selectOrdenesPorCupon(objOrderCuponsFinder);
            if(lstOrderDetail.Count>0)
            {
                int coorX = 3;
                foreach(OrderDetail item in lstOrderDetail)                                       
                {
                    xlWorksheet.Cells[coorX, 1] = item.Ord_Dt;
                    xlWorksheet.Cells[coorX, 2] = item.Store_No ;
                    xlWorksheet.Cells[coorX, 3] = item.Ord_No;
                    xlWorksheet.Cells[coorX, 4] = item.Std_Prod_Cd;
                    xlWorksheet.Cells[coorX, 5] = item.Prod_Qt;
                    xlWorksheet.Cells[coorX, 6] = item.Cpn_Cd;
                    xlWorksheet.Cells[coorX, 7] = item.Cpn_Descr;
                    xlWorksheet.Cells[coorX, 8] = item.Menu_Amt;
                    coorX++;
                }
                Excel.Range rangoHead = xlWorksheet.Range["C1", "C1"];
                rangoHead.ColumnWidth = 20;
                rangoHead = xlWorksheet.Range["G1", "G1"];
                rangoHead.ColumnWidth = 50;
                rangoHead = xlWorksheet.Range["A2", "H"+ (lstOrderDetail.Count+2).ToString()];
                rangoHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rangoHead = xlWorksheet.Range["H3", "H" + (lstOrderDetail.Count + 2).ToString()];
                rangoHead.NumberFormat = "$ #,##0.00";
            }
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
    }
}