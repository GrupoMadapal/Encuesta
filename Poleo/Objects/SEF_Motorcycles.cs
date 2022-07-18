using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class SEF_Motorcycles
    {
        private int iDMotorcycle;
        public int IDMotorcycle
        {
            get { return iDMotorcycle; }
            set { iDMotorcycle = value; }
        }
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private int model;
        public int Model
        {
            get { return model; }
            set { model = value; }
        }

        private String serial = string.Empty;
        public String Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        private String licenseNumberPlate = string.Empty;
        public String LicenseNumberPlate
        {
            get { return licenseNumberPlate; }
            set { licenseNumberPlate = value; }
        }

        private int numberStore;
        public int NumberStore
        {
            get { return numberStore; }
            set { numberStore = value; }
        }

        private String numEco = string.Empty;
        public String NumEco
        {
            get { return numEco; }
            set { numEco = value; }
        }

        private String location;
        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private String commentaries;
        public String Commentaries
        {
            get { return commentaries; }
            set { commentaries = value; }
        }

        private String reason;
        public String Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        private String replaced;
        public String Replaced
        {
            get { return replaced; }
            set { replaced = value; }
        }

    }
}