<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Poleo._Default" %>

<%@ Register Src="Controls/VentasCtrl.ascx" TagName="VentasCtrl"   TagPrefix="CTLVentas" %>
<%@ Register Src="Controls/PizzasCtrl.ascx" TagName="PizzasCtrl"   TagPrefix="CTLPizzas" %>
<%@ Register Src="Controls/ComplementosCtrl.ascx" TagName="ComplementosCtrl"   TagPrefix="CTRLComplementos" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="MainContent">
<%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="../Scripts/jquery-2.1.4.js"></script>
<script src="../Scripts/jquery-ui-1.11.4.js"></script>
<link href="../Content/themes/base/autocomplete.css" rel="stylesheet" />
<link href="../Content/themes/base/datepicker.css" rel="stylesheet" />
<script type="text/javascript">

    $(function () {
        $("[id$=TextBoxStart]").datepicker({
            dateFormat: 'dd/mm/yy'
        });
    });
    $(function () {
        $("[id$=TextBoxEnd]").datepicker({
            dateFormat: 'dd/mm/yy'
        });
    });
    $(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
            $("[id$=TextBoxStart]").datepicker({ dateFormat: 'dd/mm/yy' });
            $("[id$=TextBoxEnd]").datepicker({ dateFormat: 'dd/mm/yy' });
        }

    });
</script>
    <style>
        txtCSS {
            float: left;
            width:200px
  }
  btnCSS{ float:left;
          position:absolute;
            

  }
  .calendar{ position: relative;}
  
  .formItem label {
    display: block;
    text-align: center;

}
.button{
 padding: 10px 35px;
 overflow:hidden;
}
.button:before {
 font-family: FontAwesome;
 content:"\f07a";
 position: absolute;
 top: 11px;
 left: -30px;
 transition: all 200ms ease;
}
.button:hover:before {
 left: 7px;
}
.elementes
{
    border:0px;
    padding:0px;
    margin:0 auto;
    display:inline-block;
    position:relative;
   
}
.btnExcel{
    border-radius:50px;
    border:1px solid white;
    padding:0px;
    margin:5px;
    
}
.btnExcelText{
   border-top-right-radius:50px;
   border-bottom-right-radius:50px;
   color:white;
   font-size:10px;
}
.btnExcelTD
{
 background-color:#137A0E;
 border-bottom-left-radius:50px;
 border-top-left-radius:50px;
 width:35px;
 height:35px;
}
.messageError
{
    text-align:center;
    color:red;
    font-size:16px;

}

