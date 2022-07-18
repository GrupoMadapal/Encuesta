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

namespace Poleo.BLL
{
    public class IndicadorMaestroBLL
    {
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
        public String generateFileVentas(VentasFinder objfinder, HttpServerUtility server)
        {
            
            String nombreArchivo = string.Empty;
            String nombreLayout = "IndicadorMaestroLayout.xlsx";
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                if (File.Exists(server.MapPath("/Layout") + "/" + nombreLayout))
                { 
                    xlWorkBook = xlApp.Workbooks.Open(server.MapPath("/Layout") + "/" + nombreLayout,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                    IList<IndicadorMaestro> lstIndicadorMaestro = SelectIndicadorMaestroV3(objfinder);//SelectIndicadorMaestroV2(objfinder);//this.SelectIndicadorMaestro(objfinder);
                    if (lstIndicadorMaestro.Count > 0)
                    {
                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.get_Item(1), objfinder, lstIndicadorMaestro);
                    }
                    nombreArchivo = "IndicadorMaestro.xlsx";
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
            }
            return nombreArchivo;

        }

        public void CreatedContentFileVentas(Excel.Worksheet xlWorksheet, VentasFinder objfinder, IList<IndicadorMaestro> lstIndicadorMaestro)
        {
            int numeroSemana = 0;
            int Xpos = 5, YPos = 2;//V3 //Xpos = 4, YPos = 3; - V2 //Xpos = 3, YPos = 9; - V1
            string LocationXl;

            foreach (IndicadorMaestro item in lstIndicadorMaestro)
            {
                #region V1
                //xlWorksheet.Cells[Xpos, YPos] = objfinder.NumeroSemana;
                //xlWorksheet.Cells[Xpos, YPos + 1] = item.VentasLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 2] = item.Ventas;
                //xlWorksheet.Cells[Xpos, YPos + 3] = item.OrdenesLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 4] = item.Ordenes;
                //xlWorksheet.Cells[Xpos, YPos + 5] = item.OrdRepartoLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 6] = item.OrdMostradorLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 7] = item.OrdReparto;
                //xlWorksheet.Cells[Xpos, YPos + 8] = item.OrdMostrador;
                //xlWorksheet.Cells[Xpos, YPos + 9] = item.NumOrdenesGratis;
                //xlWorksheet.Cells[Xpos, YPos + 10] = item.NumOrdenesMalas - item.NumOrdenesGratis;
                //xlWorksheet.Cells[Xpos, YPos + 11] = item.VentaOrdenesGratis;
                //xlWorksheet.Cells[Xpos, YPos + 12] = item.VentaOrdenesMalas-item.VentaOrdenesGratis;
                //xlWorksheet.Cells[Xpos, YPos + 14] = item.UtilizadoReal;
                //xlWorksheet.Cells[Xpos, YPos + 16] = item.UtilizadoPor;
                //xlWorksheet.Cells[Xpos, YPos + 17] = item.VentasReparto;
                //xlWorksheet.Cells[Xpos, YPos + 18] = item.VentaMostrador;
                //xlWorksheet.Cells[Xpos, YPos + 19] = item.VtsRepartoLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 20] = item.VtsMostradorLastYear;
                //xlWorksheet.Cells[Xpos, YPos + 21] = (Decimal)(item.VentaOrdenesMalas+item.VentaOrdenesGratis)/item.Ventas;
                //xlWorksheet.Cells[Xpos, YPos + 22] = item.PizzaTotal;
                //xlWorksheet.Cells[Xpos, YPos + 23] = item.PizzaSarten;
                //xlWorksheet.Cells[Xpos, YPos + 24] = item.PizzaOrilla;
                //xlWorksheet.Cells[Xpos, YPos + 25] = item.PizzaM85;
                //xlWorksheet.Cells[Xpos, YPos + 26] = item.P2X1;
                //xlWorksheet.Cells[Xpos, YPos + 27] = item.P14;
                //xlWorksheet.Cells[Xpos, YPos + 28] = item.PD4;
                //xlWorksheet.Cells[Xpos, YPos + 29] = item.Canelazo;
                //xlWorksheet.Cells[Xpos, YPos + 30] = item.Papotas;
                //xlWorksheet.Cells[Xpos, YPos + 31] = item.Wings;
                //xlWorksheet.Cells[Xpos, YPos + 32] = item.Fingers;
                //xlWorksheet.Cells[Xpos, YPos + 33] = item.Volcan;
                //xlWorksheet.Cells[Xpos, YPos + 34] = item.SweetBread;
                //xlWorksheet.Cells[Xpos, YPos + 35] = item.Cheese;
                //xlWorksheet.Cells[Xpos, YPos + 36] = item.REF120Z;
                //xlWorksheet.Cells[Xpos, YPos + 37] = item.REF160Z;
                //xlWorksheet.Cells[Xpos, YPos + 38] = item.REF220Z;
                //xlWorksheet.Cells[Xpos, YPos + 39] = item.REF320Z;
                //xlWorksheet.Cells[Xpos, YPos + 40] = item.REF500ML;
                //xlWorksheet.Cells[Xpos, YPos + 41] = item.REF600ML;
                //xlWorksheet.Cells[Xpos, YPos + 42] = item.REF2LTS;
                //xlWorksheet.Cells[Xpos, YPos + 43] = item.REF25LTS;
                #endregion

                #region V2
                //Modified by Hector Sanchez M. 20170822. - Salta un renlgon cuando no exista informacion de una tienda
                //LocationXl = xlWorksheet.Cells[Xpos, 1].Value.ToString();

                //        xlWorksheet.Cells[Xpos, YPos] = item.VentasLastYear;
                //        xlWorksheet.Cells[Xpos, YPos + 1] = item.Ventas;
                //        xlWorksheet.Cells[Xpos, YPos + 2] = item.OrdenesLastYear;
                //        xlWorksheet.Cells[Xpos, YPos + 3] = item.Ordenes;
                //        xlWorksheet.Cells[Xpos, YPos + 4] = item.UtilizadoReal;
                //        xlWorksheet.Cells[Xpos, YPos + 5] = item.UtilizadoPor;
                //        xlWorksheet.Cells[Xpos, YPos + 6] = item.PizzaTotal;
                //        xlWorksheet.Cells[Xpos, YPos + 7] = (decimal)item.Full_Template * (decimal)0.01;
                //        xlWorksheet.Cells[Xpos, YPos + 8] = (decimal)item.Training * (decimal)0.01;
                //        xlWorksheet.Cells[Xpos, YPos + 9] = (decimal)item.Communication * (decimal)0.01;
                //        xlWorksheet.Cells[Xpos, YPos + 10] = (decimal)item.VentaOrdenesGratis / item.Ventas;
                //        xlWorksheet.Cells[Xpos, YPos + 11] = (decimal)item.VentaOrdenesMalas / item.Ventas;
                //        xlWorksheet.Cells[Xpos, YPos + 12] = (decimal)item.PizzaNacional / item.Ordenes;
                //        xlWorksheet.Cells[Xpos, YPos + 13] = (decimal)item.PizzaM85 / item.Ordenes;
                //        xlWorksheet.Cells[Xpos, YPos + 14] = (decimal)item.PizzaLocal / item.Ordenes;
                #endregion
                
                xlWorksheet.Cells[Xpos, YPos] = item.Tienda;
                xlWorksheet.Cells[Xpos, YPos + 1] = item.NombreTienda;
                xlWorksheet.Cells[Xpos, YPos + 2] = item.VentasLastYear;
                xlWorksheet.Cells[Xpos, YPos + 3] = item.Ventas;
                xlWorksheet.Cells[Xpos, YPos + 4] = item.OrdenesLastYear;
                xlWorksheet.Cells[Xpos, YPos + 5] = item.Ordenes;
                xlWorksheet.Cells[Xpos, YPos + 6] = item.UtilizadoReal;
                xlWorksheet.Cells[Xpos, YPos + 7] = item.UtilizadoPor;
                xlWorksheet.Cells[Xpos, YPos + 8] = item.PizzaTotal;
                xlWorksheet.Cells[Xpos, YPos + 9] = item.Ordenes == 0 ? 0 : (decimal)item.PizzaNacional / (decimal)item.Ordenes;
                xlWorksheet.Cells[Xpos, YPos + 10] = item.Ordenes == 0 ? 0 : (decimal)item.TotalAdicionales / (decimal)item.Ordenes;
                
                Xpos++;
            }
            releaseObject(xlWorksheet);
        }

        #region DAL
        public IList<IndicadorMaestro> SelectIndicadorMaestro(VentasFinder param)
        {
            IndicadorMaestroDAL objIndicadorMaestroDAL = new IndicadorMaestroDAL();
            return objIndicadorMaestroDAL.SelectIndicadorMaestro(param);
        }

        //Added by Hector Sanchez M.- 20161130
        private IList<IndicadorMaestro> SelectIndicadorMaestroV2(VentasFinder param)
        {
            IndicadorMaestroDAL dal = new IndicadorMaestroDAL();
            return dal.SelectIndicadorMaestroV2(param);
        }

        //Added by Hector Sanchez M. - 20171025
        private IList<IndicadorMaestro> SelectIndicadorMaestroV3(VentasFinder param)
        {
            IndicadorMaestroDAL dal = new IndicadorMaestroDAL();
            return dal.SelectIndicadorMaestroV3(param);
        }
        #endregion
    }
}