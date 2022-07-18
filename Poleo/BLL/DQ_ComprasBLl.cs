using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class DQ_ComprasBLL
    {
        #region DAL
        public IList<DQ_Compras> SelectComprasHeladoBaseXGalon(DQ_Compras Param)
        {
            DQ_ComprasDAL dal = new DQ_ComprasDAL();

            return dal.SelectComprasHeladoBaseXGalon(Param);
        }
        #endregion
    }
}