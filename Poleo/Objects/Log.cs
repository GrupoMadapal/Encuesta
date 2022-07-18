using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Log
    {
        private int idLog;
		private string message;
		private DateTime date;
        private string type;

        public int IdLog
        {
            get { return idLog; }
            set { idLog = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}