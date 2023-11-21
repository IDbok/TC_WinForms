using TC_WinForms.Models;

namespace TC_WinForms
{
    internal static class Program
    {

        static Dictionary<string, EModelType> keyValuePairs = new()
        {
            { "1. Требования к составу бригады и квалификации", EModelType.Staff },
            { "2. Требования к материалам и комплектующим", EModelType.Component },
            { "3. Требования к механизмам", EModelType.Machine },
            { "4. Требования к средствам защиты", EModelType.Protection },
            { "5. Требования к инструментам и приспособлениям", EModelType.Tool },
            { "6. Выполнение работ", EModelType.WorkStep }
        };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new ExParserMain());
            Application.Run(new WinIndex1());
        }
    }
}