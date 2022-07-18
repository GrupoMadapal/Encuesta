using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class IndicadorMaestro
    {
        private String tienda = String.Empty;
        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }

        private Decimal ventasLastYear = 0;

        public Decimal VentasLastYear
        {
            get { return ventasLastYear; }
            set { ventasLastYear = value; }
        }
        private Decimal ventas = 0;

        public Decimal Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }
        private int ordenesLastYear = 0;

        public int OrdenesLastYear
        {
            get { return ordenesLastYear; }
            set { ordenesLastYear = value; }
        }
        private int ordenes = 0;

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }
        private int ordRepartoLastYear = 0;

        public int OrdRepartoLastYear
        {
            get { return ordRepartoLastYear; }
            set { ordRepartoLastYear = value; }
        }
        private int ordMostradorLastYear = 0;

        public int OrdMostradorLastYear
        {
            get { return ordMostradorLastYear; }
            set { ordMostradorLastYear = value; }
        }
        private int ordReparto = 0;

        public int OrdReparto
        {
            get { return ordReparto; }
            set { ordReparto = value; }
        }
        private int ordMostrador = 0;

        public int OrdMostrador
        {
            get { return ordMostrador; }
            set { ordMostrador = value; }
        }
        private Decimal ventasReparto = 0;

        public Decimal VentasReparto
        {
            get { return ventasReparto; }
            set { ventasReparto = value; }
        }
        private Decimal ventaMostrador = 0;

        public Decimal VentaMostrador
        {
            get { return ventaMostrador; }
            set { ventaMostrador = value; }
        }
        private Decimal vtsRepartoLastYear = 0;

        public Decimal VtsRepartoLastYear
        {
            get { return vtsRepartoLastYear; }
            set { vtsRepartoLastYear = value; }
        }
        private Decimal vtsMostradorLastYear = 0;

        public Decimal VtsMostradorLastYear
        {
            get { return vtsMostradorLastYear; }
            set { vtsMostradorLastYear = value; }
        }
        private Decimal ordenesMalas = 0;

        public Decimal OrdenesMalas
        {
            get { return ordenesMalas; }
            set { ordenesMalas = value; }
        }
        private int pizzaTotal = 0;

        public int PizzaTotal
        {
            get { return pizzaTotal; }
            set { pizzaTotal = value; }
        }
        private int pizzaSarten = 0;

        public int PizzaSarten
        {
            get { return pizzaSarten; }
            set { pizzaSarten = value; }
        }
        private int pizzaOrilla = 0;

        public int PizzaOrilla
        {
            get { return pizzaOrilla; }
            set { pizzaOrilla = value; }
        }
        private int pizzaM85 = 0;

        public int PizzaM85
        {
            get { return pizzaM85; }
            set { pizzaM85 = value; }
        }
        private int totalAdicionales = 0;

        public int TotalAdicionales
        {
            get { return totalAdicionales; }
            set { totalAdicionales = value; }
        }
        private int canelazo = 0;

        public int Canelazo
        {
            get { return canelazo; }
            set { canelazo = value; }
        }
        private int papotas = 0;

        public int Papotas
        {
            get { return papotas; }
            set { papotas = value; }
        }
        private int wings = 0;

        public int Wings
        {
            get { return wings; }
            set { wings = value; }
        }
        private int fingers = 0;

        public int Fingers
        {
            get { return fingers; }
            set { fingers = value; }
        }
        private int volcan = 0;

        public int Volcan
        {
            get { return volcan; }
            set { volcan = value; }
        }
        private int sweetBread = 0;

        public int SweetBread
        {
            get { return sweetBread; }
            set { sweetBread = value; }
        }
        private int cheese = 0;

        public int Cheese
        {
            get { return cheese; }
            set { cheese = value; }
        }
        private int rEF120Z = 0;

        public int REF120Z
        {
            get { return rEF120Z; }
            set { rEF120Z = value; }
        }
        private int rEF160Z = 0;

        public int REF160Z
        {
            get { return rEF160Z; }
            set { rEF160Z = value; }
        }
        private int rEF220Z = 0;

        public int REF220Z
        {
            get { return rEF220Z; }
            set { rEF220Z = value; }
        }
        private int rEF320Z = 0;

        public int REF320Z
        {
            get { return rEF320Z; }
            set { rEF320Z = value; }
        }
        private int rEF500ML = 0;

        public int REF500ML
        {
            get { return rEF500ML; }
            set { rEF500ML = value; }
        }
        private int rEF600ML = 0;

        public int REF600ML
        {
            get { return rEF600ML; }
            set { rEF600ML = value; }
        }
        private int rEF2LTS = 0;

        public int REF2LTS
        {
            get { return rEF2LTS; }
            set { rEF2LTS = value; }
        }
        private int rEF25LTS = 0;

        public int REF25LTS
        {
            get { return rEF25LTS; }
            set { rEF25LTS = value; }
        }
        private decimal utilizadoReal = 0;

        public decimal UtilizadoReal
        {
            get { return utilizadoReal; }
            set { utilizadoReal = value; }
        }
        private Decimal utilizadoPor = 0;

        public Decimal UtilizadoPor
        {
            get { return utilizadoPor; }
            set { utilizadoPor = value; }
        }

        private int numOrdenesGratis = 0;

        public int NumOrdenesGratis
        {
            get { return numOrdenesGratis; }
            set { numOrdenesGratis = value; }
        }
        private int numOrdenesMalas = 0;

        public int NumOrdenesMalas
        {
            get { return numOrdenesMalas; }
            set { numOrdenesMalas = value; }
        }
        private Decimal ventaOrdenesGratis = 0;

        public Decimal VentaOrdenesGratis
        {
            get { return ventaOrdenesGratis; }
            set { ventaOrdenesGratis = value; }
        }
        private Decimal ventaOrdenesMalas = 0;

        public Decimal VentaOrdenesMalas
        {
            get { return ventaOrdenesMalas; }
            set { ventaOrdenesMalas = value; }
        }
        private int pD4 = 0;

        public int PD4
        {
            get { return pD4; }
            set { pD4 = value; }
        }
        private int p14 = 0;

        public int P14
        {
            get { return p14; }
            set { p14 = value; }
        }
        private int p2X1 = 0;

        public int P2X1
        {
            get { return p2X1; }
            set { p2X1 = value; }
        }

        //Added by Hector Sanchez M. - 20161202
        private int pizzaNacional = 0;

        public int PizzaNacional
        {
            get { return pizzaNacional; }
            set { pizzaNacional = value; }
        }

        private int pizzaLocal = 0;

        public int PizzaLocal
        {
            get { return pizzaLocal; }
            set { pizzaLocal = value; }
        }

        //Added by Hector Sanchez M. - 20161205
        private decimal full_Template;

        public decimal Full_Template
        {
            get { return full_Template; }
            set { full_Template = value; }
        }

        private decimal training;

        public decimal Training
        {
            get { return training; }
            set { training = value; }
        }

        private decimal communication;

        public decimal Communication
        {
            get { return communication; }
            set { communication = value; }
        }

        //Added by Hector Sanchez M. - 20171025

        private string nombreTienda;

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }
    }
}