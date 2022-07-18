<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadXMLFactura.ascx.cs" Inherits="Poleo.Controls.LoadXMLFactura" %>
<script src="../Scripts/jquery-2.1.4.js"></script>
<script src="../Scripts/jquery-ui-1.11.4.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        
        $("[id$=divLoading]").hide();
    });
    

    function ShowCurrentTime() {
        var param = { param: "param" };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/WebServices/LoadXMLFacturas.asmx/UpLoadXML",
            data: JSON.stringify(param),
            dataType: "json",
            beforeSend: function (data)
            {
                
                $("[id$=divLoading]").show();
                
            },
            success: function (data) {
                console.log(data);

            
                $("[id$=divLoading]").hide();
                $('[id$=output]').empty();
                var d = data.d.split('/');
                console.log(d);
                $.each(d, function (index,string) {
                    $('[id$=output]').append('<p>' + string + '</p><br /> ');
                    console.log(string);
                });
            },
            error: function (result) {
                console.log(result);
                
                $("[id$=divLoading]").hide();
            }
        });
        return false;
    }
</script>

<style type="text/css">
    .btnloading{
     background-color:whitesmoke;
     border-radius:40px;
     width:150px;
     height:150px;
    }
    .lblloadingText{
        color:black;
        font-size:20px;
        text-align:center;
        background-color:white;
        

    }
    .divLoading{
        float:inherit;
        background-color:white;
        display:block;  
    height:150px; 
    position:absolute; 
    top:50%; 
    left:50%; 
    margin:0 auto;
     border-radius:40px;
     padding: 20px;
    }
    .btn{
        padding:50px;
        border-radius:25px;
        background-color:#1e1919;
    }
</style>
<div style="text-align:center;">
    <div style="text-align:center; ">
        <asp:Button ID="btnLoadXmlInvoice" runat="server" Text="CARGAR FACTURAS XML"  OnClientClick="ShowCurrentTime(); return false;" CssClass="btn" />
        
    </div>
    <div class="divLoading" runat="server" id="divLoading">
        <asp:Image ID="btnloading" runat="server" ImageUrl="~/Images/loading_logofinal_by_zegerdon-d60eb1v.gif"  CssClass="btnloading" />
        <asp:Label runat="server" ID="lblTextLoading" Text="CARGANDO XML ......" CssClass="lblloadingText"></asp:Label>
    </div>
    <div runat="server" id="output" style="color:white; background-color:#121478; width:60%;height:auto; min-height:15px; text-align:center; left:25%; margin:0 auto; border-radius:50px;"></div>
</div>

