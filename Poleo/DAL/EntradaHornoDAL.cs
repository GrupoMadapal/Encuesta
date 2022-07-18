using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class EntradaHornoDAL
    {
        public ISqlMapper mapper;

        public IList<EntradaHorno> SelectEntradaHorno(VentasFinder objFinder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<EntradaHorno>("SelectEntradaHorno", objFinder);
        }
    }
}