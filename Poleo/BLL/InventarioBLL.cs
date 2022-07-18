using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class InventarioBLL
    {
        public IList<Inventario> SelectMasasPizzas(VentasFinder Param)
        {
            InventarioDAL DAL = new InventarioDAL();
            return DAL.SelectMasasPizzas(Param);
        }
        public IList<Inventario> SelectDrink(VentasFinder param)
        {
            InventarioDAL DAL = new InventarioDAL();
            return DAL.SelectDrink(param);
        }
        public IList<Inventario> SelectInventarioInicialFinal(VentasFinder param)
        {
            InventarioDAL DAL = new InventarioDAL();
            return DAL.SelectInventarioInicialFinal(param);
        }
    }
}