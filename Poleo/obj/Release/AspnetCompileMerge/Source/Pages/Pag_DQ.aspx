<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_DQ.aspx.cs" Inherits="Poleo.Pages.Pag_DQ" %>

<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DQ" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ButtonsContent" runat="server">
    <table>
        <tr>     
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnVentasDQ" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnVentasDQ_Click" /></td>
                        <td class="elementes"><asp:Button runat="server" ID="btnVentasDQText" Text="Ventas Dairy Queen"  CssClass="elementes  btnExcelText "  Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnVentasDQText_Click" /></td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5"><asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label></td>
        </tr> 
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
