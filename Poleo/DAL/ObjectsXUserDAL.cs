using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ObjectsXUserDAL
    {
        public ISqlMapper mapper;

        public ObjectsXUser SelectObjectXUser(ObjectsXUser Param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<ObjectsXUser>("SelectObjectXUser", Param);
        }

        public IList<ObjectsXUser> SelectLstObjectsXUser(int IdUser)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ObjectsXUser>("SelectLstObjectsXUser", IdUser);
        }

        public IList<int> SelectObjectsByUser(int IdUser)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<int>("SelectObjectsByUser", IdUser);
        }
    }
}