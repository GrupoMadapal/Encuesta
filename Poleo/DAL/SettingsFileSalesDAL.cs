using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class SettingsFileSalesDAL
    {
        private ISqlMapper mapper;

        public SettingsFileSales SelectObjSettings(SettingsFileSales param)
        {
            mapper = Mapper.Instance();

            return mapper.QueryForObject<SettingsFileSales>("SelectObjSettingsFileSales", param);
        }

        public void InsertObjSettings(SettingsFileSales param)
        {
            mapper = Mapper.Instance();

            mapper.Insert("InsertObjSettings", param);
        }

        public void UpdateObjSettings(SettingsFileSales param)
        {
            mapper = Mapper.Instance();

            mapper.Update("UpdateObjSettings", param);
        }
    }
}