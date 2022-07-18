using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class InventoryPurchasesExtracts
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
        private Nullable<decimal> amount = 0;

        public Nullable<decimal> Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private Nullable<decimal> deliveryCharge = 0;

        public Nullable<decimal> DeliveryCharge
        {
            get { return deliveryCharge; }
            set { deliveryCharge = value; }
        }
        private Nullable<decimal> tax = 0;

        public Nullable<decimal> Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private DateTime? dateEnd;

        public DateTime? DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }
    }
}