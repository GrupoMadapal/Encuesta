using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;

namespace Poleo.Tools
{
    public class ToolsControls
    {
        public static Button CreateBtnReport(XmlNode infoBtn)
        {
            Button btnReport = new Button();

            btnReport.CssClass = "elementes btnExcelText";
            //btnReport.BorderColor = Color.FromName("#137A0E");
            //btnReport.BackColor = Color.FromName("#8EA785");

            btnReport.ID = infoBtn.SelectSingleNode("ID").InnerText;
            btnReport.Text = infoBtn.SelectSingleNode("Text").InnerText;
            btnReport.Width = Unit.Parse(infoBtn.SelectSingleNode("Width").InnerText);
            btnReport.Height = Unit.Parse(infoBtn.SelectSingleNode("Height").InnerText);
            //btnReport.Click - TO_FIX - Pendiente: asignar evento dinamicamente, pasandole solo el nombre del metodo. Hector Sanchez M. 20161114

            return btnReport;
        }

        public static ImageButton CreateBtnImgReport(XmlNode infoImgBtn)
        {
            ImageButton btnImgReport = new ImageButton();

            btnImgReport.ImageUrl = infoImgBtn.SelectSingleNode("URL").InnerText;
            //btnImgReport.CssClass = "elementes";
            btnImgReport.Width = Unit.Parse("25px");
            btnImgReport.Height = Unit.Parse("22px");

            btnImgReport.ID = infoImgBtn.SelectSingleNode("ID").InnerText;

            return btnImgReport;
        }
    }
}