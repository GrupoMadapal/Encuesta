<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pag_CuponesDP.aspx.cs" Inherits="Poleo.Pages.Pag_CuponesDP" %>

<%@ Register Src="~/Controls/FilterIndicators.ascx" TagPrefix="MDP" TagName="Filter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DP" />
</asp:Content>--%>
<asp:Content ID="ContentFtl" runat="server" ContentPlaceHolderID="TitleContent">
    <MDP:Filter ID="ctrFilter" runat="server" TypeFilter="DP" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .divScroll {
            /*overflow:scroll;*/
            height:500px;
            /*width:830px;*/
            overflow-x:hidden;
            overflow-y:scroll;
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
    <%--<script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            //agregar una nueva columna con todo el texto 
            //contenido en las columnas de la grilla 
            //contains de Jquery es CaseSentive, por eso a minúscula
            $(".filtrar tr:has(td)").each(function () {
                var t = $(this).text().toLowerCase();
                $("<td class='indexColumn'></td>")
                .hide().text(t).appendTo(this);
            });
            //Agregar el comportamiento al texto (se selecciona por el ID) 
            $("#txtSerach").keyup(function () {
                var s = $(this).val().toLowerCase().split(" ");
                $(".filtrar tr:hidden").show();
                $.each(s, function () {
                    $(".filtrar tr:visible .indexColumn:not(:contains('"
                    + this + "'))").parent().hide();
                });
            });
        });
     </script>--%>
    <table style="width:100%">
        <tr>
            <td>
                <asp:Label ID="lblActive" runat="server">Activo :</asp:Label>
                <asp:CheckBox ID="chkActive" runat="server" Checked="true" OnCheckedChanged="chkActive_CheckedChanged" AutoPostBack="true" />
            </td>
            <%--<td>
                <asp:Label ID="lblSearch" runat="server">Buscar :</asp:Label>
                <asp:TextBox ID="txtSerach" runat="server" Width="150px"></asp:TextBox>
            </td>--%>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
            </td>
            <td>
                <%--<asp:FileUpload ID="fulFile" runat="server" BorderStyle="None" />--%>
                <asp:Button ID="btnLoadFile" runat="server" Text="Cargar Archivo" OnClick="btnLoadFile_Click" />
            </td>
        </tr>
    </table>
    <br />
    <table style="width:100%;" class="BackGroundStyleContent">
        <tr>
            <td>
                <div class="divScroll">
                    <asp:CheckBoxList ID="cblCupones" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" class="filtrar"></asp:CheckBoxList>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="padding-top:15px; padding-left:15px;">
                <table>
                    <tr>
                        <td class="elementes"> <asp:ImageButton runat="server" ID="btnimgCupon" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="btnCupon_Click"/></td>
                        <td><asp:Button runat="server" ID="btnCupon" Text="CUPONES"  CssClass="elementes btnExcelText " Width="100px" Height="35px" OnClick="btnCupon_Click"/></td>
                    </tr>
                </table> 
            </td>
            <td style="padding-top:15px; padding-left:15px;">
                <table>
                    <tr>
                        <td class="elementes"><asp:ImageButton runat="server" ID="ibtPorcCoupon" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="btnPorcCoupon_Click"/></td>
                        <td><asp:Button ID="btnPorcCoupon" runat="server" Text="% Cupones" Height="35px" CssClass="elementes btnExcelText" Width="100px" OnClick="btnPorcCoupon_Click"/></td>
                    </tr>
                </table>
            </td>
         <%--   <td style="padding-top:15px; padding-left:15px;">
                <table>
                    <tr>
                        <td class="elementes"> <asp:ImageButton runat="server" ID="ibtnIncentivoCoupon" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="btnIncentivoCoupon_Click" /></td>
                        <td><asp:Button ID="btnIncentivoCoupon" runat="server" Text="Cupon Incentivos" CssClass="elementes btnExcelText" Width="120px" Height="35px" OnClick="btnIncentivoCoupon_Click" /> </td>
                    </tr>
                </table>
            </td>--%>
             <td style="padding-top:15px; padding-left:15px;">
                <table>
                    <tr>
                        <td class="elementes"> <asp:ImageButton runat="server" ID="ibtnIncentivoCouponSLP" ImageUrl="~/Images/Excel-Grey.ico" Width="25px" Height="22px" OnClick="btnIncentivoCouponSLP_Click" /></td>
                        <td><asp:Button ID="btnIncentivoCouponSLP" runat="server" Text="Cupon Incentivos SLP/TAM" CssClass="elementes btnExcelText" Width="150px" Height="35px" OnClick="btnIncentivoCouponSLP_Click" /> </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label runat="server" ID="lblMesajeError" Visible="false"  CssClass=" messageError"></asp:Label>
</asp:Content>
