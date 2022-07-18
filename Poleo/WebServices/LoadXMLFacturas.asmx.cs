using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.IO;
using Poleo.Objects;
using Poleo.BLL;
using System.Xml;
using System.Text;

namespace Poleo.WebServices
{
    /// <summary>
    /// Descripción breve de LoadXMLFacturas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class LoadXMLFacturas : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string UpLoadXML(String param)
        {
            String message = String.Empty;
            String strMessageError=String.Empty;
            int count = 0;
            try
            {
                String strLocationXML = ConfigurationManager.AppSettings["URLtoXML"].ToString();
                FacturasBLL objFacturasBLL = new FacturasBLL();
                DirectoryInfo dirInfo = new DirectoryInfo(strLocationXML);
                FileInfo[] fileNames = dirInfo.GetFiles("*.xml");
                subirListaArchivos(fileNames);
                count += fileNames.Count();
                DirectoryInfo[] Directories = dirInfo.GetDirectories();
                foreach (DirectoryInfo item in Directories)
                {
                    FileInfo[] fileDir1 = item.GetFiles("*.xml");
                    strMessageError+=subirListaArchivos(fileDir1);
                    count += fileDir1.Count();
                    DirectoryInfo[] Directoriesnivel2 = item.GetDirectories();
                    foreach (DirectoryInfo itemNivel2 in Directoriesnivel2)
                    {
                        FileInfo[] Nivel2 = itemNivel2.GetFiles("*.xml");
                        strMessageError+=subirListaArchivos(Nivel2);
                        count += Nivel2.Count();
                        DirectoryInfo[] Directoriesnivel3 = itemNivel2.GetDirectories();
                        foreach (DirectoryInfo itemNivel3 in Directoriesnivel3)
                        {
                            FileInfo[] Nivel3 = itemNivel3.GetFiles("*.xml");
                            strMessageError += subirListaArchivos(Nivel3);
                            count += Nivel3.Count();

                        }
                    }

                }
                message="Numero de archivos Procesados: "+count.ToString();
            }catch(Exception ex)
            {
                message = ex.Message;

            }
            return message + "/" + strMessageError;
        }
        private  String subirListaArchivos(FileInfo[] fileNames)
        {
            FacturasBLL objFacturasBLL = new FacturasBLL();
            String strErrorMessage = String.Empty;
            foreach (FileInfo item in fileNames)
            {
                try
                {
                    XmlDocument objXmlDocument = new XmlDocument();
                    using (StreamReader oReader = new StreamReader(item.FullName, Encoding.GetEncoding("ISO-8859-1")))
                    {
                        //xmlDoc = XDocument.Load(oReader);
                        objXmlDocument.Load(oReader);
                    }
                    objFacturasBLL.ReadXMLInvoice(objXmlDocument);
                }catch(Exception ex)
                {
                    //throw new Exception(ex.Message+item.FullName, ex);
                    strErrorMessage += "Error:" + ex.Message + "  File:" + item.Name+"/";
                }
            }
            return strErrorMessage;
        }
    }
}
