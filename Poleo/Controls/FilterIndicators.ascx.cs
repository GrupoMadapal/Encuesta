using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.BLL;
using Poleo.Objects;
using Poleo.DAL;
using System.Globalization;
using Poleo.Enumn;

namespace Poleo.Controls
{
    public partial class FilterIndicators : System.Web.UI.UserControl
    {
        #region PROPERTIES
        public Store TypeFilter
        {
            get;
            set;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                consultarUbicaciones();
            }
        }

        public object GetFiltersField()
        {
            //String strUbicacion = lstUbicacion.SelectedValue;
            //String strTipo = lstTiposTienda.SelectedValue;
            //String strTienda = LstTiendas.SelectedValue;
            //String strNumSemana = fecha.SelectedValue;
            String strFechaInicial = TextBoxStart.Text;
            String StrFechaFinal = TextBoxEnd.Text;
            int numSemana = -1;

            if (String.IsNullOrEmpty(strFechaInicial) && String.IsNullOrEmpty(StrFechaFinal))
            {
                throw new Exception("Error: La fecha inicial y final son obligatorias");
            }
            //int.TryParse(strNumSemana, out numSemana);

            if (TypeFilter == Store.DP)
            {
                VentasFinder objVentasFinder = new VentasFinder()
                {
                    DateIni = DateTime.Parse(TextBoxStart.Text),//, new CultureInfo("en-CA")),
                    DateEnd = DateTime.Parse(TextBoxEnd.Text),//, new CultureInfo("en-CA")),
                    //NumTienda = LstTiendas.SelectedIndex > 1 ? LstTiendas.SelectedValue.Split(new char[] { '-' })[0] : String.Empty,
                    //UbicacionTienda = lstUbicacion.SelectedIndex > 1 ? lstUbicacion.SelectedValue : String.Empty,
                    //TipoTienda = lstTiposTienda.SelectedIndex > 1 ? lstTiposTienda.SelectedValue : String.Empty,
                    NumeroSemana = numSemana,
                    //IndicadorFull = CheckBox1.Checked,
                    //SelectYear = int.Parse(DDLYears.Text)
                };
                return objVentasFinder;
            }
            else
            {
                DQ_VentasFinder objDQ_VentasFinder = new DQ_VentasFinder()
                {
                    FechaIni = DateTime.Parse(TextBoxStart.Text),
                    FechaEnd = DateTime.Parse(TextBoxEnd.Text),
                    //SelectYear = int.Parse(DDLYears.Text)
                };

                return objDQ_VentasFinder;
            }
        }

        private void consultarUbicaciones()
        {
            switch (TypeFilter)
            { 
                case Store.DP:
                    TiendaDAL objTiendaDal = new TiendaDAL();
                    //IList<Tienda> lstUbicaciones = objTiendaDal.selectTiendaUp();
                    //lstUbicacion.Items.Clear();
                    //lstUbicacion.Items.Add("--- Select ---");
                    //lstUbicacion.Items.Add("ALL");
                    //foreach (Tienda item in lstUbicaciones)
                    //{
                    //    lstUbicacion.Items.Add(item.Ubicacion);
                    //}

                    GetYear();

                    //Added by Hector Sanchez M. 20151217 - Add ddlCupon
                    //Commented by Hector Sanchez M. 20161012
                    //CuponesDAL objCuponesDAL = new CuponesDAL();
                    //IList<Cupones> lstCupones = new List<Cupones>();
                    //lstCupones = objCuponesDAL.SelectCuponsByDDL(new Cupones());
                    //ddlCupon.DataSource = lstCupones;
                    //ddlCupon.DataValueField = "Codigo";
                    //ddlCupon.DataTextField = "Descripcion";
                    //ddlCupon.DataBind();
                    ////ddlCupon.Items.Add(new ListItem("--- Select ---", "-1"));
                    //ddlCupon.Items.Insert(0, new ListItem("--- Select ---", "-1"));
                    //ddlCupon.SelectedValue = "-1";
                    break;
                case Store.DQ:
                default:
                    //lstUbicacion.Enabled = false;
                    //lstTiposTienda.Enabled = false;
                    //LstTiendas.Enabled = false;
                    //ddlCupon.Enabled = false;

                    GetYear();
                    break;
            };
        }

