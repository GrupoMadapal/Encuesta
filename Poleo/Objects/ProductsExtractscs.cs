using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ProductsExtracts
    {
        private String recordType = String.Empty;//length 8
        public String RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }
        
        private String databaseVersion = String.Empty;//length 8
        public String DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }

        private String location_Code = String.Empty;//length 8
        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        private DateTime beginDate = DateTime.Now;
        public DateTime BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private String product_Code = String.Empty;//length 10
        public String Product_Code
        {
            get { return product_Code; }
            set { product_Code = value; }
        }

        private String product_Description = String.Empty;//length 50
        public String Product_Description
        {
            get { return product_Description; }
            set { product_Description = value; }
        }

        private String product_Category_Code = String.Empty;//length 8
        public String Product_Category_Code
        {
            get { return product_Category_Code; }
            set { product_Category_Code = value; }
        }

        private String product_Menu_Code = String.Empty;//length 8
        public String Product_Menu_Code
        {
            get { return product_Menu_Code; }
            set { product_Menu_Code = value; }
        }

        private String product_Size_Code = String.Empty;//length 8
        public String Product_Size_Code
        {
            get { return product_Size_Code; }
            set { product_Size_Code = value; }
        }

        private String product_Crust_Code = String.Empty;//length 8
        public String Product_Crust_Code
        {
            get { return product_Crust_Code; }
            set { product_Crust_Code = value; }
        }

        private Nullable<int> quantity = 0;
        public Nullable<int> Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private Nullable<decimal> sales = 0;
        public Nullable<decimal> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        private Nullable<int> iFC_Quantity = 0;
        public Nullable<int> IFC_Quantity
        {
            get { return iFC_Quantity; }
            set { iFC_Quantity = value; }
        }

        private Nullable<decimal> iFC = 0;
        public Nullable<decimal> IFC
        {
            get { return iFC; }
            set { iFC = value; }
        }

        private Nullable<int> order_Count = 0;
        public Nullable<int> Order_Count
        {
            get { return order_Count; }
            set { order_Count = value; }
        }
    }
}