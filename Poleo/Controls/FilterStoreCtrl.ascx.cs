using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.Objects;
using Poleo.BLL;
using Poleo.Enumn;

namespace Poleo.Controls
{
    public partial class FilterStoreCtrl : System.Web.UI.UserControl
    {
        #region Properties
        public Store TypeFilter
        {
            get;
            set;
        }

        public bool ViewInfo
        {
            get 
            {
                if (ddlViewInfo.SelectedValue == "1")
                    return true;
                else
                    return false;
            }
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
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadCtrlByStore();
        }
        
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda ObjFinder = new Tienda();

            ObjFinder.Ubicacion = ddlLocation.SelectedItem.Value != "ALL" ? ddlLocation.SelectedItem.Value : String.Empty;
            IList<Tienda> lstTipos = objTiendaBLL.SelectTipoTienda(ObjFinder);

            ddlType.DataSource = lstTipos;
            ddlType.DataTextField = "Tipo";
            ddlType.DataBind();

            ddlType.Items.Insert(0, new ListItem("--- Select ---", string.Empty));

            ddlType_SelectedIndexChanged(null, null);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinder = new Tienda();

            objFinder.Ubicacion = ddlLocation.SelectedItem.Value != "ALL" ? ddlLocation.SelectedItem.Value : String.Empty;
            objFinder.Tipo = ddlType.SelectedItem.Value != "ALL" ? ddlType.SelectedItem.Value : String.Empty;

            IList<Tienda> lstTiendas = objTiendaBLL.SelectTiendas(objFinder);

            ddlStore.DataSource = lstTiendas;
            ddlStore.DataValueField = "Number_tienda";
            ddlStore.DataTextField = "Nombre_tienda";
            ddlStore.DataBind();

            ddlStore.Items.Insert(0, new ListItem("--- Select ---", string.Empty));
        }
        #endregion

        #region Methods
        private void LoadCtrlByStore()
        {
            switch(TypeFilter)
            { 
                case Store.DP:
                    TiendaBLL objTiendaBLL = new TiendaBLL();
                    int? IdUser = (int)Session["_IdUser"];

                    LoadddlLocation();
                    ddlLocation_SelectedIndexChanged(null, null);
                    ddlType_SelectedIndexChanged(null, null);
                    lblViewInfo.Visible = true;
                    ddlViewInfo.Visible = true;
                    if (IsManager)
                        ddlViewInfo.Enabled = false;
                    break;
                case Store.DQ:
                    LoadddlStoreDQ();
                    ddlLocation.Enabled = false;
                    ddlType.Enabled = false;
                    break;
                case Store.SE:
                case Store.RL:
                case Store.MD:
                    tblDate.Visible = true;
                    tblStore.Visible = false;
                    break;
            }
        }

        private void LoadddlLocation()
        {
            int? IdUser = (int)Session["_IdUser"];
            TiendaBLL objTiendaBLL = new TiendaBLL();
            IList<Tienda> lstUbicaciones = objTiendaBLL.selectTiendaUp();

            ddlLocation.DataSource = lstUbicaciones;
            ddlLocation.DataTextField = "Ubicacion";
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("--- Select ---", string.Empty));

            if (IsManager)
                ddlLocation.SelectedValue = objTiendaBLL.SelectStoreByUserID(IdUser.Value).Ubicacion;
        }

        private void LoadddlStoreDQ()
        {
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();

            lstTienda = objTiendaBLL.SelectDQTiendas(new Tienda());

            ddlStore.DataSource = lstTienda;
            ddlStore.DataValueField = "Number_tienda";
            ddlStore.DataTextField = "Nombre_tienda";
            ddlStore.DataBind();

            ddlStore.Items.Insert(0, new ListItem("--- Select ---", string.Empty));
            //ddlStore.Items.Insert(1, new ListItem("ALL"));
        }

        public Tienda GetValuesFilter()
        {
            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objTienda = new Tienda();
            
            objTienda.Tipo = ddlType.SelectedValue;
            objTienda.Number_tienda = ddlStore.SelectedValue;

            if (IsManager)
            {
                int? IdUser = (int)Session["_IdUser"];

                if (string.IsNullOrEmpty(ddlLocation.SelectedValue) && string.IsNullOrEmpty(objTienda.Number_tienda))
                    objTienda.Ubicacion = objTiendaBLL.SelectStoreByUserID(IdUser.Value).Ubicacion;
                else
                    objTienda.Ubicacion = ddlLocation.SelectedValue;
            }
            else
                objTienda.Ubicacion = ddlLocation.SelectedValue;

            return objTienda;
        }

        public VentasFinder GetDateFilter()
        {
            VentasFinder objVentasFinder = null;

            if (!string.IsNullOrEmpty(txtDateIni.Text) && !string.IsNullOrEmpty(txtDateEnd.Text))
            {
                objVentasFinder = new VentasFinder();

                objVentasFinder.DateIni = DateTime.Parse(txtDateIni.Text);
                objVentasFinder.DateEnd = DateTime.Parse(txtDateEnd.Text);

                lblErrormsg.Visible = false;
            }
            else
            {
                lblErrormsg.Text = "Seleccione un rango de fechas.";
                lblErrormsg.Visible = true;
            }

            return objVentasFinder;
        }
        #endregion
    }
}