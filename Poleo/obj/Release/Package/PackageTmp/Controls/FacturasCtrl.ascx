<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacturasCtrl.ascx.cs" Inherits="Poleo.Controls.FacturasCtrl" %>
 <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>--%>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript" ></script>--%>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="../Scripts/jquery-2.1.4.js"></script>
<script src="../Scripts/jquery-ui-1.11.4.js"></script>
<link href="../Content/themes/base/autocomplete.css" rel="stylesheet" />
<link href="../Content/themes/base/datepicker.css" rel="stylesheet" />
    <script type="text/javascript">

        $(function () {
            $("[id$=txtFechaFacturacionFrom]").datepicker({
               
                dateFormat: 'dd/mm/yy'
            });
        });
        $(function () {
            $("[id$=txtFechaVigenciaFrom]").datepicker(
                {
                   
                    dateFormat: 'dd/mm/yy'
                });
        });
        $(function () {
            $("[id$=txtFechaPagoFrom]").datepicker({
                
                dateFormat: 'dd/mm/yy'
               
            });
        });
        $(function () {
            $("[id$=txtFechaFacturacionTo]").datepicker({
              
                dateFormat: 'dd/mm/yy'
            });
        });
        $(function () {
            $("[id$=txtFechaVigenciaTo]").datepicker(
                {
                   
                    dateFormat: 'dd/mm/yy'
                });
        });
        $(function () {
            $("[id$=txtFechaPagoTo]").datepicker({
              
                dateFormat: 'dd/mm/yy'
            });
        });
        $(function () {
            $("[id$=txtProveedor]").autocomplete({
                source: function (request, response) {
                    var param = { TextProveedores: $('[id$=txtProveedor]').val() };
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/WebServices/AutoCompleteFacturas.asmx/GetAutoCompleteProveedores",
                        data: JSON.stringify(param),
                        dataType: "json",
                        success: function (data) {
                            var dataFromServer = data.d.split(":");
                            response(dataFromServer);
                        },
                        error: function (result) {
                        }
                    });
                }
            });
        });

        $(function () {
            $("[id$=txtEmpresa]").autocomplete({
                source: function (request, response) {
                    var param = { TextEmpresa: $('[id$=txtEmpresa]').val() };
                    console.log("Entro");
                    console.log(param);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/WebServices/AutoCompleteFacturas.asmx/GetAutoCompleteEmpresa",
                        data: JSON.stringify(param),
                        dataType: "json",
                        success: function (data) {
                            var dataFromServer = data.d.split(":");
                            console.log("success");
                            response(dataFromServer);
                        },
                        error: function (result) {
                        }
                    });
                }
            });
        });
        $(function () {
            $("[id$=tableProveedor]").scrollLeft(300);
        });
    </script>
