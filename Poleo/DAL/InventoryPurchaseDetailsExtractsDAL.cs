using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;


namespace Poleo.DAL
{
    public class InventoryPurchaseDetailsExtractsDAL
    {

        public ISqlMapper mapper;

        public IList<InventoryPurchaseDetailsExtracts> SelectReporteCompras(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<InventoryPurchaseDetailsExtracts>("SelectReporteCompras", param);
        }
    }
}