using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Tools;
using Poleo.BLL;

namespace Poleo.Objects
{
    public class InfoTiempoReal
    {
        private DateTime fecha;
        private DateTime fechaEnd;
        private string numTienda;
        private string nombreTienda;
        private decimal ventasReales;
        private decimal ventasTotales;
        private decimal totalCobros;
        private IList<int> lstNumTienda;
        private bool rangeDate = false;
        private int ordenes;
        private int pasteles;
        private decimal loadTime;
        private decimal estimatedDeliveryTime;
        private string strClassEH;
        private string strClassED;
        //private int orderFree;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime FechaEnd
        {
            get { return fechaEnd; }
            set { fechaEnd = value; }
        }

        public string NumTienda
        {
            get { return numTienda; }
            set { numTienda = value; }
        }

        public string NombreTienda
        {
            get { return nombreTienda; }
            set { nombreTienda = value; }
        }

        public decimal VentasReales
        {
            get { return ventasReales; }
            set { ventasReales = value; }
        }

        public decimal VentasTotales
        {
            get { return ventasTotales; }
            set { ventasTotales = value; }
        }

        public decimal TotalCobros
        {
            get { return totalCobros; }
            set { totalCobros = value; }
        }

        public IList<int> LstNumTienda
        {
            get { return lstNumTienda; }
            set { lstNumTienda = value; }
        }

        public bool RangeDate
        {
            get { return rangeDate; }
            set { rangeDate = value; }
        }

        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }

        public int Pasteles
        {
            get { return pasteles; }
            set { pasteles = value; }
        }

        public decimal LoadTime
        {
            get { return loadTime; }
            set { loadTime = value; }
        }

        public decimal EstimatedDeliveryTime
        {
            get { return estimatedDeliveryTime; }
            set { estimatedDeliveryTime = value; }
        }

        public string StrClassEH
        {
            get { return strClassEH; }
            set { strClassEH = value; }
        }

        public string StrClassED
        {
            get { return strClassED; }
            set { strClassED = value; }
        }

        //public int OrderFree
        //{
        //    get { return orderFree; }
        //    set { orderFree = value; }
        //}

        public int OrderFree//strOrderFree
        {
            get
            {
                DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
                int of = 0;
                //InfoTiempoReal objInfoTiempoRealResult = new InfoTiempoReal();

                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = Fecha;

                //objInfoTiempoRealResult = objDOT_VentasBLL.GetFreeOrders(objInfoTiempoRealFinder);
                of = objDOT_VentasBLL.GetFreeOrders(objInfoTiempoRealFinder);
                return of;//objInfoTiempoRealResult.OrderFree.ToString();
            }
        }

        public int OrderCancel
        {
            get
            {
                DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
                int oc = 0;

                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = Fecha;

                oc = objDOT_VentasBLL.GetGetCancelOrders(objInfoTiempoRealFinder);

                return oc;
            }
        }

        public decimal SecsLoadTime
        {
            get
            {
                DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
                InfoTiempoReal objInfoTiempoRealResult = new InfoTiempoReal();

                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = Fecha;

                objInfoTiempoRealResult = objDOT_VentasBLL.GetEntradaHornoStore(objInfoTiempoRealFinder);

                return objInfoTiempoRealResult.LoadTime;
            }
        }

        public string EntryOven
        {
            get 
            {
                string strEH;

                decimal PorcEntradaHorno = SecsLoadTime / Ordenes;
                int sec = decimal.ToInt32(PorcEntradaHorno); //int.Parse(PorcEntradaHorno.ToString());

                if (sec > 179)
                    strClassEH = "messageError";
                else
                    strClassEH = string.Empty;

                strEH = ToolsTime.ConvertSecondsToHMS(sec);

                return ToolsTime.FormatHMS(strEH);
            }
        }

        public decimal SalesLastYear
        {
            get
            {
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
                VentasBLL objVentasBLL = new VentasBLL();
                AnioBLL objAnioBLL = new AnioBLL();
                
                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = objAnioBLL.GetLastYearDate(Fecha);//Fecha.AddYears(-1);

                return objVentasBLL.SelectSalesLastYearOnLine(objInfoTiempoRealFinder);
            }
        }

        private decimal DeliveryTime
        {
            get
            {
                DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
                //InfoTiempoReal objInfoTiempoRealResult = new InfoTiempoReal();
                decimal dt;

                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = Fecha;

                dt = objDOT_VentasBLL.GetLoadEstimatedDeliveryTime(objInfoTiempoRealFinder);

                //if (dt >= 24)
                //    strClassED = "messageError";
                //else
                //    strClassED = string.Empty;

                return dt;//objInfoTiempoRealResult.EstimatedDeliveryTime;
            }
        }

        public string strDeliverTime
        {
            get
            {
                string strTE;

                //decimal PorcTiempoEntrega = DeliveryTime / Ordenes;
                int sec = decimal.ToInt32(DeliveryTime);

                if (sec > 1439)
                    strClassED = "messageError";
                else
                    strClassED = string.Empty;

                strTE = ToolsTime.ConvertSecondsToHMS(sec);

                return ToolsTime.FormatHMS(strTE);
            }
        }

        public string PorcSales
        {
            get
            {
                decimal porcSales = 0;

                if(SalesLastYear !=0)
                    porcSales = VentasReales / SalesLastYear;

                return String.Format("{0:P2}", porcSales);
            }
        }

        //Added by Hector Sanchez M. 20171113
        public decimal Deposito
        {
            get
            {
                DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();
                InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();

                decimal? td = 0;

                objInfoTiempoRealFinder.NumTienda = NumTienda;
                objInfoTiempoRealFinder.Fecha = Fecha;

                td = objDOT_VentasBLL.GetTotalDeposit(objInfoTiempoRealFinder);

                if (td != null)
                    return td.Value;
                else
                    return 0;
            }
        }
    }
} 