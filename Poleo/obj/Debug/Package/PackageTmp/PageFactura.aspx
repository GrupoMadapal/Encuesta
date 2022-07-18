<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageFactura.aspx.cs" Inherits="Poleo.PageFactura" %>
<%@ Register Src="Controls/ProveedoresCtrl.ascx" TagName="ProveedoresCtrl"   TagPrefix="ProveedoresCtrl" %>
<%@ Register Src="Controls/FacturasCtrl.ascx" TagName="FacturasCtrl"   TagPrefix="FacturasCtrl" %>
<%@ Register Src="Controls/LoadXMLFactura.ascx" TagName="LoadXMLFactura"   TagPrefix="LoadXMLFactura" %>
<asp:Content  ID="FeaturedContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">

    </section>

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

    
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>--%>
