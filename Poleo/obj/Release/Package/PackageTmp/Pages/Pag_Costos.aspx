<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Pag_Costos.aspx.cs" Inherits="Poleo.Pages.Pag_Costos" %>

<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>
<%@ Register Src="~/Controls/VentasCtrl.ascx" TagName="VentasCtrl"   TagPrefix="CTLVentas" %>
<%@ Register Src="~/Controls/PizzasCtrl.ascx" TagName="PizzasCtrl"   TagPrefix="CTLPizzas" %>
<%@ Register Src="~/Controls/ComplementosCtrl.ascx" TagName="ComplementosCtrl"   TagPrefix="CTRLComplementos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Filters" ContentPlaceHolderID="TitleContent" runat="server">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DP" />
</asp:Content>
<asp:Content ID="Butsons" ContentPlaceHolderID="MainContent" runat="server">
    
    <table id="tblContent" runat="server" style="width:100%">
        <%--Contenido dinamico--%>
    </table>
    <asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass="messageError"></asp:Label>
<%--</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">--%>
    <CTLVentas:VentasCtrl ID="idCTLVentas" runat="server" Visible="false"  />
    <br />
    <br />
    <table>
        <tr> 
            <td style="width:100%;"><CTLPizzas:PizzasCtrl ID="PizzasCtrl" runat="server" Visible="false" /></td>
            <td><CTRLComplementos:ComplementosCtrl ID="ComCtrl" runat="server" Visible="false" /> </td>
        </tr>
    </table>
</asp:Content>
