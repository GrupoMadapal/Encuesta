using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class ConfigFilesTABSBLL
    {
        #region DAL
        public IList<ConfigFilesTABS> SelectConfigFilesTABs()
        {
            ConfigFilesTABSDAL dal = new ConfigFilesTABSDAL();
            return dal.SelectConfigFilesTABs();
        }
        #endregion
    }
}