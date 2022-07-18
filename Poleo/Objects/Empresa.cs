using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Empresa
    {
        private int idEmpresa = 0;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        private String nombre = String.Empty;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String rFC = String.Empty;

        public String RFC
        {
            get { return rFC; }
            set { rFC = value; }
        }
        private Boolean activo = false;

        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}