<style type="text/css">
 .button {
    margin: 10px;
    text-decoration: none;
    font: bold 15px 'Trebuchet MS',Arial, Helvetica; /*Change the em value to scale the button*/
    display: inline-block;
    text-align: center;
    color: #fff;    
    border: 1px solid #9c9c9c; /* Fallback style */
    border: 1px solid rgba(0, 0, 0, 0.3);
    text-shadow: 0 1px 0 rgba(0,0,0,0.4);    
    box-shadow: 0 0 .05em rgba(0,0,0,0.4);
    width:150px; 
    height:30PX;  
}
.button, 
.button span {
    -moz-border-radius: .3em;
    border-radius: .3em;
}
.button span {
    border-top: 1px solid #fff; /* Fallback style */
    border-top: 1px solid rgba(255, 255, 255, 0.5);
    display: block;
    padding: 0.5em 2.5em;    
    /* The background pattern */
    background-image: linear-gradient(45deg, rgba(0, 0, 0, 0.05) 25%, transparent 25%, transparent),
                      linear-gradient(-45deg, rgba(0, 0, 0, 0.05) 25%, transparent 25%, transparent),
                      linear-gradient(45deg, transparent 75%, rgba(0, 0, 0, 0.05) 75%),
                      linear-gradient(-45deg, transparent 75%, rgba(0, 0, 0, 0.05) 75%);

    /* Pattern settings */
    background-size: 3px 3px;            
}
.button:hover {
    box-shadow: 0 0 .1em rgba(0,0,0,0.4);
    font:bold 12px 'Trebuchet MS',Arial, Helvetica;
}
.button:active {
    /* When pressed, move it down 1px */
    position: relative;
    top: 1px;
}
.button-blue {
    background: #383636;
    background: -webkit-gradient(linear, left top, left bottom, from(#383636), to(#000000) );
    background: -moz-linear-gradient(-90deg,#383636, #000000);
    filter:  progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#383636', endColorstr='#000000');
}
.button-blue:hover {
    background:#000000;
    background: -webkit-gradient(linear, left top, left bottom, from(#000000), to(#383636) );
    background: -moz-linear-gradient(-90deg, #000000, #383636);
    filter:  progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#000000', endColorstr='#383636');            
}
.button-blue:active {
    background: #383636;
}
 .Calendar{
     visibility:hidden;
     width:10px;
     height:10px;
     position:absolute;
 }
 .divContent{
    margin: auto;
    width: 80%;
    border:0.8em solid #69140F;
    padding: 10px;
    background-color:#333333;
    font-size:0.7em;
    color:#E8E8E7;
    text-align:center;
 }
 .TitleFacturas{
     margin: auto;
    width: 50%;
    border:5px solid #69140F;
    padding: 10px;
    background-color:#69140F;
    border-top-left-radius:30px;
    border-top-right-radius: 30px;
    color:#E8E8E7;
   font: bold 25px 'Trebuchet MS',Arial, Helvetica;
   text-align:center;

}
 .divTextboxFecha{
  vertical-align:middle;
     margin:0px;
     position:relative;
     display:inline-block;
     width:100%;
 }
 .HEADERPLUS
 {
  border-top-left-radius:30px;
    border-top-right-radius: 30px;
    border:1px solid WHITE;
 }
 .buttonExcel{
     width:80px;
     height:45px;
     border-radius:5px;
     background-color:black;
     padding:0;
     background-repeat:no-repeat;
      }
 .buttonExcel:hover{
     width:80px;
     height:45px;
     border-radius:10px;
     background-repeat:no-repeat;
     padding:5px;
 }

</style>
<div class="TitleFacturas">
    <asp:Label runat="server" ID="lsbltitle" Text="EDITOR DE FACTURAS"></asp:Label>
</div>
<div class="divContent">
    <table  >
        <tr>
            <td><asp:Label runat="server" ID="lblProveedor" Text="PROVEEDOR:"></asp:Label></td>
            <td colspan="3"><asp:TextBox runat="server" ID="txtProveedor" Width="90%" ></asp:TextBox></td>
            <td><asp:Label runat="server" ID="lblEmpresa" Text="EMPRESA:"></asp:Label></td>
            <td colspan="3"><asp:TextBox runat="server" ID="txtEmpresa" Width="90%" ></asp:TextBox></td>
            <td><asp:Label runat="server" ID="lblActivo" Text="Activo:"></asp:Label><asp:CheckBox runat="server" ID="ckbActivo" Checked="true" /></td> 
        </tr>          
        <tr>
            <td rowspan="2" style="width:10%" ><asp:Label runat="server" ID="lblFechaFacturacion" Text="FECHA DE FACTURACION:"></asp:Label></td>
            <td style="width:8%"><asp:Label runat="server" Text="FROM:"></asp:Label></td>
            <td style="width:15%"><asp:TextBox runat="server" ID="txtFechaFacturacionFrom"  CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>            
            <td rowspan="2" style="width:10%" ><asp:Label runat="server" ID="lblFechaVigencia" Text="FECHA DE VIGENCIA:"></asp:Label></td>
            <td style="width:8%"><asp:Label runat="server" Text="FROM:"></asp:Label></td>
            <td style="width:15%"><asp:TextBox runat="server" ID="txtFechaVigenciaFrom" CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>            
            <td rowspan="2" style="width:10%"><asp:Label runat="server" ID="lblFechaPago" Text="FECHA DE PAGO:"></asp:Label></td>
            <td style="width:8%"><asp:Label runat="server" Text="FROM:"></asp:Label></td>
            <td style="width:15%"><asp:TextBox runat="server" ID="txtFechaPagoFrom" CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="TO:"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtFechaFacturacionTo"  CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>
            <td><asp:Label runat="server" Text="TO:"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtFechaVigenciaTo"  CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>
            <td><asp:Label runat="server" Text="TO:"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtFechaPagoTo"  CssClass="divTextboxFecha ui-datepicker"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="Width:10%;"><asp:Label runat="server" ID="Label4" Text="FOLIO:"></asp:Label></td>
            <td style=" Width:8%;"><asp:TextBox runat="server" ID="txtFolio" CssClass="divTextboxFecha"></asp:TextBox></td>
            <td style="Width:15%;"><asp:Label runat="server" ID="Label5" Text="FOLIO FISCAL:"></asp:Label></td>
            <td colspan="2" style="Width:25%;"><asp:TextBox runat="server" ID="txtFolioFiscal" CssClass="divTextboxFecha"></asp:TextBox></td>
            <td style=" Width:8%;"><asp:Label runat="server" ID="lblEstatus" Text="ESTATUS:"></asp:Label></td>
            <td style="Width:15%;"><asp:DropDownList runat="server" ID="ddlEstatusHead" CssClass="divTextboxFecha" ></asp:DropDownList></td>
            <td style="Width:10%;"><asp:Label runat="server" ID="lblTipoProveedor" Text="TIPO PROVEEDOR:"></asp:Label></td>
            <td style=" Width:8%;"><asp:DropDownList runat="server" ID="ddlTipoProveedor" CssClass="divTextboxFecha" ></asp:DropDownList></td>             
        </tr>
        <tr>            
            <td colspan="5"><asp:Button runat="server" ID="btnGuardar" Text="BUSCAR"  CssClass="button button-blue" OnClick="btnGuardar_Click"/></td>
            <td colspan="4" style="padding:10px;"><asp:Button runat="server" ID="btnLimpiar" Text="LIMPIAR" CssClass="button button-blue" OnClick="btnLimpiar_Click" /> </td>
        </tr>
    </table>
</div>
<div class="divContent" >
    <div>
        <table style="width:calc(100% - 17px);">
                <tr style="width:100%;">
                    <td rowspan="2" style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label1" Text="EMPRESA" ></asp:Label></td>
                    <td rowspan="2" style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label2" Text="PROVEEDOR"></asp:Label></td>
                    <td rowspan="2" style="width:7.5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblFolio" Text="FOLIO"></asp:Label></td>
                    <td colspan="2" style="width:13%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label14" Text="FECHA"></asp:Label></td>
                    <td rowspan="2" style="width:7%; padding:0px; border:1px solid white;" ><asp:Label runat="server" ID="lblSubTotal" Text="SUB TOTAL"></asp:Label></td>
                    <td colspan="2" style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label15" Text="RETENCION"></asp:Label></td>
                    <td colspan="2" style="width:10%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label16" Text="TRASLADOS"></asp:Label></td>
                    <td rowspan="2" style="width:7%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblTotal" Text="TOTAL"></asp:Label></td>
                    <td colspan="1" style="width:9%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label3" Text="FECHA"></asp:Label></td>
                    <td rowspan="2" style="width:10.5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label6" Text="ESTATUS"></asp:Label></td>
                    <td rowspan="2" style="width:6%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="Label7" Text="ACTIVO"></asp:Label></td>
                </tr>
                <tr style="width:100%;">
                    <td style="padding:0px; border:1px solid white; width:6.5%;"><asp:Label runat="server" ID="lblFechaFactura" Text="FACTURA"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:6.5%;"><asp:Label runat="server" ID="Label8" Text="VIGENCIA"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:5%;"><asp:Label runat="server" ID="lblRetIVA" Text="IVA"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:5%;"><asp:Label runat="server" ID="lblRetISR" Text="ISR"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:5%;"><asp:Label runat="server" ID="lblTrasIVA" Text="IVA"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:5%;"><asp:Label runat="server" ID="lblTrasIEPS" Text="IEPS"></asp:Label></td>
                    <td style="padding:0px; border:1px solid white; width:9%;"><asp:Label runat="server" ID="Label9" Text="PAGO"></asp:Label></td>
                </tr>                
        </table>    
    </div>
    <div style="overflow-x:hidden; overflow-y:scroll; height:300px;"> 
    <table style="width:100%;">
    <asp:Repeater runat="server" ID="repeaterFacturas" OnItemDataBound="repeaterFacturas_ItemDataBound" >       
        <ItemTemplate>            
                <tr runat="server" id="trItem"  style="width:100%;">
                    <td style=" width:10%; border:1px solid white; padding:0px; "><asp:Label runat="server" ID="lblEmpresa" Text='<% #Eval("Empresa") %>' Width="100%" >  </asp:Label>
                        <asp:Label runat="server" ID="lblIDFactura" Text='<%#Eval("IdFactura") %>' Visible="false" Width="0%"></asp:Label>
                        <asp:Label runat="server" ID="lblTipoProveedor" Text='<% #Eval("TipoProveedor") %>' Visible="false" Width="0%"></asp:Label>
                    </td>
                    <td style="width:10%; padding:0px; border:1px solid white; "><asp:Label runat="server" ID="lblProveedor" Text='<% #Eval("Proveedor") %>' Width="100%"></asp:Label></td>
                    <td style="width:7.5%; max-width:75%; min-width:75%; padding:0px; border:1px solid white; word-wrap:break-word;" ><asp:Label runat="server" ID="lblFolio" Text='<% #Eval("Folio") %>' Width="100%"></asp:Label></td>
                    <td style="width:6.5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblFechaFactura" Text='<%#Eval("Fecha_factura", "{0:d}") %>' Width="100%"></asp:Label></td>
                    <td style="width:6.5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblFechaVigencia" Text='<%#Eval("Fecha_vigencia", "{0:d}") %>' Width="100%"></asp:Label></td>
                    <td style="width:7%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblSubTotal" Text='<%#Eval("SubTotal" , "{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblRetIVA" Text='<%#Eval("RetencionIVA","{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblRetISR" Text='<%#Eval("RetencionISR","{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblTrasIVA" Text='<%#Eval("TrasladosIVA","{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:5%; padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblTrasIEPS" Text='<%#Eval("TrasladosIEPS","{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:7%;padding:0px; border:1px solid white;"><asp:Label runat="server" ID="lblTotal" Text='<%#Eval("Total_Factura", "{0:C}") %>' Width="100%"></asp:Label></td>
                    <td style="width:9%; padding:0px; border:1px solid white;"><asp:TextBox runat="server" ID="txtFechaPago" Text='<%#Eval("Fecha_Pago", "{0:d}") %>' AutoPostBack="true" Width="85%" ></asp:TextBox></td>
                    <td style="width:10.5%; padding:0px; border:1px solid white;">
                        <asp:Label runat="server" ID="lblEstatus" Text='<%#Eval("Estatus") %>' AutoPostBack="true" Visible="false" Width="0%"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlEstatus"  Width="100%"></asp:DropDownList> 
                    </td>
                    <td style="width:6%; padding:0px; border:1px solid white;"><asp:CheckBox runat="server" ID="ckbActivo" Checked='<%#Eval("Activo") %>' Width="100%" /></td>
                </tr>                
        </ItemTemplate>
    </asp:Repeater>
                
        </table>
        </div>
    <div>
        <table>
            <tr>
                <td colspan="7"><asp:Button runat="server" ID="Button1" Text="GUARDAR" CssClass="button button-blue" OnClick="btnGuardar_Click1" /> </td>
                <td colspan="7"><asp:ImageButton runat="server" ID="btbDownloadExcel" OnClick="btbDownloadExcel_Click"  CssClass="buttonExcel"  ImageUrl="~/Images/excel2.png"/> </td>
        </tr>
        </table>
    </div>
</div>
    <script type="text/javascript">
        $("[id*=txtFechaPago]").datepicker(function () {
                 dateFormat: 'dd/mm/yy' 
        });
        $("[id*=ddlEstatus]").change(function (index,i)
        {

            var td = $(this).parent();
            $("span:eq(0)", td).text($(this).val());
            var tr = td.parent();
            if($(this).val()=='PAGADA')
            {
                $("input:eq(0)", tr).attr('disabled', false);
                tr.css('background-color', '#006E2E');
                $("input:eq(0)", tr).css('background-color', '#006E2E');
            }
            else if ($(this).val() == 'CANCELADA') {

                $("input:eq(0)", tr).attr('disabled', true);
                $("input:eq(0)", tr).text(' ');
                tr.css('background-color', '#800000');
                $("input:eq(0)", tr).css('background-color', '#800000');


            } else if ($(this).val() == 'PROXIMAVENCIMIENTO') {

                $("input:eq(0)", tr).attr('disabled', true);
                tr.css('background-color', '#3F4C6B');
                $("input:eq(0)", tr).css('background-color', '#3F4C6B');

            } else if ($(this).val() == 'SUPRIMIDA') {

                $("input:eq(0)", tr).attr('disabled', true);
                tr.css('background-color', '#4B4B4B');
                $("input:eq(0)", tr).css('background-color', '#4B4B4B');

            } else if ($(this).val() == 'VENCIDA') {

                $("input:eq(0)", tr).attr('disabled', true);
                tr.css('background-color', '#C79810');
                $("input:eq(0)", tr).css('background-color', '#C79810');

            } else if ($(this).val() == 'INACTIVA') {

                $("input:eq(0)", tr).attr('disabled', true);
                tr.css('background-color', '#FA6800');
                $("input:eq(0)", tr).css('background-color', '#FA6800');
            }

        });
    </script>