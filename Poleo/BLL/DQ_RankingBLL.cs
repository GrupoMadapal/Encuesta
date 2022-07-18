using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Poleo.BLL
{
    public class DQ_RankingBLL
    {
        #region BLL
        public string CreateFileRanking(DQ_VentasFinder objDQ_VentasFinder, HttpServerUtility server)
        {
            string NameFile = "DQRanking.xlsx";
            string NameLayout = "RankingLayout.xlsx";
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

                    CreateContenFileRanking(xlWorkbook.Worksheets.get_Item(1), objDQ_VentasFinder);

                    if (File.Exists(strFile))
                        File.Delete(strFile);

                    xlWorkbook.SaveAs(strFile, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    releaseObject(xlWorkbook);
                }

                releaseObject(xlApp);
            }

            return NameFile;
        }

        private void CreateContenFileRanking(Excel.Worksheet objWorksheet, DQ_VentasFinder objDQ_VentasFinder)
        {

            objWorksheet.Cells[2, 11] = "SEMANA " + objDQ_VentasFinder.NumWeek;
            objWorksheet.Cells[2,1] = objDQ_VentasFinder.SelectYear;

            int SXPos = 5, SYPos = 2, c = 0;

            IList<DQ_Ranking> lstDQ_Ranking = new List<DQ_Ranking>();

            #region VENTAS
            IList<DQ_Ranking> lstDQ_RankingSales = new List<DQ_Ranking>();
            
            lstDQ_RankingSales = SelectSalesRanking(objDQ_VentasFinder);
            /*
            DQ_Ranking TEMPORAL_DQ_VALLES = new DQ_Ranking();
            TEMPORAL_DQ_VALLES.NameStore = "DQ Valles";
            TEMPORAL_DQ_VALLES.RealSales = 0;
            lstDQ_RankingSales.Add(TEMPORAL_DQ_VALLES);  */
            

            if (lstDQ_RankingSales.Count > 0)
            {
                foreach (DQ_Ranking item in lstDQ_RankingSales)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos +1] = item.RealSales;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData.NameStore = item.NameStore;
                    objDQ_RankingData.Position = c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region COSTE
            IList<DQ_Ranking> lstDQ_RankingCoste = new List<DQ_Ranking>();

            lstDQ_RankingCoste = SelectCosteRanking(objDQ_VentasFinder);

            if (lstDQ_RankingCoste.Count > 0)
            {
                SXPos = 5;
                SYPos = 6;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingCoste)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.CostePor;
                    objWorksheet.Cells[SXPos, SYPos + 2] = item.Coste;

                    SXPos++;
                    c++;
                    
                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);//lstDQ_RankingCoste.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region PASTELES
            IList<DQ_Ranking> lstDQ_RankingCake = new List<DQ_Ranking>();

            lstDQ_RankingCake = SelectCakeRanking(objDQ_VentasFinder);

            if (lstDQ_RankingCake.Count > 0)
            {
                SXPos = 5;
                SYPos = 11;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingCake)
                {
                    DQ_Ranking objDQ_RankingSales = new DQ_Ranking();

                    objDQ_RankingSales = lstDQ_RankingSales.FirstOrDefault(p => p.NameStore == item.NameStore);//.Contains(new DQ_Ranking { NameStore = item.NameStore });

                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.TotalCake;
                    objWorksheet.Cells[SXPos, SYPos + 2] = objDQ_RankingSales.RealSales > 0 ? item.TotalSalesCake / objDQ_RankingSales.RealSales : 0;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region EXTRATOPPING
            IList<DQ_Ranking> lstDQ_RankingExtra = new List<DQ_Ranking>();

            lstDQ_RankingExtra = SelectExtraToppingRanking(objDQ_VentasFinder);

            if (lstDQ_RankingExtra.Count > 0)
            {
                SXPos = 5;
                SYPos = 16;
                c = 0;
                

                foreach (DQ_Ranking item in lstDQ_RankingExtra)
                {
                    DQ_Ranking objDQ_RankingSales = new DQ_Ranking();

                    objDQ_RankingSales = lstDQ_RankingSales.FirstOrDefault(p => p.NameStore == item.NameStore);

                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.ExtraToppingPce;
                    objWorksheet.Cells[SXPos, SYPos + 2] = item.ExtraTopping;
                 

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region ORDENES
            IList<DQ_Ranking> lstDQ_RankingOrder = new List<DQ_Ranking>();

            lstDQ_RankingOrder = SelectOrdersRanking(objDQ_VentasFinder);

            if (lstDQ_RankingOrder.Count > 0)
            {
                SXPos = 5;
                SYPos = 21;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingOrder)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.Orders;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region CRECIMIENTO VENTAS
            IList<DQ_Ranking> lstDQ_RankingSalesIncreace = new List<DQ_Ranking>();

            lstDQ_RankingSalesIncreace = SelectSalesIncrease(objDQ_VentasFinder);

            if (lstDQ_RankingSalesIncreace.Count > 0)
            {
                SXPos = 18;
                SYPos = 2;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingSalesIncreace)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.IncreaseSales;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region CRECIMIENTO ORDENES
            IList<DQ_Ranking> lstDQ_RankingOrderIncrease = new List<DQ_Ranking>();

            lstDQ_RankingOrderIncrease = SelectOrdersIncrease(objDQ_VentasFinder);

            if (lstDQ_RankingOrderIncrease.Count > 0)
            {
                SXPos = 18;
                SYPos = 6;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingOrderIncrease)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.IncreaseOrder;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion

                }
            }
            #endregion

            #region CCRECIMIENTO PASTELES
            IList<DQ_Ranking> lstDQ_RankingCakeIncrease = new List<DQ_Ranking>();

            lstDQ_RankingCakeIncrease = SelectCakeIncrease(objDQ_VentasFinder);

            if (lstDQ_RankingCakeIncrease.Count > 0)
            {
                SXPos = 18;
                SYPos = 11;
                c = 0;

                foreach (DQ_Ranking item in lstDQ_RankingCakeIncrease)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.IncreaseCake;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region TICKET PROMEDIO
            IList<DQ_Ranking> lstDQ_RankingTicket = new List<DQ_Ranking>();

            lstDQ_RankingTicket = SelectTicketProm(objDQ_VentasFinder);

            if(lstDQ_RankingTicket.Count >0)
            {
                SXPos = 18;
                SYPos = 16;
                c = 0;

                foreach(DQ_Ranking item in lstDQ_RankingTicket)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.TicketPromedio;

                    SXPos++;
                    c++;

                    #region ACOMULADO
                    DQ_Ranking objDQ_RankingData = new DQ_Ranking();

                    objDQ_RankingData = lstDQ_Ranking.FirstOrDefault(p => p.NameStore == item.NameStore);

                    lstDQ_Ranking.Remove(objDQ_RankingData);

                    objDQ_RankingData.Position += c;

                    lstDQ_Ranking.Add(objDQ_RankingData);
                    #endregion
                }
            }
            #endregion

            #region RANCKING ACOMULADO
            if (lstDQ_Ranking.Count > 0)
            {
                SXPos = 31;
                SYPos = 2;

                lstDQ_Ranking = lstDQ_Ranking.OrderBy(p => p.Position).ToList();

                foreach (DQ_Ranking item in lstDQ_Ranking)
                {
                    objWorksheet.Cells[SXPos, SYPos] = item.NameStore;
                    objWorksheet.Cells[SXPos, SYPos + 1] = item.Position;

                    SXPos++;
                }
            }
            #endregion

            releaseObject(objWorksheet);
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
        public IList<DQ_Ranking> SelectSalesRanking(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectSalesRanking(param);
        }

        public IList<DQ_Ranking> SelectCakeRanking(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectCakeRanking(param);
        }

        public IList<DQ_Ranking> SelectExtraToppingRanking(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectExtraToppingRanking(param);
        }

        public IList<DQ_Ranking> SelectCosteRanking(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectCosteRanking(param);
        }

        public IList<DQ_Ranking> SelectOrdersRanking(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectOrdersRanking(param);
        }

        public IList<DQ_Ranking> SelectSalesIncrease(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectSalesIncrease(param);
        }

        public IList<DQ_Ranking> SelectOrdersIncrease(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectOrdersIncrease(param);
        }

        public IList<DQ_Ranking> SelectCakeIncrease(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectCakeIncrease(param);
        }

        public IList<DQ_Ranking> SelectTicketProm(DQ_VentasFinder param)
        {
            DQ_RankingDAL dal = new DQ_RankingDAL();

            return dal.SelectTicketProm(param);
        }
        #endregion
    }
} 