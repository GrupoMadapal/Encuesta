using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Poleo.Objects;
using Poleo.DAL;
using Poleo.Tools;

namespace Poleo.BLL
{
    public class TiempoServicioBLL
    {
        #region BLL
        public String CreateExcelFileTiempoServicio(HttpServerUtility server, int Year)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            if (xlApp != null)
            {
                Excel.Workbook objWorkbook;
                objWorkbook = xlApp.Workbooks.Add(misValue);

                objWorkbook = GenerateWorksheetsFile(server, Year, objWorkbook);

                nombreArchivo = "TiempoServicio.xlsx";

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

                IList<TiempoServicio> lstTiempoServicio = SelectTiempoServicio(objVentasFinder);
                CreatedContentWorksheets(objWorkbook.Worksheets.Add(), objTienda, Year, objVentasFinder, lstTiempoServicio);
            }

            return objWorkbook;
        }

        private void CreatedContentWorksheets(Excel.Worksheet xlWorksheet, Tienda objTienda, int Year, VentasFinder objVentasFinder, IList<TiempoServicio> lstTiempoServicio)
        {
            AnioBLL objAnioBLL = new AnioBLL();

            xlWorksheet.Name = objTienda.Code;

            int TotalSemanas = objAnioBLL.TotalWeekForYear(Year);
            DateTime dateItem = objVentasFinder.DateIni.Value;

            //Modified by Hector Sanchez M. 20180213 - Se agregan tablas "Estimado de entrega" y "Repisa"
            for (int i = 0; i < 60; i += 10)
            {
                xlWorksheet.Cells[6, 1 + i] = " # SEMANA";
                xlWorksheet.Cells[6, 2 + i] = "LUNES";
                xlWorksheet.Cells[6, 3 + i] = "MARTES";
                xlWorksheet.Cells[6, 4 + i] = "MIERCOLES";
                xlWorksheet.Cells[6, 5 + i] = "JUEVES";
                xlWorksheet.Cells[6, 6 + i] = "VIERNES";
                xlWorksheet.Cells[6, 7 + i] = "SABADO";
                xlWorksheet.Cells[6, 8 + i] = "DOMINGO";
                xlWorksheet.Cells[6, 9 + i] = "PROMEDIO";
            }

            int row = 7;
            int numDia = 1;
            int ColHorno = 1;
            int ColEstimadoEntrega = 11;
            int ColRepisa = 21;
            int ColEntrega30 = 31;
            int ColSalidaTienda = 41;
            int ColAdicionales = 51;
            int totalEntradaHorno = 0;
            int totalOrdenesEH = 0;
            int totalEstimadoEntrega = 0;//Added by Hector Sanchez M. 20180213
            int totalOrdenesEstimadoEntrega = 0;
            int totalRepisa = 0;//Added by Hector Sanchez M. 20180213
            int totalOrdenesRepisa = 0;
            decimal totalOrdenesEntregaTime = 0;
            decimal totalOrdenesRunTime = 0;
            decimal totalOrdenesSalidaTienda = 0;
            decimal totalAdicionales = 0;
            decimal totalOrders = 0;

            int initialCount = 1;

            //COMMENTED BY LEO FOR WEEK 53
            if (TotalSemanas == 53)
            {
               //initialCount = 0;
               // TotalSemanas--;
            }

            for (int i = initialCount; i <= TotalSemanas; i++)
            {
                xlWorksheet.Cells[row, ColHorno] = i;
                ColHorno++;
                xlWorksheet.Cells[row, ColEstimadoEntrega] = i;
                ColEstimadoEntrega++;
                xlWorksheet.Cells[row, ColRepisa] = i;
                ColRepisa++;
                xlWorksheet.Cells[row, ColEntrega30] = i;
                ColEntrega30++;
                xlWorksheet.Cells[row, ColSalidaTienda] = i;
                ColSalidaTienda++;
                xlWorksheet.Cells[row, ColAdicionales] = i;
                ColAdicionales++;

                for (int j = 0; j < 7; j++)
                {
                    int numSem = i;

                    if (initialCount == 0)
                        numSem++;

                    TiempoServicio objTiempoServicio = getTiempoServicio(lstTiempoServicio, numSem, numDia);

                    #region Entrada Horno
                    xlWorksheet.Cells[row, ColHorno] = objTiempoServicio.EntradaHornoMinHMS == string.Empty ? "00:00:00" : objTiempoServicio.EntradaHornoMinHMS;
                    ColHorno++;
                    totalEntradaHorno += objTiempoServicio.EntradaHornoSec;
                    totalOrdenesEH += objTiempoServicio.TotalOrder;
                    #endregion

                    #region Estimado de entrega
                    xlWorksheet.Cells[row, ColEstimadoEntrega] = objTiempoServicio.EstimadoEntregaHMS == string.Empty ? "00:00:00" : objTiempoServicio.EstimadoEntregaHMS;
                    ColEstimadoEntrega++;
                    totalEstimadoEntrega += objTiempoServicio.EstimadoEntregaSec;
                    totalOrdenesEstimadoEntrega += objTiempoServicio.OrdenesEstimadoEntrega;
                    #endregion

                    #region Repisa
                    xlWorksheet.Cells[row, ColRepisa] = objTiempoServicio.RepisaHMS == string.Empty ? "00:00:00" : objTiempoServicio.RepisaHMS;
                    ColRepisa++;
                    totalRepisa += objTiempoServicio.RepisaSec;
                    totalOrdenesRepisa += objTiempoServicio.OrdenesRepisa;
                    #endregion

                    #region Entrega 30 min
                    decimal PorcEntrega = 0;

                    if(objTiempoServicio.OrdenesRunTime > 0)
                    {
                        PorcEntrega = objTiempoServicio.OrdenesEntregaTime / objTiempoServicio.OrdenesRunTime;
                    }

                    xlWorksheet.Cells[row, ColEntrega30] = PorcEntrega;
                    totalOrdenesEntregaTime += objTiempoServicio.OrdenesEntregaTime;
                    totalOrdenesRunTime += objTiempoServicio.OrdenesRunTime;
                    ColEntrega30++;
                    #endregion

                    #region Tiempo Entrega salida tienda
                    decimal PorcSalida = 0;

                    if (objTiempoServicio.OrdenesRunTime > 0)
                    {
                        PorcSalida = objTiempoServicio.OrdenesSalidaTienda / objTiempoServicio.OrdenesRunTime;
                    }

                    xlWorksheet.Cells[row, ColSalidaTienda] = PorcSalida;
                    totalOrdenesSalidaTienda += objTiempoServicio.OrdenesSalidaTienda;
                    ColSalidaTienda++;
                    #endregion

                    #region Adicionales
                    decimal PorcAdicionales = 0;

                    if(objTiempoServicio.Orders>0)
                    {
                        PorcAdicionales = objTiempoServicio.Adicionales / objTiempoServicio.Orders;
                    }

                    xlWorksheet.Cells[row, ColAdicionales] = PorcAdicionales;//objTiempoServicio.ParticipacionAdicionales;
                    totalAdicionales += objTiempoServicio.Adicionales;
                    totalOrders += objTiempoServicio.Orders;
                    ColAdicionales++;
                    #endregion

                    numDia++;
                }

                //Modified by Hector Sanchez M. - 20160630
                #region Total Entrada Horno
                int porcEntradaHorno = 0;

                if (totalOrdenesEH > 0)
                {
                    porcEntradaHorno = totalEntradaHorno / totalOrdenesEH;
                }
                
                string strTotalEntradaHorno = ToolsTime.ConvertSecondsToHMS(porcEntradaHorno);//ConvertSecondsToHMS(porcEntradaHorno);
                xlWorksheet.Cells[row, ColHorno] = strTotalEntradaHorno;
                #endregion

                #region Total Estimado de entrega
                int porcEstimadoEntrega = 0;

                if (totalOrdenesEstimadoEntrega > 0)
                    porcEstimadoEntrega = totalEstimadoEntrega / totalOrdenesEstimadoEntrega;

                string strTotalEstimadoEntrega = ToolsTime.ConvertSecondsToHMS(porcEstimadoEntrega);
                xlWorksheet.Cells[row, ColEstimadoEntrega] = strTotalEstimadoEntrega;
                #endregion

                #region Repisa
                int porcRepisa = 0;

                if (totalOrdenesRepisa > 0)
                {
                    porcRepisa = totalRepisa / totalOrdenesRepisa;
                }

                string strTotalRepisa = ToolsTime.ConvertSecondsToHMS(porcRepisa);
                xlWorksheet.Cells[row, ColRepisa] = strTotalRepisa;
                #endregion

                decimal totalProcentaje = 0;
                if (totalOrdenesRunTime > 0)
                {
                    totalProcentaje = totalOrdenesEntregaTime / totalOrdenesRunTime;
                }
                xlWorksheet.Cells[row, ColEntrega30] = totalProcentaje;

                decimal totalProcSalida = 0;
                if (totalOrdenesRunTime > 0)
                {
                    totalProcSalida = totalOrdenesSalidaTienda / totalOrdenesRunTime;
                }
                xlWorksheet.Cells[row, ColSalidaTienda] = totalProcSalida;

                decimal totalPorcAdicionales = 0;
                if (totalOrders > 0)
                {
                    totalPorcAdicionales = totalAdicionales / totalOrders;
                }
                xlWorksheet.Cells[row, ColAdicionales] = totalPorcAdicionales;

                ColHorno = 1;
                ColEstimadoEntrega = 11;
                ColRepisa = 21;
                ColEntrega30 = 31;
                ColSalidaTienda = 41;
                ColAdicionales = 51;
                numDia = 1;
                row++;

                totalEntradaHorno = 0;
                totalOrdenesEH = 0;
                totalOrdenesEntregaTime = 0;
                totalOrdenesRunTime = 0;
                totalOrdenesSalidaTienda = 0;
                totalAdicionales = 0;
                totalOrders = 0;
                totalEstimadoEntrega = 0;
                totalOrdenesEstimadoEntrega = 0;
                totalRepisa = 0;
                totalOrdenesRepisa = 0;
            }

            Excel.Range rangeEntrega = xlWorksheet.Range["AP7", "AW58"];
            rangeEntrega.NumberFormat = "###,##0.00%";
            rangeEntrega = xlWorksheet.Range["AZ7", "BG58"];
            rangeEntrega.NumberFormat = "###,##0.00%";
            rangeEntrega = xlWorksheet.Range["AF7", "AM58"];
            rangeEntrega.NumberFormat = "###,##0.00%";

            Excel.Range Head = xlWorksheet.Range["A4", "I4"];
            Head.Merge();
            Head.Value = "ENTRADA HORNO 3 MIN";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            

            Head = xlWorksheet.Range["K4", "S4"];
            Head.Merge();
            Head.Value = "ESTIMADO DE ENTREGA";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Head = xlWorksheet.Range["U4", "AC4"];
            Head.Merge();
            Head.Value = "REPISA";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Head = xlWorksheet.Range["AE4", "AM4"];
            Head.Merge();
            Head.Value = "ENTREGA EN MENOS DE 30 MIN";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Head = xlWorksheet.Range["AO4", "AW4"];
            Head.Merge();
            Head.Value = "SALIDA DE TIENDA";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Head = xlWorksheet.Range["AY4", "BG4"];
            Head.Merge();
            Head.Value = "ADICIONALES";
            Head.Font.Size = 24;
            Head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

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
                //semIni--;    // COMMENTED BY LEO FOR WEEK 53
               semFin--;
            }
                

