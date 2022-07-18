using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Transactions
    {
        private String recordType = String.Empty; // max length 8 

        public  String RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }       

        private String location_Code = String.Empty; //max length 8

        public  String Location_Code
        {
            get { return location_Code; }
            set { location_Code = value; }
        }

        private Nullable<DateTime> system_Date = DateTime.Now;

        public  Nullable<DateTime> System_Date
        {
            get { return system_Date; }
            set { system_Date = value; }
        }

        private String account_Code = String.Empty; //max length 10

        public  String Account_Code
        {
            get { return account_Code; }
            set { account_Code = value; }
        }

        private String account_Description = String.Empty;

        public  String Account_Description
        {
            get { return account_Description; }
            set { account_Description = value; }
        }

        private Nullable<int> trans_Sequence = 0;

        public  Nullable<int> Trans_Sequence
        {
            get { return trans_Sequence; }
            set { trans_Sequence = value; }
        }

        private  String trans_Description = String.Empty;// max length 20

        public  String Trans_Description
        {
            get { return trans_Description; }
            set { trans_Description = value; }
        }

        private String invoice_Number = String.Empty; //max length 15

        public String Invoice_Number
        {
            get { return invoice_Number; }
            set { invoice_Number = value; }
        }

        private Nullable<Decimal> trans_Amount = 0;

        public Nullable<Decimal> Trans_Amount
        {
            get { return trans_Amount; }
            set { trans_Amount = value; }
        }

        private Nullable<char> debit_Credit_Code = ' ';

        public Nullable<char> Debit_Credit_Code
        {
            get { return debit_Credit_Code; }
            set { debit_Credit_Code = value; }
        }
        private Nullable<DateTime> edit_DateTime = DateTime.Now;

        public Nullable<DateTime> Edit_DateTime
        {
            get { return edit_DateTime; }
            set { edit_DateTime = value; }
        }

        private String edit_User = String.Empty;// max length 8

        public String Edit_User
        {
            get { return edit_User; }
            set { edit_User = value; }
        }

        private String comments = String.Empty;

        public String Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private Nullable<DateTime> deposit_DateTime = DateTime.Now;

        public Nullable<DateTime> Deposit_DateTime
        {
            get { return deposit_DateTime; }
            set { deposit_DateTime = value; }
        }

        private String bank_Number = String.Empty; // max lenght 8

        public String Bank_Number
        {
            get { return bank_Number; }
            set { bank_Number = value; }
        }

        private String bank_name = String.Empty; // max length 50

        public String Bank_name
        {
            get { return bank_name; }
            set { bank_name = value; }
        }

        private String deposit_Slip_Number = String.Empty;// max length 20

        public String Deposit_Slip_Number
        {
            get { return deposit_Slip_Number; }
            set { deposit_Slip_Number = value; }
        }

        private String deposit_bag_number = String.Empty; // Max length 10

        public String Deposit_bag_number
        {
            get { return deposit_bag_number; }
            set { deposit_bag_number = value; }
        }

        private String deposit_Employee_Code1 = String.Empty; // Max Length 8

        public String Deposit_Employee_Code1
        {
            get { return deposit_Employee_Code1; }
            set { deposit_Employee_Code1 = value; }
        }

        private String deposit_Employee_Code2 = String.Empty; // Max Length 8

        public String Deposit_Employee_Code2
        {
            get { return deposit_Employee_Code2; }
            set { deposit_Employee_Code2 = value; }
        }
        
        private Nullable<int> isDeposit = 0;

        public Nullable<int> IsDeposit
        {
            get { return isDeposit; }
            set { isDeposit = value; }
        }

        private Nullable<Decimal> deposit_Cast_amount = 0;

        public Nullable<Decimal> Deposit_Cast_amount
        {
            get { return deposit_Cast_amount; }
            set { deposit_Cast_amount = value; }
        }

        private Nullable<Decimal> deposit_Check_Amount = 0;

        public Nullable<Decimal> Deposit_Check_Amount
        {
            get { return deposit_Check_Amount; }
            set { deposit_Check_Amount = value; }
        }

        private Nullable<int> deposit_Check_Count = 0;

        public Nullable<int> Deposit_Check_Count
        {
            get { return deposit_Check_Count; }
            set { deposit_Check_Count = value; }
        }
        private String depositName1 = String.Empty; // Max Length 55

        public String DepositName1
        {
            get { return depositName1; }
            set { depositName1 = value; }
        }
        private String depositName2 = String.Empty;   // Max Length 55

        public String DepositName2
        {
            get { return depositName2; }
            set { depositName2 = value; }
        }

        private String deposit_Govt_ID2 = String.Empty; // Max Length 25

        public String Deposit_Govt_ID2
        {
            get { return deposit_Govt_ID2; }
            set { deposit_Govt_ID2 = value; }
        }

        private String deposit_Govt_ID1 = String.Empty;// Max Length 25

        public String Deposit_Govt_ID1
        {
            get { return deposit_Govt_ID1; }
            set { deposit_Govt_ID1 = value; }
        }
        private String databaseVersion = String.Empty; //length 8 

        public String DatabaseVersion
        {
            get { return databaseVersion; }
            set { databaseVersion = value; }
        }
	   
    }
}