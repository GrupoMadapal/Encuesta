using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Globalization;
using Poleo.BLL;
using Poleo.Objects;
using Poleo.Enumn;


namespace Poleo.Pages
{
    public partial class Pag_SEF : System.Web.UI.Page
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

        /*public bool IsManager
        {
            get
            {
                int? IdUser = (int)Session["_IdUser"];
                UserXRolBLL objUserXRolBLL = new UserXRolBLL();

                return objUserXRolBLL.IsManager(IdUser.Value);
            }
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            Store Company = (Store)Enum.Parse(typeof(Store), Request.QueryString["E"].ToString(), true);
            LoadCtrls(Company);


            if (!IsPostBack)
            {
                LoadgrdRegister();
            }
            
            /*
            if (!IsPostBack)
            {

                //string iDPage = Request.QueryString["IDPage"];

               // if (!string.IsNullOrEmpty(iDPage))
                    //LoadObjectControls(int.Parse(iDPage));
               // else
                    LoadgrdRegister();

                //PaymentTypeLoad();
            }
            else
            {
                LoadgrdRegister();
            }*/

        }

        /*private void LoadInitControls()
        {
            User objUser = (User)Session["UserObj"];

            txtUserName.Text = objUser.Name + " " + objUser.LastName;
            hfdIdUser.Value = objUser.IDUser.ToString();
        }*/
        private void LoadCtrls(Store Company)
        {
            switch (Company)
            {
                case Store.SE:
                    lblTitle.Text = "ALTAS";
                    //lblstrTotal.Text = "TOTAL FACTURADO :";
                    rowRegister.Visible = true;
                    LoadDDLRegister();
                    //tblCancelSEF.Visible = true;
                    break;   
                case Store.WK:
                    lblTitle.Text = "MODIFICAR MOTOCICLETAS";
                    rowEditing.Visible = true;
                    LoadDDLNumEco();
                    break;
            }
        }

        #region Grid Register Motorcycles
        private DataTable GetEmptyRow()
        {
            DataTable TableEmpty = new DataTable();

            TableEmpty.Columns.Add("Year");
            TableEmpty.Columns.Add("Model");
            TableEmpty.Columns.Add("Serial");
            TableEmpty.Columns.Add("LicenseNumberPlate");
            TableEmpty.Columns.Add("NumberStore");
            TableEmpty.Columns.Add("NumEco");
            TableEmpty.Columns.Add("Location");
            TableEmpty.Columns.Add("Status");
            TableEmpty.Columns.Add("Reason");
            TableEmpty.Columns.Add("IDMotorcycle");
            TableEmpty.Columns.Add("IDLocation");
            TableEmpty.Columns.Add("IDStatus");

            DataRow NewRow = TableEmpty.NewRow();

            TableEmpty.Rows.Add(NewRow);

            return TableEmpty;
        }

        private void LoadgrdRegister()
        {
            grdRegister.DataSource = GetEmptyRow();
            grdRegister.DataBind();
        }

        public void LoadDDLNumEco()
        {
            SEF_MotorcyclesBLL objTiendaBLL = new SEF_MotorcyclesBLL();
            SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
            IList<SEF_Motorcycles> lstNumEco = new List<SEF_Motorcycles>();

            lstNumEco = objTiendaBLL.SelectNumEco(objSEF_Motorcycles);

             //Llenar el DDL con las sucursales 
            cmbSearching.Items.Insert(0, new ListItem("---", "-1"));

            cmbSearching.DataSource = lstNumEco;
            cmbSearching.DataTextField = "NumEco";
            cmbSearching.DataValueField = "IDMotorcycle";            
            cmbSearching.DataBind();

            
        }

        public void LoadDDLRegister()
        {
            ModelsBLL objModelsBLL = new ModelsBLL();
            Models objModels = new Models();
            IList<Models> lstModels = new List<Models>();

            lstModels = objModelsBLL.SelectModels();            

            cmbModel.DataSource = lstModels;
            cmbModel.DataValueField = "IDModel";
            cmbModel.DataTextField = "Model";
            cmbModel.DataBind();

            //cmbModel.Items.Insert(0, new ListItem("---", "-1"));

            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinder = new Tienda();
            IList<Tienda> lstTienda = new List<Tienda>();

            lstTienda = objTiendaBLL.selectTiendaUp();            

            cmbLocation.DataSource = lstTienda;
            cmbLocation.DataValueField = "Ubicacion";
            cmbLocation.DataTextField = "Ubicacion";
            cmbLocation.DataBind();

            lstTienda = objTiendaBLL.SelectTiendasOrden(objFinder);

            cmbNumberStore.DataSource = lstTienda;
            cmbNumberStore.DataValueField = "Number_tienda";
            cmbNumberStore.DataTextField = "Nombre_tienda";
            cmbNumberStore.DataBind();
            //cmbConcept.Items.Insert(0, new ListItem("---", "-1"));
        }

        public bool IsReapeted
        {
            get
            {
                SEF_MotorcyclesBLL objSEF_MotorcyclesBLL = new SEF_MotorcyclesBLL();

                string serial = txtSerial.Text;
                return objSEF_MotorcyclesBLL.IsRepeated(serial);
            }
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

           /* try
            {
                SEF_MotorcyclesBLL objSEF_MotorcyclesBLL = new SEF_MotorcyclesBLL();
                SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
                //User objUser = (User)Session["UserObj"];

                int idPettyCash = 0;

                objSEF_Motorcycles.Status = "Activa";
                //objPettyCash.BusinessCard = chkBusinnesCard.Checked; - Modified by Hector Sanchez M. 20180517

                if (string.IsNullOrEmpty(hfdIdPettyCash.Value))
                {
                    string numberPetty = ConfigurationManager.AppSettings["PrefixDocPetty"] + objSEF_MotorcyclesBLL.GetConsecutiveNumber();
                    objSEF_Motorcycles.NumberPetty = numberPetty;

                    idPettyCash = objSEF_MotorcyclesBLL.InsertObject(objSEF_Motorcycles);
                }
                else
                {
                    objSEF_Motorcycles.IDPettyCash = idPettyCash = int.Parse(hfdIdPettyCash.Value);
                    objSEF_Motorcycles.NumberPetty = txtNumberPettyCash.Text;

                    objSEF_MotorcyclesBLL.UpdateObject(objSEF_Motorcycles);
                }

                InsertPettyCashDetail(idPettyCash);

                LoadObjectControls(idPettyCash);

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message + " " + ex.StackTrace;
            }*/
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
            SEF_MotorcyclesBLL objSEF_MotorcyclesBLL = new SEF_MotorcyclesBLL();

            

            objSEF_Motorcycles.Year = int.Parse(txtYear.Text);
            objSEF_Motorcycles.Model = int.Parse(cmbModel.SelectedValue);
            objSEF_Motorcycles.Serial = txtSerial.Text;
            objSEF_Motorcycles.LicenseNumberPlate = txtLicenseNumberPlate.Text;
            objSEF_Motorcycles.NumEco = txtNumEco.Text;
            objSEF_Motorcycles.Location = cmbLocation.SelectedItem.ToString(); 
            objSEF_Motorcycles.Status = 1;
            objSEF_Motorcycles.Commentaries = string.Empty;
            objSEF_Motorcycles.Reason = string.Empty;
            objSEF_Motorcycles.Replaced = string.Empty;
            objSEF_Motorcycles.NumberStore = int.Parse(cmbNumberStore.SelectedValue);
            
            if (IsValid)
            {
                if (IsReapeted)
                {
                    string script = "window.alert('Serial repetido. Favor de ingresar otro numero de Serial');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    return;
                }               
                else
                { objSEF_MotorcyclesBLL.InsertSEF_Motorcycles(objSEF_Motorcycles); }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SEF_MotorcyclesBLL objMotorcyclesBLL = new SEF_MotorcyclesBLL();
            SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
            IList<SEF_Motorcycles> lstSearch = new List<SEF_Motorcycles>();

            objSEF_Motorcycles.NumEco = cmbSearching.SelectedItem.Text;
            lstSearch = objMotorcyclesBLL.SelectVehicle(objSEF_Motorcycles);

            
            grdRegister.DataSource = lstSearch;
            grdRegister.DataBind();
            grdRegister.Visible = true;
        }

        #endregion

        protected void grdRegister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TiendaBLL objTiendaBLL = new TiendaBLL();
                Tienda objFinder = new Tienda();
                IList<Tienda> lstTienda = new List<Tienda>();

                lstTienda = objTiendaBLL.SelectTiendasOrden(objFinder);

                DropDownList cmbNumberStore = (DropDownList)e.Row.FindControl("cmbNumberStore"); //Llenar el DDL con las sucursales 

                cmbNumberStore.DataSource = lstTienda;
                cmbNumberStore.DataValueField = "Nombre_Tienda";
                cmbNumberStore.DataTextField = "Nombre_tienda";
                cmbNumberStore.DataBind();

                cmbNumberStore.Items.Insert(0, new ListItem("---", "-1"));
               
                lstTienda = objTiendaBLL.selectTiendaUp();

                DropDownList cmbConcept = (DropDownList)e.Row.FindControl("cmbLocation");

                cmbConcept.DataSource = lstTienda;
                cmbConcept.DataValueField = "Ubicacion";
                cmbConcept.DataTextField = "Ubicacion";
                cmbConcept.DataBind();

                cmbConcept.Items.Insert(0, new ListItem("---", "-1"));
           }*/
        }

        protected void grdRegister_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void grdRegister_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdRegister.EditIndex = e.NewEditIndex;

            //enlaza la info con los DDL's correspondientes 
            SEF_MotorcyclesBLL objMotorcyclesBLL = new SEF_MotorcyclesBLL();
            SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
            IList<SEF_Motorcycles> lstSearch = new List<SEF_Motorcycles>();

            objSEF_Motorcycles.NumEco = cmbSearching.SelectedItem.Text;
            lstSearch = objMotorcyclesBLL.SelectVehicle(objSEF_Motorcycles);

            grdRegister.DataSource = lstSearch;
            grdRegister.DataBind();

            Tienda objFinder = new Tienda();
            IList<Tienda> lstTienda = new List<Tienda>();
            TiendaBLL objTiendaBLL = new TiendaBLL();

            lstTienda = objTiendaBLL.SelectTiendasOrden(objFinder);

            DropDownList cmbNumberStore = (DropDownList)grdRegister.Rows[e.NewEditIndex].FindControl("cmbNumberStore");
            HiddenField hfdIdNumberStore = (HiddenField)grdRegister.Rows[e.NewEditIndex].FindControl("hfdIdNumberStore");

            cmbNumberStore.DataSource = lstTienda;
            cmbNumberStore.DataValueField = "Number_tienda";
            cmbNumberStore.DataTextField = "Nombre_tienda";
            cmbNumberStore.DataBind();

            if (hfdIdNumberStore != null && !string.IsNullOrEmpty(hfdIdNumberStore.Value))
                cmbNumberStore.SelectedValue = hfdIdNumberStore.Value;

                       lstTienda = objTiendaBLL.selectTiendaUp();

            DropDownList cmbLocation = (DropDownList)grdRegister.Rows[e.NewEditIndex].FindControl("cmbLocation");
            HiddenField hfdIDLocation = (HiddenField)grdRegister.Rows[e.NewEditIndex].FindControl("hfdIDlocation");

            cmbLocation.DataSource = lstTienda;
            cmbLocation.DataValueField = "Ubicacion";
            cmbLocation.DataTextField = "Ubicacion";
            cmbLocation.DataBind();

            if (hfdIDLocation != null && !string.IsNullOrEmpty(hfdIDLocation.Value))
                cmbLocation.SelectedValue = hfdIDLocation.Value;

            ModelsBLL objModelsBLL = new ModelsBLL();
            Models objModels = new Models();
            IList<Models> lstModels = new List<Models>();

            lstModels = objModelsBLL.SelectModels();

            DropDownList cmbModel = (DropDownList)grdRegister.Rows[e.NewEditIndex].FindControl("cmbModel");
            HiddenField hfdIdModel = (HiddenField)grdRegister.Rows[e.NewEditIndex].FindControl("hfdIModel");

            cmbModel.DataSource = lstModels;
            cmbModel.DataValueField = "IDModel";
            cmbModel.DataTextField = "Model";
            cmbModel.DataBind();

            if (hfdIdModel != null && !string.IsNullOrEmpty(hfdIdModel.Value))
                cmbLocation.SelectedValue = hfdIdModel.Value;

            Estatus objStatus = new Estatus();
            EstatusBLL objStatusBLL = new EstatusBLL();
            IList<Estatus> lstStatus = new List<Estatus>();

            lstStatus = objStatusBLL.SelectStatus();

            DropDownList cmbStatus = (DropDownList)grdRegister.Rows[e.NewEditIndex].FindControl("cmbStatus");
            HiddenField hfdIdStatus = (HiddenField)grdRegister.Rows[e.NewEditIndex].FindControl("hfdIdStatus");

            cmbStatus.DataSource = lstStatus;
            cmbStatus.DataValueField = "IdStatus";
            cmbStatus.DataTextField = "Status";
            cmbStatus.DataBind();

            if (hfdIdStatus != null && !string.IsNullOrEmpty(hfdIdStatus.Value))
                cmbStatus.SelectedValue = hfdIdStatus.Value;

        }

        protected void grdRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SEF_MotorcyclesBLL objSEF_MotorcyclesBLL = new SEF_MotorcyclesBLL();
            SEF_Motorcycles objSEF_Motorcycles = new SEF_Motorcycles();
            int idMotorcycles = int.Parse(grdRegister.DataKeys[e.RowIndex].Value.ToString());

            bool validRegister = true;
            objSEF_Motorcycles.IDMotorcycle = idMotorcycles;

            TextBox txtYear = (TextBox)grdRegister.Rows[e.RowIndex].FindControl("txtYear");
            objSEF_Motorcycles.Year = int.Parse(txtYear.Text);

            DropDownList cmbModel = (DropDownList)grdRegister.Rows[e.RowIndex].FindControl("cmbModel");
            objSEF_Motorcycles.Model = int.Parse(cmbModel.SelectedValue);

            TextBox txtSerial = (TextBox)grdRegister.Rows[e.RowIndex].FindControl("txtSerial");
            objSEF_Motorcycles.Serial = txtSerial.Text;

            TextBox txtLicenseNumberPlate = (TextBox)grdRegister.Rows[e.RowIndex].FindControl("txtLicenseNumberPlate");
            objSEF_Motorcycles.LicenseNumberPlate = txtLicenseNumberPlate.Text;

            DropDownList cmbNumberStore = (DropDownList)grdRegister.Rows[e.RowIndex].FindControl("cmbNumberStore");
            objSEF_Motorcycles.NumberStore = int.Parse(cmbNumberStore.SelectedValue);

            TextBox txtNumEco = (TextBox)grdRegister.Rows[e.RowIndex].FindControl("txtNumEco");
            objSEF_Motorcycles.NumEco = txtNumEco.Text;

            DropDownList cmbLocation = (DropDownList)grdRegister.Rows[e.RowIndex].FindControl("cmbLocation");
            objSEF_Motorcycles.Location = cmbLocation.SelectedItem.ToString();

            DropDownList cmbStatus = (DropDownList)grdRegister.Rows[e.RowIndex].FindControl("cmbStatus");
            objSEF_Motorcycles.Status = int.Parse(cmbStatus.SelectedValue);

            if(IsValid)
            {
                
                objSEF_MotorcyclesBLL.UpdateVehicle(objSEF_Motorcycles);

                grdRegister.EditIndex = -1;
                LoadgrdRegister();
            }

            

            HiddenField hfdIdCompany = (HiddenField)grdRegister.Rows[e.RowIndex].FindControl("hfdIdCompany");
        }

        protected void grdRegister_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grdRegister_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void cmbRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}