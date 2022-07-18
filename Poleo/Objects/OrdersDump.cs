using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrdersDump
    {
        private string recordType;
		private string version;
		private string location_Code;
		private int order_Number;
		private DateTime order_Date;
		private int old_Order_Number;
		private bool? being_Modified;
		private string modifying;
		private int customer_Code;
		private string customer_Room;
		private string customer_Name;
		private string comments;
		private DateTime? actual_Order_Date;
		private int order_Status_Code;
		private string order_Type_Code;
		private DateTime? order_Saved;
		private int order_Time;
		private decimal sales_Tax1;
		private decimal? sales_Tax2;
		private decimal coupon_Total;
		private decimal subTotal;
		private DateTime? route_Time;
		private string driver_ID;
		private string driver_Shift;
		private DateTime? return_Time;
		private DateTime? delivery_Time;
		private decimal delivery_Fee;
		private decimal taxable_Sales1;
		private decimal taxable_Sales2;
		private decimal non_Taxable_Sales;
		private string computer_Name;
		private string added_By;
		private DateTime? added;
		private string cancel_Reason;
		private string added_By_Location_Code;
		private string source_Code;
		private decimal? bottleDepTotal;
		private decimal discount_Amount;
		private string void_Canc_Auth_Code;
		private int orderRevNbr;
		private DateTime? orderTakeCompleteTime;
		private int? orderLoadTimeSecs;
		private int? orderRackTimeSecs;
		private int? orderDispatchTimeSecs;
		private int? orderDeliveryTimeSecs;
		private decimal orderListPrice;
		private decimal? orderMenuDiscountAmt;
		private decimal? orderLineDiscountAmt;
		private decimal? orderDiscountAmt;
		private decimal orderFinalPrice;
		private decimal orderRoyaltySales;
		private decimal? orderIdealFoodCost;
		private int orderEditCount;
		private string editEmployeeCode;
		private DateTime? orderEditDate;
		private int orderReprintCount;
		private string reprintEmployeeCode;
		private DateTime? orderReprintDate;
		private int? orderRunStopSeq;
		private int? orderRunStopCount;
		private string updateEmployeeCode;
		private DateTime? orderUpdateDate;
		private bool? orderIsTaxExempt;
		private string orderTaxExemptCode;
		private bool orderIsTaxExempt2;
		private string orderTaxExemptCode2;
		private bool? orderIsPersonalCar;
		private bool? orderHasLabelPrinted;
		private bool? orderHasReceiptPrinted;
		private decimal orderPaymentDueAmt;
		private string orderPhoneNumber;
		private string orderPhoneExt;
		private string orderCompanyName;
		private string orderStreetNumber;
		private string orderStreetName;
		private string orderAddressLine2;
		private string orderAddressLine3;
		private string orderAddressLine4;
		private string orderPostalCode;
		private string orderCityName;
		private string orderRegionName;
		private string orderAddressType;
		private string databaseVersion;
		private DateTime? orderCompletedTime;
		private decimal? outboundMileage;
		private decimal? returnMileage;
		private string mileageSource;
		private string authorizeEmployeeCode;
		private string vehicleCode;
		private DateTime orderSavedBusinessDate;
		private DateTime? calculatedDeliveryTime;
		private int? calculatedDeliveryTimeSecs;
		private int? outboundDriveTimeSecs;
		private int? returnDriveTimeSecs;
		private string driveTimeSource;
		private DateTime? calculatedReturnTime;
        private bool iSVerifyCallback;

        public string RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public string Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        public int Order_Number
        {
            get { return order_Number; }
            set { order_Number = value; }
        }

        public DateTime Order_Date
        {
            get { return order_Date; }
            set { order_Date = value; }
        }

        public int Old_Order_Number
        {
            get { return old_Order_Number; }
            set { old_Order_Number = value; }
        }

        public bool? Being_Modified
        {
            get { return being_Modified; }
            set { being_Modified = value; }
        }

        public string Modifying
        {
            get { return modifying; }
            set { modifying = value; }
        }

        public int Customer_Code
        {
            get { return customer_Code; }
            set { customer_Code = value; }
        }

        public string Customer_Room
        {
            get { return customer_Room; }
            set { customer_Room = value; }
        }

        public string Customer_Name
        {
            get { return customer_Name; }
            set { customer_Name = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public DateTime? Actual_Order_Date
        {
            get { return actual_Order_Date; }
            set { actual_Order_Date = value; }
        }

        public int Order_Status_Code
        {
            get { return order_Status_Code; }
            set { order_Status_Code = value; }
        }

        public string Order_Type_Code
        {
            get { return order_Type_Code; }
            set { order_Type_Code = value; }
        }

        public DateTime? Order_Saved
        {
            get { return order_Saved; }
            set { order_Saved = value; }
        }

        public int Order_Time
        {
            get { return order_Time; }
            set { order_Time = value; }
        }

        public decimal Sales_Tax1
        {
            get { return sales_Tax1; }
            set { sales_Tax1 = value; }
        }

        public decimal? Sales_Tax2
        {
            get { return sales_Tax2; }
            set { sales_Tax2 = value; }
        }

        public decimal Coupon_Total
        {
            get { return coupon_Total; }
            set { coupon_Total = value; }
        }

        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public DateTime? Route_Time
        {
            get { return route_Time; }
            set { route_Time = value; }
        }

        public string Driver_ID
        {
            get { return driver_ID; }
            set { driver_ID = value; }
        }

        public string Driver_Shift
        {
            get { return driver_Shift; }
            set { driver_Shift = value; }
        }

        public DateTime? Return_Time
        {
            get { return return_Time; }
            set { return_Time = value; }
        }
        public DateTime? Delivery_Time
        {
            get { return delivery_Time; }
            set { delivery_Time = value; }
        }

        public decimal Delivery_Fee
        {
            get { return delivery_Fee; }
            set { delivery_Fee = value; }
        }

        public decimal Taxable_Sales1
        {
            get { return taxable_Sales1; }
            set { taxable_Sales1 = value; }
        }

        public decimal Taxable_Sales2
        {
            get { return taxable_Sales2; }
            set { taxable_Sales2 = value; }
        }

        public decimal Non_Taxable_Sales
        {
            get { return non_Taxable_Sales; }
            set { non_Taxable_Sales = value; }
        }

        public string Computer_Name
        {
            get { return computer_Name; }
            set { computer_Name = value; }
        }

        public string Added_By
        {
            get { return added_By; }
            set { added_By = value; }
        }

        public DateTime? Added
        {
            get { return added; }
            set { added = value; }
        }

        public string Cancel_Reason
        {
            get { return cancel_Reason; }
            set { cancel_Reason = value; }
        }

        public string Added_By_Location_Code
        {
            get { return added_By_Location_Code; }
            set { added_By_Location_Code = value; }
        }

        public string Source_Code
        {
            get { return source_Code; }
            set { source_Code = value; }
        }

        public decimal? BottleDepTotal
        {
            get { return bottleDepTotal; }
            set { bottleDepTotal = value; }
        }

        public decimal Discount_Amount
        {
            get { return discount_Amount; }
            set { discount_Amount = value; }
        }

        public string Void_Canc_Auth_Code
        {
            get { return void_Canc_Auth_Code; }
            set { void_Canc_Auth_Code = value; }
        }

        public int OrderRevNbr
        {
            get { return orderRevNbr; }
            set { orderRevNbr = value; }
        }

        public DateTime? OrderTakeCompleteTime
        {
            get { return orderTakeCompleteTime; }
            set { orderTakeCompleteTime = value; }
        }

        public int? OrderLoadTimeSecs
        {
            get { return orderLoadTimeSecs; }
            set { orderLoadTimeSecs = value; }
        }

        public int? OrderRackTimeSecs
        {
            get { return orderRackTimeSecs; }
            set { orderRackTimeSecs = value; }
        }

        public int? OrderDispatchTimeSecs
        {
            get { return orderDispatchTimeSecs; }
            set { orderDispatchTimeSecs = value; }
        }

        public int? OrderDeliveryTimeSecs
        {
            get { return orderDeliveryTimeSecs; }
            set { orderDeliveryTimeSecs = value; }
        }

        public decimal OrderListPrice
        {
            get { return orderListPrice;}
            set { orderListPrice = value; }
        }

        public decimal? OrderMenuDiscountAmt
        {
            get { return orderMenuDiscountAmt; }
            set { orderMenuDiscountAmt = value; }
        }

        public decimal? OrderLineDiscountAmt
        {
            get { return orderLineDiscountAmt; }
            set { orderLineDiscountAmt = value; }
        }

        public decimal? OrderDiscountAmt
        {
            get { return orderDiscountAmt; }
            set { orderDiscountAmt = value; }
        }

        public decimal OrderFinalPrice
        {
            get { return orderFinalPrice; }
            set { orderFinalPrice = value; }
        }

        public decimal OrderRoyaltySales
        {
            get { return orderRoyaltySales; }
            set { orderRoyaltySales = value; }
        }

        public decimal? OrderIdealFoodCost
        {
            get { return orderIdealFoodCost; }
            set { orderIdealFoodCost = value; }
        }

        public int OrderEditCount
        {
            get { return orderEditCount; }
            set { orderEditCount = value; }
        }

        public string EditEmployeeCode
        {
            get { return editEmployeeCode; }
            set { editEmployeeCode = value; }
        }

        public DateTime? OrderEditDate
        {
            get { return orderEditDate; }
            set { orderEditDate = value; }
        }

        public int OrderReprintCount
        {
            get { return orderReprintCount; }
            set { orderReprintCount = value; }
        }

        public string ReprintEmployeeCode
        {
            get { return reprintEmployeeCode; }
            set { reprintEmployeeCode = value; }
        }

        public DateTime? OrderReprintDate
        {
            get { return orderReprintDate; }
            set { orderReprintDate = value; }
        }

        public int? OrderRunStopSeq
        {
            get { return orderRunStopSeq; }
            set { orderRunStopSeq = value; }
        }

        public int? OrderRunStopCount
        {
            get { return orderRunStopSeq; }
            set { orderRunStopSeq = value; }
        }

        public string UpdateEmployeeCode
        {
            get { return updateEmployeeCode; }
            set { updateEmployeeCode = value; }
        }

        public DateTime? OrderUpdateDate
        {
            get { return orderUpdateDate;}
            set { orderUpdateDate = value; }
        }

        public bool? OrderIsTaxExempt
        {
            get { return orderIsTaxExempt; }
            set { orderIsTaxExempt = value; }
        }

        public string OrderTaxExemptCode
        {
            get { return orderTaxExemptCode; }
            set { orderTaxExemptCode = value; }
        }

        public bool OrderIsTaxExempt2
        {
            get { return orderIsTaxExempt2; }
            set { orderIsTaxExempt2 = value; }
        }

        public string OrderTaxExemptCode2
        {
            get { return orderTaxExemptCode2; }
            set { orderTaxExemptCode2 = value; }
        }

        public bool? OrderIsPersonalCar
        {
            get { return orderIsPersonalCar; }
            set { orderIsPersonalCar = value; }
        }

        public bool? OrderHasLabelPrinted
        {
            get { return orderHasLabelPrinted; }
            set { orderHasLabelPrinted = value; }
        }

        public bool? OrderHasReceiptPrinted
        {
            get { return orderHasReceiptPrinted; }
            set { orderHasReceiptPrinted = value; }
        }

        public decimal OrderPaymentDueAmt
        {
            get { return orderPaymentDueAmt; }
            set { orderPaymentDueAmt = value; }
        }

        public string OrderPhoneNumber
        {
            get { return orderPhoneNumber; }
            set { orderPhoneNumber = value; }
        }

        public string OrderPhoneExt
        {
            get { return orderPhoneExt; }
            set { orderPhoneExt = value; }
        }

        public string OrderCompanyName
        {
            get { return orderCompanyName; }
            set { orderCompanyName = value; }
        }

        public string OrderStreetNumber
        {
            get { return orderStreetNumber; }
            set { orderStreetNumber = value; }
        }

        public string OrderStreetName
        {
            get { return orderStreetName; }
            set { orderStreetName = value; }
        }

        public string OrderAddressLine2
        {
            get { return orderAddressLine2; }
            set { orderAddressLine2 = value; }
        }

        public string OrderAddressLine3
        {
            get { return orderAddressLine3; }
            set { orderAddressLine3 = value; }
        }

        public string OrderAddressLine4
        {
            get { return orderAddressLine4; }
            set { orderAddressLine4 = value; }
        }

        public string OrderPostalCode
        {
            get { return orderPostalCode; }
            set { orderPostalCode = value; }
        }

        public string OrderCityName
        {
            get { return orderCityName; }
            set { orderCityName = value; }
        }

        public string OrderRegionName
        {
            get { return orderRegionName; }
            set { orderRegionName = value; }
        }

        public string OrderAddressType
        {
            get { return orderAddressType; }
            set { orderAddressType = value; }
        }

        public string DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }

        public DateTime? OrderCompletedTime
        {
            get { return orderCompletedTime; }
            set { orderCompletedTime = value; }
        }

        public decimal? OutboundMileage
        {
            get { return outboundMileage; }
            set { outboundMileage = value; }
        }

        public decimal? ReturnMileage
        {
            get { return returnMileage; }
            set { returnMileage = value; }
        }

        public string MileageSource
        {
            get { return mileageSource; }
            set { mileageSource = value; }
        }

        public string AuthorizeEmployeeCode
        {
            get { return authorizeEmployeeCode; }
            set { authorizeEmployeeCode = value; }
        }

        public string VehicleCode
        {
            get { return vehicleCode; }
            set { vehicleCode = value; }
        }

        public DateTime OrderSavedBusinessDate
        {
            get { return orderSavedBusinessDate; }
            set { orderSavedBusinessDate = value; }
        }

        public DateTime? CalculatedDeliveryTime
        {
            get { return calculatedDeliveryTime; }
            set { calculatedDeliveryTime = value; }
        }

        public int? CalculatedDeliveryTimeSecs
        {
            get { return calculatedDeliveryTimeSecs; }
            set { calculatedDeliveryTimeSecs = value; }
        }

        public int? OutboundDriveTimeSecs
        {
            get { return outboundDriveTimeSecs; }
            set { outboundDriveTimeSecs = value; }
        }

        public int? ReturnDriveTimeSecs
        {
            get { return returnDriveTimeSecs; }
            set { returnDriveTimeSecs = value; }
        }

        public string DriveTimeSource
        {
            get { return driveTimeSource; }
            set { driveTimeSource = value; }
        }

        public DateTime? CalculatedReturnTime
        {
            get { return calculatedReturnTime; }
            set { calculatedReturnTime = value; }
        }

        public bool ISVerifyCallback
        {
            get { return iSVerifyCallback; }
            set { iSVerifyCallback = value; }
        }


      

    }
}