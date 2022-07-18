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
    public class ModelsBLL
    {
        public IList<Models> SelectModels()
        {
            ModelsDAL dal = new ModelsDAL();
            return dal.SelectModels();
        }
    }
}