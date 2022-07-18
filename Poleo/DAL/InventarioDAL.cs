using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class InventarioDAL
    {
        public ISqlMapper mapper;
        public IList<Inventario> SelectMasasPizzas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Inventario>("SelectMasasPizzas", param);
        }
        public IList<Inventario> SelectDrink(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Inventario>("SelectDrink", param);
        }
        public IList<Inventario> SelectInventarioInicialFinal(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Inventario>("SelectInventarioInicialFinal", param);
        }
    }
}