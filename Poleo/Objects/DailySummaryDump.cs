using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poleo.Objects
{
    public class DailySummaryDump
    {
        private String databaseVersion = String.Empty; //length 8 

        public String DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }
        private String recordType = String.Empty;

        public String RecordType
        {
          get { return recordType; }
          set { recordType = value; }
        }
        private String location_Code = String.Empty;

            public String Location_Code
            {
              get { return location_Code; }
              set { location_Code = value; }
            }
	                private DateTime system_Date = DateTime.MinValue;

            public DateTime System_Date
            {
              get { return system_Date; }
              set { system_Date = value; }
            }
	                private Decimal master_Total = 0;

            public Decimal Master_Total
            {
              get { return master_Total; }
              set { master_Total = value; }
            }
	                private Decimal void_Orders=0;

            public Decimal Void_Orders
            {
              get { return void_Orders; }
              set { void_Orders = value; }
            }
	                private Decimal bad_Orders=0;

            public Decimal Bad_Orders
            {
              get { return bad_Orders; }
              set { bad_Orders = value; }
            } 
	                private Decimal total_Sales=0;

            public Decimal Total_Sales
            {
              get { return total_Sales; }
              set { total_Sales = value; }
            }
	                private Decimal sales_Tax=0;

            public Decimal Sales_Tax
            {
              get { return sales_Tax; }
              set { sales_Tax = value; }
            }
	                private Decimal  bottle_Deposits=0;

            public Decimal Bottle_Deposits
            {
              get { return bottle_Deposits; }
              set { bottle_Deposits = value; }
            }
	                private Decimal  net_Sales=0;

            public Decimal Net_Sales
            {
              get { return net_Sales; }
              set { net_Sales = value; }
            }
                    private Decimal coupons= 0;

            public Decimal Coupons
            {
              get { return coupons; }
              set { coupons = value; }
            }
	                private Decimal non_Royalty_Sales= 0;

            public Decimal Non_Royalty_Sales
            {
              get { return non_Royalty_Sales; }
              set { non_Royalty_Sales = value; }
            }
	                private Decimal royalty_Sales= 0;

            public Decimal Royalty_Sales
            {
              get { return royalty_Sales; }
              set { royalty_Sales = value; }
            }
	                private Decimal delivery_Company_Car= 0;

            public Decimal Delivery_Company_Car
            {
              get { return delivery_Company_Car; }
              set { delivery_Company_Car = value; }
            }
	                private int delivery_Company_Car_Count= 0;

            public int Delivery_Company_Car_Count
            {
              get { return delivery_Company_Car_Count; }
              set { delivery_Company_Car_Count = value; }
            }
	                private Decimal delivery_Personal_Car= 0;

            public Decimal Delivery_Personal_Car
            {
              get { return delivery_Personal_Car; }
              set { delivery_Personal_Car = value; }
            }
	                private int delivery_Personal_Car_Count= 0;

            public int Delivery_Personal_Car_Count
            {
              get { return delivery_Personal_Car_Count; }
              set { delivery_Personal_Car_Count = value; }
            }
	                private Decimal carry_Out= 0;

            public Decimal Carry_Out
            {
              get { return carry_Out; }
              set { carry_Out = value; }
            }
	                private int carry_Out_Count= 0;

            public int Carry_Out_Count
            {
              get { return carry_Out_Count; }
              set { carry_Out_Count = value; }
            }
	                private Decimal pick_Up= 0;

            public Decimal Pick_Up
            {
              get { return pick_Up; }
              set { pick_Up = value; }
            }
	                private int pick_Up_Count= 0;

            public int Pick_Up_Count
            {
              get { return pick_Up_Count; }
              set { pick_Up_Count = value; }
            }
	                private Decimal dine_In= 0;

            public Decimal Dine_In
            {
              get { return dine_In; }
              set { dine_In = value; }
            }
	                private int dine_In_Count= 0;

            public int Dine_In_Count
            {
              get { return dine_In_Count; }
              set { dine_In_Count = value; }
            }
	                private Decimal food= 0;

            public Decimal Food
            {
              get { return food; }
              set { food = value; }
            }
	                private Decimal labor= 0;

            public Decimal Labor
            {
              get { return labor; }
              set { labor = value; }
            }
	                private Decimal mileage= 0;

            public Decimal Mileage
            {
              get { return mileage; }
              set { mileage = value; }
            }
	                private Decimal food_Bought= 0;

            public Decimal Food_Bought
            {
              get { return food_Bought; }
              set { food_Bought = value; }
            }
	                private Decimal raise_Till= 0;

            public Decimal Raise_Till
            {
              get { return raise_Till; }
              set { raise_Till = value; }
            }
	                private Decimal mileage_All= 0;

            public Decimal Mileage_All
            {
              get { return mileage_All; }
              set { mileage_All = value; }
            }
	                private Decimal contract_Labor= 0;

            public Decimal Contract_Labor
            {
              get { return contract_Labor; }
              set { contract_Labor = value; }
            }
	                private Decimal total_CPO= 0;

            public Decimal Total_CPO
            {
              get { return total_CPO; }
              set { total_CPO = value; }
            }
	                private Decimal food_Sold= 0;

            public Decimal Food_Sold
            {
              get { return food_Sold; }
              set { food_Sold = value; }
            }
	                private Decimal lower_Till= 0;

            public Decimal Lower_Till
            {
              get { return lower_Till; }
              set { lower_Till = value; }
            }
	                private Decimal total_MROTS= 0;

            public Decimal Total_MROTS
            {
              get { return total_MROTS; }
              set { total_MROTS = value; }
            }
	                private Decimal bank_Deposits= 0;

            public Decimal Bank_Deposits
            {
              get { return bank_Deposits; }
              set { bank_Deposits = value; }
            }
	                private Decimal ending_Till= 0;

            public Decimal Ending_Till
            {
              get { return ending_Till; }
              set { ending_Till = value; }
            }
	                private String manager=String.Empty;

            public String Manager
            {
              get { return manager; }
              set { manager = value; }
            }
	                private int total_Orders= 0;

            public int Total_Orders
            {
              get { return total_Orders; }
              set { total_Orders = value; }
            }
	                private int min_Order_Number= 0;

            public int Min_Order_Number
            {
              get { return min_Order_Number; }
              set { min_Order_Number = value; }
            }
	                private int max_Order_Number= 0;

            public int Max_Order_Number
            {
              get { return max_Order_Number; }
              set { max_Order_Number = value; }
            }
	                private int orders_In_Range= 0;

            public int Orders_In_Range
            {
              get { return orders_In_Range; }
              set { orders_In_Range = value; }
            }
	                private Decimal min_Price_Per_Order= 0;

            public Decimal Min_Price_Per_Order
            {
              get { return min_Price_Per_Order; }
              set { min_Price_Per_Order = value; }
            }
	                private Decimal max_Price_Per_Order= 0;

            public Decimal Max_Price_Per_Order
            {
              get { return max_Price_Per_Order; }
              set { max_Price_Per_Order = value; }
            }
	                private Decimal average_Price= 0;

            public Decimal Average_Price
            {
              get { return average_Price; }
              set { average_Price = value; }
            }
	                private Single average_Order_Time= 0;

            public Single Average_Order_Time
            {
              get { return average_Order_Time; }
              set { average_Order_Time = value; }
            }
	                private Single average_Load_Time= 0;

            public Single Average_Load_Time
            {
              get { return average_Load_Time; }
              set { average_Load_Time = value; }
            }
	                private Single average_OTD_Time= 0;

            public Single Average_OTD_Time
            {
              get { return average_OTD_Time; }
              set { average_OTD_Time = value; }
            }
	                private Single average_Delivery_Time= 0;

            public Single Average_Delivery_Time
            {
              get { return average_Delivery_Time; }
              set { average_Delivery_Time = value; }
            }
	                private Decimal inside_Labor= 0;

            public Decimal Inside_Labor
            {
              get { return inside_Labor; }
              set { inside_Labor = value; }
            }
	                private Decimal outside_Labor= 0;

            public Decimal Outside_Labor
            {
              get { return outside_Labor; }
              set { outside_Labor = value; }
            }
	                private Decimal hourly_Labor= 0;

            public Decimal Hourly_Labor
            {
              get { return hourly_Labor; }
              set { hourly_Labor = value; }
            }
	                private Decimal salary_Labor= 0;

            public Decimal Salary_Labor
            {
              get { return salary_Labor; }
              set { salary_Labor = value; }
            }
	                private String eOD_Comments = String.Empty;

            public String EOD_Comments
            {
              get { return eOD_Comments; }
              set { eOD_Comments = value; }
            }
	                private Decimal iFC= 0;

            public Decimal IFC
            {
              get { return iFC; }
              set { iFC = value; }
            }
	                private Decimal non_Taxable_Sales= 0;

            public Decimal Non_Taxable_Sales
            {
              get { return non_Taxable_Sales; }
              set { non_Taxable_Sales = value; }
            }
	                private int less_Than_20_OTD= 0;

            public int Less_Than_20_OTD
            {
              get { return less_Than_20_OTD; }
              set { less_Than_20_OTD = value; }
            }
	                private Single average_Orders_Per_Dispatch= 0;

            public Single Average_Orders_Per_Dispatch
            {
              get { return average_Orders_Per_Dispatch; }
              set { average_Orders_Per_Dispatch = value; }
            }
	                private Decimal timed_Delivery_Company_Car= 0;

            public Decimal Timed_Delivery_Company_Car
            {
              get { return timed_Delivery_Company_Car; }
              set { timed_Delivery_Company_Car = value; }
            }
	                private int timed_Delivery_Company_Car_Count= 0;

            public int Timed_Delivery_Company_Car_Count
            {
              get { return timed_Delivery_Company_Car_Count; }
              set { timed_Delivery_Company_Car_Count = value; }
            }
	                private Decimal timed_Delivery_Personal_Car= 0;

            public Decimal Timed_Delivery_Personal_Car
            {
              get { return timed_Delivery_Personal_Car; }
              set { timed_Delivery_Personal_Car = value; }
            }
	                private int timed_Delivery_Personal_Car_Count= 0;

            public int Timed_Delivery_Personal_Car_Count
            {
              get { return timed_Delivery_Personal_Car_Count; }
              set { timed_Delivery_Personal_Car_Count = value; }
            }
	                private Decimal timed_Carry_Out= 0;

            public Decimal Timed_Carry_Out
            {
              get { return timed_Carry_Out; }
              set { timed_Carry_Out = value; }
            }
	                private int timed_Carry_Out_Count= 0;

            public int Timed_Carry_Out_Count
            {
              get { return timed_Carry_Out_Count; }
              set { timed_Carry_Out_Count = value; }
            }
	                private Decimal timed_Pick_Up= 0;

            public Decimal Timed_Pick_Up
            {
              get { return timed_Pick_Up; }
              set { timed_Pick_Up = value; }
            }
	                private int timed_Pick_Up_Count= 0;

            public int Timed_Pick_Up_Count
            {
              get { return timed_Pick_Up_Count; }
              set { timed_Pick_Up_Count = value; }
            }
	                private Decimal timed_Dine_In= 0;

            public Decimal Timed_Dine_In
            {
              get { return timed_Dine_In; }
              set { timed_Dine_In = value; }
            }
	                private int timed_Dine_In_Count= 0;

            public int Timed_Dine_In_Count
            {
              get { return timed_Dine_In_Count; }
              set { timed_Dine_In_Count = value; }
            }
	                private String added_By=String.Empty;

            public String Added_By
            {
              get { return added_By; }
              set { added_By = value; }
            }
	                private DateTime added= DateTime.MinValue;

            public DateTime Added
            {
              get { return added; }
              set { added = value; }
            }
	                private int pIGOrders= 0;

            public int PIGOrders
            {
              get { return pIGOrders; }
              set { pIGOrders = value; }
            }
	                private Decimal pIGOrderAmount= 0;

            public Decimal PIGOrderAmount
            {
              get { return pIGOrderAmount; }
              set { pIGOrderAmount = value; }
            }
	                private int missingBoxes= 0;

            public int MissingBoxes
            {
              get { return missingBoxes; }
              set { missingBoxes = value; }
            }
	                private Decimal missingBoxAmount= 0;

            public Decimal MissingBoxAmount
            {
              get { return missingBoxAmount; }
              set { missingBoxAmount = value; }
            }
	                private int newCustomers= 0;

            public int NewCustomers
            {
              get { return newCustomers; }
              set { newCustomers = value; }
            }
	                private int allCustomers= 0;

            public int AllCustomers
            {
              get { return allCustomers; }
              set { allCustomers = value; }
            }
	                private Decimal creditCardOrders_CPO= 0;

            public Decimal CreditCardOrders_CPO
            {
              get { return creditCardOrders_CPO; }
              set { creditCardOrders_CPO = value; }
            }
	                private Decimal tROrders_CPO= 0;

            public Decimal TROrders_CPO
            {
              get { return tROrders_CPO; }
              set { tROrders_CPO = value; }
            }
	                private Decimal gCOrders_CPO= 0;

            public Decimal GCOrders_CPO
            {
              get { return gCOrders_CPO; }
              set { gCOrders_CPO = value; }
            }
	                private Decimal creditCardOrders_MROTS= 0;

            public Decimal CreditCardOrders_MROTS
            {
              get { return creditCardOrders_MROTS; }
              set { creditCardOrders_MROTS = value; }
            }
	                private Decimal tROrders_MROTS= 0;

            public Decimal TROrders_MROTS
            {
              get { return tROrders_MROTS; }
              set { tROrders_MROTS = value; }
            }
	                private Decimal gCOrders_MROTS= 0;

            public Decimal GCOrders_MROTS
            {
              get { return gCOrders_MROTS; }
              set { gCOrders_MROTS = value; }
            }
	                private int electronicOrders= 0;

            public int ElectronicOrders
            {
              get { return electronicOrders; }
              set { electronicOrders = value; }
            }
	                private Decimal electronicOrderAmount= 0;

            public Decimal ElectronicOrderAmount
            {
              get { return electronicOrderAmount; }
              set { electronicOrderAmount = value; }
            }
	                private Decimal giftCardPurchases= 0;

            public Decimal GiftCardPurchases
            {
              get { return giftCardPurchases; }
              set { giftCardPurchases = value; }
            }
	                private Decimal gCPurchasedWithCC= 0;

            public Decimal GCPurchasedWithCC
            {
              get { return gCPurchasedWithCC; }
              set { gCPurchasedWithCC = value; }
            }
	                private Single pIGPercent= 0;

            public Single PIGPercent
            {
              get { return pIGPercent; }
              set { pIGPercent = value; }
            }
	                private Nullable<int> walkInOrders= 0;

            public Nullable<int> WalkInOrders
            {
              get { return walkInOrders; }
              set { walkInOrders = value; }
            }
	                private Nullable<Decimal> walkInOrderAmount= 0;

            public Nullable<Decimal> WalkInOrderAmount
            {
              get { return walkInOrderAmount; }
              set { walkInOrderAmount = value; }
            }
	                private Nullable<int> phoneInOrders= 0;

            public Nullable<int> PhoneInOrders
            {
              get { return phoneInOrders; }
              set { phoneInOrders = value; }
            }
	                private Nullable<Decimal> phoneInOrderAmount= 0;

            public Nullable<Decimal> PhoneInOrderAmount
            {
              get { return phoneInOrderAmount; }
              set { phoneInOrderAmount = value; }
            }
                }
}
