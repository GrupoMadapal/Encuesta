using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class Info_MasterIndBLL
    {
        #region DAL
        public Info_MasterInd SelectObjInfoMasterInd(Info_MasterInd Param) 
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            return dal.SelectObjInfoMasterInd(Param);
        }

        public void InsertInfoMasterInd(Info_MasterInd Param)
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            dal.InsertInfoMasterInd(Param);
        }

        public string SelectInfoMasterFT(Info_MasterInd Param)
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            return dal.SelectInfoMasterFT(Param);
        }

        public string SelectInfoMasterTr(Info_MasterInd Param)
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            return dal.SelectInfoMasterTr(Param);
        }

        public string SelectInfoMasterCm(Info_MasterInd Param)
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            return dal.SelectInfoMasterCm(Param);
        }

        public void UpdateObjInfoMasterInd(Info_MasterInd Param)
        {
            Info_MasterIndDAL dal = new Info_MasterIndDAL();

            dal.UpdateObjInfoMasterInd(Param);
        }
        #endregion
    }
}