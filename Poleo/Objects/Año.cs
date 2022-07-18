using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Año
    {
        private DateTime yearIni = new DateTime(1980, 1, 1);

        public DateTime YearIni
        {
            get { return yearIni; }
            set { yearIni = value; }
        }
        private DateTime yearEnd =  DateTime.Now;

        public DateTime YearEnd
        {
            get { return yearEnd; }
            set { yearEnd = value; }
        }
        private int yearZero=2014;
         public List<String> GetsYear()
        {
            List<String> lstYears = new List<String>();
            int yearAux1 = YearIni.Year;
            int yearAux2 = YearEnd.Year;
             for(int i= yearAux2;i>=yearAux1;i--)
             {
                 lstYears.Add(i.ToString());
             }
             return lstYears;
        }
        //public Boolean isYearwithweekZero(int año)
        // {
        //     Boolean res = false;
        //     if (yearZero==año)
        //     {
        //         return true;
        //     }
        //     else
        //         if(yearZero>año)
        //         {

        //         }
        //         else
        //             if(yearZero<año)
        //             {
        //                 int count=0;
        //                 for(int i= yearZero+1; i<=año ;i++)
        //                 {
        //                     if(DateTime.IsLeapYear(i))
        //                     {
        //                         count++;
                                 
        //                     }
        //                     else
        //                     {
        //                         count++;
        //                     }

        //                 }
        //             }
        //     return res;
        //}
    }
}