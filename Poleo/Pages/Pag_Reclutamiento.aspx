<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_Reclutamiento.aspx.cs" Inherits="Poleo.Pages.Pag_Reclutamiento" %>
<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Filters" ContentPlaceHolderID="TitleContent" runat="server">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DP" />
</asp:Content>
<asp:Content ID="Buttons" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblContent" runat="server" style="width:100%">
        <%--Contenido dinamico--%>
    </table>
    <asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass="messageError"></asp:Label>
</asp:Content>
