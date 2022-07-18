<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProveedoresCtrl.ascx.cs" Inherits="Poleo.Controls.ProveedoresCtrl" %>

<style type="text/css">
 .button {
    margin: 10px;
    text-decoration: none;
    font: bold 15px 'Trebuchet MS',Arial, Helvetica; /*Change the em value to scale the button*/
    display: inline-block;
    text-align: center;
    color: #fff;    
    border: 1px solid #9c9c9c; /* Fallback style */
    border: 1px solid rgba(0, 0, 0, 0.3);
    text-shadow: 0 1px 0 rgba(0,0,0,0.4);    
    box-shadow: 0 0 .05em rgba(0,0,0,0.4);
    width:150px; 
    height:30PX;  
}

.button, 
.button span {
    -moz-border-radius: .3em;
    border-radius: .3em;
}

.button span {
    border-top: 1px solid #fff; /* Fallback style */
    border-top: 1px solid rgba(255, 255, 255, 0.5);
    display: block;
    padding: 0.5em 2.5em;    
    /* The background pattern */
    background-image: linear-gradient(45deg, rgba(0, 0, 0, 0.05) 25%, transparent 25%, transparent),
                      linear-gradient(-45deg, rgba(0, 0, 0, 0.05) 25%, transparent 25%, transparent),
                      linear-gradient(45deg, transparent 75%, rgba(0, 0, 0, 0.05) 75%),
                      linear-gradient(-45deg, transparent 75%, rgba(0, 0, 0, 0.05) 75%);

    /* Pattern settings */
    background-size: 3px 3px;            
}

.button:hover {
    box-shadow: 0 0 .1em rgba(0,0,0,0.4);
    font:bold 12px 'Trebuchet MS',Arial, Helvetica;
}

