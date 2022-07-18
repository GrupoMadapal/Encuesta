using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Estatus
    {
        private int idStatus;
        public int IdStatus
        {
            get { return idStatus; }
            set { idStatus = value; }
        }

        private String status = string.Empty;
        public String Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}