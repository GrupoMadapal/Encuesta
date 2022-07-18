<%@ Page Title="Log On" Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="Poleo.Logon" %> 
<%@ Register Src="Controls/LoginCtrl.ascx" TagName="LoginCtrl"   TagPrefix="CTRLLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<asp:Content runat="server" ID="BodyContent2" ContentPlaceHolderID="MainContent" >
    <section >--%>
   <CTRLLogin:LoginCtrl runat="server" id="ctrlLogin"></CTRLLogin:LoginCtrl></section>
    <%--<style type="text/css">
        .auto-style1 {
            width: 18px;
        }
        .auto-style2 {
            width: 48px;
        }
        #contenedor {
  width: 90%;
  height: 300px;
 
  position: absolute;
  top: 50%;
  left: 5%;

  margin-top: -200px;  
  /*margin-left: -150px;*/

  align-content:center;
  border-radius:15px;
  border-color:dimgray;
  border-style:solid;
  text-align:center;
}
    </style>
    <div  id="contenedor" style="background-color:rgba(0, 110, 153, 0.79)">
        <h3>            
            AUTENTICACION DE USUARIOS
        </h3>
<table style="position: absolute; left:15%" >
   <tr>
      <td class="auto-style1"> <asp:Image runat="server" ImageUrl="~/Images/usuario.jpg" Width="30px" Height="30px"  />  </td>
      <td class="auto-style2"> <label for="login">Email:</label></td>
      <td><input id="txtUserName" type="text" runat="server" value="name@madapal.com"></td>
      <td><asp:RequiredFieldValidator ControlToValidate="txtUserName" Display="Static" ErrorMessage="*" runat="server" ID="vUserName" /></td>
   </tr>
   <tr>
      <td class="auto-style1"> <asp:Image ImageUrl="~/Images/password.jpg" Width="30px" Height="30px" runat="server" /></td> <td class="auto-style2"> <label for="password">Password:</label></td>
      <td><input id="txtUserPass" type="password" runat="server" value="4815162342"></td>
      <td> <asp:RequiredFieldValidator ControlToValidate="txtUserPass" Display="Static" ErrorMessage="*" runat="server" ID="vUserPass" />
      </td>
   </tr>
   <tr>
       <td></td>
      <td class="auto-style2">Remember me</td>
      <td><asp:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
      <td></td>
       
   </tr>
    <tr>
        <td colspan="4"  ><asp:Button  runat="server" ID="cmdLogin2" OnClick="cmdLogin_Click" Text="  ENTRAR  " BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Double" /></td>

    </tr>
    <tr>
        <td colspan="4"><asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" /></td>
    </tr>
</table>
  

    
    </div>
    --%>

    
<%--</asp:Content>--%>
