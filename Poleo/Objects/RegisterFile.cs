using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class RegisterFile
    {
        private String tienda = String.Empty;

        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }
        private DateTime dateRegister;

        public DateTime DateRegister
        {
            get { return dateRegister; }
            set { dateRegister = value; }
        }
        private Boolean aTR = false;

        public Boolean ATR
        {
            get { return aTR; }
            set { aTR = value; }
        }
        private Boolean cKY = false;

        public Boolean CKY
        {
            get { return cKY; }
            set { cKY = value; }
        }
        private Boolean dYS = false;

        public Boolean DYS
        {
            get { return dYS; }
            set { dYS = value; }
        }
        private Boolean iNV = false;

        public Boolean INV
        {
            get { return iNV; }
            set { iNV = value; }
        }
        private Boolean iPR = false;

        public Boolean IPR
        {
            get { return iPR; }
            set { iPR = value; }
        }
        private Boolean oRD = false;

        public Boolean ORD
        {
            get { return oRD; }
            set { oRD = value; }
        }
        private Boolean pRS = false;

        public Boolean PRS
        {
            get { return pRS; }
            set { pRS = value; }
        }
        private Boolean iPD = false;

        public Boolean IPD
        {
            get { return iPD; }
            set { iPD = value; }
        }
        private Boolean oC2 = false;

        public Boolean OC2
        {
            get { return oC2; }
            set { oC2 = value; }
        }
        private Boolean oDT = false;

        public Boolean ODT
        {
            get { return oDT; }
            set { oDT = value; }
        }

        //Added by Hector Sanchez M. - 20160517
        private bool oR2 = false;
        public bool OR2
        {
            get { return oR2; }
            set { oR2 = value; }
        }
    }
}