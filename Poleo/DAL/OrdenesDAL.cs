using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class OrdenesDAL
    {
        public ISqlMapper mapper;
        DomSqlMapBuilder Builder = new DomSqlMapBuilder();
        public IList<OrderDetail> selectOrdenesPorCupon(OrdenesFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderDetail>("selectOrdenesPorCupon", param);
        }
 
    }
}