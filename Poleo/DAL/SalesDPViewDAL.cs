using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.DataMapper;

namespace Poleo.DAL
{
    public class SalesDPViewDAL
    {
        public ISqlMapper mapper;

        public IList<SalesDP> selectLstSalesDPView(SalesDP param)
        {
            mapper = Mapper.Instance();

            return mapper.QueryForList<SalesDP>("selectLstSalesDPView", param);
        }

        public void insertObjSalesDPView()
        {
            mapper = Mapper.Instance();
            mapper.Insert("insertObjSalesDPView", new object());
        }

        public void deleteSalesDPView()
        {
            mapper = Mapper.Instance();
            mapper.Delete("deleteSalesDPView", new object());
        }
    }
}