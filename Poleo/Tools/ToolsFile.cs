using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Excel = Microsoft.Office.Interop.Excel;

namespace Poleo.Tools
{
    public class ToolsFile
    {
        public static void SaveFileExcel(Excel.Workbook ExcelBook, string Dir)
        {
            ExcelBook.SaveAs(Dir, Excel.XlFileFormat.xlWorkbookDefault, string.Empty, string.Empty, string.Empty, string.Empty, Excel.XlSaveAsAccessMode.xlShared, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }
    }
}