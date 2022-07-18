using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.BLL;
using Poleo.Objects;
using Poleo.Enumn;

namespace Poleo.Pages
{
    public partial class Pag_InfoTR : System.Web.UI.Page
    {
        public bool ViewOnlyDQ
        {
            get;
            set;
        }

        public bool ViewInfoSales
        {
            get;
            set;
        }

        public bool IsManager
        {
            get
            {
                int? IdUser = (int)Session["_IdUser"];
                UserXRolBLL objUserXRolBLL = new UserXRolBLL();

                return objUserXRolBLL.IsManager(IdUser.Value);
            }
        }

        private IList<int> LstObjects
        {
            get
            {
                ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();
                IList<int> lstObjects = new List<int>();
                lstObjects = objObjectsXUserBLL.SelectObjectsByUser((int)Session["_IdUser"]);

                return lstObjects;
            }
        }

        #region EVENTS
        protected void Page_Load(object sender, EventArgs e)
        {
            Store Company = (Store)Enum.Parse(typeof(Store), Request.QueryString["E"].ToString(), true);

            LoadCtrls(Company);
            LoadInfo(Company);

            if (IsManager)
                btnView_Click(null, null);

            IfReloadPage();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objTienda = new Tienda();
            

            objTienda = ctrlFilter.GetValuesFilter();

            //if (IsManager)
            //{
            //    int? IdUser = (int)Session["_IdUser"];

            //    if (string.IsNullOrEmpty(objTienda.Ubicacion) && string.IsNullOrEmpty(objTienda.Number_tienda))
            //        objTienda.Ubicacion = objTiendaBLL.SelectStoreByUserID(IdUser.Value).Ubicacion;
            //}

            Store Company = (Store)Enum.Parse(typeof(Store), Request.QueryString["E"].ToString(), true);

            switch (Company) { 
                case Store.DP:
                    lstTienda = objTiendaBLL.SelectTiendas(objTienda);
                    rowSalesStore.Visible = true;
                    break;
                case Store.DQ:
                    lstTienda = objTiendaBLL.SelectDQTiendas(objTienda);
                    rowSalesStore.Visible = true;
                    break;
            }

            if (IsManager)
                ViewInfoSales = false;
            else
                ViewInfoSales = ctrlFilter.ViewInfo;

            LoadInfoStore(Company, lstTienda);

            //IfReloadPage();
        }
        #endregion

        #region METHODS
        private void LoadCtrls(Store Company)
        {
            switch (Company) 
            {
                case Store.SE:
                    ctrlFilter.TypeFilter = Enumn.Store.SE;
                    lblTitle.Text = "FONTANERIA";
                    lblstrTotal.Text = "TOTAL FACTURADO :";
                    rowCobrosSef.Visible = true;
                    tblCancelSEF.Visible = true;
                    break;
                case Store.DP:
                    ctrlFilter.TypeFilter = Enumn.Store.DP;
                    lblTitle.Text = "DOMINO´S PIZZA";
                    rowOrder.Visible = !IsManager;
                    rowTotal.Visible = !IsManager;
                    break;
                case Store.DQ:
                    ctrlFilter.TypeFilter = Enumn.Store.DQ;
                    lblTitle.Text = "DAIRY QUEEN";
                    tblDQ.Visible = true;
                    ViewOnlyDQ = true;
                    rowOrder.Visible = true;
                    break;
                case Store.RL:
                    ctrlFilter.TypeFilter = Enumn.Store.RL;
                    lblTitle.Text = "INMOBILIARIA";
                    lblstrTotal.Text = "TOTAL FACTURADO :";
                    rowCobrosSef.Visible = true;
                    break;
                case Store.MD:
                    ctrlFilter.TypeFilter = Enumn.Store.RL;
                    lblTitle.Text = "MADAPAL";
                    lblstrTotal.Text = "TOTAL FACTURADO :";
                    rowCobrosSef.Visible = true;
                    break;
            }
        }

