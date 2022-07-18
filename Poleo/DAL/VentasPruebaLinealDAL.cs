using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class VentasPruebaLinealDAL
    {
        public ISqlMapper mapper;

        public IList<Ventas> SelectVentasPruebaLineales(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectVentasPruebaLineales", param);
        }

       
    }
}