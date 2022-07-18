using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class ObjectsXUserBLL
    {
        #region DAL
        public ObjectsXUser SelectObjectXUser(ObjectsXUser Param)
        {
            ObjectsXUserDAL dal = new ObjectsXUserDAL();
            return dal.SelectObjectXUser(Param);
        }

        public IList<ObjectsXUser> SelectLstObjectsXUser(int IdUser)
        {
            ObjectsXUserDAL dal = new ObjectsXUserDAL();
            return dal.SelectLstObjectsXUser(IdUser);
        }

        public IList<int> SelectObjectsByUser(int IdUser)
        {
            ObjectsXUserDAL dal = new ObjectsXUserDAL();
            return dal.SelectObjectsByUser(IdUser);
        }
        #endregion
    }
}