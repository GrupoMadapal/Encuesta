using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class MenuDAL
    {
        public ISqlMapper mapper;

        public IList<Menu> SelectListMenu()
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Menu>("SelectListMenu", new Menu());
        }
    }
}