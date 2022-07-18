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
    public class VentasBLL
        
    {
        public IList<Ventas> SelectVentas(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentas(param);
        }
        public IList<Ventas> SelectVentasGratis(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentasGratis(param);
        }
        public IList<Ventas> SelectVentasGratisTotal(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentasGratisTotal(param);
        }
        public IList<TotalSales> ventasAcumuladas(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.ventasAcumuladas(param);
        }
        public void DeleteExcel(String objRutaFile)
        {
            //Application xlApp = new Application();

            //if (xlApp != null)
            //{
            //    xlApp.DisplayAlerts = false;
            //    //cadena filePath = @ "d: \ test.xlsx";
            //    Workbook xlWorkBook = xlApp.Workbooks.Open(objRutaFile, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //    Sheets Workbook = xlWorkBook.Worksheets;
            //    Workbook[0].Delete();
            //    xlWorkBook.Save();
            //    xlWorkBook.Close();

            //    releaseObject(Workbook);
            //    releaseObject(xlWorkBook);
            //    releaseObject(xlApp);

            //}
            if (File.Exists(objRutaFile))
            {
                File.Delete(objRutaFile);
            }
        }
        public String GenerateExcel(VentasFinder objfinder, HttpServerUtility server)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet, xlWorksheet2;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorksheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                IList<Ventas> lstResultVentas = this.SelectVentas(objfinder);
                Excel.Range rangoHead = xlWorksheet.Range["D3", "N3"];
                rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                rangoHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rangoHead.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangoHead.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                rangoHead.WrapText = true;
                xlWorksheet.Cells[3, 4] = "Día";
                xlWorksheet.Cells[3, 5] = "Tienda";
                xlWorksheet.Cells[3, 6] = "Fecha";
                xlWorksheet.Cells[3, 7] = "Ventas Brutas";
                xlWorksheet.Cells[3, 8] = "Canceladas";
                xlWorksheet.Cells[3, 9] = "Ordenes Malas";
                xlWorksheet.Cells[3, 10] = "Ventas Netas";
                xlWorksheet.Cells[3, 11] = "I.V.A.";
                xlWorksheet.Cells[3, 12] = "Ventas Reales";
                xlWorksheet.Cells[3, 13] = "Ventas Reparto";
                xlWorksheet.Cells[3, 14] = "Ventas Mostrador";
                int X = 3;
                String numeroTienda = lstResultVentas.Count > 0 ? lstResultVentas[0].Tienda : String.Empty;
                foreach (Ventas item in lstResultVentas)
                {
                    X++;
                    if (numeroTienda != item.Tienda)
                    {

                        Excel.Range rangoEmpty = xlWorksheet.Range["D" + X.ToString(), "N" + X.ToString()];
                        rangoEmpty.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                        numeroTienda = item.Tienda;
                        X++;
                    }
                    xlWorksheet.Cells[X, 4] = item.Dia;
                    xlWorksheet.Cells[X, 5] = item.Tienda;
                    xlWorksheet.Cells[X, 6] = item.Fecha;
                    xlWorksheet.Cells[X, 7] = item.VentasBrutas.ToString();
                    xlWorksheet.Cells[X, 8] = item.Canceladas.ToString();
                    xlWorksheet.Cells[X, 9] = item.OrdenesMalas.ToString();
                    xlWorksheet.Cells[X, 10] = item.VentasNetas.ToString();
                    xlWorksheet.Cells[X, 11] = item.IVA.ToString();
                    xlWorksheet.Cells[X, 12] = item.VentasReales.ToString();
                    xlWorksheet.Cells[X, 13] = item.VentasReparto.ToString();
                    xlWorksheet.Cells[X, 14] = item.VentasMostrador.ToString();

                }
                Excel.Range rangoBody = xlWorksheet.Range["D4", "N" + X.ToString()];
                //rangoBody.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                rangoBody.Font.Bold = true;
                rangoBody.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Excel.Range rangeMoney = xlWorksheet.Range["G4", "N" + X.ToString()];
                rangeMoney.NumberFormat = "$ #,##0.00";
                Excel.Range chartRange1;
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)xlWorksheet2.ChartObjects(Type.Missing);
                Excel.ChartObject MYCHART1 = (Excel.ChartObject)xlCharts1.Add(0, 0, 3500, 550);
                Excel.Chart chartPage1 = MYCHART1.Chart;
                chartRange1 = xlWorksheet.get_Range("E3", "N" + X.ToString());
                chartPage1.SetSourceData(chartRange1, misValue);
                chartPage1.ChartType = Excel.XlChartType.xlColumnClustered;
                chartPage1.HasTitle = true;
                chartPage1.ChartTitle.Text = "Ventas  ";
                IList<TotalSales> lstTotalSales = this.TotalSalesbyStore(objfinder);
                X += 2;
                xlWorksheet.Cells[X, 4] = "Tienda";
                xlWorksheet.Cells[X, 5] = "Nombre Tienda";
                xlWorksheet.Cells[X, 6] = "Total Ventas Brutas";
                xlWorksheet.Cells[X, 7] = "Total Canceladas";
                xlWorksheet.Cells[X, 8] = "Total Ordenes Malas";
                xlWorksheet.Cells[X, 9] = "Total Ventas Netas";
                xlWorksheet.Cells[X, 10] = "Total I.V.A.";
                xlWorksheet.Cells[X, 11] = "Total Ventas Reales";
                xlWorksheet.Cells[X, 12] = "Total Ventas Reparto";
                xlWorksheet.Cells[X, 13] = "Total Ventas Mostrador";
                Excel.Range rangoHeadTotal = xlWorksheet.Range["D" + X.ToString(), "M" + X.ToString()];
                rangoHeadTotal.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                rangoHeadTotal.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                rangoHeadTotal.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rangoHeadTotal.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangoHeadTotal.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                rangoHeadTotal.WrapText = true;
                int inicio = X + 1;
                foreach (TotalSales item in lstTotalSales)
                {
                    X++;
                    xlWorksheet.Cells[X, 4] = item.Tienda;
                    xlWorksheet.Cells[X, 5] = item.Name;
                    xlWorksheet.Cells[X, 6] = item.VentasBrutasTotal.ToString();
                    xlWorksheet.Cells[X, 7] = item.CanceladasTotal.ToString();
                    xlWorksheet.Cells[X, 8] = item.OrdenesMalasTotal.ToString();
                    xlWorksheet.Cells[X, 9] = item.VentasNetasTotal.ToString();
                    xlWorksheet.Cells[X, 10] = item.IVATotal.ToString();
                    xlWorksheet.Cells[X, 11] = item.VentasRealesTotal.ToString();
                    xlWorksheet.Cells[X, 12] = item.VentasRepartoTotal.ToString();
                    xlWorksheet.Cells[X, 13] = item.VentasMostradorTotal.ToString();
                }

                Excel.Range rangoBodyT = xlWorksheet.Range["D" + inicio.ToString(), "M" + X.ToString()];
                rangoBodyT.Font.Bold = true;
                rangoBodyT.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rangoBodyT.WrapText = true;
                Excel.Range rangeMoneyT = xlWorksheet.Range["F" + inicio.ToString(), "M" + X.ToString()];
                rangeMoneyT.NumberFormat = "$ #,##0.00";
                Excel.Range chartRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorksheet2.ChartObjects(Type.Missing);
                Excel.ChartObject MYCHART = (Excel.ChartObject)xlCharts.Add(0, 600, 800, 550);
                Excel.Chart chartPage = MYCHART.Chart;
                chartRange = xlWorksheet.get_Range("D" + (inicio - 1).ToString(), "M" + X.ToString());
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = "Ventas Totales ";
                DateTime dateAux = DateTime.Now;
                nombreArchivo = dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString() + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "_Ventas.xlsx";
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }

            return nombreArchivo;
        }
        public String GenerateResumenVentas(VentasFinder objfinder, HttpServerUtility server)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objfinder.UbicacionTienda,
                    Tipo = objfinder.TipoTienda

                };

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                foreach (Tienda item in lstTiendas)
                {

                    this.CreatesheetResumenVentas(xlWorkBook.Worksheets.Add(), objfinder, item);

                }



                DateTime dateAux = DateTime.Now;
                nombreArchivo = dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString() + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasResumen.xlsx";
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                //releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }
        public void CreatesheetResumenVentas(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda)
        {

            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Cells[1, 1] = "FECHA";
            xlWorksheet.Cells[1, 2] = "DÍA";
            xlWorksheet.Cells[1, 3] = "NUMERO DE SEMANA";
            xlWorksheet.Cells[1, 4] = "TOTAL DE ORDENES";
            xlWorksheet.Cells[1, 5] = "ORDENES CANCELADAS";
            xlWorksheet.Cells[1, 6] = "VENTAS REALES";
            xlWorksheet.Cells[1, 7] = "VENTAS MALAS";
            xlWorksheet.Cells[1, 8] = "UTILIZADO";
            xlWorksheet.Cells[1, 9] = "UTILIZADO %";

            for (int i = 2; i < 368; i++)
            {
                xlWorksheet.Cells[i, 1] = "-----";
                xlWorksheet.Cells[i, 2] = "-----";
                xlWorksheet.Cells[i, 3] = "-----";
                xlWorksheet.Cells[i, 4] = 0;
                xlWorksheet.Cells[i, 5] = 0;
                xlWorksheet.Cells[i, 6] = 0;
                xlWorksheet.Cells[i, 7] = 0;
                xlWorksheet.Cells[i, 8] = 0;
                xlWorksheet.Cells[i, 9] = 0;
            }
            objfinder.NumTienda = objTienda.Number_tienda;
            IList<ResumenVentas> lstResumenVentas = this.SelectResumenVentas(objfinder);
            int it = 2;
            foreach (ResumenVentas item in lstResumenVentas)
            {
                xlWorksheet.Cells[it, 1] = item.Fecha.ToShortDateString();
                xlWorksheet.Cells[it, 2] = item.Dia;
                xlWorksheet.Cells[it, 3] = item.NumeroSemana;
                xlWorksheet.Cells[it, 4] = item.OrdenesTotales;
                xlWorksheet.Cells[it, 5] = item.OrdenesMalas;
                xlWorksheet.Cells[it, 6] = (Double)item.VentasReales;
                xlWorksheet.Cells[it, 7] = (Double)item.VentasMalas;
                xlWorksheet.Cells[it, 8] = (Double)item.Utilizado;
                xlWorksheet.Cells[it, 9] = (Double)item.UtilizadoPorcentaje;
                it++;
            }
            releaseObject(xlWorksheet);
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

        public IList<DailyInventoryExtracts> SelectUseInventory(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectUseInventory(param);
        }
        public IList<TotalSales> TotalSalesbyStore(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.TotalSalesbyStore(param);
        }
        public IList<SalesLastYear> SelectSalesLastWeek(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectSalesLastWeek(param);
        }
        public IList<TotalSales> SelectTotalGratis(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectTotalGratis(param);

        }
        public IList<ResumenVentas> SelectResumenVentas(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectResumenVentas(param);

        }
        public IList<ResumenVentas> SelectResumenVentas2(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectResumenVentas2(param);

        }
        public String GenerateResumenVentasV2(VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            string fecharArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objfinder.UbicacionTienda,
                    Tipo = objfinder.TipoTienda

                };

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                foreach (Tienda item in lstTiendas)
                {

                    this.CreatesheetResumenVentasV2(xlWorkBook.Worksheets.Add(), objfinder, item, Year);

                }
                Tienda objtienda = new Tienda()
                {
                    Code = "ALL",
                    Number_tienda = string.Empty
                };
                this.CreatesheetResumenVentasV2(xlWorkBook.Worksheets.Add(), objfinder, objtienda, Year);



                DateTime dateAux = DateTime.Now;

                if (objfinder.DateIni != null)
                    fecharArchivo = objfinder.DateIni.Value.Year.ToString() + objfinder.DateIni.Value.Month.ToString() + objfinder.DateIni.Value.Day.ToString();
                else
                    fecharArchivo = dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString();

                nombreArchivo = fecharArchivo + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasResumen.xlsx"; //dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString() + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasResumen.xlsx";
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                //releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }
        public void CreatesheetResumenVentasV2(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();

            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "FECHA";
            xlWorksheet.Cells[1, 3] = "DÍA";
            xlWorksheet.Cells[1, 4] = "NUMERO DE SEMANA";
            xlWorksheet.Cells[1, 5] = "TOTAL MAESTRO";
            xlWorksheet.Cells[1, 6] = "VENTAS REALES";
            xlWorksheet.Cells[1, 7] = "VENTAS MALAS";
            xlWorksheet.Cells[1, 8] = "ORDENES MALAS";
            xlWorksheet.Cells[1, 9] = "ORDENES";
            xlWorksheet.Cells[1, 10] = "UTILIZADO";
            xlWorksheet.Cells[1, 11] = "UTILIZADO %";
            xlWorksheet.Cells[1, 12] = "INVENTARIO FINAL";
            xlWorksheet.Cells[1, 13] = "EFECTIVO";
            xlWorksheet.Cells[1, 14] = "TARJETAS";
            xlWorksheet.Cells[1, 15] = "OPENPAY";
            xlWorksheet.Cells[1, 16] = "UBER EATS";

            int TW = objAnioBLL.TotalWeekForYear(Year);

            objfinder.NumTienda = objTienda.Number_tienda;
            IList<ResumenVentas> lstResumenVentas = this.SelectResumenVentas2(objfinder);
            int it = 2;
            foreach (ResumenVentas item in lstResumenVentas)
            {
                int numSem = item.NumeroSemana;

                if (TW == 53)
                    numSem--;

                xlWorksheet.Cells[it, 1] = item.Code;
                xlWorksheet.Cells[it, 2] = item.Fecha.ToOADate(); //xlWorksheet.Cells[it, 2] = item.Fecha.ToShortDateString();
                xlWorksheet.Cells[it, 3] = item.Dia;
                xlWorksheet.Cells[it, 4] = numSem;//item.NumeroSemana;
                xlWorksheet.Cells[it, 5] = item.MasterSales;
                xlWorksheet.Cells[it, 6] = (Double)item.VentasReales;
                xlWorksheet.Cells[it, 7] = (Double)item.VentasMalas;
                xlWorksheet.Cells[it, 8] = (Double)item.OrdenesMalas;
                xlWorksheet.Cells[it, 9] = (Double)item.OrdenesTotales;
                xlWorksheet.Cells[it, 10] = (Double)item.Utilizado;
                xlWorksheet.Cells[it, 11] = (Decimal)(item.VentasReales > 0 ? item.Utilizado / item.VentasReales : 0);
                xlWorksheet.Cells[it, 12] = (Double)item.InventarioFinal;
                xlWorksheet.Cells[it, 13] = (Decimal)item.DepositosEfectivo;
                xlWorksheet.Cells[it, 14] = (Double)item.DepositosTargeta;
                xlWorksheet.Cells[it, 15] = (double)item.OpenPay; 
                xlWorksheet.Cells[it, 16] = (double)item.UberEats;

                it++;
            }
            Excel.Range columna = xlWorksheet.Range["E2", "G" + (lstResumenVentas.Count + 1).ToString()];
            columna.NumberFormat = "$ #,##0.00";

            columna = xlWorksheet.Range["J2", "J" + (lstResumenVentas.Count + 1).ToString()];
            columna.NumberFormat = "$ #,##0.00";
            columna = xlWorksheet.Range["L2", "P" + (lstResumenVentas.Count + 1).ToString()];
            columna.NumberFormat = "$ #,##0.00";
            columna = xlWorksheet.Range["K2", "K" + (lstResumenVentas.Count + 1).ToString()];
            columna.NumberFormat = "###,##0.00%";
            columna = xlWorksheet.Range["B2", "B" + (lstResumenVentas.Count + 1).ToString()];
            columna.NumberFormat = "dd/MM/yyyy";
            columna = xlWorksheet.Range["A1", "P" + (lstResumenVentas.Count + 1).ToString()];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["H2", "H2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["K2", "K2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["L2", "L2"];
            columna.ColumnWidth = 18;


            releaseObject(xlWorksheet);
        }
        public String GenerateAutomaticFile(HttpServerUtility server, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            DateTime fechaInicial = new DateTime(Year, 1, 1);//new DateTime(DateTime.Now.Year, 1, 1);
            DateTime fechaFinal = new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12));//new DateTime(DateTime.Now.Year, 12,DateTime.DaysInMonth(DateTime.Now.Year,12));
            int semIni = 1;//CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fechaInicial, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int semFin = objAnioBLL.TotalWeekForYear(Year);//CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fechaFinal, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            if (semFin == 53)
            {
                semIni--;
                semFin--;
            }


            Semana objSemanaIni = new Semana(semIni, Year);//DateTime.Now.Year);
            Semana objSemanaEnd = new Semana(semFin, Year);//DateTime.Now.Year);

            VentasFinder objFinder = new VentasFinder()
            {
                DateIni = objSemanaIni.FechaInicial,
                DateEnd = objSemanaEnd.FechaFinal,
                UbicacionTienda = String.Empty,
                NumTienda = String.Empty,
                TipoTienda = String.Empty,
                SelectYear = Year
            };

            return generateFileVentas(objFinder, server, Year);
        }
        #region TO DELETE
        //public List<RowVentas> CreateMatriz(DateTime dateIni, DateTime dateEnd, IList<Ventas> lstVentasfile)
        //{
        //    List<RowVentas> matrizVentas = new List<RowVentas>();


        //    int totalSemanas = ((dateEnd - dateIni).Days+1) / 7;
        //    int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        //    DateTime dateItem = dateIni;
        //    for (int numSemana = 1; numSemana <= totalSemanas; numSemana++ )
        //    {

        //        RowVentas itemRowVentas = new RowVentas()
        //        {
        //            NumeroSemana = numSemana
        //        };
        //        for (int numDia = 1; numDia <= 7;numDia++ )
        //        {
        //            ColVentas itemColVentas = new ColVentas
        //            {
        //                NumDia=numDia,
        //                Fecha=dateItem
        //            };
        //            if (DateTime.Now >= dateItem)
        //            {
        //                Ventas objRes = this.getVentas(lstVentasfile, numSemana, numDia, dateItem);
        //                if (objRes != null)
        //                {
        //                    itemColVentas.VentasDia = objRes;
        //                }
        //            }
        //            dateItem = dateItem.AddDays(1);
        //            itemRowVentas.LstColVentas.Add(itemColVentas);
        //        }
        //            matrizVentas.Add(itemRowVentas);
        //    }
        //    return matrizVentas;
        //}
        #endregion
        public Ventas getVentas(IList<Ventas> lstVentasfile, int numSemana, int numDia, DateTime dateSearch)
        {
            Ventas res = new Ventas()
            {
                VentasReales = 0,
                VentasRegaladas = 0,
                Utilizado = 0,
                Ordenes = 0,
                OrdenesRegaladas = 0

            };
            if (dateSearch <= DateTime.Now)
            {
                foreach (Ventas item in lstVentasfile)
                {
                    if (item.NumSemana == numSemana && item.NumDia == numDia)
                    {
                        res = item;
                        break;
                    }
                }
            }
            return res;
        }
        public String generateFileVentas(VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objfinder.UbicacionTienda,
                    Tipo = objfinder.TipoTienda
                };
                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                foreach (Tienda item in lstTiendas)
                {
                    objfinder.NumTienda = item.Number_tienda;
                    //IList<Ventas> lstVentasfile = this.SelectVentasGratis(objfinder);
                    IList<Ventas> lstVentasfile = this.SelectMasterSales(objfinder);
                    if (lstVentasfile.Count > 0)
                    {
                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile, Year);
                    }
                }
                objfinder.NumTienda = "";
                objfinder.UbicacionTienda = "San Luis Potosí";
                IList<Ventas> lstVentasfileALL = this.SelectVentasGratisTotal(objfinder);
                Tienda objTienda = new Tienda()
                {
                    Code = "TOTAL_SLP",
                    Number_tienda = string.Empty
                };
                if (lstVentasfileALL.Count > 0)
                {
                    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTienda, lstVentasfileALL, Year);
                }

                objfinder.NumTienda = "";
                objfinder.UbicacionTienda = "Tamaulipas";
                IList<Ventas> lstVentasfileALLSLP = this.SelectVentasGratisTotal(objfinder);
                Tienda objTiendaSLP = new Tienda()
                {
                    Code = "TOTAL_TMPS",
                    Number_tienda = string.Empty
                };
                if (lstVentasfileALL.Count > 0)
                {
                    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP, lstVentasfileALLSLP, Year);
                }

                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "VentasDiarias" + anioNom + ".xlsx";
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

        public String generateFileContabilidadDP(VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                //Tienda objFinder = new Tienda()
                //{
                //    Ubicacion = objfinder.UbicacionTienda,
                //    Tipo = objfinder.TipoTienda
                //};
                //IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                //foreach (Tienda item in lstTiendas)
                //{
                //    objfinder.NumTienda = item.Number_tienda;
                //    //IList<Ventas> lstVentasfile = this.SelectVentasGratis(objfinder);
                //    IList<Ventas> lstVentasfile = this.SelectMasterSales(objfinder);
                //    if (lstVentasfile.Count > 0)
                //    {
                //        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile, Year);
                //    }
                //}
                //objfinder.NumTienda = "";
                //objfinder.UbicacionTienda = "San Luis Potosí";
                //IList<Ventas> lstVentasfileALL = this.SelectVentasGratisTotal(objfinder);
                //Tienda objTienda = new Tienda()
                //{
                //    Code = "TOTAL_SLP",
                //    Number_tienda = string.Empty
                //};
                //if (lstVentasfileALL.Count > 0)
                //{
                //    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTienda, lstVentasfileALL, Year);
                //}


                objfinder.NumTienda = "";
                objfinder.UbicacionTienda = "Tamaulipas";
                Tienda objTiendaSLP = new Tienda()
                {
                    Code = "Intrucciones",
                    Number_tienda = string.Empty
                };
                this.CreatedContentFileContabilidadDPIntrucciones(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP, Year);

                DateTime dateAux = DateTime.Now;
                //string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "Reportes Dominos " + Year.ToString() + ".xlsx";
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

        public String generarArchivoVentas(HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorksheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorksheet = xlWorkBook.Worksheets.Add();

            string connectionString = ConfigurationManager.ConnectionStrings["madapal"].ConnectionString;
            DataSet dt = new DataSet();
            
            ADODB.Connection objConn = new ADODB.Connection();
            ADODB.Recordset objRS = new ADODB.Recordset();
            try
            {   
                objConn.Open("Provider=SQLOLEDB; Data Source=192.168.1.99; database=madapal; uid=MadDes; password=madAdmin", "", "", 0);
                objRS.Open("EXEC ReporteVentas '2020'", objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic, 0);

                System.Collections.IEnumerator objFields = objRS.Fields.GetEnumerator();
                int nFields = objRS.Fields.Count;

                string[,] titulos = new string[2, 3];
                titulos[0, 0] = "VENTAS REALES";
                titulos[0, 1] = "A4";
                titulos[0, 2] = "I4";
                titulos[1, 0] = "REGALADAS";
                titulos[1, 1] = "K4";
                titulos[1, 2] = "S4";

                Excel.Range head;
                for (int n = 0; n < titulos.GetLength(0); n++)
                {
                    head = xlWorksheet.Range[titulos[n, 1], titulos[n, 2]];
                    head.Merge();
                    head.Value = titulos[n,0];
                    head.Font.Size = 24;
                    head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                object[] objHeaders = new object[nFields];
                ADODB.Field objField;
                for (int n = 0; n < nFields; n++)
                {
                    objFields.MoveNext();
                    objField = (ADODB.Field)objFields.Current;
                    objHeaders[n] = objField.Name;
                }

                Excel.Range objRange = xlWorksheet.Cells.get_Range("A6", misValue);
                objRange = objRange.get_Resize(1, nFields);
                objRange.Value = objHeaders;

                objRange = xlWorksheet.Cells.get_Range("A7", misValue);
                objRange.CopyFromRecordset(objRS, misValue, misValue);

                objRS.Close();
                objConn.Close();    
            }
            catch (Exception ex)
            {
                objRS.Close();
                objConn.Close();
            }

            
            nombreArchivo = "VentasDiarias" + Year + ".xlsx";
            if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
            {
                File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
            }
            xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            return nombreArchivo;

        }

        public void CreatedContentFileVentas(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            xlWorksheet.Name = objTienda.Code;
            int totalSemanas = objAnioBLL.TotalWeekForYear(Year);//((objfinder.DateEnd.Value - objfinder.DateIni.Value).Days + 1) / 7;
            int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            DateTime dateItem = objfinder.DateIni.Value;
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            //Modified by Hector Sanchez M. 20160118 - Added tables "Ordenes Malas" and "Ordenes Canceladas"
            //Modified by Hector Sanchez M. 20160316 - Added tables "Ordenes Internet" and "Ventas Internet"
            //Modified by Hector Sanchez M. 20170405 - Added tables "Restaurante", "Mostrador" and "Reparto"
            //Modified by LEO               20190121 - Added tables "Ordenes restaurante, mostrador and reparto"
            for (int i = 0; i < 210; i += 10)//for (int i = 0; i < 120; i += 10)
            {
                xlWorksheet.Cells[6, 1 + i] = " # SEMANA";
                xlWorksheet.Cells[6, 2 + i] = "LUNES";
                xlWorksheet.Cells[6, 3 + i] = "MARTES";
                xlWorksheet.Cells[6, 4 + i] = "MIERCOLES";
                xlWorksheet.Cells[6, 5 + i] = "JUEVES";
                xlWorksheet.Cells[6, 6 + i] = "VIERNES";
                xlWorksheet.Cells[6, 7 + i] = "SABADO";
                xlWorksheet.Cells[6, 8 + i] = "DOMINGO";
                xlWorksheet.Cells[6, 9 + i] = "TOTAL";
            }

            int ren = 7;
            int colVentas = 1;
            int colRegaladas = 11;
            int colOrdenes = 21;
            int colOrdenesRegaladas = 31;
            int colUtilizado = 41;
            int colCosto = 51;
            int colUtilizadoReal = 61;
            int colUtilizadoRealpor = 71;
            int colOrdenesMalas = 81;
            int colVentasMalas = 91;
            int colOrdenesCanceladas = 101;
            int colVentasCanceladas = 111;
            int colOrdenesInternet = 121;
            int colVentasInternet = 131;
            int colVentasRestaurat = 141;
            int colVentasMostrador = 151;
            int colVentasReparto = 161;
            int colOrdenesRestaurante = 171;
            int colOrdenesMostrador = 181;
            int colOrdenesReparto = 191;
            int colOrdenesRestauranteMostrador = 201;
            int numDia = 1;
            Decimal totalVentasReales = 0, totalVentasRegaladas = 0, totalOrdenes = 0, totalOrdenesRegaladas = 0;
            Decimal totalUtilizado = 0, totalCosto = 0;
            Decimal totalUtilizadoReal = 0;
            Decimal totalUtilizadoRealpor = 0;
            Decimal totalOrdenesMalas = 0;
            Decimal totalVentasMalas = 0;
            Decimal totalOrdenesCanceladas = 0;
            Decimal totalVentasCanceladas = 0;
            Decimal totalOrdenesInternet = 0;
            Decimal totalVentasInternet = 0;
            Decimal TotalVentasRestaurant = 0;
            Decimal TotalVentasMostrador = 0;
            Decimal TotalVentasReparto = 0;
            Decimal TotalOrdenesReparto = 0;
            Decimal TotalOrdenesMostrador = 0;
            Decimal TotalOrdenesRestaurante = 0;
            Decimal TotalOrdenesRestauranteMostrador = 0;
            DateTime? dateItemIni = null, dateItemEnd = null;
            int initialCount = 1;

            if (totalSemanas == 53)
            {
                //initialCount = 0;
                //totalSemanas--;
            }

            for (int i = initialCount; i <= totalSemanas; i++)//for (int i = 0; i < totalSemanas; i++)
            {
                xlWorksheet.Cells[ren, colVentas] = i;
                colVentas++;
                xlWorksheet.Cells[ren, colOrdenes] = i;
                colOrdenes++;
                xlWorksheet.Cells[ren, colRegaladas] = i;
                colRegaladas++;
                xlWorksheet.Cells[ren, colOrdenesRegaladas] = i;
                colOrdenesRegaladas++;
                xlWorksheet.Cells[ren, colUtilizado] = i;
                colUtilizado++;
                xlWorksheet.Cells[ren, colCosto] = i;
                colCosto++;
                xlWorksheet.Cells[ren, colUtilizadoReal] = i;
                colUtilizadoReal++;
                xlWorksheet.Cells[ren, colUtilizadoRealpor] = i;
                colUtilizadoRealpor++;
                //Added by Hector Sanchez M. 20160118
                xlWorksheet.Cells[ren, colOrdenesMalas] = i;
                colOrdenesMalas++;
                xlWorksheet.Cells[ren, colVentasMalas] = i;
                colVentasMalas++;
                xlWorksheet.Cells[ren, colOrdenesCanceladas] = i;
                colOrdenesCanceladas++;
                xlWorksheet.Cells[ren, colVentasCanceladas] = i;
                colVentasCanceladas++;
                //Added by Hector Sanchez M. 20160316
                xlWorksheet.Cells[ren, colOrdenesInternet] = i;
                colOrdenesInternet++;
                xlWorksheet.Cells[ren, colVentasInternet] = i;
                colVentasInternet++;
                //Added by Hector Sanchez M. 20170405
                xlWorksheet.Cells[ren, colVentasRestaurat] = i;
                colVentasRestaurat++;
                xlWorksheet.Cells[ren, colVentasMostrador] = i;
                colVentasMostrador++;
                xlWorksheet.Cells[ren, colVentasReparto] = i;
                colVentasReparto++;
                //ADDED by LEO 20190121
                xlWorksheet.Cells[ren, colOrdenesRestaurante] = i;
                colOrdenesRestaurante++;
                xlWorksheet.Cells[ren, colOrdenesMostrador] = i;
                colOrdenesMostrador++;
                xlWorksheet.Cells[ren, colOrdenesReparto] = i;
                colOrdenesReparto++;
                xlWorksheet.Cells[ren, colOrdenesRestauranteMostrador] = i;
                colOrdenesRestauranteMostrador++;
                //dateItemIni = dateItem;
                for (int j = 0; j < 7; j++)
                {
                    int numSem = i;

                    if (initialCount == 0)
                        numSem++;

                    Ventas objRes = this.getVentas(lstVentasfile, numSem, numDia, dateItem);//this.getVentas(lstVentasfile, i + 1, numDia, dateItem);

                    if (dateItemIni == null && objRes.NumDia == 1)
                    {
                        dateItemIni = objRes.FechaVenta;
                        dateItem = dateItemIni.Value;
                    }
                    if (dateItem != objfinder.DateIni && dateItemEnd != null)
                        dateItemIni = dateItemEnd.Value;

                    dateItem = dateItem.AddDays(1);

                    xlWorksheet.Cells[ren, colVentas] = (Decimal)objRes.VentasReales;
                    colVentas++;
                    totalVentasReales += (Decimal)objRes.VentasReales;

                    xlWorksheet.Cells[ren, colRegaladas] = (Decimal)objRes.VentasRegaladas;
                    colRegaladas++;
                    totalVentasRegaladas += (Decimal)objRes.VentasRegaladas;

                    xlWorksheet.Cells[ren, colOrdenes] = objRes.Ordenes;
                    colOrdenes++;
                    totalOrdenes += objRes.Ordenes;

                    xlWorksheet.Cells[ren, colOrdenesRegaladas] = objRes.OrdenesRegaladas;
                    colOrdenesRegaladas++;
                    totalOrdenesRegaladas += objRes.OrdenesRegaladas;

                    xlWorksheet.Cells[ren, colUtilizado] = (Decimal)objRes.Utilizado;
                    colUtilizado++;
                    totalUtilizado += (Decimal)objRes.Utilizado;

                    xlWorksheet.Cells[ren, colCosto] = (Decimal)objRes.VentasReales != 0 ? objRes.Utilizado / objRes.VentasReales : 0;
                    colCosto++;
                    totalCosto += (Decimal)objRes.VentasReales != 0 ? objRes.Utilizado / objRes.VentasReales : 0;

                    xlWorksheet.Cells[ren, colUtilizadoReal] = (Decimal)objRes.UtilizadoReal;
                    colUtilizadoReal++;
                    totalUtilizadoReal += (Decimal)objRes.UtilizadoReal;

                    xlWorksheet.Cells[ren, colUtilizadoRealpor] =(Decimal)objRes.VentasReales != 0 ? objRes.UtilizadoReal / objRes.VentasReales : 0; //(Decimal)objRes.CostodeComidaReal != 0 ? objRes.CostodeComidaReal : 0;
                    colUtilizadoRealpor++;
                    totalUtilizadoRealpor += (Decimal)objRes.VentasReales != 0 ? objRes.UtilizadoReal / objRes.VentasReales : 0; //(Decimal)objRes.CostodeComidaReal != 0 ? objRes.CostodeComidaReal : 0;

                    //Added by Hector Sanchez M. 20160118
                    int TotalDOrdenesMalas = objRes.TotalOrdenesMalas - objRes.OrdenesRegaladas;
                    xlWorksheet.Cells[ren, colOrdenesMalas] = TotalDOrdenesMalas;
                    colOrdenesMalas++;
                    totalOrdenesMalas += TotalDOrdenesMalas;

                    decimal TotalDVentasMalas = objRes.OrdenesMalas - objRes.VentasRegaladas;
                    xlWorksheet.Cells[ren, colVentasMalas] = TotalDVentasMalas;
                    colVentasMalas++;
                    totalVentasMalas += TotalDVentasMalas;

                    xlWorksheet.Cells[ren, colOrdenesCanceladas] = objRes.TotalOrdenesCanceladas;
                    colOrdenesCanceladas++;
                    totalOrdenesCanceladas += objRes.TotalOrdenesCanceladas;

                    xlWorksheet.Cells[ren, colVentasCanceladas] = objRes.Canceladas;
                    colVentasCanceladas++;
                    totalVentasCanceladas += objRes.Canceladas;

                    //Added by Hector Sanchez M. 2016316
                    xlWorksheet.Cells[ren, colOrdenesInternet] = objRes.OrdenesInternet;
                    colOrdenesInternet++;
                    totalOrdenesInternet += objRes.OrdenesInternet;

                    xlWorksheet.Cells[ren, colVentasInternet] = objRes.VentasInternet;
                    colVentasInternet++;
                    totalVentasInternet += objRes.VentasInternet;

                    //Added by Hector Sancez M. 20170405
                    xlWorksheet.Cells[ren, colVentasRestaurat] = objRes.VentasRestaurante;
                    colVentasRestaurat++;
                    TotalVentasRestaurant += objRes.VentasRestaurante;

                    xlWorksheet.Cells[ren, colVentasMostrador] = objRes.VentasMostrador;
                    colVentasMostrador++;
                    TotalVentasMostrador += objRes.VentasMostrador;

                    xlWorksheet.Cells[ren, colVentasReparto] = objRes.VentasReparto;
                    colVentasReparto++;
                    TotalVentasReparto += objRes.VentasReparto;
                    //ADDED by LEO 20190121
                    xlWorksheet.Cells[ren, colOrdenesRestaurante] = objRes.OrdenesRestaurante;
                    colOrdenesRestaurante++;
                    TotalOrdenesRestaurante += objRes.OrdenesRestaurante;

                    xlWorksheet.Cells[ren, colOrdenesMostrador] = objRes.OrdenesMostrador;
                    colOrdenesMostrador++;
                    TotalOrdenesMostrador += objRes.OrdenesMostrador;

                    xlWorksheet.Cells[ren, colOrdenesReparto] = objRes.OrdenesReparto;
                    colOrdenesReparto++;
                    TotalOrdenesReparto += objRes.OrdenesReparto;

                    xlWorksheet.Cells[ren, colOrdenesRestauranteMostrador] = objRes.OrdenesRestauranteMostrador;
                    colOrdenesRestauranteMostrador++;
                    TotalOrdenesRestauranteMostrador += objRes.OrdenesRestauranteMostrador;

                    numDia++;
                }
                dateItemEnd = dateItem;
                VentasFinder objFinder = new VentasFinder()
                {
                    DateIni = dateItemIni,
                    DateEnd = dateItemEnd.Value.AddDays(-1),
                    NumTienda = objTienda.Number_tienda
                };


                IList<Inventario> lstInventariosINI_END = objInventarioBLL.SelectInventarioInicialFinal(objFinder);
                IList<EntradasSalidas> lstTotalFacturas = objEntredaSalidaBLL.SelectTotalFacturas(objFinder);

                xlWorksheet.Cells[ren, colVentas] = (Decimal)totalVentasReales;
                xlWorksheet.Cells[ren, colRegaladas] = (Decimal)totalVentasRegaladas;
                xlWorksheet.Cells[ren, colOrdenes] = totalOrdenes;
                xlWorksheet.Cells[ren, colOrdenesRegaladas] = totalOrdenesRegaladas;
                xlWorksheet.Cells[ren, colUtilizado] = (Decimal)totalUtilizado;
                xlWorksheet.Cells[ren, colCosto] = (Decimal)totalVentasReales > 0 ? totalUtilizado / totalVentasReales : 0;
                xlWorksheet.Cells[ren, colUtilizadoReal] = totalUtilizadoReal;//GetUtilizadoReal(lstTotalFacturas, lstInventariosINI_END);//(Decimal)((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final));
                xlWorksheet.Cells[ren, colUtilizadoRealpor] = totalUtilizadoRealpor / 7;//(Decimal)totalVentasReales > 0 ? ((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / totalVentasReales : 0;
                //Added by Hector Sanchez M. 20160118
                xlWorksheet.Cells[ren, colOrdenesMalas] = totalOrdenesMalas;
                xlWorksheet.Cells[ren, colVentasMalas] = totalVentasMalas;
                xlWorksheet.Cells[ren, colOrdenesCanceladas] = totalOrdenesCanceladas;
                xlWorksheet.Cells[ren, colVentasCanceladas] = totalVentasCanceladas;
                //Added by Hector Sanchez M. 20160316
                xlWorksheet.Cells[ren, colOrdenesInternet] = totalOrdenesInternet;
                xlWorksheet.Cells[ren, colVentasInternet] = totalVentasInternet;
                //Added by Hector Sanchez M. 20170405
                xlWorksheet.Cells[ren, colVentasRestaurat] = TotalVentasRestaurant;
                xlWorksheet.Cells[ren, colVentasMostrador] = TotalVentasMostrador;
                xlWorksheet.Cells[ren, colVentasReparto] = TotalVentasReparto;
                //ADDED by LEO 20190121
                xlWorksheet.Cells[ren, colOrdenesRestaurante] = TotalOrdenesRestaurante;
                xlWorksheet.Cells[ren, colOrdenesMostrador] = TotalOrdenesMostrador;
                xlWorksheet.Cells[ren, colOrdenesReparto] = TotalOrdenesReparto;
                xlWorksheet.Cells[ren, colOrdenesRestauranteMostrador] = TotalOrdenesRestauranteMostrador;
                numDia = 1;
                colVentas = 1;
                colRegaladas = 11;
                colOrdenes = 21;
                colOrdenesRegaladas = 31;
                colUtilizado = 41;
                colCosto = 51;
                colUtilizadoReal = 61;
                colUtilizadoRealpor = 71;
                //Added by Hector Sanchez M. 20160118
                colOrdenesMalas = 81;
                colVentasMalas = 91;
                colOrdenesCanceladas = 101;
                colVentasCanceladas = 111;
                //Added by Hector Sanchez M. 20160316
                colOrdenesInternet = 121;
                colVentasInternet = 131;
                //Added by Hector Sanchez M. 20170405
                colVentasRestaurat = 141;
                colVentasMostrador = 151;
                colVentasReparto = 161;
                //ADDED by LEO 20190121
                colOrdenesRestaurante = 171;
                colOrdenesMostrador = 181;
                colOrdenesReparto = 191;
                colOrdenesRestauranteMostrador = 201;
                ren++;
                totalVentasReales = 0;
                totalVentasRegaladas = 0;
                totalOrdenes = 0;
                totalOrdenesRegaladas = 0;
                totalUtilizado = 0;
                totalCosto = 0;
                totalUtilizadoReal = 0;
                totalUtilizadoRealpor = 0;
                //Added by Hector Sanchez M. 20160118
                totalOrdenesMalas = 0;
                totalVentasMalas = 0;
                totalOrdenesCanceladas = 0;
                totalVentasCanceladas = 0;
                //Added by Hector Sanchez M. 20160316
                totalOrdenesInternet = 0;
                totalVentasInternet = 0;
                //Added by Hector Sanchez M. 20170405
                TotalVentasRestaurant = 0;
                TotalVentasMostrador = 0;
                TotalVentasReparto = 0;
                //ADDED by LEO 20190121
                TotalOrdenesRestaurante = 0;
                TotalOrdenesMostrador = 0;
                TotalOrdenesReparto = 0;
                TotalOrdenesRestauranteMostrador = 0;
            }

            Excel.Range rangeVentasPer = xlWorksheet.Range["AZ7", "BG59"];
            rangeVentasPer.NumberFormat = "###,##0.00%";
            rangeVentasPer = xlWorksheet.Range["BT7", "CA59"];
            rangeVentasPer.NumberFormat = "###,##0.00%";
            Excel.Range rangeVentasVal = xlWorksheet.Range["B7", "I59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["L7", "S59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["AP7", "AW59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["BJ7", "BQ59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            //Added by Hector Sanchez M. 20160119
            rangeVentasVal = xlWorksheet.Range["CN7", "CU59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["DH7", "DO59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            //Added by Hector Sanchez M. 20160316
            rangeVentasVal = xlWorksheet.Range["EB7", "Ei59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            //Added by Hector Sanchez M. 20170405
            rangeVentasVal = xlWorksheet.Range["EL7", "ES59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["EV7", "FC59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["FF7", "FM59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            //ADDED by LEO 20190121 
            rangeVentasVal = xlWorksheet.Range["FP7", "FW59"];
            rangeVentasVal.NumberFormat = "0";
            rangeVentasVal = xlWorksheet.Range["FY7", "GG59"];
            rangeVentasVal.NumberFormat = "0";
            rangeVentasVal = xlWorksheet.Range["GJ7", "GQ59"];
            rangeVentasVal.NumberFormat = "0";
            rangeVentasVal = xlWorksheet.Range["GS7", "HA7"];
            rangeVentasVal.NumberFormat = "0";


            Excel.Range head = xlWorksheet.Range["A4", "I4"];
            head.Merge();
            head.Value = "VENTAS REALES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["K4", "S4"];
            head.Merge();
            head.Value = "REGALADAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["U4", "AC4"];
            head.Merge();
            head.Value = "ORDENES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AE4", "AM4"];
            head.Merge();
            head.Value = "ORDENES REGALADAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AO4", "AW4"];
            head.Merge();
            head.Value = "UTILIZADO IDEAL";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AY4", "BG4"];
            head.Merge();
            head.Value = "COSTO DE COMIDA IDEAL";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["BI4", "BQ4"];
            head.Merge();
            head.Value = "UTILIZADO REAL";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


            head = xlWorksheet.Range["BS4", "CA4"];
            head.Merge();
            head.Value = "COSTO DE COMIDA REAL";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Added by Hector Sanchez M. 20160118
            head = xlWorksheet.Range["CC4", "CK4"];
            head.Merge();
            head.Value = "ORDENES MALAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["CM4", "CU4"];
            head.Merge();
            head.Value = "VENTAS MALAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["CW4", "DE4"];
            head.Merge();
            head.Value = "ORDENES CANCELADAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["DG4", "DO4"];
            head.Merge();
            head.Value = "VENTAS CANCELADAS";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Added by Hector Sanchez M. 20160316
            head = xlWorksheet.Range["DQ4", "DY4"];
            head.Merge();
            head.Value = "ORDENES INTERNET";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["EA4", "EI4"];
            head.Merge();
            head.Value = "VENTAS INTERNET";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Added by Hector Sanchez M. 20170405
            head = xlWorksheet.Range["EK4", "ES4"];
            head.Merge();
            head.Value = "VENTAS RESTAURANT";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["EV4", "FC4"];
            head.Merge();
            head.Value = "VENTAS MOSTRADOR";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["FF4", "FM4"];
            head.Merge();
            head.Value = "VENTAS REPARTO";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //ADDED by LEO 20190121
            head = xlWorksheet.Range["FO4", "FW4"];
            head.Merge();
            head.Value = "ORDENES RESTAURANT";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["FY4", "GG4"];
            head.Merge();
            head.Value = "ORDENES MOSTRADOR";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["GI4", "GQ4"];
            head.Merge();
            head.Value = "ORDENES REPARTO";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            head = xlWorksheet.Range["GS4", "HA4"];
            head.Merge();
            head.Value = "ORDENES RESTAURANT Y MOSTRADOR";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;



            releaseObject(xlWorksheet);
        }

        public void CreatedContentFileContabilidadDPIntrucciones(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            System.Drawing.ColorConverter cc = new System.Drawing.ColorConverter();
            xlWorksheet.Tab.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#002060"));
            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Application.ActiveWindow.SplitRow = 3;
            xlWorksheet.Application.ActiveWindow.SplitColumn = 1;
            xlWorksheet.Application.ActiveWindow.FreezePanes = true;
            int totalSemanas = objAnioBLL.TotalWeekForYear(Year);//((objfinder.DateEnd.Value - objfinder.DateIni.Value).Days + 1) / 7;
            int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            //DateTime dateItem = objfinder.DateIni.Value;
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            Excel.Range columna = xlWorksheet.Range["A1", "L1"];
            columna.RowHeight = 21;
            columna = xlWorksheet.Range["A2", "L2"];
            columna.RowHeight = 6.75;
            columna = xlWorksheet.Range["A3", "L3"];
            columna.RowHeight = 4.5;
            columna = xlWorksheet.Range["A4", "L4"];
            columna.RowHeight = 11.25;
            columna = xlWorksheet.Range["A1", "A23"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["A5", "A5"];
            columna.RowHeight = 6;
            columna = xlWorksheet.Range["A6", "L23"];
            columna.RowHeight = 13.5;
            columna = xlWorksheet.Range["A1", "L2"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#005B82"));
            columna = xlWorksheet.Range["A4", "L4"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#44546A"));
            columna = xlWorksheet.Range["A8", "L8"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#00B0F0"));
            #region Llenado de encabezado
            xlWorksheet.Cells[1, 1] = "            Dominos Pizza México ";
            xlWorksheet.Cells[4,1] = "'Instrucciones";
            xlWorksheet.Cells[6,1] = "Regla";
            xlWorksheet.Cells[6,3] = "No agregar renglones, derivado a una óptima consolidación a Dominos Pizza Internacional";
            xlWorksheet.Cells[8,1] = "'Pestaña";
            xlWorksheet.Cells[9,1] = "Glosario";
            xlWorksheet.Cells[10,1] = "Ene";
            xlWorksheet.Cells[11,1] = "Feb";
            xlWorksheet.Cells[12,1] = "Mar";
            xlWorksheet.Cells[13,1] = "Abr";
            xlWorksheet.Cells[14,1] = "May";
            xlWorksheet.Cells[15,1] = "Jun";
            xlWorksheet.Cells[16,1] = "Jul";
            xlWorksheet.Cells[17,1] = "Ago";
            xlWorksheet.Cells[18,1] = "Sep";
            xlWorksheet.Cells[19,1] = "Oct";
            xlWorksheet.Cells[20,1] = "Nov";
            xlWorksheet.Cells[21,1] = "Dic";
            xlWorksheet.Cells[23,1] = "Adicional";
            xlWorksheet.Cells[9,2] = "1";
            xlWorksheet.Cells[9,3] = "Descripción y detalle de las cuentas del P&L";
            for (int i = 10; i < 22; i++)
            {
                xlWorksheet.Cells[i,2] = (i - 8).ToString();
                xlWorksheet.Cells[i,3] = "Se deberán llenar las cuentas del glosario en miles de pesos MXN por cada una de las tiendas ";
            }
            xlWorksheet.Cells[23,3] = "Cualquier duda y/o comentario favor de contactarnos directamente: mario.cercado@alsea.com.mx | fernando.colin@alsea.com.mx | hugo.fernandez@asea.com.mx";
            #endregion
            #region Formato de celdas
            columna = xlWorksheet.Range["B9", "B21"];
            columna.Font.Bold = true;
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            columna = xlWorksheet.Range["A1", "L4"];
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            columna = xlWorksheet.Range["A8", "L8"];
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            #endregion
            releaseObject(xlWorksheet);
        }

        public IList<SalesLastYear> SelectSalesLastYearFirst(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectSalesLastYearFirst(param);
        }

        public IList<SalesLastYear> SelectSalesLastYearSecond(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectSalesLastYearSecond(param);
        }

        //ADDED  AT 20150811
        //GET´S  ALL TRANSACTIONS
        public IList<DepositoYTransacciones> SelectDepositosYTransacciones(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectDepositosYTransacciones(param);
        }


       
        public IList<Ventas> SelectMasterSales(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectMasterSales(param);
        }

       
     


        //Added by Hector Sanchez M. 20160127
        private Decimal GetUtilizadoReal(IList<EntradasSalidas> lstTotalFacturas, IList<Inventario> lstInventariosINI_END)
        {
            try
            {
                if (lstInventariosINI_END.Count > 1)
                {
                    Decimal InventarioInicial =(lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial);
                    Decimal InventarioFinal = lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final;

                    Decimal TotalUtilizado = 0;

                    if (InventarioInicial > InventarioFinal)
                        TotalUtilizado = InventarioInicial - InventarioFinal;
                    else
                        TotalUtilizado = InventarioFinal - InventarioInicial;

                    return TotalUtilizado;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                string e = ex.StackTrace;

                return 0;
            }
        }

        //Added by Hector Sanchez M. 20161207
        private Ventas SelectOrderInternet(VentasFinder param)
        {
            VentaDAL dal = new VentaDAL();
            return dal.SelectOrderInternet(param);
        }

        public string GenerateFileOrdersInternet(VentasFinder param, HttpServerUtility server)
        {
            #region propiedades excel
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            string nombreArchivo;
            #endregion

            IList<int> lstNumberWeek = new List<int>();
            IList<Tienda> lstTiendas = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            AnioBLL objAnioBLL = new AnioBLL();
            Ventas objVentas = new Ventas();

            if (xlApp != null)
            {
                Excel.Worksheet xlWorksheet = xlWorkBook.Worksheets.Add();
                xlWorksheet.Name = "Total Ordenes Internet";

                lstNumberWeek = objAnioBLL.GetNumberWeekByRangeDate(param.DateIni.Value, param.DateEnd.Value);

                Tienda TiendaFinder = new Tienda()
                {
                    Ubicacion = param.UbicacionTienda,
                    Tipo = param.TipoTienda
                };

                lstTiendas = objTiendaBLL.SelectTiendas(TiendaFinder);

                int col = 1;
                int row = 6;

                xlWorksheet.Cells[row, col] = "TIENDA";
                col++;

                for (int i = 0; i < lstNumberWeek.Count; i++)
                {
                    xlWorksheet.Cells[row, col + i] = "# " + lstNumberWeek[i];
                }

                xlWorksheet.Cells[row - 1, col] = "NUMERO SEMANA";

                col = 1;
                row = 7;

                for (int j = 0; j < lstTiendas.Count; j++)
                {
                    xlWorksheet.Cells[row + j, col] = lstTiendas[j].Number_tienda;
                }

                col = 2;
                row = 7;

                int TOI = 0;

                for (int CN = 0; CN < lstNumberWeek.Count; CN++)
                {
                    for (int CT = 0; CT < lstTiendas.Count; CT++)
                    {
                        param.NumTienda = lstTiendas[CT].Number_tienda;
                        param.NumeroSemana = lstNumberWeek[CN];

                        objVentas = SelectOrderInternet(param);

                        if (objVentas != null)
                            TOI = objVentas.OrdenesInternet;
                        else
                            TOI = 0;

                        xlWorksheet.Cells[row + CT, col + CN] = TOI;
                    }
                }

                releaseObject(xlWorksheet);
            }

            nombreArchivo = "OrdenesInternet.xlsx";
            if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
            {
                File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
            }
            xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            return nombreArchivo;
        }

        //Added by Hector Sanchez M. - 20170524
        public decimal SelectSalesLastYearOnLine(InfoTiempoReal param)
        {
            VentaDAL dal = new VentaDAL();

            return dal.SelectSalesLastYearOnLine(param);
        }

        //Added by Hector Sanchez M. - 20170725
        public void GenerateContentFileByWeek(Excel.Worksheet ExcelSheet, VentasFinder objVentasFinder, string NumberStore, int NumWeek, bool ByRegion)
        {
            EntradaSalidaBLL objEntradaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            VentasFinder objVentasFinderFac = new VentasFinder();
            IList<Ventas> lstVentas = new List<Ventas>();

            DateTime dateItem = objVentasFinder.DateIni.Value;
            DateTime? dateItemIni = null, dateItemEnd = null;

            if (!ByRegion)
                lstVentas = SelectMasterSales(objVentasFinder);
            else
                lstVentas = SelectVentasGratisTotal(objVentasFinder);

            int colVentas = 2;
            int colRegaladas = 12;
            int colOrdenes = 22;
            int colOrdenesRegaladas = 32;
            int colUtilizado = 42;
            int colCosto = 52;
            int colUtilizadoReal = 62;
            int colUtilizadoRealpor = 72;
            int colOrdenesMalas = 82;
            int colVentasMalas = 92;
            int colOrdenesCanceladas = 102;
            int colVentasCanceladas = 112;
            int colOrdenesInternet = 122;
            int colVentasInternet = 132;
            int colVentasRestaurat = 142;
            int colVentasMostrador = 152;
            int colVentasReparto = 162;
            int colOrdenesRestaurante = 172;
            int colOrdenesMostrador = 182;
            int colOrdenesReparto = 192;
            int colOrdenesRestauranteMostrador = 202;

            Decimal totalVentasReales = 0, totalVentasRegaladas = 0, totalOrdenes = 0, totalOrdenesRegaladas = 0;
            Decimal totalUtilizado = 0, totalCosto = 0;
            Decimal totalUtilizadoReal = 0;
            Decimal totalUtilizadoRealpor = 0;
            Decimal totalOrdenesMalas = 0;
            Decimal totalVentasMalas = 0;
            Decimal totalOrdenesCanceladas = 0;
            Decimal totalVentasCanceladas = 0;
            Decimal totalOrdenesInternet = 0;
            Decimal totalVentasInternet = 0;
            Decimal TotalVentasRestaurant = 0;
            Decimal TotalVentasMostrador = 0;
            Decimal TotalVentasReparto = 0;
            Decimal TotalOrdenesReparto = 0;
            Decimal TotalOrdenesMostrador = 0;
            Decimal TotalOrdenesRestaurante = 0;
            Decimal TotalOrdenesRestauranteMostrador = 0;

            int InitRow = 7 + NumWeek;
            int count = 0;

            foreach (Ventas objVentas in lstVentas)
            {
                ExcelSheet.Cells[InitRow, colVentas] = (decimal)objVentas.VentasReales;
                colVentas++;
                totalVentasReales += objVentas.VentasReales;

                ExcelSheet.Cells[InitRow, colRegaladas] = (decimal)objVentas.VentasRegaladas;
                colRegaladas++;
                totalVentasRegaladas += objVentas.VentasRegaladas;

                ExcelSheet.Cells[InitRow, colOrdenes] = objVentas.Ordenes;
                colOrdenes++;
                totalOrdenes += objVentas.Ordenes;

                ExcelSheet.Cells[InitRow, colOrdenesRegaladas] = objVentas.OrdenesRegaladas;
                colOrdenesRegaladas++;
                totalOrdenesRegaladas += objVentas.OrdenesRegaladas;

                ExcelSheet.Cells[InitRow, colUtilizado] = objVentas.Utilizado;
                colUtilizado++;
                totalUtilizado += objVentas.Utilizado;

                ExcelSheet.Cells[InitRow, colCosto] = (Decimal)objVentas.VentasReales != 0 ? objVentas.Utilizado / objVentas.VentasReales : 0;
                colCosto++;
                totalCosto += (Decimal)objVentas.VentasReales != 0 ? objVentas.Utilizado / objVentas.VentasReales : 0;

                ExcelSheet.Cells[InitRow, colUtilizadoReal] = objVentas.UtilizadoReal;
                colUtilizadoReal++;
                totalUtilizadoReal += objVentas.UtilizadoReal;

                ExcelSheet.Cells[InitRow, colUtilizadoRealpor] = (Decimal)objVentas.VentasReales != 0 ? objVentas.UtilizadoReal / objVentas.VentasReales : 0;
                colUtilizadoRealpor++;
                totalUtilizadoRealpor += (Decimal)objVentas.VentasReales != 0 ? objVentas.UtilizadoReal / objVentas.VentasReales : 0;

                int TotalDOrdenesMalas = objVentas.TotalOrdenesMalas - objVentas.OrdenesRegaladas;
                ExcelSheet.Cells[InitRow, colOrdenesMalas] = TotalDOrdenesMalas;
                colOrdenesMalas++;
                totalOrdenesMalas += TotalDOrdenesMalas;

                decimal TotalDVentasMalas = objVentas.OrdenesMalas - objVentas.VentasRegaladas;
                ExcelSheet.Cells[InitRow, colVentasMalas] = TotalDVentasMalas;
                colVentasMalas++;
                totalVentasMalas += TotalDVentasMalas;

                ExcelSheet.Cells[InitRow, colOrdenesCanceladas] = objVentas.TotalOrdenesCanceladas;
                colOrdenesCanceladas++;
                totalOrdenesCanceladas += objVentas.TotalOrdenesCanceladas;

                ExcelSheet.Cells[InitRow, colVentasCanceladas] = objVentas.Canceladas;
                colVentasCanceladas++;
                totalVentasCanceladas += objVentas.Canceladas;

                ExcelSheet.Cells[InitRow, colOrdenesInternet] = objVentas.OrdenesInternet;
                colOrdenesInternet++;
                totalOrdenesInternet += objVentas.OrdenesInternet;

                ExcelSheet.Cells[InitRow, colVentasInternet] = objVentas.VentasInternet;
                colVentasInternet++;
                totalVentasInternet += objVentas.VentasInternet;

                ExcelSheet.Cells[InitRow, colVentasRestaurat] = objVentas.VentasRestaurante;
                colVentasRestaurat++;
                TotalVentasRestaurant += objVentas.VentasRestaurante;

                ExcelSheet.Cells[InitRow, colVentasMostrador] = objVentas.VentasMostrador;
                colVentasMostrador++;
                TotalVentasMostrador += objVentas.VentasMostrador;

                ExcelSheet.Cells[InitRow, colVentasReparto] = objVentas.VentasReparto;
                colVentasReparto++;
                TotalVentasReparto += objVentas.VentasReparto;

                //ADDED by LEO 20190121
                ExcelSheet.Cells[InitRow, colOrdenesRestaurante] = objVentas.OrdenesRestaurante;
                colOrdenesRestaurante++;
                TotalOrdenesRestaurante += objVentas.OrdenesRestaurante;

                ExcelSheet.Cells[InitRow, colOrdenesMostrador] = objVentas.OrdenesMostrador;
                colOrdenesMostrador++;
                TotalOrdenesMostrador += objVentas.OrdenesMostrador;

                ExcelSheet.Cells[InitRow, colOrdenesReparto] = objVentas.OrdenesReparto;
                colOrdenesReparto++;
                TotalOrdenesReparto += objVentas.OrdenesReparto;

                ExcelSheet.Cells[InitRow, colOrdenesRestauranteMostrador] = objVentas.OrdenesRestauranteMostrador;
                colOrdenesRestauranteMostrador++;
                TotalOrdenesRestauranteMostrador += objVentas.OrdenesRestauranteMostrador;

                
                
                count++;

                if (count == 7)
                {
                    if (dateItemIni == null && objVentas.NumDia == 1)
                    {
                        dateItemIni = objVentas.FechaVenta;
                        dateItem = dateItemIni.Value;
                    }

                    if (dateItem != objVentasFinder.DateIni && dateItemEnd != null)
                        dateItemIni = dateItemEnd.Value;

                    dateItem = dateItem.AddDays(1);
                    dateItemEnd = dateItem;

                    objVentasFinderFac.DateIni = dateItemIni;
                    objVentasFinderFac.DateEnd = dateItemEnd.Value.AddDays(-1);
                    objVentasFinderFac.NumTienda = NumberStore;

                    IList<Inventario> lstInventariosINI_END = objInventarioBLL.SelectInventarioInicialFinal(objVentasFinderFac);
                    IList<EntradasSalidas> lstTotalFacturas = objEntradaSalidaBLL.SelectTotalFacturas(objVentasFinderFac);

                    ExcelSheet.Cells[InitRow, colVentas] = (Decimal)totalVentasReales;
                    ExcelSheet.Cells[InitRow, colRegaladas] = (Decimal)totalVentasRegaladas;
                    ExcelSheet.Cells[InitRow, colOrdenes] = totalOrdenes;
                    ExcelSheet.Cells[InitRow, colOrdenesRegaladas] = totalOrdenesRegaladas;
                    ExcelSheet.Cells[InitRow, colUtilizado] = (Decimal)totalUtilizado;
                    ExcelSheet.Cells[InitRow, colCosto] = (Decimal)totalVentasReales > 0 ? totalUtilizado / totalVentasReales : 0;
                    ExcelSheet.Cells[InitRow, colUtilizadoReal] = totalUtilizadoReal;//GetUtilizadoReal(lstTotalFacturas, lstInventariosINI_END);
                    ExcelSheet.Cells[InitRow, colUtilizadoRealpor] = (Decimal)totalVentasReales > 0 ? totalUtilizadoReal / totalVentasReales : 0; //((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / totalVentasReales : 0;
                    ExcelSheet.Cells[InitRow, colOrdenesMalas] = totalOrdenesMalas;
                    ExcelSheet.Cells[InitRow, colVentasMalas] = totalVentasMalas;
                    ExcelSheet.Cells[InitRow, colOrdenesCanceladas] = totalOrdenesCanceladas;
                    ExcelSheet.Cells[InitRow, colVentasCanceladas] = totalVentasCanceladas;
                    ExcelSheet.Cells[InitRow, colOrdenesInternet] = totalOrdenesInternet;
                    ExcelSheet.Cells[InitRow, colVentasInternet] = totalVentasInternet;
                    ExcelSheet.Cells[InitRow, colVentasRestaurat] = TotalVentasRestaurant;
                    ExcelSheet.Cells[InitRow, colVentasMostrador] = TotalVentasMostrador;
                    ExcelSheet.Cells[InitRow, colVentasReparto] = TotalVentasReparto;
                    //ADDED by LEO 20190121
                    ExcelSheet.Cells[InitRow, colOrdenesRestaurante] = TotalOrdenesRestaurante;
                    ExcelSheet.Cells[InitRow, colOrdenesMostrador] = TotalOrdenesMostrador;
                    ExcelSheet.Cells[InitRow, colOrdenesReparto] = TotalOrdenesReparto;
                    ExcelSheet.Cells[InitRow, colOrdenesRestauranteMostrador] = TotalOrdenesRestauranteMostrador;

                    colVentas = 2;
                    colRegaladas = 12;
                    colOrdenes = 22;
                    colOrdenesRegaladas = 32;
                    colUtilizado = 42;
                    colCosto = 52;
                    colUtilizadoReal = 62;
                    colUtilizadoRealpor = 72;
                    colOrdenesMalas = 82;
                    colVentasMalas = 92;
                    colOrdenesCanceladas = 102;
                    colVentasCanceladas = 112;
                    colOrdenesInternet = 122;
                    colVentasInternet = 132;
                    colVentasRestaurat = 142;
                    colVentasMostrador = 152;
                    colVentasReparto = 162;
                    colOrdenesRestaurante = 172;
                    colOrdenesMostrador = 182;
                    colOrdenesReparto = 192;
                    colOrdenesRestauranteMostrador = 202;

                    InitRow++;

                    totalVentasReales = 0;
                    totalVentasRegaladas = 0;
                    totalOrdenes = 0;
                    totalOrdenesRegaladas = 0;
                    totalUtilizado = 0;
                    totalCosto = 0;
                    totalUtilizadoReal = 0;
                    totalUtilizadoRealpor = 0;
                    totalOrdenesMalas = 0;
                    totalVentasMalas = 0;
                    totalOrdenesCanceladas = 0;
                    totalVentasCanceladas = 0;
                    totalOrdenesInternet = 0;
                    totalVentasInternet = 0;
                    TotalVentasRestaurant = 0;
                    TotalVentasMostrador = 0;
                    TotalVentasReparto = 0;
                    TotalOrdenesRestaurante = 0;
                    TotalOrdenesMostrador = 0;
                    TotalOrdenesReparto = 0;
                    TotalOrdenesRestauranteMostrador = 0;

                    count = 0;
               }
            }

            releaseObject(ExcelSheet);
        }

        //Added by Hector Sanchez M. - 20170726
        public Excel.Application GenerateFileSalesByWeek(int NumWeek, int Year)
        {
            Excel.Application objExcelApplication = new Excel.Application();
            Excel.Worksheet objExcelWorksheet; //= new Excel.Worksheet();
            Excel.Workbook objExcelWorkbook;
            VentasFinder objVentasFinder = new VentasFinder();
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            AnioBLL objAnioBLL = new AnioBLL();

            Semana objSemana = new Semana(NumWeek, Year);
            Semana objEndWeek = new Semana(objAnioBLL.TotalWeekForYear(Year), Year);

            objVentasFinder.DateIni = objSemana.FechaInicial;
            objVentasFinder.DateEnd = objEndWeek.FechaFinal;

            string FileName = "VentasDiarias" + Year.ToString() + ".xlsx";

            objExcelWorkbook = objExcelApplication.Workbooks.Open(HttpContext.Current.Server.MapPath(@"~\Layout\VentasDP\" + FileName),
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing);
            

            lstTienda = objTiendaBLL.SelectTiendas(new Tienda());

            foreach (Tienda objTienda in lstTienda)
            {
                objVentasFinder.NumTienda = objTienda.Number_tienda;

                objExcelWorksheet = objExcelWorkbook.Sheets[objTienda.Code];

                GenerateContentFileByWeek(objExcelWorksheet, objVentasFinder, objTienda.Number_tienda, NumWeek - 1, false);
            }

            objVentasFinder.NumTienda = string.Empty;
            objVentasFinder.UbicacionTienda = "San Luis Potosí";

            objExcelWorksheet = objExcelWorkbook.Sheets["TOTAL_SLP"];

            GenerateContentFileByWeek(objExcelWorksheet, objVentasFinder, string.Empty, NumWeek - 1, true);

            objVentasFinder.UbicacionTienda = "Tamaulipas";

            objExcelWorksheet = objExcelWorkbook.Sheets["TOTAL_TMPS"];

            GenerateContentFileByWeek(objExcelWorksheet, objVentasFinder, string.Empty, NumWeek - 1, true);

            releaseObject(objExcelWorksheet);
            releaseObject(objExcelWorkbook);

            return objExcelApplication;
        }

        //Added by Hector Sanchez M. - 20170727
        public string GenerateFileSales(int NumWeek, int Year, string Dir)
        {
            string NameFile = "VentasDiarias" + Year.ToString() + ".xlsx";

            Excel.Application objApplication = GenerateFileSalesByWeek(NumWeek, Year);
            SaveFileExcel(objApplication, HttpContext.Current.Server.MapPath(Dir));

            releaseObject(objApplication);

            return NameFile;
        }

        //Added by Hector Sanchez M. - 20170727 Obsoleto desde 20201215
        public string CreateFileSales(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName= "VentasDiarias" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            int? NumWeek = objSettingsFileSalesBLL.ValidConfigFileSales("DP", Year);

            if (NumWeek == null)
                GenerateAutomaticFile(Server, Year);
            else
                GenerateFileSales(NumWeek.Value + 1, Year, Path);


            return FileName;
        }
        //Agregados por Diego Pilar 20210328 es para obtener las contabilidad de los meses de DP
        public string CreateFileContabilidad( HttpServerUtility server)
        {
            int year = DateTime.Now.Year;
            string NameFile = "REPORTES DOMINOS "+year.ToString() +".xlsx";
            string NameLayout = "ReportesDominosLayout.xlsx";
            string strPath = server.MapPath("/Layout/VentasDP") + "/" + NameLayout;
            string strFile = server.MapPath("/indicadores") + "/" + NameFile;
            Date date = new Date();
            date.year = DateTime.Now.Year.ToString();//"2021"; //DateTime.Now.Year.ToString();
            date.month = DateTime.Now.Month.ToString();
            date.day= DateTime.Now.Day.ToString();
            Excel.Application xlApp = new Excel.Application();

            if (xlApp != null)
            {
                Excel.Workbook xlWorkbook;
                object misValue = System.Reflection.Missing.Value;

                if (File.Exists(strPath))
                {
                    xlWorkbook = xlApp.Workbooks.Open(strPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                    #region LLENADO DE LAS HOJAS DE EXCEL
                    SEF_VentasBLL BLL = new SEF_VentasBLL();
                    IList<ContabilidadDP> contabilidadDPs = new List<ContabilidadDP>();
                    contabilidadDPs= BLL.selectDPContabilidad(date);
                    // Se llena el encabezado de los meses para cambiar el año y mes para que corresponda
                    for (int i = 1; i < 13; i++)
                    {
                        CreateContenFileContabilidadEncabezado(xlWorkbook.Worksheets.get_Item(i+2),i);
                    }
                    // Se llena la informacion con el mes correspondiente  hasta el mes actual
                    for (int i = 0; i < DateTime.Now.Month; i++) //DateTime.Now.Month
                    {
                        date.month = (i + 1).ToString();
                        contabilidadDPs=BLL.selectDPContabilidad(date);
                        CreateContenFileContabilidad(xlWorkbook.Worksheets.get_Item(i + 3), i, contabilidadDPs);
                    }
                    #endregion
                    if (File.Exists(strFile))
                        File.Delete(strFile);

                    xlWorkbook.SaveAs(strFile, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    releaseObject(xlWorkbook);
                }

                releaseObject(xlApp);
            }

            return NameFile;
        }
        //Agregado por Daniel Jimenez 20201215 es una alternativa mas rapida al metodo CreateFileSales
        public string CrearArchivoVentas(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "VentasDiarias" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            generarArchivoVentas(Server, Year);           


            return FileName;
        }


        //Added by Hector Sanchez M. - 20170807
        private void SaveFileExcel(Excel.Application ExcelApplication, string Dir)
        {
            if (File.Exists(Dir))
                File.Delete(Dir);

            ExcelApplication.ActiveWorkbook.SaveAs(Dir, Excel.XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlShared, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            
            ExcelApplication.ActiveWorkbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
        }

        private void CreateContenFileContabilidadEncabezado(Excel.Worksheet objWorksheet,int mes)
        {
            int year = DateTime.Now.Year;
            #region Llenado del título dependiendo la hoja que se vaya a llenar correspondiente al mes y al año
            switch (mes)
            {
                case 1:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Jan" + year.ToString();
                    break;
                case 2:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Feb" + year.ToString();
                    break;
                case 3:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Mar" + year.ToString();
                    break;
                case 4:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Apr" + year.ToString();
                    break;
                case 5:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'May" + year.ToString();
                    break;
                case 6:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Jun" + year.ToString();
                    break;
                case 7:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Jul" + year.ToString();
                    break;
                case 8:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Aug" + year.ToString();
                    break;
                case 9:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Sep" + year.ToString();
                    break;
                case 10:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Oct" + year.ToString();
                    break;
                case 11:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Nov" + year.ToString();
                    break;
                case 12:
                    objWorksheet.Cells[1, 3] = "            Dominos Pizza México 'Dic" + year.ToString();
                    break;
            }
            #endregion
            releaseObject(objWorksheet);
        }

        private string ReturnDPcontabilidad(ContabilidadDP contabilidadDPs, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return contabilidadDPs.t11053.ToString();
                case 1:
                    return contabilidadDPs.t11028.ToString();
                case 2:
                    return contabilidadDPs.t11597.ToString();
                case 3:
                    return contabilidadDPs.t11641.ToString();
                case 4:
                    return contabilidadDPs.t11405.ToString();
                case 5:
                    return contabilidadDPs.t11544.ToString();
                case 6:
                    return contabilidadDPs.t11488.ToString();
                case 7:
                    return contabilidadDPs.t11911.ToString();
                case 8:
                    return contabilidadDPs.t11982.ToString();
                case 9:
                    return contabilidadDPs.t11406.ToString();
                case 10:
                    return contabilidadDPs.t11842.ToString();
                case 11:
                    return contabilidadDPs.t11288.ToString();
                case 12:
                    return contabilidadDPs.t11220.ToString();
                case 13:
                    return contabilidadDPs.t11863.ToString();
                case 14:
                    return contabilidadDPs.t11876.ToString();
                case 15:
                    return contabilidadDPs.t12390.ToString();
                case 16:
                    return contabilidadDPs.t11456.ToString();
                case 17:
                    return contabilidadDPs.t11101.ToString();
                case 18:
                    return contabilidadDPs.t11127.ToString();
                case 19:
                    return contabilidadDPs.t11181.ToString();
                case 20:
                    return contabilidadDPs.t11214.ToString();
                case 21:
                    return contabilidadDPs.t11443.ToString();
                case 22:
                    return contabilidadDPs.t11450.ToString();
                case 23:
                    return contabilidadDPs.t11484.ToString();
                case 24:
                    return contabilidadDPs.t11490.ToString();
                case 25:
                    return contabilidadDPs.t11497.ToString();
                case 26:
                    return contabilidadDPs.t11598.ToString();
                case 27:
                    return contabilidadDPs.t11978.ToString();
                case 28:
                    return contabilidadDPs.t12361.ToString();
                default:
                    return "";
            }
        }
        private void CreateContenFileContabilidad(Excel.Worksheet objWorksheet, int mes,IList<ContabilidadDP> contabilidadDPs)
        {
            int posicioncell = 7;
            #region Llenado de los valores del mes
            for (int i = 0; i < 21; i++)
            {
                for(int j = 0; j < 29; j++)
                {
                    objWorksheet.Cells[posicioncell, j + 5] = ReturnDPcontabilidad(contabilidadDPs[i], j);
                }
                #region cambio de celdas para el llenado correcto de las celdas
                if (posicioncell == 7)
                {
                    posicioncell += 2;
                }
                else if(posicioncell == 9)
                {
                    posicioncell += 1;
                }
                else if(posicioncell==10)
                {
                    posicioncell += 4;
                }
                else if(posicioncell>=14 && posicioncell<23)
                {
                    posicioncell += 1;
                }
                else if(posicioncell==23)
                {
                    posicioncell += 2;
                }    
                else if (posicioncell >= 25 && posicioncell < 31)
                {
                    posicioncell += 1;
                }
                else if(posicioncell==31)
                {
                    posicioncell += 7;
                }
                #endregion
            }

            #endregion
            releaseObject(objWorksheet);
        }

        //Added by Leo Mtz - 20190912
        public String GenerateInventoryDayBefore(VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            string fecharArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objfinder.UbicacionTienda,
                    Tipo = objfinder.TipoTienda

                };

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                foreach (Tienda item in lstTiendas)
                {

                    this.CreatesheetInventoryDayBefore(xlWorkBook.Worksheets.Add(), objfinder, item, Year);

                }
                /*Tienda objtienda = new Tienda()   //TOTAL IN CASE OF NEED
                {
                    Code = "ALL",
                    Number_tienda = string.Empty
                };
                this.CreatesheetResumenVentasV2(xlWorkBook.Worksheets.Add(), objfinder, objtienda, Year);*/



                DateTime dateAux = DateTime.Now;


                nombreArchivo = dateAux.ToString("ddMMyyyy_HHmm") + "_UsodeInventario.xlsx";
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                //releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }

        public void CreatesheetInventoryDayBefore(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();

            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Cells[1, 1] = "CODIGO INVENTARIO";
            xlWorksheet.Cells[1, 2] = "USO PORCION ACTUAL";
            xlWorksheet.Cells[1, 3] = "UNIDAD";
            xlWorksheet.Cells[1, 4] = "CENTRO DE COSTOS";
            xlWorksheet.Cells[1, 5] = "DESCRIPCION";

            int TW = objAnioBLL.TotalWeekForYear(Year);

            objfinder.NumTienda = objTienda.Number_tienda;
            IList<DailyInventoryExtracts> lstDailyInventory = this.SelectUseInventory(objfinder);
            int it = 2;
            foreach (DailyInventoryExtracts item in lstDailyInventory)
            {
                
                xlWorksheet.Cells[it, 1] = item.Inventory_Code;
                xlWorksheet.Cells[it, 2] = (Double)item.Actual_Usage;
                xlWorksheet.Cells[it, 3] = item.Count_Unit;
                xlWorksheet.Cells[it, 4] = item.Location_Code;
                xlWorksheet.Cells[it, 5] = item.System_Date.ToString("dd_MM_yyyy");

                it++;
            }
            Excel.Range columna = xlWorksheet.Range["B2", "B" + (lstDailyInventory.Count + 1).ToString()];
            columna.NumberFormat = "#,##0.00";
            
            columna = xlWorksheet.Range["A1", "F" + (lstDailyInventory.Count + 1).ToString()];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            columna = xlWorksheet.Range["A2", "A2"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 17;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 18;


            releaseObject(xlWorksheet);
        }
    }
}