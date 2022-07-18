using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Tools
{
    static public class ToolsTime
    {
        public static string ConvertSecondsToHMS(int Seconds)
        {
            int horas = (Seconds / 3600);
            int minutos = ((Seconds - horas * 3600) / 60);
            int segundos = (Seconds - (horas * 3600 + minutos * 60));
            return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        }

        public static string FormatHMS(string time)
        {
            string result, hh, mm, ss;
            string[] elements = time.Split(':');

            hh = elements[0];
            mm = elements[1];
            ss = elements[2];

            if (hh.Length < 2)
                hh = "0" + hh;

            if (mm.Length < 2)
                mm = "0" + mm;

            if (ss.Length < 2)
                ss = "0" + ss;

            result = hh + ":" + mm + ":" + ss;

            return result;
        }
    }
}