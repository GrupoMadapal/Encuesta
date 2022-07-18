using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Poleo.Objects;

namespace Poleo.DAL
{
    public class EncuestaDAL
    {
        public ISqlMapper mapper;
        public void InsertHEaderEncuesta(EncuestaHeader param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertNewHeaderEncuesta", param);
        }

        public void InsertAspectoLaboral(Encuesta_ASPECTOLABORAL param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertAspectoLaboral", param);
        }
        public EncuestaHeader SearchEncuesta(EncuestaHeader param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<EncuestaHeader>("SearchEncuesta", param);
        }
        public void InsertEncuesta_OportunidadLaboral(Encuesta_OportunidadLaboral param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertEncuesta_OportunidadLaboral", param);
        }
        public void InsertEncuesta_MOTIVOSPERSONALES_FAMILIARES(Encuesta_FamiliaresPersonales param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertEncuesta_MOTIVOSPERSONALES_FAMILIARES", param);
        }
        public void InsertEncuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertEncuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES", param);
        }

        public void InsertEncuesta_Footer(EncuestaFooter param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertEncuesta_Footer", param);
        }
        public Encuesta_ASPECTOLABORAL SearchAL(RecluFechas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Encuesta_ASPECTOLABORAL>("SearchAL", param);
        }

        public Encuesta_OportunidadLaboral SearchOPL(RecluFechas param)
        {
            mapper=Mapper.Instance();
            return mapper.QueryForObject<Encuesta_OportunidadLaboral>("SearchOPL",param);
        }

        public Encuesta_FamiliaresPersonales SearchFP(RecluFechas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Encuesta_FamiliaresPersonales>("SearchFP", param);
        }

        public Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES SearcEI(RecluFechas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForObject<Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES>("SearcEI", param);
        }

        public EncuestaFooter SearcEF(RecluFechas param)
        {
            mapper=Mapper.Instance();
            return mapper.QueryForObject<EncuestaFooter>("SearcEF", param);
        }
        public IList<EncuestaHeader> SearchHeader(RecluFechas param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<EncuestaHeader>("SearchHeader", param);
        }
    }
}