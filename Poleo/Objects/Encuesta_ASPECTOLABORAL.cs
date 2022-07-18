using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Encuesta_ASPECTOLABORAL
    {
        public Encuesta_ASPECTOLABORAL()
        {
            razon1 = "";
            razon2 = "";
            Razon3 = "";
            idencuesta=0;
        }
        private String razon1 = String.Empty;
        public String Razon1
        {
            get { return razon1; }
            set { razon1 = value; }
        }

        private String razon2 = String.Empty;
        public String Razon2
        {
            get { return razon2; }
            set { razon2 = value; }
        }
        private String razon3 = String.Empty;
        public String Razon3
        {
            get { return razon3; }
            set { razon3 = value; }
        }

        private int idencuesta;
        public int IdEncuesta
        {
            get { return idencuesta; }
            set { idencuesta = value; }
        }
    }
}