.button:active {
    /* When pressed, move it down 1px */
    position: relative;
    top: 1px;
}
.button-blue {
    background: #383636;
    background: -webkit-gradient(linear, left top, left bottom, from(#383636), to(#000000) );
    background: -moz-linear-gradient(-90deg,#383636, #000000);
    filter:  progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#383636', endColorstr='#000000');
}

.button-blue:hover {
    background:#000000;
    background: -webkit-gradient(linear, left top, left bottom, from(#000000), to(#383636) );
    background: -moz-linear-gradient(-90deg, #000000, #383636);
    filter:  progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#000000', endColorstr='#383636');            
}

.button-blue:active {
    background: #383636;
}
/*DIV TABLE OF */
.centerDiv {
    margin: auto;
    width: 75%;
    border:5px solid #69140F;
    padding: 10px;
    background-color:#333333;
}
.Proveedores{
    background-color:#333333;
    width:100%;
    border-spacing:0;
}
.ProveedoresHeaders
{
    background-color:#333333;
    color:#E8E8E7;
    text-align:center;
    text-decoration:wavy;
    font-size:15PX;
}
.TitleProveedores{
     margin: auto;
    width: 50%;
    border:5px solid #69140F;
    padding: 10px;
    background-color:#69140F;
    border-top-left-radius:30px;
    border-top-right-radius: 30px;
    color:#E8E8E7;
   font: bold 25px 'Trebuchet MS',Arial, Helvetica;
   text-align:center;

}
.items{
    font-size:10px;
    text-align:center;
    width:100%;
}
.Mesage{
    color:red;
    font-size :19px;
    text-align:center;
    width:100%;
}
</style>
<div class="TitleProveedores">
    <asp:Label runat="server" ID="lsbltitle" Text="EDITOR DE PROVEEDORES"></asp:Label>
</div>
<div class="centerDiv">
    <table>
        <tr>
            <td class="ProveedoresHeaders"><asp:Label runat="server" ID="lblRFC" Text="RFC"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtRFC"></asp:TextBox></td>
            <td><asp:Button runat="server" ID="btnSearch" Text="BUSCAR" OnClick="btnSearch_Click" CssClass="button button-blue" /></td>
        </tr>
        <tr style="justify-content:space-between;">
            <td class="ProveedoresHeaders" ><asp:Label runat="server" ID="lblActivo" Text="ACTIVOS"></asp:Label><asp:CheckBox runat="server" ID="ckbActivo" Checked="true" /> </td>
        </tr>
    </table>
</div>
<div class="centerDiv ">
    <div style="width: calc(100% - 17px)">
        <table>
            <tr class="ProveedoresHeaders" style="width:100%">
                <td style="width:20%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label1" Text="RFC"></asp:Label></td>
                <td style="width:30%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblNombre" Text="NOMBRE"></asp:Label></td>
                <td style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblvigencia" Text="DÍAS DE VIGENCIA"></asp:Label></td>
                <td style="width:15%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblCuenta" Text="CUENTA"></asp:Label></td>
                <td style="width:15%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblTipo" Text="TIPO"></asp:Label></td>
                <td style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label2" Text="ACTIVO"></asp:Label></td>
            </tr>
        </table>
    </div>
    <div style="overflow-x:hidden; overflow-y:scroll; height:200px;">
    <table style="align-content:center; border-collapse:separate; border-color:#383636; border-style:double; max-width:100%;" class="Proveedores" >
<asp:Repeater runat="server" ID="repeatProveedores" OnItemDataBound="repeatProveedores_ItemDataBound">
    <HeaderTemplate>
        
            
        
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="background-color: #E63E11; color:#E8E8E7 " class="items">
            <td style="width:20%; padding:0px; border:1px solid white;"> <asp:Label runat="server" ID="lblRFC" Text='<%#Eval("RFC") %>' Width="100%"></asp:Label>
                 <asp:Label runat="server" ID="lblID" Text='<%#Eval("IdProveedor") %>' Visible="false"></asp:Label>
            </td>
            <td style="width:30%; padding:0px; border:1px solid white;" ><asp:Label runat="server" ID="lblNombre" Text='<%#Eval("Nombre") %>' Width="100%"></asp:Label></td>
            <td style="width:10%; padding:0px; border:1px solid white;"><asp:TextBox runat="server" ID="txtVigencia" Text='<%#Eval("Vigencia") %>' Width="85%"></asp:TextBox></td>
            <td style="width:15%; padding:0px; border:1px solid white;"><asp:TextBox runat="server" ID="txtCuenta" Text='<%#Eval("Cuenta") %>' Width="85%"></asp:TextBox></td>
            <td style="width:15%; padding:0px; border:1px solid white;">
                <asp:DropDownList runat="server" ID="ddlTipo" Width="100%"></asp:DropDownList>
                <asp:Label runat="server" ID="lblTipo" Text='<%#Eval("Tipo") %>' Visible="false"></asp:Label>
            </td >
            <td style="width:10%; padding:0px; border:1px solid white;"><asp:CheckBox runat="server" ID="chboxActivo" Checked='<%#Eval("Activo") %>' Width="100%" /></td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate >
        <tr style="background-color:#B91817;color:#E8E8E7 " class="items">
            <td style="width:20%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblRFC" Text='<%#Eval("RFC") %>' Width="100%"></asp:Label>
                <asp:Label runat="server" ID="lblID" Text='<%#Eval("IdProveedor") %>' Visible="false"></asp:Label>
            </td>
            <td style="width:30%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblNombre" Text='<%#Eval("Nombre") %>' Width="100%"></asp:Label></td>
            <td style="width:10%; padding:0px; border:1px solid white;"><asp:TextBox runat="server" ID="txtVigencia" Text='<%#Eval("Vigencia") %>' Width="85%"></asp:TextBox></td>
            <td style="width:15%; padding:0px; border:1px solid white;"><asp:TextBox runat="server" ID="txtCuenta" Text='<%#Eval("Cuenta") %>' Width="85%"></asp:TextBox></td>
            <td style="width:15%; padding:0px; border:1px solid white;">
                <asp:DropDownList runat="server" ID="ddlTipo" Width="100%"></asp:DropDownList>
                <asp:Label runat="server" ID="lblTipo" Text='<%#Eval("Tipo") %>' Visible="false"></asp:Label>
            </td>
            <td style="width:10%; padding:0px; border:1px solid white;"><asp:CheckBox runat="server" ID="chboxActivo" Checked='<%#Eval("Activo") %>' Width="100%" /></td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td><asp:Button runat="server" ID="btnGuardar" Text="GUARDAR"  OnClick="btnGuardar_Click" CssClass="button button-blue"/></td>
            <td></td>
            <td></td>
        </tr>
    
    </FooterTemplate>
</asp:Repeater>
        </table>
    <div  class="Mesage">
            <asp:Label ID="Mensaje" runat="server" Text=" ** No se encontraron registros con la informacíon proporcionada . ** " Visible="false"></asp:Label>
    </div>
    </div>
  
</div>
