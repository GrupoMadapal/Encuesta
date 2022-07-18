using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class SalesDPViewBLL
    {
        #region BLL
        public void LoadInfo()
        {
            deleteSalesDPView();

            insertObjSalesDPView();
        }
        #endregion

        #region DAL
        public IList<SalesDP> selectLstSalesDPView(SalesDP param)
        {
            SalesDPViewDAL dal = new SalesDPViewDAL();

            return dal.selectLstSalesDPView(param);
        }

        private void insertObjSalesDPView()
        {
            SalesDPViewDAL dal = new SalesDPViewDAL();

            dal.insertObjSalesDPView();
        }

        private void deleteSalesDPView()
        {
            SalesDPViewDAL dal = new SalesDPViewDAL();

            dal.deleteSalesDPView();
        }
        #endregion
    }
}