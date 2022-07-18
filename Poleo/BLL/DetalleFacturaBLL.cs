using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class DetalleFacturaBLL
    {
        public IList<DetallesFactura> SelectDetallesFactura(DetallesFactura param)
        {
            DetalleFacturaDAL objDetalleFacturaDAL = new DetalleFacturaDAL();
            return objDetalleFacturaDAL.SelectDetallesFactura(param);
        }
        public int InsertDetallesFactura(DetallesFactura param)
        {
            DetalleFacturaDAL objDetalleFacturaDAL = new DetalleFacturaDAL();
            return objDetalleFacturaDAL.InsertDetallesFactura(param);
        }
    }
}