        private void LoadInfo(Store Company)
        {
            InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
            InfoTiempoReal objInfoTiempoReal = new InfoTiempoReal();

            InfoTiempoReal objInfoTiempoRealCobros = new InfoTiempoReal();
            SEF_VentasBLL objSEF_VentasBLL = new SEF_VentasBLL();  

            switch (Company) { 
                case Store.DQ:
                    DQ_VentasBLL objDQ_VentasBLL = new DQ_VentasBLL();

                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;

                    objInfoTiempoReal = objDQ_VentasBLL.SelectVentasDQOnLine(objInfoTiempoRealFinder);

                    if (objInfoTiempoReal != null)
                    {
                        lblTotal.Text = objInfoTiempoReal.VentasReales.ToString("C");//.VentasTotales.ToString("C");
                        lblOrdenes.Text = objInfoTiempoReal.Ordenes.ToString();
                        lblPasteles.Text = objInfoTiempoReal.Pasteles.ToString();
                    }
                    else
                    {
                        lblTotal.Text = "0";
                        lblOrdenes.Text = "0";
                        lblPasteles.Text = "0";
                    }
                    break;
                case Store.SE:
                    InfoTiempoReal objInfoTiempoRealCancelado = new InfoTiempoReal();

                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;

                    objInfoTiempoReal = objSEF_VentasBLL.SelectVentasSEFOnLine(objInfoTiempoRealFinder);
                    objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosSEFOnLine(objInfoTiempoRealFinder);
                    objInfoTiempoRealCancelado = objSEF_VentasBLL.SelectCanceladoSEFOnLine(objInfoTiempoRealFinder);

                    lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                    lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                    lblTotalCancel.Text = objInfoTiempoRealCancelado.VentasTotales.ToString("C");
                    break;
                case Store.DP:
                    DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();

                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;

                    if (LstObjects.Contains(15))
                    {
                        IList<Tienda> lstTienda = new List<Tienda>();
                        TiendaBLL objTiendaBLL = new TiendaBLL();
                        Tienda objTienda = new Tienda();
                        
                        objTienda = ctrlFilter.GetValuesFilter();

                        lstTienda = objTiendaBLL.SelectTiendas(objTienda);

                        objInfoTiempoRealFinder.LstNumTienda = objTiendaBLL.GetStringNumberStore(lstTienda);
                    }

                    objInfoTiempoReal = objDOT_VentasBLL.SelectVentasDPOnLine(objInfoTiempoRealFinder);

                    if (objInfoTiempoReal != null && !IsManager)
                    {
                        lblTotal.Text = objInfoTiempoReal.VentasReales.ToString("C");//.VentasTotales.ToString("C");
                        lblOrdenes.Text = objInfoTiempoReal.Ordenes.ToString();
                    }
                    else
                    {
                        lblTotal.Text = "0";
                        lblOrdenes.Text = "0";
                    }
                    break;
                case Store.RL:
                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;

                    objInfoTiempoReal = objSEF_VentasBLL.SelectVentasRAALOnLine(objInfoTiempoRealFinder);
                    objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosRAALOnLine(objInfoTiempoRealFinder);

                    lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                    lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                    break;
                case Store.MD:
                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;

                    objInfoTiempoReal = objSEF_VentasBLL.SelectVentasMADAPALOnLine(objInfoTiempoRealFinder);
                    objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosMADAPALOnLine(objInfoTiempoRealFinder);

                    lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                    lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                    break;
            }
        }

