using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class VentaDAL
    {
        public ISqlMapper mapper;
        public IList<Ventas> SelectVentas (VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectVentas", param);
        }
        public IList<TotalSales> TotalSalesbyStore(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<TotalSales>("TotalSalesbyStore", param);
        }
        public IList<TotalSales> SelectTotalGratis(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<TotalSales>("SelectTotalGratis", param);
        }
        public IList<ResumenVentas> SelectResumenVentas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ResumenVentas>("SelectResumenVentas", param);
        }
        public IList<ResumenVentas> SelectResumenVentas2(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<ResumenVentas>("SelectResumenVentas2", param);
        }

        public IList<Ventas> SelectVentasGratis(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectVentasGratis", param);
        }
        public IList<Ventas> SelectVentasGratisTotal(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectVentasGratisTotal", param);
        }
        //add 20151009
        public IList<Ventas> SelectMasterSales(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectMasterSales", param);
        }
        public IList<TotalSales> ventasAcumuladas(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<TotalSales>("ventasAcumuladas", param);
        }

        public IList<SalesLastYear> SelectSalesLastYearFirst(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<SalesLastYear>("SelectSalesLastYearFirst", param);
        }

        public IList<SalesLastYear> SelectSalesLastYearSecond(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<SalesLastYear>("SelectSalesLastYearSecond", param);
        }
        public IList<SalesLastYear> SelectSalesLastWeek(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<SalesLastYear>("SelectSalesLastWeek", param);
        }
        public IList<DepositoYTransacciones> SelectDepositosYTransacciones(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<DepositoYTransacciones>("SelectDepositosYTransacciones", param);
        }
     
        //Added by Hector Sanchez M. 20160712
        public Ventas SelectOrderInternet(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Ventas>("SelectOrderInternet", param);
        }

        public decimal SelectSalesLastYearOnLine(InfoTiempoReal param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<decimal>("SelectSalesLastYearOnLine", param);
        }

        //Added by Leo 
        
        public IList<Ventas> SelectCounts(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectCounts", param);
        }

        //Added by Leo Mtz 20191209
        public IList<DailyInventoryExtracts> SelectUseInventory(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<DailyInventoryExtracts>("SelectUseInventory", param);
        }

        public IList<Ventas> SelectLinealSales(VentasFinder param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<Ventas>("SelectLinealSales", param);
        }

       


    }
}