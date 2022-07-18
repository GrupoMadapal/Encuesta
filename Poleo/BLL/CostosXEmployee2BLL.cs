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
    public class CostosXEmployee2BLL
    {
        public IList<CostosXEmployee> SelectEmployeesXStore2(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectEmployeesXStore2(param);
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

        public CostosXEmployee SelectCostXEmBD(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectCostXEmBD(param);
        }

        public IList<CostosXEmployee> SelectLISTCostXEmBD(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectLISTCostXEmBD(param);
        }

        public IList<CostosXEmployee> SelectLISTCostXEm1st(OrdenesFinder param)
        {
            CostosXEmployeeDAL DAL = new CostosXEmployeeDAL();
            return DAL.SelectLISTCostXEm1st(param);
        }

        public IList<Ventas> SelectVentasGratisTotal(VentasFinder param)
        {
            VentaDAL DAL = new VentaDAL();
            return DAL.SelectVentasGratisTotal(param);
        }

        public String generateFileCostos2_1Store(HttpServerUtility server, VentasFinder objVentasFinder, string locationCode)
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

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objtienda);
                objfinder.DateIni2 = objVentasFinder.DateIni.Value;
                objfinder.DateEnd2 = objVentasFinder.DateEnd.Value;
                if (temp == "1")                       //Only one Store, selected in the DDL
                {
                    objfinder.Empleado = null;
                    objfinder.UbicacionTienda = null;
                    objfinder.NumTienda = locationCode;
                    objtienda.Code = objtienda.Number_tienda = locationCode;
                    IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                    this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda, lstVentasfile);
                }
                else
                {
                    /*Tienda objtiendaSList = new Tienda();
                    IList<Tienda> lstTiendasCompleto = objTiendasBLL.SelectTiendas(objtiendaSList);

                    foreach (Tienda item in lstTiendasCompleto)
                    {
                        objfinder.NumTienda = item.Number_tienda;
                        objVentasFinder.NumTienda = item.Number_tienda;
                        IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                        this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile);    //  COMPLETE WITH FULL LIST STORES
                    }*/
                }



                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "COSTOSHISTORIAL"+ ".xlsx";
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

        public String generateFileCostos2(HttpServerUtility server, VentasFinder objVentasFinder)
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

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objtienda);
                objfinder.DateIni2 = objVentasFinder.DateIni.Value;
                objfinder.DateEnd2 = objVentasFinder.DateEnd.Value;
                objfinder.NumTienda = objVentasFinder.NumTienda;
                if (!string.IsNullOrEmpty(objVentasFinder.NumTienda))                       //Only one Store, selected in the DDL
                {
                    objtienda.Code = objtienda.Number_tienda = objVentasFinder.NumTienda;
                    IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                    this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda, lstVentasfile);
                }else
                {
                    Tienda objtiendaSList = new Tienda();
                    IList<Tienda> lstTiendasCompleto = objTiendasBLL.SelectTiendas(objtiendaSList);

                    foreach (Tienda item in lstTiendasCompleto)
                    {
                        objfinder.NumTienda = item.Number_tienda;
                        objVentasFinder.NumTienda = item.Number_tienda;
                        IList<Ventas> lstVentasfile = this.SelectVentasGratisTotal(objVentasFinder);

                        this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, item, lstVentasfile);    //  COMPLETE WITH FULL LIST STORES
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
                    //objVentasFinder.DateIni = objVentasFinder.DateIni.Value;
                    //objVentasFinder.DateEnd = objVentasFinder.DateEnd.Value;
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
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = "Tamaulipas";
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
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = null;
                    IList<Ventas> lstVentasfileFRANQ = this.SelectVentasGratisTotal(objVentasFinder);
                    this.CreatedContentFileCostosTOTAL(xlWorkBook.Worksheets.Add(), objfinder, objTiendaFRANQ, lstVentasfileFRANQ);
                }
                /*objfinder.NumTienda = "11028";
                objtienda.Number_tienda = "11028";
                objtienda.Code = "carranza";
                this.CreatedContentFileCostos(xlWorkBook.Worksheets.Add(), objfinder, objtienda);*/



                DateTime dateAux = DateTime.Now;
                string anioNom = DateTime.Now.Year.ToString(); //objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "COSTOSHISTORIAL" + ".xlsx";
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

        public void CreatedContentFileCostos(Excel.Worksheet xlWorksheet, OrdenesFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile)
        {
            CostosXEmployee objTiemposCostos1 = new CostosXEmployee();
            CostosXEmployee objTiemposCostos2 = new CostosXEmployee();
            CostosXEmployee objTiemposCostos3 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos1 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos2 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos3 = new CostosXEmployee();
            DateTime Fecha = new DateTime();
            Boolean Bloque1 = false;
            Boolean Bloque2 = false;
            Boolean Bloque3 = false;
            int filaAuxiliar1 = 4, filaAuxiliar2 = 4, filaAuxiliar3 = 4, dias = 0, contador;
            int columnAuxiliar1 = 1, columnAuxiliar2 = 5, columnAuxiliar3 = 9;
            int TotalOrdenes1 = 0, TotalOrdenes2 = 0, TotalOrdenes3 = 0;
            string FullName1 = string.Empty, FullName2 = string.Empty, FullName3 = string.Empty;
            Decimal OrderIdealFoodCost1=0, OrderRoyaltySales1=0, OrderIdealFoodCost2=0, OrderRoyaltySales2=0, OrderIdealFoodCost3=0, OrderRoyaltySales3=0;
            Decimal CostoIdeal=0;

            xlWorksheet.Name = objTienda.Code;

            for (int i = 0; i < 4; i += 4)
            {
                xlWorksheet.Cells[3, 1 + i] = "NUMERO ORDENES";
                xlWorksheet.Cells[3, 2 + i] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[3, 3 + i] = "COSTO";
            }

            IList<CostosXEmployee> ListEmpleados = SelectEmployeesXStore2(objfinder);  //Between DateIni and DateEnd
            foreach (CostosXEmployee item in ListEmpleados)
            {
                objfinder.Empleado = item.Empleado;
                objfinder.Order_Date = Fecha;
                objTiemposCostos1 = SelectCostXEmBD(objfinder);

                if (objTiemposCostos1 != null)
                {
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                    filaAuxiliar1++;
                }

                /*TimeSpan betweenDatesSpan = objfinder.DateEnd2.Value.Subtract(objfinder.DateIni2.Value);
                dias = int.Parse(betweenDatesSpan.Days.ToString());
                Fecha = objfinder.DateIni2.Value;
                for (contador = 0; contador <= dias; contador++)
                {
                    objfinder.Order_Date = Fecha;
                    objTiemposCostos1 = SelectCostXEmBD(objfinder);

                    if (objTiemposCostos1 != null)
                    {
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                        filaAuxiliar1++;
                    }

                    Fecha = Fecha.AddDays(1);
                }*/
            }

            foreach(Ventas item in lstVentasfile)
            {
                CostoIdeal += (Decimal)item.VentasReales != 0 ? item.Utilizado / item.VentasReales : 0;
            }
            TimeSpan betweenDatesSpan = objfinder.DateEnd2.Value.Subtract(objfinder.DateIni2.Value);
            dias = int.Parse(betweenDatesSpan.Days.ToString());
            Decimal average = CostoIdeal / (dias + 1);

            xlWorksheet.Cells[3, 6] = "COSTO POR TIENDA";
            xlWorksheet.Cells[4, 6] = average;

            
            Excel.Range rangeCostos = xlWorksheet.Range["A1", "K100"];  //HEADERS
            rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rangeCostos = xlWorksheet.Range["A3", "K3"];
            rangeCostos.Rows.WrapText = true;
            rangeCostos.RowHeight = 37;
            rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeCostos = xlWorksheet.Range["A2", "C2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "DE "+objfinder.DateIni2.Value.ToShortDateString()+" A "+ objfinder.DateEnd2.Value.ToShortDateString();
            /*rangeCostos = xlWorksheet.Range["E2", "G2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "01:00 PM - 06:00 PM";
            rangeCostos = xlWorksheet.Range["I2", "K2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "06:00 PM - 12:00 AM";*/
            rangeCostos = xlWorksheet.Range["A2", "K3"];
            rangeCostos.Font.Bold = true;
            rangeCostos.Font.Size = 14;

            Excel.Range columna = xlWorksheet.Range["A2", "A2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 30;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 9;
            columna = xlWorksheet.Range["F2", "F2"];
            columna.ColumnWidth = 23;
            /*columna = xlWorksheet.Range["E2", "E2"];
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
            columna.ColumnWidth = 9;*/

            columna = xlWorksheet.Range["A2", "C" + filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            /*columna = xlWorksheet.Range["E2", "G" + filaAuxiliar2];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["I2", "K" + filaAuxiliar3];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;   */                                           //Borders

            rangeCostos = xlWorksheet.Range["C4", "C99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["F4", "F99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            /*rangeCostos = xlWorksheet.Range["G4", "G99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["K4", "K99"];
            rangeCostos.NumberFormat = "###,##0.00%";*/
             
        }

        public void CreatedContentFileCostosTOTAL(Excel.Worksheet xlWorksheet, OrdenesFinder objfinder, Tienda objTienda, IList<Ventas> lstVentasfile)
        {
            //CostosXEmployee objTiemposCostos1 = new CostosXEmployee();
            /*CostosXEmployee objTiemposCostos2 = new CostosXEmployee();
            CostosXEmployee objTiemposCostos3 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos1 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos2 = new CostosXEmployee();
            CostosXEmployee objTOTALTiemposCostos3 = new CostosXEmployee();
            DateTime Fecha = new DateTime();
            Boolean Bloque1 = false;
            Boolean Bloque2 = false;
            Boolean Bloque3 = false;
            int filaAuxiliar1 = 4, filaAuxiliar2 = 4, filaAuxiliar3 = 4, dias = 0, contador;
            int columnAuxiliar1 = 1, columnAuxiliar2 = 5, columnAuxiliar3 = 9;
            int TotalOrdenes1 = 0, TotalOrdenes2 = 0, TotalOrdenes3 = 0;
            string FullName1 = string.Empty, FullName2 = string.Empty, FullName3 = string.Empty;
            Decimal OrderIdealFoodCost1 = 0, OrderRoyaltySales1 = 0, OrderIdealFoodCost2 = 0, OrderRoyaltySales2 = 0, OrderIdealFoodCost3 = 0, OrderRoyaltySales3 = 0;
            Decimal CostoIdeal = 0;*/
            int filaAuxiliar1 = 4, columnAuxiliar1 = 1, dias = 0;
            Decimal CostoIdeal = 0;

            xlWorksheet.Name = objTienda.Code;

            for (int i = 0; i < 4; i += 4)
            {
                xlWorksheet.Cells[3, 1 + i] = "NUMERO ORDENES";
                xlWorksheet.Cells[3, 2 + i] = "TIENDA";
                xlWorksheet.Cells[3, 3 + i] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[3, 4 + i] = "COSTO";
            }

            //IList<CostosXEmployee> ListEmpleados = SelectEmployeesXStore2(objfinder);  //Between DateIni and DateEnd
            //foreach (CostosXEmployee item in ListEmpleados)
            //{
            //objfinder.Empleado = item.Empleado;
            //objfinder.Order_Date = Fecha;
            IList<CostosXEmployee> LstTiemposCostos = SelectLISTCostXEmBD(objfinder);
            if (LstTiemposCostos.Count > 0)
            {
                foreach (CostosXEmployee objTiemposCostos1 in LstTiemposCostos)
                {
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.Location_Code;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                    xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 3] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                    filaAuxiliar1++;
                }
            }
        
    
                /*TimeSpan betweenDatesSpan = objfinder.DateEnd2.Value.Subtract(objfinder.DateIni2.Value);
                dias = int.Parse(betweenDatesSpan.Days.ToString());
                Fecha = objfinder.DateIni2.Value;
                for (contador = 0; contador <= dias; contador++)
                {
                    objfinder.Order_Date = Fecha;
                    objTiemposCostos1 = SelectCostXEmBD(objfinder);

                    if (objTiemposCostos1 != null)
                    {
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1] = objTiemposCostos1.TotalOrdenes;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 1] = objTiemposCostos1.FullName + objTiemposCostos1.FullName2;
                        xlWorksheet.Cells[filaAuxiliar1, columnAuxiliar1 + 2] = objTiemposCostos1.OrderIdealFoodCost / objTiemposCostos1.OrderRoyaltySales;
                        filaAuxiliar1++;
                    }

                    Fecha = Fecha.AddDays(1);
                }*/
            //}

            foreach (Ventas item in lstVentasfile)
            {
                CostoIdeal += (Decimal)item.VentasReales != 0 ? item.Utilizado / item.VentasReales : 0;
            }
            TimeSpan betweenDatesSpan = objfinder.DateEnd2.Value.Subtract(objfinder.DateIni2.Value);
            dias = int.Parse(betweenDatesSpan.Days.ToString());
            Decimal average = CostoIdeal / (dias + 1);

            xlWorksheet.Cells[3, 7] = "COSTO TOTAL";
            xlWorksheet.Cells[4, 7] = average;


            Excel.Range rangeCostos = xlWorksheet.Range["A1", "K999"];  //HEADERS
            rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rangeCostos = xlWorksheet.Range["A3", "K3"];
            rangeCostos.Rows.WrapText = true;
            rangeCostos.RowHeight = 37;
            rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeCostos = xlWorksheet.Range["A2", "D2"];
            rangeCostos.Merge();
            rangeCostos.Rows.WrapText = true;
            rangeCostos.Value = "DE " + objfinder.DateIni2.Value.ToShortDateString() + " A " + objfinder.DateEnd2.Value.ToShortDateString();
            rangeCostos = xlWorksheet.Range["A2", "K3"];
            rangeCostos.Font.Bold = true;
            rangeCostos.Font.Size = 14;

            Excel.Range columna = xlWorksheet.Range["A2", "A2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 12;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 9;
            columna = xlWorksheet.Range["G2", "G2"];
            columna.ColumnWidth = 23;

            columna = xlWorksheet.Range["A2", "D" + filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            

            rangeCostos = xlWorksheet.Range["D4", "D999"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["G4", "G10"];
            rangeCostos.NumberFormat = "###,##0.00%";
            /*rangeCostos = xlWorksheet.Range["G4", "G99"];
            rangeCostos.NumberFormat = "###,##0.00%";
            rangeCostos = xlWorksheet.Range["K4", "K99"];
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