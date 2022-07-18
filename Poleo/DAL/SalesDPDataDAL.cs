using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.DataMapper;

namespace Poleo.DAL
{
    public class SalesDPDataDAL
    {
        public ISqlMapper mapper;

        public void insertObjSalesDPData(SalesDP param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("insertObjSalesDPData", param);
        }

        public void deleteSalesDPData()
        {
            mapper = Mapper.Instance();
            mapper.Delete("deleteSalesDPData", new object());
        }
    }
}