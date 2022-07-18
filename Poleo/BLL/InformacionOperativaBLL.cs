using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class InformacionOperativaBLL
    {
        public IList<InformacionOperativa> SelectTiemposPromedio(VentasFinder param)
        {
            InformacionOperativaDAL DAL = new InformacionOperativaDAL();
            return DAL.SelectTiemposPromedio(param);
        }
         public IList<OrderbyTime> SelectOrderbyTime(VentasFinder param)
        {
           InformacionOperativaDAL DAL = new InformacionOperativaDAL();
            return DAL.SelectOrderbyTime(param);
        }
    
    }
}