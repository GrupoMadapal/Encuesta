using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Globalization;

namespace Poleo.Objects
{
    public class DQ_Ventas
    {
        private Decimal ventasNetas = 0;

        public Decimal VentasNetas
        {
            get { return ventasNetas; }
            set { ventasNetas = value; }
        }
        private int ordenes = 0;

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }
        private String sucursal = String.Empty;

        public String Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int numeroPasteles = 0;

        public int NumeroPasteles
        {
            get { return numeroPasteles; }
            set { numeroPasteles = value; }
        }
        private Decimal ventasPasteles = 0;

        public Decimal VentasPasteles
        {
            get { return ventasPasteles; }
            set { ventasPasteles = value; }
        }
        private Decimal ventasReales = 0;

        public Decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }
        private int numSemana = 0;

        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }
        private int numDia = 0;

        public int NumDia
        {
            get { return numDia; }
            set { numDia = value; }
        }

        //Added by Hector Sanchez M. - 20160623
        private decimal ventasTotales = 0;

        public decimal VentasTotales
        {
            get { return ventasTotales; }
            set { ventasTotales = value; }
        }

        private decimal utilizadoIdeal = 0;

        public decimal UtilizadoIdeal
        {
            get { return utilizadoIdeal; }
            set { utilizadoIdeal = value; }
        }

        //Added by Hector Sanchez M. - 20180126
        private string articulo;

        public string Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }

        //Added by Hector Sanchez M. - 20180530
        private int invitaciones;

        public int Invitaciones
        {
            get { return invitaciones; }
            set { invitaciones = value; }
        }

        //Added by Leo - 20190212
        private Decimal ticketpromedio;

        public Decimal TicketPromedio
        {
            get { return ticketpromedio; }
            set { ticketpromedio = value; }
        }



        //Added by Hector Sanchez M. - 20180531
        CultureInfo ojbCultureInfo = new CultureInfo("Es-Es");

        public String Dia
        {
            get { return ojbCultureInfo.DateTimeFormat.GetDayName(Fecha.DayOfWeek); }

        }

        private Decimal ventasRappi = 0;
        public Decimal VentasRappi
        {
            get { return ventasRappi; }
            set { ventasRappi = value; }
        }

        private int numTienda = 0;
        public int NumTienda
        {
            get { return numTienda; }
            set { numTienda = value; }
        }

       private Decimal serviciodomicilio;
       public Decimal SERVICIODOMICILIO
        {
            get { return serviciodomicilio; }
            set { serviciodomicilio = value; }
        }


        private Decimal ventasdrive;
        public Decimal VENTASDRIVE
        {
            get { return ventasdrive; }
            set { ventasdrive = value; }
        }


        private int ordenesDom = 0;

        public int OrdenesDom
        {
            get { return ordenesDom; }
            set { ordenesDom = value; }
        }
    }
}