using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;
using System.Reflection; 
using System.IO;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;


namespace Poleo.BLL
{
    public class DQ_VentasBLL
    {
        #region BLL
        public String GetSalesDairyQueen(HttpServerUtility server, int Year)
        {
            DQ_VentasDAL objDQVentasDAL = new DQ_VentasDAL();
            DateTime fechaInicial = new DateTime(Year, 1, 1);//new DateTime(DateTime.Now.Year, 1, 1);
            DateTime fechaFinal = new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12));//new DateTime(DateTime.Now.Year, 12,DateTime.DaysInMonth(DateTime.Now.Year,12));
            int semIni = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fechaInicial, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int semFin = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fechaFinal, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            Semana objSemanaIni = new Semana(semIni, Year);//new Semana(semIni, DateTime.Now.Year);
            Semana objSemanaEnd = new Semana(semFin, Year);//new Semana(semFin, DateTime.Now.Year);
            //string ini = "30/12/2019", end = "05/01/2020";
            DQ_VentasFinder objFinderVentas= new DQ_VentasFinder()
            {
                FechaIni =objSemanaIni.FechaInicial,
                FechaEnd=objSemanaEnd.FechaFinal,
                //FechaIni = Convert.ToDateTime(ini),
                //FechaEnd = Convert.ToDateTime(end),
            };
            return generateFileVentas(objFinderVentas, server, Year);

        }
        public String generateFileVentas(DQ_VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            DQ_VentasDAL objDQVentasDAL = new DQ_VentasDAL();

            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                
                IList<Tienda> lstTiendas = objTiendasBLL.SelectDQTiendas(new Tienda());
                foreach (Tienda item in lstTiendas)
                {
                    objfinder.Sucursal = item.Number_tienda;
                    IList<DQ_Ventas> lstventasDQ = objDQVentasDAL.selectDQVentas(objfinder);                    

                    if (lstventasDQ.Count > 0)
                    {
                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstventasDQ, Year);
                    }
                }
                 
                Tienda objTienda = new Tienda();
                objTienda.Code = "ALL";
                IList<DQ_Ventas> lstventasDQTotal = objDQVentasDAL.selectDQVentasTotal(objfinder);                
                if (lstventasDQTotal.Count > 0)
                {
                    this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, objTienda, lstventasDQTotal, Year);
                }





                DateTime dateAux = DateTime.Now;
                nombreArchivo = "VentasDiariasDQ" + Year.ToString() +".xlsx";
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
        public void CreatedContentFileVentas(Excel.Worksheet xlWorksheet, DQ_VentasFinder objfinder, Tienda objTienda, IList<DQ_Ventas> lstventasDQ, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();
            xlWorksheet.Name = objTienda.Code;
            int totalSemanas = objAnioBLL.TotalWeekForYear(Year);//((objfinder.FechaEnd - objfinder.FechaIni).Days + 1) / 7;
            int semActual = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            DateTime dateItem = objfinder.FechaIni;
            for (int i = 0; i < 80; i += 10)
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
            int colOrdenes = 11;
            int colNumPasteles = 21;
            int colVentasPasteles = 31;
            int colVentasTotales = 41;//Added by Hector Sanchez M. - 20160623
            int colUtilizadoIdeal = 51;//Added by Hector Sanchez M. - 20160623
            int colVentasRappi = 61;
            int colOrdenesDom = 71;
            int numDia = 1;
            Decimal totalVentasReales = 0, totalVentaspasteles = 0, totalOrdenes = 0, totalNumPasteles = 0, totalVentasTotales = 0,
                totalUtilizadoIdeal = 0, totalVentasRappi = 0, totalOrdeneDom = 0;
            int initialCount = 1;

            if (totalSemanas == 53)
            {
                #region COMMENTED BY LEO FOR 53
              // initialCount = 0;
               initialCount = 1;
              // totalSemanas--;
                #endregion
                
            }

            for (int i = initialCount; i <= totalSemanas; i++)//(int i = 0; i < totalSemanas; i++)
            {
                xlWorksheet.Cells[ren, colVentas] = i;
                colVentas++;
                xlWorksheet.Cells[ren, colOrdenes] = i;
                colOrdenes++;
                xlWorksheet.Cells[ren, colNumPasteles] = i;
                colNumPasteles++;
                xlWorksheet.Cells[ren, colVentasPasteles] = i;
                colVentasPasteles++;
                xlWorksheet.Cells[ren, colVentasTotales] = i;
                colVentasTotales++;
                xlWorksheet.Cells[ren, colUtilizadoIdeal] = i;
                colUtilizadoIdeal++;
                xlWorksheet.Cells[ren, colVentasRappi] = i;
                colVentasRappi++;
                xlWorksheet.Cells[ren, colOrdenesDom] = i;
                colOrdenesDom++;
                
                for (int j = 0; j < 7; j++)
                {
                    int numSem = i;

                    if (initialCount == 0)
                        numSem++;

                    
                    DQ_Ventas objRes = this.getVentasDairyQueen(lstventasDQ, numSem, numDia, dateItem);//this.getVentasDairyQueen(lstventasDQ, i + 1, numDia, dateItem);
                    dateItem = dateItem.AddDays(1);
                    xlWorksheet.Cells[ren, colVentas] = (Decimal)objRes.VentasReales;
                    colVentas++;
                    totalVentasReales += (Decimal)objRes.VentasReales;
                
                    xlWorksheet.Cells[ren, colOrdenes] = objRes.Ordenes;
                    colOrdenes++;
                    totalOrdenes += objRes.Ordenes;

                    xlWorksheet.Cells[ren, colNumPasteles] = objRes.NumeroPasteles;
                    colNumPasteles++;
                    totalNumPasteles += objRes.NumeroPasteles;

                    xlWorksheet.Cells[ren, colVentasPasteles] = (Decimal)objRes.VentasPasteles;
                    colVentasPasteles++;
                    totalVentaspasteles += (Decimal)objRes.VentasPasteles;

                    //Added by Hector Sanchez M. - 20160623
                    xlWorksheet.Cells[ren, colVentasTotales] = (decimal)objRes.VentasTotales;
                    colVentasTotales++;
                    totalVentasTotales += (decimal)objRes.VentasTotales;

                    xlWorksheet.Cells[ren, colUtilizadoIdeal] = (decimal)objRes.UtilizadoIdeal;
                    colUtilizadoIdeal++;
                    totalUtilizadoIdeal += (decimal)objRes.UtilizadoIdeal;

                    xlWorksheet.Cells[ren, colVentasRappi] = (decimal)objRes.VentasRappi;
                    colVentasRappi++;
                    totalVentasRappi += (decimal)objRes.VentasRappi;

                    xlWorksheet.Cells[ren, colOrdenesDom] = (decimal)objRes.OrdenesDom;
                    colOrdenesDom++;
                    totalOrdeneDom += (decimal)objRes.OrdenesDom;

                    numDia++;
                }
                xlWorksheet.Cells[ren, colVentas] = (Decimal)totalVentasReales;
                xlWorksheet.Cells[ren, colOrdenes] = totalOrdenes;
                xlWorksheet.Cells[ren, colNumPasteles] = totalNumPasteles;
                xlWorksheet.Cells[ren, colVentasPasteles] = (Decimal)totalVentaspasteles;
                xlWorksheet.Cells[ren, colVentasTotales] = (decimal)totalVentasTotales;
                xlWorksheet.Cells[ren, colUtilizadoIdeal] = (decimal)totalUtilizadoIdeal;
                xlWorksheet.Cells[ren, colVentasRappi] = (decimal)totalVentasRappi;
                xlWorksheet.Cells[ren, colOrdenesDom] = (decimal)totalOrdeneDom;

                numDia = 1;
                colVentas = 1;
                colOrdenes = 11;
                colNumPasteles = 21;
                colVentasPasteles = 31;
                colVentasTotales = 41;
                colUtilizadoIdeal = 51;
                colVentasRappi = 61;
                colOrdenesDom = 71;

                ren++;
                totalVentasReales = 0;
                totalNumPasteles = 0;
                totalOrdenes = 0;
                totalVentaspasteles = 0;
                totalVentasTotales = 0;
                totalUtilizadoIdeal = 0;
                totalVentasRappi = 0;
                totalOrdeneDom = 0;
            }

           
            
            Excel.Range rangeVentasVal = xlWorksheet.Range["B7", "I59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["AF7", "AM59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["AP7", "AW59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["AZ7", "BG59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";
            rangeVentasVal = xlWorksheet.Range["BJ7", "BR59"];
            rangeVentasVal.NumberFormat = "$ #,##0.00";

            Excel.Range head = xlWorksheet.Range["A4", "I4"];
            head.Merge();
            head.Value = "VENTAS REALES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["K4", "S4"];
            head.Merge();
            head.Value = "ORDENES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["U4", "AC4"];
            head.Merge();
            head.Value = "NUMERO DE PASTELES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AE4", "AM4"];
            head.Merge();
            head.Value = "VENTAS DE PASTELES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AO4", "AW4"];
            head.Merge();
            head.Value = "VENTAS TOTALES";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["AY4", "BG4"];
            head.Merge();
            head.Value = "UTILIZADO IDEAL";
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["BI4", "BR4"]; // RAPPI
            head.Merge();
            head.Value = "VENTAS A DOMICILIO";      //Antes RAPPI
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head = xlWorksheet.Range["BS4", "CA4"]; // RAPPI
            head.Merge();
            head.Value = "ORDENES A DOMICILIO";      //Antes RAPPI
            head.Font.Size = 24;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            releaseObject(xlWorksheet);
        }
        public DQ_Ventas getVentasDairyQueen(IList<DQ_Ventas> lstVentasfile, int numSemana, int numDia, DateTime dateSearch)
        {
            DQ_Ventas res = new DQ_Ventas()
            {
                VentasReales = 0,
                Ordenes = 0,
                VentasPasteles=0,
                NumeroPasteles=0

            };
            if (dateSearch <= DateTime.Now)
            {
                foreach (DQ_Ventas item in lstVentasfile)
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

        public string CreateFileSalesArticles(DQ_VentasFinder Param, HttpServerUtility server)
        {
            string NameFile = "DQVentasArticulos.xlsx";
            string NameLayout = "ArticulosLayout.xlsx";

            string strPath = server.MapPath("/Layout/VentasDQ") + "/" + NameLayout;
            string strFile = server.MapPath("/indicadores") + "/" + NameFile;

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

                    CreateContentFileSalesArticles(xlWorkbook.Worksheets.get_Item(1), Param);

                    if (File.Exists(strFile))
                        File.Delete(strFile);

                    xlWorkbook.SaveAs(strFile, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    releaseObject(xlWorkbook);
                }
            }

            return NameFile;
        }

        private void CreateContentFileSalesArticles(Excel.Worksheet objWorksheet, DQ_VentasFinder Param)
        {
            #region Ventas
            IList<DQ_VentasArticulos> lstDQ_VentasArticulos = new List<DQ_VentasArticulos>();

            lstDQ_VentasArticulos = SelectVentasDQArticulos(Param);

            int SXPos = 2, SYPos = 1;

            if (lstDQ_VentasArticulos.Count > 0)
            {
                foreach (DQ_VentasArticulos item in lstDQ_VentasArticulos)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.Sucursal;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.VentasTotalesArtic;
                    objWorksheet.Cells[SXPos, SYPos + 3] = item.ArticCostoDinero;
                    objWorksheet.Cells[SXPos, SYPos + 4] = item.CostoPorc;
                    objWorksheet.Cells[SXPos, SYPos + 5] = item.VentasTotalesPasteles;
                    objWorksheet.Cells[SXPos, SYPos + 7] = item.PastelesCostoDinero;
                    objWorksheet.Cells[SXPos, SYPos + 8] = item.PastelesCostoPorc;
                    objWorksheet.Cells[SXPos, SYPos + 9] = item.VentasTotalesOtros;
                    objWorksheet.Cells[SXPos, SYPos + 11] = item.OtrosCostoDinero;
                    objWorksheet.Cells[SXPos, SYPos + 12] = item.OtrosCostoPorc;

                    SXPos++;
                }
            }
            #endregion

            #region Compras
            DQ_ComprasBLL objDQ_ComprasBLL = new DQ_ComprasBLL();
            IList<DQ_Compras> lstDQ_Compras = new List<DQ_Compras>();
            DQ_Compras objDQ_ComprasParam = new DQ_Compras();
            

            objDQ_ComprasParam.DateIni = Param.FechaIni;
            objDQ_ComprasParam.DateEnd = Param.FechaEnd;

            lstDQ_Compras = objDQ_ComprasBLL.SelectComprasHeladoBaseXGalon(objDQ_ComprasParam);

            SXPos = SXPos + 3;

            if(lstDQ_Compras.Count>0)
            {
                foreach (DQ_Compras item in lstDQ_Compras)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.Sucursal;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.Galones;

                    SXPos++;
                }
            }
            #endregion
            releaseObject(objWorksheet);
        }

        //Modified by Hector Sanchez M. 20180731
        private IList<DQ_VentasArticulos> SelectVentasDQArticulos(DQ_VentasFinder param)
        {
            #region COMMENTED
            //IList<DQ_Ventas> lstDQ_Ventas = new List<DQ_Ventas>();
            //DQ_Ventas objDQ_VentasArtic = new DQ_Ventas();
            //DQ_Ventas objDQ_VentasPasteles = new DQ_Ventas();
            //DQ_Ventas objDQ_VentasOtros = new DQ_Ventas();

            //objDQ_VentasArtic = SelectVentasArtic(param);
            //objDQ_VentasPasteles = SelectVentasPasteles(param);
            //objDQ_VentasOtros = SelectVentasOtros(param);

            //lstDQ_Ventas.Add(objDQ_VentasArtic);
            //lstDQ_Ventas.Add(objDQ_VentasPasteles);
            //lstDQ_Ventas.Add(objDQ_VentasOtros);

            //return lstDQ_Ventas;
            #endregion

            IList<DQ_VentasArticulos> lstDQ_VentasArticulos = new List<DQ_VentasArticulos>();

            lstDQ_VentasArticulos = SelectSalesArticles(param);

            return lstDQ_VentasArticulos;

        }

        //Added by Hector Sanchez M. - 20181009
        private void GenerateContentFileByWeek(Excel.Worksheet ExcelSheet, DQ_VentasFinder objDQ_VentasFinder, int numWeek, bool IsTotal = false)
        {
            IList<DQ_Ventas> lstDQ_Ventas = new List<DQ_Ventas>();
            DQ_VentasDAL objDQVentasDAL = new DQ_VentasDAL();
            AnioBLL objAnioBLL = new AnioBLL();
            DateTime dateItem = objDQ_VentasFinder.FechaIni;
            DateTime? dateItemIni = null, dateItemEnd = null;

            if (!IsTotal)
                lstDQ_Ventas = objDQVentasDAL.selectDQVentas(objDQ_VentasFinder);
            else
                lstDQ_Ventas = objDQVentasDAL.selectDQVentasTotal(objDQ_VentasFinder);

            int colVentas = 2;
            int colOrdenes = 12;
            int colNumPasteles = 22;
            int colVentasPasteles = 32;
            int colVentasTotales = 42;//Added by Hector Sanchez M. - 20160623
            int colUtilizadoIdeal = 52;//Added by Hector Sanchez M. - 20160623
            int colRappi = 62;
            int colOrdenesDom = 72;

            Decimal totalVentasReales = 0, totalVentaspasteles = 0, totalOrdenes = 0, totalNumPasteles = 0, totalVentasTotales = 0,
                totalUtilizadoIdeal = 0, totalVentasRappi = 0;

            int InitRow = 7 + numWeek;
            int count = 0;

            foreach (DQ_Ventas objDQ_Ventas in lstDQ_Ventas)
            {
                ExcelSheet.Cells[InitRow, colVentas] = (Decimal)objDQ_Ventas.VentasReales;
                colVentas++;
                totalVentasReales += (Decimal)objDQ_Ventas.VentasReales;

                ExcelSheet.Cells[InitRow, colOrdenes] = objDQ_Ventas.Ordenes;
                colOrdenes++;
                totalOrdenes += objDQ_Ventas.Ordenes;

                ExcelSheet.Cells[InitRow, colNumPasteles] = objDQ_Ventas.NumeroPasteles;
                colNumPasteles++;
                totalNumPasteles += objDQ_Ventas.NumeroPasteles;

                ExcelSheet.Cells[InitRow, colVentasPasteles] = (Decimal)objDQ_Ventas.VentasPasteles;
                colVentasPasteles++;
                totalVentaspasteles += (Decimal)objDQ_Ventas.VentasPasteles;

                //Added by Hector Sanchez M. - 20160623
                ExcelSheet.Cells[InitRow, colVentasTotales] = (decimal)objDQ_Ventas.VentasTotales;
                colVentasTotales++;
                totalVentasTotales += (decimal)objDQ_Ventas.VentasTotales;

                ExcelSheet.Cells[InitRow, colUtilizadoIdeal] = (decimal)objDQ_Ventas.UtilizadoIdeal;
                colUtilizadoIdeal++;

                count++;

                if (objDQ_Ventas.Sucursal == "07" && count == 6)
                {
                    colVentas++;
                    colOrdenes++;
                    colNumPasteles++;
                    colVentasPasteles++;
                    colVentasTotales++;
                    colUtilizadoIdeal++;
                    colRappi++;
                    colOrdenesDom++;

                }

                if (count == 7 || (objDQ_Ventas.Sucursal == "07" && count == 6))
                {
                    ExcelSheet.Cells[InitRow, colVentas] = (Decimal)totalVentasReales;
                    ExcelSheet.Cells[InitRow, colOrdenes] = totalOrdenes;
                    ExcelSheet.Cells[InitRow, colNumPasteles] = totalNumPasteles;
                    ExcelSheet.Cells[InitRow, colVentasPasteles] = (Decimal)totalVentaspasteles;
                    ExcelSheet.Cells[InitRow, colVentasTotales] = (decimal)totalVentasTotales;
                    ExcelSheet.Cells[InitRow, colUtilizadoIdeal] = (decimal)totalUtilizadoIdeal;

                    colVentas = 2;
                    colOrdenes = 12;
                    colNumPasteles = 22;
                    colVentasPasteles = 32;
                    colVentasTotales = 42;
                    colUtilizadoIdeal = 52;

                    InitRow++;
                    totalVentasReales = 0;
                    totalNumPasteles = 0;
                    totalOrdenes = 0;
                    totalVentaspasteles = 0;
                    totalVentasTotales = 0;
                    totalUtilizadoIdeal = 0;

                    count = 0;
                }
            }

            releaseObject(ExcelSheet);
        }

        //Added by Hector Sanchez M. - 20181009
        private Excel.Application GenerateFileSalesByWeek(int numWeek, int Year)
        {
            Excel.Application objExcelApplication = new Excel.Application();
            Excel.Worksheet objExcelWorksheet; //= new Excel.Worksheet();
            Excel.Workbook objExcelWorkbook;

            DQ_VentasFinder objDQ_VentasFinder = new DQ_VentasFinder();
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            AnioBLL objAnioBLL = new AnioBLL();

            Semana objWeek = new Semana(numWeek, Year);
            Semana objEndWeek = new Semana(objAnioBLL.TotalWeekForYear(Year), Year);

            objDQ_VentasFinder.FechaIni = objWeek.FechaInicial;
            objDQ_VentasFinder.FechaEnd = objEndWeek.FechaFinal;

            string FileName = "VentasDiariasDQ" + Year.ToString() + ".xlsx";

            objExcelWorkbook = objExcelApplication.Workbooks.Open(HttpContext.Current.Server.MapPath(@"~\Layout\VentasDQ\" + FileName),
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                     Type.Missing, Type.Missing);

            lstTienda = objTiendaBLL.SelectDQTiendas(new Tienda());

            foreach (Tienda objTienda in lstTienda)
            {
                objDQ_VentasFinder.Sucursal = objTienda.Number_tienda;

                objExcelWorksheet = objExcelWorkbook.Sheets[objTienda.Code];

                GenerateContentFileByWeek(objExcelWorksheet, objDQ_VentasFinder, numWeek - 1);
            }

            objExcelWorksheet = objExcelWorkbook.Sheets["ALL"];
            objDQ_VentasFinder.Sucursal = string.Empty;

            GenerateContentFileByWeek(objExcelWorksheet, objDQ_VentasFinder, numWeek - 1, true);

            releaseObject(objExcelWorksheet);
            releaseObject(objExcelWorkbook);

            return objExcelApplication;
        }

        //Added by Hector Sanchez M. - 20181009
        private void SaveFileExcel(Excel.Application objExcelApplication, string Dir)
        {
            if (File.Exists(Dir))
                File.Delete(Dir);

            objExcelApplication.ActiveWorkbook.SaveAs(Dir, Excel.XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlShared, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                    System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            objExcelApplication.ActiveWorkbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
        }

        //Added by Hector Sanchez M. - 20181009
        private string GenerateFileSales(int numWeek, int Year, string Dir)
        {
            string FileName = "VentasDiariasDQ" + Year.ToString() + ".xlsx";

            Excel.Application objApplication = GenerateFileSalesByWeek(numWeek, Year);
            SaveFileExcel(objApplication, HttpContext.Current.Server.MapPath(Dir));

            releaseObject(objApplication);

            return FileName;
        }

        public string CreateFileSales(int Year, HttpServerUtility Server)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();

            string FileName = "VentasDiariasDQ" + Year.ToString() + ".xlsx";
            string Path = "~/indicadores/" + FileName;

            int? NumWeek = objSettingsFileSalesBLL.ValidConfigFileSales("DQ", Year);

            if (NumWeek == null)
                GetSalesDairyQueen(Server, Year);
            else
                GenerateFileSales(NumWeek.Value, Year, Path);

            return FileName;
        }
        #endregion

        #region DAL
        public InfoTiempoReal SelectVentasDQOnLine(InfoTiempoReal Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectVentasDQOnLine(Param);
        }

        public IList<InfoTiempoReal> SelectVentasDQOnLineTienda(InfoTiempoReal Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectVentasDQOnLineTienda(Param);
        }

        //public IList<DQ_Ventas> SelectVentasDQArticulos(DQ_VentasFinder Param)
        //{
        //    DQ_VentasDAL dal = new DQ_VentasDAL();

        //    return dal.SelectVentasDQArticulos(Param);
        //}

        private DQ_Ventas SelectVentasArtic(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectVentasArtic(Param);
        }

        private DQ_Ventas SelectVentasPasteles(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectVentasPasteles(Param);
        }

        private DQ_Ventas SelectVentasOtros(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectVentasOtros(Param);
        }

        public IList<DQ_Ventas> SelectSalesScreen(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectSalesScreen(Param);
        }

        public IList<DQ_Ventas> SelectSalesScreenTotal(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectSalesScreenTotal(Param);
        }

        public IList<DQ_VentasArticulos> SelectSalesArticles(DQ_VentasFinder Param)
        {
            DQ_VentasDAL dal = new DQ_VentasDAL();

            return dal.SelectSalesArticles(Param);
        }
        #endregion
    }
}