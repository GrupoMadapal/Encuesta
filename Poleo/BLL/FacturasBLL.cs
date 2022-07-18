using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Poleo.Objects;
using Poleo.DAL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Globalization;


namespace Poleo.BLL
{
    public enum EstadosFacturas
    {
        CANCELADA,              //ROJO #800000
        PAGADA,                 //VERDE #006E2E
        VENCIDA,                //AMARILLO #C79810
        SUPRIMIDA,              //PLATA #4B4B4B 
        PROXIMAVENCIMIENTO,     //AZUL #3F4C6B
        INACTIVA                //NARANJA #FFA500
    }
    public class FacturasBLL
    {

        public IList<Facturas> SelectFactura(Facturas param)
        {
            FacturasDAL objFacturasDAL = new FacturasDAL();
            return objFacturasDAL.SelectFactura(param);
        }
        public IList<Facturas> SelectFacturaChange(FacturasFinder param)
        {
            FacturasDAL objFacturasDAL = new FacturasDAL();
            return objFacturasDAL.SelectFacturaChange(param);
        }
        public int InsertFacturas(Facturas param)
        {
            FacturasDAL objFacturasDAL = new FacturasDAL();
            return objFacturasDAL.InsertFacturas(param);
        }

        public IList<Facturas> SelectFacturastoChange(Facturas param)
        {
            FacturasDAL objFacturasDAL = new FacturasDAL();
            return objFacturasDAL.SelectFacturastoChange(param);
        }
        public void ReadXMLInvoice(XmlDocument xmlDocInvoice)
        {
            DetalleFacturaBLL objDetalleFacturaBLL = new DetalleFacturaBLL();
            EmpresaBLL objEmpresaBLL = new EmpresaBLL();
            ProveedorBLL objProveedorBLL = new ProveedorBLL();
            Proveedor objProveedorFinder = new Proveedor();
            Empresa objEmpresaFinder = new Empresa();
            Facturas objFactura = new Facturas();
  
            if(xmlDocInvoice.HasChildNodes)
            {
                XmlNodeList xmlHeadlst = xmlDocInvoice.GetElementsByTagName("cfdi:Comprobante");
                if(xmlHeadlst[0].HasChildNodes)
                {
                   XmlNode xmlHead=  xmlHeadlst.Item(0);
                   objFactura.Folio =xmlHead.Attributes["folio"]==null? "N/A": xmlHead.Attributes["folio"].Value;
                   objFactura.Fecha_Factura = DateTime.Parse(xmlHead.Attributes["fecha"].Value);
                   objFactura.Fecha_Pago = objFactura.Fecha_Vigencia = null;
                   objFactura.Total_Factura = Decimal.Parse(xmlHead.Attributes["total"].Value);
                   objFactura.SubTotal = Decimal.Parse(xmlHead.Attributes["subTotal"].Value);
                   objFactura.Activo = false;
                   XmlAttribute xmlAttributeDescuento=xmlHead.Attributes["descuento"];
                   if (xmlAttributeDescuento != null)
                   {
                       objFactura.Descuentos = Decimal.Parse(xmlHead.Attributes["descuento"].Value);
                   }
                   objFactura.Estatus = EstadosFacturas.INACTIVA.ToString();
                   XmlNode nodeEmisor=  xmlHead.ChildNodes.Item(0);
                   if (nodeEmisor != null && nodeEmisor.Name == "cfdi:Emisor")
                   {
                        objProveedorFinder.RFC = nodeEmisor.Attributes["rfc"].Value;                           
                        IList<Proveedor> lstProveedor = objProveedorBLL.SelectEmpresabyRFC(objProveedorFinder);
                        if(lstProveedor.Count>0)
                        {
                            objProveedorFinder = lstProveedor[0];
                            if (objProveedorFinder.Activo)
                            {
                                objFactura.Fecha_Vigencia = objFactura.Fecha_Factura;
                               objFactura.Fecha_Vigencia= objFactura.Fecha_Vigencia.Value.AddDays(objProveedorFinder.Vigencia);
                                objFactura.Estatus = EstadosFacturas.PROXIMAVENCIMIENTO.ToString();
                                objFactura.Activo = true;
                            }
                        }
                        else 
                        {
                            objProveedorFinder.Nombre = nodeEmisor.Attributes["nombre"].Value;
                            objProveedorFinder.IdProveedor = objProveedorBLL.InsertEmpresa(objProveedorFinder);
                        }
                        objFactura.IdProveedor = objProveedorFinder.IdProveedor;
                   }                      
                   XmlNode nodeReceptor=  xmlHead.ChildNodes.Item(1);
                   if (nodeReceptor != null && nodeReceptor.Name == "cfdi:Receptor")
                   {
                        objEmpresaFinder.RFC = nodeReceptor.Attributes["rfc"].Value;
                        IList<Empresa> lstEmpresa = objEmpresaBLL.SelectEmpresabyRFC(objEmpresaFinder);
                        if(lstEmpresa.Count>0)
                        {
                            objEmpresaFinder = lstEmpresa[0];                                
                        }
                        else
                        {
                            objEmpresaFinder.Nombre = nodeReceptor.Attributes["nombre"].Value;
                            objEmpresaFinder.IdEmpresa = objEmpresaBLL.InsertEmpresa(objEmpresaFinder);
                        }
                        objFactura.IdEmpresa = objEmpresaFinder.IdEmpresa;                            
                    }                      
                    XmlNode nodeImpuestos = xmlHead.ChildNodes.Item(3);
                    if (nodeImpuestos != null && nodeImpuestos.Name == "cfdi:Impuestos")
                    {
                        if(nodeImpuestos.HasChildNodes)
                        {
                            foreach(XmlNode item in nodeImpuestos.ChildNodes)
                            {
                                if (item.Name == "cfdi:Retenciones")
                                {
                                    if(item.HasChildNodes)
                                    {
                                        foreach(XmlNode itemRet in item.ChildNodes)
                                        {
                                            if(itemRet.Attributes["impuesto"].Value=="IVA")
                                            {
                                                objFactura.RetencionIVA += Decimal.Parse(itemRet.Attributes["importe"].Value);
                                            }
                                            if (itemRet.Attributes["impuesto"].Value == "ISR")
                                            {
                                                objFactura.RetencionISR += Decimal.Parse(itemRet.Attributes["importe"].Value);
                                            }
                                        }
                                    }
                                }
                                if (item.Name == "cfdi:Traslados")
                                {
                                    if (item.HasChildNodes)
                                    {
                                        foreach (XmlNode itemRet in item.ChildNodes)
                                        {
                                            if (itemRet.Attributes["impuesto"].Value == "IVA")
                                            {
                                                objFactura.TrasladosIVA += Decimal.Parse(itemRet.Attributes["importe"].Value);
                                            }
                                            if (itemRet.Attributes["impuesto"].Value == "IEPS")
                                            {
                                                objFactura.TrasladosIEPS += Decimal.Parse(itemRet.Attributes["importe"].Value);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }                        
                    XmlNode nodeComplemento = xmlHead.ChildNodes.Item(4);
                    if (nodeComplemento!=null&&nodeComplemento.Name == "cfdi:Complemento")
                    {
                        if (nodeComplemento.HasChildNodes)
                        {
                            foreach(XmlNode itemchild in nodeComplemento.ChildNodes )
                            {
                                if(itemchild.Attributes["UUID"]!=null)
                                {
                                    objFactura.FolioFiscal = itemchild.Attributes["UUID"].Value;
                                }
                            }
                            
                        }

                    }
                    IList<Facturas> lstFacturas = this.SelectFactura(objFactura);
                    if (lstFacturas.Count == 0)
                    {
                        objFactura.IdFactura = this.InsertFacturas(objFactura);
                    }
                    else
                    {
                        objFactura = lstFacturas[0];
                    }
                    if (objFactura.IdFactura > 0)
                    {
                        XmlNode nodeConceptos = xmlHead.ChildNodes.Item(2);
                        if (nodeConceptos != null && nodeConceptos.Name == "cfdi:Conceptos")
                        {
                            if (nodeImpuestos.HasChildNodes)
                            {
                                foreach (XmlNode item in nodeConceptos.ChildNodes)
                                {
                                  String  strProducto = item.Attributes["descripcion"].Value;
                                  if (strProducto.Length > 249)
                                        {
                                            strProducto = item.Attributes["descripcion"].Value.Substring(0, 248);
                                        }
                                        
                                    DetallesFactura objDetalleFactura = new DetallesFactura()
                                    {
                                        IdFactura = objFactura.IdFactura,
                                        Cantidad = Decimal.Parse(item.Attributes["cantidad"].Value),
                                        UnidadMedida = item.Attributes["unidad"].Value,
                                        Producto=strProducto,
                                        PrecioUnitario = Decimal.Parse(item.Attributes["valorUnitario"].Value),
                                        Importe = Decimal.Parse(item.Attributes["importe"].Value)

                                    };
                                    if (objDetalleFacturaBLL.SelectDetallesFactura(objDetalleFactura).Count == 0)
                                    {
                                        objDetalleFacturaBLL.InsertDetallesFactura(objDetalleFactura);
                                    }
                                }
                            }

                        }

                    }
                        
                }

            }

        }

        public void UpdateFacturas(Facturas param)
        {
            FacturasDAL objFacturasDAL = new FacturasDAL();
            objFacturasDAL.UpdateFacturas(param);
        }
        public String GenerateExcelFacturas(IList<Facturas> lstFacturas, HttpServerUtility server,FacturasFinder objFacturaFinder)
        {
            String nombreArchivo = string.Empty;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp != null)
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorksheet=null;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                String nameProveedor = String.Empty;
                String nameEmpresa=String.Empty;
                String tipoProveedor=String.Empty;
                Decimal totalEmpresa = 0, TotalProveedor = 0;
                int row=4, col=1;
                foreach (Facturas item in lstFacturas)
                {
                    if(nameEmpresa!=item.Empresa)
                    {
                        if (xlWorksheet != null)
                        {
                            xlWorksheet.Cells[row - 1, col + 6] = (Decimal)TotalProveedor;
                            xlWorksheet.Cells[row, col + 4] = "TOTAL";
                            xlWorksheet.Cells[row, col + 5] = (Decimal)totalEmpresa;
                            xlWorksheet.Cells[row, col + 6] = (Decimal)totalEmpresa;
                            totalEmpresa=0;
                        }
                        xlWorksheet = this.CreateWorksSheet(xlWorkBook, item, objFacturaFinder.FechaVencimientoIni, objFacturaFinder.FechaVencimientoEnd);
                        nameEmpresa = item.Empresa;
                        nameProveedor = String.Empty;
                        tipoProveedor = String.Empty;
                        row = 4;
                        totalEmpresa = 0;
                        TotalProveedor = 0;
                    }
                    if (tipoProveedor != item.TipoProveedor)
                    {
                        if (!String.IsNullOrEmpty(nameProveedor))
                        {
                            xlWorksheet.Cells[row - 1, col + 6] = (Decimal)TotalProveedor;
                            TotalProveedor = 0;
                        }
                        Excel.Range objRange = xlWorksheet.Range["A" + row.ToString(), "E" + row.ToString()];
                        objRange.Merge();
                        objRange.Value = "PAGOS PROVEEDORES DE "+item.TipoProveedor;
                        objRange.Font.Size = 14;
                        objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        tipoProveedor = item.TipoProveedor;
                        row++;                       
                    }
                    if(nameProveedor!=item.Proveedor)
                    {
                        nameProveedor = item.Proveedor;
                    }
                    xlWorksheet.Cells[row, col ] = item.Proveedor.ToUpper();
                    xlWorksheet.Cells[row, col + 1] = item.Folio;
                    xlWorksheet.Cells[row, col + 2] = "";
                    xlWorksheet.Cells[row, col + 3] = item.Fecha_Factura.ToShortDateString();
                    xlWorksheet.Cells[row, col + 4] = item.Fecha_Vigencia.Value.ToShortDateString();
                    xlWorksheet.Cells[row, col + 5] = (Decimal)item.Total_Factura;
                    row++;
                    TotalProveedor += item.Total_Factura;
                    totalEmpresa += item.Total_Factura;               
                }
                xlWorksheet.Cells[row - 1, col + 6] = (Decimal)TotalProveedor;
                xlWorksheet.Cells[row, col + 4] = "TOTAL";
                xlWorksheet.Cells[row, col + 5] = (Decimal)totalEmpresa;
                xlWorksheet.Cells[row, col + 6] = (Decimal)totalEmpresa;
                totalEmpresa = 0;
                nombreArchivo = "ProgramacionPagos.xlsx";
                if (File.Exists(server.MapPath("/indicadores") + "/" + nombreArchivo))
                {
                    File.Delete(server.MapPath("/indicadores") + "/" + nombreArchivo);
                }
                xlWorkBook.SaveAs(server.MapPath("/indicadores") + "/" + nombreArchivo, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return nombreArchivo;

        }
        public Excel.Worksheet CreateWorksSheet(Excel.Workbook xlWorkBook,Facturas itemFactura,Nullable<DateTime> fechaIni,Nullable<DateTime>fechaEnd)
        {
            Excel.Worksheet objWorkSheet = xlWorkBook.Worksheets.Add();
            objWorkSheet.Name = itemFactura.Empresa.ToUpper();
            //Nombre de la empresa
            Excel.Range objRange = objWorkSheet.Range["A1", "G1"];
                objRange.Merge();
                objRange.Value = itemFactura.Empresa.ToUpper(); 
                objRange.Font.Size = 24;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            // FECHA DEL ARCHIVO
            objRange = objWorkSheet.Range["A2", "G2"];
                objRange.Merge();
                if (fechaIni != null && fechaEnd != null)
                {
                    objRange.Value = "PAGOS A REALIZAR EN LA SEMANA DEL " + fechaIni.Value.ToShortDateString() + " AL " + fechaEnd.Value.ToShortDateString();
                }
                else
                {
                    objRange.Value = "PAGOS A REALIZAR EN LA SEMANA ";
                }
                objRange.Font.Size = 18;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            // ENCABEZADOS DE LA HOJA                
            objRange = objWorkSheet.Range["A3", "A3"];
                objRange.Merge();
                objRange.Value = "PROVEEDOR";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 35;

                objRange = objWorkSheet.Range["B3", "B3"];
                objRange.Merge();
                objRange.Value = "FACTURA";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 15;

                objRange = objWorkSheet.Range["C3", "C3"];
                objRange.Merge();
                objRange.Value = "PRODUCTO/SERVICIO";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 35;

                objRange = objWorkSheet.Range["D3", "D3"];
                objRange.Merge();
                objRange.Value = "FECHA DE FACTURACIÓN";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 18;

                objRange = objWorkSheet.Range["E3", "E3"];
                objRange.Merge();
                objRange.Value = "FECHA DE VENCIMIENTO";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 18;

                objRange = objWorkSheet.Range["F3", "F3"];
                objRange.Merge();
                objRange.Value = "IMPORTE";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 15;

                objRange = objWorkSheet.Range["G3", "G3"];
                objRange.Merge();
                objRange.Value = "TOTAL";
                objRange.Font.Size = 12;
                objRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                objRange.ColumnWidth = 15;
            return objWorkSheet;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show ("Excepción ocurrió mientras que la liberación de objeto" + ex.ToString ());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}