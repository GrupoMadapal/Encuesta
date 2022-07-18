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
    public class SEF_VentasDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public SEF_VentasDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapSEF.config", handler);
        }

        public InfoTiempoReal SelectVentasSEFOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectVentasSEFOnLine", Param);
        }

        public InfoTiempoReal SelectCobrosSEFOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectCobrosSEFOnLine", Param);
        }

        public InfoTiempoReal SelectVentasRAALOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectVentasRAALOnLine", Param);
        }

        public InfoTiempoReal SelectCobrosRAALOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectCobrosRAALOnLine", Param);
        }

        public InfoTiempoReal SelectVentasMADAPALOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectVentasMADAPALOnLine", Param);
        }

        public InfoTiempoReal SelectCobrosMADAPALOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectCobrosMADAPALOnLine", Param);
        }

        public InfoTiempoReal SelectCanceladoSEFOnLine(InfoTiempoReal Param)
        {
            return mapper.QueryForObject<InfoTiempoReal>("SelectCanceladoSEFOnLine", Param);
        }

        public IList<Contabilidad> selectDQContabilidad(DQ_VentasFinder param)
        {
            return mapper.QueryForList<Contabilidad>("selectDQContabilidad", param);
        }

        public IList<ContabilidadDP> SelectDPContabilidad(Date param)
        {
            return mapper.QueryForList<ContabilidadDP>("SelectDPContabilidad", param);
        }
    }
}