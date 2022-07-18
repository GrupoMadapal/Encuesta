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


namespace Poleo.BLL
{
    public class VentasPruebaLinealBLL
    {
        public string CreateVentas_PruebaLineal(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "VentasPruebaLineal" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            int? NumWeek = objSettingsFileSalesBLL.ValidConfigFileSales("DP", Year);

            if (NumWeek == null)
                GenerateAutomaticFile(Server, Year);


            return FileName;
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

            return GenerateVentas_PruebaLineal(objFinder, server, Year);

        }


        public String GenerateVentas_PruebaLineal(VentasFinder objfinder, HttpServerUtility server, int Year)
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
                    IList<Ventas> lstVentasfile = this.SelectLinealSales(objfinder);
                    if (lstVentasfile.Count > 0)
                    {
                        this.CreatesheetVentas_PruebaLineal(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile, Year);
                    }
                }
                /*objfinder.NumTienda = "";
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
                 * */

                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "VentasPruebaLineal" + anioNom + ".xlsx";
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

        public void CreatesheetVentas_PruebaLineal(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            xlWorksheet.Name = objTienda.Code;
            int totalSemanas = objAnioBLL.TotalWeekForYear(Year);//((objfinder.DateEnd.Value - objfinder.DateIni.Value).Days + 1) / 7;
            int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            DateTime dateItem = objfinder.DateIni.Value;

            Decimal totalVentasReales2 = 0;
            String TiendaTemp;
            

            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "NOMBRE TIENDA";
            xlWorksheet.Cells[1, 3] = "FECHA";
            xlWorksheet.Cells[1, 4] = "DÍA";
            xlWorksheet.Cells[1, 5] = "NUMERO DE SEMANA";
            xlWorksheet.Cells[1, 6] = "VENTAS REALES";
            xlWorksheet.Cells[1, 7] = "ORDENES";
            //xlWorksheet.Cells[1, 7] = "TOTAL POR TIENDA";            

            int TW = objAnioBLL.TotalWeekForYear(Year);

            objfinder.NumTienda = objTienda.Number_tienda;//////////// CHECKING


            int it = 2;
            int contador = 1;
            int filatemp = 0;
            foreach (Ventas item in lstVentasfile)
            {
                int numSem = item.NumSemana;

                if (TW == 53)
                    numSem--;


                    xlWorksheet.Cells[it, 1] = item.Tienda;
                    xlWorksheet.Cells[it, 2] = item.Name;
                    xlWorksheet.Cells[it, 3] = item.Fecha;//.ToShortDateString();
                    xlWorksheet.Cells[it, 4] = item.Dia;
                    xlWorksheet.Cells[it, 5] = numSem;//item.NumeroSemana;
                    xlWorksheet.Cells[it, 6] = item.VentasReales;
                    xlWorksheet.Cells[it, 7] = item.Ordenes;


                    TiendaTemp = item.Tienda;   //total por semana 
                
                    //totalVentasReales2 += (Decimal)item.VentasReales2;
                    it++;


                    if (contador % 7 == 0)
                    {
                        filatemp = contador;

                        if (lstVentasfile[contador].Tienda != TiendaTemp)   //Arroja el total dependiendo del numero de dias
                        {
                            xlWorksheet.Cells[it-1, 7] = totalVentasReales2;
                            totalVentasReales2 = 0;
                        }
                    }
                   
                    contador++;
               
            }
            xlWorksheet.Cells[it, 7] = (Decimal)totalVentasReales2;

            Excel.Range columna = xlWorksheet.Range["F2", "G" + (lstVentasfile.Count + 2).ToString()]; 
            columna.NumberFormat = "$ #,##0.00";
            
            columna = xlWorksheet.Range["A1", "O" + (lstVentasfile.Count + 2).ToString()];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //CENTRADO

            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 22;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 11;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 19;
            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 16;

            columna = xlWorksheet.Range["A1", "G1"];
            columna.Font.Bold = true;
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            totalVentasReales2 = 0;
            releaseObject(xlWorksheet);
        }

        public IList<Ventas> SelectVentasPruebaLineales(VentasFinder param)
        {
            VentasPruebaLinealDAL DAL = new VentasPruebaLinealDAL();
            return DAL.SelectVentasPruebaLineales(param);
        }

        public IList<Ventas> SelectLinealSales(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectLinealSales(param);
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