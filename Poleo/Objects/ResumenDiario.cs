using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Poleo.Objects
{
    public class ResumenDiario
    {
        CultureInfo ci = new CultureInfo("Es-Es");
        private Decimal venta = 0;

        public Decimal Venta
        {
            get { return venta; }
            set { venta = value; }
        }
        private int ordenes = 0;

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }
        private Decimal utilizado = 0;

        public Decimal Utilizado
        {
            get { return utilizado; }
            set { utilizado = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public String Dia
        {
            get { return ci.DateTimeFormat.GetDayName(Fecha.DayOfWeek); }

        }
    }
}