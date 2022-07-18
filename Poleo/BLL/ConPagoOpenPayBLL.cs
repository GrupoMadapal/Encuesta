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
    public class ConPagoOpenPayBLL
    {

        public IList<OrderCupons> SelectOpenPay(VentasFinder param)
        {
            OrdersFreeDAL DAL = new OrdersFreeDAL();
            return DAL.SelectOpenPay(param);
        }
        
    public IList<OrderCupons> SelectPagoUber(VentasFinder param)
        {
            OrdersFreeDAL DAL = new OrdersFreeDAL();
            return DAL.SelectPagoUber(param);
        }


        public String GenerateConPagoOpenPay(VentasFinder objVentasFinder, HttpServerUtility Server, int Year)      
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
                    Ubicacion = objVentasFinder.UbicacionTienda,
                    Tipo = objVentasFinder.TipoTienda

                };

                IList<Tienda> lstTiendas = objTiendasBLL.SelectTiendas(objFinder);
                foreach (Tienda item in lstTiendas)
                {

                    this.CreatesheetOpenPay(xlWorkBook.Worksheets.Add(), objVentasFinder, item, Year);

                }
                Tienda objtienda = new Tienda()
                {
                    Code = "ALL",
                    Number_tienda = string.Empty
                };
                this.CreatesheetOpenPay(xlWorkBook.Worksheets.Add(), objVentasFinder, objtienda, Year);



                DateTime dateAux = DateTime.Now;

                if (objVentasFinder.DateIni != null)
                    fecharArchivo = objVentasFinder.DateIni.Value.Year.ToString() + objVentasFinder.DateIni.Value.Month.ToString() + objVentasFinder.DateIni.Value.Day.ToString();
                else
                    fecharArchivo = dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString();

                nombreArchivo = fecharArchivo + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "OpenPay.xlsx"; //dateAux.Year.ToString() + dateAux.Month.ToString() + dateAux.Day.ToString() + "_" + dateAux.Hour.ToString() + dateAux.Minute.ToString() + "VentasResumen.xlsx";
                xlWorkBook.SaveAs(Server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                //releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }
        public void CreatesheetOpenPay(Excel.Worksheet xlWorksheet, VentasFinder objVentasFinder, Tienda objTienda, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();


            //-------------------PAGOS CON PAYPAL
            xlWorksheet.Name = objTienda.Code;
            Excel.Range rangoHead = xlWorksheet.Range["A1", "C1"];
            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "FECHA";
            xlWorksheet.Cells[1, 3] = "OPENPAY";
            

            rangoHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);


            int TW = objAnioBLL.TotalWeekForYear(Year);

            objVentasFinder.NumTienda = objTienda.Number_tienda;
            //IList<OrderCupons> lstConPagoOpenPay = this.SelectOpenPay(objVentasFinder);

            IList<OrderCupons> lstConPagoOpenPay = new List<OrderCupons>();

            lstConPagoOpenPay = SelectOpenPay(objVentasFinder);

            int it = 2;
            foreach (OrderCupons item in lstConPagoOpenPay)
            {
                xlWorksheet.Cells[it, 1] = item.Location_Code;
                xlWorksheet.Cells[it, 2] = item.Order_Date;
                xlWorksheet.Cells[it, 3] = item.OrderFinalPrice;
                

                it++;
            }


            Excel.Range
            columna = xlWorksheet.Range["C2", "C9999"];
            columna.NumberFormat = "$ #,##0.00";
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 18;
            




            //-------------------PAGOS CON UBER
           
            Excel.Range rangoHead2 = xlWorksheet.Range["E1", "G1"];
            xlWorksheet.Cells[1, 5] = "TIENDA";
            xlWorksheet.Cells[1, 6] = "FECHA";
            xlWorksheet.Cells[1, 7] = "UBER";
            rangoHead2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rangoHead2.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);


            objVentasFinder.NumTienda = objTienda.Number_tienda;
            IList<OrderCupons> lstConPagoUBER = new List<OrderCupons>();

            lstConPagoUBER = SelectPagoUber(objVentasFinder);

            int TW2 = objAnioBLL.TotalWeekForYear(Year);

            int it2 = 2;
            foreach (OrderCupons item in lstConPagoUBER)
            {
                xlWorksheet.Cells[it2, 5] = item.Location_Code;
                xlWorksheet.Cells[it2, 6] = item.Order_Date;
                xlWorksheet.Cells[it2, 7] = item.Pagoconuber;


                it2++;
            }

            Excel.Range
            columna2 = xlWorksheet.Range["G2", "G9999"];
            columna2.NumberFormat = "$ #,##0.00";
            columna2 = xlWorksheet.Range["G2", "G2"];
            columna2.ColumnWidth = 18;
       


            releaseObject(xlWorksheet);
        }



    


        void releaseObject(object obj)
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
