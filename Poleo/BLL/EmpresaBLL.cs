using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;

namespace Poleo.BLL
{
    public class EmpresaBLL
    {
        public IList<Empresa> SelectEmpresabyRFC(Empresa param)
        {
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();
            return objEmpresaDAL.SelectEmpresabyRFC(param);
        }
        public int InsertEmpresa(Empresa param)
        {
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();
            return objEmpresaDAL.InsertEmpresa(param);
        }
        public IList<String> AutoCompleteEmpresa(Empresa param)
        {
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();
            return objEmpresaDAL.AutoCompleteEmpresa(param);
        }
    }
}