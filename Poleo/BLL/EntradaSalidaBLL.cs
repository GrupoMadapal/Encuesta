using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class EntradaSalidaBLL
    {
        public IList<EntradasSalidas> SelectFacturas(VentasFinder param)
        {
            EntradaSalidaDAL DAL = new EntradaSalidaDAL();
            return DAL.SelectFacturas(param);
        }
        public IList<EntradasSalidas> SelectTotalFacturas(VentasFinder param)
        {
            EntradaSalidaDAL DAL = new EntradaSalidaDAL();
            return DAL.SelectTotalFacturas(param);
        }
    }
}