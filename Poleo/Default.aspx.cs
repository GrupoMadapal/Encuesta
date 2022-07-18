using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Poleo.Objects;
using System.Globalization;
using Poleo.DAL;
using Poleo.BLL;
namespace Poleo
{
    public partial class _Default : Page
    {
        public string CorreoTienda
        {
            get { return (string)Session["correoTiendaS_"]; }
            set { Session["correoTiendaS_"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Move To FilterIndicators(~/Controls/FilterIndicators.ascx)
            //if (!IsPostBack)
            //{
            //    consultarUbicaciones();
            //}
            CorreoTienda = Context.User.Identity.Name;
            lblUser.Text = "Bienvenido: " + Context.User.Identity.Name;
        }

    //    private VentasFinder ValidateFiltersField(int typeFile)
    //    {
    //        String strUbicacion = lstUbicacion.SelectedValue;
    //        String strTipo = lstTiposTienda.SelectedValue;
    //        String strTienda = LstTiendas.SelectedValue;
    //        String strNumSemana = fecha.SelectedValue;
    //        String strFechaInicial = TextBoxStart.Text;
    //        String StrFechaFinal = TextBoxEnd.Text;
    //        int numSemana=-1;

    //        if(String.IsNullOrEmpty(strFechaInicial)&&String.IsNullOrEmpty(StrFechaFinal))
    //        {
    //            throw new Exception("Error: La fecha inicial y final son obligatorias");
    //        }
    //        int.TryParse(strNumSemana, out numSemana);           
    //        VentasFinder objVentasFinder = new VentasFinder()
    //        {
    //            DateIni = DateTime.Parse(TextBoxStart.Text, new CultureInfo("en-CA")),
    //            DateEnd = DateTime.Parse(TextBoxEnd.Text, new CultureInfo("en-CA")),
    //            NumTienda = LstTiendas.SelectedIndex>1 ? LstTiendas.SelectedValue.Split(new char[] { '-' })[0] : String.Empty,
    //            UbicacionTienda = lstUbicacion.SelectedIndex>1 ? lstUbicacion.SelectedValue : String.Empty,
    //            TipoTienda = lstTiposTienda.SelectedIndex>1? lstTiposTienda.SelectedValue : String.Empty,
    //            NumeroSemana = numSemana,
    //            IndicadorFull = CheckBox1.Checked,
    //            SelectYear = int.Parse(DDLYears.Text)
    //        };
    //        return objVentasFinder;
    //    }

    //    //Move To FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    public void consultarUbicaciones()
    //    {
    //        TiendaDAL objTiendaDal = new TiendaDAL();
    //        IList<Tienda> lstUbicaciones = objTiendaDal.selectTiendaUp();
    //        lstUbicacion.Items.Clear();
    //        lstUbicacion.Items.Add("--- Select ---");
    //        lstUbicacion.Items.Add("ALL");
    //        foreach(Tienda item in lstUbicaciones)
    //        {
    //            lstUbicacion.Items.Add(item.Ubicacion);
    //        }

    //        Año objAño = new Año();

    //        DDLYears.DataSource = objAño.GetsYear();
    //        DDLYears.DataBind();

    //        //fecha.Items.Clear();
    //        //fecha.Items.Add("--- Select ---");
    //        //for (int i = 0; i < 53; i++)
    //        //{
    //        //    fecha.Items.Add(i.ToString());
    //        //}
    //        GetNumberWeek();

    //        //Added by Hector Sanchez M. 20151217 - Add ddlCupon
    //        CuponesDAL objCuponesDAL = new CuponesDAL();
    //        IList<Cupones> lstCupones = new List<Cupones>();
    //        lstCupones = objCuponesDAL.SelectCuponsByDDL();
    //        ddlCupon.DataSource = lstCupones;
    //        ddlCupon.DataValueField = "Codigo";
    //        ddlCupon.DataTextField = "Descripcion";
    //        ddlCupon.DataBind();
    //        //ddlCupon.Items.Add(new ListItem("--- Select ---", "-1"));
    //        ddlCupon.Items.Insert(0, new ListItem("--- Select ---", "-1"));
    //        ddlCupon.SelectedValue = "-1";
    //    }
    //    #region TO DELETE
    //    //public void consultarTiendas ()
    //    //{
    //    //    SqlConnection sqlConnection1 = new SqlConnection("data source= SISTEMAS-PC\\SQLEXPRESS ; Initial Catalog=Madapal;Integrated Security=True");
    //    //    SqlCommand cmd = new SqlCommand();
    //    //    SqlDataReader reader;
    //    //    List<Tienda> lstTiendas = new List<Tienda>();

    //    //    cmd.CommandText = "SELECT * FROM Tiendas";
    //    //    cmd.CommandType = CommandType.Text;
    //    //    cmd.Connection = sqlConnection1;

    //    //    sqlConnection1.Open();

    //    //    reader = cmd.ExecuteReader();
    //    //    // Data is accessible through the DataReader object here.
    //    //    while(reader.Read())
    //    //    {
    //    //        Tienda objTienda = new Tienda();
    //    //        objTienda.Nombre_Tienda = reader.GetValue(0).ToString();
    //    //        objTienda.Numero_tienda = reader.GetValue(1).ToString();
    //    //        lstTiendas.Add(objTienda);
    //    //    }
    //    //    LstTiendas.Items.Clear();
    //    //    LstTiendas.Items.Add("-----");
    //    //    foreach(Tienda item in lstTiendas)
    //    //    {
    //    //        LstTiendas.Items.Add(item.Numero_tienda+"-"+item.Nombre_Tienda);
                
    //    //    }            
    //    //    sqlConnection1.Close();
    //    //}
    //    //public void ventas()
    //    //{
    //    //    SqlConnection sqlConnection1 = new SqlConnection("data source= SISTEMAS-PC\\SQLEXPRESS ; Initial Catalog=Madapal;Integrated Security=True");
    //    //    SqlCommand cmd = new SqlCommand();
    //    //    SqlDataReader reader;
    //    //    List<Ventas> lstVentas = new List<Ventas>();

    //    //    cmd.CommandText = "SELECT EndDate ,Master_Sales	,Void_Sales	,Bad_Sales,Total_Sales,Total_Sales*0.16 ,Net_Sales,Delivery_Sales,Carryout_Sales, Location_Code FROM KeysExtractsCorpVersion order by EndDate ";
    //    //    //cmd.Parameters.Add("@DateIni", SqlDbType.DateTime);
    //    //    //cmd.Parameters.Add("@DateEnd", SqlDbType.DateTime);
    //    //    //cmd.Parameters.Add("@Tienda", SqlDbType.DateTime);
    //    //    //cmd.Parameters["@DateIni"].Value = DateStart.SelectedDate;
    //    //    //cmd.Parameters["@DateEnd"].Value = DateEnd.SelectedDate;
    //    //    //cmd.Parameters["@tienda"].Value = LstTiendas.SelectedItem;

    //    //    cmd.CommandType = CommandType.Text;
    //    //    cmd.Connection = sqlConnection1;

    //    //    sqlConnection1.Open();

    //    //    reader = cmd.ExecuteReader();
    //    //    // Data is accessible through the DataReader object here.
    //    //    while (reader.Read())
    //    //    {
    //    //        Ventas objVentas = new Ventas();
    //    //        CultureInfo ci = new CultureInfo("Es-Es");
                
    //    //        objVentas.Fecha = reader.GetDateTime(0).ToString("d");
    //    //        objVentas.Dia = ci.DateTimeFormat.GetDayName( reader.GetDateTime(0).DayOfWeek);
    //    //        objVentas.VentasBrutas = reader.GetDecimal(1);
    //    //        objVentas.Canceladas = reader.GetDecimal(2);
    //    //        objVentas.OrdenesMalas = reader.GetDecimal(3);
    //    //        objVentas.VentasNetas = reader.GetDecimal(4);
    //    //        objVentas.IVA = reader.GetDecimal(5);
    //    //        objVentas.VentasReales = reader.GetDecimal(6);
    //    //        objVentas.VentasReparto = reader.GetDecimal(7);
    //    //        objVentas.VentasMostrador = reader.GetDecimal(8);
    //    //        objVentas.Tienda = reader.GetString(9);
    //    //        lstVentas.Add(objVentas);
                
    //    //    }
    //    //    GridViewVentas.DataSource = lstVentas;
    //    //    GridViewVentas.DataBind();


    //    //}
    //    #endregion

    //    //Move To FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void btnFiltro_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            idCTLVentas.Visible = true;
    //            idCTLVentas.FechaIni = objVentasFinder.DateIni.ToString();
    //            idCTLVentas.FechaEnd = objVentasFinder.DateEnd.ToString();
    //            idCTLVentas.Tienda = objVentasFinder.NumTienda;
    //            idCTLVentas.TipoTienda = objVentasFinder.TipoTienda;
    //            idCTLVentas.Ubicacion = objVentasFinder.UbicacionTienda;
    //            idCTLVentas.llenaControl();                
    //            //PizzasCtrl.Visible = true;
    //            //PizzasCtrl.objFilter = objVentasFinder;
    //            //PizzasCtrl.fillDataGrid();
    //            //ComCtrl.Visible = true;
    //            //ComCtrl.objFilter = objVentasFinder;
    //            //ComCtrl.fillDataGrid();
    //            lblMesajeError.Visible = false;
    //        }catch(Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }




    //    }

    //    protected void LstTiendas_SelectedIndexChanged(object sender, EventArgs e)
    //    {
            
    //    }

    //    //Move To FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void lstUbicacion_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        TiendaBLL BLL = new TiendaBLL();
    //        Tienda ObjFinder = new Tienda() { Ubicacion = lstUbicacion.SelectedItem.Value != "ALL" ? lstUbicacion.SelectedItem.Value : String.Empty };
    //        IList<Tienda> lstTipos = BLL.SelectTipoTienda(ObjFinder);
    //        lstTiposTienda.Items.Clear();
    //        lstTiposTienda.Items.Add("--- Select ---");
    //        lstTiposTienda.Items.Add("ALL");
    //        foreach (Tienda item in lstTipos)
    //        {
    //            lstTiposTienda.Items.Add(item.Tipo);
    //        }
    //    }

    //    //Move to FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void lstTiposTienda_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        TiendaBLL BLL = new TiendaBLL();
    //        Tienda objFinder = new Tienda() { 
    //            Ubicacion = lstUbicacion.SelectedItem.Value!="ALL"?lstUbicacion.SelectedItem.Value: String.Empty,
    //            Tipo = lstTiposTienda.SelectedItem.Value != "ALL" ? lstTiposTienda.SelectedItem.Value : String.Empty 
    //        };
    //        IList<Tienda> lstTiendas = BLL.SelectTiendas(objFinder);

    //        LstTiendas.Items.Clear();
    //        LstTiendas.Items.Add("--- Select ---");
    //        LstTiendas.Items.Add("ALL");
    //        foreach (Tienda item in lstTiendas)
    //        {
    //            LstTiendas.Items.Add(item.Number_tienda + "--" + item.Nombre_tienda);
                
    //        }

    //    }

    //    protected void fecha_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        if (fecha.SelectedIndex > 0)
    //        {
    //            //Semana objSemana = new Semana(int.Parse(fecha.SelectedValue) + 1, int.Parse(DDLYears.SelectedValue));
    //            Semana objSemana = new Semana(int.Parse(fecha.SelectedValue), int.Parse(DDLYears.SelectedValue));
    //            TextBoxStart.Text = objSemana.FechaInicial.ToString("dd/MM/yyyy", new CultureInfo("en-CA"));
    //            TextBoxEnd.Text = objSemana.FechaFinal.ToString("dd/MM/yyyy", new CultureInfo("en-CA")); 
    //        }
    //        else
    //        {
    //            TextBoxStart.Text = String.Empty;
    //            TextBoxEnd.Text = String.Empty;
    //        }
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            int year = int.Parse(DDLYears.SelectedItem.Text);

    //            if (year < 0)
    //                year = DateTime.Now.Year;

    //            VentasBLL objVentasBLL = new VentasBLL();
    //            string name = objVentasBLL.GenerateAutomaticFile(Server, year);
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            lblMesajeError.Visible = false;
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
            
            
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void BtnIndicadorExcel_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            IndicadorBLL BLL = new IndicadorBLL();
    //            string name = BLL.generateFormatIndicador(objVentasFinder, Server);
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            lblMesajeError.Visible = false;
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnVentasResumen_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            int year = int.Parse(DDLYears.SelectedItem.Text);

    //            if (year < 0)
    //                year = DateTime.Now.Year;

    //            VentasBLL objVentasBLL = new VentasBLL();
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            string name = objVentasBLL.GenerateResumenVentasV2(objVentasFinder, Server, year);
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            lblMesajeError.Visible = false;
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
            
    //    }

    //    //Move to Pag_DQ(~/Pages/Pag_DQ.aspx.cs)
    //    protected void btnVentasDQ_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            int year = int.Parse(DDLYears.SelectedItem.Text);

    //            if (year < 0)
    //                year = DateTime.Now.Year;

    //            VentasBLL objVentasBLL = new VentasBLL();
    //            DQ_VentasBLL objVentasDQBLL = new DQ_VentasBLL();
    //            string name = objVentasDQBLL.GetSalesDairyQueen(Server, year);
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            lblMesajeError.Visible = false;
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnIndMaestro_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            IndicadorMaestroBLL BLL = new IndicadorMaestroBLL();
    //            string name = BLL.generateFileVentas(objVentasFinder, Server);
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            lblMesajeError.Visible = false;
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnTransacciones_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            DepositosBLL objDepositosBLL = new DepositosBLL();
    //            string name = objDepositosBLL.generateFileVentas(objVentasFinder, Server);
    //            lblMesajeError.Visible = false;
    //            string attachment = "attachment; filename=" + name;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);                
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
    //    }

    //    //Move To FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void btnFiltro2_Click(object sender, ImageClickEventArgs e)
    //    {
    //        this.btnFiltro_Click(sender,null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnExcelVentas_Click(object sender, EventArgs e)
    //    {
    //        this.btnExcel_Click(sender, null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnVentasResumenText_Click(object sender, EventArgs e)
    //    {
    //        this.btnVentasResumen_Click(sender,null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void BtnIndicadorExcelText_Click(object sender, EventArgs e)
    //    {
    //        this.BtnIndicadorExcel_Click(sender, null);
    //    }

    //    //Move to Pag_DQ(~/Pages/Pag_DQ.aspx.cs)
    //    protected void btnVentasDQText_Click(object sender, EventArgs e)
    //    {
    //        this.btnVentasDQ_Click(sender, null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnIndMaestroText_Click(object sender, EventArgs e)
    //    {
    //        this.btnIndMaestro_Click(sender, null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnTransaccionesText_Click(object sender, EventArgs e)
    //    {
    //        this.btnTransacciones_Click(sender, null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnImgRanking_Click(object sender, ImageClickEventArgs e)
    //    {

    //        this.btnRanking_Click(sender, null);
    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnRanking_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            RankingFinder objRankingfinder = new RankingFinder();
    //            objRankingfinder.DateIni = objVentasFinder.DateIni.Value;
    //            objRankingfinder.DateEnd = objVentasFinder.DateEnd.Value;
    //            objRankingfinder.Tienda = objVentasFinder.NumTienda;
    //            objRankingfinder.TipoTienda = objVentasFinder.TipoTienda;
    //            objRankingfinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
    //            objRankingfinder.NumSemana = objVentasFinder.NumeroSemana;
    //            objRankingfinder.SelectYear = objVentasFinder.SelectYear;

    //            RankingBLL objRankingBLL = new RankingBLL();
    //            string name = objRankingBLL.generateReportRanking(objRankingfinder, Server);
    //            string attachment = "attachment; filename=" + name;
    //            lblMesajeError.Visible = false;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }

    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnimgCupon_Click(object sender, ImageClickEventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            OrdenesFinder objOrdenesFinder = new OrdenesFinder();
    //            objOrdenesFinder.DateIni = objVentasFinder.DateIni.Value;
    //            objOrdenesFinder.DateEnd = objVentasFinder.DateEnd.Value;
    //            objOrdenesFinder.NumTienda= objVentasFinder.NumTienda;
    //            objOrdenesFinder.TipoTienda = objVentasFinder.TipoTienda;
    //            objOrdenesFinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
    //            objOrdenesFinder.CodigoCupon = ddlCupon.SelectedValue == "-1" ? string.Empty : ddlCupon.SelectedValue; //txtCupon.Text; - Changed by Hector Sanchez M. 20151217

    //            OrdenesBLL objOrdenesBLL = new OrdenesBLL();
    //            string name = objOrdenesBLL.CreateExcelFileCupones(objOrdenesFinder, Server);
    //            string attachment = "attachment; filename=" + name;
    //            lblMesajeError.Visible = false;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }

    //    }

    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnCupon_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            VentasFinder objVentasFinder = this.ValidateFiltersField(0);
    //            OrdenesFinder objOrdenesFinder = new OrdenesFinder();
    //            objOrdenesFinder.DateIni = objVentasFinder.DateIni.Value;
    //            objOrdenesFinder.DateEnd = objVentasFinder.DateEnd.Value;
    //            objOrdenesFinder.NumTienda = objVentasFinder.NumTienda;
    //            objOrdenesFinder.TipoTienda = objVentasFinder.TipoTienda;
    //            objOrdenesFinder.UbicacionTienda = objVentasFinder.UbicacionTienda;
    //            objOrdenesFinder.CodigoCupon = ddlCupon.SelectedValue == "-1" ? string.Empty : ddlCupon.SelectedValue;//txtCupon.Text; - Changed by Hector Sanchez M. 20151217

    //            OrdenesBLL objOrdenesBLL = new OrdenesBLL();
    //            string name = objOrdenesBLL.CreateExcelFileCupones(objOrdenesFinder, Server);
    //            string attachment = "attachment; filename=" + name;
    //            lblMesajeError.Visible = false;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
    //    }

    //    //Added by Hector Sanchez M. 20151228
    //    //Move to FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void GetNumberWeek()
    //    {
    //        AnioBLL objAnioBLL = new AnioBLL();
    //        int year = int.Parse(DDLYears.SelectedItem.Text);
    //        int InitalCount = 1;

    //        int TW = objAnioBLL.TotalWeekForYear(year);

    //        if (TW == 53)
    //        {
    //            InitalCount = 0;
    //            TW--;
    //        }

    //        fecha.Items.Clear();
    //        fecha.Items.Add("--- Select ---");
    //        for (int i = InitalCount; i <= TW; i++)
    //        {
    //            fecha.Items.Add(i.ToString());
    //        }
    //    }

    //    //Added by Hector Sanchez M. 20151228
    //    //Move to FilterIndicators(~/Controls/FilterIndicators.ascx)
    //    protected void DDLYears_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        GetNumberWeek();
    //    }

    //    //Added by Hector Sanchez M. 20160122
    //    //Move to Pag_Dominos(~/Pages/Pag_Dominos.aspx.cs)
    //    protected void btnTiempoServicio_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            int year = int.Parse(DDLYears.SelectedItem.Text);

    //            if (year < 0)
    //                year = DateTime.Now.Year;

    //            TiempoServicioBLL objTiempoServicioBLL = new TiempoServicioBLL();
    //            string name = objTiempoServicioBLL.CreateExcelFileTiempoServicio(Server, year);
    //            string attachment = "attachment; filename=" + name;
    //            lblMesajeError.Visible = false;
    //            Response.ClearContent();
    //            Response.AddHeader("content-disposition", attachment);
    //            Response.ContentType = "application/ms-excel";
    //            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
    //            Response.End();
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMesajeError.Text = ex.Message;
    //            lblMesajeError.Visible = true;
    //        }
 
    //    }
    }
}