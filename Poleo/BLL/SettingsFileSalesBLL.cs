using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class SettingsFileSalesBLL
    {
        #region BLL
        public int? ValidConfigFileSales(string Company, int Year)
        {
            SettingsFileSalesBLL objSettingsFileSalesBLL = new SettingsFileSalesBLL();
            SettingsFileSales objFinderSettingsFileSales = new SettingsFileSales();
            SettingsFileSales objSettingsFileSales = new SettingsFileSales();

            objFinderSettingsFileSales.Company = Company;
            objFinderSettingsFileSales.Year = Year;

            objSettingsFileSales = objSettingsFileSalesBLL.SelectObjSettings(objFinderSettingsFileSales);

            if (objSettingsFileSales != null)
                return objSettingsFileSales.NumWeek;
            else
                return null;
        }
        #endregion
        #region DAL
        public SettingsFileSales SelectObjSettings(SettingsFileSales param)
        {
            SettingsFileSalesDAL DAL = new SettingsFileSalesDAL();

            return DAL.SelectObjSettings(param);
        }

        public void InsertObjSettings(SettingsFileSales param)
        {
            SettingsFileSalesDAL DAL = new SettingsFileSalesDAL();

            DAL.InsertObjSettings(param);
        }

        public void UpdateObjSettings(SettingsFileSales param)
        {
            SettingsFileSalesDAL DAL = new SettingsFileSalesDAL();

            DAL.UpdateObjSettings(param);
        }
        #endregion
    }
}