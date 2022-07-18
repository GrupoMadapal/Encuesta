using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class EntradaSalidaDAL
    {
        public ISqlMapper mapper;
        public IList<EntradasSalidas> SelectFacturas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<EntradasSalidas>("SelectFacturas",param);
        }

        public IList<EntradasSalidas> SelectTotalFacturas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<EntradasSalidas>("SelectTotalFacturas", param);
        }
    }
}