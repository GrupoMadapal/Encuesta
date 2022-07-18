using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class UserXRolBLL
    {
        #region BLL
        public bool IsManager(int IdUSer)
        {
            IList<UserXRol> lstUserXRol = new List<UserXRol>();

            lstUserXRol = SelectUserXRol(IdUSer);

            foreach (UserXRol objUserXRol in lstUserXRol)
            {
                if (objUserXRol.Name == "Gerente")
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DAL
        public IList<UserXRol> SelectUserXRol(int IdUser)
        {
            UserXRolDAL dal = new UserXRolDAL();
            return dal.SelectUserXRol(IdUser);
        }
        #endregion
    }
}