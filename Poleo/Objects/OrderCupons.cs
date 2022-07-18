using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrderCupons
    {

        private String location_Code = String.Empty;

        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }
        private DateTime order_Date;

        public DateTime Order_Date
        {
            get { return order_Date; }
            set { order_Date = value; }
        }
        private int order_Number = 0;

        public int Order_Number
        {
            get { return order_Number; }
            set { order_Number = value; }
        }
        private int ordCpnNbr = 0;

        public int OrdCpnNbr
        {
            get { return ordCpnNbr; }
            set { ordCpnNbr = value; }
        }
        private int ordCpnRevNbr = 0;

        public int OrdCpnRevNbr
        {
            get { return ordCpnRevNbr; }
            set { ordCpnRevNbr = value; }
        }
        private String ordCpnUpdateUserCode = String.Empty;

        public String OrdCpnUpdateUserCode
        {
            get { return ordCpnUpdateUserCode; }
            set { ordCpnUpdateUserCode = value; }
        }
        private DateTime ordCpnUpdateDate;

        public DateTime OrdCpnUpdateDate
        {
            get { return ordCpnUpdateDate; }
            set { ordCpnUpdateDate = value; }
        }
        private String couponCode = String.Empty;

        public String CouponCode
        {
            get { return couponCode; }
            set { couponCode = value; }
        }
        private int ordCpnQty = 0;

        public int OrdCpnQty
        {
            get { return ordCpnQty; }
            set { ordCpnQty = value; }
        }
        private Decimal ordCpnOverrideValue = 0;

        public Decimal OrdCpnOverrideValue
        {
            get { return ordCpnOverrideValue; }
            set { ordCpnOverrideValue = value; }
        }
        private Decimal ordCpnCouponDiscountAmt = 0;

        public Decimal OrdCpnCouponDiscountAmt
        {
            get { return ordCpnCouponDiscountAmt; }
            set { ordCpnCouponDiscountAmt = value; }
        }
        private int ordCpnIsCollected = 0;

        public int OrdCpnIsCollected
        {
            get { return ordCpnIsCollected; }
            set { ordCpnIsCollected = value; }
        }
        private String ordCpnExtendedCode = String.Empty;

        public String OrdCpnExtendedCode
        {
            get { return ordCpnExtendedCode; }
            set { ordCpnExtendedCode = value; }
        }

        private String nombreEmpleado;

        public String NombreEmpleado
        {
            get { return nombreEmpleado; }
            set { nombreEmpleado = value; }
        }

        private String phone;
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private Decimal orderPaymentDueAmt;
        public Decimal OrderPaymentDueAmt
        {
            get { return orderPaymentDueAmt; }
            set { orderPaymentDueAmt = value; }
        }

        private int cupon1Quantity;
        public int Cupon1Quantity
        {
            get { return cupon1Quantity; }
            set { cupon1Quantity = value; }
        }

        private int cupon2Quantity;
        public int Cupon2Quantity
        {
            get { return cupon2Quantity; }
            set { cupon2Quantity = value; }
        }

        private int cupon3Quantity;
        public int Cupon3Quantity
        {
            get { return cupon3Quantity; }
            set { cupon3Quantity = value; }
        }

        private int cupon4Quantity;
        public int Cupon4Quantity
        {
            get { return cupon4Quantity; }
            set { cupon4Quantity = value; }
        }

        private int cupon5Quantity;
        public int Cupon5Quantity
        {
            get { return cupon5Quantity; }
            set { cupon5Quantity = value; }
        }

        private int cupon6Quantity;
        public int Cupon6Quantity
        {
            get { return cupon6Quantity; }
            set { cupon6Quantity = value; }
        }

        private int cupon7Quantity;
        public int Cupon7Quantity
        {
            get { return cupon7Quantity; }
            set { cupon7Quantity = value; }
        }

        private int cupon8Quantity;
        public int Cupon8Quantity
        {
            get { return cupon8Quantity; }
            set { cupon8Quantity = value; }
        }

        private double cupon9Quantity;
        public double Cupon9Quantity
        {
            get { return cupon9Quantity; }
            set { cupon9Quantity = value; }
        }


        private double cupon11Quantity;
        public double Cupon11Quantity
        {
            get { return cupon11Quantity; }
            set { cupon11Quantity = value; }
        }

        private double cupon12Quantity;
        public double Cupon12Quantity
        {
            get { return cupon12Quantity; }
            set { cupon12Quantity = value; }
        }


        //private double cupon13Quantity;
        //public double Cupon13Quantity
        //{
        //    get { return cupon13Quantity; }
        //    set { cupon13Quantity = value; }
        //}


        //private double cupon14Quantity;
        //public double Cupon14Quantity
        //{
        //    get { return cupon14Quantity; }
        //    set { cupon14Quantity = value; }
        //}


        private double cupon15Quantity;
        public double Cupon15Quantity
        {
            get { return cupon15Quantity; }
            set { cupon15Quantity = value; }
        }


        private double cupon16Quantity;
        public double Cupon16Quantity
        {
            get { return cupon16Quantity; }
            set { cupon16Quantity = value; }
        }


        private double cupon17Quantity;
        public double Cupon17Quantity
        {
            get { return cupon17Quantity; }
            set { cupon17Quantity = value; }
        }


        private double cupon18Quantity;
        public double Cupon18Quantity
        {
            get { return cupon18Quantity; }
            set { cupon18Quantity = value; }
        }


        private double totalcupones;
        public double Totalcupones
        {
            get { return totalcupones; }
            set { totalcupones = value; }
        }

        private double porcentaje;
        public double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        ////Ariadna Cadena 18/02/2021}
        private String customer_Name;

        public String Customer_Name
        {
            get { return customer_Name; }
            set { customer_Name = value; }
        }


        //para los cupones de san luis y tamaulipas


        private double porcentaje2a80;
        public double Porcentaje2a80
        {
            get { return porcentaje2a80; }
            set { porcentaje2a80 = value; }
        }

        private int cantidad_Ordenes;
        public int Cantidad_Ordenes
        {
            get { return cantidad_Ordenes; }
            set { cantidad_Ordenes = value; }
        }

        private int cupon2A80;
        public int Cupon2A80
        {
            get { return cupon2A80; }
            set { cupon2A80 = value; }
        }
        #region cupones genericos cantidad
        private int cupon1Qn;
        public int Cupon1Qn
        {
            get { return cupon1Qn; }
            set { cupon1Qn = value; }
        }
        private int cupon2Qn;
        public int Cupon2Qn
        {
            get { return cupon2Qn; }
            set { cupon2Qn = value; }
        }
        private int cupon3Qn;
        public int Cupon3Qn
        {
            get { return cupon3Qn; }
            set { cupon3Qn = value; }
        }
        private int cupon4Qn;
        public int Cupon4Qn
        {
            get { return cupon4Qn; }
            set { cupon4Qn = value; }
        }
        private int cupon5Qn;
        public int Cupon5Qn
        {
            get { return cupon5Qn; }
            set { cupon5Qn = value; }
        }
        private int cupon6Qn;
        public int Cupon6Qn
        {
            get { return cupon6Qn; }
            set { cupon6Qn = value; }
        }
        #endregion

        private int cuponN2E59;
        public int CuponN2E59
        {
            get { return cuponN2E59; }
            set { cuponN2E59 = value; }
        }

        private int adicionales;
        public int Adicionales
        {
            get { return adicionales; }
            set { adicionales = value; }
        }

        #region cupones genericos costos
        private double cupon1extra;
        private double cupon2extra;
        private double cupon3extra;
        private double cupon4extra;
        private double cupon5extra;
        private double cupon6extra;
        public double Cupon1extra
        {
            get { return cupon1extra; }
            set { cupon1extra = value; }
        }
        public double Cupon2extra
        {
            get { return cupon2extra; }
            set { cupon2extra = value; }
        }
        public double Cupon3extra
        {
            get { return cupon3extra; }
            set { cupon3extra = value; }
        }
        public double Cupon4extra
        {
            get { return cupon4extra; }
            set { cupon4extra = value; }
        }
        public double Cupon5extra
        {
            get { return cupon5extra; }
            set { cupon5extra = value; }
        }
        public double Cupon6extra
        {
            get { return cupon6extra; }
            set { cupon6extra = value; }
        }
        #endregion
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

        private int adicionalesPesos;
        public int AdicionalesPesos
        {
            get { return adicionalesPesos; }
            set { adicionalesPesos = value; }
        }

        private double banderaOK;
        public double BANDERAOK
        {
            get { return banderaOK; }
            set { banderaOK = value; }
        }

        private String store_No = String.Empty;//length 8
        public String Store_No
        {
            get { return store_No; }
            set { store_No = value; }
        }


        private Nullable<int> ord_No = 0;
        public Nullable<int> Ord_No
        {
            get { return ord_No; }
            set { ord_No = value; }
        }

        private String cpn_Cd = String.Empty;

        public String Cpn_Cd
        {
            get { return cpn_Cd; }
            set { cpn_Cd = value; }
        }

        private String prod_Size_Code = String.Empty;

        public String Prod_Size_Code
        {
            get { return prod_Size_Code; }
            set { prod_Size_Code = value; }
        }

        private string num_Empleado;
        public string Num_Empleado
        {
            get { return num_Empleado; }
            set { num_Empleado = value; }
        }


        private int cuponOG139;
        public int CuponOG139
        {
            get { return cuponOG139; }
            set { cuponOG139 = value; }
        }




        private int cuponOG139xextra;
        public int CuponOG139xextra
        {
            get { return cuponOG139xextra; }
            set { cuponOG139xextra = value; }
        }


        private int numSemana;

        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }

        private String razon;

        public String Razon
        {
            get { return razon; }
            set { razon = value; }
        }

        private int total_Orden;
        public int Total_Orden
        {
            get { return total_Orden; }
            set { total_Orden = value; }
        }
        
        private int orderFinalPrice;
        public int OrderFinalPrice
        {
            get { return orderFinalPrice; }
            set { orderFinalPrice = value; }
        }

        private int pagoconuber;
        public int Pagoconuber
        {
            get { return pagoconuber; }
            set { pagoconuber = value; }
        }
        //CAMPOS AGREGADOS EL 20/07/2021

        private String comments;

        public String Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private int order_Status_Code;

        public int Order_Status_Code
        {
            get { return order_Status_Code; }
            set { order_Status_Code = value; }
        }

        private String cancel_Reason;

        public String Cancel_Reason
        {
            get { return cancel_Reason; }
            set { cancel_Reason = value; }
        }

        private String orderStreetNumber;

        public String OrderStreetNumber
        {
            get { return orderStreetNumber; }
            set { orderStreetNumber = value; }
        }

        private String orderStreetName;

        public String OrderStreetName
        {
            get { return orderStreetName; }
            set { orderStreetName = value; }
        }

        private String orderAddressLine2;

        public String OrderAddressLine2
        {
            get { return orderAddressLine2; }
            set { orderAddressLine2 = value; }
        }


        private String orderAddressLine4;

        public String OrderAddressLine4
        {
            get { return orderAddressLine4; }
            set { orderAddressLine4 = value; }
        }

        private String orderPostalCode;

        public String OrderPostalCode
        {
            get { return orderPostalCode; }
            set { orderPostalCode = value; }
        }


        private String orderCityName;

        public String OrderCityName
        {
            get { return orderCityName; }
            set { orderCityName = value; }
        }
    }


}

