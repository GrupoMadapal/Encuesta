<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_Training.aspx.cs" Inherits="Poleo.Pages.Pag_Training" %>
<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Controls" ContentPlaceHolderID="TitleContent" runat="server">
    <table style="width:100%; text-align:center;">
        <tr>
            <td>
                <table class="tblTitle" align="center" style="width:350px">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitle" runat="server" >Entrenamiento</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <MDP:Filter ID="CtrlFilter" runat="server" TypeFilter="DQ" />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblInfo" runat="server">
        La información solicitada se debe capturar con valores numericos, representando el porcentaje
        del concepto.
    </asp:Label>
    <br />
    <asp:GridView ID="gvwStore" runat="server" AutoGenerateColumns="false"  BorderColor="White" RowStyle-BorderColor="White" BorderWidth="4px" RowStyle-BorderWidth="3px"
        Width="100%" CssClass="BackGroundStyleContent">
        <Columns>
            <asp:TemplateField HeaderText="Numero Tienda" HeaderStyle-BorderColor="White" HeaderStyle-BorderWidth="1px" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lblNumberStore" runat="server" Text='<%# Bind("Number_tienda") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre Tienda" HeaderStyle-BorderColor="White" HeaderStyle-BorderWidth="1px" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lblNameStore" runat="server" Text='<%# Bind("Nombre_tienda") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="%" HeaderStyle-BorderColor="White" HeaderStyle-BorderWidth="1px" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                <ItemTemplate>
                    <asp:TextBox ID="txtTraining" runat="server" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTraining" runat="server" ControlToValidate="txtTraining" ErrorMessage="*"
                        CssClass="messageError" ToolTip="Campo requerido" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTraining" runat="server" ControlToValidate="txtTraining" ErrorMessage="*"
                        ValidationExpression="^\d+([,\.]\d{1,2})?$" ToolTip="Formato Incorrecto ###.##" CssClass="messageError" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="cvTraining" runat="server" ControlToValidate="txtTraining" ValueToCompare="-1" ToolTip="No se permiten valores negativos" 
                        Type="Double" Operator="GreaterThan" ErrorMessage="*" CssClass="messageError" Display="Dynamic" ></asp:CompareValidator>
                    <asp:CompareValidator ID="cvlTraining" runat="server" ControlToValidate="txtTraining" ValueToCompare="100" ToolTip="El valor debe ser igual o menor a 100 %"
                        Type="Double" Operator="LessThanEqual" ErrorMessage="*" CssClass="messageError" Display="Dynamic"></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-BorderColor="White" HeaderStyle-BorderWidth="1px" ItemStyle-Width="35%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="35%">
                <ItemTemplate>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <table style="width:100%;">
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnAcept" runat="server" Text="Aceptar" OnClick="btnAcept_Click" ForeColor="Black" />
            </td>
        </tr>
    </table>
</asp:Content>
