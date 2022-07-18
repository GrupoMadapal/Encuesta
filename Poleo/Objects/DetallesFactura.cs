using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DetallesFactura
    {
        private int idDetalleFactura = 0;

        public int IdDetalleFactura
        {
            get { return idDetalleFactura; }
            set { idDetalleFactura = value; }
        }
        private int idFactura = 0;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private String producto = String.Empty;

        public String Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        private Decimal cantidad = 0;

        public Decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private Decimal precioUnitario = 0;

        public Decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }
        private String unidadMedida = String.Empty;

        public String UnidadMedida
        {
            get { return unidadMedida; }
            set { unidadMedida = value; }
        }
        private Decimal importe = 0;

        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

    }
}