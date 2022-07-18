using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Poleo.Objects;
using Poleo.DAL;
using System.Data;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;


namespace Poleo.BLL
{
    public class EncuestaBLL
    {
        public void InsertHEaderEncuesta(EncuestaHeader param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            DAL.InsertHEaderEncuesta(param);
        }
        public void InsertAspectoLaboral(Encuesta_ASPECTOLABORAL param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            DAL.InsertAspectoLaboral(param);
        }
        public EncuestaHeader SearchEncuesta(EncuestaHeader param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearchEncuesta(param);
        }
        public void InsertEncuesta_OportunidadLaboral(Encuesta_OportunidadLaboral param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            DAL.InsertEncuesta_OportunidadLaboral(param);

        }
        public void InsertEncuesta_MOTIVOSPERSONALES_FAMILIARES(Encuesta_FamiliaresPersonales param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            DAL.InsertEncuesta_MOTIVOSPERSONALES_FAMILIARES(param);
        }
        public void InsertEncuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES param)
        {
            EncuestaDAL DAL=new EncuestaDAL();
            DAL.InsertEncuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(param);
        }
        public void InsertEncuesta_Footer(EncuestaFooter param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            DAL.InsertEncuesta_Footer(param);
        }
        public Encuesta_ASPECTOLABORAL SearchAL(RecluFechas param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearchAL(param);
        }

        public Encuesta_OportunidadLaboral SearchOPL(RecluFechas param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearchOPL(param);
        }

        public Encuesta_FamiliaresPersonales SearchFP(RecluFechas param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearchFP(param);
        }

        public Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES SearcEI(RecluFechas param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearcEI(param);
        }
        public EncuestaFooter SearcEF(RecluFechas param)
        {
            EncuestaDAL DAL=new EncuestaDAL();
            return DAL.SearcEF(param);
        }

        public IList<EncuestaHeader> SearchHeader(RecluFechas param)
        {
            EncuestaDAL DAL = new EncuestaDAL();
            return DAL.SearchHeader(param);
        }

        
        

        public DataSet GetDataSourceReport(RecluFechas encuesta,EncuestaHeader encabezado)
        {
            IList<Encuesta_ASPECTOLABORAL> lstChecking_Expenses_Detail = new List<Encuesta_ASPECTOLABORAL>();
            EncuestaBLL encuestabll = new EncuestaBLL();
            Encuesta_ASPECTOLABORAL _ASPECTOLABORAL = new Encuesta_ASPECTOLABORAL();
            Encuesta_OportunidadLaboral encuesta_Oportunidad = new Encuesta_OportunidadLaboral();
            Encuesta_FamiliaresPersonales encuesta_FamiliaresPersonales = new Encuesta_FamiliaresPersonales();
            Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES encuesta_ESTUDIOS_U_OTROS_INTERESES_ = new Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES();
            EncuestaFooter encuestaFooter = new EncuestaFooter();

            

            _ASPECTOLABORAL = SearchAL(encuesta);
            encuesta_Oportunidad = SearchOPL(encuesta);
            encuesta_FamiliaresPersonales = SearchFP(encuesta);
            encuesta_ESTUDIOS_U_OTROS_INTERESES_ = SearcEI(encuesta);
            encuestaFooter = SearcEF(encuesta);

            DataSet DataSetReport = new DataSet();
            int table=0;
            if(encabezado!=null)
            {
                DataSetReport.Tables.Add(ObjectToData(encabezado));
                DataSetReport.Tables[table].TableName = "Cabecera";
                table += 1;
            }
            if (_ASPECTOLABORAL != null)
            {
                DataSetReport.Tables.Add(ObjectToData(_ASPECTOLABORAL));
                DataSetReport.Tables[table].TableName = "ASPECTOLABORAL";
                table += 1;
            }
            if(encuesta_Oportunidad!=null)
            {
                DataSetReport.Tables.Add(ObjectToData(encuesta_Oportunidad));
                DataSetReport.Tables[table].TableName = "Oportunidad";
                table += 1;
            }
            if (encuesta_FamiliaresPersonales != null)
            {
                DataSetReport.Tables.Add(ObjectToData(encuesta_FamiliaresPersonales));
                DataSetReport.Tables[table].TableName = "FamiliaresPersonales";
                table += 1;
            }
            if (encuesta_ESTUDIOS_U_OTROS_INTERESES_ != null)
            {
                DataSetReport.Tables.Add(ObjectToData(encuesta_ESTUDIOS_U_OTROS_INTERESES_));
                DataSetReport.Tables[table].TableName = "ESTUDIOS";
                table += 1;
            }
            if (encuestaFooter != null)
            {
                DataSetReport.Tables.Add(ObjectToData(encuestaFooter));
                DataSetReport.Tables[table].TableName = "encuestaFooter";
                table += 1;
            }

            return DataSetReport;
        }

        public static DataTable ObjectToData(object o)
        {
            DataTable dt = new DataTable("OutputData");

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(o, null);
                    dt.Columns.Add(f.Name, f.PropertyType);
                    dt.Rows[0][f.Name] = f.GetValue(o, null);
                }
                catch { }
            });
            return dt;
        }

    }
}