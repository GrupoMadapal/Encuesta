using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class FacturasFinder
    {
        private String nombreEmpresa = String.Empty;

        public String NombreEmpresa
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }
        private String nombreProveedor = String.Empty;

        public String NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }
        private Nullable<DateTime> fechaFacturaIni=null;

        public Nullable<DateTime> FechaFacturaIni
        {
            get { return fechaFacturaIni; }
            set { fechaFacturaIni = value; }
        }
        private Nullable<DateTime> fechaFacturaEnd = null;

        public Nullable<DateTime> FechaFacturaEnd
        {
            get { return fechaFacturaEnd; }
            set { fechaFacturaEnd = value; }
        }
        private Nullable<DateTime> fechaVencimientoIni = null;

        public Nullable<DateTime> FechaVencimientoIni
        {
            get { return fechaVencimientoIni; }
            set { fechaVencimientoIni = value; }
        }
        private Nullable<DateTime> fechaVencimientoEnd = null;

        public Nullable<DateTime> FechaVencimientoEnd
        {
            get { return fechaVencimientoEnd; }
            set { fechaVencimientoEnd = value; }
        }
        private Nullable<DateTime> fechaPagoIni = null;

        public Nullable<DateTime> FechaPagoIni
        {
            get { return fechaPagoIni; }
            set { fechaPagoIni = value; }
        }
        private Nullable<DateTime> fechaPagoEnd = null;

        public Nullable<DateTime> FechaPagoEnd
        {
            get { return fechaPagoEnd; }
            set { fechaPagoEnd = value; }
        }
        private String folio = String.Empty;

        public String Folio
        {
            get { return folio; }
            set { folio = value; }
        }
        private String folioFiscal = String.Empty;

        public String FolioFiscal
        {
            get { return folioFiscal; }
            set { folioFiscal = value; }
        }
        private String estatusFactura = String.Empty;

        public String EstatusFactura
        {
            get { return estatusFactura; }
            set { estatusFactura = value; }
        }
        private String tipoProveedor = String.Empty;

        public String TipoProveedor
        {
            get { return tipoProveedor; }
            set { tipoProveedor = value; }
        }
        private bool activo = false;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

    }
}