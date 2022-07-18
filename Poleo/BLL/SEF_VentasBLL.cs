using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.DAL;
using Poleo.Objects;

namespace Poleo.BLL
{
    public class SEF_VentasBLL
    {
        public InfoTiempoReal SelectVentasSEFOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectVentasSEFOnLine(Param);
        }

        public InfoTiempoReal SelectCobrosSEFOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectCobrosSEFOnLine(Param);
        }

        public InfoTiempoReal SelectVentasRAALOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectVentasRAALOnLine(Param);
        }

        public InfoTiempoReal SelectCobrosRAALOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectCobrosRAALOnLine(Param);
        }

        public InfoTiempoReal SelectVentasMADAPALOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectVentasMADAPALOnLine(Param);
        }

        public InfoTiempoReal SelectCobrosMADAPALOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectCobrosMADAPALOnLine(Param);
        }

        public InfoTiempoReal SelectCanceladoSEFOnLine(InfoTiempoReal Param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();

            return DAL.SelectCanceladoSEFOnLine(Param);
        }

        public IList<ContabilidadDP> selectDPContabilidad(Date param)
        {
            SEF_VentasDAL DAL = new SEF_VentasDAL();
            return DAL.SelectDPContabilidad(param);
        }
    }
}