using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Poleo.Tools;

namespace Poleo.Objects
{
    public class Ranking
    {

        private String tienda = String.Empty;
        public String Tienda
        {
            get { return tienda; }
            set { tienda = value; }
        }

        private Decimal ventasLastYear = 0;
        public Decimal VentasLastYear
        {
            get { return ventasLastYear; }
            set { ventasLastYear = value; }
        }

        private Decimal ventas = 0;
        public Decimal Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }
        
        private int ordenesLastYear = 0;
        public int OrdenesLastYear
        {
            get { return ordenesLastYear; }
            set { ordenesLastYear = value; }
        }

        private int ordenes = 0;
        public int Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }

        private int totalAdicionales = 0;
        public int TotalAdicionales
        {
            get { return totalAdicionales; }
            set { totalAdicionales = value; }
        }

        private Decimal utilizadoReal = 0;
        public Decimal UtilizadoReal
        {
            get { return utilizadoReal; }
            set { utilizadoReal = value; }
        }

        private Decimal utilizadoPor = 0;
        public Decimal UtilizadoPor
        {
            get { return utilizadoPor; }
            set { utilizadoPor = value; }
        }

        private int numOrdenesMalas = 0;
        public int NumOrdenesMalas
        {
            get { return numOrdenesMalas; }
            set { numOrdenesMalas = value; }
        }

        private int NumOrdenesGratis = 0;
        public int NumOrdenesGratis1
        {
            get { return NumOrdenesGratis; }
            set { NumOrdenesGratis = value; }
        }

        private Decimal ventaOrdenesGratis = 0;
        public Decimal VentaOrdenesGratis
        {
            get { return ventaOrdenesGratis; }
            set { ventaOrdenesGratis = value; }
        }

        private int ordenesEntregaTime = 0;
        public int OrdenesEntregaTime
        {
            get { return ordenesEntregaTime; }
            set { ordenesEntregaTime = value; }
        }

        private int ordenesRunTime = 0;
        public int OrdenesRunTime
        {
            get { return ordenesRunTime; }
            set { ordenesRunTime = value; }
        }

        private int ordenesSalidaTienda = 0;
        public int OrdenesSalidaTienda
        {
            get { return ordenesSalidaTienda; }
            set { ordenesSalidaTienda = value; }
        }

        private Decimal tiempoEntrada = 0;
        public Decimal TiempoEntrada
        {
            get { return tiempoEntrada; }
            set { tiempoEntrada = value; }
        }

        private String nombre_tienda = String.Empty;
        public String Nombre_tienda
        {
            get { return nombre_tienda; }
            set { nombre_tienda = value; }
        }

        private Decimal ventasMalas = 0;
        public Decimal VentasMalas
        {
            get { return ventasMalas; }
            set { ventasMalas = value; }
        }

        private String tipoTienda = String.Empty;
        public String TipoTienda
        {
            get { return tipoTienda; }
            set { tipoTienda = value; }
        }

        public Decimal VentasProcentaje
        {
            get {
                if (VentasLastYear > 0)
                    return (Ventas / VentasLastYear) - 1;
                else
                    return 0;//Ventas - 1;
            }
        }
        public Decimal OrdenesPorcentaje
        {
            get {
                if ((Decimal)OrdenesLastYear > 0)
                    return ((Decimal)Ordenes / (Decimal)OrdenesLastYear) - 1;
                else
                    return 0;//(Decimal)Ordenes - 1;
            }
        }
        public Decimal TicketPromedio
        {
            //get { return Ventas / Ordenes; } - Modified by Hector Sanchez M. 20161205
            get {
                if (ordenes > 0)
                    return Ventas / ordenes;
                else
                    return 0;
            }
        }
        public Decimal Gratis
        {
            //get { return VentaOrdenesGratis / Ventas; } - Modified by Hector Sanchez M. 20161205
            get {
                if (Ventas > 0)
                    return VentaOrdenesGratis / Ventas;
                else
                    return 0;
            }
        }
        public Decimal ParticipacionAdicionales
        {
            //get { return (Decimal)((Decimal)TotalAdicionales / (Decimal)Ordenes); } - Modified by Hector Sanchez M. 20161205
            get {
                if ((Decimal)Ordenes > 0)
                    return (Decimal)((Decimal)TotalAdicionales / (Decimal)Ordenes);
                else
                    return 0;
            }
        }
        public String EntradaHorno
        {
            get {       
                    //            int tSegundos, min, seg;
                    //            tSegundos = (int)( TiempoEntrada * 60);
                    //            min = tSegundos / 60;
                    //            seg = tSegundos - (min * 60);
                    //            return min.ToString()+":"+seg.ToString();

                    //Modified by Hector Sanchez M. - 20160628
                    string HMS = string.Empty;
                    HMS = ToolsTime.ConvertSecondsToHMS((int)TiempoEntrada);
                    return HMS;
                }
        }
        public Decimal Entrega
        {
            //get { return (Decimal)((Decimal)OrdenesEntregaTime / (Decimal)OrdenesRunTime); } - Modified by Hector Sanchez M. - 20161205
            get {
                if ((Decimal)OrdenesRunTime > 0)
                    return (Decimal)((Decimal)OrdenesEntregaTime / (Decimal)OrdenesRunTime);
                else
                    return 0;
            }
        }
        public Decimal SalidaTienda

        {
            //get { return (Decimal)((Decimal)ordenesSalidaTienda / (Decimal)OrdenesRunTime); } - Modified by  Hector Sanchez M. - 20161205
            get {
                if ((Decimal)OrdenesRunTime > 0)
                    return (Decimal)((Decimal)ordenesSalidaTienda / (Decimal)OrdenesRunTime);
                else
                    return 0;
            }
        }
        public Decimal OrdenesMalas
        {
            //get { return (ventasMalas-VentaOrdenesGratis) / Ventas; } - Modified by Hector Sanchez M. - 20161205
            get {
                if (Ventas > 0)
                    return (ventasMalas - VentaOrdenesGratis) / Ventas;
                else
                    return 0;
            }
        }
        private int puntos = 0;

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        private int numSemana = 0;

        public int NumSemana
        {
            get { return numSemana; }
            set { numSemana = value; }
        }



    }
}  