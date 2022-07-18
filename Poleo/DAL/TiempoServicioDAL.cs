using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class TiempoServicioDAL
    {
        public ISqlMapper mapper;
        public IList<TiempoServicio> SelectTiempoServicio(VentasFinder objFinder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<TiempoServicio>("SelectTiempoServicio", objFinder);
        }
    }
}