using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class SettingsFileSales
    {
        private string company;
		private int year;
        private int numWeek;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int NumWeek
        {
            get { return numWeek; }
            set { numWeek = value; }
        }
    }
}