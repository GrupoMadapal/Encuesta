using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrdersExtracts
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

        private String store_No = String.Empty;//length 8
        public String Store_No
        {
            get { return store_No; }
            set { store_No = value; }
        }

        private DateTime ord_Dt = DateTime.Now;
        public DateTime Ord_Dt
        {
            get { return ord_Dt; }
            set { ord_Dt = value; }
        }

        private Nullable<int> ord_No = 0;
        public Nullable<int> Ord_No
        {
            get { return ord_No; }
            set { ord_No = value; }
        }

        private Nullable<int> late_Order_Fg = 0;
        public Nullable<int> Late_Order_Fg
        {
            get { return late_Order_Fg; }
            set { late_Order_Fg = value; }
        }

        private Nullable<char> corrected_Ord_Fg = new char();
        public Nullable<char> Corrected_Ord_Fg
        {
            get { return corrected_Ord_Fg; }
            set { corrected_Ord_Fg = value; }
        }

        private Nullable<char> lrg_Adj_Fg = new char();
        public Nullable<char> Lrg_Adj_Fg
        {
            get { return lrg_Adj_Fg; }
            set { lrg_Adj_Fg = value; }
        }

        private String ord_Type_Cd = String.Empty;//length 2
        public String Ord_Type_Cd
        {
            get { return ord_Type_Cd; }
            set { ord_Type_Cd = value; }
        }

        private String ord_Status_Cd = String.Empty;//length 1
        public String Ord_Status_Cd
        {
            get { return ord_Status_Cd; }
            set { ord_Status_Cd = value; }
        }

        private String ret_Reason_Ds = String.Empty;//length 50
        public String Ret_Reason_Ds
        {
            get { return ret_Reason_Ds; }
            set { ret_Reason_Ds = value; }
        }

        private String late_Disp_Ds = String.Empty;//length 255
        public String Late_Disp_Ds
        {
            get { return late_Disp_Ds; }
            set { late_Disp_Ds = value; }
        }

        private String phone = String.Empty;//length 25
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private Nullable<DateTime> ord_Hms = DateTime.Now;
        public Nullable<DateTime> Ord_Hms
        {
            get { return ord_Hms; }
            set { ord_Hms = value; }
        }

        private Nullable<DateTime> disp_Hms = DateTime.Now;
        public Nullable<DateTime> Disp_Hms
        {
            get { return disp_Hms; }
            set { disp_Hms = value; }
        }

        private Nullable<int> hold_Tm = 0;
        public Nullable<int> Hold_Tm
        {
            get { return hold_Tm; }
            set { hold_Tm = value; }
        }

        private Nullable<int> take_Tm = 0;
        public Nullable<int> Take_Tm
        {
            get { return take_Tm; }
            set { take_Tm = value; }
        }

        private Nullable<int> leg_Tm = 0;
        public Nullable<int> Leg_Tm
        {
            get { return leg_Tm; }
            set { leg_Tm = value; }
        }

        private Nullable<int> delv_Tm = 0;
        public Nullable<int> Delv_Tm
        {
            get { return delv_Tm; }
            set { delv_Tm = value; }
        }


        private Nullable<int> min_Exp_Tm = 0;
        public Nullable<int> Min_Exp_Tm
        {
            get { return min_Exp_Tm; }
            set { min_Exp_Tm = value; }
        }

        private Nullable<int> max_Exp_Tm = 0;
        public Nullable<int> Max_Exp_Tm
        {
            get { return max_Exp_Tm; }
            set { max_Exp_Tm = value; }
        }

        private Nullable<int> stop_Sq = 0;
        public Nullable<int> Stop_Sq
        {
            get { return stop_Sq; }
            set { stop_Sq = value; }
        }

        private Nullable<int> stop_Ct = 0;
        public Nullable<int> Stop_Ct
        {
            get { return stop_Ct; }
            set { stop_Ct = value; }
        }

        private Nullable<decimal> menu_Amt = 0;
        public Nullable<decimal> Menu_Amt
        {
            get { return menu_Amt; }
            set { menu_Amt = value; }
        }

        private Nullable<decimal> disc_Amt = 0;
        public Nullable<decimal> Disc_Amt
        {
            get { return disc_Amt; }
            set { disc_Amt = value; }
        }

        private Nullable<decimal> f9_Amt = 0;
        public Nullable<decimal> F9_Amt
        {
            get { return f9_Amt; }
            set { f9_Amt = value; }
        }

        private String f9_Reason = String.Empty;//length 8
        public String F9_Reason
        {
            get { return f9_Reason; }
            set { f9_Reason = value; }
        }

        private Nullable<decimal> surchg_Amt = 0;
        public Nullable<decimal> Surchg_Amt
        {
            get { return surchg_Amt; }
            set { surchg_Amt = value; }
        }

        private Nullable<decimal> net_Amt = 0;
        public Nullable<decimal> Net_Amt
        {
            get { return net_Amt; }
            set { net_Amt = value; }
        }

        private Nullable<decimal> tax_Amt = 0;
        public Nullable<decimal> Tax_Amt
        {
            get { return tax_Amt; }
            set { tax_Amt = value; }
        }

        private Nullable<decimal> bottle_Amt = 0;
        public Nullable<decimal> Bottle_Amt
        {
            get { return bottle_Amt; }
            set { bottle_Amt = value; }
        }

        private Nullable<decimal> cust_Amt = 0;
        public Nullable<decimal> Cust_Amt
        {
            get { return cust_Amt; }
            set { cust_Amt = value; }
        }

        private Nullable<decimal> high_Net_Amt = 0;
        public Nullable<decimal> High_Net_Amt
        {
            get { return high_Net_Amt; }
            set { high_Net_Amt = value; }
        }

        private String payment_Type_Cd = String.Empty;//length 2
        public String Payment_Type_Cd
        {
            get { return payment_Type_Cd; }
            set { payment_Type_Cd = value; }
        }

        private String credit_Card_Descr = String.Empty;//length 20
        public String Credit_Card_Descr
        {
            get { return credit_Card_Descr; }
            set { credit_Card_Descr = value; }
        }

        private Nullable<decimal> ideal_Food_Cst = 0;
        public Nullable<decimal> Ideal_Food_Cst
        {
            get { return ideal_Food_Cst; }
            set { ideal_Food_Cst = value; }
        }

        private String first_Cpn_Cd = String.Empty;//length 8
        public String First_Cpn_Cd
        {
            get { return first_Cpn_Cd; }
            set { first_Cpn_Cd = value; }
        }

        private String cpn_Descr = String.Empty;//length 64
        public String Cpn_Descr
        {
            get { return cpn_Descr; }
            set { cpn_Descr = value; }
        }

        private Nullable<int> reprint_Ct = 0;
        public Nullable<int> Reprint_Ct
        {
            get { return reprint_Ct; }
            set { reprint_Ct = value; }
        }

        private String reprint_Ssn = String.Empty;//length 25
        public String Reprint_Ssn
        {
            get { return reprint_Ssn; }
            set { reprint_Ssn = value; }
        }

        private Nullable<DateTime> reprint_Hms = DateTime.Now;
        public Nullable<DateTime> Reprint_Hms
        {
            get { return reprint_Hms; }
            set { reprint_Hms = value; }
        }

        private Nullable<int> edit_Ct = 0;
        public Nullable<int> Edit_Ct
        {
            get { return edit_Ct; }
            set { edit_Ct = value; }
        }

        private String edit_Ssn = String.Empty;//length 25
        public String Edit_Ssn
        {
            get { return edit_Ssn; }
            set { edit_Ssn = value; }
        }

        private Nullable<DateTime> edit_Hms = DateTime.Now;
        public Nullable<DateTime> Edit_Hms
        {
            get { return edit_Hms; }
            set { edit_Hms = value; }
        }

        private Nullable<char> cycle_Id_Cd = new char();
        public Nullable<char> Cycle_Id_Cd
        {
            get { return cycle_Id_Cd; }
            set { cycle_Id_Cd = value; }
        }

        private Nullable<char> prize_Collect_Fg = new char();
        public Nullable<char> Prize_Collect_Fg
        {
            get { return prize_Collect_Fg; }
            set { prize_Collect_Fg = value; }
        }

        private String drv_Ssn = String.Empty;//length 25
        public String Drv_Ssn
        {
            get { return drv_Ssn; }
            set { drv_Ssn = value; }
        }

        private String csr_Ssn = String.Empty;//length 25
        public String Csr_Ssn
        {
            get { return csr_Ssn; }
            set { csr_Ssn = value; }
        }

        private String phone2 = String.Empty;//length 25
        public String Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }

        private String old_Phone = String.Empty;//length 25
        public String Old_Phone
        {
            get { return old_Phone; }
            set { old_Phone = value; }
        }

        private Nullable<DateTime> phone_Conv_Dt = DateTime.Now;
        public Nullable<DateTime> Phone_Conv_Dt
        {
            get { return phone_Conv_Dt; }
            set { phone_Conv_Dt = value; }
        }

        private String cust_Store_No = String.Empty;//length 8
        public String Cust_Store_No
        {
            get { return cust_Store_No; }
            set { cust_Store_No = value; }
        }

        private String station_No = String.Empty;//length 50
        public String Station_No
        {
            get { return station_No; }
            set { station_No = value; }
        }

        private Nullable<decimal> tip_Amt = 0;
        public Nullable<decimal> Tip_Amt
        {
            get { return tip_Amt; }
            set { tip_Amt = value; }
        }

        private Nullable<char> special_Credit_Cd = new char();
        public Nullable<char> Special_Credit_Cd
        {
            get { return special_Credit_Cd; }
            set { special_Credit_Cd = value; }
        }

        private String email_Addr = String.Empty;//length 255
        public String Email_Addr
        {
            get { return email_Addr; }
            set { email_Addr = value; }
        }

        private String temp_Field_1 = String.Empty;//length 255
        public String Temp_Field_1
        {
            get { return temp_Field_1; }
            set { temp_Field_1 = value; }
        }

        private String temp_Field_2 = String.Empty;//length 255
        public String Temp_Field_2
        {
            get { return temp_Field_2; }
            set { temp_Field_2 = value; }
        }

        private Nullable<decimal> prc_Ovr_Hdr_Amt = 0;
        public Nullable<decimal> Prc_Ovr_Hdr_Amt
        {
            get { return prc_Ovr_Hdr_Amt; }
            set { prc_Ovr_Hdr_Amt = value; }
        }

        private Nullable<decimal> check_Chg_Amt = 0;
        public Nullable<decimal> Check_Chg_Amt
        {
            get { return check_Chg_Amt; }
            set { check_Chg_Amt = value; }
        }

        private Nullable<int> load_Time_Secs = 0;
        public Nullable<int> Load_Time_Secs
        {
            get { return load_Time_Secs; }
            set { load_Time_Secs = value; }
        }

        private String order_Source = String.Empty;//length 25
        public String Order_Source
        {
            get { return order_Source; }
            set { order_Source = value; }
        }

        private String organization_Url = String.Empty;//length 500
        public String Organization_Url
        {
            get { return organization_Url; }
            set { organization_Url = value; }
        }

        private String ord_Src_Method = String.Empty;//length 50
        public String Ord_Src_Method
        {
            get { return ord_Src_Method; }
            set { ord_Src_Method = value; }
        }

        private Nullable<int> pulse_Order_Status_Code = 0;
        public Nullable<int> Pulse_Order_Status_Code
        {
            get { return pulse_Order_Status_Code; }
            set { pulse_Order_Status_Code = value; }
        }

        private String currency_Code = String.Empty;//length 8
        public String Currency_Code
        {
            get { return currency_Code; }
            set { currency_Code = value; }
        }

        private Nullable<decimal> orderRoyaltySales = 0;
        public Nullable<decimal> OrderRoyaltySales
        {
            get { return orderRoyaltySales; }
            set { orderRoyaltySales = value; }
        }

        private Nullable<float> outboundMileage = 0.0f;
        public Nullable<float> OutboundMileage
        {
            get { return outboundMileage; }
            set { outboundMileage = value; }
        }

        private Nullable<float> returnMileage = 0.0f;
        public Nullable<float> ReturnMileage
        {
            get { return returnMileage; }
            set { returnMileage = value; }
        }

        private String mileageSource = String.Empty;//length 2
        public String MileageSource
        {
            get { return mileageSource; }
            set { mileageSource = value; }
        }

        private String vehicleCode = String.Empty;//length 8
        public String VehicleCode
        {
            get { return vehicleCode; }
            set { vehicleCode = value; }
        }

        private Nullable<DateTime> calculatedDeliveryTime = DateTime.Now;
        public Nullable<DateTime> CalculatedDeliveryTime
        {
            get { return calculatedDeliveryTime; }
            set { calculatedDeliveryTime = value; }
        }

        private Nullable<int> calculatedDeliveryTimeSecs = 0;
        public Nullable<int> CalculatedDeliveryTimeSecs
        {
            get { return calculatedDeliveryTimeSecs; }
            set { calculatedDeliveryTimeSecs = value; }
        }

        private Nullable<int> outboundDriveTimeSecs = 0;
        public Nullable<int> OutboundDriveTimeSecs
        {
            get { return outboundDriveTimeSecs; }
            set { outboundDriveTimeSecs = value; }
        }

        private Nullable<int> returnDriveTimeSecs = 0;
        public Nullable<int> ReturnDriveTimeSecs
        {
            get { return returnDriveTimeSecs; }
            set { returnDriveTimeSecs = value; }
        }

        private String driveTimeSource = String.Empty;//length 2
        public String DriveTimeSource
        {
            get { return driveTimeSource; }
            set { driveTimeSource = value; }
        }

        private Nullable<DateTime> calculatedReturnTime = DateTime.Now;
        public Nullable<DateTime> CalculatedReturnTime
        {
            get { return calculatedReturnTime; }
            set { calculatedReturnTime = value; }
        }
    }
}