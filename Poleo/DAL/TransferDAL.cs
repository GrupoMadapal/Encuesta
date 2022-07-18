using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class TransferDAL
    {
        public ISqlMapper mapper;
        public IList<Transfer> SelectTransfer(Transfer param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Transfer>("SelectTransfer", param);
        }

        public Transfer SelectLastTransfer(Transfer param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Transfer>("SelectLastTransfer",param);
        }

        public void InsertTransfer(Transfer param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertTransfer", param);
        }

        public void UpdateTransfer(Transfer param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateTransfer", param);
        }
    }
}