using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class Facturas
    {
        private int idFactura = 0;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private int idProveedor = 0;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private int idEmpresa = 0;

        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        private String folio = String.Empty;

        public String Folio
        {
            get { return folio; }
            set { folio = value; }
        }
        private DateTime fecha_Factura;

        public DateTime Fecha_Factura
        {
            get { return fecha_Factura; }
            set { fecha_Factura = value; }
        }
        private Nullable<DateTime> fecha_Vigencia = null;

        public Nullable<DateTime> Fecha_Vigencia
        {
            get { return fecha_Vigencia; }
            set { fecha_Vigencia = value; }
        }
        private Nullable<DateTime> fecha_Pago = null;

        public Nullable<DateTime> Fecha_Pago
        {
            get { return fecha_Pago; }
            set { fecha_Pago = value; }
        }
        private Decimal total_Factura = 0;

        public Decimal Total_Factura
        {
            get { return total_Factura; }
            set { total_Factura = value; }
        }
        private Decimal retencionIVA = 0;

        public Decimal RetencionIVA
        {
            get { return retencionIVA; }
            set { retencionIVA = value; }
        }
        private String estatus = String.Empty;

        public String Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
        private String folioFiscal = String.Empty;

        public String FolioFiscal
        {
            get { return folioFiscal; }
            set { folioFiscal = value; }
        }

        private Decimal trasladosIEPS = 0;

        public Decimal TrasladosIEPS
        {
            get { return trasladosIEPS; }
            set { trasladosIEPS = value; }
        }
        private Decimal descuentos = 0;

        public Decimal Descuentos
        {
            get { return descuentos; }
            set { descuentos = value; }
        }
        private Decimal retencionISR = 0;

        public Decimal RetencionISR
        {
            get { return retencionISR; }
            set { retencionISR = value; }
        }
        private Decimal trasladosIVA = 0;

        public Decimal TrasladosIVA
        {
            get { return trasladosIVA; }
            set { trasladosIVA = value; }
        }
        private Decimal subTotal = 0;

        public Decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }
        private String empresa = String.Empty;

        public String Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private String proveedor = String.Empty;

        public String Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }
        private Boolean activo = false;

        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        private String tipoProveedor = String.Empty;

        public String TipoProveedor
        {
            get { return tipoProveedor; }
            set { tipoProveedor = value; }
        }


        
    }
}