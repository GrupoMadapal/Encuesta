<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_InfoTR.aspx.cs" Inherits="Poleo.Pages.Pag_InfoTR" %>
<%@ Register Src="~/Controls/FilterStoreCtrl.ascx" TagPrefix="MDP" TagName="FilterS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<style>
.elementes
{
    border:0px;
    background-color:rgba(92, 184, 92,.5);
}

.btnExcel{
    border-radius:50px;
    border:1px solid white;
    padding:0px;
    margin:5px;
}

.btnExcelText{
    color:#444;
    font-size:13px;
    font-weight:600;
}
</style>
<style type="text/css">
::-webkit-scrollbar {
  width: 6px;
}

::-webkit-scrollbar-thumb {
  background: #C8C8C8;
  border-radius: 10px;
  height: 55px;
}

::-webkit-scrollbar-thumb:hover {
  background: #C8C8C8;
}

::-webkit-scrollbar-thumb:active {
  background: #C8C8C8;
}

::-webkit-scrollbar-track {
  background: rgba(56, 131, 195, .7);
}
</style>

<script>
    <!--
    function timedRefresh(timeoutPeriod) {
        setTimeout("location.reload(true);", timeoutPeriod);
    }

    //window.onload = timedRefresh(900000);

    //   -->
</script>

    <table style="width:100%;">
        <tr>
            <td>
                <MDP:FilterS ID="ctrlFilter" runat="server"></MDP:FilterS>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnView" runat="server" Text="Consultar" CssClass="elementes btnExcelText" Height="35px" OnClick="btnView_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr id="rowTotal" runat="server">
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblstrTotal" runat="server" Text="TOTAL :" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblTotal" runat="server" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                    </tr>
                    <tr id="rowOrder" runat="server" visible="false">
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblStrOrdenes" runat="server" Text="NO. ORDENES:" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblOrdenes" runat="server" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tblDQ" runat="server" visible="false" style="width:100%;">
                    <tr>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblStrPasteles" runat="server" Text="NO. PASTELES:" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblPasteles" runat="server" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="rowCobrosSef" runat="server" visible="false">
            <td>
                <table style="width:100%;">
                    <tr>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblStrTotalC" runat="server" Text="TOTAL COBRADO:" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblTotalC" runat="server" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tblCancelSEF" runat="server" visible="false" style="width:100%;">
                    <tr>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblStrTotalCancel" runat="server" Text="TOTAL CANCELADO:" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                        <td style="width:50%; text-align:center;">
                            <asp:Label ID="lblTotalCancel" runat="server" CssClass="LabelPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="rowSalesStore" runat="server" visible="false" style="margin-bottom:5px;">
            <td>
                <%--DP--%>
                <% if(!ViewOnlyDQ) {%>
                <div class="TitleTblGrd">VENTAS ON LINE</div>
                <asp:Panel ID="pnlStore" runat="server" CssClass="TableGrd" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td style="width:10%;">
                                <asp:Label ID="lblNumberStore" runat="server" Text="Numero de tienda"></asp:Label>
                            </td>
                            <td style="width:10%;">
                                <asp:Label ID="lblNameStore" runat="server" Text="Nombre de tienda"></asp:Label>
                            </td>
                            <% if (!IsManager) {%>
                            <td style="width:9%;">
                                <asp:Label ID="lblTotalStore" runat="server" Text="Ventas Reales"></asp:Label>
                            </td>
                            <td style="width:9%;">
                                <asp:Label ID="lblSalesLastYear" runat="server" Text="Total año pasado"></asp:Label>
                            </td>
                            <% } %>
                            <td style="width:8%;">
                                <asp:Label ID="lblPorcSales" runat="server" Text="%"></asp:Label>
                            </td>
                            <td style="width:9%;">
                                <asp:Label ID="lblDeposito" runat="server" Text="Deposito"></asp:Label>
                            </td>
                            <td style="width:8%;">
                                <asp:Label ID="lblNumberOrders" runat="server" Text="No. Ordenes"></asp:Label>
                            </td>
                            <% if(!ViewInfoSales) {%>
                            <td style="width:9%;">
                                <asp:Label ID="lblFreeOrders" runat="server" Text="No. Ordenes Gratis"></asp:Label>
                            </td>
                            <td style="width:9%;">
                                <asp:Label ID="lblCancelOrders" runat="server" Text="No. Ordenes Canceladas"></asp:Label>
                            </td>
                            <td style="width:9%;">
                                <asp:Label ID="lblEntradaHorno" runat="server" Text="Entrado Horno"></asp:Label>
                            </td>
                            <td style="width:9%;">
                                <asp:Label ID="lblTiempoEntrega" runat="server" Text="Tiempo de entrega"></asp:Label>
                            </td>
                            <% } %>
                        </tr>
                    </table>
                    <div style="overflow-x:hidden; overflow-y:scroll; max-height:300px;" >
                        <table style="width:100%">
                            <asp:Repeater ID="rptInfoStoreDP" runat="server">
                                <ItemTemplate>
                                    <tr style="width:100%; background-color:#207CFF;">
                                        <td style="width:10%;">
                                            <asp:Label ID="lblNumberStore" runat="server" Text='<% #Eval("NumeroTienda") %>'></asp:Label>
                                        </td>
                                        <td style="width:10%;">
                                            <asp:Label ID="lblNameStore" runat="server" Text='<% #Eval("NombreTienda") %>'></asp:Label>
                                        </td>
                                        <% if (!IsManager) {%>
                                        <td style="width:9%;">
                                            <asp:Label ID="lblTotalStore" runat="server" Text='<% #Eval("VentasReales", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <td style="width:9%;">
                                            <asp:Label ID="lblSalesLastYear" runat="server" Text='<% #Eval("VentasAnoPasado", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <% } %>
                                        <td style="width:8%;">
                                            <asp:Label ID="lblPorcSales" runat="server" Text='<% #Eval("PorcVentas") %>'></asp:Label>
                                        </td>
                                        <td style="width:9%;">
                                            <asp:Label ID="lblDeposito" runat="server" Text='<% #Eval("TotalDeposito") %>'></asp:Label>
                                        </td>
                                        <td style="width:8%;">
                                            <asp:Label ID="lblNumberOrders" runat="server" Text='<% #Eval("Ordenes") %>'></asp:Label>
                                        </td>
                                        <% if(!ViewInfoSales) {%>
                                        <td style="width:9%;">
                                            <asp:Label ID="Label6" runat="server" Text='<% #Eval("OrdenesGratis") %>'></asp:Label>
                                        </td>
                                        <td style="width:9%;">
                                            <asp:Label ID="Label7" runat="server" Text='<% #Eval("OrdenesCanceladas") %>'></asp:Label>
                                        </td>
                                        <td style="width:9%;">
                                            <asp:Label ID="lblEntradaHorno" runat="server" Text='<% #Eval("EntradaHorno") %>' CssClass='<% #Eval("ClassEH") %>'></asp:Label>
                                        </td>
                                        <td style="width:9%;">
                                            <asp:Label ID="lblTimempoEntrega" runat="server" Text='<% #Eval("TiempoEntrega") %>' CssClass='<% #Eval("ClassTE") %>'></asp:Label>
                                        </td>
                                        <% } %>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr style="width:100%; background-color:#37547F;">
                                        <td>
                                            <asp:Label ID="lblNumberStore" runat="server" Text='<% #Eval("NumeroTienda") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNameStore" runat="server" Text='<% #Eval("NombreTienda") %>'></asp:Label>
                                        </td>
                                        <% if (!IsManager) {%>
                                        <td>
                                            <asp:Label ID="lblTotalStore" runat="server" Text='<% #Eval("VentasReales", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSalesLastYear" runat="server" Text='<% #Eval("VentasAnoPasado", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <% } %>
                                        <td>
                                            <asp:Label ID="lblPorcSales" runat="server" Text='<% #Eval("PorcVentas") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDeposito" runat="server" Text='<% #Eval("TotalDeposito") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNumberOrders" runat="server" Text='<% #Eval("Ordenes") %>'></asp:Label>
                                        </td>
                                        <% if(!ViewInfoSales) {%>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<% #Eval("OrdenesGratis") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<% #Eval("OrdenesCanceladas") %>'></asp:Label>
                                        </td>
                                         <td>
                                            <asp:Label ID="lblEntradaHorno" runat="server" Text='<% #Eval("EntradaHorno") %>' CssClass='<% #Eval("ClassEH") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTimempoEntrega" runat="server" Text='<% #Eval("TiempoEntrega") %>' CssClass='<% #Eval("ClassTE") %>'></asp:Label>
                                        </td>
                                        <% } %>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </asp:Panel>
                <br />
                <% } else { %>
                <%--DQ--%>
                <div class="TitleTblGrd">VENTAS ON LINE</div>
                <asp:Panel ID="Panel1" runat="server" CssClass="TableGrd" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td style="width:20%;">
                                <asp:Label ID="Label1" runat="server" Text="Numero de tienda"></asp:Label>
                            </td>
                            <td style="width:40%;">
                                <asp:Label ID="Label2" runat="server" Text="Nombre de tienda"></asp:Label>
                            </td>
                            <td style="width:20%;">
                                <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
                            </td>
                            <td style="width:10%;">
                                <asp:Label ID="Label4" runat="server" Text="No. Ordenes"></asp:Label>
                            </td>
                            <td style="width:10%;">
                                <asp:Label ID="Label5" runat="server" Text="No. Pasteles"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div style="overflow-x:hidden; overflow-y:scroll; max-height:300px;">
                        <table style="width:100%">
                            <asp:Repeater ID="rptInfoStoreDQ" runat="server">
                                <ItemTemplate>
                                    <tr style="width:100%; background-color:#207CFF;">
                                        <td style="width:20%;">
                                            <asp:Label ID="lblNumberStore" runat="server" Text='<% #Eval("NumTienda") %>'></asp:Label>
                                        </td>
                                        <td style="width:40%;">
                                            <asp:Label ID="lblNameStore" runat="server" Text='<% #Eval("NombreTienda") %>'></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="lblTotalStore" runat="server" Text='<% #Eval("VentasReales", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <td style="width:10%;">
                                            <asp:Label ID="lblOrdenes" runat="server" Text='<% #Eval("Ordenes") %>'></asp:Label>
                                        </td>
                                        <td style="width:10%;">
                                            <asp:Label ID="lblPasteles" runat="server" Text='<% #Eval("Pasteles") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr style="width:100%; background-color:#37547F;">
                                        <td>
                                            <asp:Label ID="lblNumberStore" runat="server" Text='<% #Eval("NumTienda") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNameStore" runat="server" Text='<% #Eval("NombreTienda") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalStore" runat="server" Text='<% #Eval("VentasReales", "{0:C}") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblOrdenes" runat="server" Text='<% #Eval("Ordenes") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPasteles" runat="server" Text='<% #Eval("Pasteles") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </asp:Panel>
                <%} %>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
