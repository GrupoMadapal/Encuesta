using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class ResumenDiarioBLL
    {
        public IList<ResumenDiario> SelectVentasComidaOrdenes(VentasFinder param)
        {
            ResumenDiarioDAL DAL = new ResumenDiarioDAL();
            return DAL.SelectVentasComidaOrdenes(param);
        }
    }
}