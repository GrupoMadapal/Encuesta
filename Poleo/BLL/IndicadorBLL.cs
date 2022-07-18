using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection; 
using System.IO;
using System.Globalization;

using Poleo.Tools;

namespace Poleo.BLL
{
    public class IndicadorBLL
    {

        public String generateFormatIndicador(VentasFinder objVentasFinder, HttpServerUtility Server)
        {
            Excel.Application xlApp = new Excel.Application();

            //BLL's
            VentasBLL objVentasBLL = new VentasBLL();
            PizzasBLL objPizzasBLL = new PizzasBLL();
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            ResumenDiarioBLL objResumenDiarioBLL = new ResumenDiarioBLL();
            InformacionOperativaBLL objInformacionOperativaBLL = new InformacionOperativaBLL();

            IList<TotalSales> lstResultVentas = objVentasBLL.TotalSalesbyStore(objVentasFinder);
            IList<TotalSales> lstOrdenesGratis = objVentasBLL.SelectTotalGratis(objVentasFinder);
            IList<Pizzas> lstResultPizzas = objPizzasBLL.SelectPizzasbyShop(objVentasFinder);
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                TiendaBLL objTiendaBLL = new TiendaBLL();
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objVentasFinder.UbicacionTienda,
                    Tipo = objVentasFinder.TipoTienda,
                    Number_tienda=objVentasFinder.NumTienda


                };

                IList<Tienda> objTiendas = objTiendaBLL.SelectTiendas(objFinder);
                foreach (Tienda item in objTiendas)
                {
                    GenerateWorksheet((Excel.Worksheet)xlWorkBook.Worksheets.Add(), objVentasFinder, item);
                }

                if (objTiendas.Count > 1)
                {
                    Tienda objTienda = new Tienda();
                    objTienda.Number_tienda = String.Empty;
                    GenerateWorksheet((Excel.Worksheet)xlWorkBook.Worksheets.Add(), objVentasFinder, objTienda, true);
                }

                #region TO DELETE

                //xlWorksheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //xlWorksheet.Name = "Abastos";
                //int xIni = 0, yIni = 0;
                ////Tabla de ventas
                //xlWorksheet.Cells[6, 1] = "Ventas Semanales";
                //xlWorksheet.Cells[6, 2] = "Cantidad";
                //xlWorksheet.Cells[6, 3] = " % ";

                //xlWorksheet.Cells[7, 1] = "Total Maestro";
                //xlWorksheet.Cells[8, 1] = "Canceladas";
                //xlWorksheet.Cells[9, 1] = "Ordenes Malas";
                //xlWorksheet.Cells[10, 1] = "Ventas Totales";
                //xlWorksheet.Cells[11, 1] = "Cupones/Domino's Check";
                //xlWorksheet.Cells[12, 1] = "Gratis";
                //xlWorksheet.Cells[13, 1] = "Ventas sujetas a I.V.A.";
                //xlWorksheet.Cells[14, 1] = "I.V.A.";
                //xlWorksheet.Cells[15, 1] = "Ventas Reales";
                //xlWorksheet.Cells[16, 1] = "Meta Ventas Reales";
                //xlWorksheet.Cells[17, 1] = "Semana Pasada";
                //xlWorksheet.Cells[18, 1] = "Año pasado";
                //xlWorksheet.Cells[19, 1] = "Ventas Netas";
                //xlWorksheet.Cells[20, 1] = "Ventas Restaurante (S/I.V.A.)";
                //xlWorksheet.Cells[21, 1] = "Ventas Mostrador (S/I.V.A.)";
                //xlWorksheet.Cells[22, 1] = "Ventas Reparto (S/I.V.A.)";
                //Range rangeVentas = xlWorksheet.Range["A6", "A22"];
                //rangeVentas.WrapText = true;
                //rangeVentas.ColumnWidth = 30;
                //yIni = 2;
                //xlWorksheet.Cells[7, yIni] = lstResultVentas[0].VentasBrutasTotal;
                //xlWorksheet.Cells[8, yIni] = lstResultVentas[0].CanceladasTotal;
                //xlWorksheet.Cells[9, yIni] = lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis;
                //xlWorksheet.Cells[10, yIni] = lstResultVentas[0].VentasNetasTotal ;
                //xlWorksheet.Cells[11, yIni] = 0;
                //xlWorksheet.Cells[12, yIni] = lstOrdenesGratis[0].TotalGratis;
                //xlWorksheet.Cells[13, yIni] = lstResultVentas[0].VentasNetasTotal;
                //xlWorksheet.Cells[14, yIni] = lstResultVentas[0].IVATotal;
                //xlWorksheet.Cells[15, yIni] = lstResultVentas[0].VentasRealesTotal;
                //xlWorksheet.Cells[16, yIni] = 0;
                //xlWorksheet.Cells[17, yIni] = 0;
                //xlWorksheet.Cells[18, yIni] = 0;
                //xlWorksheet.Cells[19, yIni] = lstResultVentas[0].VentasRealesTotal;
                //xlWorksheet.Cells[20, yIni] = (double)lstResultVentas[0].VentasRestauranteTotal-(((double)lstResultVentas[0].VentasRestauranteTotal/1.16) * 0.16);
                //xlWorksheet.Cells[21, yIni] = (double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal)-(((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) / 1.16) * 0.16);
                //xlWorksheet.Cells[22, yIni] = (double)lstResultVentas[0].VentasRepartoTotal-(((double)lstResultVentas[0].VentasRepartoTotal / 1.16) * 0.16);
                //Range rangeVentasVal = xlWorksheet.Range["B6", "B22"];
                //rangeVentasVal.NumberFormat = "$ #,##0.00";
                //yIni = 3;
                //xlWorksheet.Cells[7, yIni] = 1;
                //xlWorksheet.Cells[8, yIni] = (lstResultVentas[0].CanceladasTotal/lstResultVentas[0].VentasBrutasTotal);
                //xlWorksheet.Cells[9, yIni] = ((lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis) / lstResultVentas[0].VentasRealesTotal);
                //xlWorksheet.Cells[10, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal) ;
                //xlWorksheet.Cells[11, yIni] = 0;
                //xlWorksheet.Cells[12, yIni] =  lstOrdenesGratis[0].TotalGratis / lstResultVentas[0].VentasRealesTotal ;
                //xlWorksheet.Cells[13, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal) ;
                //xlWorksheet.Cells[14, yIni] = (lstResultVentas[0].IVATotal / lstResultVentas[0].VentasRealesTotal);
                //xlWorksheet.Cells[15, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal) ;
                //xlWorksheet.Cells[16, yIni] = 0;
                //xlWorksheet.Cells[17, yIni] = 0;
                //xlWorksheet.Cells[18, yIni] = 0;
                //xlWorksheet.Cells[19, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal) ;
                //xlWorksheet.Cells[20, yIni] = (((double)lstResultVentas[0].VentasRestauranteTotal - (((double)lstResultVentas[0].VentasRestauranteTotal / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal);
                //xlWorksheet.Cells[21, yIni] = (((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) - (((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal);
                //xlWorksheet.Cells[22, yIni] = (((double)lstResultVentas[0].VentasRepartoTotal - (((double)lstResultVentas[0].VentasRepartoTotal / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal); 
                //Range rangeVentasPer = xlWorksheet.Range["C6", "C22"];
                //rangeVentasPer.NumberFormat = "###,##0.00%";

                //BorderAround(xlWorksheet.Range["A6", "C22"], 0);



                //xlWorksheet.Cells[6, 4] = "Pizzas Desplazadas";
                //xlWorksheet.Cells[7, 4] = "Pizzas";
                //xlWorksheet.Cells[7, 5] = "Cantidad";
                //xlWorksheet.Cells[7, 6] = " % ";
                //xIni = 8;
                //yIni = 4;
                //int totalPizzas = 0;
                //foreach(Pizzas  item in lstResultPizzas)
                //{
                //    xlWorksheet.Cells[xIni, yIni] = "Pizza  " + item.Size + " " + item.Code;
                //    xlWorksheet.Cells[xIni, yIni+1] = item.Cantidad;
                //    xIni++;
                //    totalPizzas += item.Cantidad;

                //}
                //BorderAround(xlWorksheet.Range["D"+(xIni-lstResultPizzas.Count-2).ToString(), "F"+xIni.ToString()], 1);
                //xIni = 8;
                //yIni = 6;
                //foreach (Pizzas item in lstResultPizzas)
                //{
                //    xlWorksheet.Cells[xIni, yIni] =(double) item.Cantidad / totalPizzas;
                //    xIni++;
                //}
                //Range rangePizzas = xlWorksheet.Range["D7", "D7"];
                //rangePizzas.ColumnWidth = 25;
                //Range rangePizzasPer = xlWorksheet.Range["F8", "F"+xIni.ToString()];
                //rangePizzasPer.NumberFormat = "###,##0.00%";
                //IList<Pizzas> lstComplementos = objPizzasBLL.SelectComplementos(objVentasFinder);
                //xIni += 2;
                //yIni = 4;
                //int totalComplementos = 0;
                //int totalProducto = totalPizzas;
                // foreach(Pizzas item in  lstComplementos)
                // {
                //     xlWorksheet.Cells[xIni, yIni] = item.Producto;
                //     xlWorksheet.Cells[xIni, yIni+1] = item.Cantidad;
                //     xIni++;
                //     totalComplementos += item.Cantidad;
                //     if(item.Producto!="REFRESCOS")
                //     {
                //         totalProducto += item.Cantidad;
                //     }
                // }
                // xIni = xIni-lstComplementos.Count;
                // yIni = 6;
                //foreach(Pizzas item in  lstComplementos)
                //{
                //    xlWorksheet.Cells[xIni, yIni] = (Double)item.Cantidad / lstResultVentas[0].OrdenesTotales;
                //    xIni++;
                //}

