<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterIndicators.ascx.cs" Inherits="Poleo.Controls.FilterIndicators" %>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="../Scripts/jquery-2.1.4.js"></script>
<script src="../Scripts/jquery-ui-1.11.4.js"></script>
<link href="../Content/themes/base/autocomplete.css" rel="stylesheet" />
<link href="../Content/themes/base/datepicker.css" rel="stylesheet" />
 <script type="text/javascript">

     $(function () {
         $("[id$=TextBoxStart]").datepicker({
             dateFormat: 'dd/mm/yy'
         });
     });
     $(function () {
         $("[id$=TextBoxEnd]").datepicker({
             dateFormat: 'dd/mm/yy'
         });
     });
     $(document).ready(function () {
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

         function EndRequestHandler(sender, args) {
             $("[id$=TextBoxStart]").datepicker({ dateFormat: 'dd/mm/yy' });
             $("[id$=TextBoxEnd]").datepicker({ dateFormat: 'dd/mm/yy' });
         }

     });
</script>
<style>
txtCSS {
    float: left;
    width:200px
}

btnCSS{ 
    float:left;
    position:absolute;
}
.calendar{ position: relative;}
  
.formItem label {
display: block;
text-align: center;

}
.button{
 padding: 10px 35px;
 overflow:hidden;
}
.button:before {
 font-family: FontAwesome;
 content:"\f07a";
 position: absolute;
 top: 11px;
 left: -30px;
 transition: all 200ms ease;
}
.button:hover:before {
 left: 7px;
}
.elementes
{
    border:0px;
    background-color:rgba(92, 184, 92,.5);
    /*padding:0px;
    margin:0 auto;
    display:inline-block;
    position:relative;*/
}

.btnExcel{
    border-radius:50px;
    border:1px solid white;
    padding:0px;
    margin:5px;
}

.btnExcelText{
    /*border-top-right-radius:50px;
    border-bottom-right-radius:50px;*/
    color:#444;
    font-size:13px;
    font-weight:600;
}
.btnExcelTD
{
     background-color:rgba(92, 184, 92,.5);
     /*border-bottom-left-radius:50px;
     border-top-left-radius:50px;*/
     width:35px;
     height:35px;
}
.messageError
{
    text-align:center;
    color:red;
    font-size:16px;
}

</style>

<asp:UpdatePanel runat="server" ID="combos">
    <ContentTemplate>
        <table style="width:99%; max-width:99%">
            <tr>
                <%--<td> <div style="text-align:center;"><asp:Label runat="server" ID="Label4" Text="Ubicación" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
                <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label5" Text="Tipo" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
                <td> <div style="text-align:center;"><asp:Label runat="server" ID="msj2" Text="Tienda" Font-Bold ="true" Font-Size="Large"></asp:Label></div></td>
                <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label2" Text="Año" Font-Bold ="true" Font-Size="Large"></asp:Label> </div></td>
                <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label6" Text="Numero Semana" Font-Bold ="true" Font-Size="Large"></asp:Label></div> </td> --%>
            </tr>
            <tr>
                <%--<td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="lstUbicacion"  Width="150px" AutoPostBack="true" OnSelectedIndexChanged="lstUbicacion_SelectedIndexChanged" ForeColor="Black" ></asp:DropDownList> </div></td>
                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="lstTiposTienda" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="lstTiposTienda_SelectedIndexChanged" ForeColor="Black" ></asp:DropDownList></div></td>
                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="LstTiendas" Width="150px"  AutoPostBack="true" ForeColor="Black" ></asp:DropDownList></div></td>
                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="DDLYears" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DDLYears_SelectedIndexChanged" ForeColor="Black" ></asp:DropDownList></div></td>
                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="fecha" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="fecha_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList> </div></td>--%>
            </tr>
        </table>                
        <table style="width:99%; max-width:99%">
            <tr>
                <td><asp:Label runat="server" ID="Label1" Text="Fecha Inicial" Font-Bold ="true" Font-Size="Large"></asp:Label></td>
                <td><asp:TextBox ID="TextBoxStart" runat="server" Width="150px" CssClass="txtCSS" ForeColor="Black"></asp:TextBox></td>
                <td><asp:Label runat="server" ID="Label3" Text="Fecha Final" Font-Bold ="true" Font-Size="Large" ></asp:Label></td>
                <td><asp:TextBox ID="TextBoxEnd" runat="server" Width="150px"  CssClass="txtCSS" ForeColor="Black"></asp:TextBox></td>
                <td><%--<asp:Label runat="server" ID="Label7" Text="Cupon:" Font-Bold ="true" Font-Size="Large"></asp:Label><--%><%--<asp:TextBox ID="txtCupon" runat="server" Width="75px"  CssClass="txtCSS"></asp:TextBox>--%>
                    <%--<asp:DropDownList runat="server" ID="ddlCupon" Width="80px"></asp:DropDownList>--%>                     
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
     