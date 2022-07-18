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
    public class Ventas_LunesDAL
    {
        public ISqlMapper mapper;

        public IList<Ventas_Lunes> SelectVentasLunes2(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas_Lunes>("SelectVentasLunes2", param);
        }

        public IList<Ventas_Lunes> SelectVentasLunesTotal2(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas_Lunes>("SelectVentasLunesTotal2", param);
        }

        #region OLD 61 POS
        /*public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public Ventas_LunesDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapV.config", handler);
        }        
        //public ISqlMapper mapper;
        public IList<Ventas_Lunes> SelectVentasLunes(VentasFinder param)
        {
            //mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas_Lunes>("SelectVentasLunes", param);
        }

        public IList<Ventas_Lunes> SelectVentasLunesTotal(VentasFinder param)
        {
            //mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas_Lunes>("SelectVentasLunesTotal", param);
        } */
        #endregion
        
       
    }
}