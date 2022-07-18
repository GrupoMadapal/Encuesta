using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class SalesDP
    {
        /*Esta clase se compatira con las mapas de SalesDPData y SalesDPView*/
        private string numeroTienda;
		private string nombreTienda;
		private decimal ventasReales;
		private decimal ventasAnoPasado;
		private string porcVentas;
		private int ordenes;
		private int ordenesGratis;
		private int ordenesCanceladas;
		private string entradaHorno;
        private string tiempoEntrega;
        private string classEH;
        private string classTE;
        private IList<int> lstNumTienda;
        private decimal totalDeposito;

        public string NumeroTienda
        {
            get { return numeroTienda; }
            set { numeroTienda = value; }
        }

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }

        public decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }

        public decimal VentasAnoPasado
        {
            get { return ventasAnoPasado; }
            set { ventasAnoPasado = value; }
        }

        public string PorcVentas
        {
            get { return porcVentas; }
            set { porcVentas = value; }
        }

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }

        public int OrdenesGratis
        {
            get { return ordenesGratis; }
            set { ordenesGratis = value; }
        }

        public int OrdenesCanceladas
        {
            get { return ordenesCanceladas; }
            set { ordenesCanceladas = value; }
        }

        public string EntradaHorno
        {
            get { return entradaHorno; }
            set { entradaHorno = value; }
        }

        public string TiempoEntrega
        {
            get { return tiempoEntrega; }
            set { tiempoEntrega = value; }
        }

        public string ClassEH
        {
            get { return classEH; }
            set { classEH = value; }
        }

        public string ClassTE
        {
            get { return classTE; }
            set { classTE = value; }
        }

        public IList<int> LstNumTienda
        {
            get { return lstNumTienda; }
            set { lstNumTienda = value; }
        }

        public decimal TotalDeposito
        {
            get { return totalDeposito; }
            set { totalDeposito = value; }
        }
    }
}