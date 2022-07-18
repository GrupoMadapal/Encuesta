using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.BLL;

namespace Poleo.Objects
{
    [Serializable]
    public class VentasFinder
    {
       //se declara la variable 
        private int? selectYear = null;

        //fecha de inicio
        private Nullable<DateTime> dateIni = null;
        public Nullable<DateTime> DateIni
        {
           
            get { return dateIni; }  //empieza a ejecutar
            set { dateIni = value; } // se asigna un valor
        }

        //fecha final
        private Nullable<DateTime> dateEnd = null;
        public Nullable<DateTime> DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        //numero de la tienda
        private String numTienda = String.Empty;
        public String NumTienda
        {
            get { return numTienda; }
            set { numTienda = value; }
        }
        //tipo de tienda
        private String tipoTienda = String.Empty;
        public String TipoTienda
        {
            get { return tipoTienda; }
            set { tipoTienda = value; }
        }

        //ubicacion de la tienda
        private String ubicacionTienda = String.Empty;
        public String UbicacionTienda
        {
            get { return ubicacionTienda; }
            set { ubicacionTienda = value; }
        }

        //numero de la semana
        private int numeroSemana = 0;
        public int NumeroSemana
        {
            get { return numeroSemana; }
            set { numeroSemana = value; }
        }

        
        private Boolean indicadorFull = true;
        public Boolean IndicadorFull
        {
            get { return indicadorFull; }
            set { indicadorFull = value; }
        }
       
        //Modified by Hector Sanchez M. 20160229 - error en el reporte "Indicador Maestro" la fecha del año 
        //anterior se estaba calculando mal.(DateIniLastYear y DateEndLastYear)
        public DateTime DateIniLastYear
        {
            //get { return DateIni.Value.AddDays(1).AddYears(-1); }
            get 
            {
                AnioBLL objAnioBLL = new AnioBLL();

                return objAnioBLL.FirstDateOfWeek(selectYear.Value - 1, numeroSemana);
            }
        }
        public DateTime DateEndLastYear
        {
            //get { return DateEnd.Value.AddDays(1).AddYears(-1); }
            get { return DateIniLastYear.AddDays(6); }
        }

        public DateTime DateIniLastWeek
        {
            get { return DateIni.Value.AddDays(-7); }

        }
        public DateTime DateEndLastWeek
        {
            get { return DateEnd.Value.AddDays(-7); }

        }

        public int? SelectYear
        {
            get { return selectYear; }
            set { selectYear = value; }
        }

        //Added by Hector Sanchez M. - 20161020
        private IList<string> lstCuponCode;
        public IList<string> LstCuponCode
        {
            get { return lstCuponCode; }
            set { lstCuponCode = value; }
        }

  
    }
}