using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class ProveedorBLL
    {
        public IList<Proveedor> SelectEmpresabyRFC(Proveedor param)
        {
            ProveedorDAL objProveedorBLL = new ProveedorDAL();
            return objProveedorBLL.SelectProveedorbyRFC(param);
        }
        public int InsertEmpresa(Proveedor param)
        {
            ProveedorDAL objProveedorBLL = new ProveedorDAL();
            return objProveedorBLL.InsertProveedor(param);
        }
        public void UpdateProveedorActive(Proveedor param)
        {
            ProveedorDAL objProveedorDAL = new ProveedorDAL();
            objProveedorDAL.UpdateProveedorActive(param);
        }
        public IList<String> AutoCompleteProveedores(Proveedor param)
        {
            ProveedorDAL objProveedorDAL = new ProveedorDAL();
            return objProveedorDAL.AutoCompleteProveedores(param);
        }
    }
}