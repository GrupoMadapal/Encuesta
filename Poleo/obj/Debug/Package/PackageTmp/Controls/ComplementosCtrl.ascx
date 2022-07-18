<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComplementosCtrl.ascx.cs" Inherits="Poleo.Controls.ComplementosCtrl" %>


<asp:Label runat="server" Text="COMPLEMENTOS" Font-Bold="true" Font-Italic="true" Font-Size ="X-Large" > </asp:Label>
<br />
<asp:Panel runat="server" ScrollBars="vertical"  Height="250px" >
    <asp:GridView ID="GridViewCom" runat="server" AutoGenerateColumns="True" CellPadding ="4" ForeColor ="#333333" GridLines ="Both" BorderStyle ="Solid" BorderColor ="Black" BorderWidth ="1px" >
        <FooterStyle BackColor="#FFFFFF" Font-Bold="False" ForeColor="White" />

<RowStyle BackColor="White" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />

<EditRowStyle BackColor="#FBFACE" />

<SelectedRowStyle BackColor="#FBFACE" ForeColor="Black" />

<PagerStyle BackColor="#D5D8DE" ForeColor="Black" HorizontalAlign="Right" />

<HeaderStyle BackColor="#000000" Font-Bold="False" ForeColor="White" />

<AlternatingRowStyle BackColor="LightSteelBlue" />

        </asp:GridView>
    </asp:Panel>
