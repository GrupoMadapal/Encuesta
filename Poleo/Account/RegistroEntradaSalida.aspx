<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroEntradaSalida.aspx.cs" Inherits="Poleo.Account.RegistroEntradaSalida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID ="lblFactura" runat="server" Text="Numero de Factura" ></asp:Label>
    <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label> 
        <asp:RadioButton runat="server"  ID="rbEntrada" Text="ENTRADA"  AutoPostBack="true" />
        <asp:RadioButton runat="server"  ID="rbSalida" Text="SALIDA"  AutoPostBack="true"/>
        <br />
        <asp:Label runat="server" ID="lblCantidad" Text="Cantidad"></asp:Label>
        <asp:TextBox ID="txtCantidad" runat="server" ></asp:TextBox>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtCantidad" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="\d+(\.\d{1,2})?">
</asp:RegularExpressionValidator>
    </div>
    </form>
</body>
</html>
