<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VentasCtrl.ascx.cs" Inherits="Poleo.Controls.VentasCtrl" %>

<style >
    .HEADER
    {
        position:absolute;
        top:expression(this.offsetParent.scrollTop); 
        width:980px; 
    }
.TDItems
{
    text-align:center;
    padding:0px;
    border: 0px solid white;

}

.headTable
{
    width:100%;
    width:-webkit-calc(100% - 17px);
    width: -moz-calc(100% - 17px);
    width: calc(100% - 17px);
    font-size: 0.90em;
}
    
</style>
<style type="text/css">
::-webkit-scrollbar {
  width: 6px;
}
/*::-webkit-scrollbar-button {
  width: 0px;
  height: 0px;
}*/

::-webkit-scrollbar-thumb {
  background: #C8C8C8;
  /*border: 0px none #ffffff;*/
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
  /*border: 0px none #ffffff;
  border-radius: 0px;*/
}
/*
::-webkit-scrollbar-track:hover {
  background: #008000;
}
::-webkit-scrollbar-track:active {
  background: #0080ff;
}
::-webkit-scrollbar-corner {
  background: transparent;
}*/
</style>
<%--<asp:Label runat="server" Text="VENTAS POR DÍA" Font-Bold="true" Font-Italic="true" Font-Size ="X-Large" > </asp:Label>
<br />

 <asp:Panel runat="server" ScrollBars="vertical"  Height="250px" Width="1000px"  >
    <asp:GridView ID="GridViewVentas" runat="server" AutoGenerateColumns="false" CellPadding ="4"  ShowHeader="true" ForeColor ="#333333" GridLines ="Both" BorderStyle ="Solid" BorderColor ="Black" BorderWidth ="1px" >
        <FooterStyle BackColor="#FFFFFF" Font-Bold="False" ForeColor="White" />

<RowStyle BackColor="White" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />

<EditRowStyle BackColor="#FBFACE" />

<SelectedRowStyle BackColor="#FBFACE" ForeColor="Black" />

<PagerStyle BackColor="#D5D8DE" ForeColor="Black" HorizontalAlign="Center" />

<HeaderStyle BackColor="#000000" Font-Bold="False" ForeColor="White"   CssClass="HEADER" Wrap="true" />

<AlternatingRowStyle BackColor="LightSteelBlue" />
        <Columns>
            <asp:BoundField DataField = "Dia" 
                    HeaderText = "Día" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Dia" 
                    DataFormatString = "{0}" 
                   HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
               
                />

            <asp:BoundField DataField = "Tienda" 
                    HeaderText = "Tienda" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Tienda"  
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
                    DataFormatString = "{0}" />  

            <asp:BoundField DataField = "Fecha" 
                    HeaderText = "Fecha" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Fecha" 
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
                    DataFormatString = "{0:d}" />

            <asp:BoundField DataField = "VentasReales" 
                    HeaderText = "Ventas Reales" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasReales" 
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
                    DataFormatString = "{0:C}" />

            <asp:BoundField DataField = "VentasRegaladas" 
                    HeaderText = "Ventas Regaladas" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasRegaladas" 
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
                    DataFormatString = "{0:C}" />                   

            <asp:BoundField DataField = "Ordenes" 
                    HeaderText = "Ordenes" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Ordenes"
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%" 
                    DataFormatString = "{0:D}" />

            <asp:BoundField DataField = "OrdenesRegaladas" 
                    HeaderText = "Ordenes Regaladas" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "OrdenesRegaladas"
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%" 
                    DataFormatString = "{0:D}" />

            <asp:BoundField DataField = "Utilizado" 
                    HeaderText = "Utilizado" 
                    InsertVisible = "False" ReadOnly = "True"
                    HeaderStyle-Width="9%"
                    ItemStyle-Width="9%" 
                    SortExpression = "Utilizado" 
                    DataFormatString = "{0:C}" />            

            <asp:BoundField DataField = "VentasReparto" 
                    HeaderText = "Ventas Reparto" 
                    InsertVisible = "False" ReadOnly = "True"
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%" 
                    SortExpression = "VentasReparto" 
                    DataFormatString = "{0:C}" />

            <asp:BoundField DataField = "VentasMostrador" 
                    HeaderText = "Ventas Mostrador" 
                    InsertVisible = "False" ReadOnly = "True"
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%" 
                    SortExpression = "VentasMostrador" 
                    DataFormatString = "{0:C}" />

            <asp:BoundField DataField = "VentasRestaurante" 
                    HeaderText = "Ventas Restaurante" 
                    InsertVisible = "False" ReadOnly = "True" 
                    HeaderStyle-Width="9%" 
                    ItemStyle-Width="9%"
                    SortExpression = "VentasRestaurante" 
                    DataFormatString = "{0:C}" />
        </Columns>
    </asp:GridView>
        </asp:Panel>


