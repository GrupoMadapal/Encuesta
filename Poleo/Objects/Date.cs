using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Date
    {
        private string Year;
        private string Month;
        private string Day;
        public string year
        {
            get { return Year; }
            set { Year = value; }
        }
        public string month
        {
            get { return Month; }
            set { Month = value; }
        }
        public string day
        {
            get { return Day; }
            set { Day = value; }
        }
    }
}