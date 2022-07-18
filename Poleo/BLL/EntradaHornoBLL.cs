using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class EntradaHornoBLL
    {
        #region BLL
        public string CreateExcelFileEntradaHorno(HttpServerUtility server, int year)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            if(xlApp != null)
            {
                Excel.Workbook objWorkbook;
                objWorkbook = xlApp.Workbooks.Add(misValue);

                objWorkbook = GenerateWorksheetsFile(server, year, objWorkbook);

                nombreArchivo = "EntradaHorno.xlsx";

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

        private Excel.Workbook GenerateWorksheetsFile(HttpServerUtility server, int Year, Excel.Workbook objWorkbook)
        {
            VentasFinder objVentasFinder = GenerateFilter(Year);

            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinderTienda = new Tienda();
            IList<Tienda> lstTienda = new List<Tienda>();

            objFinderTienda.Ubicacion = objVentasFinder.UbicacionTienda;
            objFinderTienda.Tipo = objVentasFinder.TipoTienda;

            lstTienda = objTiendaBLL.SelectTiendas(objFinderTienda);

            foreach (Tienda objTienda in lstTienda)
            {
                objVentasFinder.NumTienda = objTienda.Number_tienda;

                IList<EntradaHorno> lstEntradaHorno = SelectEntradaHorno(objVentasFinder);
                CreatedContentWorksheets(objWorkbook.Worksheets.Add(), objTienda, Year, objVentasFinder, lstEntradaHorno);
            }

            return objWorkbook;
        }

        private void CreatedContentWorksheets(Excel.Worksheet xlWorksheet, Tienda objTienda, int Year, VentasFinder objVentasFinder, IList<EntradaHorno> lstEntradaHorno)
        {
            AnioBLL objAnioBLL = new AnioBLL();

            xlWorksheet.Name = objTienda.Code;

            int TotalSemanas = objAnioBLL.TotalWeekForYear(Year);
            DateTime dateItem = objVentasFinder.DateIni.Value;

            #region ENCABEZADO
            int cA = 0;

            for (int i = 0; i < 20; i += 10)
            {
                Excel.Range rangeDay = null;
                //xlWorksheet.Cells[5, 1 + i] = " # SEMANA";

                rangeDay = xlWorksheet.Range[AddPref(cA, "B5"), AddPref(cA, "D5")];
                rangeDay.Merge();
                rangeDay.Value = "LUNES";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "E5"), AddPref(cA, "G5")];
                rangeDay.Merge();
                rangeDay.Value = "MARTES";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "H5"), AddPref(cA, "J5")];
                rangeDay.Merge();
                rangeDay.Value = "MIERCOLES";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "K5"), AddPref(cA, "M5")];
                rangeDay.Merge();
                rangeDay.Value = "JUEVES";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "N5"), AddPref(cA, "P5")];
                rangeDay.Merge();
                rangeDay.Value = "VIERNES";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "Q5"), AddPref(cA, "S5")];
                rangeDay.Merge();
                rangeDay.Value = "SABADO";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "T5"), AddPref(cA, "V5")];
                rangeDay.Merge();
                rangeDay.Value = "DOMINGO";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rangeDay = xlWorksheet.Range[AddPref(cA, "W5"), AddPref(cA, "Y5")];
                rangeDay.Merge();
                rangeDay.Value = "TOTAL";
                rangeDay.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                cA++;
            }

            #region SUBTITULOS
            int c = 2;
            string lbl = "E.H. 0 - 3";
            for (int j = 0; j < 16; j++)
            {
                if (j == 8)
                {
                    c = 28;
                    lbl = "S.T. 5 - 15";
                }

                for (int h = 0; h < 3; h+=3)
                {
                    xlWorksheet.Cells[6, c++ + h] = lbl;
                    xlWorksheet.Cells[6, c++ + h] = "Total Ordenes";
                    xlWorksheet.Cells[6, c++ + h] = "%";
                }
            }
            #endregion
            #endregion

            int row = 7;
            int numDia = 1;
            int ColHorno = 1;
            int ColTorden = 3;
            int ColPorc = 4;
            int ColSalida = 27;
            int ColTorden2 = 29;
            int ColPorc2 = 30;
            int totalEntradaHorno = 0;
            int totalSalidaTienda = 0;
            int totalOrdenes = 0;

            int initialCount = 1;

            if (TotalSemanas == 53)
            {
                initialCount = 0;
                TotalSemanas = 52;
            }

            for (int i = initialCount; i <= TotalSemanas; i++)
            {
                xlWorksheet.Cells[row, ColHorno] = i;
                xlWorksheet.Cells[row, ColSalida] = i;
                ColHorno++;
                ColSalida++;

                for (int j = 0; j < 7; j++)
                {
                    int numSem = i;

                    if (initialCount == 0)
                        numSem++;

                    EntradaHorno objEntradaHorno = getEntradaHorono(lstEntradaHorno, numSem, numDia);

                    #region Entrada Horno
                    xlWorksheet.Cells[row, ColHorno] = objEntradaHorno.OrdenesHorno3min;
                    ColHorno += 3;
                    totalEntradaHorno += objEntradaHorno.OrdenesHorno3min;

                    xlWorksheet.Cells[row, ColTorden] = objEntradaHorno.Order_Count;
                    ColTorden += 3;
                    totalOrdenes += objEntradaHorno.Order_Count;

                    decimal PorcOrdenes = 0;

                    if (objEntradaHorno.Order_Count > 0)
                        PorcOrdenes = decimal.Parse(objEntradaHorno.OrdenesHorno3min.ToString()) / decimal.Parse(objEntradaHorno.Order_Count.ToString());

                    xlWorksheet.Cells[row, ColPorc] = PorcOrdenes;
                    ColPorc += 3;
                    #endregion

                    #region Salida Tienda
                    xlWorksheet.Cells[row, ColSalida] = objEntradaHorno.OrdenesSalidaTienda15min;
                    ColSalida += 3;
                    totalSalidaTienda += objEntradaHorno.OrdenesSalidaTienda15min;

                    xlWorksheet.Cells[row, ColTorden2] = objEntradaHorno.Order_Count;
                    ColTorden2 += 3;

                    PorcOrdenes = 0;

                    if (objEntradaHorno.Order_Count > 0)
                        PorcOrdenes = decimal.Parse(objEntradaHorno.OrdenesSalidaTienda15min.ToString()) / decimal.Parse(objEntradaHorno.Order_Count.ToString());

                    xlWorksheet.Cells[row, ColPorc2] = PorcOrdenes;
                    ColPorc2 += 3;
                    #endregion

                    numDia++;
                }

                #region Entrada Horno
                xlWorksheet.Cells[row, ColHorno] = totalEntradaHorno;
                xlWorksheet.Cells[row, ColTorden] = totalOrdenes;
                
                decimal PorcTotalOrdenes = 0;

                if (totalOrdenes > 0)
                    PorcTotalOrdenes = decimal.Parse(totalEntradaHorno.ToString()) / decimal.Parse(totalOrdenes.ToString());

                xlWorksheet.Cells[row, ColPorc] = PorcTotalOrdenes;
                #endregion

                #region Salida Tienda
                xlWorksheet.Cells[row, ColSalida] = totalSalidaTienda;
                xlWorksheet.Cells[row, ColTorden2] = totalOrdenes;

                PorcTotalOrdenes = 0;

                if (totalOrdenes > 0)
                    PorcTotalOrdenes = decimal.Parse(totalSalidaTienda.ToString()) / decimal.Parse(totalOrdenes.ToString());

                xlWorksheet.Cells[row, ColPorc2] = PorcTotalOrdenes;
                #endregion

                ColHorno = 1;
                ColTorden = 3;
                ColPorc = 4;
                ColSalida = 27;
                ColTorden2 = 29;
                ColPorc2 = 30;
                numDia = 1;
                row++;

                totalEntradaHorno = 0;
                totalOrdenes = 0;
                totalSalidaTienda = 0;
            }

            Excel.Range TxtSem = xlWorksheet.Range["A5", "A6"];
            TxtSem.Merge();
            TxtSem.Value = "SEMANA";
            TxtSem.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            TxtSem.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            TxtSem = xlWorksheet.Range["AA5", "AA6"];
            TxtSem.Merge();
            TxtSem.Value = "SEMANA";
            TxtSem.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            TxtSem.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            for (int x = 0; x < 2; x++)
            {
                Excel.Range FormatPorc = xlWorksheet.Range[AddPref(x, "D7"), AddPref(x, "D58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "G7"), AddPref(x, "G58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "J7"), AddPref(x, "J58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "M7"), AddPref(x, "M58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "P7"), AddPref(x, "P58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "S7"), AddPref(x, "S58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "V7"), AddPref(x, "V58")];
                FormatPorc.NumberFormat = "###,##0.00%";
                FormatPorc = xlWorksheet.Range[AddPref(x, "Y7"), AddPref(x, "Y58")];
                FormatPorc.NumberFormat = "###,##0.00%";
            }

            Excel.Range HeadTitle = xlWorksheet.Range["A2", "Y3"];
            HeadTitle.Merge();
            HeadTitle.Value = "HENTRADA HORNO 0 - 3 MINUTOS";
            HeadTitle.Font.Size = 24;
            HeadTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            HeadTitle = xlWorksheet.Range["AA2", "AY3"];
            HeadTitle.Merge();
            HeadTitle.Value = "SALIDA TIENDA 5 - 15 MINUTOS";
            HeadTitle.Font.Size = 24;
            HeadTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            releaseObject(xlWorksheet);
        }

        private VentasFinder GenerateFilter(int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            DateTime fechaInicial = new DateTime(Year, 1, 1);
            DateTime fechaFinal = new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12));
            int semIni = 1;
            int semFin = objAnioBLL.TotalWeekForYear(Year);

            if (semFin == 53)
            {
                semIni--;
                semFin--;
            }


            Semana objSemanaIni = new Semana(semIni, Year);
            Semana objSemanaEnd = new Semana(semFin, Year);

            VentasFinder objFinder = new VentasFinder()
            {
                DateIni = objSemanaIni.FechaInicial,
                DateEnd = objSemanaEnd.FechaFinal,
                UbicacionTienda = String.Empty,
                NumTienda = String.Empty,
                TipoTienda = String.Empty,
                SelectYear = Year
            };

            return objFinder;
        }

        private EntradaHorno getEntradaHorono(IList<EntradaHorno> lstEntradaHorno, int numSemana, int numDia)
        {
            EntradaHorno retEntradaHorno = new EntradaHorno();

            foreach (EntradaHorno objEntradaHorno in lstEntradaHorno)
            {
                if (objEntradaHorno.NumeroSemana == numSemana && objEntradaHorno.NumDia == numDia)
                {
                    retEntradaHorno = objEntradaHorno;
                    break;
                }
            }

            return retEntradaHorno;
        }

        private string AddPref(int val, string LetterAlph)
        {
            string Hedaer = LetterAlph;

            if (val == 1)
                Hedaer = "A" + LetterAlph;

            return Hedaer;
        }
        #endregion

        #region DAL
        private IList<EntradaHorno> SelectEntradaHorno(VentasFinder objFinder)
        {
            EntradaHornoDAL DAL = new EntradaHornoDAL();
            return DAL.SelectEntradaHorno(objFinder);
        }
        #endregion

        #region generic
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
    }
}