                //BorderAround(xlWorksheet.Range["D" + (xIni - lstComplementos.Count - 1).ToString(), "F" + xIni.ToString()], 1);
                //Range rangeComplementosPer = xlWorksheet.Range["F" + (xIni-lstComplementos.Count).ToString(), "F" + xIni.ToString()];
                //rangeComplementosPer.NumberFormat = "###,##0.00%";
                ////Ordenes           
                //xlWorksheet.Cells[8,7]="Productividad";
                //xlWorksheet.Cells[9, 7] = "Ord. Reparto";
                //xlWorksheet.Cells[10, 7] = "Ord. Mostrador";
                //xlWorksheet.Cells[11, 7] = "Ord. Restaurante";
                //xlWorksheet.Cells[12, 7] = "Ord. Malas";
                //xlWorksheet.Cells[13, 7] = "Ord. Totales";
                //xlWorksheet.Cells[14, 7] = "Ticket Promedio";
                //xlWorksheet.Cells[15, 7] = "Pizza Promedio";
                //xlWorksheet.Cells[16, 7] = "Pizza por Orden";
                
                //xlWorksheet.Cells[8, 8] = totalProducto / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
                //xlWorksheet.Cells[9, 8] = lstResultVentas[0].OrdenesTotalReparto;
                //xlWorksheet.Cells[10, 8] = lstResultVentas[0].OrdenesTotalesMostrador;
                //xlWorksheet.Cells[11, 8] = lstResultVentas[0].OrdenesTotalesRestaurante;
                //xlWorksheet.Cells[12, 8] = lstResultVentas[0].OrdenesMalasCount;
                //xlWorksheet.Cells[13, 8] = lstResultVentas[0].OrdenesTotales;
                //xlWorksheet.Cells[14, 8] = lstResultVentas[0].VentasRealesTotal / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
                //xlWorksheet.Cells[15, 8] = lstResultVentas[0].VentasRealesTotal/totalPizzas;
                //xlWorksheet.Cells[16, 8] = (Double)totalPizzas / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
                //BorderAround(xlWorksheet.Range["G7", "H16" ], 1);
                //// cupones
                
                //xIni += 2;
                //yIni = 4;

                //IList<Pizzas> lstCupones = objPizzasBLL.SelectCupones(objVentasFinder);
                //xlWorksheet.Cells[xIni, yIni] = "Cupon";
                //xlWorksheet.Cells[xIni, yIni+1] = "Participacion";
                //xIni++;

                //foreach(Pizzas item in lstCupones)
                //{
                //    xlWorksheet.Cells[xIni, yIni] = item.Code;
                //    xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                //    xlWorksheet.Cells[xIni, yIni + 2] = (double) item.Cantidad/ lstResultVentas[0].OrdenesTotales;
                //    xIni++;
                //}
                //Range porcentajesCupones = xlWorksheet.Range["F"+(xIni-lstCupones.Count).ToString(), "F" + xIni.ToString()];
                //porcentajesCupones.NumberFormat = "###,##0.00%";

                //xIni -= (lstCupones.Count+1);
                //yIni +=3;

                //IList<Pizzas> lstCupones2 = objPizzasBLL.SelectCupones2(objVentasFinder);
                //xlWorksheet.Cells[xIni, yIni] = "Cupon";
                //xlWorksheet.Cells[xIni, yIni + 1] = "Participacion";
                //xIni++;

                //foreach (Pizzas item in lstCupones2)
                //{
                //    xlWorksheet.Cells[xIni, yIni] = item.Code;
                //    xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                //    xlWorksheet.Cells[xIni, yIni + 2] = (double)item.Cantidad / lstResultVentas[0].OrdenesTotales;
                //    xIni++;
                //}
                //BorderAround(xlWorksheet.Range["D" + (xIni- 1-lstCupones2.Count).ToString(), "I" +(xIni-lstCupones2.Count +lstCupones.Count).ToString()], 1);
                //Range porcentajesCupones2 = xlWorksheet.Range["I" + (xIni - lstCupones2.Count).ToString(), "I" + xIni.ToString()];
                //porcentajesCupones2.NumberFormat = "###,##0.00%";
                //IList<Inventario> lstMasas = objInventarioBLL.SelectMasasPizzas(objVentasFinder);
                //IList<Inventario> lstRefrescos = objInventarioBLL.SelectDrink(objVentasFinder);
                //xIni = xIni - lstCupones2.Count +lstCupones.Count;
                //xIni++;
                //yIni = 4;
                //xlWorksheet.Cells[xIni, yIni] = "Descripcion";
                //xlWorksheet.Cells[xIni, yIni + 1] = "Inv. Inicial";
                //xlWorksheet.Cells[xIni, yIni + 2] = "Compras";
                //xlWorksheet.Cells[xIni, yIni + 3] = "Inv. Final";
                //xlWorksheet.Cells[xIni, yIni + 4] = "Utilizado";
                //xlWorksheet.Cells[xIni, yIni + 5] = "Vendido";
                //xlWorksheet.Cells[xIni, yIni + 6] = "Diferencia";
                //xlWorksheet.Cells[xIni, yIni + 7] = "Costo Unitario";
                //xlWorksheet.Cells[xIni, yIni + 8] = "Costo Mermas";
                //xIni++;
                //foreach(Inventario item in lstMasas)
                //{
                //    xlWorksheet.Cells[xIni, yIni] = item.Producto;
                //    xlWorksheet.Cells[xIni, yIni + 1] = item.Beginning_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 2] = item.Delivered_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 3] = item.Ending_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 4] = item.Actual_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 5] = item.Ideal_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 6] = item.Actual_Usage-item.Ideal_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 7] = item.PrecioUnitario;
                //    xlWorksheet.Cells[xIni, yIni + 8] = (item.Actual_Usage - item.Ideal_Usage)*item.PrecioUnitario;
                //    xIni++;
                //}
                //foreach (Inventario item in lstRefrescos )
                //{
                //    xlWorksheet.Cells[xIni, yIni] = item.Code;
                //    xlWorksheet.Cells[xIni, yIni + 1] = item.Beginning_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 2] = item.Delivered_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 3] = item.Ending_Qty;
                //    xlWorksheet.Cells[xIni, yIni + 4] = item.Actual_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 5] = item.Ideal_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 6] = item.Actual_Usage - item.Ideal_Usage;
                //    xlWorksheet.Cells[xIni, yIni + 7] = item.PrecioUnitario;
                //    xlWorksheet.Cells[xIni, yIni + 8] = (item.Actual_Usage - item.Ideal_Usage) * item.PrecioUnitario;
                //    xIni++;
                //}

                //BorderAround(xlWorksheet.Range["D" + (xIni - 1 - lstRefrescos.Count - lstMasas.Count).ToString(), "L" + xIni.ToString()], 1);
                //IList<ResumenDiario> lstResumendiario = objResumenDiarioBLL.SelectVentasComidaOrdenes(objVentasFinder);

                //xIni++;
                //xlWorksheet.Cells[xIni, yIni] = "Día";
                //xlWorksheet.Cells[xIni, yIni + 1] = "Venta Diaria";
                //xlWorksheet.Cells[xIni, yIni + 2] = "% Vta. Diaria";
                //xlWorksheet.Cells[xIni, yIni + 3] = "Utilizado";
                //xlWorksheet.Cells[xIni, yIni + 4] = "% Utilizad0";
                //xlWorksheet.Cells[xIni, yIni + 5] = "Ordenes";               
                //xIni++;
                //for (int i = 0; i < lstResumendiario.Count; i++)
                //{
                //    if (i < lstResumendiario.Count - 1)
                //    {
                //        xlWorksheet.Cells[xIni, yIni] = lstResumendiario[i].Dia;
                //        xlWorksheet.Cells[xIni, yIni + 1] = lstResumendiario[i].Venta;
                //        xlWorksheet.Cells[xIni, yIni + 2] = lstResumendiario[i].Venta / lstResumendiario[lstResumendiario.Count - 1].Venta;
                //        xlWorksheet.Cells[xIni, yIni + 3] = lstResumendiario[i].Utilizado;
                //        xlWorksheet.Cells[xIni, yIni + 4] = lstResumendiario[i].Utilizado / lstResumendiario[lstResumendiario.Count - 1].Utilizado;
                //        xlWorksheet.Cells[xIni, yIni + 5] = lstResumendiario[i].Ordenes;
                //        xIni++;
                //    }
                //    else
                //    {
                //        xlWorksheet.Cells[xIni, yIni] = "Total";
                //        xlWorksheet.Cells[xIni, yIni + 1] = lstResumendiario[i].Venta;
                //        xlWorksheet.Cells[xIni, yIni + 2] = lstResumendiario[i].Venta / lstResumendiario[lstResumendiario.Count - 1].Venta;
                //        xlWorksheet.Cells[xIni, yIni + 3] = lstResumendiario[i].Utilizado;
                //        xlWorksheet.Cells[xIni, yIni + 4] = lstResumendiario[i].Utilizado / lstResumendiario[lstResumendiario.Count - 1].Utilizado;
                //        xlWorksheet.Cells[xIni, yIni + 5] = lstResumendiario[i].Ordenes;
                //    }
                    
                //}
                //BorderAround(xlWorksheet.Range["D" + (xIni  - lstResumendiario.Count).ToString(), "I" + xIni.ToString()], 1);







               //IList<EntradasSalidas> lstEntradaSalidas= objEntredaSalidaBLL.SelectFacturas(objVentasFinder);
               //xIni = 24;
               //yIni = 1;
               //xlWorksheet.Cells[xIni, yIni] = "Factura";
               //xlWorksheet.Cells[xIni, yIni + 1] = "Cantidad";
               //xIni++;
               // foreach(EntradasSalidas item in lstEntradaSalidas)
               // {
               //     xlWorksheet.Cells[xIni, yIni] = "Factura #"+item.NumeroFactura;
               //     xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
               //     xIni++;
               // }

