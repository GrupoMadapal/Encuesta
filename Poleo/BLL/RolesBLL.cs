using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class RolesBLL
    {
        #region DAL
        public IList<Roles> SelectRol()
        {
            RolesDAL dal = new RolesDAL();
            return dal.SelectRol();
        }
        #endregion
    }
}