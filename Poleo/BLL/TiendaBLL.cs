using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class TiendaBLL
    {
        #region BLL
        public IList<int> GetStringNumberStore(IList<Tienda> lstTienda)
        {
            IList<int> lststring = new List<int>();

            foreach (Tienda objTienda in lstTienda)
            {
                lststring.Add(int.Parse(objTienda.Number_tienda));
            }

            return lststring;
        }

        public Tienda SelectStoreByUserID(int paramid)
        {
            TiendaDAL dal = new TiendaDAL();

            return dal.SelectStoreByUserID(paramid);
        }
        #endregion

        #region DAL
        public IList<Tienda> selectTiendaUp()
        {
            TiendaDAL DAL = new TiendaDAL();
            return DAL.selectTiendaUp();
        }
        public IList<Tienda> SelectTipoTienda(Tienda param)
        {
            TiendaDAL DAL = new TiendaDAL();
            return DAL.SelectTipoTienda(param);
        }
        public IList<Tienda> SelectTiendas(Tienda param)
        {
            TiendaDAL DAL = new TiendaDAL();
            return DAL.SelectTiendas(param);
        }
        public IList<Tienda> SelectDQTiendas(Tienda param)
        {
            TiendaDAL DAL = new TiendaDAL();
            return DAL.SelectDQTiendas(param);
        }

        public IList<Tienda> SelectTiendasOrden(Tienda param)
        {
            TiendaDAL DAL = new TiendaDAL();
            return DAL.SelectTiendasOrden(param);
        }
        #endregion
    }
}