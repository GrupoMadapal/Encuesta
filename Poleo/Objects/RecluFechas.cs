using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class RecluFechas
    {
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
        private int identrevista = 0;
        public int IdEntrevista
        {
            get { return identrevista; }
            set { identrevista = value; }
        }
    }
}