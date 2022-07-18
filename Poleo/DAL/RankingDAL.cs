using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class RankingDAL
    {
        public ISqlMapper mapper;
        public IList<Ranking> SelectDataRanking(RankingFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ranking>("SelectDataRanking", param);
        }
        public IList<Ranking> SelectDataRankingPorTienda(RankingFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ranking>("SelectDataRankingPorTienda", param);
        }
    }
}