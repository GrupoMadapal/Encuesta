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
    public class DQ_IndicadorBLL
    {
        #region BLL
        public string CreateFileIndicador(DQ_VentasFinder objDQ_VentasFinder, HttpServerUtility Server)
        {
            Excel.Application xlApp = new Excel.Application();

            if (xlApp != null)
            {
                Excel.Workbook xlWorkbook;
                Excel.Workbook xlWorkbookLayout;
                object misValue = System.Reflection.Missing.Value;
                xlWorkbook = xlApp.Workbooks.Add(misValue);

                TiendaBLL objTiendaBLL = new TiendaBLL();
                Tienda objTiendaFinder = new Tienda();

                objTiendaFinder.Number_tienda = objDQ_VentasFinder.Sucursal;

                IList<Tienda> lstTienda = objTiendaBLL.SelectDQTiendas(objTiendaFinder);

                xlWorkbookLayout = xlApp.Workbooks.Open(HttpContext.Current.Server.MapPath(@"~\Layout\VentasDQ\IndicadorLayout.xlsx"),
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing);

                Excel.Worksheet xlSheetLayout = xlWorkbookLayout.Sheets[1];
                xlSheetLayout.UsedRange.Copy(Type.Missing);

                foreach (Tienda item in lstTienda)
                {
                    objDQ_VentasFinder.Sucursal = item.Number_tienda;

                    Excel.Worksheet newWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();

                    newWorksheet.UsedRange.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);

                    ////CreateWorkSheet(xlWorkbook.Worksheets.Add(xlWorkbookLayout.Sheets.get_Item(1), Type.Missing, Type.Missing, Type.Missing), objDQ_VentasFinder, item);
                    //xlWorkbook.Worksheets.Copy(xlWorkbookLayout.Sheets[1],Type.Missing);
                    CreateWorkSheet(newWorksheet, objDQ_VentasFinder, item);
                }

                string namefile = "IndicadorDQ.xlsx";

                if (File.Exists(Server.MapPath("/indicadores") + "/" + namefile))
                {
                    File.Delete(Server.MapPath("/indicadores") + "/" + namefile);
                }

                xlWorkbook.SaveAs(Server.MapPath("/indicadores") + "/" + namefile, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkbook.Close(true, misValue, misValue);
                xlWorkbookLayout.Close();
                xlApp.Quit();
                releaseObject(xlWorkbook);
                releaseObject(xlApp);

                return namefile;
            }

            return string.Empty;
        }

        private void CreateWorkSheet(Excel.Worksheet xlSheet, DQ_VentasFinder objDQ_VentasFinder, Tienda objTienda)
        {
            xlSheet.Name = objTienda.Nombre_tienda;

            DQ_Indicador objDQ_IndicadorSalesWeek = new DQ_Indicador();

            #region Ventas Semanales
            objDQ_IndicadorSalesWeek = SelectSalesWeek(objDQ_VentasFinder);

            if (objDQ_IndicadorSalesWeek != null)
            {
                xlSheet.Cells[7, 3] = objDQ_IndicadorSalesWeek.TotalSales;
                xlSheet.Cells[11, 3] = objDQ_IndicadorSalesWeek.Target;
                xlSheet.Cells[17, 3] = objDQ_IndicadorSalesWeek.SalesLastWeek;
                xlSheet.Cells[18, 3] = objDQ_IndicadorSalesWeek.SalesLastYear;
                xlSheet.Cells[19, 3] = objDQ_IndicadorSalesWeek.Transactions;
                xlSheet.Cells[20, 3] = objDQ_IndicadorSalesWeek.TransactionsLastWeek;
                xlSheet.Cells[21, 3] = objDQ_IndicadorSalesWeek.TransactionsLastYear;
                xlSheet.Cells[23, 3] = objDQ_IndicadorSalesWeek.SalesLastWeek / objDQ_IndicadorSalesWeek.TransactionsLastWeek;
            }
            #endregion

            #region Costo de comida
            IList<DQ_Indicador> lstPurchaseInovice =new List<DQ_Indicador>();

            lstPurchaseInovice = SelectPurchaseInvoice(objDQ_VentasFinder);
            int colPurchase = 28;
            foreach (DQ_Indicador item in lstPurchaseInovice)
            {
                xlSheet.Cells[colPurchase, 3] = item.TotalPurchaseInvoice;
                colPurchase++;
            }
            #endregion

            #region Analsis Costos
            DQ_Indicador objAnalisiCosto = new DQ_Indicador();

            objAnalisiCosto = SelectCosteMerma(objDQ_VentasFinder);

            xlSheet.Cells[52, 3] = objAnalisiCosto.TotalCosteMerma;
            #endregion

            #region Participacion
            IList<DQ_Indicador> lstParticipacion = new List<DQ_Indicador>();
            int rowSales = 58;
            int rowOrders = 67;
            int rowCoste = 75;

            lstParticipacion = SelectSalesDaily(objDQ_VentasFinder);

            foreach (DQ_Indicador item in lstParticipacion)
            {
                xlSheet.Cells[rowSales, 3] = item.RealSales;
                xlSheet.Cells[rowOrders, 3] = item.Orders;
                xlSheet.Cells[rowCoste, 3] = item.CosteIdeal;

                rowSales++;
                rowOrders++;
                rowCoste++;
            }
            #endregion

            #region Productos
            IList<DQ_Indicador> lstProductos = new List<DQ_Indicador>();
            int rowProducts = 8;

            lstProductos = SelectTopProducts(objDQ_VentasFinder);

            foreach (DQ_Indicador item in lstProductos)
            {
                xlSheet.Cells[rowProducts, 7] = item.Orders;
                xlSheet.Cells[rowProducts, 8] = item.TotalSales;

                rowProducts++;
            }
            #endregion

            releaseObject(xlSheet);
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

            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region DAL
        private DQ_Indicador SelectSalesWeek(DQ_VentasFinder param)
        {
            DQ_IndicadorDAL dal = new DQ_IndicadorDAL();

            return dal.SelectSalesWeek(param);
        }

        private IList<DQ_Indicador> SelectPurchaseInvoice(DQ_VentasFinder param)
        {
            DQ_IndicadorDAL dal = new DQ_IndicadorDAL();

            return dal.SelectPurchaseInvoice(param);
        }

        private DQ_Indicador SelectCosteMerma(DQ_VentasFinder param)
        {
            DQ_IndicadorDAL dal = new DQ_IndicadorDAL();

            return dal.SelectCosteMerma(param);
        }

        private IList<DQ_Indicador> SelectSalesDaily(DQ_VentasFinder param)
        {
            DQ_IndicadorDAL dal = new DQ_IndicadorDAL();

            return dal.SelectSalesDaily(param);
        }

        private IList<DQ_Indicador> SelectTopProducts(DQ_VentasFinder param)
        {
            DQ_IndicadorDAL dal = new DQ_IndicadorDAL();

            return dal.SelectTopProducts(param);
        }
        #endregion
    }
}