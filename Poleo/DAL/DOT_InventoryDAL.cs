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
    public class DOT_InventoryDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public DOT_InventoryDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            mapper = builder.ConfigureAndWatch("SqlMapDOT.config", handler);
        }

        public IList<DOT_Inventory> GetUseInventory(InfoTiempoReal param)
        {
            return mapper.QueryForList<DOT_Inventory>("GetUseInventory", param);
        }
    }
}