using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace OfficeOpenXml.Binder.Extension
{
    public static class OfficeOpenXmlExtension
    {
        private static ConditionalWeakTable<ExcelWorksheet,IDictionary<string,BindingCell>> BindingCache = new ConditionalWeakTable<ExcelWorksheet, IDictionary<string, BindingCell>>();

        public static void Bind(this ExcelWorksheet excelWorkSheet,object obj)
        {
            var bindingDict = BindingCache.GetOrCreateValue(excelWorkSheet);
            if (bindingDict.Count == 0)
                ScanWorksheetForBindings(ref bindingDict,ref excelWorkSheet);

        }

        private static void ScanWorksheetForBindings(ref IDictionary<string, BindingCell> bindingDictionary,
            ref ExcelWorksheet excelWorksheet)
        {
            for (var r = excelWorksheet.Dimension.Start.Row; r <= excelWorksheet.Dimension.End.Row ; r++){
                for (var c = excelWorksheet.Dimension.Start.Column; c <= excelWorksheet.Dimension.End.Column; c++)
                {
                    var s = excelWorksheet.Cells[r, c].ToString();
                    if(!string.IsNullOrEmpty(s))
                        Regex.IsMatch(s,"")
                }
                
            }
            
        }

        private class BindingCell
        {
            
        }
    }
}
