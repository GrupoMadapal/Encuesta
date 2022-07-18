using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;
namespace Poleo.DAL
{

    public class OrdersFreeDAL
    {
        //Ariadna Cadena
        public ISqlMapper mapper;
        public IList<OrderCupons> SelectFreeOrders(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectFreeOrders", param);
        }

        public IList<OrderCupons> SelectOrdenesEditadas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectOrdenesEditadas", param);
        }

        public IList<OrderCupons> SelectOrdenesCanceladas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectOrdenesCanceladas", param);
        }

        
        public IList<OrderCupons> SelectOpenPay(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectOpenPay", param);
        }

        public IList<OrderCupons> SelectPagoUber(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectPagoUber", param);
        }

        public IList<OrderCupons> SelectDetalleOpenPay(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<OrderCupons>("SelectDetalleOpenPay", param);
        }
    }
}