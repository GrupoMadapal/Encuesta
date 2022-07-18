using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class DQ_VentasDAL
    {
        public static volatile ISqlMapper mapper = null;
        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public DQ_VentasDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapDQ.config", handler);
        }

        public IList<DQ_Ventas> selectDQVentas( DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ventas>("selectDQVentas", param);
        }

        public IList<DQ_Ventas> selectDQVentasTotal(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ventas>("selectDQVentasTotal", param);
        }

        public InfoTiempoReal SelectVentasDQOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectVentasDQOnLine", Param);
        }

        public IList<InfoTiempoReal> SelectVentasDQOnLineTienda(InfoTiempoReal Param)
        {
            return mapper.QueryForList<InfoTiempoReal>("SelectVentasDQOnLineTienda", Param);
        }

        //Commented by Hector Sanchez M. 20180523
        //public IList<DQ_Ventas> SelectVentasDQArticulos(DQ_VentasFinder Param)
        //{
        //    return mapper.QueryForList<DQ_Ventas>("SelectVentasDQArticulos", Param);
        //}

        public DQ_Ventas SelectVentasArtic(DQ_VentasFinder param)
        {
            return mapper.QueryForObject<DQ_Ventas>("SelectVentasArtic", param);
        }

        public DQ_Ventas SelectVentasPasteles(DQ_VentasFinder param)
        {
            return mapper.QueryForObject<DQ_Ventas>("SelectVentasPasteles", param);
        }

        public DQ_Ventas SelectVentasOtros(DQ_VentasFinder param)
        {
            return mapper.QueryForObject<DQ_Ventas>("SelectVentasOtros", param);
        }

        public IList<DQ_Ventas> SelectSalesScreen(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ventas>("SelectSalesScreen", param);
        }

        public IList<DQ_Ventas> SelectSalesScreenTotal(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ventas>("SelectSalesScreenTotal", param);
        }

        public IList<DQ_VentasArticulos> SelectSalesArticles(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_VentasArticulos>("SelectSalesArticles", param);
        }

        public IList<DQ_Ventas> selectDQVentasyOrdenesLineal(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ventas>("selectDQVentasyOrdenesLineal", param);
        }

        public IList<Contabilidad> selectDQContabilidad(DQ_VentasFinder param)
        {
            return mapper.QueryForList<Contabilidad>("selectDQContabilidad", param);
        }

    }
}