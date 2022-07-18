using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class TiendaDAL
    {
        public ISqlMapper mapper;

        public IList<Tienda> selectTiendaUp()
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Tienda>("selectTiendaUp", null);
        }
        public IList<Tienda> SelectTipoTienda(Tienda param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Tienda>("SelectTipoTienda", param);
        }
        public IList<Tienda> SelectTiendas(Tienda param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Tienda>("SelectTiendas", param);
        }
        public IList<Tienda> SelectDQTiendas(Tienda Param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Tienda>("SELECTDQTIENDAS", Param);
        }

        public Tienda SelectStoreByUserID(int paramid)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Tienda>("SelectStoreByUserID", paramid);
        }
        public IList<Tienda> SelectTiendasOrden(Tienda param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Tienda>("SelectTiendasOrden", param);
        }
    }
}