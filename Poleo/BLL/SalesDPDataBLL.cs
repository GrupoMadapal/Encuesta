using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class SalesDPDataBLL
    {
        #region BLL
        public void LoadInfoSalesDP()
        {
            IList<InfoTiempoReal> lstInfoTiempoReal = new List<InfoTiempoReal>();
            InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
            DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            
            lstTienda = objTiendaBLL.SelectTiendas(new Tienda());

            objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;
            objInfoTiempoRealFinder.LstNumTienda = objTiendaBLL.GetStringNumberStore(lstTienda);

            lstInfoTiempoReal = objDOT_VentasBLL.SelectVentasDPOnLineTienda(objInfoTiempoRealFinder);

            deleteSalesDPData();

            foreach (InfoTiempoReal objInfoTiempoReal in lstInfoTiempoReal)
            {
                SalesDP objSalesDP = new SalesDP();

                try
                {
                    objSalesDP.NumeroTienda = objInfoTiempoReal.NumTienda;
                    objSalesDP.NombreTienda = objInfoTiempoReal.NombreTienda;
                    objSalesDP.VentasReales = objInfoTiempoReal.VentasReales;
                    objSalesDP.VentasAnoPasado = objInfoTiempoReal.SalesLastYear;
                    objSalesDP.PorcVentas = objInfoTiempoReal.PorcSales;
                    objSalesDP.Ordenes = objInfoTiempoReal.Ordenes;
                    objSalesDP.OrdenesGratis = objInfoTiempoReal.OrderFree;
                    objSalesDP.OrdenesCanceladas = objInfoTiempoReal.OrderCancel;
                    objSalesDP.EntradaHorno = objInfoTiempoReal.EntryOven;
                    objSalesDP.TiempoEntrega = objInfoTiempoReal.strDeliverTime;
                    objSalesDP.ClassEH = objInfoTiempoReal.StrClassEH;
                    objSalesDP.ClassTE = objInfoTiempoReal.StrClassED;
                   objSalesDP.TotalDeposito = objInfoTiempoReal.Deposito - objInfoTiempoReal.VentasReales;//Added by Hector Sanchez M. 20171114

                    insertObjSalesDPData(objSalesDP);
                }
                catch (Exception e)
                {
                    LogBLL objLogBLL = new LogBLL();

                    objLogBLL.InsertErrorLog(e.Message);
                }
            }
        }

        public bool ValidLoadInfo()
        {
            IList<ShcheduleTransfer> lstShcheduleTransfer = new List<ShcheduleTransfer>();
            ShcheduleTransferBLL objShcheduleTransferBLL = new ShcheduleTransferBLL();
            ShcheduleTransfer objShcheduleTransferFind = new ShcheduleTransfer();

            objShcheduleTransferFind.TypeWs = "IT";

            lstShcheduleTransfer = objShcheduleTransferBLL.SelectShcheduleTransfer(objShcheduleTransferFind);

            foreach (ShcheduleTransfer objShcheduleTransfer in lstShcheduleTransfer)
            {
                if (objShcheduleTransfer.ScheduleS <= DateTime.Now.TimeOfDay)
                    return true;
            }

            return false;
        }
        #endregion

        #region DAL
        private void insertObjSalesDPData(SalesDP param)
        {
            SalesDPDataDAL dal = new SalesDPDataDAL();

            dal.insertObjSalesDPData(param);
        }

        private void deleteSalesDPData()
        {
            SalesDPDataDAL dal = new SalesDPDataDAL();

            dal.deleteSalesDPData();
        }
        #endregion
    }
}