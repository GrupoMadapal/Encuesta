using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IBatisNet.DataMapper;
using System.Globalization;

using Poleo.BLL;

namespace Poleo.Objects
{
    public class TAB_s
    {
        public IList<Files> lstFiles = new List<Files>();
        public IList<StreamReader> lstFilesContent = new List<StreamReader>();

        public void readFiles()
        {
            for (int i = 0; i < lstFiles.Count;i++ )
                
                {
                    Files itemFile = lstFiles[i];
                    StreamReader readerFile = lstFilesContent[i];
                    switch (itemFile.TypeFile.ToUpper())
                    {
                        case "ATR":
                            TransactionsExtract(itemFile, readerFile);
                            break;
                        case "CKY":
                            CorpVersionKeysExtract(itemFile, readerFile);
                            break;
                        case "DYS":
                            DailySummaryDumpExtract(itemFile, readerFile);
                            break;
                        case "INV":
                            DailyInventoryExtract(itemFile, readerFile);
                            break;
                        case "IPR":
                            InvPurchasesExtract(itemFile, readerFile);
                            break;
                        case "ORD":
                            OrdersExtract(itemFile, readerFile);
                            break;
                        case "PRS":
                            ProductsExtract(itemFile,readerFile);
                            break;
                        case "OC2":
                            OrderCuponsDump(itemFile, readerFile);
                            break;
                        case "IPD":
                            InvPurchasesDetail(itemFile, readerFile);
                            break;
                        case "ODT":
                           OrdersDetailExtract(itemFile, readerFile);
                            break;
                        case "OR2":
                            OrdersDumpBLL objOrdersDumpBLL = new OrdersDumpBLL();
                            objOrdersDumpBLL.ordersDump(itemFile, readerFile);
                            break;
                    }
                }
        }
        public void TransactionsExtract(Files objFile, StreamReader objStream)
        {
            //StreamReader objStream = new StreamReader(objFile.NameFile);
            //ISqlMapper mapper= Mapper.Instance();
            //mapper.QueryForObject();
            string line;
            int numLine = 1;
            int length = 0;
            
            DateTime? defaulTDateTime = null;
            // Read and display lines from the file until the end of 
            // the file is reached.
            while ((line = objStream.ReadLine()) != null)
            {
              if(numLine==1)//headers
              {
                  length=line.Split('\t').Length;
              }
              else
              {
                  String[] arrayInfo = line.Split('\t');
                  if (arrayInfo.Length == length)
                  {
                      if(arrayInfo[0]=="ATR")
                      {
                          objFile.TotalRegister++;
                          Transactions objTransaction = new Transactions();
                          try
                          {
                              objTransaction.RecordType = arrayInfo[0];
                              objTransaction.DatabaseVersion = arrayInfo[1];
                              objTransaction.Location_Code = arrayInfo[2];
                              objTransaction.System_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : defaulTDateTime;
                              objTransaction.Account_Code = arrayInfo[4];
                              objTransaction.Account_Description = arrayInfo[5];
                              objTransaction.Trans_Sequence = !String.IsNullOrEmpty(arrayInfo[6]) ? int.Parse(arrayInfo[6]) : 0;
                              objTransaction.Trans_Description = arrayInfo[7];
                              objTransaction.Invoice_Number = arrayInfo[8];
                              objTransaction.Trans_Amount = !String.IsNullOrEmpty(arrayInfo[9]) ? decimal.Parse(arrayInfo[9]) : 0;
                              objTransaction.Debit_Credit_Code = !String.IsNullOrEmpty(arrayInfo[10]) ? arrayInfo[10][0] : ' ';
                              objTransaction.Edit_DateTime = !String.IsNullOrEmpty(arrayInfo[11]) ? DateTime.Parse(arrayInfo[11]) : defaulTDateTime;
                              objTransaction.Edit_User = arrayInfo[12];
                              objTransaction.Comments = arrayInfo[13];
                              objTransaction.Deposit_DateTime = !String.IsNullOrEmpty(arrayInfo[14]) ? DateTime.Parse(arrayInfo[14]) : defaulTDateTime;
                              objTransaction.Bank_Number = arrayInfo[15];
                              objTransaction.Bank_name = arrayInfo[16];
                              objTransaction.Deposit_Slip_Number = arrayInfo[17];
                              objTransaction.Deposit_bag_number = arrayInfo[18];
                              objTransaction.Deposit_Employee_Code1 = arrayInfo[19];
                              objTransaction.Deposit_Employee_Code2 = arrayInfo[20];
                              //objTransaction
                              objTransaction.IsDeposit = !String.IsNullOrEmpty(arrayInfo[22]) ? int.Parse(arrayInfo[22]) : 0;
                              objTransaction.Deposit_Cast_amount = !String.IsNullOrEmpty(arrayInfo[23]) ? decimal.Parse(arrayInfo[23]) : 0;
                              objTransaction.Deposit_Check_Amount = !String.IsNullOrEmpty(arrayInfo[24]) ? decimal.Parse(arrayInfo[24]) : 0;
                              objTransaction.Deposit_Check_Count = !String.IsNullOrEmpty(arrayInfo[25]) ? int.Parse(arrayInfo[25]) : 0;
                              objTransaction.Deposit_Govt_ID1 = arrayInfo[26];
                              objTransaction.DepositName1 = arrayInfo[27];
                              objTransaction.Deposit_Govt_ID2 = arrayInfo[28];
                              objTransaction.DepositName2 = arrayInfo[29];

                              RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                              RegisterFileDAL DAL = new RegisterFileDAL();
                              DAL.UpDateRegisterFileATR(objRegisterFile);                        


                              InsertTransactions(objTransaction);
                              objFile.TotalCorrect++;
                          }
                          catch(Exception ex)
                          {
                              objFile.TotalError++;
                              //throw ex;
                          }                     
                      }
                  }

              }
              numLine++;
            }
        }

