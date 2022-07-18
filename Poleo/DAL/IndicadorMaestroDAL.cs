using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;
namespace Poleo.DAL
{
  
    public class IndicadorMaestroDAL
    {
        public ISqlMapper mapper;
        public IList<IndicadorMaestro> SelectIndicadorMaestro(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<IndicadorMaestro>("SelectIndicadorMaestro", param);
        }

        //Added by Hector Sanchez M. - 20161130
        public IList<IndicadorMaestro> SelectIndicadorMaestroV2(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<IndicadorMaestro>("SelectIndicadorMaestroV2", param);
        }

        //Added by Hector Sanchez
        public IList<IndicadorMaestro> SelectIndicadorMaestroV3(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<IndicadorMaestro>("SelectIndicadorMaestroV3", param);
        }
    }
}