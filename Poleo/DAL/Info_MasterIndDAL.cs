using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.DataMapper;

namespace Poleo.DAL
{
    public class Info_MasterIndDAL
    {
        #region DAL
        public ISqlMapper mapper;

        public Info_MasterInd SelectObjInfoMasterInd(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Info_MasterInd>("SelectObjInfoMasterInd", param);
        }

        public void InsertInfoMasterInd(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertInfoMasterInd", param);
        }

        public string SelectInfoMasterFT(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<string>("SelectInfoMasterFT", param);
        }

        public string SelectInfoMasterTr(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<string>("SelectInfoMasterTr", param);
        }

        public string SelectInfoMasterCm(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<string>("SelectInfoMasterCm", param);
        }

        public void UpdateObjInfoMasterInd(Info_MasterInd param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateObjInfoMasterInd", param);
        }
        #endregion
    }
}