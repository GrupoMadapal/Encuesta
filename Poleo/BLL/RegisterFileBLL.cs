using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;
using System.Configuration;
using System.Globalization;

namespace Poleo.BLL
{
    public class RegisterFileBLL
    {
        #region BLL
        public bool ValidateFilesTABs(string Numero_Tienda, DateTime date)
        {
            string ConfigTabs = ConfigurationManager.AppSettings["FileTABS"].ToString();
            IList<string> tabs = new List<string>();
            tabs = ConfigTabs.Split(',');
            bool LoadFile = false;

            IList<RegisterFile> lstRegisterFile = new List<RegisterFile>();
            RegisterFile RegisterFileFinder = new RegisterFile();

            RegisterFileFinder.Tienda = Numero_Tienda;
            RegisterFileFinder.DateRegister = date;

            lstRegisterFile = SelectRegisterFile(RegisterFileFinder);

            if (lstRegisterFile.Count > 0)
            {
                foreach (string tab in tabs)
                {
                    switch (tab)
                    {
                        case "ATR":
                            if (lstRegisterFile[0].ATR)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "CKY":
                            if (lstRegisterFile[0].CKY)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "DYS":
                            if (lstRegisterFile[0].DYS)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "INV":
                            if (lstRegisterFile[0].INV)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        //case "IPR":
                        //    if (lstRegisterFile[0].IPR)
                        //        LoadFile = true;
                        //    else
                        //        LoadFile = false;
                        //    break;
                        case "ORD":
                            if (lstRegisterFile[0].ORD)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "PRS":
                            if (lstRegisterFile[0].PRS)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "ODT":
                            if (lstRegisterFile[0].ODT)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        //case "IPD":
                        //    if (lstRegisterFile[0].IPD)
                        //        LoadFile = true;
                        //    else
                        //        LoadFile = false;
                        //    break;
                        case "OC2":
                            if (lstRegisterFile[0].OC2)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                        case "OR2":
                            if (lstRegisterFile[0].OR2)
                                LoadFile = true;
                            else
                                LoadFile = false;
                            break;
                    }

                    if (!LoadFile)
                        break;
                }
            }

            return LoadFile;
        }

        public bool ValidDateTransfer(string Numero_Tienda, TimeSpan Time)
        {
            //IList<ShcheduleTransfer> lstShcheduleTransfer = new List<ShcheduleTransfer>();
            //ShcheduleTransferBLL objShcheduleTransferBLL = new ShcheduleTransferBLL();
            TransferBLL objTransferBLL = new TransferBLL();
            Transfer TransferFinder = new Transfer();
            Transfer objTransfer = new Transfer();

            //lstShcheduleTransfer = objShcheduleTransferBLL.SelectShcheduleTransfer();

            TransferFinder.Numer_Tienda = Numero_Tienda;

            objTransfer = objTransferBLL.SelectLastTransfer(TransferFinder);

            if (objTransfer != null)
            {
                if (DateTime.Now.Date >= objTransfer.DateTransferIni.Date)
                {
                    return ValidTimeTransfer(Time);
                    //foreach (ShcheduleTransfer objShcheduleTransfer in lstShcheduleTransfer)
                    //{
                    //    if (objShcheduleTransfer.ScheduleS >= DateTime.Now.TimeOfDay)
                    //        return objShcheduleTransfer.IDScheduleTransfer;
                    //}
                }
                else
                    return false;
            }
            else
            {
                return ValidTimeTransfer(Time);
                //foreach (ShcheduleTransfer objShcheduleTransfer in lstShcheduleTransfer)
                //{
                //    if (objShcheduleTransfer.ScheduleS >= DateTime.Now.TimeOfDay)
                //        return objShcheduleTransfer.IDScheduleTransfer;
                //}
            }

            //return null;
        }

        private bool ValidTimeTransfer(TimeSpan Time)
        {
            if (Time >= DateTime.Now.TimeOfDay)
                return false;

            return true;
        }

        public RegisterFile CreateRegisterFile(Files objFile)
        {
            RegisterFileDAL objRegisterDAL = new RegisterFileDAL();
            RegisterFile objRegisterResult = null;
            RegisterFile objSearch = new RegisterFile
            {
                Tienda = objFile.NumberShop,
                DateRegister = DateTime.ParseExact(objFile.Date, "yyyyMMdd", CultureInfo.InvariantCulture)
            };

            IList<RegisterFile> lstRegisterFile = objRegisterDAL.SelectRegisterFile(objSearch);
            if (lstRegisterFile.Count > 0)
            {
                objRegisterResult = lstRegisterFile[0];
            }
            else
            {
                objRegisterDAL.InsertRegisterFile(objSearch);
                objRegisterResult = objRegisterDAL.SelectRegisterFile(objSearch)[0];

            }
            return objRegisterResult;
        }
        #endregion

        #region DAL
        private IList<RegisterFile> SelectRegisterFile(RegisterFile param)
        {
            RegisterFileDAL dal = new RegisterFileDAL();
            return dal.SelectRegisterFile(param);
        }
        #endregion
    }
}