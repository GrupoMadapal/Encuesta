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
    public class DQ_IndicadorDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public DQ_IndicadorDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapDQ.config", handler);
        }

        public DQ_Indicador SelectSalesWeek(DQ_VentasFinder param)
        {
            return mapper.QueryForObject<DQ_Indicador>("SelectSalesWeek", param);
        }

        public IList<DQ_Indicador> SelectPurchaseInvoice(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Indicador>("SelectPurchaseInvoice", param);
        }

        public DQ_Indicador SelectCosteMerma(DQ_VentasFinder param)
        {
            return mapper.QueryForObject<DQ_Indicador>("SelectCosteMerma", param);
        }

        public IList<DQ_Indicador> SelectSalesDaily(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Indicador>("SelectSalesDaily", param);
        }

        public IList<DQ_Indicador> SelectTopProducts(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Indicador>("SelectTopProducts", param);
        }
    }
}