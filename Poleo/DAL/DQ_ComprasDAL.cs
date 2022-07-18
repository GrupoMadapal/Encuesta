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
    public class DQ_ComprasDAL
    {

        public static volatile ISqlMapper mapper = null;
        protected static void Configure (object obj)
        {
            mapper = null;
        }

        public DQ_ComprasDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapDQ.config", handler);
        }

        public IList<DQ_Compras> SelectComprasHeladoBaseXGalon(DQ_Compras Param)
        {
            return mapper.QueryForList<DQ_Compras>("SelectComprasHeladoBaseXGalon", Param);
        }
    }
}