        public void ProductsExtract(Files objFile,StreamReader objStream)
        {
            
            string line;
            int numLine = 1;
            int length = 0;
            // Read and display lines from the file until the end of 
            // the file is reached.
            DateTime? defaulTDateTime = null;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "PRS")
                        {
                            ProductsExtracts objProduct = new ProductsExtracts();
                            try {
                                    objFile.TotalRegister++;
                                    objProduct.RecordType = arrayInfo[0];
                                    objProduct.DatabaseVersion = arrayInfo[1];
                                    objProduct.Location_Code = arrayInfo[2];
                                    objProduct.BeginDate = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                    objProduct.EndDate = !String.IsNullOrEmpty(arrayInfo[4]) ? DateTime.Parse(arrayInfo[4]) : DateTime.MinValue;
                                    objProduct.Product_Code = arrayInfo[5];
                                    objProduct.Product_Description = arrayInfo[6];
                                    objProduct.Product_Category_Code = arrayInfo[7];
                                    objProduct.Product_Menu_Code = arrayInfo[8];
                                    objProduct.Product_Size_Code = arrayInfo[9];
                                    objProduct.Product_Crust_Code = arrayInfo[10];
                                    objProduct.Quantity =!String.IsNullOrEmpty( arrayInfo[11])?int.Parse(arrayInfo[11]):0;
                                    objProduct.Sales = !String.IsNullOrEmpty(arrayInfo[12]) ? decimal.Parse(arrayInfo[12]) : 0;
                                    objProduct.IFC_Quantity = !String.IsNullOrEmpty(arrayInfo[13]) ? int.Parse(arrayInfo[13]) : 0;
                                    objProduct.IFC = !String.IsNullOrEmpty(arrayInfo[14]) ? decimal.Parse(arrayInfo[14]) : 0;
                                    objProduct.Order_Count = !String.IsNullOrEmpty(arrayInfo[15]) ? int.Parse(arrayInfo[15]) : 0;
                                    objProduct.DatabaseVersion = arrayInfo[16];
                                    RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                    RegisterFileDAL DAL = new RegisterFileDAL();
                                    DAL.UpDateRegisterFilePRS(objRegisterFile);
                                    InsertProducts(objProduct);                                    
                                    objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }
                        }

                    }
                }
                numLine++;
            }
        }
        public void OrdersExtract(Files objFile, StreamReader objStream)
        {
            
            string line;
            int numLine = 1;
            int length = 0;
            DateTime? defaulTDateTime = null;
            // Read and display lines from the file until the end of 
            // the file is reached.
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "ORD")
                        {

                            OrdersExtracts objOrder = new OrdersExtracts();
                            try{
                                objFile.TotalRegister++;
                            objOrder.RecordType = arrayInfo[0];
                            objOrder.DatabaseVersion = arrayInfo[1];
                            objOrder.Store_No = arrayInfo[2];
                            objOrder.Ord_Dt = !String.IsNullOrEmpty(arrayInfo[3])?DateTime.Parse(arrayInfo[3]):DateTime.MinValue;
                            objOrder.Ord_No = !String.IsNullOrEmpty(arrayInfo[4]) ? int.Parse(arrayInfo[4]) : 0;
                            objOrder.Late_Order_Fg = !String.IsNullOrEmpty(arrayInfo[5]) ? int.Parse(arrayInfo[5]) : 0;
                            objOrder.Corrected_Ord_Fg = !String.IsNullOrEmpty(arrayInfo[6])?arrayInfo[6][0]:' ';
                            objOrder.Lrg_Adj_Fg = !String.IsNullOrEmpty(arrayInfo[7]) ? arrayInfo[7][0] : ' ';
                            objOrder.Ord_Type_Cd = arrayInfo[8];
                            objOrder.Ord_Status_Cd = arrayInfo[9];
                            objOrder.Ret_Reason_Ds = arrayInfo[10];
                            objOrder.Late_Disp_Ds = arrayInfo[11];
                            objOrder.Phone = arrayInfo[12];
                            objOrder.Ord_Hms = !String.IsNullOrEmpty(arrayInfo[13]) ? DateTime.Parse(arrayInfo[13]) : defaulTDateTime;
                            objOrder.Disp_Hms = !String.IsNullOrEmpty(arrayInfo[14]) ? DateTime.Parse(arrayInfo[14]) : defaulTDateTime;
                            objOrder.Hold_Tm = !String.IsNullOrEmpty(arrayInfo[15]) ? int.Parse(arrayInfo[15]) : 0;
                            objOrder.Take_Tm = !String.IsNullOrEmpty(arrayInfo[16]) ? int.Parse(arrayInfo[16]) : 0;
                            objOrder.Leg_Tm = !String.IsNullOrEmpty(arrayInfo[17]) ? int.Parse(arrayInfo[17]) : 0;
                            objOrder.Delv_Tm = !String.IsNullOrEmpty(arrayInfo[18]) ? int.Parse(arrayInfo[18]) : 0;
                            objOrder.Min_Exp_Tm = !String.IsNullOrEmpty(arrayInfo[19]) ? int.Parse(arrayInfo[19]) : 0;
                            objOrder.Max_Exp_Tm = !String.IsNullOrEmpty(arrayInfo[20]) ? int.Parse(arrayInfo[20]) : 0;
                            objOrder.Stop_Sq = !String.IsNullOrEmpty(arrayInfo[21]) ? int.Parse(arrayInfo[21]) : 0;
                            objOrder.Stop_Ct = !String.IsNullOrEmpty(arrayInfo[22]) ? int.Parse(arrayInfo[22]) : 0;
                            objOrder.Menu_Amt = !String.IsNullOrEmpty(arrayInfo[23]) ? Decimal.Parse(arrayInfo[23]) : 0;
                            objOrder.Disc_Amt = !String.IsNullOrEmpty(arrayInfo[24]) ? Decimal.Parse(arrayInfo[24]) : 0;
                            objOrder.F9_Amt = !String.IsNullOrEmpty(arrayInfo[25]) ? Decimal.Parse(arrayInfo[25]) : 0;
                            objOrder.F9_Reason = arrayInfo[26];
                            objOrder.Surchg_Amt = !String.IsNullOrEmpty(arrayInfo[27]) ? Decimal.Parse(arrayInfo[27]) : 0;
                            objOrder.Net_Amt = !String.IsNullOrEmpty(arrayInfo[28]) ? Decimal.Parse(arrayInfo[28]) : 0;
                            objOrder.Tax_Amt = !String.IsNullOrEmpty(arrayInfo[29]) ? Decimal.Parse(arrayInfo[29]) : 0;
                            objOrder.Bottle_Amt = !String.IsNullOrEmpty(arrayInfo[30]) ? Decimal.Parse(arrayInfo[30]) : 0;
                            objOrder.Cust_Amt = !String.IsNullOrEmpty(arrayInfo[31]) ? Decimal.Parse(arrayInfo[31]) : 0;
                            objOrder.High_Net_Amt = !String.IsNullOrEmpty(arrayInfo[32]) ? Decimal.Parse(arrayInfo[32]) : 0;
                            objOrder.Payment_Type_Cd = arrayInfo[33];
                            objOrder.Credit_Card_Descr = arrayInfo[34];
                            objOrder.Ideal_Food_Cst = !String.IsNullOrEmpty(arrayInfo[35]) ? Decimal.Parse(arrayInfo[35]) : 0;
                            objOrder.First_Cpn_Cd = arrayInfo[36];
                            objOrder.Cpn_Descr = arrayInfo[37];
                            objOrder.Reprint_Ct = !String.IsNullOrEmpty(arrayInfo[38]) ? int.Parse(arrayInfo[38]) : 0;
                            objOrder.Reprint_Ssn = arrayInfo[39];
                            objOrder.Reprint_Hms = !String.IsNullOrEmpty(arrayInfo[40]) ? DateTime.Parse(arrayInfo[40]) : defaulTDateTime;
                            objOrder.Edit_Ct=!String.IsNullOrEmpty(arrayInfo[41]) ? int.Parse(arrayInfo[41]) : 0;
                            objOrder.Edit_Ssn = arrayInfo[42];
                            objOrder.Edit_Hms = !String.IsNullOrEmpty(arrayInfo[43]) ? DateTime.Parse(arrayInfo[43]) : defaulTDateTime;
                            objOrder.Cycle_Id_Cd = !String.IsNullOrEmpty(arrayInfo[44]) ? arrayInfo[44][0] : ' ';
                            objOrder.Prize_Collect_Fg = !String.IsNullOrEmpty(arrayInfo[45]) ? arrayInfo[45][0] : ' ';
                            objOrder.Drv_Ssn = arrayInfo[46];
                            objOrder.Csr_Ssn = arrayInfo[47];
                            objOrder.Phone2 = arrayInfo[48];
                            objOrder.Old_Phone = arrayInfo[49];
                            objOrder.Phone_Conv_Dt = !String.IsNullOrEmpty(arrayInfo[50]) ? DateTime.Parse(arrayInfo[50]) : defaulTDateTime;
                            objOrder.Cust_Store_No = arrayInfo[51];
                            objOrder.Station_No = arrayInfo[52];
                            objOrder.Tip_Amt = !String.IsNullOrEmpty(arrayInfo[53]) ? Decimal.Parse(arrayInfo[53]) : 0;
                            objOrder.Special_Credit_Cd = !String.IsNullOrEmpty(arrayInfo[54]) ? arrayInfo[54][0] : ' ';
                            objOrder.Email_Addr = arrayInfo[55];
                            objOrder.Temp_Field_1 = arrayInfo[56];
                            objOrder.Temp_Field_2 = arrayInfo[57];
                            objOrder.Prc_Ovr_Hdr_Amt = !String.IsNullOrEmpty(arrayInfo[58]) ? Decimal.Parse(arrayInfo[58]) : 0;
                            objOrder.DatabaseVersion = arrayInfo[59];
                            objOrder.Check_Chg_Amt = !String.IsNullOrEmpty(arrayInfo[60]) ? Decimal.Parse(arrayInfo[60]) : 0;
                            objOrder.Load_Time_Secs = !String.IsNullOrEmpty(arrayInfo[61]) ? int.Parse(arrayInfo[61]) : 0;
                            objOrder.Order_Source = arrayInfo[62];
                            objOrder.Organization_Url = arrayInfo[63];
                            objOrder.Ord_Src_Method = arrayInfo[64];
                            objOrder.Pulse_Order_Status_Code = !String.IsNullOrEmpty(arrayInfo[65]) ? int.Parse(arrayInfo[65]) : 0;
                            objOrder.Currency_Code = arrayInfo[66];
                            objOrder.OrderRoyaltySales = !String.IsNullOrEmpty(arrayInfo[67]) ? Decimal.Parse(arrayInfo[67]) : 0;
                            objOrder.OutboundMileage=!String.IsNullOrEmpty(arrayInfo[68]) ? float.Parse(arrayInfo[68]) : 0;
                            objOrder.ReturnMileage = !String.IsNullOrEmpty(arrayInfo[69]) ? float.Parse(arrayInfo[69]) : 0;
                            objOrder.MileageSource = arrayInfo[70];
                            objOrder.VehicleCode = arrayInfo[71];
                            objOrder.CalculatedDeliveryTime = !String.IsNullOrEmpty(arrayInfo[72]) ? DateTime.Parse(arrayInfo[72]) : defaulTDateTime;
                            objOrder.CalculatedDeliveryTimeSecs = !String.IsNullOrEmpty(arrayInfo[73]) ? int.Parse(arrayInfo[73]) : 0;
                            objOrder.OutboundDriveTimeSecs = !String.IsNullOrEmpty(arrayInfo[74]) ? int.Parse(arrayInfo[74]) : 0;
                            objOrder.ReturnDriveTimeSecs=  !String.IsNullOrEmpty(arrayInfo[75]) ? int.Parse(arrayInfo[75]) : 0;
                            objOrder.DriveTimeSource = arrayInfo[76];
                            objOrder.CalculatedDeliveryTime = !String.IsNullOrEmpty(arrayInfo[77]) ? DateTime.Parse(arrayInfo[77]) : defaulTDateTime;                            
                            RegisterFile objRegisterFile= this.CreateRegisterFile(objFile);
                            RegisterFileDAL DAL = new RegisterFileDAL();
                            DAL.UpDateRegisterFileORD(objRegisterFile);
                            InsertOrdersExtracts(objOrder);
                            objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }
                    
                        }

                    }
                }
                numLine++;
            }
        }
        public void InvPurchasesExtract(Files objFile, StreamReader objStream)
        {
           
            string line;
            int numLine = 1;
            int length = 0;
            DateTime? defaulTDateTime = null;
            // Read and display lines from the file until the end of 
            // the file is reached.
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "IPR")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                InventoryPurchasesExtracts objInvPurchase = new InventoryPurchasesExtracts();
                                objInvPurchase.RecordType = arrayInfo[0];
                                objInvPurchase.Location_Code = arrayInfo[2];
                                objInvPurchase.System_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objInvPurchase.PurchaseID = !String.IsNullOrEmpty(arrayInfo[4]) ? int.Parse(arrayInfo[4]) : 0;
                                objInvPurchase.VendorName = arrayInfo[5];
                                objInvPurchase.VendorCode = arrayInfo[6];
                                objInvPurchase.InvoiceNumber = arrayInfo[7];
                                objInvPurchase.Type = arrayInfo[8];
                                objInvPurchase.Amount = !String.IsNullOrEmpty(arrayInfo[9]) ? Decimal.Parse(arrayInfo[9]) : 0;
                                objInvPurchase.DeliveryCharge = !String.IsNullOrEmpty(arrayInfo[10]) ? Decimal.Parse(arrayInfo[10]) : 0;
                                objInvPurchase.Tax = !String.IsNullOrEmpty(arrayInfo[11]) ? Decimal.Parse(arrayInfo[11]) : 0;
                                objInvPurchase.DatabaseVersion = arrayInfo[12];                                
                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileIPR(objRegisterFile);
                                InsertInventoryPurchases(objInvPurchase);
                                objFile.TotalCorrect++;
                            }
                            catch(Exception ex)
                            {
                                objFile.TotalError++;
                               // throw ex;
                            }
                        }

                    }

                }
                numLine++;
            }
        }
        public void DailyInventoryExtract(Files objFile,StreamReader objStream)
        {
             
            string line;
            int numLine = 1;
            int length = 0;
            // Read and display lines from the file until the end of 
            // the file is reached.
            DateTime? defaulTDateTime = null;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "INV")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                DailyInventoryExtracts objDailyInv = new DailyInventoryExtracts();
                                objDailyInv.RecordType = arrayInfo[0];
                                objDailyInv.Location_Code = arrayInfo[2];
                                objDailyInv.System_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objDailyInv.Inventory_Code = arrayInfo[4];
                                objDailyInv.Description = arrayInfo[5];
                                objDailyInv.Inventory_Type_Code = arrayInfo[6];
                                objDailyInv.Count_Unit = arrayInfo[7];
                                objDailyInv.Count_Unit_Cost = !String.IsNullOrEmpty(arrayInfo[8]) ? Decimal.Parse(arrayInfo[8]) : 0;
                                objDailyInv.Beginning_Qty = !String.IsNullOrEmpty(arrayInfo[9]) ? Decimal.Parse(arrayInfo[9]) : 0;
                                objDailyInv.Delivered_Qty = !String.IsNullOrEmpty(arrayInfo[10]) ? Decimal.Parse(arrayInfo[10]) : 0;
                                objDailyInv.Starting_Qty = !String.IsNullOrEmpty(arrayInfo[11]) ? Decimal.Parse(arrayInfo[11]) : 0;
                                objDailyInv.Ending_Qty = !String.IsNullOrEmpty(arrayInfo[12]) ? Decimal.Parse(arrayInfo[12]) : 0;
                                objDailyInv.Actual_Usage = !String.IsNullOrEmpty(arrayInfo[13]) ? Decimal.Parse(arrayInfo[13]) : 0;
                                objDailyInv.Ideal_Usage = !String.IsNullOrEmpty(arrayInfo[14]) ? Decimal.Parse(arrayInfo[14]) : 0;
                                objDailyInv.Actual_vs_Ideal_Usage = !String.IsNullOrEmpty(arrayInfo[15]) ? Decimal.Parse(arrayInfo[15]) : 0;
                                objDailyInv.Cost_Actual_Used = !String.IsNullOrEmpty(arrayInfo[16]) ? Decimal.Parse(arrayInfo[16]) : 0;
                                objDailyInv.Cost_Ideal_Used = !String.IsNullOrEmpty(arrayInfo[17]) ? Decimal.Parse(arrayInfo[17]) : 0;
                                objDailyInv.Cost_Actual_vs_Ideal = !String.IsNullOrEmpty(arrayInfo[18]) ? Decimal.Parse(arrayInfo[18]) : 0;
                                objDailyInv.Order_Unit = arrayInfo[19];
                                objDailyInv.Order_Unit_Cost = !String.IsNullOrEmpty(arrayInfo[20]) ? Decimal.Parse(arrayInfo[20]) : 0;
                                objDailyInv.Count_Per_Order = !String.IsNullOrEmpty(arrayInfo[21]) ? Decimal.Parse(arrayInfo[21]) : 0;
                                objDailyInv.Portion_Unit = arrayInfo[22];
                                objDailyInv.Portion_Per_Count = !String.IsNullOrEmpty(arrayInfo[23]) ? Decimal.Parse(arrayInfo[23]) : 0;
                                objDailyInv.Vendor_Item_Code = arrayInfo[24];
                                objDailyInv.Vendor_Code = arrayInfo[25];
                                objDailyInv.Count_Type_Code = !String.IsNullOrEmpty(arrayInfo[26]) ? int.Parse(arrayInfo[26]) : 0;
                                objDailyInv.Food = arrayInfo[27];
                                objDailyInv.DatabaseVersion = arrayInfo[28];
                               
                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                               
                                DAL.UpDateRegisterFileINV(objRegisterFile);
                                InsertDailyInventory(objDailyInv);
                                objFile.TotalCorrect++;
                            }
                            catch(Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }

                        }

                    }

                }
                numLine++;
            }
        }
        public void DailySummaryDumpExtract(Files objFile,StreamReader objStream)
        {
            
            string line;
            int numLine = 1;
            int length = 0;
            // Read and display lines from the file until the end of 
            // the file is reached.
            DateTime? defaulTDateTime = null;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "DYS")
                        {
                            DailySummaryDump objSummary = new DailySummaryDump();
                            try
                            {
                                objFile.TotalRegister++;
                                objSummary.RecordType = arrayInfo[0];
                                objSummary.Location_Code = arrayInfo[2];
                                objSummary.System_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objSummary.Master_Total = !String.IsNullOrEmpty(arrayInfo[4]) ? Decimal.Parse(arrayInfo[4]) : 0;
                                objSummary.Void_Orders = !String.IsNullOrEmpty(arrayInfo[5]) ? Decimal.Parse(arrayInfo[5]) : 0;
                                objSummary.Bad_Orders = !String.IsNullOrEmpty(arrayInfo[6]) ? Decimal.Parse(arrayInfo[6]) : 0;
                                objSummary.Total_Sales = !String.IsNullOrEmpty(arrayInfo[7]) ? Decimal.Parse(arrayInfo[7]) : 0;
                                objSummary.Sales_Tax = !String.IsNullOrEmpty(arrayInfo[8]) ? Decimal.Parse(arrayInfo[8]) : 0;
                                objSummary.Bottle_Deposits = !String.IsNullOrEmpty(arrayInfo[9]) ? Decimal.Parse(arrayInfo[9]) : 0;
                                objSummary.Net_Sales = !String.IsNullOrEmpty(arrayInfo[10]) ? Decimal.Parse(arrayInfo[10]) : 0;
                                objSummary.Coupons = !String.IsNullOrEmpty(arrayInfo[11]) ? Decimal.Parse(arrayInfo[11]) : 0;
                                objSummary.Non_Royalty_Sales = !String.IsNullOrEmpty(arrayInfo[12]) ? Decimal.Parse(arrayInfo[12]) : 0;
                                objSummary.Royalty_Sales = !String.IsNullOrEmpty(arrayInfo[13]) ? Decimal.Parse(arrayInfo[13]) : 0;
                                objSummary.Delivery_Company_Car = !String.IsNullOrEmpty(arrayInfo[14]) ? Decimal.Parse(arrayInfo[14]) : 0;
                                objSummary.Delivery_Company_Car_Count = !String.IsNullOrEmpty(arrayInfo[15]) ? int.Parse(arrayInfo[15]) : 0;
                                objSummary.Delivery_Personal_Car = !String.IsNullOrEmpty(arrayInfo[16]) ? Decimal.Parse(arrayInfo[16]) : 0;
                                objSummary.Delivery_Personal_Car_Count = !String.IsNullOrEmpty(arrayInfo[17]) ? int.Parse(arrayInfo[17]) : 0;
                                objSummary.Carry_Out = !String.IsNullOrEmpty(arrayInfo[18]) ? Decimal.Parse(arrayInfo[18]) : 0;
                                objSummary.Carry_Out_Count = !String.IsNullOrEmpty(arrayInfo[19]) ? int.Parse(arrayInfo[19]) : 0;
                                objSummary.Pick_Up = !String.IsNullOrEmpty(arrayInfo[20]) ? Decimal.Parse(arrayInfo[20]) : 0;
                                objSummary.Pick_Up_Count = !String.IsNullOrEmpty(arrayInfo[21]) ? int.Parse(arrayInfo[21]) : 0;
                                objSummary.Dine_In = !String.IsNullOrEmpty(arrayInfo[22]) ? Decimal.Parse(arrayInfo[22]) : 0;
                                objSummary.Dine_In_Count = !String.IsNullOrEmpty(arrayInfo[23]) ? int.Parse(arrayInfo[23]) : 0;
                                objSummary.Food = !String.IsNullOrEmpty(arrayInfo[24]) ? Decimal.Parse(arrayInfo[24]) : 0;
                                objSummary.Labor = !String.IsNullOrEmpty(arrayInfo[25]) ? Decimal.Parse(arrayInfo[25]) : 0;
                                objSummary.Mileage = !String.IsNullOrEmpty(arrayInfo[26]) ? Decimal.Parse(arrayInfo[26]) : 0;
                                objSummary.Food_Bought = !String.IsNullOrEmpty(arrayInfo[27]) ? Decimal.Parse(arrayInfo[27]) : 0;
                                objSummary.Raise_Till = !String.IsNullOrEmpty(arrayInfo[28]) ? Decimal.Parse(arrayInfo[28]) : 0;
                                objSummary.Mileage_All = !String.IsNullOrEmpty(arrayInfo[29]) ? Decimal.Parse(arrayInfo[29]) : 0;
                                objSummary.Contract_Labor = !String.IsNullOrEmpty(arrayInfo[30]) ? Decimal.Parse(arrayInfo[30]) : 0;
                                objSummary.Total_CPO = !String.IsNullOrEmpty(arrayInfo[31]) ? Decimal.Parse(arrayInfo[31]) : 0;
                                objSummary.Food_Sold = !String.IsNullOrEmpty(arrayInfo[32]) ? Decimal.Parse(arrayInfo[32]) : 0;
                                objSummary.Lower_Till = !String.IsNullOrEmpty(arrayInfo[33]) ? Decimal.Parse(arrayInfo[33]) : 0;
                                objSummary.Total_MROTS = !String.IsNullOrEmpty(arrayInfo[34]) ? Decimal.Parse(arrayInfo[34]) : 0;
                                objSummary.Bank_Deposits = !String.IsNullOrEmpty(arrayInfo[35]) ? Decimal.Parse(arrayInfo[35]) : 0;
                                objSummary.Ending_Till = !String.IsNullOrEmpty(arrayInfo[36]) ? Decimal.Parse(arrayInfo[36]) : 0;
                                objSummary.Manager = arrayInfo[37];
                                objSummary.Total_Orders = !String.IsNullOrEmpty(arrayInfo[38]) ? int.Parse(arrayInfo[38]) : 0;
                                objSummary.Min_Order_Number = !String.IsNullOrEmpty(arrayInfo[39]) ? int.Parse(arrayInfo[39]) : 0;
                                objSummary.Max_Order_Number = !String.IsNullOrEmpty(arrayInfo[40]) ? int.Parse(arrayInfo[40]) : 0;
                                objSummary.Orders_In_Range = !String.IsNullOrEmpty(arrayInfo[41]) ? int.Parse(arrayInfo[41]) : 0;
                                objSummary.Min_Price_Per_Order = !String.IsNullOrEmpty(arrayInfo[42]) ? Decimal.Parse(arrayInfo[42]) : 0;
                                objSummary.Max_Price_Per_Order = !String.IsNullOrEmpty(arrayInfo[43]) ? Decimal.Parse(arrayInfo[43]) : 0;
                                objSummary.Average_Price = !String.IsNullOrEmpty(arrayInfo[44]) ? Decimal.Parse(arrayInfo[44]) : 0;
                                objSummary.Average_Order_Time = !String.IsNullOrEmpty(arrayInfo[45]) ? float.Parse(arrayInfo[45]) : 0;
                                objSummary.Average_Load_Time = !String.IsNullOrEmpty(arrayInfo[46]) ? float.Parse(arrayInfo[46]) : 0;
                                objSummary.Average_OTD_Time = !String.IsNullOrEmpty(arrayInfo[47]) ? float.Parse(arrayInfo[47]) : 0;
                                objSummary.Average_Delivery_Time = !String.IsNullOrEmpty(arrayInfo[48]) ? float.Parse(arrayInfo[48]) : 0;
                                objSummary.Inside_Labor = !String.IsNullOrEmpty(arrayInfo[49]) ? Decimal.Parse(arrayInfo[49]) : 0;
                                objSummary.Outside_Labor = !String.IsNullOrEmpty(arrayInfo[50]) ? Decimal.Parse(arrayInfo[50]) : 0;
                                objSummary.Hourly_Labor = !String.IsNullOrEmpty(arrayInfo[51]) ? Decimal.Parse(arrayInfo[51]) : 0;
                                objSummary.Salary_Labor = !String.IsNullOrEmpty(arrayInfo[52]) ? Decimal.Parse(arrayInfo[52]) : 0;
                                objSummary.EOD_Comments = arrayInfo[53];
                                objSummary.IFC = !String.IsNullOrEmpty(arrayInfo[54]) ? Decimal.Parse(arrayInfo[54]) : 0;
                                objSummary.Non_Taxable_Sales = !String.IsNullOrEmpty(arrayInfo[55]) ? Decimal.Parse(arrayInfo[55]) : 0;
                                objSummary.Less_Than_20_OTD = !String.IsNullOrEmpty(arrayInfo[56]) ? int.Parse(arrayInfo[56]) : 0;
                                objSummary.Average_Orders_Per_Dispatch = !String.IsNullOrEmpty(arrayInfo[57]) ? float.Parse(arrayInfo[57]) : 0.0f;
                                objSummary.Timed_Delivery_Company_Car = !String.IsNullOrEmpty(arrayInfo[58]) ? Decimal.Parse(arrayInfo[58]) : 0;
                                objSummary.Timed_Delivery_Company_Car_Count = !String.IsNullOrEmpty(arrayInfo[59]) ? int.Parse(arrayInfo[59]) : 0;
                                objSummary.Timed_Delivery_Personal_Car = !String.IsNullOrEmpty(arrayInfo[60]) ? Decimal.Parse(arrayInfo[60]) : 0;
                                objSummary.Timed_Delivery_Personal_Car_Count = !String.IsNullOrEmpty(arrayInfo[61]) ? int.Parse(arrayInfo[61]) : 0;
                                objSummary.Timed_Carry_Out = !String.IsNullOrEmpty(arrayInfo[62]) ? Decimal.Parse(arrayInfo[62]) : 0;
                                objSummary.Timed_Carry_Out_Count = !String.IsNullOrEmpty(arrayInfo[63]) ? int.Parse(arrayInfo[63]) : 0;
                                objSummary.Timed_Pick_Up = !String.IsNullOrEmpty(arrayInfo[64]) ? Decimal.Parse(arrayInfo[64]) : 0;
                                objSummary.Timed_Pick_Up_Count = !String.IsNullOrEmpty(arrayInfo[65]) ? int.Parse(arrayInfo[65]) : 0;
                                objSummary.Timed_Dine_In = !String.IsNullOrEmpty(arrayInfo[66]) ? Decimal.Parse(arrayInfo[66]) : 0;
                                objSummary.Timed_Dine_In_Count = !String.IsNullOrEmpty(arrayInfo[67]) ? int.Parse(arrayInfo[67]) : 0;
                                objSummary.Added_By = arrayInfo[68];
                                objSummary.Added = !String.IsNullOrEmpty(arrayInfo[69]) ? DateTime.Parse(arrayInfo[69]) : DateTime.MinValue;
                                objSummary.PIGOrders = !String.IsNullOrEmpty(arrayInfo[70]) ? int.Parse(arrayInfo[70]) : 0;
                                objSummary.PIGOrderAmount = !String.IsNullOrEmpty(arrayInfo[71]) ? Decimal.Parse(arrayInfo[71]) : 0;
                                objSummary.MissingBoxes = !String.IsNullOrEmpty(arrayInfo[72]) ? int.Parse(arrayInfo[72]) : 0;
                                objSummary.MissingBoxAmount = !String.IsNullOrEmpty(arrayInfo[73]) ? Decimal.Parse(arrayInfo[73]) : 0;
                                objSummary.NewCustomers = !String.IsNullOrEmpty(arrayInfo[74]) ? int.Parse(arrayInfo[74]) : 0;
                                objSummary.AllCustomers = !String.IsNullOrEmpty(arrayInfo[75]) ? int.Parse(arrayInfo[75]) : 0;
                                objSummary.CreditCardOrders_CPO = !String.IsNullOrEmpty(arrayInfo[76]) ? Decimal.Parse(arrayInfo[76]) : 0;
                                objSummary.TROrders_CPO = !String.IsNullOrEmpty(arrayInfo[77]) ? Decimal.Parse(arrayInfo[77]) : 0;
                                objSummary.GCOrders_CPO = !String.IsNullOrEmpty(arrayInfo[78]) ? Decimal.Parse(arrayInfo[78]) : 0;
                                objSummary.CreditCardOrders_MROTS = !String.IsNullOrEmpty(arrayInfo[79]) ? Decimal.Parse(arrayInfo[79]) : 0;
                                objSummary.TROrders_MROTS = !String.IsNullOrEmpty(arrayInfo[80]) ? Decimal.Parse(arrayInfo[80]) : 0;
                                objSummary.GCOrders_MROTS = !String.IsNullOrEmpty(arrayInfo[81]) ? Decimal.Parse(arrayInfo[81]) : 0;
                                objSummary.ElectronicOrders = !String.IsNullOrEmpty(arrayInfo[82]) ? int.Parse(arrayInfo[82]) : 0;
                                objSummary.ElectronicOrderAmount = !String.IsNullOrEmpty(arrayInfo[83]) ? Decimal.Parse(arrayInfo[83]) : 0;
                                objSummary.GiftCardPurchases = !String.IsNullOrEmpty(arrayInfo[84]) ? Decimal.Parse(arrayInfo[84]) : 0;
                                objSummary.GCPurchasedWithCC = !String.IsNullOrEmpty(arrayInfo[85]) ? Decimal.Parse(arrayInfo[85]) : 0;
                                objSummary.PIGPercent = !String.IsNullOrEmpty(arrayInfo[87]) ? float.Parse(arrayInfo[87]) : 0;
                                objSummary.WalkInOrders = !String.IsNullOrEmpty(arrayInfo[88]) ? int.Parse(arrayInfo[88]) : 0;
                                objSummary.WalkInOrderAmount = !String.IsNullOrEmpty(arrayInfo[89]) ? Decimal.Parse(arrayInfo[89]) : 0;
                                objSummary.PhoneInOrders = !String.IsNullOrEmpty(arrayInfo[90]) ? int.Parse(arrayInfo[90]) : 0;
                                objSummary.PhoneInOrderAmount = !String.IsNullOrEmpty(arrayInfo[91]) ? Decimal.Parse(arrayInfo[91]) : 0;
                                
                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileDYS(objRegisterFile);
                                InsertDailySummaryDump(objSummary);
                                objFile.TotalCorrect++;
                            }catch (Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }

                            
                        }

                    }

                }
                numLine++;
            }
        }
        public void CorpVersionKeysExtract(Files objFile, StreamReader objStream)
        {
           
            string line;
            int numLine = 1;
            int length = 0;
            // Read and display lines from the file until the end of 
            // the file is reached.
            DateTime? defaulTDateTime = null;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "KEY")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                KeysExtractsCorpVersion objKey = new KeysExtractsCorpVersion();
                                objKey.RecordType = arrayInfo[0];
                                objKey.Location_Code = arrayInfo[2];
                                objKey.BeginDate = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objKey.EndDate = !String.IsNullOrEmpty(arrayInfo[4]) ? DateTime.Parse(arrayInfo[4]) : DateTime.MinValue;
                                objKey.Master_Order_Count = !String.IsNullOrEmpty(arrayInfo[5]) ? int.Parse(arrayInfo[5]) : 0;
                                objKey.Master_Sales = !String.IsNullOrEmpty(arrayInfo[6]) ? decimal.Parse(arrayInfo[6]) : 0;
                                objKey.Void_Order_Count = !String.IsNullOrEmpty(arrayInfo[7]) ? int.Parse(arrayInfo[7]) : 0;
                                objKey.Void_Sales = !String.IsNullOrEmpty(arrayInfo[8]) ? decimal.Parse(arrayInfo[8]) : 0;
                                objKey.Bad_Order_Count = !String.IsNullOrEmpty(arrayInfo[9]) ? int.Parse(arrayInfo[9]) : 0;
                                objKey.Bad_Sales = !String.IsNullOrEmpty(arrayInfo[10]) ? Decimal.Parse(arrayInfo[10]) : 0;
                                objKey.Order_Count = !String.IsNullOrEmpty(arrayInfo[11]) ? int.Parse(arrayInfo[11]) : 0;
                                objKey.Total_Sales = !String.IsNullOrEmpty(arrayInfo[12]) ? Decimal.Parse(arrayInfo[12]) : 0;
                                objKey.Tax_Amount = !String.IsNullOrEmpty(arrayInfo[13]) ? Decimal.Parse(arrayInfo[13]) : 0;
                                objKey.Bottle_Deposit_Amount = !String.IsNullOrEmpty(arrayInfo[14]) ? Decimal.Parse(arrayInfo[14]) : 0;
                                objKey.Net_Sales = !String.IsNullOrEmpty(arrayInfo[15]) ? Decimal.Parse(arrayInfo[15]) : 0;
                                objKey.Delivery_Fee = !String.IsNullOrEmpty(arrayInfo[16]) ? Decimal.Parse(arrayInfo[16]) : 0;
                                objKey.Order_Discount_Amount = !String.IsNullOrEmpty(arrayInfo[17]) ? Decimal.Parse(arrayInfo[17]) : 0;
                                objKey.Item_Net = !String.IsNullOrEmpty(arrayInfo[18]) ? Decimal.Parse(arrayInfo[18]) : 0;
                                objKey.Item_Discount_Amount = !String.IsNullOrEmpty(arrayInfo[19]) ? Decimal.Parse(arrayInfo[19]) : 0;
                                objKey.Item_Menu_Amount = !String.IsNullOrEmpty(arrayInfo[20]) ? Decimal.Parse(arrayInfo[20]) : 0;
                                objKey.NonAdjustment_Coupon_Amount = !String.IsNullOrEmpty(arrayInfo[21]) ? Decimal.Parse(arrayInfo[21]) : 0;
                                objKey.Royalty_Sales = !String.IsNullOrEmpty(arrayInfo[22]) ? Decimal.Parse(arrayInfo[22]) : 0;
                                //objKey.Royalty_Sales = !String.IsNullOrEmpty(arrayInfo[23]) ? Decimal.Parse(arrayInfo[23]) : 0;
                                objKey.Non_Royalty_Sales = !String.IsNullOrEmpty(arrayInfo[23]) ? Decimal.Parse(arrayInfo[23]) : 0;
                                objKey.Non_Taxable_Sales = !String.IsNullOrEmpty(arrayInfo[24]) ? Decimal.Parse(arrayInfo[24]) : 0;
                                objKey.Average_Ticket_Order_Count = !String.IsNullOrEmpty(arrayInfo[25]) ? int.Parse(arrayInfo[25]) : 0;
                                objKey.Average_Ticket_Net = !String.IsNullOrEmpty(arrayInfo[26]) ? Decimal.Parse(arrayInfo[26]) : 0;
                                objKey.Average_Ticket = !String.IsNullOrEmpty(arrayInfo[27]) ? Decimal.Parse(arrayInfo[27]) : 0;
                                objKey.Min_Average_Ticket = !String.IsNullOrEmpty(arrayInfo[28]) ? Decimal.Parse(arrayInfo[28]) : 0;
                                objKey.Max_Average_Ticket = !String.IsNullOrEmpty(arrayInfo[29]) ? Decimal.Parse(arrayInfo[29]) : 0;
                                objKey.Delivery_Order_Count = !String.IsNullOrEmpty(arrayInfo[30]) ? int.Parse(arrayInfo[30]) : 0;
                                objKey.Delivery_Net = !String.IsNullOrEmpty(arrayInfo[31]) ? Decimal.Parse(arrayInfo[31]) : 0;
                                objKey.Delivery_Sales = !String.IsNullOrEmpty(arrayInfo[32]) ? Decimal.Parse(arrayInfo[32]) : 0;
                                objKey.Carryout_Order_Count = !String.IsNullOrEmpty(arrayInfo[33]) ? int.Parse(arrayInfo[33]) : 0;
                                objKey.Carryout_Net = !String.IsNullOrEmpty(arrayInfo[34]) ? Decimal.Parse(arrayInfo[34]) : 0;
                                objKey.Carryout_Sales = !String.IsNullOrEmpty(arrayInfo[35]) ? Decimal.Parse(arrayInfo[35]) : 0;
                                objKey.Drive_Thru_Order_Count = !String.IsNullOrEmpty(arrayInfo[36]) ? int.Parse(arrayInfo[36]) : 0;
                                objKey.Drive_Thru_Net = !String.IsNullOrEmpty(arrayInfo[37]) ? Decimal.Parse(arrayInfo[37]) : 0;
                                objKey.Drive_Thru_Sales = !String.IsNullOrEmpty(arrayInfo[38]) ? Decimal.Parse(arrayInfo[38]) : 0;
                                objKey.Dine_In_Order_Count = !String.IsNullOrEmpty(arrayInfo[39]) ? int.Parse(arrayInfo[39]) : 0;
                                objKey.Dine_In_Net = !String.IsNullOrEmpty(arrayInfo[40]) ? Decimal.Parse(arrayInfo[40]) : 0;
                                objKey.Dine_In_Sales = !String.IsNullOrEmpty(arrayInfo[41]) ? Decimal.Parse(arrayInfo[41]) : 0;
                                objKey.Phone_Order_Count = !String.IsNullOrEmpty(arrayInfo[42]) ? int.Parse(arrayInfo[42]) : 0;
                                objKey.Phone_Net = !String.IsNullOrEmpty(arrayInfo[43]) ? Decimal.Parse(arrayInfo[43]) : 0;
                                objKey.Phone_Sales = !String.IsNullOrEmpty(arrayInfo[44]) ? Decimal.Parse(arrayInfo[44]) : 0;
                                objKey.Walk_In_Order_Count = !String.IsNullOrEmpty(arrayInfo[45]) ? int.Parse(arrayInfo[45]) : 0;
                                objKey.Walk_In_Net = !String.IsNullOrEmpty(arrayInfo[46]) ? Decimal.Parse(arrayInfo[46]) : 0;
                                objKey.Walk_In_Sales1 = !String.IsNullOrEmpty(arrayInfo[47]) ? Decimal.Parse(arrayInfo[47]) : 0;
                                objKey.Internet_Order_Count = !String.IsNullOrEmpty(arrayInfo[48]) ? int.Parse(arrayInfo[48]) : 0;
                                objKey.Internet_Net = !String.IsNullOrEmpty(arrayInfo[49]) ? Decimal.Parse(arrayInfo[49]) : 0;
                                objKey.Internet_Sales = !String.IsNullOrEmpty(arrayInfo[50]) ? Decimal.Parse(arrayInfo[50]) : 0;
                                objKey.Transfer_Order_Count = !String.IsNullOrEmpty(arrayInfo[51]) ? int.Parse(arrayInfo[51]) : 0;
                                objKey.Transfer_Net = !String.IsNullOrEmpty(arrayInfo[52]) ? Decimal.Parse(arrayInfo[52]) : 0;
                                objKey.Transfer_Sales = !String.IsNullOrEmpty(arrayInfo[53]) ? Decimal.Parse(arrayInfo[53]) : 0;
                                objKey.Lunch_Order_Count = !String.IsNullOrEmpty(arrayInfo[54]) ? int.Parse(arrayInfo[54]) : 0;
                                objKey.Lunch_Net = !String.IsNullOrEmpty(arrayInfo[55]) ? Decimal.Parse(arrayInfo[55]) : 0;
                                objKey.Lunch_Sales = !String.IsNullOrEmpty(arrayInfo[56]) ? Decimal.Parse(arrayInfo[56]) : 0;
                                objKey.Dinner_Order_Count = !String.IsNullOrEmpty(arrayInfo[57]) ? int.Parse(arrayInfo[57]) : 0;
                                objKey.Dinner_Net = !String.IsNullOrEmpty(arrayInfo[58]) ? Decimal.Parse(arrayInfo[58]) : 0;
                                objKey.Dinner_Sales = !String.IsNullOrEmpty(arrayInfo[59]) ? Decimal.Parse(arrayInfo[59]) : 0;
                                objKey.Evening_Order_Count = !String.IsNullOrEmpty(arrayInfo[60]) ? int.Parse(arrayInfo[60]) : 0;
                                objKey.Evening_Net = !String.IsNullOrEmpty(arrayInfo[61]) ? Decimal.Parse(arrayInfo[61]) : 0;
                                objKey.Evening_Sales = !String.IsNullOrEmpty(arrayInfo[62]) ? Decimal.Parse(arrayInfo[62]) : 0;
                                objKey.Cash_Order_Count = !String.IsNullOrEmpty(arrayInfo[63]) ? int.Parse(arrayInfo[63]) : 0;
                                objKey.Cash_Net = !String.IsNullOrEmpty(arrayInfo[64]) ? Decimal.Parse(arrayInfo[64]) : 0;
                                objKey.Cash_Sales = !String.IsNullOrEmpty(arrayInfo[65]) ? Decimal.Parse(arrayInfo[65]) : 0;
                                objKey.Check_Order_Count = !String.IsNullOrEmpty(arrayInfo[66]) ? int.Parse(arrayInfo[66]) : 0;
                                objKey.Check_Net = !String.IsNullOrEmpty(arrayInfo[67]) ? Decimal.Parse(arrayInfo[67]) : 0;
                                objKey.Check_Sales = !String.IsNullOrEmpty(arrayInfo[68]) ? Decimal.Parse(arrayInfo[68]) : 0;
                                objKey.Credit_Card_Order_Count = !String.IsNullOrEmpty(arrayInfo[69]) ? int.Parse(arrayInfo[69]) : 0;
                                objKey.Credit_Card_Net = !String.IsNullOrEmpty(arrayInfo[70]) ? Decimal.Parse(arrayInfo[70]) : 0;
                                objKey.Credit_Card_Sales = !String.IsNullOrEmpty(arrayInfo[71]) ? Decimal.Parse(arrayInfo[71]) : 0;
                                objKey.Pizza_Order_Count = !String.IsNullOrEmpty(arrayInfo[72]) ? int.Parse(arrayInfo[72]) : 0;
                                objKey.Pizza_Quantity = !String.IsNullOrEmpty(arrayInfo[73]) ? int.Parse(arrayInfo[73]) : 0;
                                objKey.Pizza_Net = !String.IsNullOrEmpty(arrayInfo[74]) ? Decimal.Parse(arrayInfo[74]) : 0;
                                objKey.Drink_Order_Count = !String.IsNullOrEmpty(arrayInfo[75]) ? int.Parse(arrayInfo[75]) : 0;
                                objKey.Drink_Quantity = !String.IsNullOrEmpty(arrayInfo[76]) ? int.Parse(arrayInfo[76]) : 0;
                                objKey.Drink_Net = !String.IsNullOrEmpty(arrayInfo[77]) ? Decimal.Parse(arrayInfo[77]) : 0;
                                objKey.Sides_Order_Count = !String.IsNullOrEmpty(arrayInfo[78]) ? int.Parse(arrayInfo[78]) : 0;
                                objKey.Sides_Quantity = !String.IsNullOrEmpty(arrayInfo[79]) ? int.Parse(arrayInfo[79]) : 0;
                                objKey.Sides_Net = !String.IsNullOrEmpty(arrayInfo[80]) ? Decimal.Parse(arrayInfo[80]) : 0;
                                objKey.Other_Item_Order_Count = !String.IsNullOrEmpty(arrayInfo[81]) ? int.Parse(arrayInfo[81]) : 0;
                                objKey.Other_Item_Quantity = !String.IsNullOrEmpty(arrayInfo[82]) ? int.Parse(arrayInfo[82]) : 0;
                                objKey.Other_Item_Net = !String.IsNullOrEmpty(arrayInfo[83]) ? Decimal.Parse(arrayInfo[83]) : 0;
                                objKey.Food_Cost = !String.IsNullOrEmpty(arrayInfo[84]) ? Decimal.Parse(arrayInfo[84]) : 0;
                                objKey.Food_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[85]) ? Decimal.Parse(arrayInfo[85]) : 0;
                                objKey.Ideal_Food_Cost = !String.IsNullOrEmpty(arrayInfo[86]) ? Decimal.Parse(arrayInfo[86]) : 0;
                                objKey.Ideal_Food_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[87]) ? Decimal.Parse(arrayInfo[87]) : 0;
                                objKey.Var_Labor_Cost = !String.IsNullOrEmpty(arrayInfo[88]) ? Decimal.Parse(arrayInfo[88]) : 0;
                                objKey.Var_Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[89]) ? Decimal.Parse(arrayInfo[89]) : 0;
                                objKey.Var_Ideal_Labor_Cost = !String.IsNullOrEmpty(arrayInfo[90]) ? Decimal.Parse(arrayInfo[90]) : 0;
                                objKey.Var_Ideal_Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[91]) ? Decimal.Parse(arrayInfo[91]) : 0;
                                objKey.Fixed_Labor_Cost = !String.IsNullOrEmpty(arrayInfo[92]) ? Decimal.Parse(arrayInfo[92]) : 0;
                                objKey.Fixed_Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[93]) ? Decimal.Parse(arrayInfo[93]) : 0;
                                objKey.Fixed_Ideal_Labor_Cost = !String.IsNullOrEmpty(arrayInfo[94]) ? Decimal.Parse(arrayInfo[94]) : 0;
                                objKey.Fixed_Ideal_Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[95]) ? Decimal.Parse(arrayInfo[95]) : 0;
                                objKey.Labor_Cost = !String.IsNullOrEmpty(arrayInfo[96]) ? Decimal.Parse(arrayInfo[96]) : 0;
                                objKey.Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[97]) ? Decimal.Parse(arrayInfo[97]) : 0;
                                objKey.Ideal_Labor_Cost = !String.IsNullOrEmpty(arrayInfo[98]) ? Decimal.Parse(arrayInfo[98]) : 0;
                                objKey.Ideal_Labor_Cost_Percent = !String.IsNullOrEmpty(arrayInfo[99]) ? Decimal.Parse(arrayInfo[99]) : 0;
                                objKey.Mileage_Cost = !String.IsNullOrEmpty(arrayInfo[100]) ? Decimal.Parse(arrayInfo[100]) : 0;
                                objKey.Pizza_IFC_Quantity = !String.IsNullOrEmpty(arrayInfo[101]) ? int.Parse(arrayInfo[101]) : 0;
                                objKey.Pizza_IFC = !String.IsNullOrEmpty(arrayInfo[102]) ? Decimal.Parse(arrayInfo[102]) : 0;
                                objKey.Drink_IFC_Quantity = !String.IsNullOrEmpty(arrayInfo[103]) ? int.Parse(arrayInfo[103]) : 0;
                                objKey.Drink_IFC = !String.IsNullOrEmpty(arrayInfo[104]) ? Decimal.Parse(arrayInfo[104]) : 0;
                                objKey.Sides_IFC_Quantity = !String.IsNullOrEmpty(arrayInfo[105]) ? int.Parse(arrayInfo[105]) : 0;
                                objKey.Sides_IFC = !String.IsNullOrEmpty(arrayInfo[106]) ? Decimal.Parse(arrayInfo[106]) : 0;
                                objKey.Other_Item_IFC_Quantity = !String.IsNullOrEmpty(arrayInfo[107]) ? int.Parse(arrayInfo[107]) : 0;
                                objKey.Other_Item_IFC = !String.IsNullOrEmpty(arrayInfo[108]) ? Decimal.Parse(arrayInfo[108]) : 0;
                                objKey.Run_Order_Count = !String.IsNullOrEmpty(arrayInfo[109]) ? int.Parse(arrayInfo[109]) : 0;
                                objKey.Run_Count = !String.IsNullOrEmpty(arrayInfo[110]) ? int.Parse(arrayInfo[110]) : 0;
                                objKey.Ave_Order_In_Run = !String.IsNullOrEmpty(arrayInfo[111]) ? Decimal.Parse(arrayInfo[111]) : 0;
                                objKey.Goal_Run_Order_Count = !String.IsNullOrEmpty(arrayInfo[112]) ? int.Parse(arrayInfo[112]) : 0;
                                objKey.Attain_Run_Order_Count = !String.IsNullOrEmpty(arrayInfo[113]) ? int.Parse(arrayInfo[113]) : 0;
                                objKey.Attain_Run_Order_Percent = !String.IsNullOrEmpty(arrayInfo[114]) ? Decimal.Parse(arrayInfo[114]) : 0;
                                objKey.Stop_1_Run_Count = !String.IsNullOrEmpty(arrayInfo[115]) ? int.Parse(arrayInfo[115]) : 0;
                                objKey.Stop_2_Run_Count = !String.IsNullOrEmpty(arrayInfo[116]) ? int.Parse(arrayInfo[116]) : 0;
                                objKey.Stop_3_Run_Count = !String.IsNullOrEmpty(arrayInfo[117]) ? int.Parse(arrayInfo[117]) : 0;
                                objKey.Stop_4Plus_Run_Count = !String.IsNullOrEmpty(arrayInfo[118]) ? int.Parse(arrayInfo[118]) : 0;
                                objKey.Stop_1_Order_Count = !String.IsNullOrEmpty(arrayInfo[119]) ? int.Parse(arrayInfo[119]) : 0;
                                objKey.Stop_2_Order_Count = !String.IsNullOrEmpty(arrayInfo[120]) ? int.Parse(arrayInfo[120]) : 0;

                                objKey.Stop_3_Order_Count = !String.IsNullOrEmpty(arrayInfo[121]) ? int.Parse(arrayInfo[121]) : 0;
                                objKey.Stop_4Plus_Order_Count = !String.IsNullOrEmpty(arrayInfo[122]) ? int.Parse(arrayInfo[122]) : 0;
                                objKey.Take_Time = !String.IsNullOrEmpty(arrayInfo[123]) ? int.Parse(arrayInfo[123]) : 0;
                                objKey.Take_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[124]) ? int.Parse(arrayInfo[124]) : 0;
                                objKey.Ave_Take_Seconds = !String.IsNullOrEmpty(arrayInfo[125]) ? Decimal.Parse(arrayInfo[125]) : 0;
                                objKey.Ave_Take_Minutes = !String.IsNullOrEmpty(arrayInfo[126]) ? Decimal.Parse(arrayInfo[126]) : 0;
                                objKey.Ave_Take_Hms = arrayInfo[127];
                                objKey.Goal_Take_Minutes = !String.IsNullOrEmpty(arrayInfo[128]) ? int.Parse(arrayInfo[128]) : 0;
                                objKey.Attain_Take_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[129]) ? int.Parse(arrayInfo[129]) : 0;
                                objKey.Attain_Take_Percent = !String.IsNullOrEmpty(arrayInfo[130]) ? Decimal.Parse(arrayInfo[130]) : 0;
                                objKey.Load_Time = !String.IsNullOrEmpty(arrayInfo[131]) ? int.Parse(arrayInfo[131]) : 0;
                                objKey.Load_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[132]) ? int.Parse(arrayInfo[132]) : 0;
                                objKey.Ave_Load_Seconds = !String.IsNullOrEmpty(arrayInfo[133]) ? Decimal.Parse(arrayInfo[133]) : 0;
                                objKey.Ave_Load_Minutes = !String.IsNullOrEmpty(arrayInfo[134]) ? Decimal.Parse(arrayInfo[134]) : 0;
                                objKey.Ave_Load_Hms = arrayInfo[135];
                                objKey.Goal_Load_Minutes = !String.IsNullOrEmpty(arrayInfo[136]) ? int.Parse(arrayInfo[136]) : 0;
                                objKey.Attain_Load_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[137]) ? int.Parse(arrayInfo[137]) : 0;
                                objKey.Attain_Load_Percent = !String.IsNullOrEmpty(arrayInfo[138]) ? Decimal.Parse(arrayInfo[138]) : 0;
                                objKey.Oven_Minutes = !String.IsNullOrEmpty(arrayInfo[139]) ? Decimal.Parse(arrayInfo[139]) : 0;
                                objKey.Wait_Time = !String.IsNullOrEmpty(arrayInfo[140]) ? Decimal.Parse(arrayInfo[140]) : 0;
                                objKey.Wait_Order_Count = !String.IsNullOrEmpty(arrayInfo[141]) ? int.Parse(arrayInfo[141]) : 0;
                                objKey.Ave_Wait_Seconds = !String.IsNullOrEmpty(arrayInfo[142]) ? Decimal.Parse(arrayInfo[142]) : 0;
                                objKey.Ave_Wait_Minutes = !String.IsNullOrEmpty(arrayInfo[143]) ? Decimal.Parse(arrayInfo[143]) : 0;
                                objKey.Ave_Wait_Hms = arrayInfo[144];
                                objKey.Goal_Wait_Minutes = !String.IsNullOrEmpty(arrayInfo[145]) ? int.Parse(arrayInfo[145]) : 0;
                                objKey.Attain_Wait_Order_Count = !String.IsNullOrEmpty(arrayInfo[146]) ? int.Parse(arrayInfo[146]) : 0;
                                objKey.Attain_Wait_Percent = !String.IsNullOrEmpty(arrayInfo[147]) ? Decimal.Parse(arrayInfo[147]) : 0;
                                objKey.Dispatch_Time = !String.IsNullOrEmpty(arrayInfo[148]) ? int.Parse(arrayInfo[148]) : 0;
                                objKey.Dispatch_Order_Count = !String.IsNullOrEmpty(arrayInfo[149]) ? int.Parse(arrayInfo[149]) : 0;
                                objKey.Ave_Dispatch_Seconds = !String.IsNullOrEmpty(arrayInfo[150]) ? Decimal.Parse(arrayInfo[150]) : 0;

                                objKey.Ave_Dispatch_Minutes = !String.IsNullOrEmpty(arrayInfo[151]) ? Decimal.Parse(arrayInfo[151]) : 0;
                                objKey.Ave_Dispatch_Hms = arrayInfo[152];
                                objKey.Goal_Dispatch_Minutes = !String.IsNullOrEmpty(arrayInfo[153]) ? int.Parse(arrayInfo[153]) : 0;
                                objKey.Attain_Dispatch_Order_Count = !String.IsNullOrEmpty(arrayInfo[154]) ? int.Parse(arrayInfo[154]) : 0;
                                objKey.Attain_Dispatch_Percent = !String.IsNullOrEmpty(arrayInfo[155]) ? Decimal.Parse(arrayInfo[155]) : 0;
                                objKey.Delivery_Time = !String.IsNullOrEmpty(arrayInfo[156]) ? int.Parse(arrayInfo[156]) : 0;
                                objKey.Delivery_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[157]) ? int.Parse(arrayInfo[157]) : 0;
                                objKey.Ave_Delivery_Seconds = !String.IsNullOrEmpty(arrayInfo[158]) ? Decimal.Parse(arrayInfo[158]) : 0;
                                objKey.Ave_Delivery_Minutes = !String.IsNullOrEmpty(arrayInfo[159]) ? Decimal.Parse(arrayInfo[159]) : 0;
                                objKey.Ave_Delivery_Hms = arrayInfo[160];

                                objKey.Goal_Delivery_Minutes = !String.IsNullOrEmpty(arrayInfo[161]) ? int.Parse(arrayInfo[161]) : 0;
                                objKey.Attain_Delivery_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[162]) ? int.Parse(arrayInfo[162]) : 0;
                                objKey.Attain_Delivery_Percent = !String.IsNullOrEmpty(arrayInfo[163]) ? Decimal.Parse(arrayInfo[163]) : 0;
                                objKey.Delivery_Void_Order_Count = !String.IsNullOrEmpty(arrayInfo[164]) ? int.Parse(arrayInfo[164]) : 0;
                                objKey.NonDelivery_Void_Order_Count = !String.IsNullOrEmpty(arrayInfo[165]) ? int.Parse(arrayInfo[165]) : 0;
                                objKey.Delivery_Bad_Order_Count = !String.IsNullOrEmpty(arrayInfo[166]) ? int.Parse(arrayInfo[166]) : 0;
                                objKey.NonDelivery_Bad_Order_Count = !String.IsNullOrEmpty(arrayInfo[167]) ? int.Parse(arrayInfo[167]) : 0;
                                objKey.Edit_Zero_Order_Count = !String.IsNullOrEmpty(arrayInfo[168]) ? int.Parse(arrayInfo[168]) : 0;
                                objKey.NoEdit_Zero_Order_Count = !String.IsNullOrEmpty(arrayInfo[169]) ? int.Parse(arrayInfo[169]) : 0;
                                objKey.Edit_Order_Count = !String.IsNullOrEmpty(arrayInfo[170]) ? int.Parse(arrayInfo[170]) : 0;

                                objKey.Reprint_Order_Count = !String.IsNullOrEmpty(arrayInfo[171]) ? int.Parse(arrayInfo[171]) : 0;
                                objKey.Bank_Deposit_Amount = !String.IsNullOrEmpty(arrayInfo[172]) ? Decimal.Parse(arrayInfo[172]) : 0;
                                objKey.CC_Settlement_Amount = !String.IsNullOrEmpty(arrayInfo[173]) ? Decimal.Parse(arrayInfo[173]) : 0;
                                objKey.Food_Bought_Amount = !String.IsNullOrEmpty(arrayInfo[174]) ? Decimal.Parse(arrayInfo[174]) : 0;
                                objKey.Cash_Over_Short = !String.IsNullOrEmpty(arrayInfo[175]) ? decimal.Parse(arrayInfo[175]) : 0;
                                objKey.Ending_Inventory_Amount = !String.IsNullOrEmpty(arrayInfo[176]) ? Decimal.Parse(arrayInfo[176]) : 0;
                                objKey.Food_Sold_Amount = !String.IsNullOrEmpty(arrayInfo[177]) ? Decimal.Parse(arrayInfo[177]) : 0;
                                objKey.Ending_Till_Amount = !String.IsNullOrEmpty(arrayInfo[178]) ? Decimal.Parse(arrayInfo[178]) : 0;
                                objKey.Attain_Dispatch_5_Order_Count = !String.IsNullOrEmpty(arrayInfo[179]) ? int.Parse(arrayInfo[179]) : 0;
                                objKey.Corp_GL_Prod_Srvc_Guar = !String.IsNullOrEmpty(arrayInfo[180]) ? Decimal.Parse(arrayInfo[180]) : 0;

                                objKey.Corp_Goal_Take_Seconds = !String.IsNullOrEmpty(arrayInfo[181]) ? int.Parse(arrayInfo[181]) : 0;
                                objKey.Corp_Attain_Take_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[182]) ? int.Parse(arrayInfo[182]) : 0;
                                objKey.Corp_Goal_Load_Seconds = !String.IsNullOrEmpty(arrayInfo[183]) ? int.Parse(arrayInfo[183]) : 0;
                                objKey.Corp_Attain_Load_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[184]) ? int.Parse(arrayInfo[184]) : 0;
                                objKey.Corp_Goal_Dispatch_Seconds = !String.IsNullOrEmpty(arrayInfo[185]) ? int.Parse(arrayInfo[185]) : 0;
                                objKey.Corp_Attain_Dispatch_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[186]) ? int.Parse(arrayInfo[186]) : 0;
                                objKey.Corp_Goal_Delivery_Seconds = !String.IsNullOrEmpty(arrayInfo[187]) ? int.Parse(arrayInfo[187]) : 0;
                                objKey.Corp_Attain_Delivery_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[188]) ? int.Parse(arrayInfo[188]) : 0;
                                objKey.WTD_Labor = !String.IsNullOrEmpty(arrayInfo[189]) ? Decimal.Parse(arrayInfo[189]) : 0;
                                objKey.WTD_Food = !String.IsNullOrEmpty(arrayInfo[190]) ? Decimal.Parse(arrayInfo[190]) : 0;


                                objKey.WTD_Ideal_Labor = !String.IsNullOrEmpty(arrayInfo[191]) ? Decimal.Parse(arrayInfo[191]) : 0;
                                objKey.DatabaseVersion = arrayInfo[192];
                                objKey.Check_Charge_Amt = !String.IsNullOrEmpty(arrayInfo[193]) ? Decimal.Parse(arrayInfo[193]) : 0;
                                objKey.Trade_Rec_Ord_Ct = !String.IsNullOrEmpty(arrayInfo[194]) ? int.Parse(arrayInfo[194]) : 0;
                                objKey.Trade_Rec_Net = !String.IsNullOrEmpty(arrayInfo[195]) ? Decimal.Parse(arrayInfo[195]) : 0;
                                objKey.Trade_Rec_Sales = !String.IsNullOrEmpty(arrayInfo[196]) ? Decimal.Parse(arrayInfo[196]) : 0;
                                objKey.GiftCard_Ord_Ct = !String.IsNullOrEmpty(arrayInfo[197]) ? int.Parse(arrayInfo[197]) : 0;
                                objKey.GiftCard_Net = !String.IsNullOrEmpty(arrayInfo[198]) ? Decimal.Parse(arrayInfo[198]) : 0;
                                objKey.GiftCard_Sales = !String.IsNullOrEmpty(arrayInfo[199]) ? Decimal.Parse(arrayInfo[199]) : 0;
                                objKey.GCAddValue_Sales = !String.IsNullOrEmpty(arrayInfo[200]) ? Decimal.Parse(arrayInfo[200]) : 0;


                                objKey.GCAddValue_Cnt = !String.IsNullOrEmpty(arrayInfo[201]) ? int.Parse(arrayInfo[201]) : 0;
                                objKey.Cancelled_Carrout_Order_Count = !String.IsNullOrEmpty(arrayInfo[202]) ? int.Parse(arrayInfo[202]) : 0;
                                objKey.Cancelled_Carrout_Net = !String.IsNullOrEmpty(arrayInfo[203]) ? Decimal.Parse(arrayInfo[203]) : 0;
                                objKey.Cancelled_Delivery_Order_Count = !String.IsNullOrEmpty(arrayInfo[204]) ? int.Parse(arrayInfo[204]) : 0;
                                objKey.Cancelled_Delivery_Net = !String.IsNullOrEmpty(arrayInfo[205]) ? Decimal.Parse(arrayInfo[205]) : 0;
                                objKey.Carry_Out_10pm_Order_Count = !String.IsNullOrEmpty(arrayInfo[206]) ? int.Parse(arrayInfo[206]) : 0;
                                objKey.Carry_Out_After_10pm_Net = !String.IsNullOrEmpty(arrayInfo[207]) ? Decimal.Parse(arrayInfo[207]) : 0;
                                objKey.Delivery_Edit_1_Order_Count = !String.IsNullOrEmpty(arrayInfo[208]) ? int.Parse(arrayInfo[208]) : 0;
                                objKey.Delivery_Edit_2_Order_Count = !String.IsNullOrEmpty(arrayInfo[209]) ? int.Parse(arrayInfo[209]) : 0;
                                objKey.Delivery_Edit_3_Plus_Order_Count = !String.IsNullOrEmpty(arrayInfo[210]) ? int.Parse(arrayInfo[210]) : 0;

                                objKey.Carryout_Edit_1_Order_Count = !String.IsNullOrEmpty(arrayInfo[211]) ? int.Parse(arrayInfo[211]) : 0;
                                objKey.Carryout_Edit_2_Order_Count = !String.IsNullOrEmpty(arrayInfo[212]) ? int.Parse(arrayInfo[212]) : 0;
                                objKey.Carryout_Edit_3_Plus_Order_Count = !String.IsNullOrEmpty(arrayInfo[213]) ? int.Parse(arrayInfo[213]) : 0;
                                objKey.Inv_Item_Ct_With_Price_Change = !String.IsNullOrEmpty(arrayInfo[214]) ? int.Parse(arrayInfo[214]) : 0;
                                objKey.Ghost_Employee_Count = !String.IsNullOrEmpty(arrayInfo[215]) ? int.Parse(arrayInfo[215]) : 0;
                                objKey.Total_Ghost_Hours = !String.IsNullOrEmpty(arrayInfo[216]) ? Decimal.Parse(arrayInfo[216]) : 0;
                                objKey.Off_Clock_Employee_Count = !String.IsNullOrEmpty(arrayInfo[217]) ? int.Parse(arrayInfo[217]) : 0;
                                objKey.Total_Orders_Off_Clock = !String.IsNullOrEmpty(arrayInfo[218]) ? int.Parse(arrayInfo[218]) : 0;
                                objKey.Nbr_Deposits_Over_900 = !String.IsNullOrEmpty(arrayInfo[219]) ? int.Parse(arrayInfo[219]) : 0;
                                objKey.Nbr_Deposits_Multiple_Of_100 = !String.IsNullOrEmpty(arrayInfo[220]) ? int.Parse(arrayInfo[220]) : 0;

                                objKey.Additional_Mileage_Cost = !String.IsNullOrEmpty(arrayInfo[221]) ? Decimal.Parse(arrayInfo[221]) : 0;
                                objKey.Prod_Srvc_Guarantee_Amt = !String.IsNullOrEmpty(arrayInfo[222]) ? Decimal.Parse(arrayInfo[222]) : 0;
                                objKey.Prod_Srvc_Guarantee_Ct = !String.IsNullOrEmpty(arrayInfo[223]) ? int.Parse(arrayInfo[223]) : 0;
                                objKey.Reprint_1_Order_Count = !String.IsNullOrEmpty(arrayInfo[224]) ? int.Parse(arrayInfo[224]) : 0;
                                objKey.Reprint_2_Order_Count = !String.IsNullOrEmpty(arrayInfo[225]) ? int.Parse(arrayInfo[225]) : 0;
                                objKey.Reprint_3_Plus_Order_Count = !String.IsNullOrEmpty(arrayInfo[226]) ? int.Parse(arrayInfo[226]) : 0;
                                objKey.GiftCard_CPO = !String.IsNullOrEmpty(arrayInfo[227]) ? Decimal.Parse(arrayInfo[227]) : 0;
                                objKey.Trade_Rec_CPO = !String.IsNullOrEmpty(arrayInfo[228]) ? Decimal.Parse(arrayInfo[228]) : 0;
                                objKey.Att_le15_disp_ct = !String.IsNullOrEmpty(arrayInfo[229]) ? int.Parse(arrayInfo[229]) : 0;
                                objKey.Delivery_PCar_Sales = !String.IsNullOrEmpty(arrayInfo[230]) ? Decimal.Parse(arrayInfo[230]) : 0;

                                objKey.Delivery_PCar_Count = !String.IsNullOrEmpty(arrayInfo[231]) ? int.Parse(arrayInfo[231]) : 0;
                                objKey.Delivery_CoCar_Sales = !String.IsNullOrEmpty(arrayInfo[232]) ? Decimal.Parse(arrayInfo[232]) : 0;
                                objKey.Delivery_CoCar_Count = !String.IsNullOrEmpty(arrayInfo[233]) ? int.Parse(arrayInfo[233]) : 0;
                                objKey.Royalty_Sales_Last_Year = !String.IsNullOrEmpty(arrayInfo[234]) ? Decimal.Parse(arrayInfo[234]) : 0;
                                objKey.Total_MROT_Amount = !String.IsNullOrEmpty(arrayInfo[235]) ? Decimal.Parse(arrayInfo[235]) : 0;
                                objKey.Total_CPO_Amount = !String.IsNullOrEmpty(arrayInfo[236]) ? Decimal.Parse(arrayInfo[236]) : 0;
                                objKey.Run_Time = !String.IsNullOrEmpty(arrayInfo[237]) ? int.Parse(arrayInfo[237]) : 0;
                                objKey.Run_Time_Order_Count = !String.IsNullOrEmpty(arrayInfo[238]) ? int.Parse(arrayInfo[238]) : 0;
                                objKey.OLO_Order_Count = !String.IsNullOrEmpty(arrayInfo[239]) ? int.Parse(arrayInfo[239]) : 0;
                                objKey.OLO_Net = !String.IsNullOrEmpty(arrayInfo[240]) ? Decimal.Parse(arrayInfo[240]) : 0;

                                objKey.OLO_Sales = !String.IsNullOrEmpty(arrayInfo[241]) ? Decimal.Parse(arrayInfo[241]) : 0;
                                objKey.Edit_Downs = !String.IsNullOrEmpty(arrayInfo[242]) ? int.Parse(arrayInfo[242]) : 0;
                                objKey.MPC_Total = !String.IsNullOrEmpty(arrayInfo[243]) ? int.Parse(arrayInfo[243]) : 0;
                                objKey.ManualCPO = !String.IsNullOrEmpty(arrayInfo[244]) ? Decimal.Parse(arrayInfo[244]) : 0;
                                objKey.Service_Exceptions = !String.IsNullOrEmpty(arrayInfo[245]) ? int.Parse(arrayInfo[245]) : 0;
                                objKey.Insider_ActualHoursMorning = !String.IsNullOrEmpty(arrayInfo[246]) ? Decimal.Parse(arrayInfo[246]) : 0;
                                objKey.Insider_ActualHoursLunch = !String.IsNullOrEmpty(arrayInfo[247]) ? Decimal.Parse(arrayInfo[247]) : 0;
                                objKey.Insider_ActualHoursDinner = !String.IsNullOrEmpty(arrayInfo[248]) ? Decimal.Parse(arrayInfo[248]) : 0;
                                objKey.Insider_ActualHoursClosed = !String.IsNullOrEmpty(arrayInfo[249]) ? Decimal.Parse(arrayInfo[249]) : 0;
                                objKey.Insider_ForecastHoursMorning = !String.IsNullOrEmpty(arrayInfo[250]) ? Decimal.Parse(arrayInfo[250]) : 0;
                                
                                objKey.Insider_ForecastHoursLunch = !String.IsNullOrEmpty(arrayInfo[251]) ? Decimal.Parse(arrayInfo[251]) : 0;
                                objKey.Insider_ForecastHoursDinner = !String.IsNullOrEmpty(arrayInfo[252]) ? Decimal.Parse(arrayInfo[252]) : 0;
                                objKey.Insider_ForecastHoursClosed = !String.IsNullOrEmpty(arrayInfo[253]) ? Decimal.Parse(arrayInfo[253]) : 0;
                                objKey.Insider_IdealHoursMorning = !String.IsNullOrEmpty(arrayInfo[254]) ? Decimal.Parse(arrayInfo[254]) : 0;
                                objKey.Insider_IdealHoursLunch = !String.IsNullOrEmpty(arrayInfo[255]) ? Decimal.Parse(arrayInfo[255]) : 0;
                                objKey.Insider_IdealHoursDinner = !String.IsNullOrEmpty(arrayInfo[256]) ? Decimal.Parse(arrayInfo[256]) : 0;
                                objKey.Insider_IdealHoursClosed = !String.IsNullOrEmpty(arrayInfo[257]) ? Decimal.Parse(arrayInfo[257]) : 0;
                                objKey.Insider_ScheduledHoursMorning = !String.IsNullOrEmpty(arrayInfo[258]) ? Decimal.Parse(arrayInfo[258]) : 0;
                                objKey.Insider_ScheduledHoursLunch = !String.IsNullOrEmpty(arrayInfo[259]) ? Decimal.Parse(arrayInfo[259]) : 0;
                                objKey.Insider_ScheduledHoursDinner = !String.IsNullOrEmpty(arrayInfo[260]) ? Decimal.Parse(arrayInfo[260]) : 0;

                                objKey.Insider_ScheduledHoursClosed = !String.IsNullOrEmpty(arrayInfo[261]) ? Decimal.Parse(arrayInfo[261]) : 0;
                                objKey.DExpert_ActualHoursMorning = !String.IsNullOrEmpty(arrayInfo[262]) ? Decimal.Parse(arrayInfo[262]) : 0;
                                objKey.DExpert_ActualHoursLunch = !String.IsNullOrEmpty(arrayInfo[263]) ? Decimal.Parse(arrayInfo[263]) : 0;
                                objKey.DExpert_ActualHoursDinner = !String.IsNullOrEmpty(arrayInfo[264]) ? Decimal.Parse(arrayInfo[264]) : 0;
                                objKey.DExpert_ActualHoursClosed = !String.IsNullOrEmpty(arrayInfo[265]) ? Decimal.Parse(arrayInfo[265]) : 0;
                                objKey.DExpert_ForecastHoursMorning = !String.IsNullOrEmpty(arrayInfo[266]) ? Decimal.Parse(arrayInfo[266]) : 0;
                                objKey.DExpert_ForecastHoursLunch = !String.IsNullOrEmpty(arrayInfo[267]) ? Decimal.Parse(arrayInfo[267]) : 0;
                                objKey.DExpert_ForecastHoursDinner = !String.IsNullOrEmpty(arrayInfo[268]) ? Decimal.Parse(arrayInfo[268]) : 0;
                                objKey.DExpert_ForecastHoursClosed = !String.IsNullOrEmpty(arrayInfo[269]) ? Decimal.Parse(arrayInfo[269]) : 0;
                                objKey.DExpert_IdealHoursMorning = !String.IsNullOrEmpty(arrayInfo[270]) ? Decimal.Parse(arrayInfo[270]) : 0;

                                objKey.DExpert_IdealHoursLunch = !String.IsNullOrEmpty(arrayInfo[271]) ? Decimal.Parse(arrayInfo[271]) : 0;
                                objKey.DExpert_IdealHoursDinner = !String.IsNullOrEmpty(arrayInfo[272]) ? Decimal.Parse(arrayInfo[272]) : 0;
                                objKey.DExpert_IdealHoursClosed = !String.IsNullOrEmpty(arrayInfo[273]) ? Decimal.Parse(arrayInfo[273]) : 0;
                                objKey.DExpert_ScheduledHoursMorning = !String.IsNullOrEmpty(arrayInfo[274]) ? Decimal.Parse(arrayInfo[274]) : 0;
                                objKey.DExpert_ScheduledHoursLunch = !String.IsNullOrEmpty(arrayInfo[275]) ? Decimal.Parse(arrayInfo[275]) : 0;
                                objKey.DExpert_ScheduledHoursDinner = !String.IsNullOrEmpty(arrayInfo[276]) ? Decimal.Parse(arrayInfo[276]) : 0;
                                objKey.DExpert_ScheduledHoursClosed = !String.IsNullOrEmpty(arrayInfo[277]) ? Decimal.Parse(arrayInfo[277]) : 0;
                                objKey.HourlyTM_OvertimeHours = !String.IsNullOrEmpty(arrayInfo[278]) ? Decimal.Parse(arrayInfo[278]) : 0;
                                objKey.Management_Hours = !String.IsNullOrEmpty(arrayInfo[279]) ? Decimal.Parse(arrayInfo[279]) : 0;
                                objKey.ActualUsage_Cheese = !String.IsNullOrEmpty(arrayInfo[280]) ? Decimal.Parse(arrayInfo[280]) : 0;

                                objKey.IdealUsage_Cheese = !String.IsNullOrEmpty(arrayInfo[281]) ? Decimal.Parse(arrayInfo[281]) : 0;
                                objKey.ActualUsage_Pepperoni = !String.IsNullOrEmpty(arrayInfo[282]) ? Decimal.Parse(arrayInfo[282]) : 0;
                                objKey.IdealUsage_Pepperoni = !String.IsNullOrEmpty(arrayInfo[283]) ? Decimal.Parse(arrayInfo[283]) : 0;
                                objKey.ActualUsage_Ham = !String.IsNullOrEmpty(arrayInfo[284]) ? Decimal.Parse(arrayInfo[284]) : 0;
                                objKey.IdealUsage_Ham = !String.IsNullOrEmpty(arrayInfo[285]) ? Decimal.Parse(arrayInfo[285]) : 0;
                                objKey.ActualUsage_Sausage = !String.IsNullOrEmpty(arrayInfo[286]) ? Decimal.Parse(arrayInfo[286]) : 0;
                                objKey.IdealUsage_Sausage = !String.IsNullOrEmpty(arrayInfo[287]) ? Decimal.Parse(arrayInfo[287]) : 0;
                                objKey.ActualUsage_Wings = !String.IsNullOrEmpty(arrayInfo[288]) ? Decimal.Parse(arrayInfo[288]) : 0;
                                objKey.IdealUsage_Wings = !String.IsNullOrEmpty(arrayInfo[289]) ? Decimal.Parse(arrayInfo[289]) : 0;
                                objKey.ActualUsage_Kickers = !String.IsNullOrEmpty(arrayInfo[290]) ? Decimal.Parse(arrayInfo[290]) : 0;

                                objKey.IdealUsage_Kickers = !String.IsNullOrEmpty(arrayInfo[291]) ? Decimal.Parse(arrayInfo[291]) : 0;
                                objKey.ActualUsage_Dough = !String.IsNullOrEmpty(arrayInfo[292]) ? Decimal.Parse(arrayInfo[292]) : 0;
                                objKey.IdealUsage_Dough = !String.IsNullOrEmpty(arrayInfo[293]) ? Decimal.Parse(arrayInfo[293]) : 0;
                                objKey.ActualUsage_20ozDrinks = !String.IsNullOrEmpty(arrayInfo[294]) ? Decimal.Parse(arrayInfo[294]) : 0;
                                objKey.IdealUsage_20ozDrinks = !String.IsNullOrEmpty(arrayInfo[295]) ? Decimal.Parse(arrayInfo[295]) : 0;
                                objKey.NonTaxableDeliveryFees = !String.IsNullOrEmpty(arrayInfo[296]) ? Decimal.Parse(arrayInfo[296]) : 0;
                                objKey.CharitableDonations = !String.IsNullOrEmpty(arrayInfo[297]) ? Decimal.Parse(arrayInfo[297]) : 0;
                                objKey.Goal_Labor = !String.IsNullOrEmpty(arrayInfo[298]) ? int.Parse(arrayInfo[298]) : 0;
                                objKey.Edit_Downs_Amt = !String.IsNullOrEmpty(arrayInfo[299]) ? Decimal.Parse(arrayInfo[299]) : 0;
                                objKey.Delivery_Time_Mp = !String.IsNullOrEmpty(arrayInfo[300]) ? int.Parse(arrayInfo[300]) : 0;

                                objKey.Ave_Delivery_Seconds_Mp = !String.IsNullOrEmpty(arrayInfo[301]) ? Decimal.Parse(arrayInfo[301]) : 0;
                                objKey.Ave_Delivery_Minutes_Mp = !String.IsNullOrEmpty(arrayInfo[302]) ? Decimal.Parse(arrayInfo[302]) : 0;
                                objKey.Ave_Delivery_Hms_Mp = arrayInfo[303];
                                objKey.Attain_Delivery_Time_Order_Count_Mp = !String.IsNullOrEmpty(arrayInfo[304]) ? int.Parse(arrayInfo[304]) : 0;
                                objKey.Attain_Delivery_Percent_Mp = !String.IsNullOrEmpty(arrayInfo[305]) ? Decimal.Parse(arrayInfo[305]) : 0;
                                objKey.Corp_Attain_Delivery_Time_Order_Count_Mp = !String.IsNullOrEmpty(arrayInfo[306]) ? int.Parse(arrayInfo[306]) : 0;
                                objKey.Run_Time_Mp = !String.IsNullOrEmpty(arrayInfo[307]) ? int.Parse(arrayInfo[307]) : 0;
                                objKey.Service_Exceptions_Mp = !String.IsNullOrEmpty(arrayInfo[308]) ? int.Parse(arrayInfo[308]) : 0;
                                
                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileCKY(objRegisterFile);
                                InsertKeysExtractsCorpVersion(objKey);
                                objFile.TotalCorrect++;
                            }
                            catch(Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }
                        }

                    }

                }
                numLine++;
            }
        }
        public void OrderCuponsDump(Files objFile, StreamReader objStream)
        {

            string line;
            int numLine = 1;
            int length = 0;
            // Read and display lines from the file until the end of 
            // the file is reached.
            DateTime? defaulTDateTime = null;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "OC2")
                        {
                            OrderCupons objOrderCupons = new OrderCupons();
                            try
                            {
                                objFile.TotalRegister++;

                                objOrderCupons.Location_Code = arrayInfo[2];
                                objOrderCupons.Order_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objOrderCupons.Order_Number= !String.IsNullOrEmpty(arrayInfo[4]) ? int.Parse(arrayInfo[4]) : 0;
                                objOrderCupons.OrdCpnNbr =!String.IsNullOrEmpty(arrayInfo[5]) ? int.Parse(arrayInfo[5]) : 0;
                                objOrderCupons.OrdCpnRevNbr=!String.IsNullOrEmpty(arrayInfo[6]) ? int.Parse(arrayInfo[6]) : 0;
                                objOrderCupons.OrdCpnUpdateUserCode=arrayInfo[7];
                                objOrderCupons.OrdCpnUpdateDate=!String.IsNullOrEmpty(arrayInfo[8]) ? DateTime.Parse(arrayInfo[8]) : DateTime.MinValue;
                                objOrderCupons.CouponCode= arrayInfo[9];
                                objOrderCupons.OrdCpnQty=!String.IsNullOrEmpty(arrayInfo[10]) ? int.Parse(arrayInfo[10]) : 0;
                                objOrderCupons.OrdCpnOverrideValue=!String.IsNullOrEmpty(arrayInfo[11]) ? Decimal.Parse(arrayInfo[11]) : 0;
                                objOrderCupons.OrdCpnCouponDiscountAmt=!String.IsNullOrEmpty(arrayInfo[12]) ? Decimal.Parse(arrayInfo[12]) : 0;
                                objOrderCupons.OrdCpnIsCollected=!String.IsNullOrEmpty(arrayInfo[13]) ? int.Parse(arrayInfo[13]) : 0;
                                objOrderCupons.OrdCpnExtendedCode=arrayInfo[14];

                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileOC2(objRegisterFile);
                                InsertOrderCuponDump(objOrderCupons);
                                objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                //throw ex;
                            }


                        }

                    }

                }
                numLine++;
            }
        }
        public void InvPurchasesDetail(Files objFile, StreamReader objStream)
        {

            string line;
            int numLine = 1;
            int length = 0;
           // DateTime? defaulTDateTime = null;
            // Read and display lines from the file until the end of 
            // the file is reached.
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "IPD")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                
                                PurchaseDetailcs objPurchaseDetail = new PurchaseDetailcs();
                                objPurchaseDetail.RecordType = arrayInfo[0];
                                objPurchaseDetail.Location_Code = arrayInfo[2];;
                                objPurchaseDetail.System_Date = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objPurchaseDetail.PurchaseID = !String.IsNullOrEmpty(arrayInfo[4]) ? int.Parse(arrayInfo[4]) : 0;
                                objPurchaseDetail.VendorName = arrayInfo[5];
                                objPurchaseDetail.VendorCode = arrayInfo[6];
                                objPurchaseDetail.InvoiceNumber = arrayInfo[7];
                                objPurchaseDetail.Type = arrayInfo[8];
                                objPurchaseDetail.VendorItemCode = arrayInfo[9];
                                objPurchaseDetail.InventoryCode = arrayInfo[10];
                                objPurchaseDetail.Quantity = !String.IsNullOrEmpty(arrayInfo[11]) ? Decimal.Parse(arrayInfo[11]) : 0;
                                objPurchaseDetail.OrderUnit = arrayInfo[12];
                                objPurchaseDetail.Price = !String.IsNullOrEmpty(arrayInfo[13]) ? Decimal.Parse(arrayInfo[13]) : 0;
                                objPurchaseDetail.Extended_Price = !String.IsNullOrEmpty(arrayInfo[14]) ? Decimal.Parse(arrayInfo[14]) : 0;
                                objPurchaseDetail.DatabaseVersion = arrayInfo[15];

                                
                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileIPD(objRegisterFile);
                                InsertPurchaseDetails(objPurchaseDetail);
                                objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                // throw ex;
                            }
                        }

                    }

                }
                numLine++;
            }
        }
        public void OrdersDetailExtract(Files objFile, StreamReader objStream)
        {

            string line;
            int numLine = 1;
            int length = 0;
            // DateTime? defaulTDateTime = null;
            // Read and display lines from the file until the end of 
            // the file is reached.
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    String[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "ODT")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                OrderDetail objOrdersDetail = new OrderDetail();
                                objOrdersDetail.RecordType = arrayInfo[0];
                                objOrdersDetail.DatabaseVersion = arrayInfo[1];
                                objOrdersDetail.Store_No = arrayInfo[2];
                                objOrdersDetail.Ord_Dt = !String.IsNullOrEmpty(arrayInfo[3]) ? DateTime.Parse(arrayInfo[3]) : DateTime.MinValue;
                                objOrdersDetail.Ord_No=!String.IsNullOrEmpty(arrayInfo[4]) ? int.Parse(arrayInfo[4]) : 0;
                                objOrdersDetail.Line_No = !String.IsNullOrEmpty(arrayInfo[5]) ? int.Parse(arrayInfo[5]) : 0;
                                objOrdersDetail.Std_Prod_Cd = arrayInfo[6];
                                objOrdersDetail.Prod_Cd = arrayInfo[7];
                                objOrdersDetail.Prod_Size_Code = arrayInfo[8];
                                objOrdersDetail.Left_Top_Ds = arrayInfo[9];
                                objOrdersDetail.Right_Top_Ds = arrayInfo[10];
                                objOrdersDetail.Prod_Qt = !String.IsNullOrEmpty(arrayInfo[11])?int.Parse(arrayInfo[11]):0;
                                objOrdersDetail.Cpn_Cd = arrayInfo[12];
                                objOrdersDetail.Cpn_Descr = arrayInfo[13];
                                objOrdersDetail.Combo_Cd = arrayInfo[14];
                                objOrdersDetail.Load_Tm = !String.IsNullOrEmpty(arrayInfo[15]) ? Decimal.Parse(arrayInfo[15]) : 0;
                                objOrdersDetail.Wait_Tm = !String.IsNullOrEmpty(arrayInfo[16]) ? Decimal.Parse(arrayInfo[16]) : 0;
                                objOrdersDetail.Prize_Fg = arrayInfo[17];
                                objOrdersDetail.Comment_Ds = arrayInfo[18];
                                objOrdersDetail.Full_Menu_Amt = !String.IsNullOrEmpty(arrayInfo[19]) ? Decimal.Parse(arrayInfo[19]) : 0;
                                objOrdersDetail.Menu_Amt = !String.IsNullOrEmpty(arrayInfo[20]) ? Decimal.Parse(arrayInfo[20]) : 0;
                                objOrdersDetail.Item_Net_Amt = !String.IsNullOrEmpty(arrayInfo[21]) ? Decimal.Parse(arrayInfo[21]) : 0;
                                objOrdersDetail.Ideal_Food_Cst = !String.IsNullOrEmpty(arrayInfo[22]) ? Decimal.Parse(arrayInfo[22]) : 0;
                                objOrdersDetail.Prc_Ovr_Amt = !String.IsNullOrEmpty(arrayInfo[23]) ? Decimal.Parse(arrayInfo[23]) : 0;
                                objOrdersDetail.Prc_Ovr_Cd = arrayInfo[24];                       
                                this.InsertOrdersDetail(objOrdersDetail);

                                RegisterFile objRegisterFile = this.CreateRegisterFile(objFile);
                                RegisterFileDAL DAL = new RegisterFileDAL();
                                DAL.UpDateRegisterFileODT(objRegisterFile);
                                objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                // throw ex;
                            }
                        }
                    }
                }
                numLine++;
            }
        }
        
       
        public void InsertProducts(ProductsExtracts Param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertProducts", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertOrdersDetail(OrderDetail Param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertOrdersDetail", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertOrdersExtracts(OrdersExtracts Param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertOrdersExtracts", Param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertInventoryPurchases(InventoryPurchasesExtracts param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertInventoryPurchases", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertDailyInventory(DailyInventoryExtracts param)
        {
            try
            {
                 ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertDailyInventory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertTransactions(Transactions param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertTransactions", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertDailySummaryDump(DailySummaryDump  param )
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertDailySummaryDump", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertKeysExtractsCorpVersion(KeysExtractsCorpVersion  param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertKeysExtractsCorpVersion", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertPurchaseDetails(PurchaseDetailcs param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertPurchaseDetails", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertOrderCuponDump(OrderCupons  param)
        {
            try
            {
                ISqlMapper mapper = Mapper.Instance();
                mapper.Insert("InsertOrderCuponDump", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TO_DO: Move to RegisterFileBLL.cs
        private RegisterFile CreateRegisterFile(Files objFile)
        {
            RegisterFileDAL objRegisterDAL = new RegisterFileDAL();
            RegisterFile objRegisterResult = null;
            RegisterFile objSearch = new RegisterFile 
            {
                Tienda=objFile.NumberShop,
                DateRegister = DateTime.ParseExact(objFile.Date, "yyyyMMdd", CultureInfo.InvariantCulture)               
            };

            IList<RegisterFile> lstRegisterFile = objRegisterDAL.SelectRegisterFile(objSearch);
             if( lstRegisterFile.Count>0)
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
    }
}
