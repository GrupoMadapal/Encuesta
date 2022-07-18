using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using Poleo.DAL;
using System.IO;

namespace Poleo.BLL
{
    public class OrdersDumpBLL
    {
        #region BLL
        public void ordersDump(Files objFile, StreamReader objStream)
        {
            RegisterFileBLL objRegisterFileBLL = new RegisterFileBLL();

            string line;
            int numLine = 1;
            int length = 0;

            string oN = string.Empty;
            while ((line = objStream.ReadLine()) != null)
            {
                if (numLine == 1)//Headers
                {
                    length = line.Split('\t').Length;
                }
                else
                {
                    string[] arrayInfo = line.Split('\t');
                    if (arrayInfo.Length == length)
                    {
                        if (arrayInfo[0] == "OR2")
                        {
                            try
                            {
                                objFile.TotalRegister++;
                                OrdersDump objOrdersDump = new OrdersDump();
                                objOrdersDump.RecordType = arrayInfo[0];
                                objOrdersDump.Version = arrayInfo[1];
                                objOrdersDump.Location_Code = arrayInfo[2];
                                objOrdersDump.Order_Number = int.Parse(arrayInfo[3]);
                                oN = arrayInfo[3];
                                objOrdersDump.Order_Date = DateTime.Parse(arrayInfo[4]);
                                objOrdersDump.Old_Order_Number = int.Parse(arrayInfo[5]);
                                objOrdersDump.Being_Modified = Convert.ToBoolean(int.Parse(arrayInfo[6]));//bool.Parse(arrayInfo[6]);
                                objOrdersDump.Modifying = arrayInfo[7];
                                objOrdersDump.Customer_Code = int.Parse(arrayInfo[8]);
                                objOrdersDump.Customer_Room = arrayInfo[9];
                                objOrdersDump.Customer_Name = arrayInfo[10];
                                objOrdersDump.Comments = arrayInfo[11];
                                DateTime? AOD = null;
                                if (arrayInfo[12] != string.Empty) AOD = DateTime.Parse(arrayInfo[12]);
                                objOrdersDump.Actual_Order_Date = AOD;
                                objOrdersDump.Order_Status_Code = int.Parse(arrayInfo[13]);
                                objOrdersDump.Order_Type_Code = arrayInfo[14];
                                DateTime? OS = null;
                                if (arrayInfo[15] != string.Empty) OS = DateTime.Parse(arrayInfo[15]);
                                objOrdersDump.Order_Saved = OS;
                                objOrdersDump.Order_Time = int.Parse(arrayInfo[16]);
                                objOrdersDump.Sales_Tax1 = decimal.Parse(arrayInfo[17]);
                                objOrdersDump.Sales_Tax2 = decimal.Parse(arrayInfo[18]);
                                objOrdersDump.Coupon_Total = decimal.Parse(arrayInfo[19]);
                                objOrdersDump.SubTotal = decimal.Parse(arrayInfo[20]);
                                DateTime? RT = null;
                                if (arrayInfo[21] != string.Empty) RT = DateTime.Parse(arrayInfo[21]);
                                objOrdersDump.Route_Time = RT;
                                objOrdersDump.Driver_ID = arrayInfo[22];
                                objOrdersDump.Driver_Shift = arrayInfo[23];
                                DateTime? RTim = null;
                                if (arrayInfo[24] != string.Empty) RTim = DateTime.Parse(arrayInfo[24]);
                                objOrdersDump.Return_Time = RTim;
                                DateTime? DT = null;
                                if (arrayInfo[25] != string.Empty) DT = DateTime.Parse(arrayInfo[25]);
                                objOrdersDump.Delivery_Time = DT;
                                objOrdersDump.Delivery_Fee = decimal.Parse(arrayInfo[26]);
                                objOrdersDump.Taxable_Sales1 = decimal.Parse(arrayInfo[27]);
                                objOrdersDump.Taxable_Sales2 = decimal.Parse(arrayInfo[28]);
                                objOrdersDump.Non_Taxable_Sales = decimal.Parse(arrayInfo[29]);
                                objOrdersDump.Computer_Name = arrayInfo[30];
                                objOrdersDump.Added_By = arrayInfo[31];
                                DateTime? Ad = null;
                                if (arrayInfo[32] != string.Empty) Ad = DateTime.Parse(arrayInfo[32]);
                                objOrdersDump.Added = Ad;
                                objOrdersDump.Cancel_Reason = arrayInfo[33];
                                objOrdersDump.Added_By_Location_Code = arrayInfo[34];
                                objOrdersDump.Source_Code = arrayInfo[35];
                                objOrdersDump.BottleDepTotal = decimal.Parse(arrayInfo[36]);
                                objOrdersDump.Discount_Amount = decimal.Parse(arrayInfo[37]);
                                objOrdersDump.Void_Canc_Auth_Code = arrayInfo[38];
                                objOrdersDump.OrderRevNbr = int.Parse(arrayInfo[39]);
                                DateTime? OTCT = null;
                                if (arrayInfo[40] != string.Empty) OTCT = DateTime.Parse(arrayInfo[40]);
                                objOrdersDump.OrderTakeCompleteTime = OTCT;
                                int? OLTS = null;
                                if (arrayInfo[41] != string.Empty) OLTS = int.Parse(arrayInfo[41]);
                                objOrdersDump.OrderLoadTimeSecs = OLTS;
                                int? ORTS = null;
                                if (arrayInfo[42] != string.Empty) ORTS = int.Parse(arrayInfo[42]);
                                objOrdersDump.OrderRackTimeSecs = ORTS;
                                int? ODTS = null;
                                if (arrayInfo[43] != string.Empty) ODTS = int.Parse(arrayInfo[43]);
                                objOrdersDump.OrderDispatchTimeSecs = ODTS;
                                int? ODeTS = null;
                                if (arrayInfo[44] != string.Empty) ODeTS = int.Parse(arrayInfo[44]);
                                objOrdersDump.OrderDeliveryTimeSecs = ODeTS;
                                objOrdersDump.OrderListPrice = decimal.Parse(arrayInfo[45]);
                                objOrdersDump.OrderMenuDiscountAmt = decimal.Parse(arrayInfo[46]);
                                objOrdersDump.OrderLineDiscountAmt = decimal.Parse(arrayInfo[47]);
                                objOrdersDump.OrderDiscountAmt = decimal.Parse(arrayInfo[48]);
                                objOrdersDump.OrderFinalPrice = decimal.Parse(arrayInfo[49]);
                                objOrdersDump.OrderRoyaltySales = decimal.Parse(arrayInfo[50]);
                                decimal? OIFC = null;
                                if (arrayInfo[51] != string.Empty) OIFC = decimal.Parse(arrayInfo[51]);
                                objOrdersDump.OrderIdealFoodCost = OIFC;
                                objOrdersDump.OrderEditCount = int.Parse(arrayInfo[52]);
                                objOrdersDump.EditEmployeeCode = arrayInfo[53];
                                DateTime? OED = null;
                                if (arrayInfo[54] != string.Empty) OED = DateTime.Parse(arrayInfo[54]);
                                objOrdersDump.OrderEditDate = OED;
                                objOrdersDump.OrderReprintCount = int.Parse(arrayInfo[55]);
                                objOrdersDump.ReprintEmployeeCode = arrayInfo[56];
                                DateTime? ORD = null;
                                if (arrayInfo[57] != string.Empty) ORD = DateTime.Parse(arrayInfo[57]);
                                objOrdersDump.OrderReprintDate = ORD;
                                int? ORSS = null;
                                if (arrayInfo[58] != string.Empty) ORSS = int.Parse(arrayInfo[58]);
                                objOrdersDump.OrderRunStopSeq = ORSS;
                                int? ORSC = null;
                                if (arrayInfo[59] != string.Empty) ORSC = int.Parse(arrayInfo[59]);
                                objOrdersDump.OrderRunStopCount = ORSC;
                                objOrdersDump.UpdateEmployeeCode = arrayInfo[60];
                                objOrdersDump.OrderUpdateDate = DateTime.Parse(arrayInfo[61]);
                                objOrdersDump.OrderIsTaxExempt = Convert.ToBoolean(int.Parse(arrayInfo[62]));
                                objOrdersDump.OrderTaxExemptCode = arrayInfo[63];
                                objOrdersDump.OrderIsTaxExempt2 = Convert.ToBoolean(int.Parse(arrayInfo[64]));
                                objOrdersDump.OrderTaxExemptCode2 = arrayInfo[65];
                                bool? OIPC = null;
                                if (arrayInfo[66] != string.Empty) OIPC = Convert.ToBoolean(int.Parse(arrayInfo[66]));
                                objOrdersDump.OrderIsPersonalCar = OIPC;
                                objOrdersDump.OrderHasLabelPrinted = Convert.ToBoolean(int.Parse(arrayInfo[67]));
                                objOrdersDump.OrderHasReceiptPrinted = Convert.ToBoolean(int.Parse(arrayInfo[68]));
                                objOrdersDump.OrderPaymentDueAmt = decimal.Parse(arrayInfo[69]);
                                objOrdersDump.OrderPhoneNumber = arrayInfo[70];
                                objOrdersDump.OrderPhoneExt = arrayInfo[71];
                                objOrdersDump.OrderCompanyName = arrayInfo[72];
                                objOrdersDump.OrderStreetNumber = arrayInfo[73];
                                objOrdersDump.OrderStreetName = arrayInfo[74];
                                objOrdersDump.OrderAddressLine2 = arrayInfo[75];
                                objOrdersDump.OrderAddressLine3 = arrayInfo[76];
                                objOrdersDump.OrderAddressLine4 = arrayInfo[77];
                                objOrdersDump.OrderPostalCode = arrayInfo[78];
                                objOrdersDump.OrderCityName = arrayInfo[79];
                                objOrdersDump.OrderRegionName = arrayInfo[80];
                                objOrdersDump.OrderAddressType = arrayInfo[81];
                                objOrdersDump.DatabaseVersion = arrayInfo[82];
                                DateTime? OCT = null;
                                if (arrayInfo[83] != string.Empty) OCT = DateTime.Parse(arrayInfo[83]);
                                objOrdersDump.OrderCompletedTime = OCT;
                                decimal? OM = null;
                                if (arrayInfo[84] != string.Empty) OM = decimal.Parse(arrayInfo[84]);
                                objOrdersDump.OutboundMileage = OM;
                                decimal? RM = null;
                                if (arrayInfo[85] != string.Empty) RM = decimal.Parse(arrayInfo[85]);
                                objOrdersDump.ReturnMileage = RM;
                                objOrdersDump.MileageSource = arrayInfo[86];
                                objOrdersDump.AuthorizeEmployeeCode = arrayInfo[87];
                                objOrdersDump.VehicleCode = arrayInfo[88];
                                objOrdersDump.OrderSavedBusinessDate = DateTime.Parse(arrayInfo[89]);
                                DateTime? CDT = null;
                                if (arrayInfo[90] != string.Empty) CDT = DateTime.Parse(arrayInfo[90]);
                                objOrdersDump.CalculatedDeliveryTime = CDT;
                                int? CDTS = null;
                                if (arrayInfo[91] != string.Empty) CDTS = int.Parse(arrayInfo[91]);
                                objOrdersDump.CalculatedDeliveryTimeSecs = CDTS;
                                int? ODT = null;
                                if (arrayInfo[92] != string.Empty) ODT = int.Parse(arrayInfo[92]);
                                objOrdersDump.OutboundDriveTimeSecs = ODT;
                                int? RDS = null;
                                if (arrayInfo[93] != string.Empty) RDS = int.Parse(arrayInfo[93]);
                                objOrdersDump.ReturnDriveTimeSecs = RDS;
                                objOrdersDump.DriveTimeSource = arrayInfo[94];
                                DateTime? CRT = null;
                                if (arrayInfo[95] != string.Empty) CRT = DateTime.Parse(arrayInfo[95]);
                                objOrdersDump.CalculatedReturnTime = CRT;
                                objOrdersDump.ISVerifyCallback = Convert.ToBoolean(int.Parse(arrayInfo[96]));
                                InsertOrdersDump(objOrdersDump);

                                RegisterFile objRegisterFile = objRegisterFileBLL.CreateRegisterFile(objFile);
                                RegisterFileDAL objRegisterFileDAL = new RegisterFileDAL();
                                objRegisterFileDAL.UpDateRegisterFileOR2(objRegisterFile);
                                objFile.TotalCorrect++;
                            }
                            catch (Exception ex)
                            {
                                objFile.TotalError++;
                                string one = oN;
                            }
                        }
                    }
                }
                numLine++;
            }
        }
        #endregion

        #region DAL
        private void InsertOrdersDump(OrdersDump param)
        {
            OrdersDumpDAL dal = new OrdersDumpDAL();
            dal.InsertOrdersDump(param);
        }
        #endregion
    }
}