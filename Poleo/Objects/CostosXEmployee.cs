using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class CostosXEmployee
    {
        private String location_Code;
        private String added_By;
        private DateTime order_Date;
        private DateTime actual_Order_Date;
        private int order_Number;
        private Decimal orderIdealFoodCost;
        private Decimal orderRoyaltySales;
        private String fullName;
        private String fullName2;
        private int totalOrdenes;
        private int tiempoPromedioMinutes;
        private int tiempoPromedioDeCorrida;

        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        public String Added_By
        {
            get { return added_By; }
            set { added_By = value; }
        }

        public DateTime Order_Date
        {
            get { return order_Date; }
            set { order_Date = value; }
        }

        public DateTime Actual_Order_Date
        {
            get { return actual_Order_Date; }
            set { actual_Order_Date = value; }
        }

        public int Order_Number
        {
            get { return order_Number; }
            set { order_Number = value; }
        }

        public Decimal OrderIdealFoodCost
        {
            get { return orderIdealFoodCost; }
            set { orderIdealFoodCost = value; }
        }

        public Decimal OrderRoyaltySales
        {
            get { return orderRoyaltySales; }
            set { orderRoyaltySales = value; }
        }

        public String FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public String FullName2
        {
            get { return fullName2; }
            set { fullName2 = value; }
        }

        public int TotalOrdenes
        {
            get { return totalOrdenes; }
            set { totalOrdenes = value; }
        }

        public String Empleado
        {
            get { return added_By; }
            set { added_By = value; }
        }

        public Nullable<Decimal> Costo
        {
            get { return OrderRoyaltySales != 0 ? OrderIdealFoodCost / OrderRoyaltySales : 0; }
        }

        public int TiempoPromedioMinutes
        {
            get { return tiempoPromedioMinutes; }
            set { tiempoPromedioMinutes = value; }
        }

        public int TiempoPromedioDeCorrida
        {
            get { return tiempoPromedioDeCorrida; }
            set { tiempoPromedioDeCorrida = value; }
        }
    }
}