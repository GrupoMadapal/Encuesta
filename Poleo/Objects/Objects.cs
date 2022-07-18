using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Objects
    {
        private int idObject = 0;
        private string name = string.Empty;
        private string description;
        private string codeObject;
        private int? idParent = null;

        public int IdObject
        {
            get { return idObject; }
            set { idObject = value; }
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

        public string CodeObject
        {
            get { return codeObject; }
            set { codeObject = value; }
        }

        public int? IdParent
        {
            get { return idParent; }
            set { idParent = value; }
        }
    }
}