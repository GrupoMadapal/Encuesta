using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class PizzasDAL
    {
        public ISqlMapper mapper;
        public IList<Pizzas> SelectPizzas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectPizzas", param);

        }
        public IList<Pizzas> SelectPizzasMaestro(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectPizzasMaestro", param);

        }
        public IList<Pizzas> SelectProductos(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectProductos", param);

        }
        public IList<Pizzas> SelectComplementos(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectComplementos", param);
        }
        public IList<Pizzas> SelectCupones(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectCupones", param);
        }
        public IList<Pizzas> SelectCupones2(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Pizzas>("SelectCupones2", param);
        }
    }
}