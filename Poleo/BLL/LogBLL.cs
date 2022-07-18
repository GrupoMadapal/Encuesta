using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;
using System.Configuration;

namespace Poleo.BLL
{
    public class LogBLL
    {
        #region BLL
        public void InsertErrorLog(string message)
        {
            Log objLog = new Log();

            objLog.Message = message;
            objLog.Type = "Error";

            InsertLog(objLog);
        }
        #endregion

        #region DAL
        private void InsertLog(Log param)
        {
            LogDAL dal = new LogDAL();
            dal.InsertLog(param);
        }
        #endregion
    }
}