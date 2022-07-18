using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Poleo.Objects
{
    public class Login
    {
        private String email = String.Empty;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        
        private String userName = String.Empty;
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private String password = String.Empty;
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private Boolean activo = false;
        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private String name = String.Empty;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int idUser = 0;
        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
    }
}