<asp:Label runat="server" Text="VENTAS TOTALES" Font-Bold="true" Font-Italic="true" Font-Size ="X-Large"> </asp:Label>
<br />
<asp:Panel runat="server" ScrollBars="vertical"  Height="200px" >
        <asp:GridView runat="server" ID ="TotalDatagrid"  AutoGenerateColumns="false" CellPadding ="4" ForeColor ="#333333" GridLines ="Both" BorderStyle ="Solid" BorderColor ="Black" BorderWidth ="1px">
            <FooterStyle BackColor="#FFFFFF" Font-Bold="False" ForeColor="White" />

            <RowStyle BackColor="LightSteelBlue" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />

            <EditRowStyle BackColor="#FBFACE" />

            <SelectedRowStyle BackColor="#FBFACE" ForeColor="Black" />

            <PagerStyle BackColor="#D5D8DE" ForeColor="Black" HorizontalAlign="Right" />

            <HeaderStyle BackColor="#000000" Font-Bold="False" ForeColor="LightSteelBlue" />

            <AlternatingRowStyle BackColor="White" />
            <Columns>
            

            

            <asp:BoundField DataField = "VentasRealesTotal" 
                    HeaderText = "Ventas Reales" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasRealesTotal" 
                    DataFormatString = "{0:C}" />

                <asp:BoundField DataField = "VentasRegaladas" 
                    HeaderText = "Ventas Regaladas" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasRegaladas" 
                    DataFormatString = "{0:C}" /> 

                <asp:BoundField DataField = "OrdenesTotales" 
                    HeaderText = "Ordenes" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "OrdenesTotales" 
                    DataFormatString = "{0:D}" />

            <asp:BoundField DataField = "OrdenesRegaladas" 
                    HeaderText = "Ordenes Regaladas" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "OrdenesRegaladas" 
                    DataFormatString = "{0:D}" />

            <asp:BoundField DataField = "Utilizado" 
                    HeaderText = "Utilizado" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Utilizado" 
                    DataFormatString = "{0:C}" /> 

            <asp:BoundField DataField = "VentasRepartoTotal" 
                    HeaderText = "Ventas Reparto" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasRepartoTotal" 
                    DataFormatString = "{0:C}" />

            <asp:BoundField DataField = "VentasMostradorTotal" 
                    HeaderText = "Ventas Mostrador" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasMostradorTotal" 
                    DataFormatString = "{0:C}" />

                <asp:BoundField DataField = "VentasRestauranteTotal" 
                    HeaderText = "Ventas Restaurante" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "VentasRestauranteTotal" 
                    DataFormatString = "{0:C}" />
        </Columns>


        </asp:GridView>
    </asp:Panel>--%>
