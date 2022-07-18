using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Roles
    {
        private int idRol = 0;
        private string name = string.Empty;
        private string description = string.Empty;

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}