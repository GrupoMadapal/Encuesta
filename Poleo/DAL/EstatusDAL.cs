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
    public class EstatusDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public EstatusDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapSEFMotorcycles.config", handler);
        }

        public IList<Estatus> SelectStatus()
        {
            return mapper.QueryForList<Estatus>("SelectStatus", null);
        }
    }
}