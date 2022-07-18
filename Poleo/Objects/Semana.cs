using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

using Poleo.BLL;

namespace Poleo.Objects
{
    public class Semana
    {
        DateTime fi;
        DateTime ff;

        public DateTime FechaInicial
        {
            get { return fi; }
            private set { fi = value; }
        }

        public DateTime FechaFinal
        {
            get { return ff; }
            private set { ff = value; }
        }

        public Semana(int num,int year)
        {
            //Changed by Hector Sanchez M. - 20160104
            #region OLD CODE
            //if (num < 0 || num > 54)
            //{
            //    throw new ArgumentException("En número de la semana debe estar comprendido en el rango [1..53]");
            //}

            //FechaInicial = new DateTime(year,2,1);
            //FechaInicial = FechaInicial.AddDays(DayOfWeek.Monday - FechaInicial.DayOfWeek);

            //int sem = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(FechaInicial, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            //if (sem != num)
            //{
            //    FechaInicial = FechaInicial.AddDays((num - sem) * 7);
                
            //}
            //FechaFinal = FechaInicial.AddDays(6);
            #endregion

            AnioBLL objAnioBLL = new AnioBLL();

            if (num < 0 || num > 54)
            {
                throw new ArgumentException("En número de la semana debe estar comprendido en el rango [1..53]");
            }

            FechaInicial = objAnioBLL.FirstDateOfWeek(year, num);

            FechaFinal = FechaInicial.AddDays(6);
        }
    }
}