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
    public class SEFMotorcyclesDAL
    {
        public static volatile ISqlMapper mapper = null;

        protected static void Configure(object obj)
        {
            mapper = null;
        }

        public SEFMotorcyclesDAL()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch("SqlMapSEFMotorcycles.config", handler);
        }

        public void InsertSEF_Motorcycles(SEF_Motorcycles param)
        {
            mapper.Insert("InsertSEF_Motorcycles", param);
        }

        public IList<SEF_Motorcycles> SelectSerial(string Serial)
        {
            return mapper.QueryForList<SEF_Motorcycles>("SelectSerial", Serial);
        }

        public IList<SEF_Motorcycles> SelectNumEco(SEF_Motorcycles param)
        {
            return mapper.QueryForList<SEF_Motorcycles>("SelectNumEco", param);
        }

        public IList<SEF_Motorcycles> SelectVehicle(SEF_Motorcycles param)
        {
            return mapper.QueryForList<SEF_Motorcycles>("SelectVehicle", param); 
        }

        /*public IList<SEF_Motorcycles> UpdateVehicle(SEF_Motorcycles param)
        {
            return mapper.QueryForList<SEF_Motorcycles>("UpdateVehicle", param);
        }*/

        public void UpdateVehicle(SEF_Motorcycles param)
        {
            mapper.Update("UpdateVehicle", param);
        }
    }
}