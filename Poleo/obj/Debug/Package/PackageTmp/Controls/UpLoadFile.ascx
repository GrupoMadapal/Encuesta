<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpLoadFile.ascx.cs" Inherits="Poleo.Controls.UpLoadFile" %>


<asp:Button runat="server" ID="btnUpLoadAUTO" OnClick="btnUpLoadAUTO_Click" Text="PROCESAR" />


    <asp:Panel runat="server" ID="idpanel" ScrollBars="Auto" Height="500px">
        <asp:GridView runat="server" ID="IdGridViewResultUpLoad"  AutoGenerateColumns="false" CellPadding ="4" ForeColor ="#333333" GridLines ="Both" BorderStyle ="Solid" BorderColor ="Black" BorderWidth ="1px">
            <FooterStyle BackColor="#FFFFFF" Font-Bold="False" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />
            <EditRowStyle BackColor="#FBFACE" />
            <SelectedRowStyle BackColor="#FBFACE" ForeColor="Black" />
            <PagerStyle BackColor="#D5D8DE" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#000000" Font-Bold="False" ForeColor="White" />
            <AlternatingRowStyle BackColor="LightSteelBlue" />  
            <Columns>
            <asp:BoundField DataField = "totalRegister" 
                    HeaderText = "Total Registros" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "totalRegister" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "TotalCorrect" 
                    HeaderText = "Registros Correctos" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "TotalCorrect" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "TotalError" 
                    HeaderText = "Registros InCorrectos" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "TotalError" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "NumberShop" 
                    HeaderText = "Tienda " 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "NumberShop" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "Date" 
                    HeaderText = "Fecha" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "Date" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "TypeFile" 
                    HeaderText = "Tipo archivo " 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "TypeFile" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "TableName" 
                    HeaderText = "Nombre" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "TableName" 
                    DataFormatString = "{0}" />

                <asp:BoundField DataField = "NameFile" 
                    HeaderText = "Nombre completo" 
                    InsertVisible = "False" ReadOnly = "True" 
                    SortExpression = "NameFile" 
                    DataFormatString = "{0}" />
                </Columns>         
        </asp:GridView>
    </asp:Panel>
<asp:Button runat="server" ID="testConection" Text="test" OnClick="testConection_Click" />
