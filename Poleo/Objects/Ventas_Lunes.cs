using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Poleo.Objects
{
    public class Ventas_Lunes
    {
        CultureInfo ci = new CultureInfo("Es-Es");
        private string location_Code2;
        private string nombre_tienda2;
        private Decimal ventasconimpuesto2;
        private Decimal impuesto2 = 0;
        private int numSemana2 = 0;
        private String tienda2;
        private DateTime fechaVenta2;
        private int numDia2 = 0;
        private int ordenes2 = 0;
        private Decimal ventasReales2 = 0;
        
        public int NumSemana2
        {
            get { return numSemana2; }
            set { numSemana2 = value; }
        }

        public String Tienda2
        {
            get { return tienda2; }
            set { tienda2 = value; }
        }

        public DateTime FechaVenta2
        {
            get { return fechaVenta2; }
            set { fechaVenta2 = value; }
        }

        public String Dia2
        {
            get { return ci.DateTimeFormat.GetDayName(fechaVenta2.DayOfWeek); }

        }

        public int NumDia2
        {
            get { return numDia2; }
            set { numDia2 = value; }
        }

        public string Location_Code2
        {
            get { return location_Code2; }
            set { location_Code2 = value; }
        }

        public string Nombre_tienda2
        {
            get { return nombre_tienda2; }
            set { nombre_tienda2 = value; }
        }

        public Decimal VentasConImpuesto2
        {
            get { return ventasconimpuesto2; }
            set { ventasconimpuesto2 = value; }
        }

        public Decimal Impuesto2
        {
            get { return impuesto2; }
            set { impuesto2 = value; }
        }

        public int Ordenes2
        {
            get { return ordenes2; }
            set { ordenes2 = value; }
        }

        public Decimal VentasReales2
        {
            get { return ventasReales2; }
            set { ventasReales2 = value; }
        }
    }
}