            Semana objSemanaIni = new Semana(semIni, Year);
            Semana objSemanaEnd = new Semana(semFin, Year);

            VentasFinder objFinder = new VentasFinder()
            {
                DateIni=objSemanaIni.FechaInicial,
                DateEnd=objSemanaEnd.FechaFinal,
                UbicacionTienda=String.Empty,
                NumTienda=String.Empty,
                TipoTienda=String.Empty,
                SelectYear = Year
            };

            return objFinder;
        }

        private TiempoServicio getTiempoServicio(IList<TiempoServicio> lstTiempoServicio, int numSemana, int numDia)
        {
            TiempoServicio retTiempoServicio = new TiempoServicio();

            foreach (TiempoServicio objTiempoServicio in lstTiempoServicio)
            {
                if (objTiempoServicio.NumSemana == numSemana && objTiempoServicio.NumDia == numDia)
                {
                    retTiempoServicio = objTiempoServicio;
                    break;
                }
            }

            return retTiempoServicio;
        }

        //Moved by Hector Sanchez M. 20160629 - Moved to generic class ToolsTime
        //private string ConvertSecondsToHMS(int Seconds)
        //{
        //    int horas = (Seconds / 3600);
        //    int minutos = ((Seconds - horas * 3600) / 60);
        //    int segundos = (Seconds - (horas * 3600 + minutos * 60));
        //    return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        //}
        #endregion

        #region DAL

        private IList<TiempoServicio> SelectTiempoServicio(VentasFinder objFinder)
        {
            TiempoServicioDAL DAL = new TiempoServicioDAL();
            return DAL.SelectTiempoServicio(objFinder);
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