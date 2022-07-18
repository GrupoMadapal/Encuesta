using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Poleo.Objects;
using Poleo.BLL;

namespace Poleo.WebServices
{
    /// <summary>
    /// Descripción breve de AutoCompleteFacturas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class AutoCompleteFacturas : System.Web.Services.WebService
    {

        [WebMethod(false)]
        public string HelloWorld(string TextProveedores )
        {
            return "Hola a todos"+TextProveedores;
        }
        [WebMethod]
        public string GetAutoCompleteProveedores(string TextProveedores)
        {
            ProveedorBLL objProveedorBLL = new ProveedorBLL();
            Proveedor finderProveedor = new Proveedor()
            {
                Nombre=TextProveedores+"%"
            };
            IList<String> lstResultProveedores=objProveedorBLL.AutoCompleteProveedores(finderProveedor);
            String strResult=String.Empty;
            foreach(String item in lstResultProveedores)
            {
                strResult+=item+":";
            }
            return strResult;
        }
        [WebMethod]
        public string GetAutoCompleteEmpresa(string TextEmpresa)
        {
            EmpresaBLL objEmpresaBLL = new EmpresaBLL();
            String strResult = String.Empty;
            Empresa finderEmpresa = new Empresa()
            {
                Nombre = TextEmpresa + "%"
            };
            IList<String> lstEmpresas = objEmpresaBLL.AutoCompleteEmpresa(finderEmpresa);
            foreach(String item in lstEmpresas)
            {
                strResult += item + ":";
            }
            return strResult;
        }
    }
}
