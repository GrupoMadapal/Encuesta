using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ServiceTime
    {
        private int loadTime;
        private int waitTime;
        private int outTheDoorTime;
        private int rowTienda;
        private int estimatedDeliveryTime;

        public int LoadTime
        {
            get { return loadTime; }
            set { loadTime = value; }
        }

        public int WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }

        public int OutTheDoorTime
        {
            get { return outTheDoorTime; }
            set { outTheDoorTime = value; }
        }

        public int EstimatedDeliveryTime
        {
            get { return estimatedDeliveryTime; }
            set { estimatedDeliveryTime = value; }
        }

        public int RowTienda
        {
            get { return rowTienda; }
            set { rowTienda = value; }
        }

        
    }
}