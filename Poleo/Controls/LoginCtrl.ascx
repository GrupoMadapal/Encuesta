<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginCtrl.ascx.cs" Inherits="Poleo.Controls.LoginCtrl" %>

<link href="../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
    $(document).ready(function () {
        $('.forgot-pass').click(function (event) {
            $(".pr-wrap").toggleClass("show-pass-reset");
        });

        $('.pass-reset-submit').click(function (event) {
            $(".pr-wrap").removeClass("show-pass-reset");
        });
    });
    </script>
    <style>
        body
        {
            background: url('../Content/Fondo11360.jpg') fixed;
            background-size: cover;
            padding: 0;
            margin: 0;
            /*font-family:"Helvetica Neue";*/
        }

        .wrap
        {
            width: 100%;
            height: 100%;
            min-height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 99;
        }

        p.form-title
        {
            font-family: 'Open Sans' , sans-serif;
            font-size: 20px;
            font-weight: 600;
            text-align: center;
            color: #FFFFFF;
            margin-top: 5%;
            text-transform: uppercase;
            letter-spacing: 4px;
        }

        form
        {
            width: 250px;
            margin: 0 auto;
        }

        form.login input[type="text"], form.login input[type="password"]
        {
            width: 100% !important;
            margin: 0 !important;
            padding: 5px 10px !important;
            background: 0 !important;
            border: 0 !important;
            border-bottom: 1px solid #FFFFFF !important;
            outline: 0 !important;
            font-style: italic !important;
            font-size: 12px !important;
            font-weight: 400 !important;
            letter-spacing: 1px !important;
            margin-bottom: 5px !important;
            color: #FFFFFF !important;
            outline: 0 !important;
        }

        form.login input[type="submit"]
        {
            width: 100%;
            font-size: 14px;
            text-transform: uppercase;
            font-weight: 500;
            margin-top: 16px;
            outline: 0;
            cursor: pointer;
            letter-spacing: 1px;
        }

        form.login input[type="submit"]:hover
        {
            transition: background-color 0.5s ease;
        }

        form.login .remember-forgot
        {
            float: left;
            width: 100%;
            margin: 10px 0 0 0;
        }
        form.login .forgot-pass-content
        {
            min-height: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        form.login label, form.login a
        {
            font-size: 12px;
            font-weight: 400;
            color: #FFFFFF;
        }

        form.login a
        {
            transition: color 0.5s ease;
        }

        form.login a:hover
        {
            color: #2ecc71;
        }

        .pr-wrap
        {
            width: 100%;
            height: 100%;
            min-height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 999;
            display: none;
        }

        .show-pass-reset
        {
            display: block !important;
        }

        .pass-reset
        {
            margin: 0 auto;
            width: 250px;
            position: relative;
            margin-top: 22%;
            z-index: 999;
            background: #FFFFFF;
            padding: 20px 15px;
        }

        .pass-reset label
        {
            font-size: 12px;
            font-weight: 400;
            margin-bottom: 15px;
        }

        .pass-reset input[type="email"]
        {
            width: 100%;
            margin: 5px 0 0 0;
            padding: 5px 10px;
            background: 0;
            border: 0;
            border-bottom: 1px solid #000000;
            outline: 0;
            font-style: italic;
            font-size: 12px;
            font-weight: 400;
            letter-spacing: 1px;
            margin-bottom: 5px;
            color: #000000;
            outline: 0;
        }

        .pass-reset input[type="submit"]
        {
            width: 100%;
            border: 0;
            font-size: 14px;
            text-transform: uppercase;
            font-weight: 500;
            margin-top: 10px;
            outline: 0;
            cursor: pointer;
            letter-spacing: 1px;
        }

        .pass-reset input[type="submit"]:hover
        {
            transition: background-color 0.5s ease;
        }
        .posted-by
        {
            position: absolute;
            bottom: 26px;
            margin: 0 auto;
            color: #FFF;
            background-color: rgba(0, 0, 0, 0.66);
            padding: 10px;
            left: 45%;
        }
    </style>
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="pr-wrap">
                    <div class="pass-reset">
                        <label>
                            Enter the email you signed up with</label>
                        <input type="email" placeholder="Email" />
                        <input type="submit" value="Submit" class="pass-reset-submit btn btn-success btn-sm" />
                    </div>
                </div>
                <div class="wrap">
                    <p class="form-title">
                        Sign In</p>
                    <form class="login" runat="server">
                    <input type="text" placeholder="Username" id="txtUserName" runat="server" />
                    <input type="password" placeholder="Password" id="txtUserPass" runat="server" />
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-sm" OnClick="cmdLogin_Click" Text="Sign In" />
                        <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="50" runat="server" />
                    <div class="remember-forgot">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkPersistCookie" runat="server" />
                                        Remember Me
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-6 forgot-pass-content">
                                <a href="javascription:void(0)" class="forgot-pass">Forgot Password</a>
                            </div>
                        </div>
                        
                    </div>
                    </form>

                    
                </div>
            </div>
        </div>
    </div>
<%--OLD CODE Modified by Hector Sanchez M. 20170307 - Cambio de diseño--%>
<%--<style type="text/css">
.auto-style1 
{
    width: 18px;
}
.auto-style2 
{
    width: 48px;
}
#contenedor 
{
  width: 90%;
  height: 300px; 
  position: absolute;
  top: 50%;
  left: 5%;
  margin-top: -200px;  
  align-content:center;
  border-radius:15px;
  border-color:dimgray;
  border-style:solid;
  text-align:center;
}
</style>
<div  id="contenedor" style="background-color:rgba(0, 110, 153, 0.79)">
    <h3>            
        AUTENTICACION DE USUARIOS
    </h3>
    <table style="position: absolute; left:15%" >
        <tr>
            <td class="auto-style1"> 
                <asp:Image runat="server" ImageUrl="~/Images/usuario.jpg" Width="30px" Height="30px"  />  
            </td>
            <td class="auto-style2"> 
                <label for="login">Email:</label>
            </td>
            <td>
                <input id="txtUserName" type="text" runat="server" value="name@madapal.com">
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ControlToValidate="txtUserName" Display="Static" ErrorMessage="*" runat="server" ID="vUserName" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"> 
                <asp:Image ImageUrl="~/Images/password.jpg" Width="30px" Height="30px" runat="server" />
            </td> 
            <td class="auto-style2"> 
                <label for="password">Password:</label>
            </td>
            <td>
                <input id="txtUserPass" type="password" runat="server" value="4815162342">
            </td>
            <td> 
                <%--<asp:RequiredFieldValidator ControlToValidate="txtUserPass" Display="Static" ErrorMessage="*" runat="server" ID="vUserPass" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style2">Remember me</td>
            <td>
                <asp:CheckBox id="chkPersistCookie" runat="server" autopostback="false" />

            </td>
            <td></td>
       
        </tr>
        <tr>
            <td colspan="4"  >  
                <asp:Button  runat="server" ID="cmdLogin2" OnClick="cmdLogin_Click" Text="  ENTRAR  " BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Double" />
            </td>
        </tr>
        <tr>
            <td colspan="4"><asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" /></td>
        </tr>
    </table>
</div>--%>
