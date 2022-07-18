using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class OrderbyTime
    {
        private int ord_Less_15 = 0;

        public int Ord_Less_15
        {
            get { return ord_Less_15; }
            set { ord_Less_15 = value; }
        }
        private int ord_Less_30 = 0;

        public int Ord_Less_30
        {
            get { return ord_Less_30; }
            set { ord_Less_30 = value; }
        }
        private int ord_More_30 = 0;

        public int Ord_More_30
        {
            get { return ord_More_30; }
            set { ord_More_30 = value; }
        }
        private int ord_Total = 0;

        public int Ord_Total
        {
            get { return ord_Total; }
            set { ord_Total = value; }
        }
    }
}