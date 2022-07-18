using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class UserXRol
    {
        private int idRoleXUser = 0;
        private int idUser = 0;
        private int idRol = 0;
        private string name = string.Empty;

        public int IdRoleXUser
        {
            get { return idRoleXUser; }
            set { idRoleXUser = value; }
        }

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

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
    }
}