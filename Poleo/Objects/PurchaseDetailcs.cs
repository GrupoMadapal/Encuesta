using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class PurchaseDetailcs
    {
        private String recordType = String.Empty;

        public String RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }
        private String databaseVersion = String.Empty;

        public String DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }
        private String location_Code = String.Empty;

        public String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }
        private DateTime system_Date;

        public DateTime System_Date
        {
            get { return system_Date; }
            set { system_Date = value; }
        }
        private int purchaseID = 0;

        public int PurchaseID
        {
            get { return purchaseID; }
            set { purchaseID = value; }
        }
        private String vendorName = String.Empty;

        public String VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
        }
        private String vendorCode = String.Empty;

        public String VendorCode
        {
            get { return vendorCode; }
            set { vendorCode = value; }
        }
        private String invoiceNumber = String.Empty;

        public String InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
        private String type = String.Empty;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        private String vendorItemCode = String.Empty;

        public String VendorItemCode
        {
            get { return vendorItemCode; }
            set { vendorItemCode = value; }
        }
        private String inventoryCode = String.Empty;

        public String InventoryCode
        {
            get { return inventoryCode; }
            set { inventoryCode = value; }
        }
        private Decimal quantity = 0;

        public Decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private String orderUnit = String.Empty;

        public String OrderUnit
        {
            get { return orderUnit; }
            set { orderUnit = value; }
        }
        private Decimal price = 0;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        private Decimal extended_Price = 0;

        public Decimal Extended_Price
        {
            get { return extended_Price; }
            set { extended_Price = value; }
        }
    }
}