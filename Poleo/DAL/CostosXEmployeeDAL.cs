using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class CostosXEmployeeDAL
    {
       public ISqlMapper mapper;
       public CostosXEmployee SelectCostXEm1st (OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForObject<CostosXEmployee>("SelectCostXEm1st", param);
       }

       public CostosXEmployee SelectCostXEm2nd(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForObject<CostosXEmployee>("SelectCostXEm2nd", param);
       }

       public CostosXEmployee SelectCostXEm3rd(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForObject<CostosXEmployee>("SelectCostXEm3rd", param);
       }
        
       public CostosXEmployee SelectCostXStore(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForObject<CostosXEmployee>("SelectCostXStore", param);
       }

       public IList<CostosXEmployee> SelectEmployeesXStore(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectEmployeesXStore", param);
       }

       public IList<CostosXEmployee> SelectEmployeesXStore2(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectEmployeesXStore2", param);
       }

       public CostosXEmployee SelectCostXEmBD(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForObject<CostosXEmployee>("SelectCostXEmBD", param);
       }

        public IList<CostosXEmployee> SelectLISTCostXEmBD(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectCostXEmBD", param);
       }

       public IList<CostosXEmployee> SelectLISTCostXEm1st(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectCostXEm1st", param);
       }

       public IList<CostosXEmployee> SelectLISTCostXEm2nd(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectCostXEm2nd", param);
       }

       public IList<CostosXEmployee> SelectLISTCostXEm3rd(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectCostXEm3rd", param);
       }

       public IList<CostosXEmployee> SelectDeliveryOrdersXEmToday(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectDeliveryOrdersXEmToday", param);
       }

       public IList<CostosXEmployee> SelectDeliveryOrdersXEmBD(OrdenesFinder param)
       {
           mapper = Mapper.Instance();
           return mapper.QueryForList<CostosXEmployee>("SelectDeliveryOrdersXEmBD", param);
       }


    }
}