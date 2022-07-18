using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using Poleo.Objects;
using Poleo.BLL;

namespace Poleo
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //private bool ValidateUser(string userName, string passWord)
        //{
        //    //SqlConnection conn;
        //    //SqlCommand cmd;
        //    LoginBLL objLoginBLL = new LoginBLL();
        //    string lookupPassword = null;

        //    // Buscar nombre de usuario no válido.
        //    // el nombre de usuario no debe ser un valor nulo y debe tener entre 1 y 15 caracteres.
        //    if ((null == userName) || (0 == userName.Length) || (userName.Length > 50))
        //    {
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
        //        return false;
        //    }

        //    // Buscar contraseña no válida.
        //    // La contraseña no debe ser un valor nulo y debe tener entre 1 y 25 caracteres.
        //    if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
        //    {
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
        //        return false;
        //    }

        //    try
        //    {
                
        //        // Consultar con el administrador de SQL Server para obtener una conexión apropiada
        //        // cadena que se utiliza para conectarse a su SQL Server local.
        //        //conn = new SqlConnection("data source= MADAPAL-PC\\SQLEXPRESS ; Initial Catalog=Madapal;Integrated Security=True");
        //        //conn.Open();

        //        //// Crear SqlCommand para seleccionar un campo de contraseña desde la tabla de usuarios dado el nombre de usuario proporcionado.
        //        //cmd = new SqlCommand("SELECT Password   FROM Login    where Email=@userName", conn);
        //        //cmd.Parameters.Add("@userName", System.Data.SqlDbType.VarChar, 50);
        //        //cmd.Parameters["@userName"].Value = userName;

        //        //// Ejecutar el comando y capturar el campo de contraseña en la cadena lookupPassword.
        //        //lookupPassword = (string)cmd.ExecuteScalar();

        //        //// Comando de limpieza y objetos de conexión.
        //        //cmd.Dispose();
        //        //conn.Dispose();
        //        Poleo.Objects.Login objfinderLogin = new Objects.Login()
        //        {
        //            Email=userName
        //        };

        //        Poleo.Objects.Login objResultLogin = objLoginBLL.GetPasswordByEmail(objfinderLogin);
        //        if(objResultLogin!=null)
        //        {
        //            lookupPassword = objResultLogin.Password;

        //        }
        //        else
        //        {
        //            ctrlLogin.lblMsg.Text = "El usuario " + userName + " no existe";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // Agregar aquí un control de errores para la depuración.
        //        // Este mensaje de error no debería reenviarse al que realiza la llamada.
        //        System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
        //    }

        //    // Si no se encuentra la contraseña, devuelve false.
        //    if (null == lookupPassword)
        //    {
        //        // Para más seguridad, puede escribir aquí los intentos de inicio de sesión con error para el registro de eventos.
        //        return false;
        //    }

        //    // Comparar lookupPassword e introduzca passWord, usando una comparación que distinga mayúsculas y minúsculas.
        //    return (0 == string.Compare(lookupPassword, passWord, false));

        //}

        //protected void cmdLogin_Click(object sender, EventArgs e)
        //{
        //    if (ValidateUser(txtUserName.Value, txtUserPass.Value))
        //        FormsAuthentication.RedirectFromLoginPage(ctrlLogin.txtUserName.Value+"chacha",
        //            ctrlLogin.chkPersistCookie.Checked);
        //    else
        //        Response.Redirect("logon.aspx", true);
        //}
    }
}