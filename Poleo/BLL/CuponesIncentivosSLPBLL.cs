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
    public class CuponesIncentivosSLPBLL
    {

        public IList<OrderCupons> SelectIncentiveCouponsSLP(VentasFinder param)
        {
            CuponesDAL DAL = new CuponesDAL();
            return DAL.SelectIncentiveCouponsSLP(param);
        }

        public string CreateExcelFileIncentiveCoupons1StoreSLP(HttpServerUtility server, VentasFinder objVentasFinder, string locationCode)
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

                    this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, objtienda);
                }
                else
                {



                }

                nombreArchivo = "Cupones Incentivos San Luis Potospí.xlsx";
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

        public string CreateExcelFileCouponsSLP(HttpServerUtility server, VentasFinder objVentasFinder)
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

                    this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, objtienda);
                }
                else
                {
                    IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objtienda);

                    foreach (Tienda item in lstTiendas)
                    {
                        objVentasFinder.NumTienda = item.Number_tienda;

                        this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, item);  //All of them

                    }

                    Tienda objTiendaSLP = new Tienda()                      //TOTALS
                    {
                        Code = "TOTAL_SLP",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = "San Luis Potosí";
                    this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaSLP);


                    Tienda objTiendaTMPS = new Tienda()
                    {
                        Code = "TOTAL_TMPS",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = "Tamaulipas";
                    this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaTMPS);



                    Tienda objTiendaFRANQ = new Tienda()
                    {
                        Code = "FRANQ",
                        Number_tienda = string.Empty
                    };
                    objVentasFinder.NumTienda = null;
                    objVentasFinder.UbicacionTienda = null;
                    this.CreateReportCouponsSLP(xlWorkBook.Worksheets.Add(), objVentasFinder, objTiendaFRANQ);

                }

                nombreArchivo = "Cupones Incentivos.xlsx";
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


        public void CreateReportCouponsSLP(Excel.Worksheet xlWorksheet, VentasFinder objVentasFinder, Tienda objTienda)
        {

            //Decimal TotalQty2A80 = 0, TotalQtyN2E59 = 0, TotalCANTORD = 0, TotalQty2A80P = 0, //--NUEVOS CAMPOS AGREGADOS ARIADNA CADENA 
            //    TotalADIC = 0, TotalQtyN2E59P = 0, TotalQtyDD82 = 0, TotalOrdenes = 0;
            double TotalSuc = 0;

            xlWorksheet.Name = objTienda.Code;

            // xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 1] = "TOTAL";
            xlWorksheet.Cells[3, 1] = "";
            xlWorksheet.Cells[5, 1] = "PORCENTAJE 2X99";
            xlWorksheet.Cells[5, 2] = "TIENDA";
            xlWorksheet.Cells[5, 3] = "NÚMERO DE EMPLEADO";
            xlWorksheet.Cells[5, 4] = "NOMBRE DEL EMPLEADO";
            xlWorksheet.Cells[5, 5] = "CANTIDAD DE ORDENES";
            xlWorksheet.Cells[5, 6] = "CUPON-2X99";
            xlWorksheet.Cells[5, 7] = "CUPON-FAV199";
            xlWorksheet.Cells[5, 8] = "CUPON-FAVE UP SALE";
            xlWorksheet.Cells[5, 9] = "CUPON-PAQ239";
            xlWorksheet.Cells[5, 10] = "CUPON-PAQ279";
            xlWorksheet.Cells[5, 11] = "ADICIONALES SIN CUPÓN";
            xlWorksheet.Cells[5, 12] = "2X99 $";
            xlWorksheet.Cells[5, 13] = "FAV199 $";
            xlWorksheet.Cells[5, 14] = "FAVE UP SALE $";
            xlWorksheet.Cells[5, 15] = "PAQ239 $";
            xlWorksheet.Cells[5, 16] = "PAQ279 $";
            xlWorksheet.Cells[5, 17] = "ADICIONALES $";
            //xlWorksheet.Cells[5, 9] = "CUPON-OG139";
            //xlWorksheet.Cells[5, 10] = "2A80 $";
            //xlWorksheet.Cells[5, 11] = "N2E59 $";
            //xlWorksheet.Cells[5, 12] = "ADICIONALES $";
            //xlWorksheet.Cells[5, 13] = "OG139 $";
            xlWorksheet.Cells[5, 18] = "PORCENTAJE";
            xlWorksheet.Cells[5, 19] = "TOTAL CUPONES";
            xlWorksheet.Cells[5, 20] = "SE CUMPLE BANDERA";


            objVentasFinder.NumTienda = objTienda.Number_tienda;
            IList<OrderCupons> ListIncentiveCouponsSLP = SelectIncentiveCouponsSLP(objVentasFinder);  //Between DateIni and DateEnd
            int filaAuxiliar1 = 6;

            foreach (OrderCupons item in ListIncentiveCouponsSLP)
            {

                xlWorksheet.Cells[filaAuxiliar1, 1] = item.Porcentaje2a80;
                xlWorksheet.Cells[filaAuxiliar1, 2] = item.Location_Code;
                xlWorksheet.Cells[filaAuxiliar1, 3] = item.Num_Empleado;
                xlWorksheet.Cells[filaAuxiliar1, 4] = item.NombreEmpleado;
                xlWorksheet.Cells[filaAuxiliar1, 5] = item.Cantidad_Ordenes;
                xlWorksheet.Cells[filaAuxiliar1, 6] = item.Cupon1Qn;
                xlWorksheet.Cells[filaAuxiliar1, 7] = item.Cupon2Qn;
                xlWorksheet.Cells[filaAuxiliar1, 8] = item.Cupon3Qn;
                xlWorksheet.Cells[filaAuxiliar1, 9] = item.Cupon5Qn;
                xlWorksheet.Cells[filaAuxiliar1, 10] = item.Cupon6Qn;
                xlWorksheet.Cells[filaAuxiliar1, 11] = item.Adicionales;
                xlWorksheet.Cells[filaAuxiliar1, 12] = item.Cupon1extra;
                xlWorksheet.Cells[filaAuxiliar1, 13] = item.Cupon2extra;
                xlWorksheet.Cells[filaAuxiliar1, 14] = item.Cupon3extra;
                xlWorksheet.Cells[filaAuxiliar1, 15] = item.Cupon5extra;
                xlWorksheet.Cells[filaAuxiliar1, 16] = item.Cupon6extra;
                xlWorksheet.Cells[filaAuxiliar1, 17] = item.AdicionalesPesos;
                xlWorksheet.Cells[filaAuxiliar1, 18] = item.Porcentaje;
                xlWorksheet.Cells[filaAuxiliar1, 19] = item.Totalcupones;
                xlWorksheet.Cells[filaAuxiliar1, 20] = item.BANDERAOK;

              //  xlWorksheet.Cells[2, 1] = item.Location_Code;


                filaAuxiliar1++;

            //    TotalCANTORD += item.Cantidad_Ordenes;
            //    TotalQty2A80 += item.Cupon2A80;
            //    TotalQtyN2E59 += item.CuponN2E59;  //SE EDITO EL TotalQtyPQCD             
            //    TotalADIC += item.Adicionales;
            //    //TotalQty2A80P += item.Cupon2a80xextra;
            //    //TotalQtyN2E59P += item.CuponN2E59xextra;
            //    TotalQtyDD82 += item.AdicionalesPesos;
            //   // TotalOrdenes += item.Totalcupones;
              TotalSuc += item.BANDERAOK;
            }

            xlWorksheet.Cells[2, 1] = TotalSuc;


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
            
            columna = xlWorksheet.Range["C1", "C1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["D1", "D1"];
            columna.ColumnWidth = 40;
            columna = xlWorksheet.Range["E1", "E1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["F1", "F1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["G1", "G1"];
            columna.ColumnWidth = 18;         
            columna = xlWorksheet.Range["H1", "H1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["I1", "I1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["J1", "J1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["K1", "K1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["L1", "L1"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["M1", "M1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["N1", "N1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["O1", "O1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["P1", "P1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["Q1", "Q1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["R1", "R1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["S1", "S1"];
            columna.ColumnWidth = 20;
            columna = xlWorksheet.Range["T1", "T1"];
            columna.ColumnWidth = 20;




            columna = xlWorksheet.Range["A5", "T" + filaAuxiliar1];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;
            columna = xlWorksheet.Range["A1"];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;//Borders
            columna = xlWorksheet.Range["A2"];
            columna.Borders.Color = Excel.XlRgbColor.rgbBlack;//Borders                                                  //
            columna = xlWorksheet.Range["A2"];
            columna.NumberFormat = "$ #,##0.00";
        
        
        
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