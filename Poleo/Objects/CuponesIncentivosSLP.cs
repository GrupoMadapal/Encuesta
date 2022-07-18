using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class CuponesIncentivosSLP
    {
        private String location_Code = String.Empty;
        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }
        //private DateTime order_Date;

        private double cupon2A80;
        public double Cupon2A80
        {
            get { return cupon2A80; }
            set { cupon2A80 = value; }
        }


        private double cuponN2E59;
        public double CuponN2E59
        {
            get { return cuponN2E59; }
            set { cuponN2E59 = value; }
        }

        private double cupon2a80xextra;
        public double Cupon2a80xextra
        {
            get { return cupon2a80xextra; }
            set { cupon2a80xextra = value; }
        }


        private double cuponN2E59xextra;
        public double CuponN2E59xextra
        {
            get { return cuponN2E59xextra; }
            set { cuponN2E59xextra = value; }
        }

        private int sINcupon;
        public int SINcupon
        {
            get { return sINcupon; }
            set { sINcupon = value; }
        }

        private int cupon8Quantity;
        public int Cupon8Quantity
        {
            get { return cupon8Quantity; }
            set { cupon8Quantity = value; }
        }

        private String nombreEmpleado;

        public String NombreEmpleado
        {
            get { return nombreEmpleado; }
            set { nombreEmpleado = value; }
        }

        private double porcentaje;
        public double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        private double totalcupones;
        public double Totalcupones
        {
            get { return totalcupones; }
            set { totalcupones = value; }
        }

       
    }
}