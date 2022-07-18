using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.DataMapper;

namespace Poleo.DAL
{
    public class RolesDAL
    {
        public ISqlMapper mapper;

        public IList<Roles> SelectRol()
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Roles>("SelectRol", new Roles());
        }
    }
}