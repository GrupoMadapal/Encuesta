using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class EmpresaDAL
    {
        public ISqlMapper mapper;
        public IList<Empresa> SelectEmpresabyRFC(Empresa param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Empresa>("SelectEmpresabyRFC", param);
        }
        public int InsertEmpresa(Empresa param)
        {
            mapper = Mapper.Instance();
            return (int)mapper.Insert("insertEmpresa", param);
        }
        public IList<String> AutoCompleteEmpresa(Empresa param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<String>("AutoCompleteEmpresa", param);
        }
    }
}