using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class MenuBLL
    {
        #region DAL
        public IList<Menu> SelectListMenu()
        {
            MenuDAL dal = new MenuDAL();
            return dal.SelectListMenu();
        }
        #endregion
    }
}