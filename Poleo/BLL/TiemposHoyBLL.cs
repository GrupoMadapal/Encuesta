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
    public class TiemposHoyBLL
    {
        public IList<CostosXEmployee> SelectDeliveryOrdersXEmToday(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectDeliveryOrdersXEmToday(param);
        }

        public IList<CostosXEmployee> SelectDeliveryOrdersXEmBD(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectDeliveryOrdersXEmBD(param);
        }

        public String generateFileDeliveryOrdersToday1Store(HttpServerUtility server, VentasFinder objVentasFinder, string locationCode)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            OrdenesFinder objfinder = new OrdenesFinder();
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objtienda = new Tienda();
                string temp = locationCode.Substring(0, 1);

                if (temp == "1")                         //Only one Store, selected in the DDL
                {
                    objtienda.Code = objtienda.Number_tienda = objfinder.NumTienda = locationCode;
                    objfinder.UbicacionTienda = null;
                    objfinder.Empleado = null;
                    objVentasFinder.DateIni = DateTime.Today;
                    objVentasFinder.DateEnd = DateTime.Today;

                    this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, objtienda);
                }
                else
                {
                    
                }


                /*objfinder.NumTienda = "11028";
                objtienda.Number_tienda = "11028";
                objtienda.Code = "carranza";
                this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda);*/



                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "TiemposHoy" + anioNom + ".xlsx";
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

        public String generateFileDeliveryOrdersToday(HttpServerUtility server, VentasFinder objVentasFinder)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            OrdenesFinder objfinder = new OrdenesFinder();
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objtienda = new Tienda();

                if (!string.IsNullOrEmpty(objVentasFinder.NumTienda))                       //Only one Store, selected in the DDL
                {
                    objtienda.Code = objfinder.NumTienda = objVentasFinder.NumTienda;
                    objfinder.UbicacionTienda = null;
                    objfinder.Empleado = null;
                    objVentasFinder.DateIni = DateTime.Today;
                    objVentasFinder.DateEnd = DateTime.Today;

                    this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, objtienda);
                }
                else
                {
                    IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objtienda);
                    foreach (Tienda item in lstTiendas)
                    {
                        objfinder.NumTienda = item.Number_tienda;
                        objVentasFinder.NumTienda = item.Number_tienda;
                        objVentasFinder.DateIni = DateTime.Today;
                        objVentasFinder.DateEnd = DateTime.Today;

                        this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, item);

                    }

                    objfinder.NumTienda = null;
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = "San Luis Potosí";
                    Tienda objTiendaSLP = new Tienda()
                    {
                        Code = "TOTAL_SLP",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.UbicacionTienda = "San Luis Potosí";
                    objVentasFinder.DateIni = DateTime.Today;
                    objVentasFinder.DateEnd = DateTime.Today;
                    //this.CreatedContentFileDeliveryOrdersTodayTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP);
                    this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP);


                    objfinder.NumTienda = null;
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = "Tamaulipas";
                    Tienda objTiendaTMPS = new Tienda()
                    {
                        Code = "TOTAL_TMPS",
                        Number_tienda = string.Empty
                    };
                    //this.CreatedContentFileDeliveryOrdersTodayTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaTMPS);
                    this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, objTiendaTMPS);

                    objfinder.NumTienda = null;
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = null;
                    Tienda objTiendaFRANQ = new Tienda()
                    {
                        Code = "FRANQ",
                        Number_tienda = string.Empty
                    };
                    //this.CreatedContentFileDeliveryOrdersTodayTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaFRANQ);
                    this.CreatedContentFileDeliveryOrdersToday(xlWorkBook.Worksheets.Add(), objfinder, objTiendaFRANQ);
                }


                /*objfinder.NumTienda = "11028";
                objtienda.Number_tienda = "11028";
                objtienda.Code = "carranza";
                this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda);*/



                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "TiemposHoy" + anioNom + ".xlsx";
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

        public void CreatedContentFileDeliveryOrdersToday(Excel.Worksheet xlWorksheet, OrdenesFinder objfinder, Tienda objTienda)
        {            
            objfinder.Order_Date = DateTime.Today;
            //objfinder.Order_Date = new DateTime(2020, 07, 29);
            xlWorksheet.Name = objTienda.Code;

            for (int i = 1; i < 10; i += 6)
            {
                xlWorksheet.Cells[2, 1 + i] = "TIENDA";
                xlWorksheet.Cells[2, 2 + i] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[2, 3 + i] = "TOTAL DE ORDENES";
                xlWorksheet.Cells[2, 4 + i] = "TIEMPO PROMEDIO";
                xlWorksheet.Cells[2, 5 + i] = "TIEMPO PROMEDIO DE CORRIDA";
            }

            int filaAuxiliar1 = 3, filaAuxiliar2 = 3, counts = 0;
            int columnAuxiliar1 = 2, columnAuxiliar2 = 8;


            //IList<CostosXEmployee> LstTiemposPromedio = SelectDeliveryOrdersXEmBD(objfinder);
            IList<CostosXEmployee> LstTiemposPromedio = SelectDeliveryOrdersXEmToday(objfinder);

            if (LstTiemposPromedio.Count > 0)
            {
                foreach (CostosXEmployee objTiemposCostos1 in LstTiemposPromedio)
                {
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.Location_Code;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.FullName;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 3] = objTiemposCostos1.TiempoPromedioMinutes.ToString();
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 4] = objTiemposCostos1.TiempoPromedioDeCorrida.ToString();
                    filaAuxiliar1++;
                }
            }

            if (LstTiemposPromedio.Count > 0)
            {
                foreach (CostosXEmployee objTiemposCostos2 in LstTiemposPromedio)
                {
                    if (objTiemposCostos2.TiempoPromedioMinutes > 44)
                    {
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2] = objTiemposCostos2.Location_Code;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 1] = objTiemposCostos2.FullName;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 2] = objTiemposCostos2.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 3] = objTiemposCostos2.TiempoPromedioMinutes.ToString();
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 4] = objTiemposCostos2.TiempoPromedioDeCorrida.ToString();
                        filaAuxiliar2++;
                    }
                    
                }
            }

            /*Decimal CostoIdeal = 0;
            int dias = 0, filaMax;
            foreach (Ventas item in lstVentasfile)
            {
                CostoIdeal += (Decimal)item.VentasReales != 0 ? item.Utilizado / item.VentasReales : 0;
            }
            TimeSpan betweenDatesSpan = objfinder.Order_Date.Subtract(objfinder.Order_Date);
            dias = int.Parse(betweenDatesSpan.Days.ToString());
            Decimal average = CostoIdeal / (dias + 1);*/            

            Excel.Range rangeCostos = xlWorksheet.Range["A1", "L799"];  //HEADERS
            rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rangeCostos = xlWorksheet.Range["H1","L1"];            
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Font.Bold = true;
            rangeCostos.Merge();
            rangeCostos.Value = "MAYOR A 45 MINUTOS";

            rangeCostos = xlWorksheet.Range["B2", "L2"];
            rangeCostos.Rows.WrapText = true;
            rangeCostos.RowHeight = 55; ////////////////////////////////////////////////////
            rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeCostos.Font.Size = 14;

            Excel.Range  columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 15;

            columna = xlWorksheet.Range["H2", "H2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["I2", "I2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["J2", "J2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["K2", "K2"];
            columna.ColumnWidth = 15;
            columna = xlWorksheet.Range["L2", "L2"];
            columna.ColumnWidth = 15;

            columna = xlWorksheet.Range["B2", "F" + filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["H2", "L" + filaAuxiliar2];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders

            /*rangeCostos = xlWorksheet.Range["C4", "C99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["G4", "G99"];
            rangeCostos.NumberFormat = "###,##0.00%";*/
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