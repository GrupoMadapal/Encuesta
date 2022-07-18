<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_MasterInd.aspx.cs" Inherits="Poleo.Pages.Pag_MasterInd" %>
<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>

<asp:Content ID="Filters" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Controls" ContentPlaceHolderID="FeaturedContent" runat="server">
    <MDP:Filter ID="CtrlFilter" runat="server" TypeFilter="DP" />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ButtonsContent" runat="server">
    <asp:Label ID="lblInfo" runat="server">
        La información solicitada se debe capturar con valores numericos, representando el porcentaje
        de cada concepto.
    </asp:Label>
    <table style="width:100%">
        <tr>
            <td style="width:25%">
                <asp:Label ID="lblFullTempalte" runat="server" Text="Plantilla Completa :" Font-Bold ="true" Font-Size="Large"></asp:Label>
            </td>
            <td style="width:25%">
                <asp:TextBox ID="txtFullTemplate" runat="server" Width="150px" CssClass="txtCSS"></asp:TextBox>
                <asp:Label runat="server" ID="por1">%</asp:Label>
                <asp:RequiredFieldValidator ID="rfvFullTemplate" runat="server" ControlToValidate="txtFullTemplate" ErrorMessage="*"
                    CssClass="messageError" ToolTip="Campo requerido" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFullTempalte" runat="server" ControlToValidate="txtFullTemplate" ErrorMessage="*"
                    ValidationExpression="^\d+([,\.]\d{1,2})?$" ToolTip="Formato Incorrecto ###.##" CssClass="messageError" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cvFullTemplate" runat="server" ControlToValidate="txtFullTemplate" ValueToCompare="-1" ToolTip="No se permiten valores negativos" 
                    Type="Double" Operator="GreaterThan" ErrorMessage="*" CssClass="messageError" Display="Dynamic" ></asp:CompareValidator>
                <asp:CompareValidator ID="cvlFullTemplate" runat="server" ControlToValidate="txtFullTemplate" ValueToCompare="100" ToolTip="El valor debe ser igual o menor a 100 %"
                    Type="Double" Operator="LessThanEqual" ErrorMessage="*" CssClass="messageError" Display="Dynamic"></asp:CompareValidator>
            </td>
            <td style="width:25%">
                <asp:Label ID="lblTraining" runat="server" Text="Entrenamiento :" Font-Bold ="true" Font-Size="Large"></asp:Label>
            </td>
            <td style="width:25%">
                <asp:TextBox ID="txtTraining" runat="server" Width="150px" CssClass="txtCSS"></asp:TextBox>
                <asp:Label runat="server" ID="por2">%</asp:Label>
                <asp:RequiredFieldValidator ID="rfvTraining" runat="server" ControlToValidate="txtTraining" ErrorMessage="*"
                    CssClass="messageError" ToolTip="Campo requerido" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTraining" runat="server" ControlToValidate="txtTraining" ErrorMessage="*"
                    ValidationExpression="^\d+([,\.]\d{1,2})?$" ToolTip="Formato Incorrecto ###.##" CssClass="messageError" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cvTraining" runat="server" ControlToValidate="txtTraining" ValueToCompare="-1" ToolTip="No se permiten valores negativos" 
                    Type="Double" Operator="GreaterThan" ErrorMessage="*" CssClass="messageError" Display="Dynamic" ></asp:CompareValidator>
                <asp:CompareValidator ID="cvlTraining" runat="server" ControlToValidate="txtTraining" ValueToCompare="100" ToolTip="El valor debe ser igual o menor a 100 %"
                    Type="Double" Operator="LessThanEqual" ErrorMessage="*" CssClass="messageError" Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCommunication" runat="server" Text="Comunicación y Motivación :" Font-Bold="true" Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCommunication" runat="server" Width="150px" CssClass="txtCSS"></asp:TextBox>
                <asp:Label runat="server" ID="por3">%</asp:Label>
                <asp:RequiredFieldValidator ID="rfvCommunication" runat="server" ControlToValidate="txtCommunication" ErrorMessage="*"
                    CssClass="messageError" ToolTip="Campo requerido" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCommunication" runat="server" ControlToValidate="txtCommunication" ErrorMessage="*"
                    ValidationExpression="^\d+([,\.]\d{1,2})?$" ToolTip="Formato Incorrecto ###.##" CssClass="messageError" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cvCommunication" runat="server" ControlToValidate="txtCommunication" ValueToCompare="-1" ToolTip="No se permiten valores negativos" 
                    Type="Double" Operator="GreaterThan" ErrorMessage="*" CssClass="messageError" Display="Dynamic" ></asp:CompareValidator>
                <asp:CompareValidator ID="cvlCommunication" runat="server" ControlToValidate="txtCommunication" ValueToCompare="100" ToolTip="El valor debe ser igual o menor a 100 %"
                    Type="Double" Operator="LessThanEqual" ErrorMessage="*" CssClass="messageError" Display="Dynamic"></asp:CompareValidator>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:center;">
                <asp:Button ID="btnAcept" runat="server" Text="Aceptar" OnClick="btnAcept_Click" />
            </td>
        </tr>
    </table>
    <asp:Label runat="server" ID="lblMesaje"></asp:Label>
    <asp:Label runat="server" ID="lblMesajeError" CssClass="messageError"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>
