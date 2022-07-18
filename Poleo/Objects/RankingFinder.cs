using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.BLL;

namespace Poleo.Objects
{
    public class RankingFinder
    {
        private int? selectYear = null;
        private DateTime dateIni;
        public DateTime DateIni
        {
            get { return dateIni; }
            set { dateIni = value; }
        }

        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        //Modified by Hector Sanchez M. 20160309.
        //Error en el reporte "Ranking" las fechas del año anterior se estaban calculando mal
        public DateTime LastYearDateIni
        {
            //get { return DateIni.AddDays(1).AddYears(-1); }
            get
            {
                AnioBLL objAnioBLL = new AnioBLL();

                return objAnioBLL.FirstDateOfWeek(selectYear.Value - 1, numSemana);
            }
        }

        public DateTime LastYearDateEnd
        {
            //get { return dateEnd.AddDays(1).AddYears(-1); }
            get { return LastYearDateIni.AddDays(6); }
        }

        private String tipoTienda = String.Empty;
        public String TipoTienda
        {
            get { return tipoTienda; }
            set { tipoTienda = value; }
        }

        private String ubicacionTienda = String.Empty;
        public String UbicacionTienda
        {
            get { return ubicacionTienda; }
            set { ubicacionTienda = value; }
        }

        private String tienda = String.Empty;
        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }

        private int numSemana = 0;
        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }
        
        public void modificaFechaInicial_9SemAntes()
        {
            DateIni = DateIni.AddDays(-(9 * 7));
        }

        public int? SelectYear
        {
            get { return selectYear; }
            set { selectYear = value; }
        }
    }
}