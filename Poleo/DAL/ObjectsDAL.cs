using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ObjectsDAL
    {
        public ISqlMapper mapper;

        public IList<Objects.Objects> SelectLstObjectsParents()
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Objects.Objects>("SelectLstObjectsParents", new Objects.Objects());
        }

        public IList<Objects.Objects> SelectLstObjectsByParents(int IdParent)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Objects.Objects>("SelectLstObjectsByParents", IdParent);
        }
    }
}