using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ShcheduleTransferDAL
    {
        public ISqlMapper mapper;
        public IList<ShcheduleTransfer> SelectShcheduleTransfer(ShcheduleTransfer param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ShcheduleTransfer>("SelectShcheduleTransfer", param);
        }
    }
}