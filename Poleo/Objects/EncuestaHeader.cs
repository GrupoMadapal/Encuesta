using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class EncuestaHeader
    {
        private int idencuesta;
        public int IdEncuesta
        {
            get { return idencuesta; }
            set { idencuesta = value; }
        }
        private String nombre = String.Empty;
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private String puesto = String.Empty;
        public String Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }

        private String nombrejefe = String.Empty;
        public String NombreJefe
        {
            get { return nombrejefe; }
            set { nombrejefe = value; }
        }

        private String puestojefe = String.Empty;
        public String PuestoJefe
        {
            get { return puestojefe; }
            set { puestojefe = value; }
        }

        private String marca = String.Empty;
        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private String sucursal_departamento = String.Empty;
        public String Sucursal_Departamento
        {
            get { return sucursal_departamento; }
            set { sucursal_departamento = value; }
        }

        private DateTime ingreso;
        public DateTime Ingreso
        {
            get { return ingreso; }
            set { ingreso = value; }
        }

        private DateTime salida;
        public DateTime Salida
        {
            get { return salida; }
            set { salida = value; }
        }

        private string razon = string.Empty;
        public string Razon
        { 
            get { return razon; }
            set { razon = value; }
        }
        private DateTime fechaencuesta;
        public DateTime FechaEncuesta
        {
            get { return fechaencuesta; }
            set { fechaencuesta = value; }
        }
    }
}