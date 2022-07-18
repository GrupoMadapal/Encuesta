using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;

using Poleo.Tools;

namespace Poleo.BLL
{
    public class EstatusBLL
    {
        public IList<Estatus> SelectStatus()
        {
            EstatusDAL dal = new EstatusDAL();
            return dal.SelectStatus();
        }
    }
}