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
    public class Ventas_LunesBLL
    {
        /*public String GenerateVentas_Prueba(VentasFinder objfinder, HttpServerUtility server, int Year)
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

                    this.CreatesheetVentas_Prueba(xlWorkBook.Worksheets.Add(), objfinder, item, Year);

                }
                Tienda objtienda = new Tienda()
                {
                    Code = "ALL",
                    Number_tienda = string.Empty
                };
                this.CreatesheetVentas_Prueba(xlWorkBook.Worksheets.Add(), objfinder, objtienda, Year);  



                DateTime dateAux = DateTime.Now;

                if (objfinder.DateIni != null)
                    fecharArchivo = objfinder.DateIni.Value.Year.ToString() + objfinder.DateIni.Value.Month.ToString() + objfinder.DateIni.Value.Day.ToString();
                else
                    fecharArchivo = dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString();

                nombreArchivo = fecharArchivo + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasLunes.xlsx"; //dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString() + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasResumen.xlsx";
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                //releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }

        public void CreatesheetVentas_Prueba(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            Decimal totalVentasReales2 = 0;
            String TiendaTemp;
            

            xlWorksheet.Name = objTienda.Code;
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "NOMBRE TIENDA";
            xlWorksheet.Cells[1, 3] = "FECHA";
            xlWorksheet.Cells[1, 4] = "DÍA";
            xlWorksheet.Cells[1, 5] = "NUMERO DE SEMANA";
            xlWorksheet.Cells[1, 6] = "VENTAS REALES";
            xlWorksheet.Cells[1, 7] = "TOTAL POR TIENDA";            

            int TW = objAnioBLL.TotalWeekForYear(Year);

            objfinder.NumTienda = objTienda.Number_tienda;
            IList<Ventas_Lunes> lstResumenVentas = this.SelectVentasLunes(objfinder);
            int it = 2;
            int contador = 0;
            foreach (Ventas_Lunes item in lstResumenVentas)
            {
                int numSem = item.NumSemana2;

                if (TW == 53)
                    numSem--;
                
                
                    xlWorksheet.Cells[it, 1] = item.Tienda2;
                    xlWorksheet.Cells[it, 2] = item.Nombre_tienda2;
                    xlWorksheet.Cells[it, 3] = item.FechaVenta2;//.ToShortDateString();
                    xlWorksheet.Cells[it, 4] = item.Dia2;
                    xlWorksheet.Cells[it, 5] = numSem;//item.NumeroSemana;
                    xlWorksheet.Cells[it, 6] = item.VentasReales2;


                    TiendaTemp = item.Tienda2;
                
                    totalVentasReales2 += (Decimal)item.VentasReales2;
                    it++;                        

                    
                    if(contador+1 < lstResumenVentas.Count)
                    {
                        if (lstResumenVentas[contador + 1].Tienda2 != TiendaTemp)   //Arroja el total dependiendo del numero de dias
                        {
                            xlWorksheet.Cells[it-1, 7] = totalVentasReales2;
                            totalVentasReales2 = 0;
                        }
                    }
                   
                    contador++;
               
            }
            xlWorksheet.Cells[it, 7] = (Decimal)totalVentasReales2;

            Excel.Range columna = xlWorksheet.Range["F2", "G" + (lstResumenVentas.Count + 2).ToString()]; 
            columna.NumberFormat = "$ #,##0.00";
            
            columna = xlWorksheet.Range["A1", "O" + (lstResumenVentas.Count + 2).ToString()];
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
        }*/

        public IList<Ventas_Lunes> SelectVentasLunes2(VentasFinder param)
        {
            Ventas_LunesDAL DAL = new Ventas_LunesDAL();
            return DAL.SelectVentasLunes2(param);
        }

        public IList<Ventas_Lunes> SelectVentasLunesTotal2(VentasFinder param)
        {
            Ventas_LunesDAL DAL = new Ventas_LunesDAL();
            return DAL.SelectVentasLunesTotal2(param);
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

        

        private VentasFinder GenerateFilter(int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            DateTime fechaInicial = new DateTime(Year, 1, 1);
            DateTime fechaFinal = new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12));
            int semIni = 1;
            int semFin = objAnioBLL.TotalWeekForYear(Year);

            if (semFin == 53)
            {
                //semIni--;
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
        

        #region Matriz como el ventas diarias
        public string GenerateVentas_Prueba(HttpServerUtility Server, int Year)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "VentasLunes" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            int? NumWeek = objSettingsFileSalesBLL.ValidConfigFileSales("DP", Year);

            //if (NumWeek == null)
            GenerateAutomaticFile(Server, Year);
            /*else
                GenerateFileSales(NumWeek.Value + 1, Year, Path); */


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
                //semIni--;
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

                #region TAMAULIPAS ALL
                objfinder.NumTienda = "";
                objfinder.UbicacionTienda = "Tamaulipas";
                IList<Ventas_Lunes> lstVentasfileALLSLP = this.SelectVentasLunesTotal2(objfinder);
                Tienda objTiendaSLP = new Tienda()
                {
                    Code = "TOTAL_TMPS",
                    Number_tienda = string.Empty
                };
                if (lstVentasfileALLSLP.Count > 0)
                {
                    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP, lstVentasfileALLSLP, Year);
                }
                #endregion

                #region TAMAULIPAS Each Ones
                Tienda objFinderTam = new Tienda()
                {
                    Ubicacion = objfinder.UbicacionTienda,
                    Tipo = objfinder.TipoTienda
                };
                IList<Tienda> lstTiendasTam = objTiendasBLL.SelectTiendas(objFinderTam);
                foreach (Tienda item in lstTiendasTam)
                {
                    objfinder.NumTienda = item.Number_tienda;
                    //IList<Ventas> lstVentasfile = this.SelectVentasGratis(objfinder);
                    IList<Ventas_Lunes> lstVentasfile = this.SelectVentasLunes2(objfinder);
                    if (lstVentasfile.Count > 0 && objfinder.UbicacionTienda == "Tamaulipas")
                    {

                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile, Year);
                    }
                }
                #endregion

                #region SAN LUIS POTOSI ALL
                objfinder.NumTienda = "";
                objfinder.UbicacionTienda = "San Luis Potosí";
                IList<Ventas_Lunes> lstVentasfileALL = this.SelectVentasLunesTotal2(objfinder);
                Tienda objTienda = new Tienda()
                {
                    Code = "TOTAL_SLP",
                    Number_tienda = string.Empty
                };
                if (lstVentasfileALL.Count > 0)
                {
                    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTienda, lstVentasfileALL, Year);
                }
                #endregion

                #region SAN LUIS POTOSI EACH ONES
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
                    IList<Ventas_Lunes> lstVentasfile = this.SelectVentasLunes2(objfinder);
                    if (lstVentasfile.Count > 0 && objfinder.UbicacionTienda == "San Luis Potosí")
                    {
                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile, Year);
                    }
                }
                #endregion
                

                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "VentasLunes" + anioNom + ".xlsx";
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

        public void CreatedContentFileVentas(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, IList<Ventas_Lunes> lstVentasfile, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            xlWorksheet.Name = objTienda.Code;
            int totalSemanas = objAnioBLL.TotalWeekForYear(Year);//((objfinder.DateEnd.Value - objfinder.DateIni.Value).Days + 1) / 7;
            int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            DateTime dateItem = objfinder.DateIni.Value;
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();            
            //Modified by LEO               20190121 - Added tables "Ordenes restaurante, mostrador and reparto"
            for (int i = 0; i < 10; i += 10)//for (int i = 0; i < 120; i += 10)
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
            //int colRegaladas = 11;
            int numDia = 1;
            Decimal VentasReales2 = 0;
            Decimal totalVentasReales = 0;        
            DateTime? dateItemIni = null, dateItemEnd = null;
            int initialCount = 1;

            if (totalSemanas == 53)
            {
               //initialCount = 0;
              // totalSemanas--;
            }

            for (int i = initialCount; i <= totalSemanas; i++)//for (int i = 0; i < totalSemanas; i++)
            {
                xlWorksheet.Cells[ren, colVentas] = i;
                colVentas++;
                //xlWorksheet.Cells[ren, colOrdenes] = i;
               // colOrdenes++;
               
                //dateItemIni = dateItem;
                for (int j = 0; j < 7; j++)
                {
                    int numSem = i;

                    if (initialCount == 0)
                        numSem++;

                    Ventas_Lunes objRes = this.getVentas(lstVentasfile, numSem, numDia, dateItem);//this.getVentas(lstVentasfile, i + 1, numDia, dateItem);

                    if (dateItemIni == null && objRes.NumDia2 == 1)
                    {
                        dateItemIni = objRes.FechaVenta2;
                        dateItem = dateItemIni.Value;
                    }
                    if (dateItem != objfinder.DateIni && dateItemEnd != null)
                        dateItemIni = dateItemEnd.Value;

                    dateItem = dateItem.AddDays(1);

                    //VentasReales2 = objRes.VentasConImpuesto2 - objRes.Impuesto2;
                    //xlWorksheet.Cells[ren, colVentas] = VentasReales2;
                    //colVentas++;
                    //totalVentasReales += VentasReales2;

                    xlWorksheet.Cells[ren, colVentas] = objRes.VentasReales2;
                    colVentas++;
                    totalVentasReales += objRes.VentasReales2;

                    //xlWorksheet.Cells[ren, colRegaladas] = (Decimal)objRes.VentasRegaladas;
                    //colRegaladas++;
                    //totalVentasRegaladas += (Decimal)objRes.VentasRegaladas;                    

                    objRes.VentasReales2 = 0;
                    numDia++;
                }
                dateItemEnd = dateItem;
                VentasFinder objFinder = new VentasFinder()
                {
                    DateIni = dateItemIni,
                    DateEnd = dateItemEnd.Value.AddDays(-1),
                    NumTienda = objTienda.Number_tienda
                };


                xlWorksheet.Cells[ren, colVentas] = (Decimal)totalVentasReales;
                //xlWorksheet.Cells[ren, colRegaladas] = (Decimal)totalVentasRegaladas;

                numDia = 1;
                colVentas = 1;               
                ren++;
                totalVentasReales = 0;              
            }

            Excel.Range rangeEntrega = xlWorksheet.Range["B7", "I59"];
            rangeEntrega.NumberFormat = "$ #,##0.00";
            


            Excel.Range head = xlWorksheet.Range["A4", "I4"];
            head.Merge();
            head.Value = "VENTAS REALES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["K4", "S4"];
            head.Merge();


            releaseObject(xlWorksheet);
        }

        public Ventas_Lunes getVentas(IList<Ventas_Lunes> lstVentasfile, int numSemana, int numDia, DateTime dateSearch)
        {
            Ventas_Lunes res = new Ventas_Lunes()
            {
                VentasConImpuesto2 = 0,
            };
            if (dateSearch <= DateTime.Now)
            {
                foreach (Ventas_Lunes item in lstVentasfile)
                {
                    if (item.NumSemana2 == numSemana && item.NumDia2 == numDia)
                    {
                        res = item;
                        break;
                    }
                }
            }
            return res;
        }
        #endregion


    }

}