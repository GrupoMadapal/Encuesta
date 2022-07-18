using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Objects;
using IBatisNet.DataMapper;

namespace Poleo.DAL
{
    public class UserXRolDAL
    {
        private ISqlMapper mapper;

        public IList<UserXRol> SelectUserXRol(int IdUser)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<UserXRol>("SelectUserXRol", IdUser);
        }
    }
}