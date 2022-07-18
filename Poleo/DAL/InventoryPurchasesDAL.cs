using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class InventoryPurchasesDAL
    {
        public ISqlMapper mapper;

        public IList<InventoryPurchasesExtracts> SelectInvoicesQty0(InventoryPurchasesExtracts param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<InventoryPurchasesExtracts>("SelectInvoicesQtyZero", param);
        }

        public void UpdateInvoicesQty0(InventoryPurchasesExtracts param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateInvoicesQtyZero", param);
        }
    }
}