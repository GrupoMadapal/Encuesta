using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.BLL;

namespace Poleo.Objects
{
    public class DQ_VentasFinder
    {

        private String sucursal = String.Empty;

        public String Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }
        private DateTime fechaIni;

        public DateTime FechaIni
        {
            get { return fechaIni; }
            set { fechaIni = value; }
        }
        private DateTime fechaEnd;

        public DateTime FechaEnd
        {
            get { return fechaEnd; }
            set { fechaEnd = value; }
        }

        private int? selectYear;

        public int? SelectYear
        {
            get { return selectYear; }
            set { selectYear = value; }
        }

        public int NumWeek
        {
            get
            {
                AnioBLL objAnioBLL = new AnioBLL();

                return objAnioBLL.GetWeekNumber(FechaIni);
            }
        }


        public DateTime DateIniLastYear
        {
            get 
            {
                AnioBLL objAnioBLL = new AnioBLL();
                 

             //   return objAnioBLL.FirstDateOfWeek(selectYear.Value - 1, NumWeek);

        ///Agregados por Ariadna Cadena 03/02/2021
                
                DateTime Rankingsemanal = objAnioBLL.FirstDateOfWeek(selectYear.Value - 1, NumWeek + 1);

                return Rankingsemanal;
            }
        }

        public DateTime DateEndLastYear
        {
            get
            {
                if (FindByWeek)
                    return DateIniLastYear.AddDays(6);
                else
                {
                    AnioBLL objAnioBLL = new AnioBLL();

                    DateTime dateEndLastYear = new DateTime();

                    dateEndLastYear = objAnioBLL.GetLastYearDate(fechaEnd);

                    return dateEndLastYear;
                }
            }
        }

        //Added by Hector Sanchez M. 20171129
        public DateTime DateIniLastWeek
        {
            get 
            {
                AnioBLL objAnioBLL = new AnioBLL();

                return objAnioBLL.FirstDateOfWeek(selectYear.Value, NumWeek - 1);
            }
        }

        public DateTime DateEndLastWeek

        {
            get
            {
                return DateIniLastWeek.AddDays(6);
            }
        }

        private bool FindByWeek
        {
            get
            {
                TimeSpan difDate = FechaEnd - FechaIni;

                int difDay = difDate.Days;

                if (difDay > 6)
                    return false;

                return true;
            }
        }

        //Added by Hector Sanchez M. 20180823
        public string AlmacenMerma
        {
            get 
            {
                return sucursal + "M";
            }
        }
    }
}