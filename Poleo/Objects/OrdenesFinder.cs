using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrdenesFinder
    {
        private DateTime dateIni ;

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

        private Nullable<DateTime> dateIni2;

        public Nullable<DateTime> DateIni2
        {
            get { return dateIni2; }
            set { dateIni2 = value; }
        }
        private Nullable<DateTime> dateEnd2;

        public Nullable<DateTime> DateEnd2
        {
            get { return dateEnd2; }
            set { dateEnd2 = value; }
        }
        private String numTienda = String.Empty;

        public String NumTienda
        {
            get { return numTienda; }
            set { numTienda = value; }
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
        private String  codigoCupon=String.Empty;

        public String CodigoCupon
        {
          get { return codigoCupon; }
          set { codigoCupon = value; }
        }

        private IList<string> lstCuponCode;

        public IList<string> LstCuponCode
        {
            get { return lstCuponCode; }
            set { lstCuponCode = value; }
        }

        private String empleado;
        public String Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        private DateTime order_Date;
        public DateTime Order_Date
        {
            get { return order_Date; }
            set { order_Date = value; }
        }
        
    }
}