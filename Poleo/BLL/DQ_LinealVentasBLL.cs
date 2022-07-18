using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.DAL;
using Poleo.Objects;
using System.Reflection;
using System.IO;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;


namespace Poleo.BLL
{
    public class DQ_LinealVentasBLL
    {
        private IList<DQ_Ventas> selectDQVentasyOrdenesLineal(DQ_VentasFinder param)
        {
            DQ_VentasDAL DAL = new DQ_VentasDAL();
            return DAL.selectDQVentasyOrdenesLineal(param);
        }
        private IList<Contabilidad> selectDQContabilidad(DQ_VentasFinder param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();
            return DAL.selectDQContabilidad(param);
        }

        public String GenerateVentas_Lineal(DQ_VentasFinder objfinder, HttpServerUtility server, int Year)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);


                IList<DQ_Ventas> lstLinealVentasyOrdenes = this.selectDQVentasyOrdenesLineal(objfinder);
                xlWorksheet = xlWorkBook.Worksheets[1]; //Sets the info in the first Sheet
                this.CreatesheetVentas_Lineal(xlWorksheet, lstLinealVentasyOrdenes, Year);


                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                nombreArchivo = "VentasyOrdenesDQ" + anioNom + ".xlsx";
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


        public String GenerateContabilidad(DQ_VentasFinder objfinder, HttpServerUtility server, int Year,int Mounth)
        {
            TiendaBLL objTiendasBLL = new TiendaBLL();
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);


                IList<Contabilidad> lstLinealVentasyOrdenes = this.selectDQContabilidad(objfinder);
                xlWorksheet = xlWorkBook.Worksheets[1]; //Sets the info in the first Sheet
                xlWorksheet.Application.ActiveWindow.SplitRow = 5;
                xlWorksheet.Application.ActiveWindow.SplitColumn = 3;
                xlWorksheet.Application.ActiveWindow.FreezePanes = true;
                xlWorksheet.Name = "Acumulado";
                this.CreatesheetContabilidad(xlWorksheet, lstLinealVentasyOrdenes, Year);


                DateTime dateAux = DateTime.Now;
                string anioNom = objfinder.SelectYear == null ? objfinder.DateIniLastWeek.Year.ToString() : objfinder.SelectYear.Value.ToString();
                DateTime fechaActual = DateTime.Now.AddMonths(-1);
                string mes = fechaActual.ToString("MMMM");
                nombreArchivo = "Reporte_ContabilidadDQ"+".xlsx";
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

        public void CreatesheetVentas_Lineal(Excel.Worksheet xlWorksheet, IList<DQ_Ventas> lstVentasfile, int Year )
        {
            AnioBLL objAnioBLL = new AnioBLL();

            Decimal totalVentasReales2 = 0;
            String TiendaTemp;
            DateTime yeartemp;


            xlWorksheet.Cells[1, 1] = "TIENDA";
            xlWorksheet.Cells[1, 2] = "FECHA";
            xlWorksheet.Cells[1, 3] = "ORDENES";
            xlWorksheet.Cells[1, 4] = "VENTAS REALES";

            int TW = objAnioBLL.TotalWeekForYear(Year);

            int it = 2;
            int filatemp = 0;

            foreach (DQ_Ventas item in lstVentasfile)
            {
                int numSem = item.NumSemana;

                if (TW == 53)
                    numSem--;


                xlWorksheet.Cells[it, 1] = item.NumTienda;
                xlWorksheet.Cells[it, 2] = item.Fecha.ToOADate();
                xlWorksheet.Cells[it, 3] = item.Ordenes;//.ToShortDateString();
                xlWorksheet.Cells[it, 4] = (Decimal)item.VentasReales;
                
                it++;

            }

            Excel.Range columna = xlWorksheet.Range["D2", "D" + (lstVentasfile.Count + 2).ToString()];
            columna.NumberFormat = "$ #,##0.00";

            columna = xlWorksheet.Range["A1", "O" + (lstVentasfile.Count + 2).ToString()];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //CENTRADO
            columna = xlWorksheet.Range["B2", "B" + (lstVentasfile.Count + 1).ToString()];
            columna.NumberFormat = "dd/MM/yyyy";

            columna = xlWorksheet.Range["B2", "B2"];
            columna.ColumnWidth = 18;
            columna = xlWorksheet.Range["C2", "C2"];
            columna.ColumnWidth = 11;
            columna = xlWorksheet.Range["D2", "D2"];
            columna.ColumnWidth = 19;

            columna = xlWorksheet.Range["A1", "D1"];
            columna.Font.Bold = true;
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            totalVentasReales2 = 0;
            releaseObject(xlWorksheet);
        }

