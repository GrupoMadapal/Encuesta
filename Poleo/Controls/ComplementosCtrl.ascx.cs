using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.BLL;
using Poleo.Objects;

namespace Poleo.Controls
{
    public partial class ComplementosCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public VentasFinder objFilter
        {
            get
            {
                return (VentasFinder)ViewState["objFilter"];
            }
            set
            {
                ViewState["objFilter"] = value;
            }
        }
        public void fillDataGrid()
        {
            ComplementosBLL BLL = new ComplementosBLL();
            GridViewCom.DataSource= BLL.Selectcomplementos(objFilter);
            GridViewCom.DataBind();
            
        }
    }
}