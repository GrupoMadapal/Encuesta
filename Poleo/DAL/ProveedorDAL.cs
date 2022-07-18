using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ProveedorDAL
    {
        public ISqlMapper mapper;
        public IList<Proveedor> SelectProveedorbyRFC(Proveedor param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Proveedor>("SelectProveedorbyRFC", param);
        }
        public int InsertProveedor(Proveedor param)
        {
            mapper = Mapper.Instance();
            return (int)mapper.Insert("InsertProveedor", param);
        }
        public void UpdateProveedorActive(Proveedor param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateProveedorActive", param);

        }
        public IList<String> AutoCompleteProveedores(Proveedor param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<String>("AutoCompleteProveedores", param);
        }

    }
}