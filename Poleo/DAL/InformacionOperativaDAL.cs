using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class InformacionOperativaDAL
    {
        public ISqlMapper mapper;

        public IList<InformacionOperativa> SelectTiemposPromedio(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<InformacionOperativa>("SelectTiemposPromedio", param);        
        }
        public IList<OrderbyTime> SelectOrderbyTime(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderbyTime>("SelectOrderbyTime", param);
        }
    }
}