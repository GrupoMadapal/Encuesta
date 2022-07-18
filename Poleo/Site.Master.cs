using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Poleo.Objects;
using Poleo.BLL;

namespace Poleo
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuControl();
            }
        }

        //Added by Hector Sanchez M. 20161006
        protected void BindMenuControl()
        {
            if (Session["_IdUser"] != null)
            {
                IList<Objects.Menu> lstMenu = new List<Objects.Menu>();
                IList<int> lstObjects = new List<int>();
                ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();
                MenuBLL objMenuBLL = new MenuBLL();
                int? IdUser = (int)Session["_IdUser"];

                lstMenu = objMenuBLL.SelectListMenu();
                lstObjects = objObjectsXUserBLL.SelectObjectsByUser(IdUser.Value);

                foreach (Objects.Menu objMenu in lstMenu)
                {
                    if (objMenu.Id_parent_menu_option == null)
                    {
                        if (objMenu.Rol == null || lstObjects.Contains(objMenu.Rol.Value))//Validacion de permisos
                        {
                            MenuItem objMenuItem = new MenuItem(objMenu.Description, objMenu.Id_menu_option.ToString(), objMenu.UrlImage, objMenu.Url);

                            ctrmenu.Items.Add(objMenuItem);

                            AddChildItem(ref objMenuItem, lstMenu, lstObjects);
                        }
                    }
                }
            }
        }

        //Added by Hector Sanchez M. 20161213
        protected void AddChildItem(ref MenuItem objMenuItem, IList<Objects.Menu> lstMenu, IList<int> lstObjects)
        {
            foreach (Objects.Menu objMenu in lstMenu)
            {
                if (objMenu.Id_parent_menu_option.ToString() == objMenuItem.Value && objMenu.Id_menu_option != objMenu.Id_parent_menu_option)
                {
                    if (objMenu.Rol == null || lstObjects.Contains(objMenu.Rol.Value))
                    {
                        MenuItem childMenuItem = new MenuItem(objMenu.Description, objMenu.Id_menu_option.ToString(), string.Empty, objMenu.Url);

                        objMenuItem.ChildItems.Add(childMenuItem);

                        AddChildItem(ref childMenuItem, lstMenu, lstObjects);
                    }
                }
            }
        }
    }
}