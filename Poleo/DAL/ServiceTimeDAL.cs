using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class ServiceTimeDAL
    {
        public ISqlMapper mapper;
        
        public IList<ServiceTime> SelectLoadWaitOutEstimated(VentasFinder objFinder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ServiceTime>("SelectLoadWaitOutEstimated", objFinder);
        }
    }
}