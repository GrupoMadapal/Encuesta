using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Info_MasterInd
    {
        private string store_Number;
        private DateTime date_Ini;
        private DateTime date_End;
        private decimal? full_Template;
        private decimal? training;
        private decimal? communication;
        private DateTime dateRegister;

        public string Store_Number
        {
            get { return store_Number; }
            set { store_Number = value; }
        }

        public DateTime Date_Ini
        {
            get { return date_Ini; }
            set { date_Ini = value; }
        }

        public DateTime Date_End
        {
            get { return date_End; }
            set { date_End = value; }
        }

        public decimal? Full_Template
        {

            get { return full_Template; }
            set { full_Template = value; }
        }

        public decimal? Training
        {
            get { return training; }
            set { training = value; }
        }

        public decimal? Communication
        {
            get { return communication; }
            set { communication = value; }
        }

        public DateTime DateRegister
        {
            get { return dateRegister; }
            set { dateRegister = value; }
        }
    }
}