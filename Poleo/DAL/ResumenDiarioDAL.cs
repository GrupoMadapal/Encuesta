using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using  Poleo.Objects;

namespace Poleo.DAL
{
    public class ResumenDiarioDAL
    {
        public ISqlMapper mapper;
        public IList<ResumenDiario> SelectVentasComidaOrdenes(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ResumenDiario>("SelectVentasComidaOrdenes", param);             
        }
    }
}