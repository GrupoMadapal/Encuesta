using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Poleo.Objects
{
   public class Files
    {
        private int totalRegister = 0;

        public int TotalRegister
        {
            get { return totalRegister; }
            set { totalRegister = value; }
        }
        private int totalCorrect = 0;

        public int TotalCorrect
        {
            get { return totalCorrect; }
            set { totalCorrect = value; }
        }
        private int totalError = 0;

        public int TotalError
        {
            get { return totalError; }
            set { totalError = value; }
        }
        private String nameFile = String.Empty;

        public String NameFile
        {
            get { return nameFile; }
            set { nameFile = value; }
        }
        private String typeFile = String.Empty;

        public String TypeFile
        {
            get { return typeFile; }
            set { typeFile = value; }
        }
        private String numberShop = String.Empty;

        public String NumberShop
        {
            get { return numberShop; }
            set { numberShop = value; }
        }
        private String date = String.Empty;

        public String Date
        {
            get { return date; }
            set { date = value; }
        }
        public DateTime DateFile
        {
            get { return DateTime.ParseExact(Date, "yyyyMMdd", CultureInfo.InvariantCulture); }
        }
        private String creationDate = String.Empty;

        public String CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        private String creationTime = String.Empty;

        public String CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }
        private String tableName = String.Empty;

        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public Files(string fileName)
        {
            NameFile = fileName;
            extractInformation();
        }
        public Files()
        { }
        

        public Boolean FileCorrect
        {
            get { return totalError>0; }           
        }

        public void extractInformation()
        {
            if (!String.IsNullOrEmpty(NameFile))
            {
                String[] rute = NameFile.Split(new[] { "\\" }, StringSplitOptions.None);
                if (rute.Length > 0)
                {
                    String[] name = rute[rute.Length - 1].Split('_');
                    if (name.Length == 7)
                    {
                        typeFile = name[0];
                        numberShop = name[1];
                        date = name[2];
                        creationDate = name[4];
                        CreationTime = name[5];
                        tableName = name[6].Split('.')[0];
                    }
                }
            }

        }
        

    }
}
