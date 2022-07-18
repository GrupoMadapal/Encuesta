using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace Poleo.DAL
{
    public class DOT_VentasDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public DOT_VentasDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            mapper = builder.ConfigureAndWatch("SqlMapDOT.config", handler);
        }

        public InfoTiempoReal SelectVentasDPOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectVentasDPOnLine", Param);
        }

        public IList<InfoTiempoReal> SelectVentasDPOnLineTienda(InfoTiempoReal Param)
        {
            return mapper.QueryForList<InfoTiempoReal>("SelectVentasDPOnLineTienda", Param);
        }

        public InfoTiempoReal GetEntradaHornoStore(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("GetEntradaHornoStore", Param);
        }

        public decimal GetLoadEstimatedDeliveryTime(InfoTiempoReal Param)
        {
            try
            {
                return mapper.QueryForObject<decimal>("GetLoadEstimatedDeliveryTime", Param);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetFreeOrders(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<int>("GetFreeOrders", Param);
        }

        public int GetGetCancelOrders(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<int>("GetGetCancelOrders", Param);
        }

        public decimal? GetTotalDeposit(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<decimal?>("GetTotalDeposit", Param);
        }
    }
}