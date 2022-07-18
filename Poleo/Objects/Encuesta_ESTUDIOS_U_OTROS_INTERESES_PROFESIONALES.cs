using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES
    {
        private String razon1 = String.Empty;
        public String Razon1
        {
            get { return razon1; }
            set { razon1 = value; }
        }
        private String otro = String.Empty;
        public String Otro
        {
            get { return otro; }
            set { otro = value; }
        }

        private int idencuesta;
        public int IdEncuesta
        {
            get { return idencuesta; }
            set { idencuesta = value; }
        }
    }
}