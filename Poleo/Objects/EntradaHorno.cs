using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class EntradaHorno
    {
        private int ordenesHorno3min = 0;
        private int ordenesSalidaTienda15min = 0;
        private DateTime order_Date = DateTime.MinValue;
        private int numeroSemana = 0;
        private int numDia = 0;
        private string location_Code;
        private int order_Count;

        public int OrdenesHorno3min
        {
            get { return ordenesHorno3min; }
            set { ordenesHorno3min = value; }
        }

        public int OrdenesSalidaTienda15min
        {
            get { return ordenesSalidaTienda15min; }
            set { ordenesSalidaTienda15min = value; }
        }

        public DateTime Order_Date
        {
            get { return order_Date; }
            set { order_Date = value; }
        }

        public int NumeroSemana
        {
            get { return numeroSemana; }
            set { numeroSemana = value; }
        }

        public int NumDia
        {
            get { return numDia; }
            set { numDia = value; }
        }

        public string Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        public int Order_Count
        {
            get { return order_Count; }
            set { order_Count = value; }
        }
    }
}