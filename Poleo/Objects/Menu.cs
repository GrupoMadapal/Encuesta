using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Menu
    {
        private int id_menu_option;
        private string description;
        private int? id_parent_menu_option;
        private string url;
        private string urlimage;
        private int? rol;

        public int Id_menu_option
        {
            get { return id_menu_option; }
            set { id_menu_option = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int? Id_parent_menu_option
        {
            get { return id_parent_menu_option; }
            set { id_parent_menu_option = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string UrlImage
        {
            get { return urlimage; }
            set { urlimage = value; }
        }

        public int? Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }
}