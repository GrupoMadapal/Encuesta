using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class OrdersDumpDAL
    {
        public ISqlMapper mapper;

        public void InsertOrdersDump(OrdersDump param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertOrdersDump", param);
        }
    }
}