using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class DetalleFacturaDAL
    {
        public ISqlMapper mapper;
        public IList<DetallesFactura> SelectDetallesFactura(DetallesFactura param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<DetallesFactura>("SelectDetallesFactura", param);
        }
        public int InsertDetallesFactura(DetallesFactura param)
        {
            mapper = Mapper.Instance();
            return (int)mapper.Insert("InsertDetallesFactura", param);
        }
    }
    
}