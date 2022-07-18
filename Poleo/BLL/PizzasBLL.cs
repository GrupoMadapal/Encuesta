using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Poleo.DAL;
using Poleo.Objects;
using System.Globalization;

namespace Poleo.BLL
{
    public class PizzasBLL
    {
        public DataTable SelectPizzas(VentasFinder param)
        {
            PizzasDAL DAL = new PizzasDAL();
            DataTable DT= new DataTable();
            CultureInfo ci = new CultureInfo("Es-Es");
           
            IList<Pizzas> lstPizzas= DAL.SelectPizzas(param);

                DT.Columns.Add("Tienda");                
                DT.Columns.Add("Producto");
                DT.Columns.Add("Cantidad");              
                int count = 0;
                String Tienda = lstPizzas[0].Tienda;
                foreach (Pizzas item in lstPizzas)
                {
                    if (Tienda == item.Tienda)
                    {
                        count += item.Cantidad;
                    }
                    else
                    {
                        DataRow newRowTotal = DT.NewRow();
                        newRowTotal["Tienda"] = String.Empty;
                        newRowTotal["Producto"] = "Total: ";
                        newRowTotal["Cantidad"] = count;
                        DT.Rows.Add(newRowTotal);
                        count = 0;
                        Tienda = item.Tienda;

                    }
                    DataRow newRow = DT.NewRow();
                    newRow["Tienda"] = item.Tienda;
                    newRow["Producto"] = "Pizza  " +item.Size+" "+item.Code ;
                    newRow["Cantidad"] = item.Cantidad;                    
                    DT.Rows.Add(newRow);                  
                }
                DataRow newRowTotalEnd = DT.NewRow();
                newRowTotalEnd["Tienda"] = String.Empty;
                newRowTotalEnd["Producto"] = "Total: ";
                newRowTotalEnd["Cantidad"] = count;
                DT.Rows.Add(newRowTotalEnd);               
            return DT;
        }
        public IList<Pizzas>  SelectPizzasbyShop(VentasFinder param)
        {
                PizzasDAL DAL = new PizzasDAL();
                return DAL.SelectPizzas(param);
        }
        public IList<Pizzas> SelectPizzasMaestro(VentasFinder param)
        {
            PizzasDAL DAL = new PizzasDAL();
            return DAL.SelectPizzasMaestro(param);
        }
        public IList<Pizzas> SelectComplementos(VentasFinder param)
        {
            PizzasDAL DAL = new PizzasDAL();
            return DAL.SelectComplementos(param);
        }

        public IList<Pizzas> SelectCupones(VentasFinder param)
        {
            PizzasDAL DAL = new PizzasDAL();
            return DAL.SelectCupones(param);
        }
        public IList<Pizzas> SelectCupones2(VentasFinder param)
        {
            PizzasDAL DAL = new PizzasDAL();
            return DAL.SelectCupones2(param);
        }
    }
}