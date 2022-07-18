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
    public class DQ_RankingDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public DQ_RankingDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            mapper = builder.ConfigureAndWatch("SqlMapDQ.config", handler);
        }

        public IList<DQ_Ranking> SelectSalesRanking(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectSalesRanking", param);
        }

        public IList<DQ_Ranking> SelectCakeRanking(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectCakeRanking", param);
        }

        public IList<DQ_Ranking> SelectExtraToppingRanking(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectExtraToppingRanking", param);
        }

        public IList<DQ_Ranking> SelectCosteRanking(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectCosteRanking", param);
        }

        public IList<DQ_Ranking> SelectOrdersRanking(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectOrdersRanking", param);
        }

        public IList<DQ_Ranking> SelectSalesIncrease(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectSalesIncrease", param);
        }

        public IList<DQ_Ranking> SelectOrdersIncrease(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectOrdersIncrease", param);
        }

        public IList<DQ_Ranking> SelectCakeIncrease(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectCakeIncrease", param);
        }

        public IList<DQ_Ranking> SelectTicketProm(DQ_VentasFinder param)
        {
            return mapper.QueryForList<DQ_Ranking>("SelectTicketProm", param);
        }
    }
}