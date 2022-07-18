<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_Dominos.aspx.cs" Inherits="Poleo.Pages.Pag_Dominos" %>

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
    <%--<table>
        <tr>           
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="btnExcel" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnExcel_Click"/></td>
                        <td class="elementes"><asp:Button runat="server" ID="btnExcelVentas" Text="Ventas"  CssClass="elementes  btnExcelText " Width="80px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnExcelVentas_Click" /></td>
                    </tr>
                </table>
            </td>
            <td> 
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="BtnIndicadorExcel" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="BtnIndicadorExcel_Click" /></td>
                        <td class="elementes"><asp:Button runat="server" ID="BtnIndicadorExcelText" Text="Indicador Clave"  CssClass="elementes  btnExcelText " Width="120px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="BtnIndicadorExcelText_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnVentasResumen" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnVentasResumen_Click"  /> </td>
                        <td class="elementes"><asp:Button runat="server" ID="btnVentasResumenText" Text="Contabilidad"  CssClass="elementes  btnExcelText " Width="100px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnVentasResumenText_Click" /></td>
                    </tr>
                </table> 
            </td>
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnImgRanking" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px"  OnClick="btnImgRanking_Click" /> </td>
                        <td class="elementes"><asp:Button runat="server" ID="btnRanking" Text="RANKING"  CssClass="elementes  btnExcelText " Width="100px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnRanking_Click"  /></td>
                    </tr>
                </table> 
            </td>
            <td>
                <%--<table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnimgCupon" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px"  OnClick="btnimgCupon_Click" /> </td>
                        <td class="elementes"><asp:Button runat="server" ID="btnCupon" Text="CUPONES"  CssClass="elementes  btnExcelText " Width="100px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnCupon_Click" /></td>
                    </tr>
                </table> 
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="btnIndMaestro" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnIndMaestro_Click" /></td>
                        <td class="elementes"><asp:Button runat="server" ID="btnIndMaestroText" Text="Indicador Maestro"  CssClass="elementes  btnExcelText "  Height="35px" BackColor="#137A0E" BorderColor="#137A0E"  OnClick="btnIndMaestroText_Click"/></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr> 
            <td></td> 
            <td><asp:CheckBox ID="CheckBox1" runat="server" Checked="true" /> <asp:Label runat="server" ID="lblindi" Text="Indicador Completo"></asp:Label></td>
            <td></td>
            <td> </td>
        </tr> 
        <tr>
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="btnTransacciones" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnTransacciones_Click" /></td>
                        <td class="elementes"><asp:Button runat="server" ID="btnTransaccionesText" Text="Transacciones"  CssClass="elementes  btnExcelText "  Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnTransaccionesText_Click" /></td>
                    </tr>
                </table>
            </td> 
            <td>
                <table>
                    <tr style=" white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="btnFiltro2" ImageUrl="~/Images/ver.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnFiltro2_Click" /></td>
                        <td class="elementes "><asp:Button ID="btnFiltro" runat="server" Text="Desplegar" OnClick="btnFiltro_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass=" elementes btnExcelText" Width="100px"  /></td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr style="white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="ibtEntradaHorno" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnEntradaHorno_Click" /></td>
                        <td class="elementes"><asp:Button ID="btnEntradaHorno" runat="server" Text="Entrada Horno" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass="elementes btnExcelText" Width="115px" OnClick="btnEntradaHorno_Click" /></td>
                    </tr>
                </table>
            </td> 
            <td> 
                <%--<table>
                    <tr style="white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="ibtPorcCoupon" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnPorcCoupon_Click" /></td>
                        <td class="elementes"><asp:Button ID="btnPorcCoupon" runat="server" Text="% Cupones" OnClick="btnPorcCoupon_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass=" elementes btnExcelText" Width="100px"/></td>
                    </tr>
                </table>
                <table>
                    <tr style="white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="ibtTiempoServicio" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnTiempoServicio_Click" /></td>
                        <td class="elementes"><asp:Button ID="btnTiempoServicio" runat="server" Text="Tiempo servicio" OnClick="btnTiempoServicio_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass="elementes btnExcelText" Width="115px"/></td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr style="white-space:nowrap;">
                        <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="ibtOrdenesInternet" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnOrdenesInternet_Click" /></td>
                        <td class="elementes"><asp:Button ID="btnOrdenesInternet" runat="server" Text="Ordenes Internet" OnClick="btnOrdenesInternet_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass="elementes btnExcelText" Width="125px"/></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4"><asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label></td>
        </tr> 
    </table>--%>
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
