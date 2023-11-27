using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using TC_WinForms.Models;

namespace TC_WinForms
{
    internal static class Program
    {
        public static bool testMode = true;//false;//
        public static Form MainForm { get; set; }

        public static bool dataToSave = false;//true;//

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            int row;
            List<string> values;
            using (var package = new ExcelPackage(new FileInfo(@"C:\Users\bokar\OneDrive\Работа\Таврида\Технологические карты\Пример\ТК_ТТ_v4.0_Уфа.xlsx")))
            {
                int columnRow = 33;
                int i = 4;
                string columnName = "№";
                var worksheet = package.Workbook.Worksheets["ТК_1.4.1"];
                ExcelRange rowCells = worksheet.Cells[i, 1, i, 20];//[i, 1, i, 20];
                int[] columns = {1,2,4,5,7 };
                values = GetCellValue(rowCells, columns);
                //MessageBox.Show(mapper.ToString());
                //var ans = mapper.FindColumn(columnName, columnRow, worksheet);
            }
            foreach (string value in values)
            {
                MessageBox.Show(value);
            }
            //ApplicationConfiguration.Initialize();
            //MainForm = new WinExParser();
            //Application.Run(MainForm);
            List<string> GetCellValue(ExcelRange rowCells, int[] columns) //int row, int column, ExcelWorksheet worksheet)
            {
                columns[columns.Length-1] = 172;
                List<string> values = new List<string>();
                foreach (var item in columns)
                {
                    values.Add(rowCells[6, item].Value?.ToString()?.Trim() ?? "");
                }
                return values;
            }
        }

    }
}