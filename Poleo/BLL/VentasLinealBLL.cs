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
    public class VentasLinealBLL
    {
        public IList<Ventas> SelectLinealSales(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectLinealSales(param);
        }

        public string CreateVentas_PruebaLineal(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "VentasyOrdenes" + Year.ToString() + ".xlsx";
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


                IList<Ventas> lstLinealVentasyOrdenes = this.SelectLinealSales(objfinder); 
                xlWorksheet = xlWorkBook.Worksheets[1]; //Set the info in the first Sheet
                this.CreatesheetVentas_Lineal(xlWorksheet, lstLinealVentasyOrdenes, Year);
                        
                 
                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "VentasyOrdenes" + anioNom + ".xlsx";
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

        public void CreatesheetVentas_Lineal(Excel.Worksheet xlWorksheet, IList<Ventas> lstVentasfile, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();            

            Decimal totalVentasReales2 = 0;
            String TiendaTemp;


            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "FECHA";
            xlWorksheet.Cells[1, 3] = "ORDENES";
            xlWorksheet.Cells[1, 4] = "VENTAS REALES";

            int TW = objAnioBLL.TotalWeekForYear(Year);

            int it = 2;
            int contador = 1;
            int filatemp = 0;
            foreach (Ventas item in lstVentasfile)
            {
                int numSem = item.NumSemana;

                if (TW == 53)
                    numSem--;


                xlWorksheet.Cells[it, 1] = item.NumTienda;
                xlWorksheet.Cells[it, 2] = item.FechaVenta.ToOADate();
                xlWorksheet.Cells[it, 3] = item.Ordenes;//.ToShortDateString();
                xlWorksheet.Cells[it, 4] = (Decimal)item.VentasReales;


                TiendaTemp = item.Tienda;   //total por semana 

                //totalVentasReales2 += (Decimal)item.VentasReales2;
                it++;
                

                contador++;

            }

            Excel.Range columna = xlWorksheet.Range["D2", "D" + (lstVentasfile.Count + 2).ToString()];
            columna.NumberFormat = "$ #,##0.00";

            columna = xlWorksheet.Range["A1", "O" + (lstVentasfile.Count + 2).ToString()];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //CENTRADO
            columna = xlWorksheet.Range["B2", "B" + (lstVentasfile.Count + 1).ToString()];
            columna.NumberFormat = "dd/MM/yyyy";

            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 11;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 19;

            columna = xlWorksheet.Range["A1", "D1"];
            columna.Font.Bold = true;
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            totalVentasReales2 = 0;
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
    }
}