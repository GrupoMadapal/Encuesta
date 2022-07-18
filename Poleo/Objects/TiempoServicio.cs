using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class TiempoServicio
    {
        private string entradaHornoMinHMS = string.Empty;
        private int entradaHornoSec = 0;
        private DateTime fecha = DateTime.MinValue;
        private int numDia = 0;
        private int numSemana = 0;
        private decimal ordenesEntregaTime;
        private decimal ordenesRunTime;
        private decimal ordenesSalidaTienda;
        private decimal adicionales;
        private int orders;
        private int totalOrder = 0; //Added by Hector Sanchez M. - 20160629
        //Added by Hector Sanchez M. - 20180213
        private string estimadoEntregaHMS = string.Empty;
        private int estimadoEntregaSec = 0;
        private string repisaHMS = string.Empty;
        private int repisaSec = 0;
        private int ordenesEstimadoEntrega;
        private int ordenesRepisa;
        //Added by Leo
        private int loadTime = 0;
        private int waitTime = 0;
        private int outTheDoorTime = 0;

        public string EntradaHornoMinHMS
        {
            get { return entradaHornoMinHMS; }
            set { entradaHornoMinHMS = value; }
        }

        public int EntradaHornoSec
        {
            get { return entradaHornoSec; }
            set { entradaHornoSec = value; }
        }

        public decimal OrdenesEntregaTime
        {
            get { return ordenesEntregaTime; }
            set { ordenesEntregaTime = value; }
        }

        public decimal OrdenesRunTime
        {
            get { return ordenesRunTime; }
            set { ordenesRunTime = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int NumDia
        {
            get { return numDia; }
            set { numDia = value; }
        }

        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }

        public decimal OrdenesSalidaTienda
        {
            get { return ordenesSalidaTienda; }
            set { ordenesSalidaTienda = value; }
        }

        public decimal Adicionales
        {
            get { return adicionales;}
            set { adicionales = value; }
        }

        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public decimal ParticipacionAdicionales
        {
            get 
            {
                if (Orders > 0)
                    return Adicionales / Orders;
                else
                    return 0;
            }
        }

        public int TotalOrder
        {
            get { return totalOrder; }
            set { totalOrder = value; }
        }

        public string EstimadoEntregaHMS
        {
            get { return estimadoEntregaHMS; }
            set { estimadoEntregaHMS = value; }
        }

        public int EstimadoEntregaSec
        {
            get { return estimadoEntregaSec; }
            set { estimadoEntregaSec = value; }
        }

        public string RepisaHMS
        {
            get { return repisaHMS; }
            set { repisaHMS = value; }
        }

        public int RepisaSec
        {
            get { return repisaSec; }
            set { repisaSec = value; }
        }

        public int OrdenesEstimadoEntrega
        {
            get { return ordenesEstimadoEntrega; }
            set { ordenesEstimadoEntrega = value; }
        }

        public int OrdenesRepisa
        {
            get { return ordenesRepisa; }
            set { ordenesRepisa = value; }
        }

        //2019-03-13
        public int LoadTime
        {
            get { return loadTime;  }
            set { loadTime = value; }
        }

        public int WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }

        public int OutTheDoorTime
        {
            get { return outTheDoorTime; }
            set { outTheDoorTime = value; }
        }
    }
}