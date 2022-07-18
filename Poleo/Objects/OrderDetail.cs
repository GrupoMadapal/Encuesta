using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrderDetail
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
        private String store_No = String.Empty;

        public String Store_No
        {
            get { return store_No; }
            set { store_No = value; }
        }
        private DateTime ord_Dt;

        public DateTime Ord_Dt
        {
            get { return ord_Dt; }
            set { ord_Dt = value; }
        }
        private int ord_No = 0;

        public int Ord_No
        {
            get { return ord_No; }
            set { ord_No = value; }
        }
        private int line_No = 0;

        public int Line_No
        {
            get { return line_No; }
            set { line_No = value; }
        }
        private String std_Prod_Cd = String.Empty;

        public String Std_Prod_Cd
        {
            get { return std_Prod_Cd; }
            set { std_Prod_Cd = value; }
        }
        private String prod_Cd = String.Empty;

        public String Prod_Cd
        {
            get { return prod_Cd; }
            set { prod_Cd = value; }
        }
        private String prod_Size_Code = String.Empty;

        public String Prod_Size_Code
        {
            get { return prod_Size_Code; }
            set { prod_Size_Code = value; }
        }
        private String right_Top_Ds = String.Empty;

        public String Right_Top_Ds
        {
            get { return right_Top_Ds; }
            set { right_Top_Ds = value; }
        }
        private String left_Top_Ds = String.Empty;

        public String Left_Top_Ds
        {
            get { return left_Top_Ds; }
            set { left_Top_Ds = value; }
        }
        private int prod_Qt = 0;

        public int Prod_Qt
        {
            get { return prod_Qt; }
            set { prod_Qt = value; }
        }
        private String cpn_Cd = String.Empty;

        public String Cpn_Cd
        {
            get { return cpn_Cd; }
            set { cpn_Cd = value; }
        }
        private String cpn_Descr = String.Empty;

        public String Cpn_Descr
        {
            get { return cpn_Descr; }
            set { cpn_Descr = value; }
        }
        private String combo_Cd = String.Empty;

        public String Combo_Cd
        {
            get { return combo_Cd; }
            set { combo_Cd = value; }
        }
        private Decimal load_Tm = 0;

        public Decimal Load_Tm
        {
            get { return load_Tm; }
            set { load_Tm = value; }
        }
        private Decimal wait_Tm = 0;

        public Decimal Wait_Tm
        {
            get { return wait_Tm; }
            set { wait_Tm = value; }
        }
        private String prize_Fg = String.Empty;

        public String Prize_Fg
        {
            get { return prize_Fg; }
            set { prize_Fg = value; }
        }
        private String comment_Ds = String.Empty;

        public String Comment_Ds
        {
            get { return comment_Ds; }
            set { comment_Ds = value; }
        }
        private Decimal full_Menu_Amt = 0;

        public Decimal Full_Menu_Amt
        {
            get { return full_Menu_Amt; }
            set { full_Menu_Amt = value; }
        }
        private Decimal menu_Amt = 0;

        public Decimal Menu_Amt
        {
            get { return menu_Amt; }
            set { menu_Amt = value; }
        }
        private Decimal item_Net_Amt = 0;

        public Decimal Item_Net_Amt
        {
            get { return item_Net_Amt; }
            set { item_Net_Amt = value; }
        }
        private Decimal ideal_Food_Cst = 0;

        public Decimal Ideal_Food_Cst
        {
            get { return ideal_Food_Cst; }
            set { ideal_Food_Cst = value; }
        }
        private Decimal prc_Ovr_Amt = 0;

        public Decimal Prc_Ovr_Amt
        {
            get { return prc_Ovr_Amt; }
            set { prc_Ovr_Amt = value; }
        }
        private String prc_Ovr_Cd = String.Empty;

        public String Prc_Ovr_Cd
        {
            get { return prc_Ovr_Cd; }
            set { prc_Ovr_Cd = value; }
        }
    }
}