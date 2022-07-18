using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using Poleo.Objects;
using Poleo.BLL;

namespace Poleo.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Objects.Login objNewLogin = new Objects.Login
            {
                Name = RegisterUserWizardStep.Name,
                UserName = RegisterUser.UserName,
                Password = RegisterUser.Password,
                Email = RegisterUser.Email
            };
            LoginBLL objLoginBLL = new LoginBLL();

            if( objLoginBLL.ExistUser(objNewLogin)==0)
            {
                    objLoginBLL.InsertNewLogin(objNewLogin);
            }
            else
            {
                 
            }         
        }
    }
}