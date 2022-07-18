using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Configuration;

using Poleo.Objects;

namespace Poleo.BLL
{
    public class TAB_sBLL
    {
        //Added by Hector Sanchez M. 20160209
        public TAB_s SelectMoveFiles(string URLOrigen)
        {
            try
            {
                TAB_s objTabs = new TAB_s();
                DirectoryInfo dirInfo = new DirectoryInfo(URLOrigen);
                DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
                string ConfigTabs = ConfigurationManager.AppSettings["FileTABS"].ToString();
                IList<string> tabs = new List<string>();//string[] tabs = ConfigTabs.Split(',');
                tabs = ConfigTabs.Split(',');

                FileInfo[] fileNames = dirInfo.GetFiles("*.tab");//dirItem.GetFiles("*.tab");
                foreach (FileInfo item in fileNames)
                {
                    StreamReader objStreamReader = new StreamReader(File.OpenRead(item.FullName));
                    Files objFiles = new Files(item.FullName);

                    if (tabs.Contains(objFiles.TypeFile.ToUpper()))
                    {
                        objTabs.lstFiles.Add(objFiles);
                    }
                }

                return objTabs;
            }
            catch (Exception ex)
            {
                LogBLL objLogBLL = new LogBLL();
                objLogBLL.InsertErrorLog(ex.Message);

                return null;
            }
        }

        public void MoveFilesTABS(string URLDestino, TAB_s FilesToMove)
        {
            if (!System.IO.Directory.Exists(URLDestino))
                System.IO.Directory.CreateDirectory(URLDestino);

            foreach (Files objFiles in FilesToMove.lstFiles)
            {
                String[] names = objFiles.NameFile.Split(new[] { "\\" }, StringSplitOptions.None);

                if (!File.Exists(URLDestino + "\\" + names[names.Length - 1]))
                    File.Copy(objFiles.NameFile, URLDestino + "\\" + names[names.Length - 1]);
            }
        }

        public int? ValidTransferStore()
        {
            RegisterFileBLL objRegisterFileBLL = new RegisterFileBLL();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            TransferBLL objTransferBLL = new TransferBLL();
            IList<Tienda> lstTienda = new List<Tienda>();
            ShcheduleTransfer objShcheduleTransferFind = new ShcheduleTransfer();
            ShcheduleTransferBLL objShcheduleTransferBLL = new ShcheduleTransferBLL();
            IList<ShcheduleTransfer> lstShcheduleTransfer = new List<ShcheduleTransfer>();
            int? IdTransfer = null;
            DateTime dateT = DateTime.Now;
            //int TAttempts = 0;

            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TransferAttempts"].ToString()))
            //    TAttempts = int.Parse(ConfigurationManager.AppSettings["TransferAttempts"].ToString());

            objShcheduleTransferFind.TypeWs = "TB";//TABS

            lstShcheduleTransfer = objShcheduleTransferBLL.SelectShcheduleTransfer(objShcheduleTransferFind);
            lstTienda = objTiendaBLL.SelectTiendas(new Tienda());

            foreach (ShcheduleTransfer objShcheduleTransfer in lstShcheduleTransfer)
            {
                foreach (Tienda objTienda in lstTienda)
                {
                    bool validDate = objRegisterFileBLL.ValidDateTransfer(objTienda.Number_tienda, objShcheduleTransfer.ScheduleS);

                    if (validDate)
                    {
                        bool TransferStore = objTransferBLL.ValidTransferByStore(objTienda.Number_tienda, dateT, objShcheduleTransfer.IDScheduleTransfer);

                        if (TransferStore)
                        {
                            bool registerFile = objRegisterFileBLL.ValidateFilesTABs(objTienda.Number_tienda, dateT.AddDays(-1));

                            if (registerFile)
                            {
                                IdTransfer = null;
                                //break;
                            }
                            else
                            {
                                bool validAttemp = objTransferBLL.ValidateAttemps(objTienda.Number_tienda, objShcheduleTransfer.IDScheduleTransfer, dateT);

                                if (!validAttemp)
                                    IdTransfer = null;
                                else
                                    IdTransfer = objShcheduleTransfer.IDScheduleTransfer;
                            }
                        }
                        else
                        {
                            IdTransfer = objShcheduleTransfer.IDScheduleTransfer;
                            break;
                        }
                    }

                    if (IdTransfer != null)
                        break;
                }

                if (IdTransfer != null)
                    break;
            }

            return IdTransfer;
        }
    }
}