        public void CreatesheetContabilidad(Excel.Worksheet xlWorksheet, IList<Contabilidad> lstVentasfile, int Year)
        {
            AnioBLL objAnioBLL = new AnioBLL();


            #region informacion conceptos
            xlWorksheet.Cells[1, 1] = "YTD";
            xlWorksheet.Cells[1, 3] = "ADQ";
            xlWorksheet.Cells[1, 4] = "1";
            xlWorksheet.Cells[2, 4] = "42607";
            xlWorksheet.Cells[3, 4] = "SENDERO";
            xlWorksheet.Cells[4, 4] = "$";
            xlWorksheet.Cells[1, 6] = "2";
            //xlWorksheet.Cells[6, 5] = "=SI(D$6>0,SI(D6>0,D6/D$6,SI(D6<0,D6/D$6,'')),'')";
            xlWorksheet.Cells[2, 6] = "43662";
            xlWorksheet.Cells[3, 6] = "LOMAS";
            xlWorksheet.Cells[4, 6] = "$";
            xlWorksheet.Cells[1, 8] = "3";
            xlWorksheet.Cells[2, 8] = "41871";
            xlWorksheet.Cells[3, 8] = "DORADO";
            xlWorksheet.Cells[4, 8] = "$";
            xlWorksheet.Cells[1, 10] = "4";
            xlWorksheet.Cells[2, 10] = "43894";
            xlWorksheet.Cells[3, 10] = "VALLES";
            xlWorksheet.Cells[4, 10] = "$";
            xlWorksheet.Cells[1, 12] = "5";
            xlWorksheet.Cells[2, 12] = "44139";
            xlWorksheet.Cells[3, 12] = "CHAPULTEPEC";
            xlWorksheet.Cells[4, 10] = "$";
            xlWorksheet.Cells[1, 14] = "6";
            xlWorksheet.Cells[2, 14] = "44184";
            xlWorksheet.Cells[3, 14] = "CENTRO";
            xlWorksheet.Cells[4, 14] = "$";
            xlWorksheet.Cells[1, 16] = "7";
            xlWorksheet.Cells[2, 16] = "44608";
            xlWorksheet.Cells[3, 16] = "WTC";
            xlWorksheet.Cells[4, 16] = "$";
            xlWorksheet.Cells[1, 18] = "8";
            xlWorksheet.Cells[2, 18] = "44911";
            xlWorksheet.Cells[3, 18] = "CONSTRUPLAZA";
            xlWorksheet.Cells[4, 18] = "$";
            xlWorksheet.Cells[1, 20] = "9";
            xlWorksheet.Cells[2, 20] = "45035";
            xlWorksheet.Cells[3, 20] = "MATEHUALA";
            xlWorksheet.Cells[4, 20] = "$";
            xlWorksheet.Cells[1, 22] = "10";
            xlWorksheet.Cells[2, 22] = "45133";
            xlWorksheet.Cells[3, 22] = "CARRANZA";
            xlWorksheet.Cells[4, 22] = "$";
            xlWorksheet.Cells[1, 24] = "11";
            xlWorksheet.Cells[2, 24] = "45679";
            xlWorksheet.Cells[3, 24] = "FENAPO";
            xlWorksheet.Cells[4, 24] = "$";
            xlWorksheet.Cells[1, 26] = "12";
            xlWorksheet.Cells[2, 26] = "45927";
            xlWorksheet.Cells[3, 26] = "GALERIAS";
            xlWorksheet.Cells[4, 26] = "$";
            xlWorksheet.Cells[1, 28] = "13";
            xlWorksheet.Cells[2, 28] = "70737";
            xlWorksheet.Cells[3, 28] = "PACHUCA";
            xlWorksheet.Cells[4, 28] = "$";
            xlWorksheet.Cells[2, 3] = "Internal";
            xlWorksheet.Cells[3, 3] = "Use";
            xlWorksheet.Cells[4, 3] = "Only";
            xlWorksheet.Cells[6, 3] = "3";
            xlWorksheet.Cells[9, 3] = "8";
            xlWorksheet.Cells[10, 3] = "10";
            xlWorksheet.Cells[17, 3] = "11";
            xlWorksheet.Cells[18, 3] = "12";
            xlWorksheet.Cells[19, 3] = "13";
            xlWorksheet.Cells[20, 3] = "14";
            xlWorksheet.Cells[21, 3] = "48";
            xlWorksheet.Cells[22, 3] = "15";
            xlWorksheet.Cells[23, 3] = "16";
            xlWorksheet.Cells[28, 3] = "17";
            xlWorksheet.Cells[29, 3] = "18";
            xlWorksheet.Cells[30, 3] = "19";
            xlWorksheet.Cells[31, 3] = "20";
            xlWorksheet.Cells[32, 3] = "21";
            xlWorksheet.Cells[33, 3] = "22";
            xlWorksheet.Cells[34, 3] = "23";
            xlWorksheet.Cells[35, 3] = "24";
            xlWorksheet.Cells[36, 3] = "25";
            xlWorksheet.Cells[37, 3] = "26";
            xlWorksheet.Cells[38, 3] = "27";
            xlWorksheet.Cells[39, 3] = "28";
            xlWorksheet.Cells[40, 3] = "29";
            xlWorksheet.Cells[41, 3] = "54";
            xlWorksheet.Cells[48, 3] = "30";
            xlWorksheet.Cells[49, 3] = "31";
            xlWorksheet.Cells[50, 3] = "36";
            xlWorksheet.Cells[51, 3] = "49";
            xlWorksheet.Cells[60, 3] = "50";
            xlWorksheet.Cells[61, 3] = "39";
            xlWorksheet.Cells[62, 3] = "40";
            xlWorksheet.Cells[6, 2] = "VENTAS NETAS (Ventas netas, impuestos y descuentos)";
            xlWorksheet.Cells[8, 1] = "COSTO DE COMIDA (No incluye químicos de limpieza)";
            xlWorksheet.Cells[9, 2] = "Costo de Comida";
            xlWorksheet.Cells[10, 2] = "Descuentos de proveedores";
            xlWorksheet.Cells[12, 2] = "TOTAL COSTO DE COMIDA";
            xlWorksheet.Cells[14, 1] = "MARGEN BRUTO";
            xlWorksheet.Cells[16, 1] = "COSTO MANO DE OBRA";
            xlWorksheet.Cells[17, 2] = "Empleados";
            xlWorksheet.Cells[18, 2] = "Salarios de Gerentes";
            xlWorksheet.Cells[19, 2] = "Impuestos";
            xlWorksheet.Cells[20, 2] = "Beneficios";
            xlWorksheet.Cells[21, 2] = "Seguro de Salud";
            xlWorksheet.Cells[22, 2] = "Bonos";
            xlWorksheet.Cells[23, 2] = "Incapacidad ";
            xlWorksheet.Cells[25, 2] = "TOTAL MANO DE OBRA ";
            xlWorksheet.Cells[27, 1] = "CONTROLABLES POR EL RESTAURANTE";
            xlWorksheet.Cells[28, 2] = "Luz, Agua, ";
            xlWorksheet.Cells[29, 2] = "Teléfono/Internet";
            xlWorksheet.Cells[30, 2] = "Mercadotecnia local";
            xlWorksheet.Cells[31, 2] = "Mercadotecnia local - Rembolsos";
            xlWorksheet.Cells[32, 2] = "Mantenimiento y reparaciones";
            xlWorksheet.Cells[33, 2] = "Servicios externos";
            xlWorksheet.Cells[34, 2] = "Lavandería y Uniformes";
            xlWorksheet.Cells[35, 2] = "Artículos de papelería";
            xlWorksheet.Cells[36, 2] = "Químicos de Limpieza";
            xlWorksheet.Cells[37, 2] = "Artículos no depreciables";
            xlWorksheet.Cells[38, 2] = "Basura y reciclaje";
            xlWorksheet.Cells[39, 2] = "Cargos del banco (Fee)";
            xlWorksheet.Cells[40, 2] = "Faltantes y sobrantes";
            xlWorksheet.Cells[41, 2] = "Comisión de servicio a domicilio";
            xlWorksheet.Cells[43, 2] = "TOTAL CONTROLABLES POR EL RESTAURANTE";
            xlWorksheet.Cells[45, 1] = "GANANCIAS";
            xlWorksheet.Cells[47, 1] = "COSTO DE OPCUPACIÓN RENTA";
            xlWorksheet.Cells[48, 2] = "Renta";
            xlWorksheet.Cells[49, 2] = "Gastos relacionados con la plaza";
            xlWorksheet.Cells[50, 2] = "Gastos de impuestos sobre propiedad";
            xlWorksheet.Cells[51, 2] = "Impuestos y licencias";
            xlWorksheet.Cells[53, 2] = "GASTO TOTAL DE OCUPACIÓN";
            xlWorksheet.Cells[55, 1] = "GASTOS TOTALES DE OPERACIÓN";
            xlWorksheet.Cells[57, 1] = "INGRESOS OPERATIVOS";
            xlWorksheet.Cells[59, 1] = "OTROS INGRESOS-GASTOS";
            xlWorksheet.Cells[60, 2] = "Otros ingresos";
            xlWorksheet.Cells[61, 2] = "Regalías";
            xlWorksheet.Cells[62, 2] = "Fondo de mercadotecnia";
            xlWorksheet.Cells[64, 2] = "TOTAL OTROS INGRESOS-GASTOS";
            xlWorksheet.Cells[66, 1] = "GANANCIAS NETAS ANTES DE IMPUESTOS";
            xlWorksheet.Cells[68, 2] = "COSTO TEORICO";
            #endregion
            #region Inicializa valores
            for (int j = 4; j <= 29; j = j + 2)
            {
                for (int i = 9; i < 11; i++)
                {
                    xlWorksheet.Cells[i, j] = (Decimal)0;
                }
                for (int i = 17; i < 24; i++)
                {
                    xlWorksheet.Cells[i, j] = (Decimal)0;
                }
                for (int i = 28; i < 42; i++)
                {
                    xlWorksheet.Cells[i, j] = (Decimal)0;
                }
                for (int i = 48; i < 52; i++)
                {
                    xlWorksheet.Cells[i, j] = (Decimal)0;
                }
                for (int i = 60; i < 63; i++)
                {
                    xlWorksheet.Cells[i, j] = (Decimal)0;
                }
            }
            for (int i = 4; i < 29; i=i+2)
            {
                xlWorksheet.Cells[68, i] = (Decimal)0;
            }
            #endregion
            int posiciontienda = 4;
            #region LLenado sendero
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].sendero - (Decimal)lstVentasfile[1].sendero;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].sendero + (Decimal)lstVentasfile[4].sendero;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].sendero + (Decimal)lstVentasfile[6].sendero;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].sendero + (Decimal)lstVentasfile[14].sendero + (Decimal)lstVentasfile[15].sendero + (Decimal)lstVentasfile[16].sendero;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].sendero;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].sendero;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].sendero;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].sendero + (Decimal)lstVentasfile[25].sendero;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].sendero;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].sendero;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].sendero;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado Lomas
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].lomas - (Decimal)lstVentasfile[1].lomas;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].lomas + (Decimal)lstVentasfile[4].lomas;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].lomas + (Decimal)lstVentasfile[6].lomas;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].lomas + (Decimal)lstVentasfile[14].lomas + (Decimal)lstVentasfile[15].lomas + (Decimal)lstVentasfile[16].lomas;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].lomas;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].lomas;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].lomas;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].lomas + (Decimal)lstVentasfile[25].lomas;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].lomas;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].lomas;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].lomas;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado dorado
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].dorado - (Decimal)lstVentasfile[1].dorado;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].dorado + (Decimal)lstVentasfile[4].dorado;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].dorado + (Decimal)lstVentasfile[6].dorado;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].dorado + (Decimal)lstVentasfile[14].dorado + (Decimal)lstVentasfile[15].dorado + (Decimal)lstVentasfile[16].dorado;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].dorado;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].dorado;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].dorado;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].dorado + (Decimal)lstVentasfile[25].dorado;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].dorado;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].dorado;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].dorado;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado valles
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].valles - (Decimal)lstVentasfile[1].valles;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].valles + (Decimal)lstVentasfile[4].valles;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].valles + (Decimal)lstVentasfile[6].valles;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].valles + (Decimal)lstVentasfile[14].valles + (Decimal)lstVentasfile[15].valles + (Decimal)lstVentasfile[16].valles;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].valles;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].valles;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].valles;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].valles + (Decimal)lstVentasfile[25].valles;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].valles;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].valles;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].valles;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado chapulpetec
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].chapultepec - (Decimal)lstVentasfile[1].chapultepec;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].chapultepec + (Decimal)lstVentasfile[4].chapultepec;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].chapultepec + (Decimal)lstVentasfile[6].chapultepec;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].chapultepec + (Decimal)lstVentasfile[14].chapultepec + (Decimal)lstVentasfile[15].chapultepec + (Decimal)lstVentasfile[16].chapultepec;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].chapultepec;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].chapultepec;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].chapultepec;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].chapultepec + (Decimal)lstVentasfile[25].chapultepec;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].chapultepec;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].chapultepec;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].chapultepec;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado centro
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].centro - (Decimal)lstVentasfile[1].centro;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].centro + (Decimal)lstVentasfile[4].centro;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].centro + (Decimal)lstVentasfile[6].centro;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].centro + (Decimal)lstVentasfile[14].centro + (Decimal)lstVentasfile[15].centro + (Decimal)lstVentasfile[16].centro;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].centro;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].centro;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].centro;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].centro + (Decimal)lstVentasfile[25].centro;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].centro;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].centro;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].centro;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado wtc
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].wtc - (Decimal)lstVentasfile[1].wtc;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].wtc + (Decimal)lstVentasfile[4].wtc;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].wtc + (Decimal)lstVentasfile[6].wtc;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].wtc + (Decimal)lstVentasfile[14].wtc + (Decimal)lstVentasfile[15].wtc + (Decimal)lstVentasfile[16].wtc;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].wtc;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].wtc;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].wtc;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].wtc + (Decimal)lstVentasfile[25].wtc;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].wtc;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].wtc;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].wtc;
            # endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado construplaza
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].construplaza - (Decimal)lstVentasfile[1].construplaza;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].construplaza + (Decimal)lstVentasfile[4].construplaza;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].construplaza + (Decimal)lstVentasfile[6].construplaza;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].construplaza + (Decimal)lstVentasfile[14].construplaza + (Decimal)lstVentasfile[15].construplaza + (Decimal)lstVentasfile[16].construplaza;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].construplaza;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].construplaza;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].construplaza;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].construplaza + (Decimal)lstVentasfile[25].construplaza;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].construplaza;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].construplaza;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].construplaza;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado matehuala
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].matehuala - (Decimal)lstVentasfile[1].matehuala;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].matehuala + (Decimal)lstVentasfile[4].matehuala;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].matehuala + (Decimal)lstVentasfile[6].matehuala;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].matehuala + (Decimal)lstVentasfile[14].matehuala + (Decimal)lstVentasfile[15].matehuala + (Decimal)lstVentasfile[16].matehuala;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].matehuala;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].matehuala;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].matehuala;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].matehuala + (Decimal)lstVentasfile[25].matehuala;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].matehuala;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].matehuala;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].matehuala;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado carranza
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].carranza - (Decimal)lstVentasfile[1].carranza;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].carranza + (Decimal)lstVentasfile[4].carranza;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].carranza + (Decimal)lstVentasfile[6].carranza;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].carranza + (Decimal)lstVentasfile[14].carranza + (Decimal)lstVentasfile[15].carranza + (Decimal)lstVentasfile[16].carranza;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].carranza;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].carranza;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].carranza;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].carranza + (Decimal)lstVentasfile[25].carranza;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].carranza;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].carranza;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].carranza;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado fenapo
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].fenapo - (Decimal)lstVentasfile[1].fenapo;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].fenapo + (Decimal)lstVentasfile[4].fenapo;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].fenapo + (Decimal)lstVentasfile[6].fenapo;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].fenapo + (Decimal)lstVentasfile[14].fenapo + (Decimal)lstVentasfile[15].fenapo + (Decimal)lstVentasfile[16].fenapo;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].fenapo;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].fenapo;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].fenapo;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].fenapo + (Decimal)lstVentasfile[25].fenapo;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].fenapo;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].fenapo;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].fenapo;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado galerias
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].galerias - (Decimal)lstVentasfile[1].galerias;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].galerias + (Decimal)lstVentasfile[4].galerias;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].galerias + (Decimal)lstVentasfile[6].galerias;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].galerias + (Decimal)lstVentasfile[14].galerias + (Decimal)lstVentasfile[15].galerias + (Decimal)lstVentasfile[16].galerias;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].galerias;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].galerias;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].galerias;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].galerias + (Decimal)lstVentasfile[25].galerias;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].galerias;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].galerias;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].galerias;
            #endregion
            posiciontienda = posiciontienda + 2;
            #region LLenado pachuca
            xlWorksheet.Cells[6, posiciontienda] = (Decimal)lstVentasfile[0].pachuca - (Decimal)lstVentasfile[1].pachuca;
            xlWorksheet.Cells[28, posiciontienda] = (Decimal)lstVentasfile[3].pachuca + (Decimal)lstVentasfile[4].pachuca;
            xlWorksheet.Cells[29, posiciontienda] = (Decimal)lstVentasfile[5].pachuca + (Decimal)lstVentasfile[6].pachuca;
            xlWorksheet.Cells[32, posiciontienda] = (Decimal)lstVentasfile[13].pachuca + (Decimal)lstVentasfile[14].pachuca + (Decimal)lstVentasfile[15].pachuca + (Decimal)lstVentasfile[16].pachuca;
            xlWorksheet.Cells[34, posiciontienda] = (Decimal)lstVentasfile[19].pachuca;
            xlWorksheet.Cells[35, posiciontienda] = (Decimal)lstVentasfile[11].pachuca;
            xlWorksheet.Cells[36, posiciontienda] = (Decimal)lstVentasfile[10].pachuca;
            xlWorksheet.Cells[39, posiciontienda] = (Decimal)lstVentasfile[17].pachuca + (Decimal)lstVentasfile[25].pachuca;
            xlWorksheet.Cells[41, posiciontienda] = (Decimal)lstVentasfile[23].pachuca;
            xlWorksheet.Cells[48, posiciontienda] = (Decimal)lstVentasfile[7].pachuca;
            xlWorksheet.Cells[61, posiciontienda] = (Decimal)lstVentasfile[2].pachuca;
            #endregion
            #region Porcentajes
            string CeldaSEl2 = "";
            string CeldaSEl3 = "";
            Excel.Range columna2;
            for (int i = 68; i < 90; i=i+2)
            {
                CeldaSEl2 = Char.ToString((char)i);
                CeldaSEl3 = Char.ToString((char)(i+1));
                columna2 = xlWorksheet.Range[CeldaSEl3+"6", CeldaSEl3+"6"];
                columna2.Formula = "="+ CeldaSEl2 + "6/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3+"12", CeldaSEl3+ "12"];
                columna2.Formula = "="+ CeldaSEl2 + "12/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "14", CeldaSEl3 + "14"];
                columna2.Formula = "="+ CeldaSEl2+"14/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "25", CeldaSEl3 + "25"];
                columna2.Formula = "="+ CeldaSEl2 + "25/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "43", CeldaSEl3 + "43"];
                columna2.Formula = "="+ CeldaSEl2 + "43/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "45", CeldaSEl3 + "45"];
                columna2.Formula = "="+ CeldaSEl2+"45/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "53", CeldaSEl3 + "53"];
                columna2.Formula = "="+ CeldaSEl2 + "53/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "55", CeldaSEl3 + "55"];
                columna2.Formula = "="+ CeldaSEl2 + "55/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "57", CeldaSEl3 + "57"];
                columna2.Formula = "="+ CeldaSEl2 + "57/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "64", CeldaSEl3 + "64"];
                columna2.Formula = "="+ CeldaSEl2 + "64/"+ CeldaSEl2 + "$6";
                columna2.Calculate();
                columna2 = xlWorksheet.Range[CeldaSEl3 + "66", CeldaSEl3 + "66"];
                columna2.Formula = "="+ CeldaSEl2 + "66/"+CeldaSEl2+"$6";
                columna2.Calculate();
            }
            CeldaSEl2 = "Z";
            CeldaSEl3 = "AA";
            columna2 = xlWorksheet.Range[CeldaSEl3 + "6", CeldaSEl3 + "6"];
            columna2.Formula = "=" + CeldaSEl2 + "6/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "12", CeldaSEl3 + "12"];
            columna2.Formula = "=" + CeldaSEl2 + "12/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "14", CeldaSEl3 + "14"];
            columna2.Formula = "=" + CeldaSEl2 + "14/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "25", CeldaSEl3 + "25"];
            columna2.Formula = "=" + CeldaSEl2 + "25/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "43", CeldaSEl3 + "43"];
            columna2.Formula = "=" + CeldaSEl2 + "43/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "45", CeldaSEl3 + "45"];
            columna2.Formula = "=" + CeldaSEl2 + "45/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "53", CeldaSEl3 + "53"];
            columna2.Formula = "=" + CeldaSEl2 + "53/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "55", CeldaSEl3 + "55"];
            columna2.Formula = "=" + CeldaSEl2 + "55/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "57", CeldaSEl3 + "57"];
            columna2.Formula = "=" + CeldaSEl2 + "57/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "64", CeldaSEl3 + "64"];
            columna2.Formula = "=" + CeldaSEl2 + "64/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "66", CeldaSEl3 + "66"];
            columna2.Formula = "=" + CeldaSEl2 + "66/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            CeldaSEl2 = "AB";
            CeldaSEl3 = "AC";
            columna2 = xlWorksheet.Range[CeldaSEl3+"6", CeldaSEl3+"6"];
            columna2.Formula = "=" + CeldaSEl2 + "6/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "12", CeldaSEl3 + "12"];
            columna2.Formula = "=" + CeldaSEl2 + "12/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "14", CeldaSEl3 + "14"];
            columna2.Formula = "=" + CeldaSEl2 + "14/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "25", CeldaSEl3 + "25"];
            columna2.Formula = "=" + CeldaSEl2 + "25/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "43", CeldaSEl3 + "43"];
            columna2.Formula = "=" + CeldaSEl2 + "43/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "45", CeldaSEl3 + "45"];
            columna2.Formula = "=" + CeldaSEl2 + "45/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "53", CeldaSEl3 + "53"];
            columna2.Formula = "=" + CeldaSEl2 + "53/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "55", CeldaSEl3 + "55"];
            columna2.Formula = "=" + CeldaSEl2 + "55/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "57", CeldaSEl3 + "57"];
            columna2.Formula = "=" + CeldaSEl2 + "57/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "64", CeldaSEl3 + "64"];
            columna2.Formula = "=" + CeldaSEl2 + "64/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            columna2 = xlWorksheet.Range[CeldaSEl3 + "66", CeldaSEl3 + "66"];
            columna2.Formula = "=" + CeldaSEl2 + "66/" + CeldaSEl2 + "$6";
            columna2.Calculate();
            #endregion
            #region Color de conceptos
            Excel.Range columna = xlWorksheet.Range["A1", "AB68"];
            //columna.Font.Name = "Arial";
            columna = xlWorksheet.Range["B6", "B6"];
            columna.ColumnWidth = 50;
            System.Drawing.ColorConverter cc = new System.Drawing.ColorConverter();
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            //ColorTranslator.ToOle((Color)cc.ConvertFromString("#BDD7EE"))
            columna = xlWorksheet.Range["A1", "A1"];
            columna.Font.Bold = true;
            columna.Font.Underline = true;
            columna = xlWorksheet.Range["A1", "A1"];
            columna.Font.Bold = true;
            columna = xlWorksheet.Range["c1", "c69"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["c1", "c4"];
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            columna = xlWorksheet.Range["D2", "AB4"];
            columna.Font.Bold = true;
            columna.ColumnWidth = 15.5;
            columna.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            columna = xlWorksheet.Range["E2", "E4"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["G2", "G4"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["I2", "I4"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["K2", "K4"];
            columna.ColumnWidth = 7.5;
            
            columna = xlWorksheet.Range["M2", "M4"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["O2", "O4"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["Q2", "Q24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["S2", "S24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["U2", "U24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["W2", "W24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["Y2", "Y24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["AA2", "AA24"];
            columna.ColumnWidth = 7.5;
            columna = xlWorksheet.Range["B10", "C10"];
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            columna = xlWorksheet.Range["B12", "B12"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["A14", "B14"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["B25", "B25"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            //columna = xlWorksheet.Range["D6", "AC6"];
            columna = xlWorksheet.Range["B43", "B43"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["A45", "B45"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["B53", "B53"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["A55", "B55"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["A57", "B57"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["D68", "AB68"];
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#0000FF"));
            columna = xlWorksheet.Range["B60", "C60"];
            columna.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            columna = xlWorksheet.Range["B64", "B64"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            columna = xlWorksheet.Range["A66", "B66"];
            columna.Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color)cc.ConvertFromString("#BDD7EE"));
            #endregion
            #region Desbloquear celdas
            columna = xlWorksheet.Range["D6", "AC66"];
            columna.Locked = false;
            #endregion
            #region Formato de pesos
            string CeldaSEl = "";
            for (int L = 68; L <= 90; L = L + 2)
            {
                CeldaSEl = Char.ToString((char)L);
                columna = xlWorksheet.Range[CeldaSEl+"6", CeldaSEl + "66"];
                columna.NumberFormat = "$ #,##0.00";
            }
            CeldaSEl = "AB";
            columna = xlWorksheet.Range[CeldaSEl + "6", CeldaSEl + "66"];
            columna.NumberFormat = "$ #,##0.00";
            #endregion
            #region FORMATO POCENTAJE
            for (int L = 69; L <= 90; L = L + 2)
            {
                CeldaSEl = Char.ToString((char)L);
                columna = xlWorksheet.Range[CeldaSEl + "6", CeldaSEl + "66"];
                columna.NumberFormat = "###,##0.00%";
                columna.Locked = true;
            }
            CeldaSEl = "AC";
            columna = xlWorksheet.Range[CeldaSEl + "6", CeldaSEl + "68"];
            columna.NumberFormat = "###,##0.00%";
            columna.Locked = true;
            CeldaSEl = "AC";
            columna = xlWorksheet.Range[CeldaSEl + "68", CeldaSEl + "68"];
            columna.NumberFormat = "###,##0.00%";
            columna.Locked = true;
            CeldaSEl = "AA";
            columna = xlWorksheet.Range[CeldaSEl + "6", CeldaSEl + "66"];
            columna.NumberFormat = "###,##0.00%";
            columna.Locked = true;
            //CeldaSEl = "AC";
            //columna = xlWorksheet.Range[CeldaSEl + "6", CeldaSEl + "66"];
            //columna.NumberFormat= "###,##0.00%";
            for (int i = 68; i < 91; i = i + 2)
            {
                CeldaSEl = Char.ToString((char)i);
                columna = xlWorksheet.Range[CeldaSEl +"68", CeldaSEl +"68"];
                columna.NumberFormat = "###,##0.00%";
            }
            CeldaSEl = "AB";
            columna = xlWorksheet.Range[CeldaSEl + "68", CeldaSEl + "68"];
            columna.NumberFormat = "###,##0.00%";
            #endregion
            #region Formulas
            for (int L = 68; L < 90; L = L + 2)
            {
                for (int E = 9; E < 11; E++)
                {
                    CeldaSEl = Char.ToString((char)(L + 1));
                    columna = xlWorksheet.Range[CeldaSEl + E.ToString(), CeldaSEl + E.ToString()];
                    columna.Formula = "=" + Char.ToString((char)(L)) + E.ToString() + "/" + Char.ToString((char)(L)) + "$6";
                    columna.Calculate();
                    columna.Locked = true;
                }
                for (int E = 17; E < 24; E++)
                {
                    CeldaSEl = Char.ToString((char)(L + 1));
                    columna = xlWorksheet.Range[CeldaSEl + E.ToString(), CeldaSEl + E.ToString()];
                    columna.Formula = "=" + Char.ToString((char)(L)) + E.ToString() + "/" + Char.ToString((char)(L)) + "$6";
                    columna.Calculate();
                    columna.Locked = true;
                }
                for (int E = 28; E < 42; E++)
                {
                    CeldaSEl = Char.ToString((char)(L + 1));
                    columna = xlWorksheet.Range[CeldaSEl + E.ToString(), CeldaSEl + E.ToString()];
                    columna.Formula = "=" + Char.ToString((char)(L)) + E.ToString() + "/" + Char.ToString((char)(L)) + "$6";
                    columna.Calculate();
                    columna.Locked = true;
                }
                for (int E = 48; E < 52; E++)
                {
                    CeldaSEl = Char.ToString((char)(L + 1));
                    columna = xlWorksheet.Range[CeldaSEl + E.ToString(), CeldaSEl + E.ToString()];
                    columna.Formula = "=" + Char.ToString((char)(L)) + E.ToString() + "/" + Char.ToString((char)(L)) + "$6";
                    columna.Calculate();
                    columna.Locked = true;
                }
                for (int E = 60; E < 62; E++)
                {
                    CeldaSEl = Char.ToString((char)(L + 1));
                    columna = xlWorksheet.Range[CeldaSEl + E.ToString(), CeldaSEl + E.ToString()];
                    columna.Formula = "=" + Char.ToString((char)(L)) + E.ToString() + "/" + Char.ToString((char)(L)) + "$6";
                    columna.Calculate();
                    columna.Locked = true;
                }
                CeldaSEl = Char.ToString((char)L);
                columna = xlWorksheet.Range[CeldaSEl + "12", CeldaSEl + "12"];
                columna.Formula = "=" + CeldaSEl + "9-" + CeldaSEl + "10";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "14", CeldaSEl + "14"];
                columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "12";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "25", CeldaSEl + "25"];
                columna.Formula = "=" + CeldaSEl + "17+" + CeldaSEl + "18+" + CeldaSEl + "19+"
                    + CeldaSEl + "20+" + CeldaSEl + "21+" + CeldaSEl + "22+" + CeldaSEl + "23";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "43", CeldaSEl + "43"];
                columna.Formula = "=" + CeldaSEl + "28+" + CeldaSEl + "29+" + CeldaSEl + "30+"
                    + CeldaSEl + "31+" + CeldaSEl + "32+" + CeldaSEl + "33+" + CeldaSEl + "34+"
                    + CeldaSEl + "35+" + CeldaSEl + "35+" + CeldaSEl + "37+" + CeldaSEl + "38+"
                    + CeldaSEl + "39+" + CeldaSEl + "40+" + CeldaSEl + "41";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "45", CeldaSEl + "45"];
                columna.Formula = "=" + CeldaSEl + "14-" + CeldaSEl + "25-" + CeldaSEl + "43";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "53", CeldaSEl + "53"];
                columna.Formula = "=" + CeldaSEl + "48+" + CeldaSEl + "49+" + CeldaSEl + "50+"
                    + CeldaSEl + "51+" + CeldaSEl + "52";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "55", CeldaSEl + "55"];
                columna.Formula = "=" + CeldaSEl + "12+" + CeldaSEl + "25+" + CeldaSEl + "43+" + CeldaSEl + "53";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "57", CeldaSEl + "57"];
                columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "55";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "64", CeldaSEl + "64"];
                columna.Formula = "=(" + CeldaSEl + "61+" + CeldaSEl + "62)-" + CeldaSEl + "60";
                columna.Calculate();
                columna.Locked = true;
                columna = xlWorksheet.Range[CeldaSEl + "66", CeldaSEl + "66"];
                columna.Formula = "=" + CeldaSEl + "57-" + CeldaSEl + "64";
                columna.Calculate();
                columna.Locked = true;
            }
            String sL = "AB";
            String sLL = "AC";
            for (int E = 9; E < 11; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 17; E < 24; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 28; E < 42; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 48; E < 52; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 60; E < 62; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            sL = "Z";
            sLL = "AA";
            for (int E = 9; E < 11; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 17; E < 24; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 28; E < 42; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 48; E < 52; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            for (int E = 60; E < 62; E++)
            {
                columna = xlWorksheet.Range[sLL + E.ToString(), sLL + E.ToString()];
                columna.Formula = "=" + sL + E.ToString() + "/" + sL + "$6";
                columna.Calculate();
                columna.Locked = true;
            }
            CeldaSEl = "Z";
            columna = xlWorksheet.Range[CeldaSEl + "12", CeldaSEl + "12"];
            columna.Formula = "=" + CeldaSEl + "9-" + CeldaSEl + "10";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "14", CeldaSEl + "14"];
            columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "12";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "25", CeldaSEl + "25"];
            columna.Formula = "=" + CeldaSEl + "17+" + CeldaSEl + "18+" + CeldaSEl + "19+"
                + CeldaSEl + "20+" + CeldaSEl + "21+" + CeldaSEl + "22+" + CeldaSEl + "23";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "43", CeldaSEl + "43"];
            columna.Formula = "=" + CeldaSEl + "28+" + CeldaSEl + "29+" + CeldaSEl + "30+"
                + CeldaSEl + "31+" + CeldaSEl + "32+" + CeldaSEl + "33+" + CeldaSEl + "34+"
                + CeldaSEl + "35+" + CeldaSEl + "35+" + CeldaSEl + "36+" + CeldaSEl + "37+" + CeldaSEl + "38+"
                + CeldaSEl + "39+" + CeldaSEl + "40+" + CeldaSEl + "41";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "45", CeldaSEl + "45"];
            columna.Formula = "=" + CeldaSEl + "14-" + CeldaSEl + "25-" + CeldaSEl + "43";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "53", CeldaSEl + "53"];
            columna.Formula = "=" + CeldaSEl + "48+" + CeldaSEl + "49+" + CeldaSEl + "50+"
                + CeldaSEl + "51+" + CeldaSEl + "52";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "55", CeldaSEl + "55"];
            columna.Formula = "=" + CeldaSEl + "12+" + CeldaSEl + "25+" + CeldaSEl + "43+" + CeldaSEl + "53";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "57", CeldaSEl + "57"];
            columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "55";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "64", CeldaSEl + "64"];
            columna.Formula = "=(" + CeldaSEl + "61+" + CeldaSEl + "62)-" + CeldaSEl + "60";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "66", CeldaSEl + "66"];
            columna.Formula = "=" + CeldaSEl + "57-" + CeldaSEl + "64";
            columna.Calculate();
            columna.Locked = true;
            CeldaSEl = "AB";
            columna = xlWorksheet.Range[CeldaSEl + "12", CeldaSEl + "12"];
            columna.Formula = "=" + CeldaSEl + "9-" + CeldaSEl + "10";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "14", CeldaSEl + "14"];
            columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "12";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "25", CeldaSEl + "25"];
            columna.Formula = "=" + CeldaSEl + "17+" + CeldaSEl + "18+" + CeldaSEl + "19+"
                + CeldaSEl + "20+" + CeldaSEl + "21+" + CeldaSEl + "22+" + CeldaSEl + "23";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "43", CeldaSEl + "43"];
            columna.Formula = "=" + CeldaSEl + "28+" + CeldaSEl + "29+" + CeldaSEl + "30+"
                + CeldaSEl + "31+" + CeldaSEl + "32+" + CeldaSEl + "33+" + CeldaSEl + "34+"
                + CeldaSEl + "35+" + CeldaSEl + "35+" + CeldaSEl + "36+" + CeldaSEl + "37+" + CeldaSEl + "38+"
                + CeldaSEl + "39+" + CeldaSEl + "40+" + CeldaSEl + "41";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "45", CeldaSEl + "45"];
            columna.Formula = "=" + CeldaSEl + "14-" + CeldaSEl + "25-" + CeldaSEl + "43";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "53", CeldaSEl + "53"];
            columna.Formula = "=" + CeldaSEl + "48+" + CeldaSEl + "49+" + CeldaSEl + "50+"
                + CeldaSEl + "51+" + CeldaSEl + "52";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "55", CeldaSEl + "55"];
            columna.Formula = "=" + CeldaSEl + "12+" + CeldaSEl + "25+" + CeldaSEl + "43+" + CeldaSEl + "53";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "57", CeldaSEl + "57"];
            columna.Formula = "=" + CeldaSEl + "6-" + CeldaSEl + "55";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "64", CeldaSEl + "64"];
            columna.Formula = "=(" + CeldaSEl + "61+" + CeldaSEl + "62)-" + CeldaSEl + "60";
            columna.Calculate();
            columna.Locked = true;
            columna = xlWorksheet.Range[CeldaSEl + "66", CeldaSEl + "66"];
            columna.Formula = "=" + CeldaSEl + "57-" + CeldaSEl + "64";
            columna.Calculate();
            columna.Locked = true;

            #endregion
            #region Formato de celdas
            columna = xlWorksheet.Range["D6", "AC6"];
            columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            columna = xlWorksheet.Range["D9", "AC9"];
            columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            for (int i = 10; i < 15; i = i + 2)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            for (int i=17;i<24;i++)
            {
                columna = xlWorksheet.Range["D"+i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            columna = xlWorksheet.Range["D25", "AC25"];
            columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            for (int i = 28; i < 42; i++)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            columna = xlWorksheet.Range["D43", "AC43"];
            columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            columna = xlWorksheet.Range["D45", "AC45"];
            columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
            for (int i = 48; i < 52; i++)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            for (int i = 53; i < 58; i = i + 2)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            for (int i = 60; i < 62; i++)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            for (int i = 64; i < 67; i = i + 2)
            {
                columna = xlWorksheet.Range["D" + i.ToString(), "AC" + i.ToString()];
                columna.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            #endregion

            xlWorksheet.Protect("1234", true);
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
                //MessageBox.Show ("Excepción ocurrió mientras que la liberación de objeto" + ex.ToString ());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}