using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class ComplementosDAL
    {
        public ISqlMapper mapper;
        DomSqlMapBuilder Builder = new DomSqlMapBuilder();
        public IList<Complementos> Selectcomplementos(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Complementos>("Selectcomplementos", param);
        }
    }
}
