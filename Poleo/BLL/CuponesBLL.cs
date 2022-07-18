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
    public class CuponesBLL
    {
        #region BLL
        public string CresteExcelFileCuponesPorc(HttpServerUtility server, VentasFinder objVentasFinder)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            if (xlApp != null)
            {
                Excel.Workbook objWorkBook;
                objWorkBook = xlApp.Workbooks.Add(misValue);

                objWorkBook = GenerateWorksheetsReport(server, objVentasFinder, objWorkBook);
                nombreArchivo = "PorcCupon.xlsx";
                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }
                objWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                objWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(objWorkBook);
            }
            releaseObject(xlApp);

            return nombreArchivo;
        }

        private Excel.Workbook GenerateWorksheetsReport(HttpServerUtility server, VentasFinder objVentasFinder, Excel.Workbook xlWorkbook )
        {
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinderTienda = new Tienda();
            IList<Tienda> lstTienda = new List<Tienda>();

            objFinderTienda.Ubicacion = objVentasFinder.UbicacionTienda;
            objFinderTienda.Tipo = objVentasFinder.TipoTienda;
            objFinderTienda.Number_tienda = objVentasFinder.NumTienda;

            lstTienda = objTiendaBLL.SelectTiendas(objFinderTienda);

            foreach (Tienda objTienda in lstTienda)
            {
                IList<Cupones> lstCupones = new List<Cupones>();
                objVentasFinder.NumTienda = objTienda.Number_tienda;

                lstCupones = SelectOrderCupontPorcentage(objVentasFinder);
                CreatedContentWorksheets(xlWorkbook.Worksheets.Add(), objTienda.Code, lstCupones);
            }

            return xlWorkbook;
        }

        private void CreatedContentWorksheets(Excel.Worksheet xlWorksheet, string code, IList<Cupones> lstCupones)
        {
            xlWorksheet.Cells[2, 1] = "FECHA";
            xlWorksheet.Cells[2, 2] = "CODIGO";
            xlWorksheet.Cells[2, 3] = "DESCRIPCION";
            xlWorksheet.Cells[2, 4] = "TOTAL ORDENES CUPON";
            xlWorksheet.Cells[2, 5] = "TOTAL ORDENES";
            xlWorksheet.Cells[2, 6] = "TOTAL $";
            xlWorksheet.Cells[2, 7] = "% ORDENES CUPON";
            xlWorksheet.Cells[2, 8] = "TOTAL ORDENES MENU";
            xlWorksheet.Cells[2, 9] = "TOTAL DESCUENTO ORDENES";
            xlWorksheet.Cells[2, 10] = "TOTAL ORDENES $";
            xlWorksheet.Cells[2, 11] = "IVA";
            xlWorksheet.Cells[2, 12] = "TOTAL ORDENES $ + IVA";

            if (lstCupones.Count > 0)
            {
                int corX = 3;
                foreach (Cupones objCupones in lstCupones)
                {
                    xlWorksheet.Cells[corX, 1] = objCupones.Ord_Dt;
                    xlWorksheet.Cells[corX, 2] = objCupones.CouponCode;
                    xlWorksheet.Cells[corX, 3] = objCupones.Descripcion;
                    xlWorksheet.Cells[corX, 4] = objCupones.CountOrdenCupon;
                    xlWorksheet.Cells[corX, 5] = objCupones.Order_Count;
                    xlWorksheet.Cells[corX, 6] = objCupones.Net_Sales;
                    xlWorksheet.Cells[corX, 7] = objCupones.PorcOrderCupon;
                    xlWorksheet.Cells[corX, 8] = objCupones.Menu_Amt;
                    xlWorksheet.Cells[corX, 9] = objCupones.Disc_Amt;
                    xlWorksheet.Cells[corX, 10] = objCupones.Net_Amt;
                    xlWorksheet.Cells[corX, 11] = objCupones.Tax_Amt;
                    xlWorksheet.Cells[corX, 12] = objCupones.Cust_Amt;
                    corX++;
                }
            }
            xlWorksheet.Name = code;
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

        //Added by Hector Sanchez M. 20161006
        public void UpdateValidityCupons()
        {
            IList<Cupones> lstCupones = new List<Cupones>();
            Cupones objCupones = new Cupones();

            objCupones.Validity = DateTime.Now;

            lstCupones = SelectListCupones(objCupones);

            foreach (Cupones objCuponesParam in lstCupones)
            {
                objCupones.Active = false;

                UpdateActiveCupon(objCuponesParam);
            }
        }

        //Added by Hector Sanchez M. 20161006
        public void UpdateCupons(StreamReader objStream)
        {
            string line;
            int numLine = 1;
            int length = 0;

            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)
                    length = line.Split('\t').Length;
                else
                {
                    string[] arrayInfo = line.Split('\t');

                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "C2D")
                        {
                            Cupones objCuponesParam = new Cupones();
                            Cupones objCupones = new Cupones();

                            try
                            {
                                objCuponesParam.Codigo = arrayInfo[3];
                                objCuponesParam.Descripcion = arrayInfo[18];
                                objCuponesParam.Validity = !string.IsNullOrEmpty(arrayInfo[13]) ? DateTime.Parse(arrayInfo[13]) : (DateTime?)null;
                                objCuponesParam.Active = true;

                                objCupones = SelectObjCupones(objCuponesParam.Codigo);

                                if (objCupones == null)
                                    InserObjCupon(objCuponesParam);
                                else
                                {
                                    if (objCupones.Validity == null && objCuponesParam.Validity != null)
                                    {
                                        objCupones.Validity = objCuponesParam.Validity;

                                        UpdateObjCupon(objCupones);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
 
                            }
                        }
                    }
                }
                numLine++;
            }
        }
        #endregion

        #region DAL
        public IList<Cupones> SelectOrderCupontPorcentage(VentasFinder finder)
        {
            CuponesDAL dal = new CuponesDAL();
            IList<Cupones> lstCupones = new List<Cupones>();

            lstCupones = dal.SelectOrderCupontPorcentage(finder);

            return lstCupones;
        }

        //Added by Hector Sanchez M. 20161006
        private IList<Cupones> SelectListCupones(Cupones Finder)
        {
            CuponesDAL dal = new CuponesDAL();

            return dal.SelectListCupones(Finder);
        }

        //Added by Hector Sanchez M. 20161007
        private Cupones SelectObjCupones(string Code)
        {
            CuponesDAL dal = new CuponesDAL();
            return dal.SelectObjCupones(Code);
        }

        //Added by Hector Sanchez M- 20161007
        private void UpdateObjCupon(Cupones Param)
        {
            CuponesDAL dal = new CuponesDAL();
            dal.UpdateObjCupon(Param);
        }

        //Added by Hector Sanchez M. 20161006
        private void UpdateActiveCupon(Cupones Param)
        {
            CuponesDAL dal = new CuponesDAL();
            dal.UpdateActiveCupon(Param);
        }
        
        //Added by Hector Sanchez M. 20161007
        private void InserObjCupon(Cupones Param)
        {
            CuponesDAL dal = new CuponesDAL();
            dal.InserObjCupon(Param);
        }

        public IList<Cupones> SelectCuponsByDDL(Cupones Param)
        {
            CuponesDAL dal = new CuponesDAL();

            return dal.SelectCuponsByDDL(Param);
        }
        #endregion
    }
}