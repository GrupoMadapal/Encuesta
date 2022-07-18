using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.Objects;
using Poleo.BLL;

namespace Poleo.Controls
{
    public partial class VentasCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public String Ubicacion
        {
            get
            {
                return (String)ViewState["ubicacion"];
            }
            set
            {
                ViewState["ubicacion"] = value;
            }
        }
        public String TipoTienda
        {
            get
            {
                return (String)ViewState["tipoTienda"];
            }
            set
            {
                ViewState["tipoTienda"] = value;
            }
        }
        public String Tienda
        {
            get
            {
                return (String)ViewState["tienda"];
            }
            set
            {
                ViewState["tienda"] = value;
            }
        }
        public String FechaIni
        {
            get
            {
                return (String)ViewState["fechaIni"];
            }
            set
            {
                ViewState["fechaIni"] = value;
            }
        }
        public String FechaEnd
        {
            get
            {
                return (String)ViewState["fechaEnd"];
            }
            set
            {
                ViewState["fechaEnd"] = value;
            }
        }
        public void llenaControl()
        {
            VentasBLL BLLVentas = new VentasBLL();
            VentasFinder objVentasFinder = new VentasFinder()
            {
                DateIni = DateTime.Parse(FechaIni),
                DateEnd = DateTime.Parse(FechaEnd),
                NumTienda = Tienda,
                UbicacionTienda = Ubicacion,
                TipoTienda = TipoTienda

            };
            IList<Ventas> lstResultVentas = BLLVentas.SelectVentasGratis(objVentasFinder);
            //GridViewVentas.DataSource = lstResultVentas;
            //GridViewVentas.DataBind();
            IList<TotalSales> lstTotalSales = BLLVentas.ventasAcumuladas(objVentasFinder);
            //TotalDatagrid.DataSource = lstTotalSales;
            //TotalDatagrid.DataBind();
            repeatVentas.DataSource = lstResultVentas;
            repeatVentas.DataBind();
            repeatFull.DataSource = lstTotalSales;
            repeatFull.DataBind();
        }
            
    }
}