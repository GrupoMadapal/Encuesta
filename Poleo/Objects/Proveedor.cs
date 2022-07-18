using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public enum TipoProveedor
    {
        SUMINISTROS,
        SERVICIOS,
        PUBLICIDAD,
        INSUMOS,
        DEFAULT
    }
    public class Proveedor
    {
        private int idProveedor = 0;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private String nombre = String.Empty;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String rFC = String.Empty;

        public String RFC
        {
            get { return rFC; }
            set { rFC = value; }
        }
        private int vigencia = 0;

        public int Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }
        private String cuenta = String.Empty;

        public String Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
        private Boolean activo = false;

        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        private String tipo = String.Empty;

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


    }
}