
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class FacturasDAL
    {
        public ISqlMapper mapper;
        public IList<Facturas> SelectFactura(Facturas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Facturas>("SelectFactura", param);
        }
        public int InsertFacturas(Facturas param)
        {
            mapper = Mapper.Instance();
            return (int)mapper.Insert("InsertFacturas", param);
        }
        public IList<Facturas> SelectFacturaChange( FacturasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Facturas>("SelectFacturaChange", param);
        }
        public void UpdateFacturas(Facturas PARAM)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateFacturas", PARAM);
        }
        public IList<Facturas> SelectFacturastoChange(Facturas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Facturas>("SelectFacturastoChange", param);
        }
    }
}