using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;


using Poleo.BLL;
using Poleo.Objects;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Net;

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Poleo.Pages
{
    public partial class Pag_Reclutamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateContent();
        }

        #region TBL
        private void CreateContent()
        {
            int IdUser = (int)Session["_IdUser"];
            IList<int> lstObjects = new List<int>();
            ObjectsXUserBLL objObjectsXUserBLL = new ObjectsXUserBLL();

            lstObjects = objObjectsXUserBLL.SelectObjectsByUser(IdUser);

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("/XML/XMLButtonsReclutamiento.xml"));

            XmlNodeList lstButtons = doc.SelectNodes("Buttons/Button");

            HtmlTableRow Row = null;
            int CountBtn = int.Parse(ConfigurationManager.AppSettings["Maxbtn"].ToString());
            int c = 1;

            foreach (XmlNode button in lstButtons)
            {
                string rol = button.SelectSingleNode("Rol").InnerText;


                if (string.IsNullOrEmpty(rol) || lstObjects.Contains(int.Parse(rol)))
                {
                    if (c == 1)
                        Row = new HtmlTableRow();

                    HtmlTableCell Cell = new HtmlTableCell();
                    Button reportBtn = new Button();
                    ImageButton reportImgBtn = new ImageButton();
                    HtmlTable tableContentBtn = new HtmlTable();

                    reportBtn = Tools.ToolsControls.CreateBtnReport(button.SelectSingleNode("Control"));
                    reportImgBtn = Tools.ToolsControls.CreateBtnImgReport(button.SelectSingleNode("Image"));
                    AsignMethodBtn(reportBtn);
                    AsignMethodImgBtn(reportImgBtn);

                    tableContentBtn = CreateTblContentBtn(reportBtn, reportImgBtn);
                    Cell.Controls.Add(tableContentBtn);
                    Row.Cells.Add(Cell);

                    Cell.Attributes.Add("style", "padding-bottom: 15px;padding-left: 15px;");

                    if (c == CountBtn)
                    {
                        tblContent.Rows.Add(Row);
                        c = 1;
                    }
                    else
                        c++;
                }
            }

            if (c > 1 && c < CountBtn)
                tblContent.Rows.Add(Row);
        }
        #endregion
        protected void btnPDFEncuesta_Click(object sender, EventArgs e)
        {
            this.btnPDFEncuesta_Click(sender, null);
        }

        private ImageButton AsignMethodImgBtn(ImageButton imgBtnReport)
        {
            switch (imgBtnReport.ID)
            {
                case "ibtnPDF":
                    imgBtnReport.Click += new ImageClickEventHandler(btnPDFEncuesta_Click);
                    break;

            }

            return imgBtnReport;
        }
        private HtmlTable CreateTblContentBtn(Button btnReport, ImageButton imgBtnReport)
        {
            HtmlTable tblContentBtn = new HtmlTable();
            HtmlTableRow rowContent = new HtmlTableRow();
            HtmlTableCell cellContentImg = new HtmlTableCell();
            HtmlTableCell cellContentBtn = new HtmlTableCell();

            cellContentImg = AddCellImgBtn(imgBtnReport);
            cellContentBtn = AddCellBtn(btnReport);

            rowContent.Cells.Add(cellContentImg);
            rowContent.Cells.Add(cellContentBtn);

            //rowContent.Attributes.Add("style", "white-space:nowrap;");

            tblContentBtn.Rows.Add(rowContent);

            return tblContentBtn;
        }
        private HtmlTableCell AddCellImgBtn(ImageButton imgBtnReport)
        {
            HtmlTableCell CellImg = new HtmlTableCell();

            CellImg.Attributes.Add("class", "btnExcelTD");

            CellImg.Controls.Add(imgBtnReport);

            return CellImg;
        }

        private HtmlTableCell AddCellBtn(Button btnReport)
        {
            HtmlTableCell CellBtn = new HtmlTableCell();

            //CellBtn.Attributes.Add("class", "elementes");

            CellBtn.Controls.Add(btnReport);

            return CellBtn;
        }
        private Button AsignMethodBtn(Button btnReport)
        {
            switch (btnReport.ID)
            {
                case "btnPDFEncuesta":
                    btnReport.Click += new EventHandler(btnPDFEncuesta_Click);
                    break;

            }

            return btnReport;
        }
        private VentasFinder ValidateFiltersField()
        //ventasfinder contiene (fechainicial, fechafinal, numtienda, tipotienda, ubicacion, numsemana, indicadorfull)
        {
            VentasFinder objVentasFinder = new VentasFinder();

            objVentasFinder = (VentasFinder)ctrFilter.GetFiltersField();
            objVentasFinder.IndicadorFull = true;//CheckBox1.Checked;

            return objVentasFinder;
        }
        private void creapdf(RecluFechas reclufechas, EncuestaHeader encuestaHeader)
        {

            Excel.Workbook wkb = new Excel.Workbook();

            // Acceda a la primera hoja de trabajo del libro.
            Excel.Worksheet sht = wkb.Worksheets[0];

            // Obtenga la(s) celda(s) deseada(s) de la hoja de cálculo.
            Cell c00 = sht.Cells["A1"];
            Cell c01 = sht.Cells["B1"];
            Cell c10 = sht.Cells["A2"];
            Cell c11 = sht.Cells["B2"];

            // ingrese el valor en la(s) celda(s).

            // Guarde el libro de trabajo como archivo .pdf.
            wkb.SaveAs("created_one.pdf");

            //    EncuestaBLL encuestaBLL1 = new EncuestaBLL();
            //    reclufechas.IdEntrevista = encuestaHeader.IdEncuesta;
            //    DataSet dataSourceReport = encuestaBLL1.GetDataSourceReport(reclufechas, encuestaHeader);
            //    ReportDataSource objReportDataSource = new ReportDataSource("Cabecera", dataSourceReport.Tables[0]);
            //    ReportDataSource objReportDataSource1 = new ReportDataSource("Detalle", dataSourceReport.Tables[1]);
            //    ReportViewer objReportViewer = new ReportViewer();

            //    Warning[] warnings;
            //    string[] streamIds;
            //    string mimeType = string.Empty;
            //    string encoding = string.Empty;
            //    string extension = string.Empty;
            //    string fileName = encuestaHeader.Nombre; //dataSourceReport.Tables[0].Rows[0][1].ToString();

            //    objReportViewer.ProcessingMode = ProcessingMode.Local;
            //    objReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Report\Report_CheckingExpenses.rdlc");
            //    objReportViewer.LocalReport.DataSources.Add(objReportDataSource);
            //    objReportViewer.LocalReport.DataSources.Add(objReportDataSource1);

            //    byte[] bytes = objReportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            //    Response.Buffer = true;
            //    Response.Clear();
            //    Response.ContentType = mimeType;
            //    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            //    Response.BinaryWrite(bytes); // create the file
            //    Response.Flush(); // send it to the client to download
            }

            protected void btnPDFEncuesta_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                DateTime datesatandar = new DateTime();
                DateTime datestar = new DateTime();
                DateTime datefinish = new DateTime();
                datestar = ValidateFiltersField().DateIni.Value;
                datefinish = ValidateFiltersField().DateEnd.Value;
                RecluFechas reclufechas = new RecluFechas();
                VentasFinder ventasFinder = new VentasFinder();
                reclufechas.DateIni = datestar;
                reclufechas.DateEnd = datefinish;
                Excel.Application oXL = new Excel.Application();
                
                if (datesatandar != datestar && datesatandar!=datefinish)
                {

                    EncuestaBLL encuestaBLL = new EncuestaBLL();
                    IList<EncuestaHeader> headers= new List<EncuestaHeader>();
                    Encuesta_ASPECTOLABORAL AL = new Encuesta_ASPECTOLABORAL();
                    Encuesta_OportunidadLaboral OL=new Encuesta_OportunidadLaboral();
                    Encuesta_FamiliaresPersonales FP=new Encuesta_FamiliaresPersonales();
                    Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES EIP = new Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES();
                    EncuestaFooter EF=new EncuestaFooter();
                    headers =encuestaBLL.SearchHeader(reclufechas);
                    #region crear el excel con varios sheet
                    oXL.Visible = false;
                    Excel.Workbook oWB = oXL.Workbooks.Add(Type.Missing);
                    Excel.Worksheet oSheet = oWB.ActiveSheet as Excel.Worksheet;
                    if(headers.Count > 0)
                    {
                        EncuestaHeader header = headers[0];
                        reclufechas.IdEntrevista = header.IdEncuesta;
                        AL = encuestaBLL.SearchAL(reclufechas);
                        OL = encuestaBLL.SearchOPL(reclufechas);
                        FP = encuestaBLL.SearchFP(reclufechas);
                        EIP = encuestaBLL.SearcEI(reclufechas);
                        EF = encuestaBLL.SearcEF(reclufechas);
                        oWB = oXL.Workbooks.Add(Type.Missing);
                        oSheet = oWB.ActiveSheet as Excel.Worksheet;
                        oSheet.Name = header.IdEncuesta.ToString();
                        #region Encabezado
                        oSheet.Cells[3, 1] = "Nombre";
                        oSheet.Cells[3, 2] = header.Nombre;
                        oSheet.Cells[4, 1] = "Puesto";
                        oSheet.Cells[4, 2] = header.Puesto;
                        oSheet.Cells[5, 1] = "Jefe inmediato";
                        oSheet.Cells[5, 2] = header.NombreJefe;
                        oSheet.Cells[6, 1] = "Puesto Jefe";
                        oSheet.Cells[6, 2] = header.PuestoJefe;
                        oSheet.Cells[3, 4] = "Ingreso";
                        oSheet.Cells[3, 5] = header.Ingreso.ToShortDateString();
                        oSheet.Cells[4, 4] = "Salida";
                        oSheet.Cells[4, 5]=header.Salida.ToShortDateString();
                        oSheet.Cells[5, 4] = "Marca";
                        oSheet.Cells[5, 5] = header.Marca;
                        oSheet.Cells[6, 4] = "Sucursal/Departamento";
                        oSheet.Cells[6, 5] = header.Sucursal_Departamento;
                        oSheet.Cells[9, 1] = "¿Cuál es tu principal motivo de salida?";
                        oSheet.Cells[11, 1] = header.Razon;
                        oSheet.get_Range("A3", "A6").Font.Bold = true;
                        oSheet.get_Range("D3", "D6").Font.Bold = true;
                        oSheet.get_Range("A9", "A9").Font.Bold = true;
                        oSheet.get_Range("A9", "D9").Merge(true);
                        oSheet.get_Range("A3", "F6").Columns.AutoFit();
                        #endregion
                        int inicioPreguntas = 13;
                        #region Aspecto Laboral
                        if (AL!=null)
                        {
                            oSheet.Cells[inicioPreguntas, 1] = "Aspecto Laboral";
                            oSheet.get_Range("A"+inicioPreguntas.ToString(), "D"+inicioPreguntas.ToString()).Merge(true);
                            oSheet.get_Range("A"+ inicioPreguntas.ToString(), "A"+inicioPreguntas.ToString()).Font.Bold = true;
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "1-" +AL.Razon1;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "2-" + AL.Razon2;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "3-" + AL.Razon3;
                            inicioPreguntas += 3;
                        }
                        #endregion
                        #region Oportunidad laboral
                        if (OL != null)
                        {
                            oSheet.Cells[inicioPreguntas, 1] = "MEJOR OPORTUNIDAD LABORAL";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "1-"+( (OL.Razon1 != "Otra") ? OL.Razon1 : OL.Otro);
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "2-"+ ((OL.Razon2 != "Otra") ? OL.Razon2 : OL.Otro);
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "3-" + ((OL.Razon2 != "Otra") ? OL.Razon2 : OL.Otro);
                            inicioPreguntas += 3;
                        }
                        #endregion
                        #region Personales Familiares
                        if (FP != null)
                        {
                            oSheet.Cells[inicioPreguntas, 1] = "MOTIVOS PERSONALES y/o FAMILIARES";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = (FP.Razon1 != "Otra") ? FP.Razon1 : FP.Otro;
                            inicioPreguntas += 3;
                        }
                        #endregion
                        #region estudios/ intereses profesionales
                        if (EIP != null)
                        {
                            oSheet.Cells[inicioPreguntas, 1] = "ESTUDIOS U OTROS INTERESES PROFESIONALES";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = (EIP.Razon1 != "Otra") ? EIP.Razon1 : EIP.Otro;
                            inicioPreguntas += 3;
                        }
                        #endregion
                        #region Encuesta footer
                        if (EF != null)
                        {
                            //oSheet.Cells[inicioPreguntas, 1] = "ESTUDIOS U OTROS INTERESES PROFESIONALES";
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            //inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "3.	¿Te dieron la bienvenida cuando ingresaste a la empresa/tienda?";
                            oSheet.get_Range("A"+ inicioPreguntas.ToString(), "A"+ inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A"+ inicioPreguntas.ToString(), "F"+ inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A"+ inicioPreguntas.ToString(), "F"+ inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta1;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "4.	¿Quién te dio la bienvenida y te mostro lo que tenías que hacer? Escribe su nombre";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta2;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit(); 
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "5.	¿Te capacitaron en tu puesto desde el primer día?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta3;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "6.	¿Te dieron  las reglas o políticas que debías acatar  día a día?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta4;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "7.	¿Te dijeron tus objetivos?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta5;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "8.	¿Tenías claras tus funciones y actividades, de ser así, menciona 2";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta6;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "9.	¿Tu horario de trabajo fue el que te mencionaron en la entrevista?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta7;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "10.	En caso de haber cambiado ¿fue de común acuerdo?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta8;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "11.	¿Te dieron retroalimentación sobre el avance de tus objetivos  y áreas de mejora?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta9;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "12.	¿Si tenías dudas se te aclaraban oportunamente?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta10;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "13.	¿Crees que en esta empresa tienes oportunidades de crecimiento?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta11;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "14.	¿Conoces algún sistema de reconocimiento? De ser así menciónalo	 ";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta12;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "15.¿Cómo fue tu relación con tus compañeros de trabajo?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta13;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta13Des;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "16.¿La relación con tu jefe directo fue?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta14;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta14Des;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "17. ¿El horario que cubrías fue?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta15;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "18. ¿Cómo consideras el sueldo que percibías de acuerdo a las actividades de tu puesto?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta16;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "19. ¿Cómo consideras las prestaciones que percibías?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta17;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "20. ¿Las funciones que desempeñabas fueron?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta18;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "21. ¿Se te facilitaron las herramientas adecuadas para desempeñar tus funciones?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta19;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "22.¿Qué hubiera podido cambiar/mejorar para prevenir tu salida de la empresa?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta20;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "23. Algún otro comentario que te gustaría compartir con nosotros";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta21;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "De acuerdo a tu experiencia, ¿Recomendarías a un familiar y/o amigo trabajar en esta empresa?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta22;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = "Si las políticas lo permitieran, ¿Te gustaría regresar a trabajar con nosotros?";
                            oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                            oSheet.Cells[inicioPreguntas, 1] = EF.Pregunta23;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                            //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            inicioPreguntas += 1;
                        }
                        #endregion
                        for (int i = 1; i < headers.Count; i++)
                        {
                            header = headers[i];
                            reclufechas.IdEntrevista = header.IdEncuesta;
                            AL = encuestaBLL.SearchAL(reclufechas);
                            OL = encuestaBLL.SearchOPL(reclufechas);
                            FP = encuestaBLL.SearchFP(reclufechas);
                            EIP = encuestaBLL.SearcEI(reclufechas);
                            EF = encuestaBLL.SearcEF(reclufechas);
                            Excel.Worksheet oSheet2 = oWB.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing)
                            as Excel.Worksheet;
                            oSheet2.Name = header.IdEncuesta.ToString();
                            #region Encabezado
                            oSheet2.Cells[3, 1] = "Nombre";
                            oSheet2.Cells[3, 2] = header.Nombre;
                            oSheet2.Cells[4, 1] = "Puesto";
                            oSheet2.Cells[4, 2] = header.Puesto;
                            oSheet2.Cells[5, 1] = "Jefe inmediato";
                            oSheet2.Cells[5, 2] = header.NombreJefe;
                            oSheet2.Cells[6, 1] = "Puesto Jefe";
                            oSheet2.Cells[6, 2] = header.PuestoJefe;
                            oSheet2.Cells[3, 4] = "Ingreso";
                            oSheet2.Cells[3, 5] = header.Ingreso.ToShortDateString();
                            oSheet2.Cells[4, 4] = "Salida";
                            oSheet2.Cells[4, 5] = header.Salida.ToShortDateString();
                            oSheet2.Cells[5, 4] = "Marca";
                            oSheet2.Cells[5, 5] = header.Marca;
                            oSheet2.Cells[6, 4] = "Sucursal/Departamento";
                            oSheet2.Cells[6, 5] = header.Sucursal_Departamento;
                            oSheet2.Cells[9, 1] = "¿Cuál es tu principal motivo de salida?";
                            oSheet2.Cells[11, 1] = header.Razon;
                            oSheet2.get_Range("A3", "A6").Font.Bold = true;
                            oSheet2.get_Range("D3", "D6").Font.Bold = true;
                            oSheet2.get_Range("A9", "A9").Font.Bold = true;
                            oSheet2.get_Range("A9", "D9").Merge(true);
                            oSheet2.get_Range("A3", "F6").Columns.AutoFit();
                            #endregion
                            inicioPreguntas = 13;
                            #region ASPECTO LABORAL
                            if (AL != null)
                            {
                                oSheet2.Cells[inicioPreguntas, 1] = "Aspecto Laboral";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "1-"+AL.Razon1;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "2-"+ AL.Razon2;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "3-"+ AL.Razon3;
                                inicioPreguntas += 3;
                            }
                            #endregion
                            #region MEJOR OPORTUNIDAD LABORAL
                            if (OL != null)
                            {
                                oSheet2.Cells[inicioPreguntas, 1] = "MEJOR OPORTUNIDAD LABORAL";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "1-"+((OL.Razon1 != "Otra") ? OL.Razon1 : OL.Otro);
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "2-"+((OL.Razon2 != "Otra") ? OL.Razon2 : OL.Otro);
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "3-"+((OL.Razon2 != "Otra") ? OL.Razon2 : OL.Otro);
                                inicioPreguntas += 3;
                            }
                            #endregion
                            #region MOTIVOS PERSONALES y/o FAMILIARES
                            if (FP != null)
                            {
                                oSheet2.Cells[inicioPreguntas, 1] = "MOTIVOS PERSONALES y/o FAMILIARES";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = (FP.Razon1 != "Otra") ? FP.Razon1 : FP.Otro;
                                inicioPreguntas += 3;
                            }
                            #endregion
                            #region ESTUDIOS U OTROS INTERESES PROFESIONALES
                            if (EIP != null)
                            {
                                oSheet2.Cells[inicioPreguntas, 1] = "ESTUDIOS U OTROS INTERESES PROFESIONALES";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = (EIP.Razon1 != "Otra") ? EIP.Razon1 : FP.Otro;
                                inicioPreguntas += 3;
                            }
                            #endregion
                            #region Encuesta footer
                            if (EF != null)
                            {
                                //oSheet.Cells[inicioPreguntas, 1] = "ESTUDIOS U OTROS INTERESES PROFESIONALES";
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "D" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                //inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "3.	¿Te dieron la bienvenida cuando ingresaste a la empresa/tienda?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta1;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "4.	¿Quién te dio la bienvenida y te mostro lo que tenías que hacer? Escribe su nombre";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta2;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "5.	¿Te capacitaron en tu puesto desde el primer día?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta3;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "6.	¿Te dieron  las reglas o políticas que debías acatar  día a día?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta4;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "7.	¿Te dijeron tus objetivos?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta5;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "8.	¿Tenías claras tus funciones y actividades, de ser así, menciona 2";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta6;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "9.	¿Tu horario de trabajo fue el que te mencionaron en la entrevista?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta7;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "10.	En caso de haber cambiado ¿fue de común acuerdo?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta8;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "11.	¿Te dieron retroalimentación sobre el avance de tus objetivos  y áreas de mejora?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta9;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "12.	¿Si tenías dudas se te aclaraban oportunamente?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta10;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "13.	¿Crees que en esta empresa tienes oportunidades de crecimiento?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta11;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "14.	¿Conoces algún sistema de reconocimiento? De ser así menciónalo	 ";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta12;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "15.¿Cómo fue tu relación con tus compañeros de trabajo?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta13;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta13Des;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "16.¿La relación con tu jefe directo fue?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta14;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta14Des;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "17. ¿El horario que cubrías fue?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta15;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "18. ¿Cómo consideras el sueldo que percibías de acuerdo a las actividades de tu puesto?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta16;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "19. ¿Cómo consideras las prestaciones que percibías?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta17;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "20. ¿Las funciones que desempeñabas fueron?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta18;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "21. ¿Se te facilitaron las herramientas adecuadas para desempeñar tus funciones?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta19;
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "22.¿Qué hubiera podido cambiar/mejorar para prevenir tu salida de la empresa?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta20;
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "23. Algún otro comentario que te gustaría compartir con nosotros";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta21;
                                //oShe2et.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "De acuerdo a tu experiencia, ¿Recomendarías a un familiar y/o amigo trabajar en esta empresa?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta22;
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = "Si las políticas lo permitieran, ¿Te gustaría regresar a trabajar con nosotros?";
                                oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                                oSheet2.Cells[inicioPreguntas, 1] = EF.Pregunta23;
                                //oSheet.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).Font.Bold = true;
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Merge(true);
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "F" + inicioPreguntas.ToString()).Columns.AutoFit();
                                //oSheet2.get_Range("A" + inicioPreguntas.ToString(), "A" + inicioPreguntas.ToString()).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                inicioPreguntas += 1;
                            }
                            #endregion
                        }
                    }
                    string fileName = Server.MapPath("/indicadores") + "\\" + "ReporteEncuesta.xlsx";
                    if (File.Exists(Server.MapPath("/indicadores") + "/" + "ReporteEncuesta.xlsx"))
                    {
                        File.Delete(Server.MapPath("/indicadores") + "/" + "ReporteEncuesta.xlsx");
                    }
                    oWB.SaveAs(Server.MapPath("/indicadores") + "/" + "ReporteEncuesta.xlsx",
                        Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlShared,
                        misValue, misValue, misValue, misValue, misValue);
                    oWB.Close(Type.Missing, Type.Missing, Type.Missing);
                    oXL.UserControl = true;
                    oXL.Quit();
                    #endregion
                    #region se descarga el reporte 
                    string name = "ReporteEncuesta.xlsx";
                    string attachment = "attachment; filename=" + name;
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/ms-excel";
                    Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                    lblMesajeError.Visible = false;
                    Response.End();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                lblMesajeError.Text = ex.Message;
                lblMesajeError.Visible = true; }
                //try
                //{
                //    int year = ValidateFiltersField().SelectYear.Value; //int.Parse(DDLYears.SelectedItem.Text);

                //    if (year < 0)
                //        year = DateTime.Now.Year;

                //    VentasBLL objVentasBLL = new VentasBLL();
                //    string name = objVentasBLL.CreateFileSales(year, Server);//objVentasBLL.GenerfireateAutomaticFile(Server, year);
                //    //Llamar a metodo crearArchivoVentas
                //    string attachment = "attachment; filename=" + name;
                //    Response.ClearContent();
                //    Response.AddHeader("content-disposition", attachment);
                //    Response.ContentType = "application/ms-excel";
                //    Response.WriteFile(Server.MapPath("/indicadores") + "/" + name);
                //    lblMesajeError.Visible = false;
                //    Response.End();
                //}
                //catch (Exception ex)
                //{
                //    lblMesajeError.Text = ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace;
                //    lblMesajeError.Visible = true;
                //}
            }
        }
}