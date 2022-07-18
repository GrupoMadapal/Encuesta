using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Poleo.Objects
{
    public class Ventas
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

        public String Fecha
        {
            get { return fechaVenta.ToString("d"); }
        }
        private String name = String.Empty;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Dia
        {
            get { return ci.DateTimeFormat.GetDayName(fechaVenta.DayOfWeek); }

        }
        private Decimal ventasBrutas;

        public Decimal VentasBrutas
        {
            get { return ventasBrutas; }
            set { ventasBrutas = value; }
        }

        private Decimal canceladas;

        public Decimal Canceladas
        {
            get { return canceladas; }
            set { canceladas = value; }
        }

        private Decimal costodeComidaReal;

        public Decimal CostodeComidaReal
        {
            get { return costodeComidaReal; }
            set { costodeComidaReal = value; }
        }
        private Decimal ordenesMalas;

        public Decimal OrdenesMalas
        {
            get { return ordenesMalas; }
            set { ordenesMalas = value; }
        }

        private Decimal ventasNetas;

        public Decimal VentasNetas
        {
            get { return ventasNetas; }
            set { ventasNetas = value; }
        }

        private Decimal iVA;

        public Decimal IVA
        {
            get { return iVA; }
            set { iVA = value; }
        }

        private Decimal ventasReales;

        public Decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }

        private Decimal ventasReparto;

        public Decimal VentasReparto
        {
            get { return ventasReparto; }
            set { ventasReparto = value; }
        }

        private Decimal ventasMostrador;

        public Decimal VentasMostrador
        {
            get { return ventasMostrador; }
            set { ventasMostrador = value; }
        }
        // Added of 20150528
        private Decimal ventasRegaladas = 0;

        public Decimal VentasRegaladas
        {
            get { return ventasRegaladas; }
            set { ventasRegaladas = value; }
        }
        private int ordenes = 0;

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
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
        private Decimal ventasRestaurante = 0;

        public Decimal VentasRestaurante
        {
            get { return ventasRestaurante; }
            set { ventasRestaurante = value; }
        }

        private int numDia = 0;

        public int NumDia
        {
            get { return numDia; }
            set { numDia = value; }
        }
        private int numSemana = 0;

        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }
        private Decimal utilizadoReal = 0;

        public Decimal UtilizadoReal
        {
            get { return utilizadoReal; }
            set { utilizadoReal = value; }
        }

        int totalOrdenesMalas = 0;

        public int TotalOrdenesMalas
        {
            get { return totalOrdenesMalas; }
            set { totalOrdenesMalas = value; }
        }

        int totalOrdenesCanceladas = 0;

        public int TotalOrdenesCanceladas
        {
            get { return totalOrdenesCanceladas; }
            set { totalOrdenesCanceladas = value; }
        }

        //Added by Hector Sanchez M. 20160316
        private int ordenesInternet = 0;

        public int OrdenesInternet
        {
            get { return ordenesInternet; }
            set { ordenesInternet = value; }
        }

        private decimal ventasInternet;

        public decimal VentasInternet
        {
            get { return ventasInternet; }
            set { ventasInternet = value; }
        }

        //Added by Leo
        
        private int ordenesReparto = 0;

        public int OrdenesReparto
        {
            get { return ordenesReparto; }
            set { ordenesReparto = value; }
        }

        private int ordenesMostrador = 0;

        public int OrdenesMostrador
        {
            get { return ordenesMostrador; }
            set { ordenesMostrador = value; }
        }

        private int ordenesResturante = 0;

        public int OrdenesRestaurante
        {
            get { return ordenesResturante; }
            set { ordenesResturante = value; }
        }

        private int ordenesRestauranteMostrador = 0;

        public int OrdenesRestauranteMostrador
        {
            get { return ordenesRestauranteMostrador; }
            set { ordenesRestauranteMostrador = value; }
        }

        private int numTienda = 0;

        public int NumTienda
        {
            get { return numTienda; }
            set { numTienda = value; }
        }
         
    }
}