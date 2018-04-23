using System;
using System.IO;
using OfficeOpenXml;
using Xunit;

namespace Binder.Extension.Test
{
    public class SingleModel
    {
        [Fact]
        public void BindToPocoModel()
        {
            //arrange
            var outputPath = Path.Combine( TestHelper.EmptyFolder, "BindToPocoModel.xlsx");
            var outputFile = new FileStream(outputPath,FileMode.CreateNew,FileAccess.Write,FileShare.Read);
            FileInfo fs = new FileInfo(Path.Combine(TestHelper.TestAssetsFolder,"OneField.xlsx"));
            using (ExcelPackage excelPackage = new ExcelPackage(fs))
            {
                var myWorksheet = excelPackage.Workbook.Worksheets[1];

                
                // (1)
                myWorksheet.Cells[7, 3].Value = myWorksheet.Cells[7, 3].Value.ToString().Replace("{NUMB}", "replace Numb");
                // (2)
                myWorksheet.Cells[7, 5].Value = 10; 
                // (3)
                myWorksheet.Cells[8, 3].Value = "TEST"; 

                excelPackage.SaveAs(outputFile);
            }
            //act
            
            //assert
            
        }
    }
}