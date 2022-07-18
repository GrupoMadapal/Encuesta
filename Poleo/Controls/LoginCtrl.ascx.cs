using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.Objects;
using Poleo.BLL;
using System.Web.Security;

namespace Poleo.Controls
{
    public partial class LoginCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private bool ValidateUser(string userName, string passWord)
        {
            
            LoginBLL objLoginBLL = new LoginBLL();
            string lookupPassword = null;

           
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 50))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {

                Poleo.Objects.Login objfinderLogin = new Objects.Login()
                {
                    UserName = userName
                };

                Poleo.Objects.Login objResultLogin = objLoginBLL.SelectUser(objfinderLogin);//objLoginBLL.GetPasswordByEmail(objfinderLogin);
                if (objResultLogin != null)
                {
                    lookupPassword = objResultLogin.Password;
                    Session["_IdUser"] = objResultLogin.IdUser;
                }
                else
                {
                    lblMsg.Text = "El usuario " + userName + " no existe";
                }
            }
            catch (Exception ex)
            {
                // Agregar aquí un control de errores para la depuración.
                // Este mensaje de error no debería reenviarse al que realiza la llamada.
                //System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                lblMsg.Text = ex.Message + "-" + ex.InnerException;
            }

            // Si no se encuentra la contraseña, devuelve false.
            if (null == lookupPassword)
            {
                // Para más seguridad, puede escribir aquí los intentos de inicio de sesión con error para el registro de eventos.
                return false;
            }

            // Comparar lookupPassword e introduzca passWord, usando una comparación que distinga mayúsculas y minúsculas.
            return (0 == string.Compare(lookupPassword, passWord, false));

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUser(txtUserName.Value, txtUserPass.Value))
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value,
                    chkPersistCookie.Checked);
            else
                Response.Redirect("Logon.aspx", true);
        }
    }
}