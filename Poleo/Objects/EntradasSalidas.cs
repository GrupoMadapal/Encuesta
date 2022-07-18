using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class EntradasSalidas
    {
        private String numeroFactura = String.Empty;
        public String NumeroFactura
        {
            get { return numeroFactura; }
            set { numeroFactura = value; }
        }

        private Decimal cantidad = 0;
        public Decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private Decimal totalFactura = 0;
        public Decimal TotalFactura
        {
            get { return totalFactura; }
            set { totalFactura = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int idEntradaSalida = 0;
        public int IdEntradaSalida
        {
            get { return idEntradaSalida; }
            set { idEntradaSalida = value; }
        }

        private Boolean tipo = false;
        public Boolean Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private String location_Code_Origen = String.Empty;
        public String Location_Code_Origen
        {
            get { return location_Code_Origen; }
            set { location_Code_Origen = value; }
        }

        private String location_Code_Destino = String.Empty;
        public String Location_Code_Destino
        {
            get { return location_Code_Destino; }
            set { location_Code_Destino = value; }
        }

        private String vendedorName = String.Empty;
        public String VendedorName
        {
            get { return vendedorName; }
            set { vendedorName = value; }
        }

        private String vendedorCode = String.Empty;
        public String VendedorCode
        {
            get { return vendedorCode; }
            set { vendedorCode = value; }
        }

        private Boolean autorizado = false;
        public Boolean Autorizado
        {
            get { return autorizado; }
            set { autorizado = value; }
        }

        private Boolean recibido = false;
        public Boolean Recibido
        {
            get { return recibido; }
            set { recibido = value; }
        }

        private Boolean enviado = false;
        public Boolean Enviado
        {
            get { return enviado; }
            set { enviado = value; }
        }

        private String observaciones = String.Empty;
        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

       


    }
}