               // IList<EntradasSalidas> lstTotalFacturas = objEntredaSalidaBLL.SelectTotalFacturas(objVentasFinder);
               // xIni++;
               // xlWorksheet.Cells[xIni, yIni] = "Total de Facturas";
               // xlWorksheet.Cells[xIni, yIni + 1] = lstTotalFacturas[0].TotalFactura;
               // IList<Inventario> lstInventariosINI_END = objInventarioBLL.SelectInventarioInicialFinal(objVentasFinder);
               // xIni++;
               // xlWorksheet.Cells[xIni, yIni] = "Inventario Inicial";
               // xlWorksheet.Cells[xIni, yIni + 1] = lstInventariosINI_END[0].Inventario_Inicial;
               // xIni++;
               // xlWorksheet.Cells[xIni, yIni] = "Inventario Final";
               // xlWorksheet.Cells[xIni, yIni + 1] = lstInventariosINI_END[1].Inventario_Inicial;
               // xIni++;
               // xlWorksheet.Cells[xIni, yIni] = "Utilizado";
               // xlWorksheet.Cells[xIni, yIni + 1] = (lstTotalFacturas[0].TotalFactura + lstInventariosINI_END[0].Inventario_Inicial)- lstInventariosINI_END[1].Inventario_Inicial;
               // BorderAround(xlWorksheet.Range["A" + (xIni - lstEntradaSalidas.Count-5).ToString(), "C" + xIni.ToString()], 1);

               // #region INFORMACION OPERATIVA
               // xIni++;
               // IList<InformacionOperativa> lstTiempoPromedio = objInformacionOperativaBLL.SelectTiemposPromedio(objVentasFinder);
               // if (lstTiempoPromedio.Count > 0)
               // {
               //     xlWorksheet.Cells[xIni, yIni] = "INFORMACION OPERATIVA";
               //     xIni++;
               //     xlWorksheet.Cells[xIni, yIni] = "TIEMPO PROMEDIO";
               //     xlWorksheet.Cells[xIni, yIni + 1] = "LOGRADO";
               //     xlWorksheet.Cells[xIni, yIni + 2] = "META";
               //     xIni++;

               //     xlWorksheet.Cells[xIni, yIni] = "Toma de Ordenes";
               //     xlWorksheet.Cells[xIni, yIni + 1] = TimeSpan.FromMinutes((double)lstTiempoPromedio[0].TomaOrden).ToString();
               //     xlWorksheet.Cells[xIni, yIni + 2] = " 1 MIN";
               //     xIni++;

               //     xlWorksheet.Cells[xIni, yIni] = "Produccion";
               //     xlWorksheet.Cells[xIni, yIni + 1] = TimeSpan.FromMinutes((double)lstTiempoPromedio[0].Produccion).ToString();
               //     xlWorksheet.Cells[xIni, yIni + 2] = " 3 MIN";
               //     xIni++;

               //     xlWorksheet.Cells[xIni, yIni] = "Repisa";
               //     xlWorksheet.Cells[xIni, yIni + 1] = TimeSpan.FromMinutes((double)lstTiempoPromedio[0].Repisa).ToString();
               //     xlWorksheet.Cells[xIni, yIni + 2] = " 2 MIN";
               //     xIni++;

               //     xlWorksheet.Cells[xIni, yIni] = "Fuera de Tienda";
               //     xlWorksheet.Cells[xIni, yIni + 1] = TimeSpan.FromMinutes((double)lstTiempoPromedio[0].FueraTienda).ToString();
               //     xlWorksheet.Cells[xIni, yIni + 2] = " 15 MIN";
               //     xIni++;

               //     xlWorksheet.Cells[xIni, yIni] = "Estimado de Entrega";
               //     xlWorksheet.Cells[xIni, yIni + 1] = TimeSpan.FromMinutes((double)lstTiempoPromedio[0].Entrega).ToString();
               //     xlWorksheet.Cells[xIni, yIni + 2] = " 20 MIN";
               //     xIni++;

               //     BorderAround(xlWorksheet.Range["A" + (xIni  - 7).ToString(), "C" + xIni.ToString()], 1);




               // }



                #endregion

                DateTime dateAux = DateTime.Now;
                 string nombreArchivo = "Indicador.xlsx";
                 if (File.Exists(Server.MapPath("/indicadores") + "/" + nombreArchivo))
                 {
                     File.Delete(Server.MapPath("/indicadores") + "/" + nombreArchivo);
                 }
                 xlWorkBook.SaveAs(Server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                return nombreArchivo;
  
            }
            return string.Empty;
        }

