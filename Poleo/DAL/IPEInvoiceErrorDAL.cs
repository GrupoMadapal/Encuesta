using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class IPEInvoiceErrorDAL
    {
        public ISqlMapper mapper;

        public void InsertIPEInvoiceError(IPEInvoiceError param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertIPEInvoiceError", param);
        }
    }
}