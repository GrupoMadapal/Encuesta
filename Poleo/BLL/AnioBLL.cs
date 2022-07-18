using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Poleo.BLL
{
    public class AnioBLL
    {
        //Devuelve el numero de semana al que pertenece una fecha
        public int GetWeekNumber(DateTime Date)
        {
            int wk = 0;
            int Year = Date.Year;
            DateTime startOfYear = new DateTime(Year, 1, 1);
            DateTime endOfYear = new DateTime(Year, 12, 31);
            int[] iso8601Correction = { 6, 7, 8, 9, 10, 4, 5 };
            int nds = Date.Subtract(startOfYear).Days + iso8601Correction[(int)startOfYear.DayOfWeek];
            wk = nds / 7;
            switch (wk)
            {
                case 0:
                    // Return weeknumber of dec 31st of the previous year
                    wk = GetWeekNumber(Date.AddDays(-1));
                    break;
                case 53:
                    // If dec 31st falls before thursday it is week 01 of next year
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                    {
                        wk = 1; Year += 1;
                    }
                    break;
                default:
                    break;
            }

            return wk;
        }

        //Devuelve el total de semanas de un año
        public int TotalWeekForYear(int Year)
        {
            int TW = 0;
            int day = 31;
            DateTime date = new DateTime();
            for (int CD = day; CD > 0; CD--)
            {
                date = new DateTime(Year, 12, day);
                TW = WeekId(date);

                if (TW == 1)
                    day--;
                else
                    break;
            }
            return TW;
        }

        public int WeekId(DateTime Date)
        {
            int wk = 0;

            wk = GetWeekNumber(Date);

            return wk;
        }

        //Devuelve la fecha correspondiente al primer dia de la semana(lunes)
        public DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = (int)DayOfWeek.Monday - (int)jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            //get first week by ISO
            int firstWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.InvariantCulture.DateTimeFormat.CalendarWeekRule, DayOfWeek.Monday);
            int numWeek = WeekId(firstMonday);
            int TW = TotalWeekForYear(year);

            if (numWeek == 53 || numWeek == 52)
            {
                firstMonday = firstMonday.AddDays(7);
                numWeek = WeekId(firstMonday);
            }

            #region COMMENTED BY LEO FOR 53
            //if (TW != 53)
            if (TW != 54)
                weekOfYear--;
            #endregion
            
            

            return firstMonday.AddDays(weekOfYear * 7);
        }

        //Added by Hector Sanchez M. 20160713
        //Devuleve el numero de semana al que pertenece un rango de fechas
        public IList<int> GetNumberWeekByRangeDate(DateTime DateIni, DateTime DateEnd)
        {
            IList<int> lstInt = new List<int>();
            DateTime DateAux = DateIni;
            int NumberWeek = 0;
            int NumberWeekAux = 0;

            while (DateAux <= DateEnd)
            {
                NumberWeek = GetWeekNumber(DateAux);

                if (NumberWeek != NumberWeekAux)
                {
                    NumberWeekAux = NumberWeek;

                    lstInt.Add(NumberWeek);
                }

                DateAux = DateAux.AddDays(1);
            }

            return lstInt;
        }

        //Added by Hector Sanchez M. 20170602
        //Devuelve la fecha del año anterior de acuerdo al calendario de dominos
        public DateTime GetLastYearDate(DateTime ActualDate)
        {
            DateTime DateIniYear = FirstDateOfWeek(ActualDate.Year, 1);

            TimeSpan daysdif = ActualDate - DateIniYear;

            int day = daysdif.Days;

            DateTime DateIniLastYear = FirstDateOfWeek(ActualDate.AddYears(-1).Year, 1);

            DateTime datelastYear = DateIniLastYear.AddDays(day);

            return datelastYear;
        }
    }
}