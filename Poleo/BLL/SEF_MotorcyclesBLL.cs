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
    public class SEF_MotorcyclesBLL
    {
        public void InsertSEF_Motorcycles(SEF_Motorcycles param)
        {
            SEFMotorcyclesDAL dal = new SEFMotorcyclesDAL();

            dal.InsertSEF_Motorcycles(param);
        }

        public bool IsRepeated(string Serial)
        {
            IList<SEF_Motorcycles> lstSEF_Motorcycles = new List<SEF_Motorcycles>();

            lstSEF_Motorcycles = SelectSerial(Serial);

            foreach (SEF_Motorcycles objSEF_Motorcycles in lstSEF_Motorcycles)
            {
                if (objSEF_Motorcycles.Serial == Serial)
                {
                    return true;
                }
            }

            return false;
        }

        public IList<SEF_Motorcycles> SelectSerial(string Serial)
        {
            SEFMotorcyclesDAL dal = new SEFMotorcyclesDAL();
            return dal.SelectSerial(Serial);
        }

        public IList<SEF_Motorcycles> SelectNumEco(SEF_Motorcycles param)
        {
            SEFMotorcyclesDAL dal = new SEFMotorcyclesDAL();
            return dal.SelectNumEco(param);
        }

        public IList<SEF_Motorcycles> SelectVehicle(SEF_Motorcycles param)
        {
            SEFMotorcyclesDAL dal = new SEFMotorcyclesDAL();
            return dal.SelectVehicle(param);
        }

        public void UpdateVehicle(SEF_Motorcycles Param)
        {
            SEFMotorcyclesDAL dal = new SEFMotorcyclesDAL();

            dal.UpdateVehicle(Param);
        }
    } 
}