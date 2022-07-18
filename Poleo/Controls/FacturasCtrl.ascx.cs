using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.Objects;
using Poleo.BLL;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace Poleo.Controls
{
    public partial class FacturasCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ddlEstatusHead.Items.Clear();
            ddlEstatusHead.Items.Add("ALL");
            foreach (EstadosFacturas item in Enum.GetValues(typeof(EstadosFacturas)))
            {
                ddlEstatusHead.Items.Add(item.ToString());
            }
            ddlTipoProveedor.Items.Clear();
            ddlTipoProveedor.Items.Add("ALL");
            foreach (TipoProveedor item in Enum.GetValues(typeof(TipoProveedor)))
            {
                ddlTipoProveedor.Items.Add(item.ToString());
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            FacturasBLL objFacturasBLL = new FacturasBLL();
            //String fecha = txtFechaVigenciaFrom.Text;
            //Nullable<DateTime> FechaFacturaIni = txtFechaVigenciaFrom.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaVigenciaFrom.Text, new CultureInfo("en-CA")) : null;
            FacturasFinder objFacturasFinder = new FacturasFinder()
            {
                NombreProveedor = txtProveedor.Text.Length > 0 ? txtProveedor.Text : String.Empty,
                NombreEmpresa = txtEmpresa.Text.Length > 0 ? txtEmpresa.Text : String.Empty,
                Folio = txtFolio.Text.Length > 0 ? txtFolio.Text : String.Empty,
                FolioFiscal = txtFolioFiscal.Text.Length > 0 ? txtFolioFiscal.Text : String.Empty,
                EstatusFactura = ddlEstatusHead.SelectedValue == "ALL" ? String.Empty : ddlEstatusHead.SelectedValue,
                TipoProveedor = ddlTipoProveedor.SelectedValue == "ALL" ? String.Empty : ddlTipoProveedor.SelectedValue,
                Activo = ckbActivo.Checked,
                FechaFacturaIni=txtFechaFacturacionFrom.Text.Length>0?(Nullable<DateTime>)DateTime.Parse(txtFechaFacturacionFrom.Text, new CultureInfo("en-CA") ):null,
                FechaFacturaEnd = txtFechaFacturacionTo.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaFacturacionTo.Text, new CultureInfo("en-CA")) : null,
                FechaVencimientoIni = txtFechaVigenciaFrom.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaVigenciaFrom.Text, new CultureInfo("en-CA")) : null,
                FechaVencimientoEnd = txtFechaVigenciaTo.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaVigenciaTo.Text, new CultureInfo("en-CA")) : null,
                FechaPagoIni = txtFechaPagoFrom.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaPagoFrom.Text, new CultureInfo("en-CA")) : null,
                FechaPagoEnd = txtFechaPagoTo.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaPagoTo.Text, new CultureInfo("en-CA")) : null
            };
            IList<Facturas> lstFacturas = objFacturasBLL.SelectFacturaChange(objFacturasFinder);
            repeaterFacturas.DataSource = lstFacturas;
            repeaterFacturas.DataBind();

        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            FacturasBLL objFacturasBLL = new FacturasBLL();
            IList<Facturas> lstFacturas = this.GetFacturasofRepeater();
            foreach(Facturas item in lstFacturas )
            {
                objFacturasBLL.UpdateFacturas(item);
            }
            repeaterFacturas.DataSource = lstFacturas;
            repeaterFacturas.DataBind();
        }

        protected void repeaterFacturas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lblEstatus = (Label)e.Item.FindControl("lblEstatus");
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("trItem");
                TextBox txtFechaPago = (TextBox)e.Item.FindControl("txtFechaPago");
                DropDownList ddlEstatus = (DropDownList)e.Item.FindControl("ddlEstatus");
                txtFechaPago.Attributes.Add("disabled", "true");
                if (EstadosFacturas.CANCELADA.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#800000;");
                    txtFechaPago.Attributes.Add("style", "background-color:#800000;");
                }
                else if (EstadosFacturas.PAGADA.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#006E2E;");
                    txtFechaPago.Attributes.Add("style", "background-color:#006E2E;");
                    txtFechaPago.Attributes.Add("disabled", "false");
                }
                else if (EstadosFacturas.PROXIMAVENCIMIENTO.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#3F4C6B;");
                    txtFechaPago.Attributes.Add("style", "background-color:#3F4C6B;");
                }
                else if (EstadosFacturas.SUPRIMIDA.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#4B4B4B;");
                    txtFechaPago.Attributes.Add("style", "background-color:#4B4B4B;");
                }
                else if (EstadosFacturas.VENCIDA.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#C79810;");
                    txtFechaPago.Attributes.Add("style", "background-color:#C79810;");
                }
                else if (EstadosFacturas.INACTIVA.ToString() == lblEstatus.Text)
                {
                    tr.Attributes.Add("style", "background-color:#FA6800;");
                    txtFechaPago.Attributes.Add("style", "background-color:#FA6800;");
                }
                ddlEstatus.Items.Clear();
                foreach (EstadosFacturas item in Enum.GetValues(typeof(EstadosFacturas)))
                {
                    ddlEstatus.Items.Add(item.ToString());
                }
                if (lblEstatus.Text.Length > 0)
                {
                    ddlEstatus.Items.FindByValue(lblEstatus.Text).Selected = true;
                }
                
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProveedor.Text = String.Empty;
            txtEmpresa.Text = String.Empty;
            txtFechaFacturacionFrom.Text = String.Empty;
            txtFechaFacturacionTo.Text = String.Empty;
            txtFechaPagoFrom.Text = String.Empty;
            txtFechaPagoTo.Text = String.Empty;
            txtFechaVigenciaFrom.Text = String.Empty;
            txtFechaVigenciaTo.Text = String.Empty;
            txtFolio.Text = String.Empty;
            txtFolioFiscal.Text = String.Empty;
            ddlEstatusHead.Items.FindByValue("ALL").Selected = true;
            ddlTipoProveedor.Items.FindByValue("ALL").Selected = true;

        }

        protected void btbDownloadExcel_Click(object sender, ImageClickEventArgs e)
        {
            FacturasBLL objFacturasBLL = new FacturasBLL();
            IList<Facturas> lstFacturas = this.GetFacturasofRepeater();
            foreach (Facturas item in lstFacturas)
            {
                objFacturasBLL.UpdateFacturas(item);
            }
            FacturasFinder objFacturaFinder= new FacturasFinder()
            {
                FechaVencimientoIni = txtFechaVigenciaFrom.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaVigenciaFrom.Text, new CultureInfo("en-CA") ) : null,
                FechaVencimientoEnd = txtFechaVigenciaTo.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaVigenciaTo.Text, new CultureInfo("en-CA")) : null,
            };
            repeaterFacturas.DataSource = lstFacturas;
            repeaterFacturas.DataBind();
            string name = objFacturasBLL.GenerateExcelFacturas(lstFacturas,Server, objFacturaFinder);
            string attachment = "attachment; filename=" + name;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);

            Response.End();
        }

        private IList<Facturas> GetFacturasofRepeater()
        {
            List<Facturas> lstFacturas = new List<Facturas>();
            foreach (RepeaterItem item in repeaterFacturas.Items)
            {
                Label lblEmpresa = (Label)item.FindControl("lblEmpresa");
                Label lblIdFactura = (Label)item.FindControl("lblIDFactura");
                Label lblTipoProveedor = (Label)item.FindControl("lblTipoProveedor");
                Label lblProveedor = (Label)item.FindControl("lblProveedor");
                Label lblFolio = (Label)item.FindControl("lblFolio");
                Label lblFechaFactura = (Label)item.FindControl("lblFechaFactura");
                Label lblFechaVigencia = (Label)item.FindControl("lblFechaVigencia");
                Label lblSubTotal = (Label)item.FindControl("lblSubTotal");
                Label lblRetIVA = (Label)item.FindControl("lblRetIVA");
                Label lblRetISR = (Label)item.FindControl("lblRetISR");
                Label lblTrasIVA = (Label)item.FindControl("lblTrasIVA");
                Label lblTrasIEPS = (Label)item.FindControl("lblTrasIEPS");
                Label lblTotal = (Label)item.FindControl("lblTotal");
                TextBox txtFechaPago = (TextBox)item.FindControl("txtFechaPago");
                DropDownList ddlEstatus = (DropDownList)item.FindControl("ddlEstatus");
                CheckBox ckbActivo = (CheckBox)item.FindControl("ckbActivo");
                
                
                Facturas objFactura = new Facturas()
                {
                    Empresa=lblEmpresa!=null&&lblEmpresa.Text.Length>0?lblEmpresa.Text:String.Empty,
                    IdFactura = lblIdFactura != null&& lblIdFactura.Text.Length>0 ? int.Parse(lblIdFactura.Text) : 0,
                    TipoProveedor=lblTipoProveedor!=null&&lblTipoProveedor.Text.Length>0?lblTipoProveedor.Text:String.Empty,
                    Proveedor=lblProveedor!=null&&lblProveedor.Text.Length>0?lblProveedor.Text:String.Empty,
                    Folio=lblFolio!=null&&lblFolio.Text.Length>0?lblFolio.Text:String.Empty,
                    Fecha_Factura = lblFechaFactura != null && lblFechaFactura.Text.Length > 0 ? DateTime.Parse(lblFechaFactura.Text, new CultureInfo("en-CA")) : DateTime.Now,
                    Fecha_Vigencia = lblFechaVigencia != null && lblFechaVigencia.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(lblFechaVigencia.Text, new CultureInfo("en-CA")) : null,
                    SubTotal= lblSubTotal!=null&&lblSubTotal.Text.Length>0? Decimal.Parse(lblSubTotal.Text.Replace("$","")):0,
                    RetencionIVA = lblRetIVA != null && lblRetIVA.Text.Length > 0 ? Decimal.Parse(lblRetIVA.Text.Replace("$", "")) : 0,
                    RetencionISR = lblRetISR != null && lblRetISR.Text.Length > 0 ? Decimal.Parse(lblRetISR.Text.Replace("$", "")) : 0,
                    TrasladosIVA = lblTrasIVA != null && lblTrasIVA.Text.Length > 0 ? Decimal.Parse(lblTrasIVA.Text.Replace("$", "")) : 0,
                    TrasladosIEPS = lblTrasIEPS != null && lblTrasIEPS.Text.Length > 0 ? Decimal.Parse(lblTrasIEPS.Text.Replace("$", "")) : 0,
                    Total_Factura = lblTotal != null && lblTotal.Text.Length > 0 ? Decimal.Parse(lblTotal.Text.Replace("$", "")) : 0,
                    Fecha_Pago = txtEmpresa != null && txtFechaPago.Text.Length > 0 ? (Nullable<DateTime>)DateTime.Parse(txtFechaPago.Text, new CultureInfo("en-CA")) : null,
                    Estatus = ddlEstatus.SelectedValue,
                    Activo = ckbActivo.Checked,
                    
                };
                lstFacturas.Add(objFactura);
            }
            return lstFacturas;
        }  
    }
}