        //Added by Hector Sanchez M. 20160311
        private void GetYear()
         {
            Año objAño = new Año();

            //DDLYears.DataSource = objAño.GetsYear();
            //DDLYears.DataBind();

            //fecha.Items.Clear();
            //fecha.Items.Add("--- Select ---");
            //for (int i = 0; i < 53; i++)
            //{
            //    fecha.Items.Add(i.ToString());
            //}
            GetNumberWeek();
        }

        protected void lstUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiendaBLL BLL = new TiendaBLL();
            //Tienda ObjFinder = new Tienda() { Ubicacion = lstUbicacion.SelectedItem.Value != "ALL" ? lstUbicacion.SelectedItem.Value : String.Empty };
            //IList<Tienda> lstTipos = BLL.SelectTipoTienda(ObjFinder);
            //lstTiposTienda.Items.Clear();
            //lstTiposTienda.Items.Add("--- Select ---");
            //lstTiposTienda.Items.Add("ALL");
            //foreach (Tienda item in lstTipos)
            //{
            //    lstTiposTienda.Items.Add(item.Tipo);
            //}
        }

        protected void lstTiposTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiendaBLL BLL = new TiendaBLL();
            Tienda objFinder = new Tienda()
            {
                //Ubicacion = lstUbicacion.SelectedItem.Value != "ALL" ? lstUbicacion.SelectedItem.Value : String.Empty,
                //Tipo = lstTiposTienda.SelectedItem.Value != "ALL" ? lstTiposTienda.SelectedItem.Value : String.Empty
            };
            IList<Tienda> lstTiendas = BLL.SelectTiendas(objFinder);

            //LstTiendas.Items.Clear();
            //LstTiendas.Items.Add("--- Select ---");
            //LstTiendas.Items.Add("ALL");
            //foreach (Tienda item in lstTiendas)
            //{
            //    LstTiendas.Items.Add(item.Number_tienda + "--" + item.Nombre_tienda);
            //}
        }

        protected void fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (fecha.SelectedIndex > 0)
            //{
            //    //Semana objSemana = new Semana(int.Parse(fecha.SelectedValue) + 1, int.Parse(DDLYears.SelectedValue));
            //    Semana objSemana = new Semana(int.Parse(fecha.SelectedValue), int.Parse(DDLYears.SelectedValue));
            //    TextBoxStart.Text = objSemana.FechaInicial.ToString("dd/MM/yyyy", new CultureInfo("en-CA"));
            //    TextBoxEnd.Text = objSemana.FechaFinal.ToString("dd/MM/yyyy", new CultureInfo("en-CA"));
            //}
            //else
            //{
            //    TextBoxStart.Text = String.Empty;
            //    TextBoxEnd.Text = String.Empty;
            //}
        }

        //Added by Hector Sanchez M. 20151228
        protected void GetNumberWeek()
        {
            AnioBLL objAnioBLL = new AnioBLL();
            //int year = int.Parse(DDLYears.SelectedItem.Text);
            int InitalCount = 1;

            //int TW = objAnioBLL.TotalWeekForYear(year);

            //if (TW == 53)
            //{
            //    #region COMMENTED BY LEO FOR 53
            //    //InitalCount = 0;
            //   // TW--;
            //    #endregion
                
            //}

            //fecha.Items.Clear();
            //fecha.Items.Add("--- Select ---");
            //for (int i = InitalCount; i <= TW; i++)
            //{
            //    fecha.Items.Add(i.ToString());
            //}

            SelectNumberWeek();
        }

        //Added by Hector Sanchez M. 20151228
        protected void DDLYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNumberWeek();
        }

        //Commented by Hector Sanchez M- 20161012
        //public string GetValueCupons()
        //{
        //    if (ddlCupon.SelectedValue == "-1")
        //        return string.Empty;
        //    else
        //        return ddlCupon.SelectedValue;
        //}

        private void SelectNumberWeek()
        {
            //AnioBLL objAnioBLL = new AnioBLL();

            //fecha.SelectedValue = objAnioBLL.GetWeekNumber(DateTime.Now).ToString();
            //fecha_SelectedIndexChanged(null, null);
        }
    }
}