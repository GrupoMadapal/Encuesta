using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class LogDAL
    {
        public ISqlMapper mapper;

        public void InsertLog(Log param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertLog", param);
        }
    }
}