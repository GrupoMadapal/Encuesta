<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterStoreCtrl.ascx.cs" Inherits="Poleo.Controls.FilterStoreCtrl" %>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<link href="../Content/themes/base/autocomplete.css" rel="stylesheet" />
<link href="../Content/themes/base/datepicker.css" rel="stylesheet" />

<style>
.messageError
{
    text-align:center;
    color:red;
}
</style>
 <script type="text/javascript">

     $(function () {
         $("[id$=txtDateIni]").datepicker({
             dateFormat: 'dd/mm/yy'
         });
     });
     $(function () {
         $("[id$=txtDateEnd]").datepicker({
             dateFormat: 'dd/mm/yy'
         });
     });
     $(document).ready(function () {
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

         function EndRequestHandler(sender, args) {
             $("[id$=txtDateIni]").datepicker({ dateFormat: 'dd/mm/yy' });
             $("[id$=txtDateEnd]").datepicker({ dateFormat: 'dd/mm/yy' });
         }

     });
</script>

<table id="tblStore" runat="server" style="width:100%;">
    <tr>
        <td><div style="text-align:center;"><asp:Label runat="server" ID="lblLocation" Text="Ubicación" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
        <td><div style="text-align:center;"><asp:Label runat="server" ID="lblType" Text="Tipo" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
        <td><div style="text-align:center;"><asp:Label runat="server" ID="lblStore" Text="Tienda" Font-Bold ="true" Font-Size="Large"></asp:Label></div></td>
        <td><div style="text-align:center;"><asp:Label runat="server" ID="lblViewInfo" Text="Informacion" Font-Bold ="true" Font-Size="Large" Visible="false"></asp:Label></div></td>
    </tr>
    <tr>
        <td>
            <div style="text-align:center;"><asp:DropDownList ID="ddlLocation" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList></div>
        </td>
        <td>
            <div style="text-align:center;"><asp:DropDownList ID="ddlType" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList></div>
        </td>
        <td>
            <div style="text-align:center;"><asp:DropDownList ID="ddlStore" runat="server" Width="150px" ForeColor="Black"></asp:DropDownList></div>
        </td>
        <td>
            <div style="text-align:center;">
                <asp:DropDownList ID="ddlViewInfo" runat="server" Width="150px" ForeColor="Black" Visible="false">
                    <asp:ListItem Text="Ventas" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Operacion" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </td>
    </tr>
</table>
<br />
<table id="tblDate" runat="server" visible="false" style="width:100%;">
    <tr>
        <td>
            <asp:Label runat="server" ID="lblDateIni" Text="Fecha Inicial" Font-Bold ="true" Font-Size="Large"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDateIni" runat="server" Width="150px" CssClass="txtCSS" ForeColor="Black"></asp:TextBox>
        </td>
        <td>
            <asp:Label runat="server" ID="lblDateEnd" Text="Fecha Final" Font-Bold ="true" Font-Size="Large" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDateEnd" runat="server" Width="150px"  CssClass="txtCSS" ForeColor="Black"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:Label ID="lblErrormsg" runat="server" Visible="false"></asp:Label>