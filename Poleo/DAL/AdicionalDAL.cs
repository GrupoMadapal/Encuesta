using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class AdicionalDAL
    {
        public ISqlMapper mapper;

        public Adicional SelectAdcCanelazo(VentasFinder finder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Adicional>("SelectAdcCanelazo", finder);
        }
    }
}