using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class DOT_VentasBLL
    {
        #region DAL
        public InfoTiempoReal SelectVentasDPOnLine(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.SelectVentasDPOnLine(Param);
        }

        public IList<InfoTiempoReal> SelectVentasDPOnLineTienda(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.SelectVentasDPOnLineTienda(Param);
        }

        public InfoTiempoReal GetEntradaHornoStore(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.GetEntradaHornoStore(Param);
        }

        public decimal GetLoadEstimatedDeliveryTime(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.GetLoadEstimatedDeliveryTime(Param);
        }

        public int GetFreeOrders(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.GetFreeOrders(Param);
        }

        public int GetGetCancelOrders(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.GetGetCancelOrders(Param);
        }

        public decimal? GetTotalDeposit(InfoTiempoReal Param)
        {
            DOT_VentasDAL dal = new DOT_VentasDAL();

            return dal.GetTotalDeposit(Param);
        }
        #endregion
    }
}