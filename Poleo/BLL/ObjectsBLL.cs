using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class ObjectsBLL
    {
        #region DAL
        public IList<Objects.Objects> SelectLstObjectsParents()
        {
            ObjectsDAL dal = new ObjectsDAL();
            return dal.SelectLstObjectsParents();
        }

        public IList<Objects.Objects> SelectLstObjectsByParents(int IdParent)
        {
            ObjectsDAL dal = new ObjectsDAL();
            return dal.SelectLstObjectsByParents(IdParent);
        }
        #endregion
    }
}