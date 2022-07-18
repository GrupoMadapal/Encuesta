using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Models
    {
        private int iDModel;
        public int IDModel
        {
            get { return iDModel; }
            set { iDModel = value; }
        }

        private String model = string.Empty;
        public String Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}