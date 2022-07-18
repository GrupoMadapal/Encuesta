<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_DQ.aspx.cs" Inherits="Poleo.Pages.Pag_DQ" %>

<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DQ" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .headTable
        {
            width:100%;
            width:-webkit-calc(100% - 17px);
            width: -moz-calc(100% - 17px);
            width: calc(100% - 17px);
            font-size: 0.90em;
        }

        .TDItems
        {
            text-align:center;
            padding:0px;
            border: 0px solid white;
        }
    </style>
    <%--<table>
        <tr>     
            <td style="padding-left:15px">
                <table>
                    <tr>
                        <td class="elementes"><asp:ImageButton runat="server" ID="btnVentasDQ" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="btnVentasDQ_Click" /></td>
                        <td><asp:Button runat="server" ID="btnVentasDQText" Text="Ventas Dairy Queen"  CssClass="elementes btnExcelText" Height="35px" OnClick="btnVentasDQText_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td class="elementes"><asp:ImageButton runat="server" ID="ibtRanking" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="ibtRanking_Click" /></td>
                        <td><asp:Button runat="server" ID="btnRanking" Text="Ranking"  CssClass="elementes btnExcelText" Height="35px" OnClick="btnRanking_Click" /></td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5"><asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label></td>
        </tr> 
    </table>--%>
    <table id="tblContent" runat="server" style="width:100%">
        <%--Contenido dinamico--%>
    </table>
    <asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label>
    <%--<table style="width:50%; border:2px solid white;">
        <tr>
            <td>
                <asp:Repeater ID="rptSalesArticulos" runat="server" Visible="false">
                    <HeaderTemplate>
                        <tr>
                            <td>
                                Articulo
                            </td>
                            <td style="border-left:2px solid white; border-top:2px solid white;">
                                Total
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="border-top:2px solid white;">
                            <td >
                                <asp:Label ID="lblArticulo" runat="server" Text='<% #Eval("Articulo") %>'></asp:Label>
                            </td>
                            <td style="border-left:2px solid white;">
                                <asp:Label ID="lblTotal" runat="server" Text='<% #Eval("VentasTotales") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>--%>
    <div runat="server" id="panelscreen" visible="false">
    <div class="TitleTblGrd">VENTAS DIARIAS</div>
    <asp:Panel runat="server" ID="panelventas" CssClass="TableGrd" Width="100%">
        <div style="width:100%;">
            <table class="headTable">
                <tr style="width:100%;">
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="DÍA"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="FECHA"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:12%"><asp:Label runat="server" Text="SUCURSAL"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="VENTAS"></asp:Label></td>
                    <td colspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="ORDENES"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="UTILIZADO"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="PASTELES"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="TICKET PROMEDIO"></asp:Label></td>
                    <td rowspan="2" class="TDItems" style="width:7%"><asp:Label runat="server" Text="SERVICIO A DOMICILIO"></asp:Label></td>
                  <td rowspan="2" class="TDItems" style="width:10%"><asp:Label runat="server" Text="VENTAS DRVIE"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TDItems" style="width:8%"><asp:Label runat="server" Text="TOTALES"></asp:Label></td>
                    <td class="TDItems" style="width:4%"><asp:Label runat="server" Text="REGALADAS"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div style="overflow-x:hidden; overflow-y:scroll; max-height:300px;">
            <table style="width:100%;">
                <asp:Repeater ID="rptVentas" runat="server">
                    <ItemTemplate>
                        <tr style="width:100%; background-color:#207CFF;">
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl1" Text='<% #Eval("Dia") %>'  ></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl2" Text='<% #Eval("Fecha", "{0:d}") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:12%"><asp:Label runat="server" ID="lbl3" Text='<% #Eval("Sucursal") %>'  style="text-align:left"></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasReales", "{0:C}") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("Ordenes") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("Invitaciones") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("UtilizadoIdeal", "{0:C}") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("NumeroPasteles") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("TicketPromedio", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("SERVICIODOMICILIO", "{0:C}" ) %>'></asp:Label></td>
                         <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl14" Text='<% #Eval("VENTASDRIVE", "{0:C}" ) %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="width:100%; background-color:#37547F;">
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl1" Text='<% #Eval("Dia") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl2" Text='<% #Eval("Fecha", "{0:d}") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:12%"><asp:Label runat="server" ID="lbl3" Text='<% #Eval("Sucursal") %>' style="text-align:left"></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasReales", "{0:C}") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("Ordenes") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("Invitaciones") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("UtilizadoIdeal", "{0:C}") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("NumeroPasteles") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("TicketPromedio", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("SERVICIODOMICILIO", "{0:C}" ) %>'></asp:Label></td>
                           <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl14" Text='<% #Eval("VENTASDRIVE", "{0:C}" ) %>'></asp:Label></td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </table>
        </div>
       <%-- <div>
            <table class="headTable">
                <asp:Repeater runat="server" ID="rptTotal">
                    <ItemTemplate>
                        <tr style="width:100%">
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl1" ></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl2"  ></asp:Label></td>
                            <td class="TDItems"  style="width:15%"><asp:Label runat="server" ID="lbl3" Text="TOTAL :" ></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasReales", "{0:C}") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("Ordenes") %>' ></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("Invitaciones") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("UtilizadoIdeal", "{0:C}") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("NumeroPasteles") %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("TicketPromedio", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("UBER", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl11" Text='<% #Eval("RAPI", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl12" Text='<% #Eval("INDOOR", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl13" Text='<% #Eval("COMAL", "{0:C}" ) %>'></asp:Label></td>
                            <td class="TDItems"  style="width:5%"><asp:Label runat="server" ID="lbl14" Text='<% #Eval("VENTASDRIVE", "{0:C}" ) %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>--%>
    </asp:Panel>
    </div>
</asp:Content>
