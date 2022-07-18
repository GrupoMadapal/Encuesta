using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    #region ReporteCompras
    public class InventoryPurchaseDetailsExtracts
    {
        private String recordType = string.Empty;
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
        #endregion
        private Nullable<int> purchaseID = 0;

        public Nullable<int> PurchaseID
        {
            get { return purchaseID; }
            set { purchaseID = value; }
        }
        private String vendorName = String.Empty; //length 50

        public String VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
        }
        private String vendorCode = String.Empty; //length 8 

        public String VendorCode
        {
            get { return vendorCode; }
            set { vendorCode = value; }
        }
        private String invoiceNumber = String.Empty; //length 15

        public String InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
        private String type = String.Empty; //length 30

        public String Type
        {
            get { return type; }
            set { type = value; }
        }


        private String vendorItemCode;

        public String VendorItemCode
        {
            get { return vendorItemCode; }
            set { vendorItemCode = value; }
        }


        private String inventoryCode;

        public String InventoryCode
        {
            get { return inventoryCode; }
            set { inventoryCode = value; }
        }


        private Decimal quantity;

        public Decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private String orderUnit;

        public String OrderUnit
        {
            get { return orderUnit; }
            set { orderUnit = value; }
        }

        private Decimal price;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private Decimal extended_Price;

        public Decimal Extended_Price
        {
            get { return extended_Price; }
            set { extended_Price = value; }
        }

    }
}