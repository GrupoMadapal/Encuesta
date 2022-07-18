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
    public class CuponesIncentivosBLL
    {
        public IList<OrderCupons> SelectIncentiveCoupons(VentasFinder param)
        {
            CuponesDAL DAL = new CuponesDAL();
            return DAL.SelectIncentiveCoupons(param);
        }


        ////-----------------///////////////////////////
        ////para la consulta de la cantidades de las ordenes, endonde se encuentra la tabla OrderDump
        ////15-12-2020
        //public IList<OrdersDump> SelectCantidadOrdenes(VentasFinder param)
        //{
        //    CuponesDAL DAL = new CuponesDAL();
        //    return DAL.SelectCantidadOrdenes(param);
        //}
        ////-------/////////////////////

        public string CreateExcelFileIncentiveCoupons1Store(HttpServerUtility server, VentasFinder objVentasFinder, string locationCode)
        {
            String nombreArchivo = string.Empty;
            TiendaBLL objTiendasBLL = new TiendaBLL();
            Excel.Application xlApp = new Excel.Application();
            //object misValue = System.Reflection.Missing.Value;

            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objtienda = new Tienda();
                string temp = locationCode.Substring(0, 1);


                if (temp == "1")//!string.IsNullOrEmpty(objVentasFinder.NumTienda))                       //Only one Store, selected in the DDL
                {
                    objtienda.Code = objVentasFinder.NumTienda = locationCode;

                    this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, objtienda);
                }
                else
                {
                    


                }

                nombreArchivo = "CuponesIncentivos.xlsx";
                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
            }
            releaseObject(xlApp);

            return nombreArchivo;
        }

        public string CreateExcelFileIncentiveCoupons(HttpServerUtility server, VentasFinder objVentasFinder)
        {
            String nombreArchivo = string.Empty;
            TiendaBLL objTiendasBLL = new TiendaBLL();
            Excel.Application xlApp = new Excel.Application();
            string fecharArchivo = string.Empty; //
            //object misValue = System.Reflection.Missing.Value;

            if (xlApp != null)
            {

                
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Tienda objtienda = new Tienda();

              

                if (!string.IsNullOrEmpty(objVentasFinder.NumTienda))                       //Only one Store, selected in the DDL
                {
                    objtienda.Code = objVentasFinder.NumTienda;

                    this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, objtienda);
                }
                else
                {
                    IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objtienda);

                    foreach (Tienda item in lstTiendas)
                    {
                        objVentasFinder.NumTienda = item.Number_tienda;

                        this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, item);  //All of them

                    }

                    Tienda objTiendaSLP = new Tienda()                      //TOTALS
                    {
                        Code = "TOTAL_SLP",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = "San Luis Potosí";
                    this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaSLP);                    

                    
                    Tienda objTiendaTMPS = new Tienda()
                    {
                        Code = "TOTAL_TMPS",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = "Tamaulipas";
                    this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaTMPS);


                    Tienda objTiendaFRANQ = new Tienda()
                    {
                        Code = "FRANQ",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = null;
                    this.CreateReportIncentiveCoupons(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaFRANQ);
                    
                }
                
                nombreArchivo = "CuponesIncentivos.xlsx";
                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
            }
            releaseObject(xlApp);

            return nombreArchivo;
        }

        public void CreateReportIncentiveCoupons(Excel.Worksheet xlWorksheet, VentasFinder objVentasFinder, Tienda objTienda)
        {


            Decimal TotalQtyCHY189 = 0, TotalQtyPQCD = 0, TotalQty2A80 = 0, TotalQtyN2E59 = 0, //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA 
                  TotalQtyPQCD2 = 0, TotalQtyAD89 = 0, TotalQtyDD82 = 0, TotalOrdenes = 0; 
            double TotalSuc = 0;
            
            
            

           
          //  for (int i = 0; i < 200; i += 200)
            // { 
                xlWorksheet.Name = objTienda.Code;

                xlWorksheet.Cells[1, 1] = "TIENDA";
                xlWorksheet.Cells[1, 2] = "TOTAL";
                xlWorksheet.Cells[3, 1] = "";
                xlWorksheet.Cells[5, 1] = "TIENDA";
                xlWorksheet.Cells[5, 2] = "NOMBRE DEL EMPLEADO";
                xlWorksheet.Cells[5, 3] = "2A80";
                //--NUEVOS CAMPOS MODIFICADOS ARIADNA CADENA
                xlWorksheet.Cells[5, 4] = "CHY189";
                xlWorksheet.Cells[5, 5] = "N2E59";
                xlWorksheet.Cells[5, 6] = "PQCD2";
                //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA
                xlWorksheet.Cells[5, 7] = "USG49";
                xlWorksheet.Cells[5, 8] = "AD89";
                xlWorksheet.Cells[5, 9] = "AD892";
                xlWorksheet.Cells[5, 10] = "# DE ORDENES";
                xlWorksheet.Cells[5, 11] = "2A80 $";
                xlWorksheet.Cells[5, 12] = "CHY189 $";
                xlWorksheet.Cells[5, 13] = "N2E59 $";
                xlWorksheet.Cells[5, 14] = "PQCD2 $";
                xlWorksheet.Cells[5, 15] = "USG49 $";
                xlWorksheet.Cells[5, 16] = "AD89 $";
                xlWorksheet.Cells[5, 17] = "AD892 $";
                xlWorksheet.Cells[5, 18] = "% ORDENES TOTAL";
                xlWorksheet.Cells[5, 19] = "$ ORDENES";
                xlWorksheet.Cells[5, 20] = "SE CUMPLE BANDERA";
                
           // }

                objVentasFinder.NumTienda = objTienda.Number_tienda;
            IList<OrderCupons> ListIncentiveCoupons = SelectIncentiveCoupons(objVentasFinder);  //Between DateIni and DateEnd
            int filaAuxiliar1 = 6;
            

           // if (ListIncentiveCoupons.Count > 0)
           // {
                foreach (OrderCupons item in ListIncentiveCoupons)
                {
                   // OrderCupons OrderCouponGotten = getIncentiveItem(ListIncentiveCoupons, item.OrdCpnUpdateUserCode, item.CouponCode, item.Location_Code);

                   

                    xlWorksheet.Cells[filaAuxiliar1, 1] = item.Location_Code;
                    xlWorksheet.Cells[filaAuxiliar1, 2] = item.NombreEmpleado;
                    xlWorksheet.Cells[filaAuxiliar1, 3] = item.Cupon1Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 4] = item.Cupon2Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 5] = item.Cupon3Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 6] = item.Cupon4Quantity;
                    //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA
                    xlWorksheet.Cells[filaAuxiliar1, 7] = item.Cupon5Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 8] = item.Cupon6Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 9] = item.Cupon7Quantity;

                    xlWorksheet.Cells[filaAuxiliar1, 10] =item.Cupon8Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 11] = item.Cupon9Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 12] = item.Cupon11Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 13] = item.Cupon12Quantity;
                    //xlWorksheet.Cells[filaAuxiliar1, 14] = item.Cupon13Quantity;
                    //xlWorksheet.Cells[filaAuxiliar1, 15] = item.Cupon14Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 16] = item.Cupon15Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 17] = item.Cupon16Quantity;
                    xlWorksheet.Cells[filaAuxiliar1, 18] = item.Porcentaje;
                    xlWorksheet.Cells[filaAuxiliar1, 19] = item.Totalcupones;
                    xlWorksheet.Cells[filaAuxiliar1, 20] = item.Cupon17Quantity;
                    xlWorksheet.Cells[2, 1] = item.Location_Code;
                    

                   filaAuxiliar1++;

                   TotalQtyCHY189 += item.Cupon1Quantity;
                   TotalQtyPQCD += item.Cupon2Quantity;  //SE EDITO EL TotalQtyPQCD
                   TotalQty2A80 += item.Cupon3Quantity;
                   TotalQtyN2E59 += item.Cupon4Quantity;
                    //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA
                   TotalQtyPQCD2 += item.Cupon5Quantity;
                   TotalQtyAD89 += item.Cupon6Quantity;
                   TotalQtyDD82 += item.Cupon7Quantity;
                   TotalOrdenes += item.Cupon8Quantity;
                   TotalSuc += item.Cupon18Quantity;
                }
 

                    xlWorksheet.Cells[filaAuxiliar1, 1] = "TOTALES";
                    xlWorksheet.Cells[filaAuxiliar1, 3] = TotalQtyCHY189;
                    xlWorksheet.Cells[filaAuxiliar1, 4] = TotalQtyPQCD;  //SE EDITO EL TotalQtyPQCD
                    xlWorksheet.Cells[filaAuxiliar1, 5] = TotalQty2A80;
                    xlWorksheet.Cells[filaAuxiliar1, 6] = TotalQtyN2E59;
                    //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA
                    xlWorksheet.Cells[filaAuxiliar1, 7] = TotalQtyPQCD2;
                    xlWorksheet.Cells[filaAuxiliar1, 8] = TotalQtyAD89;
                    xlWorksheet.Cells[filaAuxiliar1, 9] = TotalQtyDD82;
                    xlWorksheet.Cells[filaAuxiliar1, 10] = TotalOrdenes;
                    xlWorksheet.Cells[2, 2] = TotalSuc;


                    Excel.Range rangeCostos = xlWorksheet.Range["A1", "T999"];  //HEADERS

                    rangeCostos.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    rangeCostos = xlWorksheet.Range["A1", "T5"];
                    rangeCostos.Font.Bold = true;
                    rangeCostos.Rows.WrapText = true;
                    rangeCostos.Font.Size = 14;
                    rangeCostos.RowHeight = 37;
                    rangeCostos.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    Excel.Range columna = xlWorksheet.Range["A1", "A1"];
                    columna.ColumnWidth = 18;
                    columna = xlWorksheet.Range["B1", "B1"];
                    columna.ColumnWidth = 35;
                    columna = xlWorksheet.Range["C1", "C1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["D1", "D1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["E1", "E1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["F1", "F1"];
                    columna.ColumnWidth = 10;
                    //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA
                    columna = xlWorksheet.Range["G1", "G1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["H1", "H1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["I1", "I1"];
                    columna.ColumnWidth = 10;
                    columna = xlWorksheet.Range["J1", "J1"];
                    columna.ColumnWidth = 18;
                    columna = xlWorksheet.Range["K1", "K1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["L1", "L1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["M1", "M1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["N1", "N1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["O1", "O1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["P1", "P1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["Q1", "Q1"];
                    columna.ColumnWidth = 12;
                    columna = xlWorksheet.Range["R1", "R1"];
                    columna.ColumnWidth = 18;
                    columna = xlWorksheet.Range["S1", "S1"];
                    columna.ColumnWidth = 18;
                    columna = xlWorksheet.Range["T1", "T1"];
                    columna.ColumnWidth = 18;

                    
                    columna = xlWorksheet.Range["A5", "T" + filaAuxiliar1];
                    columna.Borders.Color = Excel.XlRgbColor.rgbBlack;
                    columna = xlWorksheet.Range["A1", "B1"];
                    columna.Borders.Color = Excel.XlRgbColor.rgbBlack;//Borders
                    columna = xlWorksheet.Range["A2", "B2"];
                    columna.Borders.Color = Excel.XlRgbColor.rgbBlack;//Borders
                    columna = xlWorksheet.Range["B2"];
                    columna.NumberFormat = "$ #,##0.00";          //Borders

                

                    //rangeCostos = xlWorksheet.Range["R11", "R999"];
                    //rangeCostos.NumberFormat = "#.#0%";
                      
            //columna = xlWorksheet.Range["R2"];
            //columna.NumberFormat = "% #,##0.00"; 
            //columna = xlWorksheet.Range["K6", "R" + filaAuxiliar2];
            //columna.NumberFormat = "$ #,##0.00";
            //columna = xlWorksheet.Range["L6", "R" + filaAuxiliar3];
            //columna.NumberFormat = "$ #,##0.00";
            /*columna = xlWorksheet.Range["E2", "G" + filaAuxiliar2];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;                                              //Borders
            columna = xlWorksheet.Range["I2", "K" + filaAuxiliar3];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;   */
                    //Borders

                    /*rangeCostos = xlWorksheet.Range["C4", "C99"];
                    rangeCostos.NumberFormat = "###,##0.00%";
                    rangeCostos = xlWorksheet.Range["F4", "F99"];
                    rangeCostos.NumberFormat = "###,##0.00%";*/


          //  }//

           // IList<OrderCupons> ListIncentiveCoupons2 = SelectIncentiveCoupons(objVentasFinder);  //Between DateIni and DateEnd
           // int filaAuxiliar2 = 2;
           //// if (ListIncentiveCoupons.Count > 0)
           //// {
           //     foreach (OrderCupons item in ListIncentiveCoupons2)
           //     {

           //     }
            
        //}

        //private OrderCupons getIncentiveItem(IList<OrderCupons> ListIncentiveCoupons, string user, string Coupon, string Location_Code)
        //{
        //    OrderCupons resul = new OrderCupons();

        //    foreach(OrderCupons item in ListIncentiveCoupons)
        //    {
        //        if (item.Location_Code == Location_Code && item.OrdCpnUpdateUserCode == user && item.CouponCode == Coupon)
        //        {
        //            resul = item;
        //            break;
        //        }
        //    }

        //    return resul;
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