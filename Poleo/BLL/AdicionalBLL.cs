using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Poleo.BLL
{
    public class AdicionalBLL
    {
        #region BLL
        public string GenerateFileCanelazos(VentasFinder finder, HttpServerUtility server)
        {
            #region propiedades excel
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            //xlWorkBook = xlApp.Workbooks.Add(misValue);
            string nombreArchivo = string.Empty;
            string nombreLayout = "InfoCanelazoLayout.xlsx";
            string urlLayout = server.MapPath("/Layout") + "/" + nombreLayout;
            #endregion

            #region Filtro Tienda
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objTienda = new Tienda();

            objTienda.Ubicacion = finder.UbicacionTienda;
            objTienda.Tipo = finder.TipoTienda;
            objTienda.Number_tienda = finder.NumTienda;

            lstTienda = objTiendaBLL.SelectTiendas(objTienda);
            #endregion
            
            IList<Adicional> lstAdicional = new List<Adicional>();

            foreach (Tienda FindTienda in lstTienda)
            {
                Adicional objAdicional = new Adicional();

                finder.NumTienda = FindTienda.Number_tienda;

                objAdicional = SelectAdcCanelazo(finder);

                if (objAdicional != null)
                {
                    lstAdicional.Add(objAdicional);
                }
            }

            if (File.Exists(urlLayout))
            {
                xlWorkBook = xlApp.Workbooks.Open(urlLayout,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                if (lstAdicional.Count > 0)
                {
                    CreatedContentFileAdc(xlWorkBook.Worksheets.get_Item(1), lstAdicional);
                    CreatedContentFileAdcPMC(xlWorkBook.Worksheets.get_Item(2), lstAdicional);
                }

                nombreArchivo = "Canelazo.xlsx";

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

        private void CreatedContentFileAdc(Excel.Worksheet xlWorksheet, IList<Adicional> lstAdicional)
        {
            int Xpos = 4, YPos = 1;
            foreach (Adicional objAdicional in lstAdicional)
            {
                xlWorksheet.Cells[Xpos, YPos] = objAdicional.Nombre_tienda;
                xlWorksheet.Cells[Xpos, YPos + 1] = objAdicional.Location_Code;
                xlWorksheet.Cells[Xpos, YPos + 2] = objAdicional.Quantity;

                Xpos++;
            }

            releaseObject(xlWorksheet);
        }

        private void CreatedContentFileAdcPMC(Excel.Worksheet xlWorksheet, IList<Adicional> lstAdicional)
        {
            decimal TotalC = 0;

            foreach (Adicional objAdicional in lstAdicional)
            {
                TotalC += objAdicional.Quantity;
            }

            xlWorksheet.Cells[13, 5] = TotalC.ToString();

            releaseObject(xlWorksheet);
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
        #endregion

        #region DAL
        public Adicional SelectAdcCanelazo(VentasFinder finder)
        {            
            AdicionalDAL dal = new AdicionalDAL();

            Adicional objAdicional = new Adicional();

            objAdicional = dal.SelectAdcCanelazo(finder);

            return objAdicional;
        }
        #endregion
    }
}