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
    public partial class ProveedoresCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorBLL objProveedorBLL = new ProveedorBLL();
            FacturasBLL objFacturasBLL = new FacturasBLL();
            List<Proveedor> lstProveedores = new List<Proveedor>();
            foreach(RepeaterItem item in repeatProveedores.Items)
            {
                CheckBox objCheckBoxActive = (CheckBox)item.FindControl("chboxActivo");
                TextBox objTxtCuenta = (TextBox)item.FindControl("txtCuenta");
                TextBox objTxtVigencia = (TextBox)item.FindControl("txtVigencia");
                Label objLblID = (Label)item.FindControl("lblID");
                Label objLblRFC = (Label)item.FindControl("lblRFC");
                DropDownList ddlTipo = (DropDownList)item.FindControl("ddlTipo");

                Proveedor objNewProveedor = new Proveedor()
                {
                    Activo = objCheckBoxActive.Checked,
                    IdProveedor = int.Parse(objLblID.Text),
                    RFC = objLblRFC.Text,
                    Cuenta = objTxtCuenta.Text,
                    Vigencia = int.Parse(objTxtVigencia.Text),
                    Tipo=ddlTipo.SelectedValue
                };
                lstProveedores.Add(objNewProveedor);
            }

            foreach(Proveedor item in lstProveedores)
            {
                objProveedorBLL.UpdateProveedorActive(item);
                if(item.Activo&&item.Vigencia>0)
                {
                    Facturas finder = new Facturas()
                    {
                        IdProveedor = item.IdProveedor
                    };
                    IList<Facturas> lstFactura = objFacturasBLL.SelectFacturastoChange(finder);
                    foreach(Facturas itemFac in lstFactura)
                    {
                        itemFac.Activo = true;
                        itemFac.Fecha_Vigencia = itemFac.Fecha_Factura.AddDays(item.Vigencia);
                        itemFac.Estatus = EstadosFacturas.PROXIMAVENCIMIENTO.ToString();
                        itemFac.Fecha_Pago = null;
                        objFacturasBLL.UpdateFacturas(itemFac);
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ProveedorBLL objProveedoresBLL = new ProveedorBLL();
            String strRFC = txtRFC.Text.Length > 0 ? txtRFC.Text : String.Empty;
            Proveedor objProveedorFinder = new Proveedor()
            {
                RFC =strRFC,
                Activo=ckbActivo.Checked
            };
            IList<Proveedor> lstProveedores=objProveedoresBLL.SelectEmpresabyRFC(objProveedorFinder);
            if (lstProveedores.Count > 0)
            {

                Mensaje.Visible = false;
                repeatProveedores.Visible = true ;
            }
            else
            {
                Mensaje.Visible = true;
                repeatProveedores.Visible = false;
            }
            repeatProveedores.DataSource = lstProveedores;
            repeatProveedores.DataBind();
        }

        protected void repeatProveedores_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlTipo = (DropDownList)e.Item.FindControl("ddlTipo");
                Label lblTipo = (Label)e.Item.FindControl("lblTipo");
                ddlTipo.Items.Clear();
                foreach (TipoProveedor item in Enum.GetValues(typeof(TipoProveedor)))
                {
                    ddlTipo.Items.Add(item.ToString());
                }
                if (lblTipo.Text.Length > 0)
                {
                    ddlTipo.Items.FindByValue(lblTipo.Text).Selected = true;
                }
            }
        }
    }
}