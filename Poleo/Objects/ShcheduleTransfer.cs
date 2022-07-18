using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ShcheduleTransfer
    {
        private int iDScheduleTransfer;
        private string shchuedule;
        private string typeWs;

        public int IDScheduleTransfer
        {
            get { return iDScheduleTransfer; }
            set { iDScheduleTransfer = value; }
        }

        public string Shchuedule
        {
            get { return shchuedule; }
            set { shchuedule = value; }
        }

        public string TypeWs
        {
            get { return typeWs; }
            set { typeWs = value; }
        }

        public TimeSpan ScheduleS
        {
            get { return TimeSpan.Parse(shchuedule); }
        }
    }
}