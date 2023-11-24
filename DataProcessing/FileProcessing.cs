using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_WinForms.DataProcessing
{
    internal static class FileProcessing
    {
        // public static string filepath = @"C:\Users\bokar\OneDrive\Работа\Таврида\Технологические карты\Пример\ТК_ТТ_v4.0_Уфа — копия.xlsx";//@"C:\Users\bokar\Documents\ТК.xlsx";
        // public static string jsonCatalog = @"Temp\Cards";
        // create an delegate to print messages
        static Action<string> PrintMessage = (string message) => { Console.WriteLine(message); };

        public static List<string> GetSheetsNamesWithTC(string filepath)
        {
            List<string> sheetsTC = new List<string>();
            if (File.Exists(filepath))
            {
                try
                {
                    sheetsTC = GetSheetsNames(filepath, "ТК_");
                }
                catch (System.IO.IOException ex)
                {
                    PrintMessage("Произошла ошибка. Проверьте закрыт ли обрабатываемый файл.\n(" + ex + ")");
                }
                catch (Exception) { PrintMessage("Произошла ошибка при открытии файла."); }
            }
            else PrintMessage("Файл по указаному пути не найден!");
            return sheetsTC;
        }
        public static List<string> GetSheetsNames(string filepath, string? nameContains = null )
        {
            List<string> sheetsTK = new();

            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                foreach (var ws in package.Workbook.Worksheets)
                {
                    // if nameContains is null then return all sheets
                    if (nameContains == null ? true : ws.Name.ToString().Contains(nameContains)) 
                        sheetsTK.Add(ws.Name);
                }
            }
            return sheetsTK;
        }
    }
}
