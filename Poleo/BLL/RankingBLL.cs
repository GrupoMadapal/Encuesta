using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace Poleo.BLL
{
    public class RankingBLL
    {
        public IList<Ranking> SelectDataRanking(RankingFinder objRankingfinder)
        {
            RankingDAL objRankingDAL = new RankingDAL();
            return objRankingDAL.SelectDataRanking(objRankingfinder);
        }
        public IList<Ranking> SelectDataRankingPorTienda(RankingFinder objRankingfinder)
        {
            RankingDAL objRankingDAL = new RankingDAL();
            return objRankingDAL.SelectDataRankingPorTienda(objRankingfinder);
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
        public String generateReportRanking(RankingFinder objRankingFinder,HttpServerUtility server)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    IList<Ranking> lstRankings = this.SelectDataRanking(objRankingFinder);
                    if (lstRankings.Count > 0)
                    {
                        this.CreateSheetHome(xlWorkBook.Worksheets.Add(), objRankingFinder, lstRankings);
                    }
                    this.createRankingHistorico(xlWorkBook, objRankingFinder);
                    nombreArchivo = "Ranking.xlsx";
                    if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                    {
                        File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                    }
                    xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;
        }
        public void CreateSheetHome(Excel.Worksheet xlWorksheet, RankingFinder objRankingfinder, IList<Ranking> lstRankings)
        {
            int coorX=0, coorY=0,numTiendas=0;
            encabezadoRanking(xlWorksheet, objRankingfinder,new Tienda(), false, false);
            IList<Ranking> lstRankingNoExpress=SeparaTiendasPorTipo(lstRankings,false);
            numTiendas = lstRankingNoExpress.Count;
            coorX=1;
            coorY=9;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListVentas(lstRankingNoExpress),"VENTAS AP 9%",xlWorksheet,2);

            coorX=1;
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListOrdenes(lstRankingNoExpress),"ORDENES 9%",xlWorksheet,3);
            coorX+=numTiendas+2;
            coorY=1;
            lstRankingNoExpress=createTabla(coorX,coorY,this.sortListCostoComida(lstRankingNoExpress),"COSTO DE COMIDA 40%",xlWorksheet,4);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListTicketPromedio(lstRankingNoExpress),"TICKET PROM $160.00",xlWorksheet,5);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListGratis(lstRankingNoExpress),"GRATIS 0.50%",xlWorksheet,6);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListParticipacionAdicionales(lstRankingNoExpress),"PART ADICIONALES",xlWorksheet,7);

            coorY=1;
            coorX+=numTiendas+2;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListentradaHorno(lstRankingNoExpress),"ENTRADA HORNO 3 MIN",xlWorksheet,8);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListEntrega(lstRankingNoExpress),"ENTREGA EN MENOS DE 30 MIN 85%",xlWorksheet,9);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListSalidaTienda(lstRankingNoExpress),"SALIDA DE TIENDA 55%",xlWorksheet,10);
            coorY+=4;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListOrdenesMalas(lstRankingNoExpress),"MALAS ORD Y CANCELADAS",xlWorksheet,11);
            coorX=1;
            coorY=1;
            lstRankingNoExpress=createTabla(coorX,coorY,this.SortListPuntos(lstRankingNoExpress),"RANKING SEMANAL",xlWorksheet,1);
            AnchoColumnas(xlWorksheet);

            IList<Ranking> lstRankingExpress = SeparaTiendasPorTipo(lstRankings, true);
            int posX = (numTiendas * 3) + 9;
            coorX =(numTiendas*3)+9 ;
            coorY = 9;
            numTiendas = lstRankingExpress.Count;

            lstRankingExpress = createTabla(coorX, coorY, this.SortListVentas(lstRankingExpress), "VENTAS AP ", xlWorksheet, 2);

            
            coorY+=4;
            lstRankingExpress = createTabla(coorX, coorY, this.SortListOrdenes(lstRankingExpress), "ORDENES ", xlWorksheet, 3);

            coorX = posX+numTiendas+2;
            coorY = 1;
            lstRankingExpress = createTabla(coorX, coorY, this.sortListCostoComida(lstRankingExpress), "COSTO DE COMIDA 38.5%", xlWorksheet, 4);
            coorY += 4;
            lstRankingExpress = createTabla(coorX, coorY, this.SortListentradaHorno(lstRankingExpress), "ENTRADA HORNO 3 MIN", xlWorksheet, 8);
            coorY += 4; 
            lstRankingExpress = createTabla(coorX, coorY, this.SortListParticipacionAdicionales(lstRankingExpress), "PART ADICIONALES 100%", xlWorksheet, 7);
            coorY += 4;
            lstRankingExpress = createTabla(coorX, coorY, this.SortListTicketPromedio(lstRankingExpress), "TICKET PROM $100.00", xlWorksheet, 5);
            coorX = posX;
            coorY = 1;
            lstRankingExpress = createTabla(coorX, coorY, this.SortListPuntos(lstRankingExpress), "RANKING SEMANAL", xlWorksheet, 1);
            

        }
        public IList<Ranking> createTabla( int coorX, int coorY, IList<Ranking> lstRankings,String strEncabezado, Excel.Worksheet xlWorksheet,int tipoTabla, bool ishistorico =false )
        {
          
            Excel.Range tabla = xlWorksheet.Range[xlWorksheet.Cells[coorX, coorY],xlWorksheet.Cells[coorX, coorY+2]];
            Excel.Range tabla2 = xlWorksheet.Range[xlWorksheet.Cells[coorX, coorY], xlWorksheet.Cells[coorX+lstRankings.Count, coorY + 2]];
            Excel.Range values = xlWorksheet.Range[xlWorksheet.Cells[coorX+1, coorY+2], xlWorksheet.Cells[coorX + lstRankings.Count, coorY + 2]];
            
            tabla.Merge();
            tabla.Value = strEncabezado;
            coorX++;
            int pos=0;
            Decimal auxVal = -1;
            Decimal valReal=-1;
            foreach(Ranking item in lstRankings)
            {
                if (ishistorico)
                { xlWorksheet.Cells[coorX, coorY + 1] = "SEMANA " + item.NumSemana; }
                else
                {
                    xlWorksheet.Cells[coorX, coorY + 1] = item.Nombre_tienda;
                }
                
                switch(tipoTabla)
                {
                    case 1:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.Puntos;
                        valReal=(Decimal)item.Puntos;
                        break;
                    case 2:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.VentasProcentaje;
                        valReal=(Decimal)item.VentasProcentaje;
                        break;
                    case 3:
                        xlWorksheet.Cells[coorX, coorY + 2] =item.OrdenesPorcentaje;
                        valReal=(Decimal)item.OrdenesPorcentaje;;
                        break;
                    case 4:
                        xlWorksheet.Cells[coorX, coorY + 2] =item.UtilizadoPor;
                        valReal=(Decimal)item.UtilizadoPor;
                        break;
                    case 5:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.TicketPromedio;
                        valReal=(Decimal)item.TicketPromedio;
                        break;
                    case 6:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.Gratis;
                        valReal=(Decimal)item.Gratis;
                        break;
                    case 7:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.ParticipacionAdicionales;
                        valReal=(Decimal)item.ParticipacionAdicionales;
                        break;
                    case 8:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.EntradaHorno;
                        valReal=(Decimal)item.TiempoEntrada;
                        break;
                    case 9:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.Entrega;
                        valReal=(Decimal)item.Entrega;
                        break;
                    case 10:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.SalidaTienda;
                        valReal=(Decimal)item.SalidaTienda;
                        break;
                    case 11:
                        xlWorksheet.Cells[coorX, coorY + 2] = item.OrdenesMalas;                        
                        valReal=(Decimal)item.OrdenesMalas;
                        break;
                }
                
               
                if (auxVal != valReal)
                {
                    pos++;
                    auxVal = valReal;
                }
                xlWorksheet.Cells[coorX, coorY] = pos;
                if (tipoTabla != 1)
                {
                    item.Puntos += pos;
                }
                coorX++;

            }
            if(tipoTabla==1||tipoTabla==8)
            {
                FormatoTabla(tabla2, lstRankings.Count + 1, tabla, values,0);
            }
            else if(tipoTabla==5)
            {
                FormatoTabla(tabla2, lstRankings.Count + 1, tabla, values,2);
            }
            else
            {
                FormatoTabla(tabla2, lstRankings.Count + 1, tabla, values,1);
            }
            
            return lstRankings;
        }
        public IList<Ranking> sortListCostoComida(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderBy(order => order.UtilizadoPor).ToList();
        }
        public IList<Ranking> SortListVentas(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.VentasProcentaje).ToList();
        }
        public IList<Ranking> SortListOrdenes(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.OrdenesPorcentaje).ToList();
        }
        public IList<Ranking> SortListTicketPromedio(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.TicketPromedio).ToList();
        }   
        public IList<Ranking> SortListGratis(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderBy(order => order.Gratis).ToList();
        }
        public IList<Ranking> SortListParticipacionAdicionales(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.ParticipacionAdicionales).ToList();
        }
        public IList<Ranking> SortListentradaHorno(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderBy(order => order.TiempoEntrada).ToList();
        }
        public IList<Ranking> SortListEntrega(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.Entrega).ToList();
        }
        public IList<Ranking> SortListSalidaTienda(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderByDescending(order => order.SalidaTienda).ToList();
        }
        public IList<Ranking> SortListOrdenesMalas(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderBy(order => order.OrdenesMalas).ToList();
        }
        public IList<Ranking> SortListPuntos(IList<Ranking> lstRankigs)
        {
            return lstRankigs.OrderBy(order => order.Puntos).ToList();
        }
        public IList<Ranking> SeparaTiendasPorTipo(IList<Ranking>lstRankings, Boolean isExpress )
        {
            IList<Ranking> lstTiendasExtress= new List<Ranking>();
            IList<Ranking> lstTiendas = new List<Ranking>();
            foreach(Ranking item in lstRankings)
            {
               if(item.TipoTienda=="Express")
               {
                   lstTiendasExtress.Add(item);
               }
               else
               {
                   lstTiendas.Add(item);
               }
            }
            if(isExpress)
            {
                return lstTiendasExtress;
            }else{
                return lstTiendas;
            }

        }
        public void AddPointsOfStrore(IList<Ranking> lstRanking,String strTienda, int puntos)
        {
            foreach(Ranking item in lstRanking)
            {
                if(item.Tienda==strTienda)
                {
                    item.Puntos+=puntos;
                    break;
                }
            }
        }
        private void AnchoColumnas(Excel.Worksheet xlWorksheet)
        {
            Excel.Range column = xlWorksheet.Range["A1","A1"];
            column.ColumnWidth = 3;
            column = xlWorksheet.Range["B1", "B1"];
            column.ColumnWidth = 18;
            column = xlWorksheet.Range["C1", "C1"];
            column.ColumnWidth = 10;
            column = xlWorksheet.Range["D1", "D1"];
            column.ColumnWidth = 2;
            column = xlWorksheet.Range["E1", "E1"];
            column.ColumnWidth = 3;
            column = xlWorksheet.Range["F1", "F1"];
            column.ColumnWidth = 18;
            column = xlWorksheet.Range["G1", "G1"];
            column.ColumnWidth = 10;
            column = xlWorksheet.Range["H1", "H1"];
            column.ColumnWidth = 2;
            column = xlWorksheet.Range["I1", "I1"];
            column.ColumnWidth = 3;
            column = xlWorksheet.Range["J1", "J1"];
            column.ColumnWidth = 18;
            column = xlWorksheet.Range["K1", "K1"];
            column.ColumnWidth = 10;
            column = xlWorksheet.Range["L1", "L1"];
            column.ColumnWidth = 2;
            column = xlWorksheet.Range["M1", "M1"];
            column.ColumnWidth = 3;
            column = xlWorksheet.Range["N1", "N1"];
            column.ColumnWidth = 18;
            column = xlWorksheet.Range["O1", "O1"];
            column.ColumnWidth = 10;

        }
        private void FormatoTabla(Excel.Range range, int tam, Excel.Range head, Excel.Range values, int tipo)
        {
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            head.Font.Bold = true;
            head.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
            head.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            if(tipo==1)
            {

                values.NumberFormat = " ###,##0.00%";
            }else
                if(tipo==2)
                {
                    values.NumberFormat = "$ #,##0.00";
                }
        }
        private void createRankingHistorico(Excel.Workbook xlWorkBook, RankingFinder objRankingfinder)
        {

            TiendaBLL objTiendaBLL = new TiendaBLL();
            Tienda objFinder = new Tienda()
            {
                Ubicacion = objRankingfinder.UbicacionTienda,
                Tipo = objRankingfinder.TipoTienda,
                Number_tienda = objRankingfinder.Tienda
            };

            IList<Tienda> objTiendas = objTiendaBLL.SelectTiendas(objFinder);
            objRankingfinder.modificaFechaInicial_9SemAntes();
            foreach(Tienda item in objTiendas)
            {
                this.CreateRenkingHistoricoPorTienda(xlWorkBook.Sheets.Add(), objRankingfinder, item);
            }
        }
        private void CreateRenkingHistoricoPorTienda(Excel.Worksheet xlWorksheet, RankingFinder objRankingfinder,Tienda objTiendas)
        {
            RankingBLL objRankingBLL = new RankingBLL();
            int coorX = 0, coorY = 0, numTiendas = 0;
            objRankingfinder.Tienda = objTiendas.Number_tienda;
            xlWorksheet.Name = objTiendas.Code;
            IList<Ranking> lstRankingNoExpress = this.SelectDataRankingPorTienda(objRankingfinder);
            //IList<Ranking> lstRankingNoExpress = SeparaTiendasPorTipo(lstRankings, false);
            encabezadoRanking(xlWorksheet, objRankingfinder, objTiendas, false, true);
            if (objTiendas.Tipo != "Express")
            {
                

                numTiendas = lstRankingNoExpress.Count;
                coorX = 1;
                coorY = 9;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListVentas(lstRankingNoExpress), "VENTAS AP 9%", xlWorksheet, 2, true);

                coorX = 1;
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListOrdenes(lstRankingNoExpress), "ORDENES 9%", xlWorksheet, 3, true);
                coorX += numTiendas + 2;
                coorY = 1;
                lstRankingNoExpress = createTabla(coorX, coorY, this.sortListCostoComida(lstRankingNoExpress), "COSTO DE COMIDA 40%", xlWorksheet, 4, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListTicketPromedio(lstRankingNoExpress), "TICKET PROM $160.00", xlWorksheet, 5, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListGratis(lstRankingNoExpress), "GRATIS 0.50%", xlWorksheet, 6, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListParticipacionAdicionales(lstRankingNoExpress), "PART ADICIONALES", xlWorksheet, 7, true);

                coorY = 1;
                coorX += numTiendas + 2;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListentradaHorno(lstRankingNoExpress), "ENTRADA HORNO 3 MIN", xlWorksheet, 8, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListEntrega(lstRankingNoExpress), "ENTREGA EN MENOS DE 30 MIN 85%", xlWorksheet, 9, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListSalidaTienda(lstRankingNoExpress), "SALIDA DE TIENDA 55%", xlWorksheet, 10, true);
                coorY += 4;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListOrdenesMalas(lstRankingNoExpress), "MALAS ORD Y CANCELADAS", xlWorksheet, 11, true);
                coorX = 1;
                coorY = 1;
                lstRankingNoExpress = createTabla(coorX, coorY, this.SortListPuntos(lstRankingNoExpress), "RANKING SEMANAL", xlWorksheet, 1, true);
            }
            else
            {
                int posX = 1;
                coorX = 1;
                coorY = 9;
                IList<Ranking>  lstRankingExpress = lstRankingNoExpress;
                numTiendas = lstRankingExpress.Count;

                lstRankingExpress = createTabla(coorX, coorY, this.SortListVentas(lstRankingExpress), "VENTAS AP ", xlWorksheet, 2, true);


                coorY += 4;
                lstRankingExpress = createTabla(coorX, coorY, this.SortListOrdenes(lstRankingExpress), "ORDENES ", xlWorksheet, 3, true);

                coorX = posX + numTiendas + 2;
                coorY = 1;
                lstRankingExpress = createTabla(coorX, coorY, this.sortListCostoComida(lstRankingExpress), "COSTO DE COMIDA 38.5%", xlWorksheet, 4, true);
                coorY += 4;
                lstRankingExpress = createTabla(coorX, coorY, this.SortListentradaHorno(lstRankingExpress), "ENTRADA HORNO 3 MIN", xlWorksheet, 8, true);
                coorY += 4;
                lstRankingExpress = createTabla(coorX, coorY, this.SortListParticipacionAdicionales(lstRankingExpress), "PART ADICIONALES 100%", xlWorksheet, 7, true);
                coorY += 4;
                lstRankingExpress = createTabla(coorX, coorY, this.SortListTicketPromedio(lstRankingExpress), "TICKET PROM $100.00", xlWorksheet, 5, true);
                coorX = posX;
                coorY = 1;
                lstRankingExpress = createTabla(coorX, coorY, this.SortListPuntos(lstRankingExpress), "RANKING SEMANAL", xlWorksheet, 1, true);

            }
            AnchoColumnas(xlWorksheet);
        }
        private void encabezadoRanking(Excel.Worksheet xlWorksheet, RankingFinder objRankingFinder, Tienda objTiendas, Boolean isExpress, Boolean isHistorico)
        {
            if (!isExpress)
            {
                Excel.Range column = xlWorksheet.Range["E1", "G1"];
                column.Merge();
                column.Value = "RANKING SEMANAL";
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                column.Font.Bold = true;
                column = xlWorksheet.Range["E2", "G2"];
                column.Merge();
                column.Value = objRankingFinder.SelectYear == null ? DateTime.Now.Year.ToString() : objRankingFinder.SelectYear.Value.ToString();
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                column.Font.Bold = true;
                column = xlWorksheet.Range["E3", "G3"];
                column.Merge();
                column.Value = "DOMIN0'S PIZZA";
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                column.Font.Bold = true;
                column = xlWorksheet.Range["E4", "G5"];
                column.Merge();
                column.Value = "SEMANA " + objRankingFinder.NumSemana.ToString();
                column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                column.Font.Bold = true;
                if (isHistorico)
                {
                    column = xlWorksheet.Range["E6", "G6"];
                    column.Merge();
                    column.Value =objTiendas.Nombre_tienda;
                    column.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    column.Font.Bold = true;
                }


            }
            //else
            //{
            //    Excel.Range column = xlWorksheet.Range["A1", "A1"];
            //}
        }

    }
}