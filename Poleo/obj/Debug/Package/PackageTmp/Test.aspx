<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Poleo.Test" %>
<%@ Register Src="Controls/VentasCtrl.ascx" TagName="ListPicker"   TagPrefix="uc1" %> 
<%@ Register Src="Controls/UpLoadFile.ascx" TagName="UpLoadFileCtrl"   TagPrefix="CTRLUpLoadFile" %>
<%@ Register Src="Controls/ProveedoresCtrl.ascx" TagName="ProveedoresCtrl"   TagPrefix="ProveedoresCtrl" %>
<%@ Register Src="Controls/FacturasCtrl.ascx" TagName="FacturasCtrl"   TagPrefix="FacturasCtrl" %>
<%@ Register Src="Controls/LoadXMLFactura.ascx" TagName="LoadXMLFactura"   TagPrefix="LoadXMLFactura" %>


<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script language="javascript" type="text/javascript"> 
      $(document).ready(function() { 
            //agregar una nueva columna con todo el texto 
            //contenido en las columnas de la grilla 
            //contains de Jquery es CaseSentive, por eso a minúscula
      $(".filtrar tr:has(td)").each(function() { 
      var t = $(this).text().toLowerCase();  
                $("<td class='indexColumn'></td>") 
                .hide().text(t).appendTo(this); 
            });
            //Agregar el comportamiento al texto (se selecciona por el ID) 
            $("#texto").keyup(function() { 
                var s = $(this).val().toLowerCase().split(" "); 
                $(".filtrar tr:hidden").show(); 
                $.each(s, function() { 
                     $(".filtrar tr:visible .indexColumn:not(:contains('" 
                     + this + "'))").parent().hide(); 
                });  
            });  
        });
     </script>
    <form id="form1" runat="server">
        <asp:Button ID="btnXLS" runat="server" Text="Prueba XLS" OnClick="btnXLS_Click" />
        <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTest_Click" />
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblTime" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnTestxlFile" runat="server" Text="Archivo ventas test DP" OnClick="btnTestxlFile_Click" />
        <asp:Button ID="btnTestxlFileDq" runat="server" Text="Archivo ventas test DQ" OnClick="btnTestxlFileDQ_Click" />
    <div>
        <br />
        <CTRLUpLoadFile:UpLoadFileCtrl runat="server"></CTRLUpLoadFile:UpLoadFileCtrl>   
</div>
        <div>
            <%--<asp:Button runat="server" ID="btnTestWS" Text="TEST WS" OnClick="btnTestWS_Click" />--%>
        </div>
        <div>
            <LoadXMLFactura:LoadXMLFactura runat="server"></LoadXMLFactura:LoadXMLFactura>
        </div>
        <div>
            <ProveedoresCtrl:ProveedoresCtrl runat="server" />
        </div>
        <br />
        <br />
        <div>
            <FacturasCtrl:FacturasCtrl runat="server" />
        </div>
        <br />
        <br />
        <div>
            <asp:TextBox ID="texto" runat="server"></asp:TextBox>
            <br />
            <br />
            <%--<asp:GridView ID="gvTest" runat="server" class="filtrar" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblDes" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
            <asp:CheckBoxList ID="lstCupons" runat="server" class="filtrar" RepeatColumns="4" RepeatDirection="Horizontal"></asp:CheckBoxList>
        </div>
    </form>
</body>
</html>

