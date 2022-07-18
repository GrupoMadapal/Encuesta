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
    public class CostosXEmployeeBLL
    {
        public IList<CostosXEmployee> SelectEmployeesXStore(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectEmployeesXStore(param);
        }

        public CostosXEmployee SelectCostXEm1st(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectCostXEm1st(param);
        }

        public CostosXEmployee SelectCostXEm2nd(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectCostXEm2nd(param);
        }

        public CostosXEmployee SelectCostXEm3rd(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectCostXEm3rd(param);
        }

        public CostosXEmployee SelectCostXStore(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectCostXStore(param);
        }
        

        public IList<Ventas> SelectVentasGratisTotal(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentasGratisTotal(param);
        }

        public IList<CostosXEmployee> SelectLISTCostXEm1st(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectLISTCostXEm1st(param);
        }

        public IList<CostosXEmployee> SelectLISTCostXEm2nd(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectLISTCostXEm2nd(param);
        }

        public IList<CostosXEmployee> SelectLISTCostXEm3rd(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectLISTCostXEm3rd(param);
        }

        public String generateFileCostos1Store(HttpServerUtility server, VentasFinder objVentasFinder, string locationCode)
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
                string temp = locationCode.Substring(0,1);



                if (temp == "1")//if (!string.IsNullOrEmpty(objVentasFinder.NumTienda))                       //Only one Store, selected in the DDL
                {
                    //objtienda.Code =  objfinder.NumTienda = objVentasFinder.NumTienda;
                    objtienda.Code = objfinder.NumTienda = locationCode;
                    objVentasFinder.DateIni = DateTime.Today;
                    objVentasFinder.DateEnd = DateTime.Today;
                    IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                    this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda, lstVentasfile);
                }
                else
                {
                    
                }

                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "COSTOSHOY" +  ".xlsx";
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

        public String generateFileCostos(HttpServerUtility server, VentasFinder objVentasFinder)
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
                    objtienda.Code =  objfinder.NumTienda = objVentasFinder.NumTienda;
                    objVentasFinder.DateIni = DateTime.Today;
                    objVentasFinder.DateEnd = DateTime.Today;
                    IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                    this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda, lstVentasfile);
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
                        IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                        this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile);

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
                    IList<Ventas> lstVentasfileSLP = this.SelectVentasGratisTotal(objVentasFinder);
                    this.CreatedContentFileCostosTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaSLP, lstVentasfileSLP);


                    objfinder.NumTienda = null;
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = "Tamaulipas";
                    Tienda objTiendaTMPS = new Tienda()
                    {
                        Code = "TOTAL_TMPS",
                        Number_tienda = string.Empty
                    };
                    IList<Ventas> lstVentasfileTMPS = this.SelectVentasGratisTotal(objVentasFinder);
                    this.CreatedContentFileCostosTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaTMPS, lstVentasfileTMPS);

                    objfinder.NumTienda = null;
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = null;
                    Tienda objTiendaFRANQ = new Tienda()
                    {
                        Code = "FRANQ",
                        Number_tienda = string.Empty
                    };
                    IList<Ventas> lstVentasfileFRANQ = this.SelectVentasGratisTotal(objVentasFinder);
                    this.CreatedContentFileCostosTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaFRANQ, lstVentasfileFRANQ);
                }


                /*objfinder.NumTienda = "11028";
                objtienda.Number_tienda = "11028";
                objtienda.Code = "carranza";
                this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda);*/



                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "COSTOSHOY" + anioNom + ".xlsx";
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

        public void CreatedContentFileCostosTOTAL(Excel.Worksheet xlWorksheet, OrdenesFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile)
        {
            //CostosXEmployee objTiemposCostos1 = new CostosXEmployee();
            //CostosXEmployee objTiemposCostos2 = new CostosXEmployee();
            //CostosXEmployee objTiemposCostos3 = new CostosXEmployee();
            objfinder.Order_Date = DateTime.Today;
            //objfinder.Order_Date = new DateTime(2020, 07, 29);

            xlWorksheet.Name = objTienda.Code;

            for (int i = 0; i < 12; i += 5)
            {
                xlWorksheet.Cells[3, 1 + i] = "NUMERO ORDENES";
                xlWorksheet.Cells[3, 2 + i] = "TIENDA";
                xlWorksheet.Cells[3, 3 + i] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[3, 4 + i] = "COSTO";
                
            }

            int filaAuxiliar1 = 4, filaAuxiliar2 = 4, filaAuxiliar3 = 4;
            int columnAuxiliar1 = 1, columnAuxiliar2 = 6, columnAuxiliar3 = 11;

                IList<CostosXEmployee> LstTiemposCostos1 = SelectLISTCostXEm1st(objfinder); //1st ==   10 AM to 1 PM

                if (LstTiemposCostos1.Count > 0)
                {
                    foreach(CostosXEmployee objTiemposCostos1 in LstTiemposCostos1)
                    {
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.Location_Code;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 3] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                        filaAuxiliar1++;
                    }
                    
                }

                IList<CostosXEmployee> LstTiemposCostos2 = SelectLISTCostXEm2nd(objfinder);  //2nd ==   1 PM to 6 PM
                if (LstTiemposCostos2.Count > 0)
                {
                    foreach (CostosXEmployee objTiemposCostos2 in LstTiemposCostos2)
                    {
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2] = objTiemposCostos2.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 1] = objTiemposCostos2.Location_Code;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 2] = objTiemposCostos2.FullName + objTiemposCostos2.FullName2;
                        xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 3] = objTiemposCostos2.OrderIdealFoodCost / objTiemposCostos2.OrderRoyaltySales;
                        filaAuxiliar2++;
                    }
                }

                IList<CostosXEmployee> LstTiemposCostos3 = SelectLISTCostXEm3rd(objfinder);    //3rd ==   6 PM to 12 PM
                if (LstTiemposCostos3.Count > 0)
                {
                    foreach (CostosXEmployee objTiemposCostos3 in LstTiemposCostos3)
                    {
                        xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3] = objTiemposCostos3.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3 + 1] = objTiemposCostos3.Location_Code;
                        xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3 + 2] = objTiemposCostos3.FullName + objTiemposCostos3.FullName2;
                        xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3 + 3] = objTiemposCostos3.OrderIdealFoodCost / objTiemposCostos3.OrderRoyaltySales;
                        filaAuxiliar3++;
                    }
                }

            
            CostosXEmployee CostXStore = SelectCostXStore(objfinder);

            int filaMax = Math.Max(Math.Max(filaAuxiliar1, filaAuxiliar2), filaAuxiliar3);
            xlWorksheet.Cells[filaMax + 2, 8] = "COSTO TOTAL:";
            xlWorksheet.Cells[filaMax + 2, 9] = CostXStore != null ? CostXStore.Costo : 0;


            Excel.Range rangeCostos = xlWorksheet.Range["A1", "N500"];  //HEADERS
            rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rangeCostos = xlWorksheet.Range["A3", "N3"];
            rangeCostos.Rows.WrapText = true;
            rangeCostos.RowHeight = 37; ////////////////////////////////////////////////////
            rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeCostos = xlWorksheet.Range["A2", "D2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "10:00 AM - 1:00 PM";
            rangeCostos = xlWorksheet.Range["F2", "I2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "01:00 PM - 06:00 PM";
            rangeCostos = xlWorksheet.Range["K2", "N2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "06:00 PM - 12:00 AM";
            rangeCostos = xlWorksheet.Range["A2", "N3"];
            rangeCostos.Font.Bold = true;
            rangeCostos.Font.Size = 14;

            Excel.Range columna = xlWorksheet.Range["A2", "A2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 9;

            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["H2", "H2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["I2", "I2"];
            columna.ColumnWidth = 9;

            columna = xlWorksheet.Range["K2", "K2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["L2", "L2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["M2", "M2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["N2", "N2"];
            columna.ColumnWidth = 9;

            columna = xlWorksheet.Range["A2", "D" + filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["F2", "I" + filaAuxiliar2];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["K2", "N" + filaAuxiliar3];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders

            rangeCostos = xlWorksheet.Range["D4", "D299"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["I4", "I299"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["N4", "N299"];
            rangeCostos.NumberFormat = "###,##0.00%";
            
            
        }

        public void CreatedContentFileCostos(Excel.Worksheet xlWorksheet, OrdenesFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile)
        {
            CostosXEmployee objTiemposCostos1 = new CostosXEmployee();
            CostosXEmployee objTiemposCostos2= new CostosXEmployee();
            CostosXEmployee objTiemposCostos3 = new CostosXEmployee();
            objfinder.Order_Date = DateTime.Today;
            xlWorksheet.Name = objTienda.Code;

            for (int i = 0; i < 12; i += 4)
            {
                xlWorksheet.Cells[3, 1 + i] = "NUMERO ORDENES";
                xlWorksheet.Cells[3, 2 + i] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[3, 3 + i] = "COSTO";
            }

            int filaAuxiliar1 = 4, filaAuxiliar2 = 4, filaAuxiliar3 = 4, counts = 0;
            int columnAuxiliar1 = 1, columnAuxiliar2 = 5, columnAuxiliar3 = 9;

            
            IList<CostosXEmployee> ListEmpleados = SelectEmployeesXStore(objfinder);

            foreach(CostosXEmployee item in ListEmpleados)
            {
                objfinder.Empleado = item.Empleado;
                objTiemposCostos1 = SelectCostXEm1st(objfinder);

                if (objTiemposCostos1 != null)
                {
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                    filaAuxiliar1++;
                }

                objTiemposCostos2 = SelectCostXEm2nd(objfinder);
                if (objTiemposCostos2 != null)
                {
                    xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2] = objTiemposCostos2.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 1] = objTiemposCostos2.FullName + objTiemposCostos2.FullName2;
                    xlWorksheet.Cells[filaAuxiliar2, columnAuxiliar2 + 2] = objTiemposCostos2.OrderIdealFoodCost / objTiemposCostos2.OrderRoyaltySales;
                    filaAuxiliar2++;
                }                

                objTiemposCostos3 = SelectCostXEm3rd(objfinder);
                if (objTiemposCostos3 != null)
                {
                    xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3] = objTiemposCostos3.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3 + 1] = objTiemposCostos3.FullName + objTiemposCostos3.FullName2;
                    xlWorksheet.Cells[filaAuxiliar3, columnAuxiliar3 + 2] = objTiemposCostos3.OrderIdealFoodCost / objTiemposCostos3.OrderRoyaltySales;
                    filaAuxiliar3++;
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

            OrdenesFinder finderXTienda1 = new OrdenesFinder();
            finderXTienda1.Order_Date = DateTime.Today;
            finderXTienda1.NumTienda = objfinder.NumTienda;
            finderXTienda1.UbicacionTienda = null;
            CostosXEmployee CostXStore = SelectCostXStore(finderXTienda1);

            int filaMax = Math.Max(Math.Max(filaAuxiliar1, filaAuxiliar2), filaAuxiliar3);            
            xlWorksheet.Cells[filaMax + 2, 6 ] = "COSTO POR TIENDA:";
            xlWorksheet.Cells[filaMax + 2, 7 ] = CostXStore != null ? CostXStore.Costo : 0;            

            Excel.Range rangeCostos = xlWorksheet.Range["A1", "K100"];  //HEADERS
            rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rangeCostos = xlWorksheet.Range["A3", "K3"];
            rangeCostos.Rows.WrapText = true;
            rangeCostos.RowHeight = 37; ////////////////////////////////////////////////////
            rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeCostos = xlWorksheet.Range["A2", "C2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "10:00 AM - 1:00 PM";
            rangeCostos = xlWorksheet.Range["E2", "G2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "01:00 PM - 06:00 PM";
            rangeCostos = xlWorksheet.Range["I2", "K2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "06:00 PM - 12:00 AM";
            rangeCostos = xlWorksheet.Range["A2", "K3"];
            rangeCostos.Font.Bold = true;
            rangeCostos.Font.Size = 14;

            Excel.Range columna = xlWorksheet.Range["A2", "A2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 9;  
            columna = xlWorksheet.Range["E2", "E2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 9;
            columna = xlWorksheet.Range["I2", "I2"]; 
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["J2", "J2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["K2", "k2"];
            columna.ColumnWidth = 9;

            columna = xlWorksheet.Range["A2", "C"+ filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["E2", "G"+ filaAuxiliar2];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["I2", "K"+ filaAuxiliar3];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders

            rangeCostos = xlWorksheet.Range["C4", "C99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["G4", "G99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["K4", "K99"];
            rangeCostos.NumberFormat = "###,##0.00%";
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