</style>
    <section class="featured">
        <div class="content-wrapper">           
                    <asp:UpdatePanel runat="server" ID="combos">
                        <ContentTemplate>
                            <table style="width:99%; max-width:99%">
                             <tr>
                                 <td> <div style="text-align:center;"> <asp:Label  runat="server"  ID="Label4" Text="Ubicación" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
                                 <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label5" Text="Tipo" Font-Bold ="true" Font-Size="Large" ></asp:Label></div></td>
                                 <td> <div style="text-align:center;"><asp:Label runat="server" ID="msj2" Text="Tienda" Font-Bold ="true" Font-Size="Large"></asp:Label></div></td>
                                 <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label2" Text="Año" Font-Bold ="true" Font-Size="Large"></asp:Label> </div></td>
                                 <td> <div style="text-align:center;"><asp:Label runat="server" ID="Label6" Text="Numero Semana" Font-Bold ="true" Font-Size="Large"></asp:Label></div> </td> 
                            </tr>
                            <tr>
                                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="lstUbicacion"  Width="150px" AutoPostBack="true" OnSelectedIndexChanged="lstUbicacion_SelectedIndexChanged"  ></asp:DropDownList> </div></td>
                                <td ><div style="text-align:center;"><asp:DropDownList runat="server" ID="lstTiposTienda" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="lstTiposTienda_SelectedIndexChanged"></asp:DropDownList></div></td>
                                <td><div style="text-align:center;"><asp:DropDownList runat="server" ID="LstTiendas" Width="150px"  AutoPostBack="true" OnSelectedIndexChanged="LstTiendas_SelectedIndexChanged" ></asp:DropDownList></div></td>
                                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID ="DDLYears" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DDLYears_SelectedIndexChanged" ></asp:DropDownList></div></td>
                                <td> <div style="text-align:center;"><asp:DropDownList runat="server" ID="fecha" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="fecha_SelectedIndexChanged"> </asp:DropDownList> </div></td>
                            </tr>
                           </table>                       
                            <table>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label1" Text="Fecha Inicial" Font-Bold ="true" Font-Size="Large"></asp:Label></td>
                                    <td><asp:TextBox ID="TextBoxStart" runat="server" Width="150px" CssClass="txtCSS"></asp:TextBox></td>
                                    <td><asp:Label runat="server" ID="Label3" Text="Fecha Final" Font-Bold ="true" Font-Size="Large" ></asp:Label></td>
                                    <td><asp:TextBox ID="TextBoxEnd" runat="server" Width="150px"  CssClass="txtCSS"></asp:TextBox></td>
                                    <td><asp:Label runat="server" ID="Label7" Text="Cupon:" Font-Bold ="true" Font-Size="Large"></asp:Label><%--<asp:TextBox ID="txtCupon" runat="server" Width="75px"  CssClass="txtCSS"></asp:TextBox>
                                        <asp:DropDownList runat="server" ID="ddlCupon" Width="80px"></asp:DropDownList>
                                         
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel> 
                                                       
               <table>
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
                       <table>
                           <tr style=" white-space:nowrap;">
                               <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnimgCupon" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px"  OnClick="btnimgCupon_Click" /> </td>
                               <td class="elementes"><asp:Button runat="server" ID="btnCupon" Text="CUPONES"  CssClass="elementes  btnExcelText " Width="100px" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnCupon_Click" /></td>
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
                                    <td class="elementes btnExcelTD"> <asp:ImageButton runat="server" ID="btnVentasDQ" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnVentasDQ_Click" /></td>
                                    <td class="elementes"><asp:Button runat="server" ID="btnVentasDQText" Text="Ventas Dairy Queen"  CssClass="elementes  btnExcelText "  Height="35px" BackColor="#137A0E" BorderColor="#137A0E" OnClick="btnVentasDQText_Click" /></td>
                                </tr>
                            </table>
                        </td> 
                        <td>
                            <table>
                                <tr style=" white-space:nowrap;">
                                    <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="btnIndMaestro" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnIndMaestro_Click" /></td>
                                    <td class="elementes"><asp:Button runat="server" ID="btnIndMaestroText" Text="Indicador Maestro"  CssClass="elementes  btnExcelText "  Height="35px" BackColor="#137A0E" BorderColor="#137A0E"  OnClick="btnIndMaestroText_Click"/></td>
                                </tr>
                            </table>
                        </td>
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
                                    <td class="elementes "><asp:Button ID="btnFiltro" runat="server" Text="Desplegar" OnClick="btnFiltro_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass=" elementes btnExcelText" Width="200px"  /></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr style="white-space:nowrap;">
                                    <td class="elementes btnExcelTD"><asp:ImageButton runat="server" ID="ibtTiempoServicio" ImageUrl="~/Images/ExcelButton.png" CssClass="btnExcel" Width="25px" Height="22px" OnClick="btnTiempoServicio_Click" /></td>
                                    <td class="elementes"><asp:Button ID="btnTiempoServicio" runat="server" Text="Tiempo de servicio" OnClick="btnTiempoServicio_Click" Height="35px" BackColor="#137A0E" BorderColor="#137A0E" CssClass=" elementes btnExcelText" Width="200px"/></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"><asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label></td>
                    </tr> 
            </table>           
        </div>
    </section>   
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <CTLVentas:VentasCtrl ID="idCTLVentas" runat="server" Visible="false"  />
    <br />
    <br />
    <table>
        <tr> 
            <td style="width:100%;"><CTLPizzas:PizzasCtrl ID="PizzasCtrl" runat="server" Visible="false" /></td>
            <td><CTRLComplementos:ComplementosCtrl ID="ComCtrl" runat="server" Visible="false" /> </td>
        </tr>
    </table>--%>   
    <script src="Scripts/bootstrap.js"></script>
    <%--<script src="Scripts/bootstrap.min.js"></script>--%>
    <asp:Label ID="lblUser" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>
    <table style="width:100%;">
        <tr>
           <td>
               <table style="width:80%;"  align="center">
                   <tr>
                       <td>
                           <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                              <!-- Indicators -->
                              <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                              </ol>

                              <!-- Wrapper for slides -->
                              <div class="carousel-inner" role="listbox" style="align-content:center;">
                                <div class="item active">
                                  <img src="Images/Carousel/15259734_1470963869598577_2921272096247029014_o.jpg" alt="...">
                                  <div class="carousel-caption">
                                    ...
                                  </div>
                                </div>
                                <div class="item">
                                  <img src="Images/Carousel/16602947_1563856773642619_2196270466766185271_n.png" alt="...">
                                  <div class="carousel-caption">
                                    ...
                                  </div>
                                </div>
                                <div class="item">
                                  <img src="Images/Carousel/17545611_408597229501217_2080797769863736357_o.jpg" alt="...">
                                  <div class="carousel-caption">
                                    ...
                                  </div>
                                </div>
                                <div class="item">
                                  <img src="Images/Carousel/17635173_406654459695494_2361420118644115122_o.jpg" alt="...">
                                  <div class="carousel-caption">
                                    ...
                                  </div>
                                </div>
                              </div>

                              <!-- Controls -->
                              <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                              </a>
                              <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                              </a>
                            </div>
                        </td>
                   </tr>
               </table>
           </td>
        </tr>
    </table>
 </asp:Content>




