using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class KeysExtractsCorpVersion
    {

         private String recordType = String.Empty ;// max length 8

            public String RecordType
            {
              get { return recordType; }
              set { recordType = value; }
            }
	     private String databaseVersion = String.Empty ;// max length 8

         public String DatabaseVersion
{
  get { return databaseVersion; }
  set { databaseVersion = value; }
}
	     private String location_Code= String.Empty ;// max length 8

         public String Location_Code
{
  get { return location_Code; }
  set { location_Code = value; }
}
	     private DateTime beginDate = DateTime.MinValue;

         public DateTime BeginDate
{
  get { return beginDate; }
  set { beginDate = value; }
}
	     private DateTime endDate  = DateTime.MinValue;

         public DateTime EndDate
{
  get { return endDate; }
  set { endDate = value; }
}
	     private int master_Order_Count= 0;

            public int Master_Order_Count
{
  get { return master_Order_Count; }
  set { master_Order_Count = value; }
}
            private Nullable<Decimal> master_Sales = 0;

            public Nullable<Decimal> Master_Sales
            {
                get { return master_Sales; }
                set { master_Sales = value; }
            }
            private Nullable<int> void_Order_Count = 0;

            public Nullable<int> Void_Order_Count
            {
                get { return void_Order_Count; }
                set { void_Order_Count = value; }
            }
            private Nullable<Decimal> void_Sales = 0;

            public Nullable<Decimal> Void_Sales
            {
                get { return void_Sales; }
                set { void_Sales = value; }
            }
            private Nullable<int> bad_Order_Count = 0;

            public Nullable<int> Bad_Order_Count
            {
                get { return bad_Order_Count; }
                set { bad_Order_Count = value; }
            }
            private Nullable<Decimal> bad_Sales = 0;

            public Nullable<Decimal> Bad_Sales
            {
                get { return bad_Sales; }
                set { bad_Sales = value; }
            }
            private Nullable<int> order_Count = 0;

            public Nullable<int> Order_Count
            {
                get { return order_Count; }
                set { order_Count = value; }
            }
            private Nullable<Decimal> total_Sales = 0;

            public Nullable<Decimal> Total_Sales
            {
                get { return total_Sales; }
                set { total_Sales = value; }
            }
            private Nullable<Decimal> tax_Amount = 0;

            public Nullable<Decimal> Tax_Amount
            {
                get { return tax_Amount; }
                set { tax_Amount = value; }
            }
            private Nullable<Decimal> bottle_Deposit_Amount = 0;

            public Nullable<Decimal> Bottle_Deposit_Amount
            {
                get { return bottle_Deposit_Amount; }
                set { bottle_Deposit_Amount = value; }
            }
            private Nullable<Decimal> net_Sales = 0;

            public Nullable<Decimal> Net_Sales
            {
                get { return net_Sales; }
                set { net_Sales = value; }
            }
            private Nullable<Decimal> delivery_Fee = 0;

            public Nullable<Decimal> Delivery_Fee
            {
                get { return delivery_Fee; }
                set { delivery_Fee = value; }
            }
            private Nullable<Decimal> order_Discount_Amount = 0;

            public Nullable<Decimal> Order_Discount_Amount
            {
                get { return order_Discount_Amount; }
                set { order_Discount_Amount = value; }
            }
            private Nullable<Decimal> item_Net = 0;

            public Nullable<Decimal> Item_Net
            {
                get { return item_Net; }
                set { item_Net = value; }
            }
            private Nullable<Decimal> item_Discount_Amount = 0;

            public Nullable<Decimal> Item_Discount_Amount
            {
                get { return item_Discount_Amount; }
                set { item_Discount_Amount = value; }
            }
            private Nullable<Decimal> item_Menu_Amount = 0;

            public Nullable<Decimal> Item_Menu_Amount
            {
                get { return item_Menu_Amount; }
                set { item_Menu_Amount = value; }
            }
            private Nullable<Decimal> nonAdjustment_Coupon_Amount = 0;

            public Nullable<Decimal> NonAdjustment_Coupon_Amount
            {
                get { return nonAdjustment_Coupon_Amount; }
                set { nonAdjustment_Coupon_Amount = value; }
            }
            private Nullable<Decimal> royalty_Sales = 0;

            public Nullable<Decimal> Royalty_Sales
            {
                get { return royalty_Sales; }
                set { royalty_Sales = value; }
            }
            private Nullable<Decimal> non_Royalty_Sales = 0;

            public Nullable<Decimal> Non_Royalty_Sales
            {
                get { return non_Royalty_Sales; }
                set { non_Royalty_Sales = value; }
            }
            private Nullable<Decimal> non_Taxable_Sales = 0;

            public Nullable<Decimal> Non_Taxable_Sales
            {
                get { return non_Taxable_Sales; }
                set { non_Taxable_Sales = value; }
            }
            private Nullable<int> average_Ticket_Order_Count = 0;

            public Nullable<int> Average_Ticket_Order_Count
            {
                get { return average_Ticket_Order_Count; }
                set { average_Ticket_Order_Count = value; }
            }
            private Nullable<Decimal> average_Ticket_Net = 0;

            public Nullable<Decimal> Average_Ticket_Net
            {
                get { return average_Ticket_Net; }
                set { average_Ticket_Net = value; }
            }
            private Nullable<Decimal> average_Ticket = 0;

            public Nullable<Decimal> Average_Ticket
            {
                get { return average_Ticket; }
                set { average_Ticket = value; }
            }
            private Nullable<Decimal> min_Average_Ticket = 0;

            public Nullable<Decimal> Min_Average_Ticket
            {
                get { return min_Average_Ticket; }
                set { min_Average_Ticket = value; }
            }
            private Nullable<Decimal> max_Average_Ticket = 0;

            public Nullable<Decimal> Max_Average_Ticket
            {
                get { return max_Average_Ticket; }
                set { max_Average_Ticket = value; }
            }
            private Nullable<int> delivery_Order_Count = 0;

            public Nullable<int> Delivery_Order_Count
            {
                get { return delivery_Order_Count; }
                set { delivery_Order_Count = value; }
            }
            private Nullable<Decimal> delivery_Net = 0;

            public Nullable<Decimal> Delivery_Net
            {
                get { return delivery_Net; }
                set { delivery_Net = value; }
            }
            private Nullable<Decimal> delivery_Sales = 0;

            public Nullable<Decimal> Delivery_Sales
            {
                get { return delivery_Sales; }
                set { delivery_Sales = value; }
            }
            private Nullable<int> carryout_Order_Count = 0;

            public Nullable<int> Carryout_Order_Count
            {
                get { return carryout_Order_Count; }
                set { carryout_Order_Count = value; }
            }
            private Nullable<Decimal> carryout_Net = 0;

            public Nullable<Decimal> Carryout_Net
            {
                get { return carryout_Net; }
                set { carryout_Net = value; }
            }
            private Nullable<Decimal> carryout_Sales = 0;

            public Nullable<Decimal> Carryout_Sales
            {
                get { return carryout_Sales; }
                set { carryout_Sales = value; }
            }
            private Nullable<int> drive_Thru_Order_Count = 0;

            public Nullable<int> Drive_Thru_Order_Count
            {
                get { return drive_Thru_Order_Count; }
                set { drive_Thru_Order_Count = value; }
            }
            private Nullable<Decimal> drive_Thru_Net = 0;

            public Nullable<Decimal> Drive_Thru_Net
            {
                get { return drive_Thru_Net; }
                set { drive_Thru_Net = value; }
            }
            private Nullable<Decimal> drive_Thru_Sales = 0;

            public Nullable<Decimal> Drive_Thru_Sales
            {
                get { return drive_Thru_Sales; }
                set { drive_Thru_Sales = value; }
            }
            private Nullable<int> dine_In_Order_Count = 0;

            public Nullable<int> Dine_In_Order_Count
            {
                get { return dine_In_Order_Count; }
                set { dine_In_Order_Count = value; }
            }
            private Nullable<Decimal> dine_In_Net = 0;

            public Nullable<Decimal> Dine_In_Net
            {
                get { return dine_In_Net; }
                set { dine_In_Net = value; }
            }
            private Nullable<Decimal> dine_In_Sales = 0;

            public Nullable<Decimal> Dine_In_Sales
            {
                get { return dine_In_Sales; }
                set { dine_In_Sales = value; }
            }
            private Nullable<int> phone_Order_Count = 0;

            public Nullable<int> Phone_Order_Count
            {
                get { return phone_Order_Count; }
                set { phone_Order_Count = value; }
            }
            private Nullable<Decimal> phone_Net = 0;

            public Nullable<Decimal> Phone_Net
            {
                get { return phone_Net; }
                set { phone_Net = value; }
            }
            private Nullable<Decimal> phone_Sales = 0;

            public Nullable<Decimal> Phone_Sales
            {
                get { return phone_Sales; }
                set { phone_Sales = value; }
            }
            private Nullable<int> walk_In_Order_Count = 0;

            public Nullable<int> Walk_In_Order_Count
            {
                get { return walk_In_Order_Count; }
                set { walk_In_Order_Count = value; }
            }
            private Nullable<Decimal> walk_In_Net = 0;

            public Nullable<Decimal> Walk_In_Net
            {
                get { return walk_In_Net; }
                set { walk_In_Net = value; }
            }
            private Nullable<Decimal> Walk_In_Sales = 0;

            public Nullable<Decimal> Walk_In_Sales1
            {
                get { return Walk_In_Sales; }
                set { Walk_In_Sales = value; }
            }
            private Nullable<int> internet_Order_Count = 0;

            public Nullable<int> Internet_Order_Count
            {
                get { return internet_Order_Count; }
                set { internet_Order_Count = value; }
            }
            private Nullable<Decimal> internet_Net = 0;

            public Nullable<Decimal> Internet_Net
            {
                get { return internet_Net; }
                set { internet_Net = value; }
            }
            private Nullable<Decimal> internet_Sales = 0;

            public Nullable<Decimal> Internet_Sales
            {
                get { return internet_Sales; }
                set { internet_Sales = value; }
            }
            private Nullable<int> transfer_Order_Count = 0;

            public Nullable<int> Transfer_Order_Count
            {
                get { return transfer_Order_Count; }
                set { transfer_Order_Count = value; }
            }
            private Nullable<Decimal> transfer_Net = 0;

            public Nullable<Decimal> Transfer_Net
            {
                get { return transfer_Net; }
                set { transfer_Net = value; }
            }
            private Nullable<Decimal> transfer_Sales = 0;

            public Nullable<Decimal> Transfer_Sales
            {
                get { return transfer_Sales; }
                set { transfer_Sales = value; }
            }
            private Nullable<int> lunch_Order_Count = 0;

            public Nullable<int> Lunch_Order_Count
            {
                get { return lunch_Order_Count; }
                set { lunch_Order_Count = value; }
            }
            private Nullable<Decimal> lunch_Net = 0;

            public Nullable<Decimal> Lunch_Net
            {
                get { return lunch_Net; }
                set { lunch_Net = value; }
            }
            private Nullable<Decimal> lunch_Sales = 0;

            public Nullable<Decimal> Lunch_Sales
            {
                get { return lunch_Sales; }
                set { lunch_Sales = value; }
            }
            private Nullable<int> dinner_Order_Count = 0;

            public Nullable<int> Dinner_Order_Count
            {
                get { return dinner_Order_Count; }
                set { dinner_Order_Count = value; }
            }
            private Nullable<Decimal> dinner_Net = 0;

            public Nullable<Decimal> Dinner_Net
            {
                get { return dinner_Net; }
                set { dinner_Net = value; }
            }
            private Nullable<Decimal> dinner_Sales = 0;

            public Nullable<Decimal> Dinner_Sales
            {
                get { return dinner_Sales; }
                set { dinner_Sales = value; }
            }
            private Nullable<int> evening_Order_Count = 0;

            public Nullable<int> Evening_Order_Count
            {
                get { return evening_Order_Count; }
                set { evening_Order_Count = value; }
            }
            private Nullable<Decimal> evening_Net = 0;

            public Nullable<Decimal> Evening_Net
            {
                get { return evening_Net; }
                set { evening_Net = value; }
            }
            private Nullable<Decimal> evening_Sales = 0;

            public Nullable<Decimal> Evening_Sales
            {
                get { return evening_Sales; }
                set { evening_Sales = value; }
            }
            private Nullable<int> cash_Order_Count = 0;

            public Nullable<int> Cash_Order_Count
            {
                get { return cash_Order_Count; }
                set { cash_Order_Count = value; }
            }
            private Nullable<Decimal> cash_Net = 0;

            public Nullable<Decimal> Cash_Net
            {
                get { return cash_Net; }
                set { cash_Net = value; }
            }
            private Nullable<Decimal> cash_Sales = 0;

            public Nullable<Decimal> Cash_Sales
            {
                get { return cash_Sales; }
                set { cash_Sales = value; }
            }
            private Nullable<int> check_Order_Count = 0;

            public Nullable<int> Check_Order_Count
            {
                get { return check_Order_Count; }
                set { check_Order_Count = value; }
            }
            private Nullable<Decimal> check_Net = 0;

            public Nullable<Decimal> Check_Net
            {
                get { return check_Net; }
                set { check_Net = value; }
            }
            private Nullable<Decimal> check_Sales = 0;

            public Nullable<Decimal> Check_Sales
            {
                get { return check_Sales; }
                set { check_Sales = value; }
            }
            private Nullable<int> credit_Card_Order_Count = 0;

            public Nullable<int> Credit_Card_Order_Count
            {
                get { return credit_Card_Order_Count; }
                set { credit_Card_Order_Count = value; }
            }
            private Nullable<Decimal> credit_Card_Net = 0;

            public Nullable<Decimal> Credit_Card_Net
            {
                get { return credit_Card_Net; }
                set { credit_Card_Net = value; }
            }
            private Nullable<Decimal> credit_Card_Sales = 0;

            public Nullable<Decimal> Credit_Card_Sales
            {
                get { return credit_Card_Sales; }
                set { credit_Card_Sales = value; }
            }
            private Nullable<int> pizza_Order_Count = 0;

            public Nullable<int> Pizza_Order_Count
            {
                get { return pizza_Order_Count; }
                set { pizza_Order_Count = value; }
            }
            private Nullable<int> pizza_Quantity = 0;

            public Nullable<int> Pizza_Quantity
            {
                get { return pizza_Quantity; }
                set { pizza_Quantity = value; }
            }
            private Nullable<Decimal> pizza_Net = 0;

            public Nullable<Decimal> Pizza_Net
            {
                get { return pizza_Net; }
                set { pizza_Net = value; }
            }
            private Nullable<int> drink_Order_Count = 0;

            public Nullable<int> Drink_Order_Count
            {
                get { return drink_Order_Count; }
                set { drink_Order_Count = value; }
            }
            private Nullable<int> drink_Quantity = 0;

            public Nullable<int> Drink_Quantity
            {
                get { return drink_Quantity; }
                set { drink_Quantity = value; }
            }
            private Nullable<Decimal> drink_Net = 0;

            public Nullable<Decimal> Drink_Net
            {
                get { return drink_Net; }
                set { drink_Net = value; }
            }
            private Nullable<int> sides_Order_Count = 0;

            public Nullable<int> Sides_Order_Count
            {
                get { return sides_Order_Count; }
                set { sides_Order_Count = value; }
            }
            private Nullable<int> sides_Quantity = 0;

            public Nullable<int> Sides_Quantity
            {
                get { return sides_Quantity; }
                set { sides_Quantity = value; }
            }
            private Nullable<Decimal> sides_Net = 0;

            public Nullable<Decimal> Sides_Net
            {
                get { return sides_Net; }
                set { sides_Net = value; }
            }
            private Nullable<int> other_Item_Order_Count = 0;

            public Nullable<int> Other_Item_Order_Count
            {
                get { return other_Item_Order_Count; }
                set { other_Item_Order_Count = value; }
            }
            private Nullable<int> other_Item_Quantity = 0;

            public Nullable<int> Other_Item_Quantity
            {
                get { return other_Item_Quantity; }
                set { other_Item_Quantity = value; }
            }
            private Nullable<Decimal> other_Item_Net = 0;

            public Nullable<Decimal> Other_Item_Net
            {
                get { return other_Item_Net; }
                set { other_Item_Net = value; }
            }
            private Nullable<Decimal> food_Cost = 0;

            public Nullable<Decimal> Food_Cost
            {
                get { return food_Cost; }
                set { food_Cost = value; }
            }
            private Nullable<Decimal> food_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Food_Cost_Percent
            {
                get { return food_Cost_Percent; }
                set { food_Cost_Percent = value; }
            }
            private Nullable<Decimal> ideal_Food_Cost = 0;

            public Nullable<Decimal> Ideal_Food_Cost
            {
                get { return ideal_Food_Cost; }
                set { ideal_Food_Cost = value; }
            }
            private Nullable<Decimal> ideal_Food_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Ideal_Food_Cost_Percent
            {
                get { return ideal_Food_Cost_Percent; }
                set { ideal_Food_Cost_Percent = value; }
            }
            private Nullable<Decimal> var_Labor_Cost = 0;

            public Nullable<Decimal> Var_Labor_Cost
            {
                get { return var_Labor_Cost; }
                set { var_Labor_Cost = value; }
            }
            private Nullable<Decimal> var_Labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Var_Labor_Cost_Percent
            {
                get { return var_Labor_Cost_Percent; }
                set { var_Labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> var_Ideal_Labor_Cost = 0;

            public Nullable<Decimal> Var_Ideal_Labor_Cost
            {
                get { return var_Ideal_Labor_Cost; }
                set { var_Ideal_Labor_Cost = value; }
            }
            private Nullable<Decimal> var_Ideal_Labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Var_Ideal_Labor_Cost_Percent
            {
                get { return var_Ideal_Labor_Cost_Percent; }
                set { var_Ideal_Labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> fixed_Labor_Cost = 0;

            public Nullable<Decimal> Fixed_Labor_Cost
            {
                get { return fixed_Labor_Cost; }
                set { fixed_Labor_Cost = value; }
            }
            private Nullable<Decimal> fixed_Labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Fixed_Labor_Cost_Percent
            {
                get { return fixed_Labor_Cost_Percent; }
                set { fixed_Labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> fixed_Ideal_Labor_Cost = 0;

            public Nullable<Decimal> Fixed_Ideal_Labor_Cost
            {
                get { return fixed_Ideal_Labor_Cost; }
                set { fixed_Ideal_Labor_Cost = value; }
            }
            private Nullable<Decimal> fixed_Ideal_Labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Fixed_Ideal_Labor_Cost_Percent
            {
                get { return fixed_Ideal_Labor_Cost_Percent; }
                set { fixed_Ideal_Labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> labor_Cost = 0;

            public Nullable<Decimal> Labor_Cost
            {
                get { return labor_Cost; }
                set { labor_Cost = value; }
            }
            private Nullable<Decimal> labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Labor_Cost_Percent
            {
                get { return labor_Cost_Percent; }
                set { labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> ideal_Labor_Cost = 0;

            public Nullable<Decimal> Ideal_Labor_Cost
            {
                get { return ideal_Labor_Cost; }
                set { ideal_Labor_Cost = value; }
            }
            private Nullable<Decimal> ideal_Labor_Cost_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Ideal_Labor_Cost_Percent
            {
                get { return ideal_Labor_Cost_Percent; }
                set { ideal_Labor_Cost_Percent = value; }
            }
            private Nullable<Decimal> mileage_Cost = 0;

            public Nullable<Decimal> Mileage_Cost
            {
                get { return mileage_Cost; }
                set { mileage_Cost = value; }
            }
            private Nullable<int> pizza_IFC_Quantity = 0;

            public Nullable<int> Pizza_IFC_Quantity
            {
                get { return pizza_IFC_Quantity; }
                set { pizza_IFC_Quantity = value; }
            }
            private Nullable<Decimal> pizza_IFC = 0;

            public Nullable<Decimal> Pizza_IFC
            {
                get { return pizza_IFC; }
                set { pizza_IFC = value; }
            }
            private Nullable<int> drink_IFC_Quantity = 0;

            public Nullable<int> Drink_IFC_Quantity
            {
                get { return drink_IFC_Quantity; }
                set { drink_IFC_Quantity = value; }
            }
            private Nullable<Decimal> drink_IFC = 0;

            public Nullable<Decimal> Drink_IFC
            {
                get { return drink_IFC; }
                set { drink_IFC = value; }
            }
            private Nullable<int> sides_IFC_Quantity = 0;

            public Nullable<int> Sides_IFC_Quantity
            {
                get { return sides_IFC_Quantity; }
                set { sides_IFC_Quantity = value; }
            }
            private Nullable<Decimal> sides_IFC = 0;

            public Nullable<Decimal> Sides_IFC
            {
                get { return sides_IFC; }
                set { sides_IFC = value; }
            }
            private Nullable<int> other_Item_IFC_Quantity = 0;

            public Nullable<int> Other_Item_IFC_Quantity
            {
                get { return other_Item_IFC_Quantity; }
                set { other_Item_IFC_Quantity = value; }
            }
            private Nullable<Decimal> other_Item_IFC = 0;

            public Nullable<Decimal> Other_Item_IFC
            {
                get { return other_Item_IFC; }
                set { other_Item_IFC = value; }
            }
            private Nullable<int> run_Order_Count = 0;

            public Nullable<int> Run_Order_Count
            {
                get { return run_Order_Count; }
                set { run_Order_Count = value; }
            }
            private Nullable<int> run_Count = 0;

            public Nullable<int> Run_Count
            {
                get { return run_Count; }
                set { run_Count = value; }
            }
            private Nullable<Decimal> ave_Order_In_Run = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Order_In_Run
            {
                get { return ave_Order_In_Run; }
                set { ave_Order_In_Run = value; }
            }
            private Nullable<int> goal_Run_Order_Count = 0;

            public Nullable<int> Goal_Run_Order_Count
            {
                get { return goal_Run_Order_Count; }
                set { goal_Run_Order_Count = value; }
            }
            private Nullable<int> attain_Run_Order_Count = 0;

            public Nullable<int> Attain_Run_Order_Count
            {
                get { return attain_Run_Order_Count; }
                set { attain_Run_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Run_Order_Percent = 0; //[decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Run_Order_Percent
            {
                get { return attain_Run_Order_Percent; }
                set { attain_Run_Order_Percent = value; }
            }
            private Nullable<int> stop_1_Run_Count = 0;

            public Nullable<int> Stop_1_Run_Count
            {
                get { return stop_1_Run_Count; }
                set { stop_1_Run_Count = value; }
            }
            private Nullable<int> stop_2_Run_Count = 0;

            public Nullable<int> Stop_2_Run_Count
            {
                get { return stop_2_Run_Count; }
                set { stop_2_Run_Count = value; }
            }
            private Nullable<int> stop_3_Run_Count = 0;

            public Nullable<int> Stop_3_Run_Count
            {
                get { return stop_3_Run_Count; }
                set { stop_3_Run_Count = value; }
            }
            private Nullable<int> stop_4Plus_Run_Count = 0;

            public Nullable<int> Stop_4Plus_Run_Count
            {
                get { return stop_4Plus_Run_Count; }
                set { stop_4Plus_Run_Count = value; }
            }
            private Nullable<int> stop_1_Order_Count = 0;

            public Nullable<int> Stop_1_Order_Count
            {
                get { return stop_1_Order_Count; }
                set { stop_1_Order_Count = value; }
            }
            private Nullable<int> stop_2_Order_Count = 0;

            public Nullable<int> Stop_2_Order_Count
            {
                get { return stop_2_Order_Count; }
                set { stop_2_Order_Count = value; }
            }
            private Nullable<int> stop_3_Order_Count = 0;

            public Nullable<int> Stop_3_Order_Count
            {
                get { return stop_3_Order_Count; }
                set { stop_3_Order_Count = value; }
            }
            private Nullable<int> stop_4Plus_Order_Count = 0;

            public Nullable<int> Stop_4Plus_Order_Count
            {
                get { return stop_4Plus_Order_Count; }
                set { stop_4Plus_Order_Count = value; }
            }
            private Nullable<int> take_Time = 0;

            public Nullable<int> Take_Time
            {
                get { return take_Time; }
                set { take_Time = value; }
            }
            private Nullable<int> take_Time_Order_Count = 0;

            public Nullable<int> Take_Time_Order_Count
            {
                get { return take_Time_Order_Count; }
                set { take_Time_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Take_Seconds = 0; //[decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Take_Seconds
            {
                get { return ave_Take_Seconds; }
                set { ave_Take_Seconds = value; }
            }
            private Nullable<Decimal> ave_Take_Minutes = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Take_Minutes
            {
                get { return ave_Take_Minutes; }
                set { ave_Take_Minutes = value; }
            }
            private String ave_Take_Hms = String.Empty;

            public String Ave_Take_Hms
            {
                get { return ave_Take_Hms; }
                set { ave_Take_Hms = value; }
            }
            private Nullable<int> goal_Take_Minutes = 0;

            public Nullable<int> Goal_Take_Minutes
            {
                get { return goal_Take_Minutes; }
                set { goal_Take_Minutes = value; }
            }
            private Nullable<int> attain_Take_Time_Order_Count = 0;

            public Nullable<int> Attain_Take_Time_Order_Count
            {
                get { return attain_Take_Time_Order_Count; }
                set { attain_Take_Time_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Take_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Take_Percent
            {
                get { return attain_Take_Percent; }
                set { attain_Take_Percent = value; }
            }
            private Nullable<int> load_Time = 0;

            public Nullable<int> Load_Time
            {
                get { return load_Time; }
                set { load_Time = value; }
            }
            private Nullable<int> load_Time_Order_Count = 0;

            public Nullable<int> Load_Time_Order_Count
            {
                get { return load_Time_Order_Count; }
                set { load_Time_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Load_Seconds = 0; // [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Load_Seconds
            {
                get { return ave_Load_Seconds; }
                set { ave_Load_Seconds = value; }
            }
            private Nullable<Decimal> ave_Load_Minutes = 0; // [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Load_Minutes
            {
                get { return ave_Load_Minutes; }
                set { ave_Load_Minutes = value; }
            }
            private String ave_Load_Hms = String.Empty;

            public String Ave_Load_Hms
            {
                get { return ave_Load_Hms; }
                set { ave_Load_Hms = value; }
            }
            private Nullable<int> goal_Load_Minutes = 0;

            public Nullable<int> Goal_Load_Minutes
            {
                get { return goal_Load_Minutes; }
                set { goal_Load_Minutes = value; }
            }
            private Nullable<int> attain_Load_Time_Order_Count = 0;

            public Nullable<int> Attain_Load_Time_Order_Count
            {
                get { return attain_Load_Time_Order_Count; }
                set { attain_Load_Time_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Load_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Load_Percent
            {
                get { return attain_Load_Percent; }
                set { attain_Load_Percent = value; }
            }
            private Nullable<Decimal> oven_Minutes = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Oven_Minutes
            {
                get { return oven_Minutes; }
                set { oven_Minutes = value; }
            }
            private Nullable<Decimal> wait_Time = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Wait_Time
            {
                get { return wait_Time; }
                set { wait_Time = value; }
            }
            private Nullable<int> wait_Order_Count = 0;

            public Nullable<int> Wait_Order_Count
            {
                get { return wait_Order_Count; }
                set { wait_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Wait_Seconds = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Wait_Seconds
            {
                get { return ave_Wait_Seconds; }
                set { ave_Wait_Seconds = value; }
            }
            private Nullable<Decimal> ave_Wait_Minutes = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Wait_Minutes
            {
                get { return ave_Wait_Minutes; }
                set { ave_Wait_Minutes = value; }
            }
            private String ave_Wait_Hms = String.Empty;

            public String  Ave_Wait_Hms
            {
                get { return ave_Wait_Hms; }
                set { ave_Wait_Hms = value; }
            }
            private Nullable<int> goal_Wait_Minutes = 0;

            public Nullable<int> Goal_Wait_Minutes
            {
                get { return goal_Wait_Minutes; }
                set { goal_Wait_Minutes = value; }
            }
            private Nullable<int> attain_Wait_Order_Count = 0;

            public Nullable<int> Attain_Wait_Order_Count
            {
                get { return attain_Wait_Order_Count; }
                set { attain_Wait_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Wait_Percent = 0; //[decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Wait_Percent
            {
                get { return attain_Wait_Percent; }
                set { attain_Wait_Percent = value; }
            }
            private Nullable<int> dispatch_Time = 0;

            public Nullable<int> Dispatch_Time
            {
                get { return dispatch_Time; }
                set { dispatch_Time = value; }
            }
            private Nullable<int> dispatch_Order_Count = 0;

            public Nullable<int> Dispatch_Order_Count
            {
                get { return dispatch_Order_Count; }
                set { dispatch_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Dispatch_Seconds = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Dispatch_Seconds
            {
                get { return ave_Dispatch_Seconds; }
                set { ave_Dispatch_Seconds = value; }
            }
            private Nullable<Decimal> ave_Dispatch_Minutes = 0; // [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Dispatch_Minutes
            {
                get { return ave_Dispatch_Minutes; }
                set { ave_Dispatch_Minutes = value; }
            }
            private String ave_Dispatch_Hmss = String.Empty;

            public String Ave_Dispatch_Hms
            {
                get { return ave_Dispatch_Hmss; }
                set { ave_Dispatch_Hmss = value; }
            }
            private Nullable<int> goal_Dispatch_Minutes = 0;

            public Nullable<int> Goal_Dispatch_Minutes
            {
                get { return goal_Dispatch_Minutes; }
                set { goal_Dispatch_Minutes = value; }
            }
            private Nullable<int> attain_Dispatch_Order_Count = 0;

            public Nullable<int> Attain_Dispatch_Order_Count
            {
                get { return attain_Dispatch_Order_Count; }
                set { attain_Dispatch_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Dispatch_Percent = 0; // [decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Dispatch_Percent
            {
                get { return attain_Dispatch_Percent; }
                set { attain_Dispatch_Percent = value; }
            }
            private Nullable<int> delivery_Time = 0; //] [int] NULL,

            public Nullable<int> Delivery_Time
            {
                get { return delivery_Time; }
                set { delivery_Time = value; }
            }
            private Nullable<int> delivery_Time_Order_Count = 0; //] [int] NULL,

            public Nullable<int> Delivery_Time_Order_Count
            {
                get { return delivery_Time_Order_Count; }
                set { delivery_Time_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Delivery_Seconds = 0; // ] [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Delivery_Seconds
            {
                get { return ave_Delivery_Seconds; }
                set { ave_Delivery_Seconds = value; }
            }
            private Nullable<Decimal> ave_Delivery_Minutes = 0; // ] [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Delivery_Minutes
            {
                get { return ave_Delivery_Minutes; }
                set { ave_Delivery_Minutes = value; }
            }
            private String ave_Delivery_Hms = String.Empty;

           public String Ave_Delivery_Hms
            {
                get { return ave_Delivery_Hms; }
                set { ave_Delivery_Hms = value; }
            }
            private Nullable<int> goal_Delivery_Minutes = 0;

            public Nullable<int> Goal_Delivery_Minutes
            {
                get { return goal_Delivery_Minutes; }
                set { goal_Delivery_Minutes = value; }
            }
            private Nullable<int> attain_Delivery_Time_Order_Count = 0;

            public Nullable<int> Attain_Delivery_Time_Order_Count
            {
                get { return attain_Delivery_Time_Order_Count; }
                set { attain_Delivery_Time_Order_Count = value; }
            }
            private Nullable<Decimal> attain_Delivery_Percent = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Delivery_Percent
            {
                get { return attain_Delivery_Percent; }
                set { attain_Delivery_Percent = value; }
            }
            private Nullable<int> delivery_Void_Order_Count = 0;

            public Nullable<int> Delivery_Void_Order_Count
            {
                get { return delivery_Void_Order_Count; }
                set { delivery_Void_Order_Count = value; }
            }
            private Nullable<int> nonDelivery_Void_Order_Count = 0;

            public Nullable<int> NonDelivery_Void_Order_Count
            {
                get { return nonDelivery_Void_Order_Count; }
                set { nonDelivery_Void_Order_Count = value; }
            }
            private Nullable<int> delivery_Bad_Order_Count = 0;

            public Nullable<int> Delivery_Bad_Order_Count
            {
                get { return delivery_Bad_Order_Count; }
                set { delivery_Bad_Order_Count = value; }
            }
            private Nullable<int> nonDelivery_Bad_Order_Count = 0;

            public Nullable<int> NonDelivery_Bad_Order_Count
            {
                get { return nonDelivery_Bad_Order_Count; }
                set { nonDelivery_Bad_Order_Count = value; }
            }
            private Nullable<int> edit_Zero_Order_Count = 0;

            public Nullable<int> Edit_Zero_Order_Count
            {
                get { return edit_Zero_Order_Count; }
                set { edit_Zero_Order_Count = value; }
            }
            private Nullable<int> noEdit_Zero_Order_Count = 0;

            public Nullable<int> NoEdit_Zero_Order_Count
            {
                get { return noEdit_Zero_Order_Count; }
                set { noEdit_Zero_Order_Count = value; }
            }
            private Nullable<int> edit_Order_Count = 0;

            public Nullable<int> Edit_Order_Count
            {
                get { return edit_Order_Count; }
                set { edit_Order_Count = value; }
            }
            private Nullable<int> reprint_Order_Count = 0;

            public Nullable<int> Reprint_Order_Count
            {
                get { return reprint_Order_Count; }
                set { reprint_Order_Count = value; }
            }
            private Nullable<Decimal> bank_Deposit_Amount = 0;

            public Nullable<Decimal> Bank_Deposit_Amount
            {
                get { return bank_Deposit_Amount; }
                set { bank_Deposit_Amount = value; }
            }
            private Nullable<Decimal> cC_Settlement_Amount = 0;

            public Nullable<Decimal> CC_Settlement_Amount
            {
                get { return cC_Settlement_Amount; }
                set { cC_Settlement_Amount = value; }
            }
            private Nullable<Decimal> food_Bought_Amount = 0;

            public Nullable<Decimal> Food_Bought_Amount
            {
                get { return food_Bought_Amount; }
                set { food_Bought_Amount = value; }
            }
            private Nullable<Decimal> cash_Over_Short = 0;

            public Nullable<Decimal> Cash_Over_Short
            {
                get { return cash_Over_Short; }
                set { cash_Over_Short = value; }
            }
            private Nullable<Decimal> ending_Inventory_Amount = 0;

            public Nullable<Decimal> Ending_Inventory_Amount
            {
                get { return ending_Inventory_Amount; }
                set { ending_Inventory_Amount = value; }
            }
            private Nullable<Decimal> food_Sold_Amount = 0;

            public Nullable<Decimal> Food_Sold_Amount
            {
                get { return food_Sold_Amount; }
                set { food_Sold_Amount = value; }
            }
            private Nullable<Decimal> ending_Till_Amount = 0;

            public Nullable<Decimal> Ending_Till_Amount
            {
                get { return ending_Till_Amount; }
                set { ending_Till_Amount = value; }
            }
            private Nullable<int> run_Time = 0;

            public Nullable<int> Run_Time
            {
                get { return run_Time; }
                set { run_Time = value; }
            }
            private Nullable<int> run_Time_Order_Count = 0;

            public Nullable<int> Run_Time_Order_Count
            {
                get { return run_Time_Order_Count; }
                set { run_Time_Order_Count = value; }
            }
            private Nullable<Decimal> ave_Run_Seconds = 0; //[decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Run_Seconds
            {
                get { return ave_Run_Seconds; }
                set { ave_Run_Seconds = value; }
            }
            private Nullable<Decimal> ave_Run_Minutes = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Run_Minutes
            {
                get { return ave_Run_Minutes; }
                set { ave_Run_Minutes = value; }
            }
            private String ave_Run_Hms = String.Empty;

            public String Ave_Run_Hms
            {
                get { return ave_Run_Hms; }
                set { ave_Run_Hms = value; }
            }
            private Nullable<int> delivery_Time_Order_Count_EQ_Goal_10 = 0;

            public Nullable<int> Delivery_Time_Order_Count_EQ_Goal_10
            {
                get { return delivery_Time_Order_Count_EQ_Goal_10; }
                set { delivery_Time_Order_Count_EQ_Goal_10 = value; }
            }
            private Nullable<int> delivery_Time_Order_Count_GT_Goal_10 = 0;

            public Nullable<int> Delivery_Time_Order_Count_GT_Goal_10
            {
                get { return delivery_Time_Order_Count_GT_Goal_10; }
                set { delivery_Time_Order_Count_GT_Goal_10 = value; }
            }
            private Nullable<int> attain_Load_Time_Pizza_Count = 0;

            public Nullable<int> Attain_Load_Time_Pizza_Count
            {
                get { return attain_Load_Time_Pizza_Count; }
                set { attain_Load_Time_Pizza_Count = value; }
            }
            private Nullable<int> active_Customer_Count = 0;

            public Nullable<int> Active_Customer_Count
            {
                get { return active_Customer_Count; }
                set { active_Customer_Count = value; }
            }
            private Nullable<int> new_Customer_Count = 0;

            public Nullable<int> New_Customer_Count
            {
                get { return new_Customer_Count; }
                set { new_Customer_Count = value; }
            }
            private Nullable<int> lost_Customer_Count = 0;

            public Nullable<int> Lost_Customer_Count
            {
                get { return lost_Customer_Count; }
                set { lost_Customer_Count = value; }
            }
            private Nullable<Decimal> royalty_Sales_Last_Year = 0;

            public Nullable<Decimal> Royalty_Sales_Last_Year
            {
                get { return royalty_Sales_Last_Year; }
                set { royalty_Sales_Last_Year = value; }
            }
            private Nullable<Decimal> total_MROT_Amount = 0;

            public Nullable<Decimal> Total_MROT_Amount
            {
                get { return total_MROT_Amount; }
                set { total_MROT_Amount = value; }
            }
            private Nullable<Decimal> total_CPO_Amount = 0;

            public Nullable<Decimal> Total_CPO_Amount
            {
                get { return total_CPO_Amount; }
                set { total_CPO_Amount = value; }
            }
            private Nullable<Decimal> delivery_PCar_Sales = 0;

            public Nullable<Decimal> Delivery_PCar_Sales
            {
                get { return delivery_PCar_Sales; }
                set { delivery_PCar_Sales = value; }
            }
            private Nullable<int> attain_Dispatch_5_Order_Count = 0;

            public Nullable<int> Attain_Dispatch_5_Order_Count
            {
                get { return attain_Dispatch_5_Order_Count; }
                set { attain_Dispatch_5_Order_Count = value; }
            }
            private Nullable<int> corp_Goal_Take_Seconds = 0;

            public Nullable<int> Corp_Goal_Take_Seconds
            {
                get { return corp_Goal_Take_Seconds; }
                set { corp_Goal_Take_Seconds = value; }
            }
            private Nullable<int> corp_Attain_Take_Time_Order_Count = 0;

            public Nullable<int> Corp_Attain_Take_Time_Order_Count
            {
                get { return corp_Attain_Take_Time_Order_Count; }
                set { corp_Attain_Take_Time_Order_Count = value; }
            }
            private Nullable<int> corp_Goal_Load_Seconds = 0;

            public Nullable<int> Corp_Goal_Load_Seconds
            {
                get { return corp_Goal_Load_Seconds; }
                set { corp_Goal_Load_Seconds = value; }
            }
            private Nullable<int> corp_Attain_Load_Time_Order_Count = 0;

            public Nullable<int> Corp_Attain_Load_Time_Order_Count
            {
                get { return corp_Attain_Load_Time_Order_Count; }
                set { corp_Attain_Load_Time_Order_Count = value; }
            }
            private Nullable<int> corp_Goal_Dispatch_Seconds = 0;

            public Nullable<int> Corp_Goal_Dispatch_Seconds
            {
                get { return corp_Goal_Dispatch_Seconds; }
                set { corp_Goal_Dispatch_Seconds = value; }
            }
            private Nullable<int> corp_Attain_Dispatch_Time_Order_Count = 0;

            public Nullable<int> Corp_Attain_Dispatch_Time_Order_Count
            {
                get { return corp_Attain_Dispatch_Time_Order_Count; }
                set { corp_Attain_Dispatch_Time_Order_Count = value; }
            }
            private Nullable<int> corp_Goal_Delivery_Seconds = 0;

            public Nullable<int> Corp_Goal_Delivery_Seconds
            {
                get { return corp_Goal_Delivery_Seconds; }
                set { corp_Goal_Delivery_Seconds = value; }
            }
            private Nullable<int> corp_Attain_Delivery_Time_Order_Count = 0;

            public Nullable<int> Corp_Attain_Delivery_Time_Order_Count
            {
                get { return corp_Attain_Delivery_Time_Order_Count; }
                set { corp_Attain_Delivery_Time_Order_Count = value; }
            }
            private Nullable<Decimal> wTD_Labor = 0;

            public Nullable<Decimal> WTD_Labor
            {
                get { return wTD_Labor; }
                set { wTD_Labor = value; }
            }
            private Nullable<Decimal> wTD_Food = 0;

            public Nullable<Decimal> WTD_Food
            {
                get { return wTD_Food; }
                set { wTD_Food = value; }
            }
            private Nullable<Decimal> wTD_Ideal_Labor = 0;

            public Nullable<Decimal> WTD_Ideal_Labor
            {
                get { return wTD_Ideal_Labor; }
                set { wTD_Ideal_Labor = value; }
            }
            private Nullable<Decimal> check_Charge_Amt = 0;

            public Nullable<Decimal> Check_Charge_Amt
            {
                get { return check_Charge_Amt; }
                set { check_Charge_Amt = value; }
            }
            private Nullable<int> trade_Rec_Ord_Ct = 0;

            public Nullable<int> Trade_Rec_Ord_Ct
            {
                get { return trade_Rec_Ord_Ct; }
                set { trade_Rec_Ord_Ct = value; }
            }
            private Nullable<Decimal> trade_Rec_Net = 0;

            public Nullable<Decimal> Trade_Rec_Net
            {
                get { return trade_Rec_Net; }
                set { trade_Rec_Net = value; }
            }
            private Nullable<Decimal> trade_Rec_Sales = 0;

            public Nullable<Decimal> Trade_Rec_Sales
            {
                get { return trade_Rec_Sales; }
                set { trade_Rec_Sales = value; }
            }
            private Nullable<int> giftCard_Ord_Ct = 0;

            public Nullable<int> GiftCard_Ord_Ct
            {
                get { return giftCard_Ord_Ct; }
                set { giftCard_Ord_Ct = value; }
            }
            private Nullable<Decimal> giftCard_Net = 0;

            public Nullable<Decimal> GiftCard_Net
            {
                get { return giftCard_Net; }
                set { giftCard_Net = value; }
            }
            private Nullable<Decimal> giftCard_Sales = 0;

            public Nullable<Decimal> GiftCard_Sales
            {
                get { return giftCard_Sales; }
                set { giftCard_Sales = value; }
            }
            private Nullable<Decimal> gCAddValue_Sales = 0;

            public Nullable<Decimal> GCAddValue_Sales
            {
                get { return gCAddValue_Sales; }
                set { gCAddValue_Sales = value; }
            }
            private Nullable<int> gCAddValue_Cnt = 0;

            public Nullable<int> GCAddValue_Cnt
            {
                get { return gCAddValue_Cnt; }
                set { gCAddValue_Cnt = value; }
            }
            private Nullable<int> cancelled_Carrout_Order_Count = 0;

            public Nullable<int> Cancelled_Carrout_Order_Count
            {
                get { return cancelled_Carrout_Order_Count; }
                set { cancelled_Carrout_Order_Count = value; }
            }
            private Nullable<Decimal> cancelled_Carrout_Net = 0;

            public Nullable<Decimal> Cancelled_Carrout_Net
            {
                get { return cancelled_Carrout_Net; }
                set { cancelled_Carrout_Net = value; }
            }
            private Nullable<int> cancelled_Delivery_Order_Count = 0;

            public Nullable<int> Cancelled_Delivery_Order_Count
            {
                get { return cancelled_Delivery_Order_Count; }
                set { cancelled_Delivery_Order_Count = value; }
            }
            private Nullable<Decimal> cancelled_Delivery_Net = 0;

            public Nullable<Decimal> Cancelled_Delivery_Net
            {
                get { return cancelled_Delivery_Net; }
                set { cancelled_Delivery_Net = value; }
            }
            private Nullable<int> carry_Out_10pm_Order_Count = 0;

            public Nullable<int> Carry_Out_10pm_Order_Count
            {
                get { return carry_Out_10pm_Order_Count; }
                set { carry_Out_10pm_Order_Count = value; }
            }
            private Nullable<Decimal> carry_Out_After_10pm_Net = 0;

            public Nullable<Decimal> Carry_Out_After_10pm_Net
            {
                get { return carry_Out_After_10pm_Net; }
                set { carry_Out_After_10pm_Net = value; }
            }
            private Nullable<int> delivery_Edit_1_Order_Count = 0;

            public Nullable<int> Delivery_Edit_1_Order_Count
            {
                get { return delivery_Edit_1_Order_Count; }
                set { delivery_Edit_1_Order_Count = value; }
            }
            private Nullable<int> delivery_Edit_2_Order_Count = 0;

            public Nullable<int> Delivery_Edit_2_Order_Count
            {
                get { return delivery_Edit_2_Order_Count; }
                set { delivery_Edit_2_Order_Count = value; }
            }
            private Nullable<int> delivery_Edit_3_Plus_Order_Count = 0;

            public Nullable<int> Delivery_Edit_3_Plus_Order_Count
            {
                get { return delivery_Edit_3_Plus_Order_Count; }
                set { delivery_Edit_3_Plus_Order_Count = value; }
            }
            private Nullable<int> carryout_Edit_1_Order_Count = 0;

            public Nullable<int> Carryout_Edit_1_Order_Count
            {
                get { return carryout_Edit_1_Order_Count; }
                set { carryout_Edit_1_Order_Count = value; }
            }
            private Nullable<int> carryout_Edit_2_Order_Count = 0;

            public Nullable<int> Carryout_Edit_2_Order_Count
            {
                get { return carryout_Edit_2_Order_Count; }
                set { carryout_Edit_2_Order_Count = value; }
            }
            private Nullable<int> carryout_Edit_3_Plus_Order_Count = 0;

            public Nullable<int> Carryout_Edit_3_Plus_Order_Count
            {
                get { return carryout_Edit_3_Plus_Order_Count; }
                set { carryout_Edit_3_Plus_Order_Count = value; }
            }
            private Nullable<int> inv_Item_Ct_With_Price_Change = 0;

            public Nullable<int> Inv_Item_Ct_With_Price_Change
            {
                get { return inv_Item_Ct_With_Price_Change; }
                set { inv_Item_Ct_With_Price_Change = value; }
            }
            private Nullable<int> ghost_Employee_Count = 0;

            public Nullable<int> Ghost_Employee_Count
            {
                get { return ghost_Employee_Count; }
                set { ghost_Employee_Count = value; }
            }
            private Nullable<Decimal> total_Ghost_Hours = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Total_Ghost_Hours
            {
                get { return total_Ghost_Hours; }
                set { total_Ghost_Hours = value; }
            }
            private Nullable<int> off_Clock_Employee_Count = 0;

            public Nullable<int> Off_Clock_Employee_Count
            {
                get { return off_Clock_Employee_Count; }
                set { off_Clock_Employee_Count = value; }
            }
            private Nullable<int> total_Orders_Off_Clock = 0;

            public Nullable<int> Total_Orders_Off_Clock
            {
                get { return total_Orders_Off_Clock; }
                set { total_Orders_Off_Clock = value; }
            }
            private Nullable<int> nbr_Deposits_Over_900 = 0;

            public Nullable<int> Nbr_Deposits_Over_900
            {
                get { return nbr_Deposits_Over_900; }
                set { nbr_Deposits_Over_900 = value; }
            }
            private Nullable<int> nbr_Deposits_Multiple_Of_100 = 0;

            public Nullable<int> Nbr_Deposits_Multiple_Of_100
            {
                get { return nbr_Deposits_Multiple_Of_100; }
                set { nbr_Deposits_Multiple_Of_100 = value; }
            }
            private Nullable<Decimal> additional_Mileage_Cost = 0;

            public Nullable<Decimal> Additional_Mileage_Cost
            {
                get { return additional_Mileage_Cost; }
                set { additional_Mileage_Cost = value; }
            }
            private Nullable<Decimal> prod_Srvc_Guarantee_Amt = 0;

            public Nullable<Decimal> Prod_Srvc_Guarantee_Amt
            {
                get { return prod_Srvc_Guarantee_Amt; }
                set { prod_Srvc_Guarantee_Amt = value; }
            }
            private Nullable<int> prod_Srvc_Guarantee_Ct = 0;

            public Nullable<int> Prod_Srvc_Guarantee_Ct
            {
                get { return prod_Srvc_Guarantee_Ct; }
                set { prod_Srvc_Guarantee_Ct = value; }
            }
            private Nullable<int> reprint_1_Order_Count = 0;

            public Nullable<int> Reprint_1_Order_Count
            {
                get { return reprint_1_Order_Count; }
                set { reprint_1_Order_Count = value; }
            }
            private Nullable<int> reprint_2_Order_Count = 0;

            public Nullable<int> Reprint_2_Order_Count
            {
                get { return reprint_2_Order_Count; }
                set { reprint_2_Order_Count = value; }
            }
            private Nullable<int> reprint_3_Plus_Order_Count = 0;

            public Nullable<int> Reprint_3_Plus_Order_Count
            {
                get { return reprint_3_Plus_Order_Count; }
                set { reprint_3_Plus_Order_Count = value; }
            }
            private Nullable<Decimal> corp_GL_Prod_Srvc_Guar = 0;

            public Nullable<Decimal> Corp_GL_Prod_Srvc_Guar
            {
                get { return corp_GL_Prod_Srvc_Guar; }
                set { corp_GL_Prod_Srvc_Guar = value; }
            }
            private Nullable<Decimal> giftCard_CPO = 0;

            public Nullable<Decimal> GiftCard_CPO
            {
                get { return giftCard_CPO; }
                set { giftCard_CPO = value; }
            }
            private Nullable<Decimal> trade_Rec_CPO = 0;

            public Nullable<Decimal> Trade_Rec_CPO
            {
                get { return trade_Rec_CPO; }
                set { trade_Rec_CPO = value; }
            }
            private Nullable<int> att_le15_disp_ct = 0;

            public Nullable<int> Att_le15_disp_ct
            {
                get { return att_le15_disp_ct; }
                set { att_le15_disp_ct = value; }
            }
            private Nullable<int> delivery_PCar_Count = 0;

            public Nullable<int> Delivery_PCar_Count
            {
                get { return delivery_PCar_Count; }
                set { delivery_PCar_Count = value; }
            }
            private Nullable<Decimal> delivery_CoCar_Sales = 0;

            public Nullable<Decimal> Delivery_CoCar_Sales
            {
                get { return delivery_CoCar_Sales; }
                set { delivery_CoCar_Sales = value; }
            }
            private Nullable<int> delivery_CoCar_Count = 0;

            public Nullable<int> Delivery_CoCar_Count
            {
                get { return delivery_CoCar_Count; }
                set { delivery_CoCar_Count = value; }
            }
            private Nullable<int> oLO_Order_Count = 0;

            public Nullable<int> OLO_Order_Count
            {
                get { return oLO_Order_Count; }
                set { oLO_Order_Count = value; }
            }
            private Nullable<Decimal> oLO_Net = 0;

            public Nullable<Decimal> OLO_Net
            {
                get { return oLO_Net; }
                set { oLO_Net = value; }
            }
            private Nullable<Decimal> oLO_Sales = 0;

            public Nullable<Decimal> OLO_Sales
            {
                get { return oLO_Sales; }
                set { oLO_Sales = value; }
            }
            private Nullable<int> edit_Downs = 0;

            public Nullable<int> Edit_Downs
            {
                get { return edit_Downs; }
                set { edit_Downs = value; }
            }
            private Nullable<int> mPC_Total = 0;

            public Nullable<int> MPC_Total
            {
                get { return mPC_Total; }
                set { mPC_Total = value; }
            }
            private Nullable<Decimal> manualCPO = 0;

            public Nullable<Decimal> ManualCPO
            {
                get { return manualCPO; }
                set { manualCPO = value; }
            }
            private Nullable<int> service_Exceptions = 0;

            public Nullable<int> Service_Exceptions
            {
                get { return service_Exceptions; }
                set { service_Exceptions = value; }
            }
            private Nullable<Decimal> insider_ActualHoursMorning = 0; // [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ActualHoursMorning
            {
                get { return insider_ActualHoursMorning; }
                set { insider_ActualHoursMorning = value; }
            }
            private Nullable<Decimal> insider_ActualHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ActualHoursLunch
            {
                get { return insider_ActualHoursLunch; }
                set { insider_ActualHoursLunch = value; }
            }
            private Nullable<Decimal> insider_ActualHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ActualHoursDinner
            {
                get { return insider_ActualHoursDinner; }
                set { insider_ActualHoursDinner = value; }
            }
            private Nullable<Decimal> insider_ActualHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ActualHoursClosed
            {
                get { return insider_ActualHoursClosed; }
                set { insider_ActualHoursClosed = value; }
            }
            private Nullable<Decimal> insider_ForecastHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ForecastHoursMorning
            {
                get { return insider_ForecastHoursMorning; }
                set { insider_ForecastHoursMorning = value; }
            }
            private Nullable<Decimal> insider_ForecastHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ForecastHoursLunch
            {
                get { return insider_ForecastHoursLunch; }
                set { insider_ForecastHoursLunch = value; }
            }
            private Nullable<Decimal> insider_ForecastHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ForecastHoursDinner
            {
                get { return insider_ForecastHoursDinner; }
                set { insider_ForecastHoursDinner = value; }
            }
            private Nullable<Decimal> insider_ForecastHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ForecastHoursClosed
            {
                get { return insider_ForecastHoursClosed; }
                set { insider_ForecastHoursClosed = value; }
            }
            private Nullable<Decimal> insider_IdealHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_IdealHoursMorning
            {
                get { return insider_IdealHoursMorning; }
                set { insider_IdealHoursMorning = value; }
            }
            private Nullable<Decimal> insider_IdealHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_IdealHoursLunch
            {
                get { return insider_IdealHoursLunch; }
                set { insider_IdealHoursLunch = value; }
            }
            private Nullable<Decimal> insider_IdealHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_IdealHoursDinner
            {
                get { return insider_IdealHoursDinner; }
                set { insider_IdealHoursDinner = value; }
            }
            private Nullable<Decimal> insider_IdealHoursClosed = 0;//[decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_IdealHoursClosed
            {
                get { return insider_IdealHoursClosed; }
                set { insider_IdealHoursClosed = value; }
            }
            private Nullable<Decimal> insider_ScheduledHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ScheduledHoursMorning
            {
                get { return insider_ScheduledHoursMorning; }
                set { insider_ScheduledHoursMorning = value; }
            }
            private Nullable<Decimal> insider_ScheduledHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ScheduledHoursLunch
            {
                get { return insider_ScheduledHoursLunch; }
                set { insider_ScheduledHoursLunch = value; }
            }
            private Nullable<Decimal> insider_ScheduledHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ScheduledHoursDinner
            {
                get { return insider_ScheduledHoursDinner; }
                set { insider_ScheduledHoursDinner = value; }
            }
            private Nullable<Decimal> insider_ScheduledHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Insider_ScheduledHoursClosed
            {
                get { return insider_ScheduledHoursClosed; }
                set { insider_ScheduledHoursClosed = value; }
            }
            private Nullable<Decimal> dExpert_ActualHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ActualHoursMorning
            {
                get { return dExpert_ActualHoursMorning; }
                set { dExpert_ActualHoursMorning = value; }
            }
            private Nullable<Decimal> dExpert_ActualHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ActualHoursLunch
            {
                get { return dExpert_ActualHoursLunch; }
                set { dExpert_ActualHoursLunch = value; }
            }
            private Nullable<Decimal> dExpert_ActualHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ActualHoursDinner
            {
                get { return dExpert_ActualHoursDinner; }
                set { dExpert_ActualHoursDinner = value; }
            }
            private Nullable<Decimal> dExpert_ActualHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ActualHoursClosed
            {
                get { return dExpert_ActualHoursClosed; }
                set { dExpert_ActualHoursClosed = value; }
            }
            private Nullable<Decimal> dExpert_ForecastHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ForecastHoursMorning
            {
                get { return dExpert_ForecastHoursMorning; }
                set { dExpert_ForecastHoursMorning = value; }
            }
            private Nullable<Decimal> dExpert_ForecastHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ForecastHoursLunch
            {
                get { return dExpert_ForecastHoursLunch; }
                set { dExpert_ForecastHoursLunch = value; }
            }
            private Nullable<Decimal> dExpert_ForecastHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ForecastHoursDinner
            {
                get { return dExpert_ForecastHoursDinner; }
                set { dExpert_ForecastHoursDinner = value; }
            }
            private Nullable<Decimal> dExpert_ForecastHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ForecastHoursClosed
            {
                get { return dExpert_ForecastHoursClosed; }
                set { dExpert_ForecastHoursClosed = value; }
            }
            private Nullable<Decimal> dExpert_IdealHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_IdealHoursMorning
            {
                get { return dExpert_IdealHoursMorning; }
                set { dExpert_IdealHoursMorning = value; }
            }
            private Nullable<Decimal> dExpert_IdealHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_IdealHoursLunch
            {
                get { return dExpert_IdealHoursLunch; }
                set { dExpert_IdealHoursLunch = value; }
            }
            private Nullable<Decimal> dExpert_IdealHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_IdealHoursDinner
            {
                get { return dExpert_IdealHoursDinner; }
                set { dExpert_IdealHoursDinner = value; }
            }
            private Nullable<Decimal> dExpert_IdealHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_IdealHoursClosed
            {
                get { return dExpert_IdealHoursClosed; }
                set { dExpert_IdealHoursClosed = value; }
            }
            private Nullable<Decimal> dExpert_ScheduledHoursMorning = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ScheduledHoursMorning
            {
                get { return dExpert_ScheduledHoursMorning; }
                set { dExpert_ScheduledHoursMorning = value; }
            }
            private Nullable<Decimal> dExpert_ScheduledHoursLunch = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ScheduledHoursLunch
            {
                get { return dExpert_ScheduledHoursLunch; }
                set { dExpert_ScheduledHoursLunch = value; }
            }
            private Nullable<Decimal> dExpert_ScheduledHoursDinner = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ScheduledHoursDinner
            {
                get { return dExpert_ScheduledHoursDinner; }
                set { dExpert_ScheduledHoursDinner = value; }
            }
            private Nullable<Decimal> dExpert_ScheduledHoursClosed = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> DExpert_ScheduledHoursClosed
            {
                get { return dExpert_ScheduledHoursClosed; }
                set { dExpert_ScheduledHoursClosed = value; }
            }
            private Nullable<Decimal> hourlyTM_OvertimeHours = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> HourlyTM_OvertimeHours
            {
                get { return hourlyTM_OvertimeHours; }
                set { hourlyTM_OvertimeHours = value; }
            }
            private Nullable<Decimal> management_Hours = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Management_Hours
            {
                get { return management_Hours; }
                set { management_Hours = value; }
            }
            private Nullable<Decimal> actualUsage_Cheese = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Cheese
            {
                get { return actualUsage_Cheese; }
                set { actualUsage_Cheese = value; }
            }
            private Nullable<Decimal> idealUsage_Cheese = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Cheese
            {
                get { return idealUsage_Cheese; }
                set { idealUsage_Cheese = value; }
            }
            private Nullable<Decimal> actualUsage_Pepperoni = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Pepperoni
            {
                get { return actualUsage_Pepperoni; }
                set { actualUsage_Pepperoni = value; }
            }
            private Nullable<Decimal> idealUsage_Pepperoni = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Pepperoni
            {
                get { return idealUsage_Pepperoni; }
                set { idealUsage_Pepperoni = value; }
            }
            private Nullable<Decimal> actualUsage_Ham = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Ham
            {
                get { return actualUsage_Ham; }
                set { actualUsage_Ham = value; }
            }
            private Nullable<Decimal> idealUsage_Ham = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Ham
            {
                get { return idealUsage_Ham; }
                set { idealUsage_Ham = value; }
            }
            private Nullable<Decimal> actualUsage_Sausage = 0;//[decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Sausage
            {
                get { return actualUsage_Sausage; }
                set { actualUsage_Sausage = value; }
            }
            private Nullable<Decimal> idealUsage_Sausage = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Sausage
            {
                get { return idealUsage_Sausage; }
                set { idealUsage_Sausage = value; }
            }
            private Nullable<Decimal> actualUsage_Wings = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Wings
            {
                get { return actualUsage_Wings; }
                set { actualUsage_Wings = value; }
            }
            private Nullable<Decimal> idealUsage_Wings = 0;//[decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Wings
            {
                get { return idealUsage_Wings; }
                set { idealUsage_Wings = value; }
            }
            private Nullable<Decimal> actualUsage_Kickers = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Kickers
            {
                get { return actualUsage_Kickers; }
                set { actualUsage_Kickers = value; }
            }
            private Nullable<Decimal> idealUsage_Kickers = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Kickers
            {
                get { return idealUsage_Kickers; }
                set { idealUsage_Kickers = value; }
            }
            private Nullable<Decimal> actualUsage_Dough = 0; //[decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_Dough
            {
                get { return actualUsage_Dough; }
                set { actualUsage_Dough = value; }
            }
            private Nullable<Decimal> idealUsage_Dough = 0; //[decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_Dough
            {
                get { return idealUsage_Dough; }
                set { idealUsage_Dough = value; }
            }
            private Nullable<Decimal> actualUsage_20ozDrinks = 0;//  [decimal](10, 2) NULL,

            public Nullable<Decimal> ActualUsage_20ozDrinks
            {
                get { return actualUsage_20ozDrinks; }
                set { actualUsage_20ozDrinks = value; }
            }
            private Nullable<Decimal> idealUsage_20ozDrinks = 0;//[decimal](10, 2) NULL,

            public Nullable<Decimal> IdealUsage_20ozDrinks
            {
                get { return idealUsage_20ozDrinks; }
                set { idealUsage_20ozDrinks = value; }
            }
            private Nullable<Decimal> nonTaxableDeliveryFees = 0;

            public Nullable<Decimal> NonTaxableDeliveryFees
            {
                get { return nonTaxableDeliveryFees; }
                set { nonTaxableDeliveryFees = value; }
            }
            private Nullable<Decimal> charitableDonations = 0;

            public Nullable<Decimal> CharitableDonations
            {
                get { return charitableDonations; }
                set { charitableDonations = value; }
            }
            private Nullable<int> goal_Labor = 0;

            public Nullable<int> Goal_Labor
            {
                get { return goal_Labor; }
                set { goal_Labor = value; }
            }
            private Nullable<Decimal> edit_Downs_Amt = 0;

            public Nullable<Decimal> Edit_Downs_Amt
            {
                get { return edit_Downs_Amt; }
                set { edit_Downs_Amt = value; }
            }
            private Nullable<int> delivery_Time_Mp = 0;

            public Nullable<int> Delivery_Time_Mp
            {
                get { return delivery_Time_Mp; }
                set { delivery_Time_Mp = value; }
            }
            private Nullable<Decimal> ave_Delivery_Seconds_Mp = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Delivery_Seconds_Mp
            {
                get { return ave_Delivery_Seconds_Mp; }
                set { ave_Delivery_Seconds_Mp = value; }
            }
            private Nullable<Decimal> ave_Delivery_Minutes_Mp = 0;// [decimal](10, 2) NULL,

            public Nullable<Decimal> Ave_Delivery_Minutes_Mp
            {
                get { return ave_Delivery_Minutes_Mp; }
                set { ave_Delivery_Minutes_Mp = value; }
            }
            private String ave_Delivery_Hms_Mp = String.Empty;// [char](8) NULL,

            public String Ave_Delivery_Hms_Mp
            {
                get { return ave_Delivery_Hms_Mp; }
                set { ave_Delivery_Hms_Mp = value; }
            }
            private Nullable<int> attain_Delivery_Time_Order_Count_Mp = 0;

            public Nullable<int> Attain_Delivery_Time_Order_Count_Mp
            {
                get { return attain_Delivery_Time_Order_Count_Mp; }
                set { attain_Delivery_Time_Order_Count_Mp = value; }
            }
            private Nullable<Decimal> attain_Delivery_Percent_Mp = 0;// [decimal](10, 4) NULL,

            public Nullable<Decimal> Attain_Delivery_Percent_Mp
            {
                get { return attain_Delivery_Percent_Mp; }
                set { attain_Delivery_Percent_Mp = value; }
            }
            private Nullable<int> corp_Attain_Delivery_Time_Order_Count_Mp = 0;

            public Nullable<int> Corp_Attain_Delivery_Time_Order_Count_Mp
            {
                get { return corp_Attain_Delivery_Time_Order_Count_Mp; }
                set { corp_Attain_Delivery_Time_Order_Count_Mp = value; }
            }
            private Nullable<int> run_Time_Mp = 0;

            public Nullable<int> Run_Time_Mp
            {
                get { return run_Time_Mp; }
                set { run_Time_Mp = value; }
            }
            private Nullable<int> service_Exceptions_Mp = 0;

            public Nullable<int> Service_Exceptions_Mp
            {
                get { return service_Exceptions_Mp; }
                set { service_Exceptions_Mp = value; }
            }
    }
}