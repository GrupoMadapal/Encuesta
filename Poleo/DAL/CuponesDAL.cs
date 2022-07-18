using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class CuponesDAL
    {
        public ISqlMapper mapper;

        public IList<Cupones> SelectCuponsByDDL(Cupones Param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Cupones>("SelectCuponsByDDL", Param);
        }

        public IList<Cupones> SelectOrderCupontPorcentage(VentasFinder finder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Cupones>("SelectOrderCupontPorcentage", finder);
        }

        public Cupones SelectObjCupones(string Code)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Cupones>("SelectObjCupones", Code);
        }

        public IList<Cupones> SelectListCupones(Cupones Finder)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Cupones>("SelectListCupones", Finder);
        }

        public void InserObjCupon(Cupones Param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InserObjCupon", Param);
        }

        public void UpdateObjCupon(Cupones Param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateObjCupon", Param);
        }

        public void UpdateActiveCupon(Cupones Param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpdateActiveCupon", Param);
        }

        public IList<OrderCupons> SelectIncentiveCoupons(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectIncentiveCoupons", param);
        }

        public IList<OrderCupons> SelectIncentiveCouponsSLP(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectIncentiveCouponsSLP", param);
        }
    }
}