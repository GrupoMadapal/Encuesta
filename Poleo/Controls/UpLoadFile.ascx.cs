using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.Objects;
using System.IO;
using System.Collections;
using Poleo.DAL;
using Poleo.BLL;
using System.Xml;

using System.Configuration;

namespace Poleo.Controls
{
    public partial class UpLoadFile : System.Web.UI.UserControl
    {
        public bool blockForm = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnUpLoadAUTO_Click(object sender, EventArgs e)
        {
            try
            {
                TAB_s objTabs = new TAB_s();
                DriveInfo di = new DriveInfo(ConfigurationManager.AppSettings["UrlSumaryTabs"].ToString());//(@"F:\\Dropbox\\");//(@"C:\\Summary_TABS\\");
                DirectoryInfo dirInfo = new DirectoryInfo(ConfigurationManager.AppSettings["UrlSumaryTabs"].ToString());//(@"F:\\Dropbox\\");//(@"C:\\Summary_TABS\\");
                RegisterFileDAL regFileDAL = new RegisterFileDAL();
                DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
                List<StreamReader> lstbyClose = new List<StreamReader>();
                foreach (DirectoryInfo dirItem in dirInfos)
                {
                    FileInfo[] fileNames = dirItem.GetFiles("*.tab");
                    foreach (FileInfo item in fileNames)
                    {
                        StreamReader objStream = new StreamReader(File.OpenRead(item.FullName));
                        Files objFile = new Files(item.FullName);
                        RegisterFile objRegisterFileFinder = new RegisterFile()
                        {
                            Tienda = objFile.NumberShop,
                            DateRegister = objFile.DateFile
                        };
                        IList<RegisterFile> lstresult = regFileDAL.SelectRegisterFile(objRegisterFileFinder);
                        if (lstresult.Count > 0)
                        {
                            switch (objFile.TypeFile.ToUpper())
                            {
                                case "ATR":
                                    if (!lstresult[0].ATR)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "CKY":
                                    if (!lstresult[0].CKY)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "DYS":
                                    if (!lstresult[0].DYS)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "INV":
                                    if (!lstresult[0].INV)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "IPR":
                                    if (!lstresult[0].IPR)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "ORD":
                                    if (!lstresult[0].ORD)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "PRS":
                                    if (!lstresult[0].PRS)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "OC2":
                                    if (!lstresult[0].ORD)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "IPD":
                                    if (!lstresult[0].IPD)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "ODT":
                                    if (!lstresult[0].ODT)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                                case "OR2"://Added by Hector Sanchez M. - 20160517
                                    if (!lstresult[0].OR2)
                                    {
                                        objTabs.lstFiles.Add(objFile);
                                        objTabs.lstFilesContent.Add(objStream);
                                    }
                                    else
                                    {
                                        lstbyClose.Add(objStream);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            objTabs.lstFiles.Add(objFile);
                            objTabs.lstFilesContent.Add(objStream);
                        }
                    }
                }

                FileInfo[] fileNames2 = dirInfo.GetFiles("*.tab");
                foreach (FileInfo item in fileNames2)
                {
                    StreamReader objStream = new StreamReader(File.OpenRead(item.FullName));
                    Files objFile = new Files(item.FullName);
                    objTabs.lstFiles.Add(objFile);
                    objTabs.lstFilesContent.Add(objStream);
                }
                objTabs.readFiles();
                if (!blockForm)
                {
                    IdGridViewResultUpLoad.DataSource = objTabs.lstFiles;
                    IdGridViewResultUpLoad.DataBind();
                }
                MoveFiles(objTabs);
                foreach (StreamReader itemReader in lstbyClose)
                {
                    itemReader.Close();
                }
            }
            catch (Exception ex)
            {
                LogBLL objLogBLL = new LogBLL();
                objLogBLL.InsertErrorLog(ex.Message);
            }
        }
        private void MoveFiles(TAB_s objTabs)
        {
            RegisterFileDAL DAL = new RegisterFileDAL();
            if (!System.IO.Directory.Exists(ConfigurationManager.AppSettings["UrlTabsCorrect"].ToString()))//(@"F:\TABCorrectos"))//(@"C:\TABCorrectos"))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["UrlTabsCorrect"].ToString());//(@"F:\TABCorrectos");//(@"C:\TABCorrectos");
            }
            if (!System.IO.Directory.Exists(ConfigurationManager.AppSettings["UrlTabsInCorrectos"].ToString()))//(@"F:\TABInCorrectos"))//(@"C:\TABInCorrectos"))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["UrlTabsInCorrectos"].ToString());//(@"F:\TABInCorrectos");//(@"C:\TABInCorrectos");
            }
            foreach (StreamReader itemReader in objTabs.lstFilesContent)
            {
                itemReader.Close();
            }
            objTabs.lstFilesContent.Clear();
            foreach (Files item in objTabs.lstFiles)
            {
                String[] names = item.NameFile.Split(new[] { "\\" }, StringSplitOptions.None);
                DAL.InsertUpLoadedFiles(item);
                if (!item.FileCorrect)
                {
                    if (!File.Exists(ConfigurationManager.AppSettings["UrlTabsCorrect"].ToString() + names[names.Length - 1]))//(@"F:\\TABCorrectos\\" + names[names.Length - 1]))//(@"C:\\TABCorrectos\\" + names[names.Length - 1]))
                        File.Move(item.NameFile, ConfigurationManager.AppSettings["UrlTabsCorrect"].ToString() + names[names.Length - 1]);//(item.NameFile, @"F:\\TABCorrectos\\" + names[names.Length - 1]);//(item.NameFile, @"C:\\TABCorrectos\\" + names[names.Length - 1]);
                    else
                        File.Delete(item.NameFile);
                }
                else
                {
                    if (!File.Exists(ConfigurationManager.AppSettings["UrlTabsInCorrectos"].ToString() + names[names.Length - 1]))//(@"F:\\TABInCorrectos\\" + names[names.Length - 1]))//(@"C:\\TABInCorrectos\\" + names[names.Length - 1]))
                        File.Move(item.NameFile, ConfigurationManager.AppSettings["UrlTabsInCorrectos"].ToString() + names[names.Length - 1]);//(item.NameFile, @"F:\\TABInCorrectos\\" + names[names.Length - 1]);//(item.NameFile, @"C:\\TABInCorrectos\\" + names[names.Length - 1]);
                    else
                        File.Delete(item.NameFile);
                }
            }
        }

        protected void testConection_Click(object sender, EventArgs e)
        {
       //     System.Data.SqlClient.SqlConnection conn =
       //new System.Data.SqlClient.SqlConnection();
       //     // TODO: Modify the connection string and include any
       //     // additional required properties for your database.
       //     conn.ConnectionString =
       //      "data source=192.168.1.117\\SQLEXPRESS;" +
       //      "persist security info=True; User ID=ICGAdmin;Password=masterkey;initial catalog=BD1";
       //     try
       //     {
       //         conn.Open();
       //         // Insert code to process data.
       //     }
       //     catch (Exception ex)
       //     {
                
       //     }
       //     finally
       //     {
       //         conn.Close();
       //     }

            //DQ_VentasBLL DAL = new DQ_VentasBLL();
            //DAL.GetSalesDairyQueen();

            FacturasBLL bll = new FacturasBLL();
  
            bll.ReadXMLInvoice(new XmlDocument() );



        }
    }
}