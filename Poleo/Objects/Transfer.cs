using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Transfer
    {
        private int iDTransfer;
		private int iDScheduleTransfer;
		private string numer_Tienda;
		private DateTime dateTransferIni;
		private DateTime dateTransferEnd;
        private bool successfulTransfer;
        private int attemptsTransfer;

        public int IDTransfer
        {
            get { return iDTransfer; }
            set { iDTransfer = value; }
        }

        public int IDScheduleTransfer
        {
            get { return iDScheduleTransfer; }
            set { iDScheduleTransfer = value; }
        }

        public string Numer_Tienda
        {
            get { return numer_Tienda; }
            set { numer_Tienda = value; }
        }

        public DateTime DateTransferIni
        {
            get { return dateTransferIni; }
            set { dateTransferIni = value; }
        }

        public bool SuccessfulTransfer
        {
            get { return successfulTransfer; }
            set { successfulTransfer = value; }
        }

        public int AttemptsTransfer
        {
            get { return attemptsTransfer; }
            set { attemptsTransfer = value; }
        }
    }
}