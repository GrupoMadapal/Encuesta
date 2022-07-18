using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class ConfigFilesTABS
    {
        private int iDConfigFiles;
        private string numer_Tienda;
        private string dirOrigen;
        private string dirDestino;

        public int IDConfigFiles
        {
            get { return iDConfigFiles; }
            set { iDConfigFiles = value; }
        }

        public string Numer_Tienda
        {
            get { return numer_Tienda; }
            set { numer_Tienda = value; }
        }

        public string DirOrigen
        {
            get { return dirOrigen; }
            set { dirOrigen = value; }
        }

        public string DirDestino
        {
            get { return dirDestino; }
            set { dirDestino = value; }
        }
    }
}