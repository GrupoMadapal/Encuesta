using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class ComplementosBLL
    {
        public IList<Complementos> Selectcomplementos(VentasFinder param)
        {
            ComplementosDAL DAL = new ComplementosDAL();
            return DAL.Selectcomplementos(param);
        }
    }
}