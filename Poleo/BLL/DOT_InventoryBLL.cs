using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Poleo.BLL
{
    public class DOT_InventoryBLL
    {
        #region BLL
        public string GenerateFileUseInventory(VentasFinder objVentasFinder, HttpServerUtility server)
        {
            #region propiedades excel
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            string nombreArchivo = "Uso_Inventario.xlsx";
            #endregion

            if (xlApp != null)
            {
                xlWorkBook = GenerateWorksheetsFile(objVentasFinder, xlWorkBook);

                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }

                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }

            return nombreArchivo;
        }

        private Excel.Workbook GenerateWorksheetsFile(VentasFinder objVentasFinder, Excel.Workbook objWorkbook)
        {
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinderTienda = new Tienda();
            IList<Tienda> lstTienda = new List<Tienda>();

            objFinderTienda.Ubicacion = objVentasFinder.UbicacionTienda;
            objFinderTienda.Tipo = objVentasFinder.TipoTienda;
            objFinderTienda.Number_tienda = objVentasFinder.NumTienda;

            lstTienda = objTiendaBLL.SelectTiendas(objFinderTienda);

            foreach (Tienda objTienda in lstTienda)
            {
                InfoTiempoReal objInfoTiempoReal = new InfoTiempoReal();
                IList<DOT_Inventory> lstDOT_Inventory = new List<DOT_Inventory>();

                objInfoTiempoReal.NumTienda = objTienda.Number_tienda;
                objInfoTiempoReal.Fecha = objVentasFinder.DateIni.Value;
                objInfoTiempoReal.FechaEnd = objVentasFinder.DateEnd.Value;

                lstDOT_Inventory = GetUseInventory(objInfoTiempoReal);

                CreatedContentWorksheets(objWorkbook.Worksheets.Add(), objTienda.Code, lstDOT_Inventory);
            }

            return objWorkbook;
        }

        private void CreatedContentWorksheets(Excel.Worksheet xlWorkSheet, string NameStore, IList<DOT_Inventory> lstDOT_Inventory)
        {
            xlWorkSheet.Name = NameStore;

            xlWorkSheet.Cells[1, 1] = "Descripcion";
            xlWorkSheet.Cells[1, 2] = "Categoria";
            xlWorkSheet.Cells[1, 3] = "Unidad de conteo";
            xlWorkSheet.Cells[1, 4] = "Precio unitario";

            int row = 2;

            foreach (DOT_Inventory objDOT_Inventory in lstDOT_Inventory)
            {
                xlWorkSheet.Cells[row, 1] = objDOT_Inventory.Description;
                xlWorkSheet.Cells[row, 2] = objDOT_Inventory.ItemCategory;
                xlWorkSheet.Cells[row, 3] = objDOT_Inventory.Count_Unit;
                xlWorkSheet.Cells[row, 4] = objDOT_Inventory.UnitPrice;

                row++;
            }

            Excel.Range rangeVentasVal = xlWorkSheet.Range["D2", "D200"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";

            releaseObject(xlWorkSheet);
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
        #endregion

        #region DAL
        private IList<DOT_Inventory> GetUseInventory(InfoTiempoReal param)
        {
            DOT_InventoryDAL dal = new DOT_InventoryDAL();

            return dal.GetUseInventory(param);
        }
        #endregion
    }
}