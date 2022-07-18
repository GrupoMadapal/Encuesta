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
    public class A_CantidadesBLL
    {
        public IList<Ventas> SelectCounts(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectCounts(param);
        }
        public IList<Ventas> SelectVentas(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentas(param);
        }
        public IList<Ventas> SelectMasterSales(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectMasterSales(param);
        }
        public IList<Ventas> SelectVentasGratisTotal(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentasGratisTotal(param);
        }


        public void DeleteExcel(String objRutaFile)
        {
            if (File.Exists(objRutaFile))
            {
                File.Delete(objRutaFile);
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
                nombreArchivo = "Cantidades_Prueba" + anioNom + ".xlsx";
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
            //Modified by LEO                        - Added tables "Counts restaurante, mostrador and reparto"
            for (int i = 0; i < 200; i += 10)//for (int i = 0; i < 170; i += 10)
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
            // ADDED
            int colOrdenesRestaurante = 171;
            int colOrdenesMostrador = 181;
            int colOrdenesReparto = 191;
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
            // ADDED
            Decimal TotalOrdenesReparto = 0;
            Decimal TotalOrdenesMostrador = 0;
            Decimal TotalOrdenesRestaurante = 0;
            DateTime? dateItemIni = null, dateItemEnd = null;
            int initialCount = 1;

            if (totalSemanas == 53)
            {
                initialCount = 0;
                totalSemanas--;
            }

            for (int i = initialCount; i <= totalSemanas; i++)//for (int i = 0; i < totalSemanas; i++) //va llenando todas las columnas con el valor de la semana en la posicion del bucle
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
                //ADDED by LEO
                xlWorksheet.Cells[ren, colOrdenesRestaurante] = i;
                colOrdenesRestaurante++;
                xlWorksheet.Cells[ren, colOrdenesMostrador] = i;
                colOrdenesMostrador++;
                xlWorksheet.Cells[ren, colOrdenesReparto] = i;
                colOrdenesReparto++;
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

                    xlWorksheet.Cells[ren, colUtilizadoRealpor] = (Decimal)objRes.VentasReales != 0 ? objRes.UtilizadoReal / objRes.VentasReales : 0;
                    colUtilizadoRealpor++;
                    totalUtilizadoRealpor += (Decimal)objRes.VentasReales != 0 ? objRes.UtilizadoReal / objRes.VentasReales : 0;

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
                    
                    //ADDED by LEO 
                    xlWorksheet.Cells[ren, colOrdenesRestaurante] = objRes.OrdenesRestaurante;
                    colOrdenesRestaurante++;
                    TotalOrdenesRestaurante += objRes.OrdenesRestaurante;

                    xlWorksheet.Cells[ren, colOrdenesMostrador] = objRes.OrdenesMostrador;
                    colOrdenesMostrador++;
                    TotalOrdenesMostrador += objRes.OrdenesMostrador;

                    xlWorksheet.Cells[ren, colOrdenesReparto] = objRes.OrdenesReparto;
                    colOrdenesReparto++;
                    TotalOrdenesReparto += objRes.OrdenesReparto;

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
                xlWorksheet.Cells[ren, colUtilizadoRealpor] = (Decimal)totalVentasReales > 0 ? totalUtilizadoReal / totalVentasReales : 0;//(Decimal)totalVentasReales > 0 ? ((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / totalVentasReales : 0;
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
                //ADDED by LEO
                xlWorksheet.Cells[ren, colOrdenesRestaurante] = TotalOrdenesRestaurante;
                xlWorksheet.Cells[ren, colOrdenesMostrador] = TotalOrdenesMostrador;
                xlWorksheet.Cells[ren, colOrdenesReparto] = TotalOrdenesReparto;
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
                //ADDED by LEO
                colOrdenesRestaurante = 171;
                colOrdenesMostrador = 181;
                colOrdenesReparto = 191;
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
                //ADDED by LEO
                TotalOrdenesRestaurante = 0;
                TotalOrdenesMostrador = 0;
                TotalOrdenesReparto = 0;
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
            //ADDED by LEO 
            rangeVentasVal = xlWorksheet.Range["FP7", "FW59"];
            rangeVentasVal.NumberFormat = "0";
            rangeVentasVal = xlWorksheet.Range["FY7", "GG59"];
            rangeVentasVal.NumberFormat = "0";
            rangeVentasVal = xlWorksheet.Range["GJ7", "GQ59"];
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

            head = xlWorksheet.Range["FO4","FW4"];
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

            releaseObject(xlWorksheet);
        }

        public string CreateFileSales(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "Cantidades_Prueba" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            int? NumWeek = objSettingsFileSalesBLL.ValidConfigFileSales("DP", Year);

            if (NumWeek == null)
                GenerateAutomaticFile(Server, Year);
            else
                GenerateFileSales(NumWeek.Value + 1, Year, Path);

            return FileName;
        }

        public string GenerateFileSales(int NumWeek, int Year, string Dir)
        {
            string NameFile = "Cantidades_Prueba" + Year.ToString() + ".xlsx";

            Excel.Application objApplication = GenerateFileSalesByWeek(NumWeek, Year);
            SaveFileExcel(objApplication, HttpContext.Current.Server.MapPath(Dir));

            releaseObject(objApplication);

            return NameFile;
        }

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

            string FileName = "Cantidades_Prueba" + Year.ToString() + ".xlsx";

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
            //ADDED by LEO
            int colOrdenesRestaurante = 172;
            int colOrdenesMostrador = 182;
            int colOrdenesReparto = 192;

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
            // ADDED
            Decimal TotalOrdenesReparto = 0;
            Decimal TotalOrdenesMostrador = 0;
            Decimal TotalOrdenesRestaurante = 0;

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

                //ADDED by LEO
                ExcelSheet.Cells[InitRow, colOrdenesRestaurante] = objVentas.OrdenesRestaurante;
                colOrdenesRestaurante++;
                TotalOrdenesRestaurante += objVentas.OrdenesRestaurante;

                ExcelSheet.Cells[InitRow, colOrdenesMostrador] = objVentas.OrdenesMostrador;
                colOrdenesMostrador++;
                TotalOrdenesMostrador += objVentas.OrdenesMostrador;

                ExcelSheet.Cells[InitRow, colOrdenesReparto] = objVentas.OrdenesReparto;
                colOrdenesReparto++;
                TotalOrdenesReparto += objVentas.OrdenesReparto;

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
                    //ADDED
                    ExcelSheet.Cells[InitRow, colOrdenesRestaurante] = TotalOrdenesRestaurante;
                    ExcelSheet.Cells[InitRow, colOrdenesMostrador] = TotalOrdenesMostrador;
                    ExcelSheet.Cells[InitRow, colOrdenesReparto] = TotalOrdenesReparto;

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
                    //ADDED by LEO
                    colOrdenesRestaurante = 172;
                    colOrdenesMostrador = 182;
                    colOrdenesReparto = 192;

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
                    //ADDED 
                    TotalOrdenesRestaurante = 0;
                    TotalOrdenesMostrador = 0;
                    TotalOrdenesReparto = 0;

                    count = 0;
                }
            }

            releaseObject(ExcelSheet);
        }

        private void SaveFileExcel(Excel.Application ExcelApplication, string Dir)
        {
            if (File.Exists(Dir))
                File.Delete(Dir);

            ExcelApplication.ActiveWorkbook.SaveAs(Dir, Excel.XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlShared, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            ExcelApplication.ActiveWorkbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
        }
    
    }
}