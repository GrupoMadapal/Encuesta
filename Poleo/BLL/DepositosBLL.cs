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

namespace Poleo.BLL
{
    // ADDED AT 20150811
    public class DepositosBLL
    {
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
        public String generateFileVentas(VentasFinder objfinder, HttpServerUtility server)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            VentasBLL objVentasBLL = new VentasBLL();
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
                    IList<DepositoYTransacciones> lstDepositos = objVentasBLL.SelectDepositosYTransacciones(objfinder);
                    if (lstDepositos.Count > 0)
                    {
                        this.CreatedContentFileVentas(xlWorkBook.Worksheets.Add(), objfinder, item, lstDepositos);
                    }

                }

                DateTime dateAux = DateTime.Now;
                nombreArchivo = "Transacciones.xlsx";
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
        public void CreatedContentFileVentas(Excel.Worksheet xlWorksheet, VentasFinder objfinder, Tienda objTienda, IList<DepositoYTransacciones> lstDepositos)
        {
            xlWorksheet.Name = objTienda.Code;
            int numeroSemana = 0;
            int Xpos=0, YPos = -3;
            AnioBLL objAnioBLL = new AnioBLL();

            int TW = objAnioBLL.TotalWeekForYear(objfinder.SelectYear.Value);

            foreach(DepositoYTransacciones item in lstDepositos)
            {
                if(numeroSemana!=item.NumSemana)
                {
                    int numSem = item.NumSemana;

                    if (TW == 53)
                        numSem--;

                    Xpos = 4;
                    YPos +=4;
                    numeroSemana = item.NumSemana;
                    xlWorksheet.Cells[Xpos, YPos + 1] = " # SEMANA";
                    xlWorksheet.Cells[Xpos, YPos + 2] = numSem;//item.NumSemana-1;
                    Xpos++;
                    xlWorksheet.Cells[Xpos, YPos + 1] = "FECHA";
                    xlWorksheet.Cells[Xpos, YPos + 2] = "DESCRIPCION";
                    xlWorksheet.Cells[Xpos, YPos + 3] = "TOTAL";
                    xlWorksheet.Cells[Xpos, YPos + 4] = "COMENTARIOS";
                    xlWorksheet.Cells[Xpos, YPos + 5] = "NÚM FACTURA";
                    Xpos++;
                }
                xlWorksheet.Cells[Xpos, YPos + 1] = item.Fecha;
                xlWorksheet.Cells[Xpos, YPos + 2] = item.Tipo;
                xlWorksheet.Cells[Xpos, YPos + 3] = item.Total;
                xlWorksheet.Cells[Xpos, YPos + 4] = item.Comentarios;
                xlWorksheet.Cells[Xpos, YPos + 5] = item.NumFactura;

                Xpos++;
            }


            releaseObject(xlWorksheet);
        }
    }
}