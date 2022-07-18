using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class ShcheduleTransferBLL
    {
        #region DAL
        public IList<ShcheduleTransfer> SelectShcheduleTransfer(ShcheduleTransfer param)
        {
            ShcheduleTransferDAL dal = new ShcheduleTransferDAL();
            return dal.SelectShcheduleTransfer(param);
        }
        #endregion
    }
}