<div class="TitleTblGrd">VENTAS DIARIAS</div>
<asp:Panel  runat="server" ID="pnlVentasSucursales" CssClass="TableGrd" Width="100%">
    <%--<div class="TitleFacturas">
        <asp:Label runat="server" Text="VENTAS DIARIAS"></asp:Label>
     </div>--%>
    
    <div  style="width:100%">
        <table class="headTable" >
            <tr  style="width:100%; ">
                <td rowspan="2" class="TDItems" style="width:9%"><asp:Label runat="server" Text="DÍA"></asp:Label></td>
                <td rowspan="2" class="TDItems" style="width:10%"><asp:Label runat="server" Text="FECHA"></asp:Label></td>
                <td rowspan="2" class="TDItems" style="width:9%"><asp:Label runat="server" Text="SUCURSAL"></asp:Label></td>
                <td colspan="2" class="TDItems" style="width:18%"><asp:Label runat="server" Text="VENTAS"></asp:Label></td>
                <td colspan="2" class="TDItems" style="width:14%"><asp:Label runat="server" Text="ORDENES"></asp:Label></td>
                <td rowspan="2" class="TDItems" style="width:10%"><asp:Label runat="server" Text="UTILIZADO"></asp:Label></td>
                <td colspan="3" class="TDItems" style="width:30%"><asp:Label runat="server" Text="VENTAS"></asp:Label></td>
            </tr>
            <tr  style="width:100%; ">
                <td class="TDItems" style="width:10%"><asp:Label runat="server" Text="REALES"></asp:Label></td>
                <td class="TDItems" style="width:8%"><asp:Label runat="server" Text="REGALADAS"></asp:Label></td>
                <td class="TDItems" style="width:7%"><asp:Label runat="server" Text="TOTALES"></asp:Label></td>
                <td class="TDItems" style="width:7%"><asp:Label runat="server" Text="REGALADAS"></asp:Label></td>
                <td class="TDItems" style="width:10%"><asp:Label runat="server" Text="REPARTO"></asp:Label></td>
                <td class="TDItems" style="width:10%"><asp:Label runat="server" Text="MOSTRADOR"></asp:Label></td>
                <td class="TDItems" style="width:10%"><asp:Label runat="server" Text="RESTAURANTE"></asp:Label></td>
            </tr>
        </table>
    </div>
    <div style="overflow-x:hidden; overflow-y:scroll; max-height:300px;">
        <table style="width:100%">
            <asp:Repeater runat="server" ID="repeatVentas">
                <ItemTemplate>
                    <tr  style="width:100%; background-color:#207CFF;">
                        <td class="TDItems"  style="width:9%" ><asp:Label runat="server" ID="lbl1" Text='<% #Eval("Dia") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl2" Text='<% #Eval("Fecha") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:9%"><asp:Label runat="server" ID="lbl3" Text='<% #Eval("Tienda") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasReales", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:8%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("VentasRegaladas", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("Ordenes") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("OrdenesRegaladas") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("UtilizadoReal", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("VentasReparto", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("VentasMostrador", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl11" Text='<% #Eval("VentasRestaurante", "{0:C}") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                        <tr  style="width:100%; background-color:#37547F;">
                        <td class="TDItems"  style="width:9%"><asp:Label runat="server" ID="lbl1" Text='<% #Eval("Dia") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl2" Text='<% #Eval("Fecha") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:9%"><asp:Label runat="server" ID="lbl3" Text='<% #Eval("Tienda") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasReales", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:8%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("VentasRegaladas", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("Ordenes") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("OrdenesRegaladas") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("UtilizadoReal", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("VentasReparto", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("VentasMostrador", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl11" Text='<% #Eval("VentasRestaurante", "{0:C}") %>'></asp:Label></td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>    
        </table>
    </div>
    <div>
        <table class="headTable">
            <asp:Repeater runat="server" ID="repeatFull">
                <ItemTemplate>
                    <tr style="width:100%;">
                        <td class="TDItems"  style="width:9%" ><asp:Label runat="server" ID="lbl1" Text="" ></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl2" Text="" ></asp:Label></td>
                        <td class="TDItems"  style="width:9%"><asp:Label runat="server" ID="lbl3" Text="TOTAL:"></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl4" Text='<% #Eval("VentasRealesTotal", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:8%"><asp:Label runat="server" ID="lbl5" Text='<% #Eval("VentasRegaladas", "{0:C}") %>' ></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl6" Text='<% #Eval("OrdenesTotales") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:7%"><asp:Label runat="server" ID="lbl7" Text='<% #Eval("OrdenesRegaladas") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl8" Text='<% #Eval("Utilizado", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl9" Text='<% #Eval("VentasRepartoTotal", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl10" Text='<% #Eval("VentasMostradorTotal", "{0:C}") %>'></asp:Label></td>
                        <td class="TDItems"  style="width:10%"><asp:Label runat="server" ID="lbl11" Text='<% #Eval("VentasRestauranteTotal", "{0:C}") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Panel>




