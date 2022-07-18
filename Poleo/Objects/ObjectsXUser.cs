using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ObjectsXUser
    {
        private int idUserXObject = 0;
        private int idUser = 0;
        private int? codeObject = 0;

        public int IdUserXObject
        {
            get { return idUserXObject; }
            set { idUserXObject = value; }
        }

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public int? CodeObject
        {
            get { return codeObject; }
            set { codeObject = value; }
        }
    }
}