        private void LoadInfoStore(Store Company, IList<Tienda> lstTienda)
        {
            InfoTiempoReal objInfoTiempoRealFinder = new InfoTiempoReal();
            IList<InfoTiempoReal> lstInfoTiempoReal = new List<InfoTiempoReal>();
            TiendaBLL objTiendaBLL = new TiendaBLL();
            
            InfoTiempoReal objInfoTiempoRealCobros = new InfoTiempoReal();
            InfoTiempoReal objInfoTiempoReal = new InfoTiempoReal();
            SEF_VentasBLL objSEF_VentasBLL = new SEF_VentasBLL();
            VentasFinder objVentasFinder = new VentasFinder();

            switch (Company) { 
                case Store.DQ:
                    DQ_VentasBLL objDQ_VentasBLL = new DQ_VentasBLL();
                    
                    objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;
                    objInfoTiempoRealFinder.LstNumTienda = objTiendaBLL.GetStringNumberStore(lstTienda);

                    lstInfoTiempoReal = objDQ_VentasBLL.SelectVentasDQOnLineTienda(objInfoTiempoRealFinder);

                    rptInfoStoreDQ.DataSource = lstInfoTiempoReal;

                    rptInfoStoreDQ.DataBind();
                    break;
                case Store.SE:
                    InfoTiempoReal objInfoTiempoRealCancelado = new InfoTiempoReal();

                    objVentasFinder = ctrlFilter.GetDateFilter();

                    if (objVentasFinder != null)
                    {
                        objInfoTiempoRealFinder.RangeDate = true;
                        objInfoTiempoRealFinder.Fecha = objVentasFinder.DateIni.Value;
                        objInfoTiempoRealFinder.FechaEnd = objVentasFinder.DateEnd.Value;

                        objInfoTiempoReal = objSEF_VentasBLL.SelectVentasSEFOnLine(objInfoTiempoRealFinder);
                        objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosSEFOnLine(objInfoTiempoRealFinder);
                        objInfoTiempoRealCancelado = objSEF_VentasBLL.SelectCanceladoSEFOnLine(objInfoTiempoRealFinder);

                        lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                        lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                        lblTotalCancel.Text = objInfoTiempoRealCancelado.VentasTotales.ToString("C");
                    }
                    break;
                case Store.DP:
                    //Modified by Hector Sanchez M. 20170702
                    //DOT_VentasBLL objDOT_VentasBLL = new DOT_VentasBLL();

                    //objInfoTiempoRealFinder.Fecha = DateTime.Now.Date;
                    //objInfoTiempoRealFinder.LstNumTienda = objTiendaBLL.GetStringNumberStore(lstTienda);

                    //lstInfoTiempoReal = objDOT_VentasBLL.SelectVentasDPOnLineTienda(objInfoTiempoRealFinder);

                    //rptInfoStoreDP.DataSource = lstInfoTiempoReal;

                    //rptInfoStoreDP.DataBind();
                    
                    SalesDPViewBLL objSalesDPViewBLL = new SalesDPViewBLL();
                    IList<SalesDP> lstSalesDP = new List<SalesDP>();
                    SalesDP objSalesDP = new SalesDP();

                    objSalesDP.LstNumTienda = objTiendaBLL.GetStringNumberStore(lstTienda);

                    lstSalesDP = objSalesDPViewBLL.selectLstSalesDPView(objSalesDP);

                    rptInfoStoreDP.DataSource = lstSalesDP;

                    rptInfoStoreDP.DataBind();
                    break;
                case Store.RL:
                    objVentasFinder = ctrlFilter.GetDateFilter();

                    if (objVentasFinder != null)
                    {
                        objInfoTiempoRealFinder.RangeDate = true;
                        objInfoTiempoRealFinder.Fecha = objVentasFinder.DateIni.Value;
                        objInfoTiempoRealFinder.FechaEnd = objVentasFinder.DateEnd.Value;

                        objInfoTiempoReal = objSEF_VentasBLL.SelectVentasRAALOnLine(objInfoTiempoRealFinder);
                        objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosRAALOnLine(objInfoTiempoRealFinder);

                        lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                        lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                    }
                    break;
                case Store.MD:
                    objVentasFinder = ctrlFilter.GetDateFilter();

                    if (objVentasFinder != null)
                    {
                        objInfoTiempoRealFinder.RangeDate = true;
                        objInfoTiempoRealFinder.Fecha = objVentasFinder.DateIni.Value;
                        objInfoTiempoRealFinder.FechaEnd = objVentasFinder.DateEnd.Value;

                        objInfoTiempoReal = objSEF_VentasBLL.SelectVentasMADAPALOnLine(objInfoTiempoRealFinder);
                        objInfoTiempoRealCobros = objSEF_VentasBLL.SelectCobrosMADAPALOnLine(objInfoTiempoRealFinder);

                        lblTotal.Text = objInfoTiempoReal.VentasTotales.ToString("C");
                        lblTotalC.Text = objInfoTiempoRealCobros.TotalCobros.ToString("C");
                    }
                    break;
            }
        }

        private void IfReloadPage()
        {
            if (LstObjects.Contains(15))
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "window.onload = timedRefresh(900000);", true);
        }
        #endregion
    }
} 