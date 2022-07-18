using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ResumenVentas
    {
        private String tienda = String.Empty;
        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int ordenesTotales = 0;
        public int OrdenesTotales
        {
            get { return ordenesTotales; }
            set { ordenesTotales = value; }
        }

        private int ordenesMalas = 0;
        public int OrdenesMalas
        {
            get { return ordenesMalas; }
            set { ordenesMalas = value; }
        }

        private Decimal ventasReales = 0;
        public Decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }

        private Decimal ventasMalas = 0;
        public Decimal VentasMalas
        {
            get { return ventasMalas; }
            set { ventasMalas = value; }
        }

        private Decimal utilizado = 0;
        public Decimal Utilizado
        {
            get { return utilizado; }
            set { utilizado = value; }
        }

        private Decimal utilizadoPorcentaje = 0;
        public Decimal UtilizadoPorcentaje
        {
            get { return utilizadoPorcentaje; }
            set { utilizadoPorcentaje = value; }
        }

        private int numeroSemana = 0;
        public int NumeroSemana
        {
            get { return numeroSemana; }
            set { numeroSemana = value; }
        }

        private String dia = String.Empty;

        public String Dia
        {
            get { return dia; }
            set { dia = value; }
        }
        private Decimal masterSales = 0;

        public Decimal MasterSales
        {
            get { return masterSales; }
            set { masterSales = value; }
        }
        private Decimal masterSalesIVA = 0;

        public Decimal MasterSalesIVA
        {
            get { return masterSalesIVA; }
            set { masterSalesIVA = value; }
        }
        private String code = string.Empty;

        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private Decimal canceladas = 0;

        public Decimal Canceladas
        {
            get { return canceladas; }
            set { canceladas = value; }
        }
        private int ordenesCanceladas = 0;

        public int OrdenesCanceladas
        {
            get { return ordenesCanceladas; }
            set { ordenesCanceladas = value; }
        }
        private Decimal inventarioFinal = 0;

        public Decimal InventarioFinal
        {
            get { return inventarioFinal; }
            set { inventarioFinal = value; }
        }
        private Decimal depositosTargeta = 0;

        public Decimal DepositosTargeta
        {
            get { return depositosTargeta; }
            set { depositosTargeta = value; }
        }
        private Decimal depositosEfectivo = 0;

        public Decimal DepositosEfectivo
        {
            get { return depositosEfectivo; }
            set { depositosEfectivo = value; }
        }

        //Added by Hector Sanchez M. 20170821
        private decimal openPay;

        public decimal OpenPay
        {
            get { return openPay; }
            set { openPay = value; }
        }


        private decimal uberEats;

        public decimal UberEats
        {
            get { return uberEats; }
            set { uberEats = value; }
        }
    }
}