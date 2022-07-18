using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Poleo.Objects
{
    public class TotalSales
    {
        CultureInfo ci = new CultureInfo("Es-Es");
        private DateTime fechaVenta;

        public DateTime FechaVenta
        {
            get { return fechaVenta; }
            set { fechaVenta = value; }
        }
        private String tienda;

        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }
        private String name = String.Empty;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public String Fecha
        {
            get { return fechaVenta.ToString("d"); }
        }

        public String Dia
        {
            get { return ci.DateTimeFormat.GetDayName(fechaVenta.DayOfWeek); }

        }
        private Decimal ventasBrutasTotal;

        public Decimal VentasBrutasTotal
        {
            get { return ventasBrutasTotal; }
            set { ventasBrutasTotal = value; }
        }

        private Decimal canceladasTotal;

        public Decimal CanceladasTotal
        {
            get { return canceladasTotal; }
            set { canceladasTotal = value; }
        }
        private Decimal ordenesMalasTotal;

        public Decimal OrdenesMalasTotal
        {
            get { return ordenesMalasTotal; }
            set { ordenesMalasTotal = value; }
        }

        private Decimal ventasNetasTotal;

        public Decimal VentasNetasTotal
        {
            get { return ventasNetasTotal; }
            set { ventasNetasTotal = value; }
        }

        private Decimal iVATotal;

        public Decimal IVATotal
        {
            get { return iVATotal; }
            set { iVATotal = value; }
        }

        private Decimal ventasRealesTotal;

        public Decimal VentasRealesTotal
        {
            get { return ventasRealesTotal; }
            set { ventasRealesTotal = value; }
        }

        private Decimal ventasRepartoTotal;

        public Decimal VentasRepartoTotal
        {
            get { return ventasRepartoTotal; }
            set { ventasRepartoTotal = value; }
        }

        private Decimal ventasMostradorTotal;

        public Decimal VentasMostradorTotal
        {
            get { return ventasMostradorTotal; }
            set { ventasMostradorTotal = value; }
        }
        private Decimal ventasRestauranteTotal;

         public Decimal VentasRestauranteTotal
        {
            get { return ventasRestauranteTotal; }
            set { ventasRestauranteTotal = value; }
        }
         private int ordenesTotales = 0;

         public int OrdenesTotales
         {
             get { return ordenesTotales; }
             set { ordenesTotales = value; }
         }
         private int ordenesTotalesRestaurante = 0;

         public int OrdenesTotalesRestaurante
         {
             get { return ordenesTotalesRestaurante; }
             set { ordenesTotalesRestaurante = value; }
         }
         private int ordenesTotalesMostrador = 0;

         public int OrdenesTotalesMostrador
         {
             get { return ordenesTotalesMostrador; }
             set { ordenesTotalesMostrador = value; }
         }
         private int ordenesTotalReparto = 0;

         public int OrdenesTotalReparto
         {
             get { return ordenesTotalReparto; }
             set { ordenesTotalReparto = value; }
         }
         private int ordenesMalasCount = 0;

         public int OrdenesMalasCount
         {
             get { return ordenesMalasCount; }
             set { ordenesMalasCount = value; }
         }
         private Decimal totalGratis = 0;

         public Decimal TotalGratis
         {
             get { return totalGratis; }
             set { totalGratis = value; }
         }
         private Decimal ventasRegaladas = 0;

         public Decimal VentasRegaladas
         {
             get { return ventasRegaladas; }
             set { ventasRegaladas = value; }
         }
         
         private int ordenesRegaladas = 0;

         public int OrdenesRegaladas
         {
             get { return ordenesRegaladas; }
             set { ordenesRegaladas = value; }
         }
         private Decimal utilizado = 0;

         public Decimal Utilizado
         {
             get { return utilizado; }
             set { utilizado = value; }
         }


    }
}