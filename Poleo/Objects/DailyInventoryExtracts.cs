using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DailyInventoryExtracts
    {
        private String recordType = String.Empty; //length 8

        public String RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }
        private String databaseVersion = String.Empty; //length 8

        public String DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }
        private String location_Code = String.Empty; //length 8

        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }
        private DateTime system_Date = DateTime.Now;

        public DateTime System_Date
        {
            get { return system_Date; }
            set { system_Date = value; }
        }
        private String inventory_Code = String.Empty; //length 8

        public String Inventory_Code
        {
            get { return inventory_Code; }
            set { inventory_Code = value; }
        }
        private String description = String.Empty; //length 50

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        private String inventory_Type_Code = String.Empty; //length 8

        public String Inventory_Type_Code
        {
            get { return inventory_Type_Code; }
            set { inventory_Type_Code = value; }
        }
        private String count_Unit = String.Empty; //length 8

        public String Count_Unit
        {
            get { return count_Unit; }
            set { count_Unit = value; }
        }
        private Nullable<decimal> count_Unit_Cost = 0;// [money] NULL,

        public Nullable<decimal> Count_Unit_Cost
        {
            get { return count_Unit_Cost; }
            set { count_Unit_Cost = value; }
        }
        private Nullable<decimal> beginning_Qty = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Beginning_Qty
        {
            get { return beginning_Qty; }
            set { beginning_Qty = value; }
        }
        private Nullable<decimal> delivered_Qty = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Delivered_Qty
        {
            get { return delivered_Qty; }
            set { delivered_Qty = value; }
        }
        private Nullable<decimal> starting_Qty = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Starting_Qty
        {
            get { return starting_Qty; }
            set { starting_Qty = value; }
        }
        private Nullable<decimal> ending_Qty = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Ending_Qty
        {
            get { return ending_Qty; }
            set { ending_Qty = value; }
        }
        private Nullable<decimal> actual_Usage = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Actual_Usage
        {
            get { return actual_Usage; }
            set { actual_Usage = value; }
        }
        private Nullable<decimal> ideal_Usage = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Ideal_Usage
        {
            get { return ideal_Usage; }
            set { ideal_Usage = value; }
        }
        private Nullable<decimal> actual_vs_Ideal_Usage = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Actual_vs_Ideal_Usage
        {
            get { return actual_vs_Ideal_Usage; }
            set { actual_vs_Ideal_Usage = value; }
        }
        private Nullable<decimal> cost_Actual_Used = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Cost_Actual_Used
        {
            get { return cost_Actual_Used; }
            set { cost_Actual_Used = value; }
        }
        private Nullable<decimal> cost_Ideal_Used = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Cost_Ideal_Used
        {
            get { return cost_Ideal_Used; }
            set { cost_Ideal_Used = value; }
        }
        private Nullable<decimal> cost_Actual_vs_Ideal = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Cost_Actual_vs_Ideal
        {
            get { return cost_Actual_vs_Ideal; }
            set { cost_Actual_vs_Ideal = value; }
        }
        private String order_Unit = String.Empty; //length 8

        public String Order_Unit
        {
            get { return order_Unit; }
            set { order_Unit = value; }
        }
        private Nullable<decimal> order_Unit_Cost = 0;// [money] NULL,

        public Nullable<decimal> Order_Unit_Cost
        {
            get { return order_Unit_Cost; }
            set { order_Unit_Cost = value; }
        }
        private Nullable<decimal> count_Per_Order = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Count_Per_Order
        {
            get { return count_Per_Order; }
            set { count_Per_Order = value; }
        }
        private String portion_Unit = String.Empty; //length 8

        public String Portion_Unit
        {
            get { return portion_Unit; }
            set { portion_Unit = value; }
        }
        private Nullable<decimal> portion_Per_Count = 0;// [decimal](10, 2) NULL,

        public Nullable<decimal> Portion_Per_Count
        {
            get { return portion_Per_Count; }
            set { portion_Per_Count = value; }
        }
        private String vendor_Item_Code = String.Empty; //length 15

        public String Vendor_Item_Code
        {
            get { return vendor_Item_Code; }
            set { vendor_Item_Code = value; }
        }
        private String vendor_Code = String.Empty; //length 8

        public String Vendor_Code
        {
            get { return vendor_Code; }
            set { vendor_Code = value; }
        }
        private Nullable<int> count_Type_Code = 0;

        public Nullable<int> Count_Type_Code
        {
            get { return count_Type_Code; }
            set { count_Type_Code = value; }
        }
        private String food = String.Empty; //length 3 [varchar](3) NULL,

        public String Food
        {
            get { return food; }
            set { food = value; }
        }
    }
}