        private void GenerateWorksheet(Excel.Worksheet xlWorksheet, VentasFinder objFinder, Tienda objTienda, bool general = false)
        {
            // BLL's
            VentasBLL objVentasBLL = new VentasBLL();
            PizzasBLL objPizzasBLL = new PizzasBLL();
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            ResumenDiarioBLL objResumenDiarioBLL = new ResumenDiarioBLL();
            InformacionOperativaBLL objInformacionOperativaBLL = new InformacionOperativaBLL();

            objFinder.NumTienda = objTienda.Number_tienda;
            IList<TotalSales> lstResultVentas = objVentasBLL.TotalSalesbyStore(objFinder);
            IList<TotalSales> lstOrdenesGratis = objVentasBLL.SelectTotalGratis(objFinder);
            IList<Pizzas> lstResultPizzas = objPizzasBLL.SelectPizzasbyShop(objFinder);
            xlWorksheet.Name = !string.IsNullOrEmpty(objTienda.Nombre_tienda) ? objTienda.Nombre_tienda : "Franquicias"; ;
            int xIni = 0, yIni = 0;

           
            Excel.Range rangeVentas1 = xlWorksheet.Range["G1", "G2"];
            rangeVentas1.WrapText = true;
            rangeVentas1.ColumnWidth = 15;
            rangeVentas1 = xlWorksheet.Range["H1", "H2"];
            rangeVentas1.WrapText = true;
            rangeVentas1.ColumnWidth = 15;
            rangeVentas1 = xlWorksheet.Range["I1", "i2"];
            rangeVentas1.WrapText = true;
            rangeVentas1.ColumnWidth = 15;

            Excel.Range empresaHead = xlWorksheet.Range["A1", "I1"];
            empresaHead.Merge();
            empresaHead.Value = "ORGANIZACION DOT";
            empresaHead.Font.Size = 24;
            empresaHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range tiendaHead = xlWorksheet.Range["A2", "I2"];
            tiendaHead.Merge();
            tiendaHead.Font.Size=18;
            tiendaHead.Value = objTienda.Namefull;
            tiendaHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            xlWorksheet.Cells[3, 1] = "FECHA INICIAL:";
            xlWorksheet.Cells[3, 2] = objFinder.DateIni.Value.ToShortDateString();

            xlWorksheet.Cells[4, 1] = "FECHA FINAL:";
            xlWorksheet.Cells[4, 2] = objFinder.DateEnd.Value.ToShortDateString();

            xlWorksheet.Cells[5, 1] = "GERENTE:";
            xlWorksheet.Cells[5, 2] = objTienda.Gerente;

            xlWorksheet.Cells[3, 4] = "SEMANA DOMINO`S";
            xlWorksheet.Cells[3, 5] = objFinder.NumeroSemana;


            tiendaHead = xlWorksheet.Range["A3", "E5"];
            tiendaHead.Font.Bold=true;
            tiendaHead.Font.Size = 13;

           
            if (lstResultVentas.Count > 0 && lstResultVentas[0].VentasBrutasTotal>0)
            {
                #region VENTAS
                IList<SalesLastYear> lstSalesLastyear = objVentasBLL.SelectSalesLastYearSecond(objFinder);
                IList<SalesLastYear> lstSalesLastWeek = objVentasBLL.SelectSalesLastWeek(objFinder);
                xlWorksheet.Cells[6, 1] = " VENTAS";
                Excel.Range headVentas = xlWorksheet.Range["A6", "C6"];
                headVentas.Merge();
                headVentas.Value = "VENTAS";                
                xlWorksheet.Cells[7, 1] = "Ventas Semanales";
                xlWorksheet.Cells[7, 2] = "Cantidad";
                xlWorksheet.Cells[7, 3] = " % ";
                xlWorksheet.Cells[8, 1] = "Total Maestro";
                xlWorksheet.Cells[9, 1] = "Canceladas";
                xlWorksheet.Cells[10, 1] = "Ordenes Malas";
                xlWorksheet.Cells[11, 1] = "Ventas Totales";
                xlWorksheet.Cells[12, 1] = "Cupones/Domino's Check";
                xlWorksheet.Cells[13, 1] = "Gratis";
                xlWorksheet.Cells[14, 1] = "Ventas sujetas a I.V.A.";
                xlWorksheet.Cells[15, 1] = "I.V.A.";
                xlWorksheet.Cells[16, 1] = "Ventas Reales";
                xlWorksheet.Cells[17, 1] = "Meta Ventas Reales";
                xlWorksheet.Cells[18, 1] = "Semana Pasada";
                xlWorksheet.Cells[19, 1] = "Año pasado";
                xlWorksheet.Cells[20, 1] = "Ventas Netas";
                xlWorksheet.Cells[21, 1] = "Ventas Restaurante (S/I.V.A.)";
                xlWorksheet.Cells[22, 1] = "Ventas Mostrador (S/I.V.A.)";
                xlWorksheet.Cells[23, 1] = "Ventas Reparto (S/I.V.A.)";
                Excel.Range rangeVentas = xlWorksheet.Range["A6", "A22"];
                rangeVentas.WrapText = true;
                rangeVentas.ColumnWidth = 30;
                yIni = 2;
                decimal canceladas = lstResultVentas[0].CanceladasTotal;
                decimal ventasMalas = lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis;
                xlWorksheet.Cells[8, yIni] = objFinder.IndicadorFull?lstResultVentas[0].VentasBrutasTotal:0;
                xlWorksheet.Cells[9, yIni] = lstResultVentas[0].CanceladasTotal;
                xlWorksheet.Cells[10, yIni] = lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis;
                xlWorksheet.Cells[11, yIni] = objFinder.IndicadorFull? lstResultVentas[0].VentasNetasTotal:0;
                xlWorksheet.Cells[12, yIni] = 0;
                xlWorksheet.Cells[13, yIni] = lstOrdenesGratis[0].TotalGratis;
                xlWorksheet.Cells[14, yIni] = objFinder.IndicadorFull?lstResultVentas[0].VentasNetasTotal:0;
                xlWorksheet.Cells[15, yIni] = objFinder.IndicadorFull?lstResultVentas[0].IVATotal:0;
                xlWorksheet.Cells[16, yIni] = objFinder.IndicadorFull?lstResultVentas[0].VentasRealesTotal:0;
                xlWorksheet.Cells[17, yIni] = objFinder.IndicadorFull ? (Double)lstSalesLastyear[0].VentasReales * 1.1 : 0;
                xlWorksheet.Cells[18, yIni] = objFinder.IndicadorFull?lstSalesLastWeek[0].VentasReales:0;
                xlWorksheet.Cells[19, yIni] = objFinder.IndicadorFull ? lstSalesLastyear[0].VentasReales : 0;
                xlWorksheet.Cells[20, yIni] = objFinder.IndicadorFull?lstResultVentas[0].VentasRealesTotal:0;
                xlWorksheet.Cells[21, yIni] = objFinder.IndicadorFull?(double)lstResultVentas[0].VentasRestauranteTotal - (((double)lstResultVentas[0].VentasRestauranteTotal / 1.16) * 0.16):0;
                xlWorksheet.Cells[22, yIni] = objFinder.IndicadorFull?(double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) - (((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) / 1.16) * 0.16):0;
                xlWorksheet.Cells[23, yIni] = objFinder.IndicadorFull?(double)lstResultVentas[0].VentasRepartoTotal - (((double)lstResultVentas[0].VentasRepartoTotal / 1.16) * 0.16):0;
                Excel.Range rangeVentasVal = xlWorksheet.Range["B6", "B23"];
                rangeVentasVal.NumberFormat = "$ #,##0.00";
                yIni = 3;
                xlWorksheet.Cells[8, yIni] = 1;
                xlWorksheet.Cells[9, yIni] = (lstResultVentas[0].CanceladasTotal / lstResultVentas[0].VentasBrutasTotal);
                xlWorksheet.Cells[10, yIni] = ((lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis) / lstResultVentas[0].VentasRealesTotal);
                xlWorksheet.Cells[11, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal);
                xlWorksheet.Cells[12, yIni] = 0;
                xlWorksheet.Cells[13, yIni] = lstOrdenesGratis[0].TotalGratis / lstResultVentas[0].VentasRealesTotal;
                xlWorksheet.Cells[14, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal);
                xlWorksheet.Cells[15, yIni] = (lstResultVentas[0].IVATotal / lstResultVentas[0].VentasRealesTotal);
                xlWorksheet.Cells[16, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal);
                xlWorksheet.Cells[17, yIni] = (Double)((Double)(lstResultVentas[0].VentasRealesTotal) / (Double)((Double)lstSalesLastyear[0].VentasReales * 1.1)) - 1;
                xlWorksheet.Cells[18, yIni] = (double)((Double)lstResultVentas[0].VentasRealesTotal / (double)lstSalesLastWeek[0].VentasReales) - 1; ;
                xlWorksheet.Cells[19, yIni] = (double)((Double)lstResultVentas[0].VentasRealesTotal / (double)lstSalesLastyear[0].VentasReales) - 1; ;
                xlWorksheet.Cells[20, yIni] = (lstResultVentas[0].VentasNetasTotal / lstResultVentas[0].VentasBrutasTotal);
                xlWorksheet.Cells[21, yIni] = (((double)lstResultVentas[0].VentasRestauranteTotal - (((double)lstResultVentas[0].VentasRestauranteTotal / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal);
                xlWorksheet.Cells[22, yIni] = (((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) - (((double)(lstResultVentas[0].VentasMostradorTotal - lstResultVentas[0].VentasRestauranteTotal) / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal);
                xlWorksheet.Cells[23, yIni] = (((double)lstResultVentas[0].VentasRepartoTotal - (((double)lstResultVentas[0].VentasRepartoTotal / 1.16) * 0.16)) / (double)lstResultVentas[0].VentasRealesTotal);
                Excel.Range rangeVentasPer = xlWorksheet.Range["C6", "C23"];
                rangeVentasPer.NumberFormat = "###,##0.00%";
                BorderAround(xlWorksheet.Range["A6", "C23"], 0);
                rangeVentasPer = xlWorksheet.Range["A16", "C16"];
                rangeVentasPer.Font.Size = 12;
                rangeVentasPer.Font.Bold = true;


                #endregion

                xIni = 25;
                yIni = 1;
                IList<EntradasSalidas> lstEntradaSalidas = objEntredaSalidaBLL.SelectFacturas(objFinder);
                IList<Inventario> lstInventariosINI_END = objInventarioBLL.SelectInventarioInicialFinal(objFinder);
                IList<EntradasSalidas> lstTotalFacturas = objEntredaSalidaBLL.SelectTotalFacturas(objFinder);
                if (!general)
                {
                    #region Entradas Salidas Facturas
                    
                    xIni = 25;
                    yIni = 1;
                    xlWorksheet.Cells[xIni, yIni] = "Factura";
                    xlWorksheet.Cells[xIni, yIni + 1] = "Cantidad";
                    xIni++;
                    foreach (EntradasSalidas item in lstEntradaSalidas)
                    {
                        xlWorksheet.Cells[xIni, yIni] = "Factura #" + item.NumeroFactura;
                        xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                        xIni++;
                    }

                    
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Total de Facturas";
                    xlWorksheet.Cells[xIni, yIni + 1] = lstTotalFacturas[0].TotalFactura;
                    
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Inventario Inicial";
                    xlWorksheet.Cells[xIni, yIni + 1] = lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial;
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Inventario Final";
                    xlWorksheet.Cells[xIni, yIni + 1] = lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final;
                    xlWorksheet.Cells[xIni, yIni+2] = "Costo Comida";
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Utilizado Real";
                    xlWorksheet.Cells[xIni, yIni + 1] = (lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final);
                    xlWorksheet.Cells[xIni, yIni + 2] = ((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / lstResultVentas[0].VentasRealesTotal;
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Utilizado Ideal";
                    xlWorksheet.Cells[xIni, yIni + 1] = lstResultVentas[0].Utilizado;
                    xlWorksheet.Cells[xIni, yIni + 2] = lstResultVentas[0].Utilizado / lstResultVentas[0].VentasRealesTotal;
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Diferencia";
                    xlWorksheet.Cells[xIni, yIni + 1] = (lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)-lstResultVentas[0].Utilizado;

                    rangeVentasPer=xlWorksheet.Range["C" + (xIni-2).ToString(), "C" + xIni.ToString()];
                    rangeVentasPer.NumberFormat = " ###,##0.00%";
                    BorderAround(xlWorksheet.Range["A" + (xIni - lstEntradaSalidas.Count - 8).ToString(), "C" + xIni.ToString()], 1);

                    rangeVentasPer = xlWorksheet.Range["A"+(xIni-5).ToString(), "C" + xIni.ToString()];
                    rangeVentasPer.Font.Size = 12;
                    rangeVentasPer.Font.Bold = true;
                    rangeVentasPer = xlWorksheet.Range["B" + (xIni - 5).ToString(), "B" + xIni.ToString()];
                    rangeVentasPer.NumberFormat = "$ #,##0.00";

                    #endregion
                }
                int TamColumn1 = xIni+1;
                #region COMPLEMENTOS

                IList<Pizzas> lstComplementos = objPizzasBLL.SelectComplementos(objFinder);
                xIni = 6;
                yIni = 4;
                int totalComplementos = 0;
                int totalProducto = 0;
                Excel.Range headComplementos = xlWorksheet.Range["D" + xIni.ToString(), "F" + xIni.ToString()];
                headComplementos.Merge();
                headComplementos.Value = "COMPLEMENTOS DESPLAZADOS";
                xIni++;
                xlWorksheet.Cells[xIni, yIni] = "COMPLEMENTOS";
                xlWorksheet.Cells[xIni, yIni + 1] = "CANTIDAD";
                xlWorksheet.Cells[xIni, yIni + 2] = " % ";
                xIni++;

                foreach (Pizzas item in lstComplementos)
                {
                    xlWorksheet.Cells[xIni, yIni] = item.Producto;
                    xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                    xIni++;
                    totalComplementos += item.Cantidad;
                    if (!item.Producto.Contains("REFRESCO"))
                    {
                        totalProducto += item.Cantidad;
                    }
                }
                xlWorksheet.Cells[xIni, yIni] = "PARTICIPACION DE ADICIONALES";
                xlWorksheet.Cells[xIni, yIni + 1] = totalComplementos;
                rangeVentasPer = xlWorksheet.Range["D"+xIni.ToString(), "F"+xIni.ToString()];
                rangeVentasPer.Font.Size = 12;
                rangeVentasPer.Font.Bold = true;
                xIni = xIni - lstComplementos.Count;
                yIni = 6;
                foreach (Pizzas item in lstComplementos)
                {
                    xlWorksheet.Cells[xIni, yIni] = (Double)item.Cantidad / lstResultVentas[0].OrdenesTotales;
                    xIni++;
                }
                xlWorksheet.Cells[xIni, yIni] = (Double)totalComplementos / lstResultVentas[0].OrdenesTotales;


                BorderAround(xlWorksheet.Range["D" + (xIni - lstComplementos.Count - 2).ToString(), "F" + xIni.ToString()], 1);
                Excel.Range rangeComplementosPer = xlWorksheet.Range["F" + (xIni - lstComplementos.Count).ToString(), "F" + xIni.ToString()];
                rangeComplementosPer.NumberFormat = "###,##0.00%";
                #endregion
                #region PIZZAS

                yIni = 4;
                xIni++;
                Excel.Range headPizzas = xlWorksheet.Range["D" + xIni.ToString(), "F" + xIni.ToString()];
                headPizzas.Merge();
                headPizzas.Value = "PIZZAS DESPLAZADAS";
                xIni++;
                xlWorksheet.Cells[xIni, yIni] = "Pizzas";
                xlWorksheet.Cells[xIni, yIni+1] = "Cantidad";
                xlWorksheet.Cells[xIni, yIni+2] = " % ";
                xIni++;
                
                int totalPizzas = 0;
                foreach (Pizzas item in lstResultPizzas)
                {
                    xlWorksheet.Cells[xIni, yIni] = "Pizza  " + item.Size + " " + item.Code;
                    xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                    xIni++;
                    totalPizzas += item.Cantidad;

                }
                xIni = xIni-lstResultPizzas.Count;
                yIni = 6;
                foreach (Pizzas item in lstResultPizzas)
                {
                    xlWorksheet.Cells[xIni, yIni] = (double)item.Cantidad / totalPizzas;
                    xIni++;
                }
                totalProducto += totalPizzas;
                BorderAround(xlWorksheet.Range["D" + (xIni - lstResultPizzas.Count - 2).ToString(), "F" + xIni.ToString()], 1);

                Excel.Range rangePizzas = xlWorksheet.Range["D7", "D7"];
                rangePizzas.ColumnWidth = 25;
                Excel.Range rangePizzasPer = xlWorksheet.Range["F8", "F" + xIni.ToString()];
                rangePizzasPer.NumberFormat = "###,##0.00%";

                #endregion
                #region RESUMEN ORDENES 
                //Ordenes 
                yIni=4;
                xIni++;
                Excel.Range headR_Orden = xlWorksheet.Range["D" + xIni.ToString(), "F" + xIni.ToString()];
                headR_Orden.Merge();
                headR_Orden.Value = "RESUMEN DE ORDENES";
                xIni+=2;
                xlWorksheet.Cells[xIni, yIni] = "Productividad";
                xlWorksheet.Cells[xIni+1, yIni] = "Ord. Reparto";
                xlWorksheet.Cells[xIni+2, yIni] = "Ord. Mostrador";
                xlWorksheet.Cells[xIni+3, yIni] = "Ord. Restaurante";
                xlWorksheet.Cells[xIni+4, yIni] = "Ord. Malas";
                xlWorksheet.Cells[xIni+5, yIni] = "Ord. Totales";
                xlWorksheet.Cells[xIni+6, yIni] = "Ticket Promedio";
                xlWorksheet.Cells[xIni+7, yIni] = "Pizza Promedio";
                xlWorksheet.Cells[xIni+8, yIni] = "Pizza por Orden";
                yIni++;
                xlWorksheet.Cells[xIni, yIni] = (double)totalProducto / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
                xlWorksheet.Cells[xIni+1, yIni] = lstResultVentas[0].OrdenesTotalReparto;
                xlWorksheet.Cells[xIni+2, yIni] = lstResultVentas[0].OrdenesTotalesMostrador;
                xlWorksheet.Cells[xIni+3, yIni] = lstResultVentas[0].OrdenesTotalesRestaurante;
                xlWorksheet.Cells[xIni+4, yIni] = lstResultVentas[0].OrdenesMalasCount;
                xlWorksheet.Cells[xIni+5, yIni] = lstResultVentas[0].OrdenesTotales;
                xlWorksheet.Cells[xIni+6, yIni] = objFinder.IndicadorFull? lstResultVentas[0].VentasRealesTotal / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount):0;
                xlWorksheet.Cells[xIni+7, yIni] = lstResultVentas[0].VentasRealesTotal / totalPizzas;
                xlWorksheet.Cells[xIni+8, yIni] = (Double)totalPizzas / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
                BorderAround(xlWorksheet.Range["D" + (xIni - 2).ToString(), "F" + (xIni + 8).ToString()], 1);

                Excel.Range Promedio = xlWorksheet.Range["E" + (xIni + 6).ToString(), "E" + (xIni + 7).ToString()];
                Promedio.NumberFormat = "$ #,##0.00";

                Excel.Range PRODUCTIVIDAD = xlWorksheet.Range["E" + xIni.ToString(), "E" + xIni.ToString()];
                PRODUCTIVIDAD.NumberFormat = "#,##0.00";

                Excel.Range PIZZAPROMEDIO = xlWorksheet.Range["E" + (xIni + 8).ToString(), "E" + (xIni + 8).ToString()];
                PIZZAPROMEDIO.NumberFormat = " #,##0.00";

                rangeVentasPer = xlWorksheet.Range["D" + (xIni +5).ToString(), "E" + (xIni + 8).ToString()];
                rangeVentasPer.Font.Size = 12;
                rangeVentasPer.Font.Bold = true;
                #endregion
                
                    #region Ventas Diarias
                    yIni = 1;

                    xIni += 9;
                    if (xIni < TamColumn1)
                        xIni = TamColumn1;
                    IList<ResumenDiario> lstResumendiario = objResumenDiarioBLL.SelectVentasComidaOrdenes(objFinder);
                    Excel.Range headVentasDiarias = xlWorksheet.Range["A" + xIni.ToString(), "F" + xIni.ToString()];
                    headVentasDiarias.Merge();
                    headVentasDiarias.Value = "VENTAS DIARIAS , % COMIDA, ORDENES";
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Día";
                    xlWorksheet.Cells[xIni, yIni + 1] = "Venta Diaria";
                    xlWorksheet.Cells[xIni, yIni + 2] = "% Vta. Diaria";
                    xlWorksheet.Cells[xIni, yIni + 3] = "Utilizado";
                    xlWorksheet.Cells[xIni, yIni + 4] = "% Utilizad0";
                    xlWorksheet.Cells[xIni, yIni + 5] = "Ordenes";
                    xIni++;
                    for (int i = 0; i < lstResumendiario.Count; i++)
                    {
                        if (i < lstResumendiario.Count - 1)
                        {
                            xlWorksheet.Cells[xIni, yIni] = lstResumendiario[i].Dia.ToUpper();
                            xlWorksheet.Cells[xIni, yIni + 1] = objFinder.IndicadorFull?lstResumendiario[i].Venta:0;
                            xlWorksheet.Cells[xIni, yIni + 2] = objFinder.IndicadorFull?lstResumendiario[i].Venta / lstResumendiario[lstResumendiario.Count - 1].Venta:0;
                            xlWorksheet.Cells[xIni, yIni + 3] = objFinder.IndicadorFull?lstResumendiario[i].Utilizado:0;
                            xlWorksheet.Cells[xIni, yIni + 4] = objFinder.IndicadorFull?lstResumendiario[i].Venta > 0 ? lstResumendiario[i].Utilizado / lstResumendiario[i].Venta : 0:0;
                            xlWorksheet.Cells[xIni, yIni + 5] = objFinder.IndicadorFull?lstResumendiario[i].Ordenes:0;
                            xIni++;
                        }
                        else
                        {
                            xlWorksheet.Cells[xIni, yIni] = "Total";
                            xlWorksheet.Cells[xIni, yIni + 1] = objFinder.IndicadorFull?lstResumendiario[i].Venta:0;
                            xlWorksheet.Cells[xIni, yIni + 2] = objFinder.IndicadorFull?lstResumendiario[i].Venta / lstResumendiario[lstResumendiario.Count - 1].Venta:0;
                            xlWorksheet.Cells[xIni, yIni + 3] = objFinder.IndicadorFull?lstResumendiario[i].Utilizado:0;
                            xlWorksheet.Cells[xIni, yIni + 4] = objFinder.IndicadorFull?lstResumendiario[i].Utilizado / lstResumendiario[i].Venta:0;
                            xlWorksheet.Cells[xIni, yIni + 5] = objFinder.IndicadorFull?lstResumendiario[i].Ordenes:0;

                        }

                    }
                    BorderAround(xlWorksheet.Range["A" + (xIni - lstResumendiario.Count - 1).ToString(), "F" + xIni.ToString()], 1);

                    Excel.Range VentasDiarias = xlWorksheet.Range["B" + (xIni - lstResumendiario.Count).ToString(), "B" + xIni.ToString()];
                    VentasDiarias.NumberFormat = "$ #,##0.00";
                    Excel.Range VentasUtilizado = xlWorksheet.Range["D" + (xIni - lstResumendiario.Count).ToString(), "D" + xIni.ToString()];
                    VentasUtilizado.NumberFormat = "$ #,##0.00";

                    Excel.Range VentasDiariasPor = xlWorksheet.Range["C" + (xIni - lstResumendiario.Count).ToString(), "C" + xIni.ToString()];
                    VentasDiariasPor.NumberFormat = "###,##0.00%";
                    Excel.Range VentasUtilizadoPor = xlWorksheet.Range["E" + (xIni - lstResumendiario.Count).ToString(), "E" + xIni.ToString()];
                    VentasUtilizadoPor.NumberFormat = "###,##0.00%";

                    rangeVentasPer = xlWorksheet.Range["A" + xIni.ToString(), "F" + xIni.ToString()];
                    rangeVentasPer.Font.Size = 12;
                    rangeVentasPer.Font.Bold = true;
                    #endregion
                

                xIni++;
                if (!general)
                {
                    IList<Inventario> lstMasas = objInventarioBLL.SelectMasasPizzas(objFinder);
                    IList<Inventario> lstRefrescos = objInventarioBLL.SelectDrink(objFinder);
                    //xIni = xIni - lstCupones2.Count + lstCupones.Count;
                    
                    yIni = 1;
                    #region MASAS CAJAS REFRESCOS
                    Excel.Range headMasas = xlWorksheet.Range["A" + xIni.ToString(), "F" + xIni.ToString()];
                    headMasas.Merge();
                    headMasas.Value = "MASAS--CAJAS--REFRESCOS";
                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Descripcion";
                    xlWorksheet.Cells[xIni, yIni + 1] = "Inv. Inicial";
                    xlWorksheet.Cells[xIni, yIni + 2] = "Compras";
                    xlWorksheet.Cells[xIni, yIni + 3] = "Inv. Final";
                    xlWorksheet.Cells[xIni, yIni + 4] = "Utilizado";
                    xlWorksheet.Cells[xIni, yIni + 5] = "Vendido";
                    xlWorksheet.Cells[xIni, yIni + 6] = "Diferencia";
                    xlWorksheet.Cells[xIni, yIni + 7] = "Costo Unitario";
                    xlWorksheet.Cells[xIni, yIni + 8] = "Costo Mermas";
                    xIni++;
                    foreach (Inventario item in lstMasas)
                    {
                        xlWorksheet.Cells[xIni, yIni] = item.Producto;
                        xlWorksheet.Cells[xIni, yIni + 1] = item.Beginning_Qty;
                        xlWorksheet.Cells[xIni, yIni + 2] = item.Delivered_Qty;
                        xlWorksheet.Cells[xIni, yIni + 3] = item.Ending_Qty;
                        xlWorksheet.Cells[xIni, yIni + 4] = item.Actual_Usage;
                        xlWorksheet.Cells[xIni, yIni + 5] = item.Ideal_Usage;
                        xlWorksheet.Cells[xIni, yIni + 6] = item.Actual_Usage - item.Ideal_Usage;
                        xlWorksheet.Cells[xIni, yIni + 7] = item.PrecioUnitario;
                        xlWorksheet.Cells[xIni, yIni + 8] = (item.Actual_Usage - item.Ideal_Usage) * item.PrecioUnitario;
                        xIni++;
                    }
                    foreach (Inventario item in lstRefrescos)
                    {
                        xlWorksheet.Cells[xIni, yIni] = item.Code;
                        xlWorksheet.Cells[xIni, yIni + 1] = item.Beginning_Qty;
                        xlWorksheet.Cells[xIni, yIni + 2] = item.Delivered_Qty;
                        xlWorksheet.Cells[xIni, yIni + 3] = item.Ending_Qty;
                        xlWorksheet.Cells[xIni, yIni + 4] = item.Actual_Usage;
                        xlWorksheet.Cells[xIni, yIni + 5] = item.Ideal_Usage;
                        xlWorksheet.Cells[xIni, yIni + 6] = item.Actual_Usage - item.Ideal_Usage;
                        xlWorksheet.Cells[xIni, yIni + 7] = item.PrecioUnitario;
                        xlWorksheet.Cells[xIni, yIni + 8] = (item.Actual_Usage - item.Ideal_Usage) * item.PrecioUnitario;
                        xIni++;
                    }

                    BorderAround(xlWorksheet.Range["A" + (xIni - 2 - lstRefrescos.Count - lstMasas.Count).ToString(), "I" + (xIni - 1).ToString()], 1);

                    #endregion
                }

                
                    #region CUPONES
                    // cupones


                    yIni = 1;

                    IList<Pizzas> lstCupones = objPizzasBLL.SelectCupones(objFinder);


                    Excel.Range headCupones = xlWorksheet.Range["A" + xIni.ToString(), "F" + xIni.ToString()];
                    headCupones.Merge();
                    headCupones.Value = "CUPONES POR PARTICIPACION";

                    xIni++;
                    xlWorksheet.Cells[xIni, yIni] = "Cupon";
                    xlWorksheet.Cells[xIni, yIni + 1] = "Participacion";
                    xIni++;

                    foreach (Pizzas item in lstCupones)
                    {
                        xlWorksheet.Cells[xIni, yIni] = item.Code+"  "+ item.Descripcion;
                        xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                        xlWorksheet.Cells[xIni, yIni + 2] = (double)item.Cantidad / lstResultVentas[0].OrdenesTotales;
                        xIni++;
                    }
                    Excel.Range porcentajesCupones = xlWorksheet.Range["C" + (xIni - lstCupones.Count).ToString(), "C" + xIni.ToString()];
                    porcentajesCupones.NumberFormat = "###,##0.00%";

                    xIni -= (lstCupones.Count + 1);
                    yIni += 3;

                    IList<Pizzas> lstCupones2 = objPizzasBLL.SelectCupones2(objFinder);
                    xlWorksheet.Cells[xIni, yIni] = "Cupon";
                    xlWorksheet.Cells[xIni, yIni + 1] = "Participacion";
                    xIni++;

                    foreach (Pizzas item in lstCupones2)
                    {
                        xlWorksheet.Cells[xIni, yIni] = item.Code;
                        xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                        xlWorksheet.Cells[xIni, yIni + 2] = (double)item.Cantidad / lstResultVentas[0].OrdenesTotales;
                        xIni++;
                    }
                    BorderAround(xlWorksheet.Range["A" + (xIni - 2 - lstCupones2.Count).ToString(), "F" + (xIni - lstCupones2.Count + lstCupones.Count).ToString()], 1);
                    Excel.Range porcentajesCupones2 = xlWorksheet.Range["F" + (xIni - lstCupones2.Count).ToString(), "F" + xIni.ToString()];
                    porcentajesCupones2.NumberFormat = "###,##0.00%";

                    #endregion
                
                #region  KPI`S CLAVE

                

                xIni = 6;
                yIni = 7;
                Excel.Range headClave = xlWorksheet.Range["G" + xIni.ToString(), "I" + (xIni + 1).ToString()];
                headClave.Merge();
                headClave.Value = "KPI`S CLAVE";
                headClave.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headClave.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                

                xIni += 2;
                Excel.Range VentasReales = xlWorksheet.Range["G" + xIni.ToString(), "H" + (xIni + 1).ToString()];
                VentasReales.Merge();
                VentasReales.Value = "VENTAS REALES";
                VentasReales.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                VentasReales.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                Excel.Range rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + (xIni + 1).ToString()];
                rngValues.Merge();
                rngValues.Value =  objFinder.IndicadorFull?lstResultVentas[0].VentasRealesTotal:0;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = "$ #,##0.00";



                xIni += 3;
                Excel.Range CostoComida = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                CostoComida.Merge();
                CostoComida.Value = "COSTO COMIDA";
                CostoComida.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = ((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / lstResultVentas[0].VentasRealesTotal;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni++;
                Excel.Range gratis = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                gratis.Merge();
                gratis.Value = "GRATIS";
                gratis.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = lstOrdenesGratis[0].TotalGratis / lstResultVentas[0].VentasRealesTotal;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni++;


                Excel.Range badOrders = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                badOrders.Merge();
                badOrders.Value = "MALAS ORDENES/CANCEL";
                badOrders.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = (lstResultVentas[0].CanceladasTotal / lstResultVentas[0].VentasBrutasTotal) + ((lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis) / lstResultVentas[0].VentasRealesTotal);
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni++;
                Excel.Range ticket = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                ticket.Merge();
                ticket.Value = "TICKET PROMEDIO";
                ticket.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = objFinder.IndicadorFull?lstResultVentas[0].VentasRealesTotal / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount):0;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = "$ #,##0.00";
                xIni++;
                Excel.Range ordenesTotal = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                ordenesTotal.Merge();
                ordenesTotal.Value = "ORDENES TOTALES ";
                ordenesTotal.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = lstResultVentas[0].OrdenesTotales;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                xIni++;

                Excel.Range ADICIONALES = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                ADICIONALES.Merge();
                ADICIONALES.Value = "PART. DE ADICIONALES";
                ADICIONALES.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = (Double)totalComplementos / lstResultVentas[0].OrdenesTotales;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni+=2;


                //20170927 - Modified by Hector Sanchez M. - Se estaba haciendo los calculos con el total de ordenes, el calculo se tienen que hacer con el total de las ventas.
                Excel.Range distributionOrder = xlWorksheet.Range["G" + xIni.ToString(), "I" + xIni.ToString()];
                distributionOrder.Merge();
                distributionOrder.Value = "DISTRIBUCION ORDENES";
                distributionOrder.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xIni++;
                Excel.Range distributionOrder1 = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                distributionOrder1.Merge();
                distributionOrder1.Value = "RESTAURANTE";
                distributionOrder1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = lstResultVentas[0].VentasRestauranteTotal / lstResultVentas[0].VentasNetasTotal;//(Double) lstResultVentas[0].OrdenesTotalesRestaurante / lstResultVentas[0].OrdenesTotales;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni++;
                Excel.Range distributionOrder2 = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                distributionOrder2.Merge();
                distributionOrder2.Value = "CARRY OUT";
                distributionOrder2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni .ToString()];
                rngValues.Merge();
                rngValues.Value = lstResultVentas[0].VentasMostradorTotal / lstResultVentas[0].VentasNetasTotal;//(Double)lstResultVentas[0].OrdenesTotalesMostrador / lstResultVentas[0].OrdenesTotales; ;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                xIni++;
                Excel.Range distributionOrder3 = xlWorksheet.Range["G" + xIni.ToString(), "H" + xIni.ToString()];
                distributionOrder3.Merge();
                distributionOrder3.Value = "DELIVERY";
                distributionOrder3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rngValues = xlWorksheet.Range["I" + xIni.ToString(), "I" + xIni.ToString()];
                rngValues.Merge();
                rngValues.Value = lstResultVentas[0].VentasRepartoTotal / lstResultVentas[0].VentasNetasTotal;//(Double)lstResultVentas[0].OrdenesTotalReparto / lstResultVentas[0].OrdenesTotales;
                rngValues.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rngValues.NumberFormat = " ###,##0.00%";
                BorderAround(xlWorksheet.Range["G6", "I21"], 1);
                rangeVentasPer = xlWorksheet.Range["G7", "I21"];
                rangeVentasPer.Font.Size = 12;
                rangeVentasPer.Font.Bold = true;


                #endregion

                if (!general)
                {
                    #region INFORMACION OPERATIVA
                    xIni=22;
                    yIni = 7;
                    IList<InformacionOperativa> lstTiempoPromedio = objInformacionOperativaBLL.SelectTiemposPromedio(objFinder);
                    if (lstTiempoPromedio.Count > 0)
                    {
                        Excel.Range headInfoOperativa = xlWorksheet.Range["G" + xIni.ToString(), "I" + xIni.ToString()];
                        headInfoOperativa.Merge();
                        headInfoOperativa.Value = "INFORMACION OPERATIVA";
                        xIni++;
                        xlWorksheet.Cells[xIni, yIni] = "TIEMPO PROMEDIO";
                        xlWorksheet.Cells[xIni, yIni + 1] = "LOGRADO";
                        xlWorksheet.Cells[xIni, yIni + 2] = "META";
                        xIni++;
                        int tSegundos, min, seg;

                        xlWorksheet.Cells[xIni, yIni] = "Toma de Ordenes";
                        tSegundos = (int)(lstTiempoPromedio[0].TomaOrden);
                        //min = tSegundos / 60;
                        //seg = tSegundos - (min * 60);
                        xlWorksheet.Cells[xIni, yIni + 1] = ToolsTime.ConvertSecondsToHMS(tSegundos);//min.ToString() + ":" + seg.ToString();
                        xlWorksheet.Cells[xIni, yIni + 2] = " 1 MIN";
                        xIni++;

                        xlWorksheet.Cells[xIni, yIni] = "Produccion";
                        tSegundos = (int)(lstTiempoPromedio[0].Produccion);
                        //min = tSegundos / 60;
                        //seg = tSegundos - (min * 60);
                        xlWorksheet.Cells[xIni, yIni + 1] = ToolsTime.ConvertSecondsToHMS(tSegundos);//min.ToString() + ":" + seg.ToString();
                        xlWorksheet.Cells[xIni, yIni + 2] = " 3 MIN";
                        xIni++;

                        xlWorksheet.Cells[xIni, yIni] = "Repisa";
                        tSegundos = (int)(lstTiempoPromedio[0].Repisa);
                        //min = tSegundos / 60;
                        //seg = tSegundos - (min * 60);
                        xlWorksheet.Cells[xIni, yIni + 1] = ToolsTime.ConvertSecondsToHMS(tSegundos);//min.ToString() + ":" + seg.ToString();
                        xlWorksheet.Cells[xIni, yIni + 2] = " 2 MIN";
                        xIni++;

                        xlWorksheet.Cells[xIni, yIni] = "Fuera de Tienda";
                        tSegundos = (int)(lstTiempoPromedio[0].FueraTienda);
                        //min = tSegundos / 60;
                        //seg = tSegundos - (min * 60);
                        xlWorksheet.Cells[xIni, yIni + 1] = ToolsTime.ConvertSecondsToHMS(tSegundos);//min.ToString() + ":" + seg.ToString();
                        xlWorksheet.Cells[xIni, yIni + 2] = " 15 MIN";
                        xIni++;

                        xlWorksheet.Cells[xIni, yIni] = "Estimado de Entrega";
                        tSegundos = (int)(lstTiempoPromedio[0].Entrega);
                        //min = tSegundos / 60;
                        //seg = tSegundos - (min * 60);
                        xlWorksheet.Cells[xIni, yIni + 1] = ToolsTime.ConvertSecondsToHMS(tSegundos);//min.ToString() + ":" + seg.ToString();
                        xlWorksheet.Cells[xIni, yIni + 2] = " 20 MIN";
                        xIni++;

                        BorderAround(xlWorksheet.Range["G" + (xIni - 7).ToString(), "I" + xIni.ToString()], 1);

                    }
                    #endregion
                }
            }
            releaseObject(xlWorksheet);
           

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                
            }
            finally
            {
                GC.Collect();
            }
        }
        private void BorderAround(Excel.Range range, int colour)
        {
            Excel.Borders borders = range.Borders;
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Color = colour;
            borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders = null;
           
            for (int i = 1; i <= range.Columns.Count; i++)
            {
                Excel.Range rng = range.Cells[1, i];
                rng.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                rng.Font.Bold = true;
                rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
                rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Excel.Range rng2 = range.Cells[2, i];
                rng2.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                rng2.Font.Bold = true;
                rng2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
                rng2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
             
        }

        public String GenerateFormatMaster(VentasFinder objVentasFinder,HttpServerUtility Server)
        {
            Excel.Application xlApp = new Excel.Application();

            //BLL's
            VentasBLL objVentasBLL = new VentasBLL();
            PizzasBLL objPizzasBLL = new PizzasBLL();
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            ResumenDiarioBLL objResumenDiarioBLL = new ResumenDiarioBLL();
            InformacionOperativaBLL objInformacionOperativaBLL = new InformacionOperativaBLL();

            IList<TotalSales> lstResultVentas = objVentasBLL.TotalSalesbyStore(objVentasFinder);
            IList<TotalSales> lstOrdenesGratis = objVentasBLL.SelectTotalGratis(objVentasFinder);
            IList<Pizzas> lstResultPizzas = objPizzasBLL.SelectPizzasbyShop(objVentasFinder);
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                TiendaBLL objTiendaBLL = new TiendaBLL();
                Tienda objFinder = new Tienda()
                {
                    Ubicacion = objVentasFinder.UbicacionTienda,
                    Tipo = objVentasFinder.TipoTienda,
                    Number_tienda = objVentasFinder.NumTienda
                };

                IList<Tienda> objTiendas = objTiendaBLL.SelectTiendas(objFinder);
                foreach (Tienda item in objTiendas)
                {
                    GenerateContentWorkSheetMaster((Excel.Worksheet)xlWorkBook.Worksheets.Add(), objVentasFinder, item);
                }

                if (objTiendas.Count > 1)
                {
                    Tienda objTienda = new Tienda();
                    objTienda.Number_tienda = String.Empty;
                    GenerateContentWorkSheetMaster((Excel.Worksheet)xlWorkBook.Worksheets.Add(), objVentasFinder, objTienda);
                }

               

                DateTime dateAux = DateTime.Now;
                string nombreArchivo = "IndicadorMaestro.xlsx";
                if (File.Exists(Server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(Server.MapPath("/indicadores") + "/" + nombreArchivo);
                }
                xlWorkBook.SaveAs(Server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                return nombreArchivo;

            }
            return string.Empty;
        }
        public void GenerateContentWorkSheetMaster(Excel.Worksheet xlWorksheet, VentasFinder objFinder, Tienda objTienda)
        {
            // BLL's
            VentasBLL objVentasBLL = new VentasBLL();
            PizzasBLL objPizzasBLL = new PizzasBLL();
            EntradaSalidaBLL objEntredaSalidaBLL = new EntradaSalidaBLL();
            InventarioBLL objInventarioBLL = new InventarioBLL();
            ResumenDiarioBLL objResumenDiarioBLL = new ResumenDiarioBLL();
            InformacionOperativaBLL objInformacionOperativaBLL = new InformacionOperativaBLL();

            objFinder.NumTienda = objTienda.Number_tienda;
            IList<TotalSales> lstResultVentas = objVentasBLL.TotalSalesbyStore(objFinder);
            IList<TotalSales> lstOrdenesGratis = objVentasBLL.SelectTotalGratis(objFinder);
            IList<Pizzas> lstResultPizzas = objPizzasBLL.SelectPizzasbyShop(objFinder);
            IList<SalesLastYear> lstSalesLastyear = objVentasBLL.SelectSalesLastYearSecond(objFinder);
            IList<OrderbyTime> lstOrderbyTime = objInformacionOperativaBLL.SelectOrderbyTime(objFinder);

            xlWorksheet.Name = !string.IsNullOrEmpty(objTienda.Number_tienda) ? objTienda.Number_tienda : "Franquicias"; ;
            int xIni = 0, yIni = 0;
            #region HEAD
            xlWorksheet.Cells[2, 1] = " FRANQUICIA";
            xlWorksheet.Cells[4, 1] = " GERENTE";
            xlWorksheet.Cells[6, 1] = " FECHA INICIAL";
            xlWorksheet.Cells[6, 4] = " FECHA FINAL";
            xlWorksheet.Cells[2, 7] = " # TIENDA";
            xlWorksheet.Cells[4, 7] = " SEMANA";
          
            Excel.Range contentHeader = xlWorksheet.Range["B2", "E2"];
            contentHeader.Merge();
            contentHeader.Value = "ORGANIZACION DOT";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader=xlWorksheet.Range["B4", "E4"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = objTienda.Gerente.ToUpper().ToString();
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["B6", "B6"];
            contentHeader.Merge();
            contentHeader.ColumnWidth = 30;
            contentHeader.WrapText = true;
            contentHeader.Value = objFinder.DateIni.Value.ToString("dd DE MMMM DE yyyy", CultureInfo.CreateSpecificCulture("es-MX")).ToUpper();
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["E6", "E6"];
            contentHeader.Merge();
            contentHeader.ColumnWidth = 30;
            contentHeader.WrapText = true;
            contentHeader.Value = objFinder.DateEnd.Value.ToString("dd DE MMMM DE yyyy", CultureInfo.CreateSpecificCulture("es-MX")).ToUpper();
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["H2", "H2"];
            contentHeader.Merge();
            contentHeader.ColumnWidth = 10;
            contentHeader.WrapText = true;
            contentHeader.Value = objTienda.Number_tienda;
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["H4", "H4"];
            contentHeader.Merge();
            contentHeader.ColumnWidth = 10;
            contentHeader.WrapText = true;
            contentHeader.Value = objFinder.NumeroSemana;
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["A1", "A1"];
            contentHeader.Merge();
            contentHeader.ColumnWidth = 35;

            #endregion

            #region VENTAS SEMANALES

            contentHeader = xlWorksheet.Range["A8", "C8"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = "VENTAS SEMANALES";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            IList<EntradasSalidas> lstEntradaSalidas = objEntredaSalidaBLL.SelectFacturas(objFinder);
            IList<Inventario> lstInventariosINI_END = objInventarioBLL.SelectInventarioInicialFinal(objFinder);
            IList<EntradasSalidas> lstTotalFacturas = objEntredaSalidaBLL.SelectTotalFacturas(objFinder);
            xlWorksheet.Cells[9, 1] = "TOTAL MAESTRO";
            xlWorksheet.Cells[10, 1] = "MALAS ORDENES";
            xlWorksheet.Cells[11, 1] = "VENTAS TOTALES";
            xlWorksheet.Cells[12, 1] = "CUPONES";
            xlWorksheet.Cells[13, 1] = "GRATIS";
            xlWorksheet.Cells[14, 1] = "IVA";
            xlWorksheet.Cells[15, 1] = "VENTAS REALES";
            xlWorksheet.Cells[16, 1] = "AÑO ANTERIOR";
            xlWorksheet.Cells[17, 1] = "VENTAS DE REPARTO"; 
            xlWorksheet.Cells[18, 1] = "COSTO DE COMIDA IDEAL";
            xlWorksheet.Cells[19, 1] = "COSTO DE COMIDA REAL";

            xlWorksheet.Cells[9, 2] = (double)lstResultVentas[0].VentasBrutasTotal;
            xlWorksheet.Cells[10, 2] = (double)(lstResultVentas[0].OrdenesMalasTotal - lstOrdenesGratis[0].TotalGratis + lstResultVentas[0].CanceladasTotal);
            xlWorksheet.Cells[11, 2] = (double)lstResultVentas[0].VentasNetasTotal;
            xlWorksheet.Cells[12, 2] = 0;
            xlWorksheet.Cells[13, 2] = (double)lstOrdenesGratis[0].TotalGratis;
            xlWorksheet.Cells[14, 2] = (double)lstResultVentas[0].IVATotal;
            xlWorksheet.Cells[15, 2] = (double)lstResultVentas[0].VentasRealesTotal;
            xlWorksheet.Cells[16, 2] = (double)lstSalesLastyear[0].VentasReales;
            xlWorksheet.Cells[17, 2] = (double)lstResultVentas[0].VentasRepartoTotal - (((double)lstResultVentas[0].VentasRepartoTotal / 1.16) * 0.16);
            xlWorksheet.Cells[18, 2] = (double)(lstResultVentas[0].Utilizado / lstResultVentas[0].VentasRealesTotal);
            xlWorksheet.Cells[19, 2] = ((lstTotalFacturas[0].TotalFactura + (lstInventariosINI_END[0].Inventario_Inicial == 0 ? lstInventariosINI_END[1].Inventario_Inicial : lstInventariosINI_END[0].Inventario_Inicial)) - (lstInventariosINI_END[1].Inventario_Final == 0 ? lstInventariosINI_END[0].Inventario_Final : lstInventariosINI_END[1].Inventario_Final)) / lstResultVentas[0].VentasRealesTotal;

            xlWorksheet.Cells[16, 3] = (double)((Double)lstResultVentas[0].VentasRealesTotal/(double)lstSalesLastyear[0].VentasReales)-1;



            contentHeader = xlWorksheet.Range["A20", "B20"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = "PIZZA";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            IList<Pizzas> lstPizzas = objPizzasBLL.SelectPizzasMaestro(objFinder);
            xIni = 21;
            yIni = 1;
            int totalpizza = 0;
            foreach(Pizzas item in lstPizzas)
            {
                xlWorksheet.Cells[xIni, yIni] = item.Descripcion.ToUpper();
                xlWorksheet.Cells[xIni, yIni+1] = item.Cantidad;
                totalpizza += item.Cantidad;
                
                xIni++;
            }
            xlWorksheet.Cells[xIni, yIni] = "PIZZAS TOTALES";
            xlWorksheet.Cells[xIni, yIni + 1] = totalpizza;
            xIni = 21;
            foreach (Pizzas item in lstPizzas)
            {
                xlWorksheet.Cells[xIni, yIni + 2] = (Double)item.Cantidad / totalpizza;
                xIni++;
            }


            contentHeader = xlWorksheet.Range["C20", "C20"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = " % ";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["A37", "C37"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = "INFORMACIÓN OPERATIVA";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            IList<InformacionOperativa> lstTiempoPromedio = objInformacionOperativaBLL.SelectTiemposPromedio(objFinder);
            int tSegundos, min, seg;

            xlWorksheet.Cells[38, 1] = "TIEMPO DE SERVICIO";
            xlWorksheet.Cells[39, 1] = "% OTD < 15 MIN.";
            xlWorksheet.Cells[40, 1] = "% ESTIMADO DE ENTREGA < 30 MIN";
            xlWorksheet.Cells[41, 1] = "LOAD TIME ENTRADA AL HORNO";
            xlWorksheet.Cells[42, 1] = "ESTIMADO DE ENTREGA";

            
            xlWorksheet.Cells[38, 2] = "LOGRADO";
            xlWorksheet.Cells[39, 2] = (Double)(lstOrderbyTime[0].Ord_Total > 0 ? (Double)((Double)lstOrderbyTime[0].Ord_Less_15 / (Double)lstOrderbyTime[0].Ord_Total) : 0.0);
            xlWorksheet.Cells[40, 2] = (Double)(lstOrderbyTime[0].Ord_Total > 0 ? (Double)((Double)lstOrderbyTime[0].Ord_Less_30 / (Double)lstOrderbyTime[0].Ord_Total) : 0.0);
            tSegundos = (int)(lstTiempoPromedio[0].Produccion * 60);
            min = tSegundos / 60;
            seg = tSegundos - (min * 60);
            xlWorksheet.Cells[41, 2] = min.ToString() + ":" + seg.ToString();
            tSegundos = (int)(lstTiempoPromedio[0].Entrega * 60);
            min = tSegundos / 60;
            seg = tSegundos - (min * 60);
            xlWorksheet.Cells[42, 2] = min.ToString() + ":" + seg.ToString();

            xlWorksheet.Cells[38, 3] = "META";
            xlWorksheet.Cells[39, 3] = (Double)0.75;
            xlWorksheet.Cells[40, 3] = (Double)0.90;
            xlWorksheet.Cells[41, 3] = "02:30 MIN";
            xlWorksheet.Cells[42, 3] = "18:00 MIN";

            contentHeader = xlWorksheet.Range["E8", "G8"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = "ORDENES";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            xlWorksheet.Cells[9, 5] = "ORDENES TOTALES";
            xlWorksheet.Cells[10, 5] = "TICKET PROMEDIO";
            xlWorksheet.Cells[11, 5] = "ORDENES MOSTRADOR";
            xlWorksheet.Cells[12, 5] = "ORDENES REPARTO";
            xlWorksheet.Cells[13, 5] = "ORDENES AÑO ANTERIOR";

            xlWorksheet.Cells[9, 6] = lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount;
            xlWorksheet.Cells[10, 6] = lstResultVentas[0].VentasRealesTotal / (lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount);
            xlWorksheet.Cells[11, 6] = lstResultVentas[0].OrdenesTotalesMostrador;
            xlWorksheet.Cells[12, 6] = lstResultVentas[0].OrdenesTotalReparto;
            xlWorksheet.Cells[13, 6] = lstSalesLastyear[0].Ordenes;

            xlWorksheet.Cells[11, 8] = (Double)lstResultVentas[0].OrdenesTotalesMostrador / lstResultVentas[0].OrdenesTotales;
            xlWorksheet.Cells[12, 8] = (Double)lstResultVentas[0].OrdenesTotalReparto / lstResultVentas[0].OrdenesTotales;
            xlWorksheet.Cells[13, 8] = (Double)(((Double)(lstResultVentas[0].OrdenesTotales - lstResultVentas[0].OrdenesMalasCount) / (Double)lstSalesLastyear[0].Ordenes) - 1);
           

            contentHeader = xlWorksheet.Range["H8", "H8"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = " % ";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            contentHeader = xlWorksheet.Range["E14", "G14"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = "OTROS PRODUCTOS";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            IList<Pizzas> lstComplementos = objPizzasBLL.SelectComplementos(objFinder);
            xIni = 15;
            yIni = 5;
            int totalRefrescos = 0;
            int totalcomplementos = 0;
            foreach (Pizzas item in lstComplementos)
            {
                if (!item.Producto.Contains("REFRESCO") && !item.Producto.Contains("AGUA"))
                {
                    xlWorksheet.Cells[xIni, yIni] = item.Producto;
                    xlWorksheet.Cells[xIni, yIni + 1] = item.Cantidad;
                    xIni++;            
                }
                else
                {
                    totalRefrescos += item.Cantidad;

                }
                totalcomplementos+=item.Cantidad;
            }
            
            
            xlWorksheet.Cells[xIni, yIni] = "REFRESCOS";
            xlWorksheet.Cells[xIni, yIni + 1] = totalRefrescos;
            xlWorksheet.Cells[xIni, yIni + 3] = (Double)totalRefrescos / totalcomplementos;
            xIni++;
            xlWorksheet.Cells[xIni, yIni] = "Totales";
            xlWorksheet.Cells[xIni, yIni + 1] =totalcomplementos;
            xIni = 15;
            foreach (Pizzas item in lstComplementos)
            {
                if (!item.Producto.Contains("REFRESCO") && !item.Producto.Contains("AGUA"))
                {
                    xlWorksheet.Cells[xIni, yIni + 3] = (Double)item.Cantidad / totalcomplementos;
                    xIni++;
                }
            }

            contentHeader = xlWorksheet.Range["H14", "H14"];
            contentHeader.Merge();
            contentHeader.WrapText = true;
            contentHeader.Value = " % ";
            contentHeader.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
            contentHeader.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            contentHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range format = xlWorksheet.Range["B9","B17"];
            format.NumberFormat = "$ #,##0.00";

            format = xlWorksheet.Range["F10", "B10"];
            format.NumberFormat = "$ #,##0.00";

            format = xlWorksheet.Range["C21", "C35"];
            format.NumberFormat = "###,##0.00%";

            format = xlWorksheet.Range["H11", "H13"];
            format.NumberFormat = "###,##0.00%";
            format = xlWorksheet.Range["H15", "H21"];
            format.NumberFormat = "###,##0.00%";
            format = xlWorksheet.Range["B39", "C40"];
            format.NumberFormat = "###,##0.00%";
            format = xlWorksheet.Range["B18", "B19"];
            format.NumberFormat = "###,##0.00%";

            format = xlWorksheet.Range["C16", "C16"];
            format.NumberFormat = "###,##0.00%";
            #endregion
        }
    }
}