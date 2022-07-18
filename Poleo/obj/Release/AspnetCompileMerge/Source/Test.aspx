<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Poleo.Test" %>
<%@ Register Src="Controls/VentasCtrl.ascx" TagName="ListPicker"   TagPrefix="uc1" %> 
<%@ Register Src="Controls/UpLoadFile.ascx" TagName="UpLoadFileCtrl"   TagPrefix="CTRLUpLoadFile" %>
<%@ Register Src="Controls/ProveedoresCtrl.ascx" TagName="ProveedoresCtrl"   TagPrefix="ProveedoresCtrl" %>
<%@ Register Src="Controls/FacturasCtrl.ascx" TagName="FacturasCtrl"   TagPrefix="FacturasCtrl" %>
<%@ Register Src="Controls/LoadXMLFactura.ascx" TagName="LoadXMLFactura"   TagPrefix="LoadXMLFactura" %>


<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CTRLUpLoadFile:UpLoadFileCtrl runat="server"></CTRLUpLoadFile:UpLoadFileCtrl>   
</div>
        <div>
            <%--<asp:Button runat="server" ID="btnTestWS" Text="TEST WS" OnClick="btnTestWS_Click" />--%>
        </div>
        <div>
            <LoadXMLFactura:LoadXMLFactura runat="server"></LoadXMLFactura:LoadXMLFactura>
        </div>
        <div>
            <ProveedoresCtrl:ProveedoresCtrl runat="server" />
        </div>
        <br />
        <br />
        <div>
            <FacturasCtrl:FacturasCtrl runat="server" />
        </div>
    </form>
</body>
</html>

