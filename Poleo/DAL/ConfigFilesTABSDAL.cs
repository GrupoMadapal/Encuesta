using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ConfigFilesTABSDAL
    {
        public ISqlMapper mapper;

        public IList<ConfigFilesTABS> SelectConfigFilesTABs()
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ConfigFilesTABS>("SelectConfigFilesTABs", new ConfigFilesTABS());
        }
    }
}