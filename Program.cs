using TC_WinForms.Models;

namespace TC_WinForms
{
    internal static class Program
    {

        static Dictionary<string, EModelType> keyValuePairs = new()
        {
            { "1. ���������� � ������� ������� � ������������", EModelType.Staff },
            { "2. ���������� � ���������� � �������������", EModelType.Component },
            { "3. ���������� � ����������", EModelType.Machine },
            { "4. ���������� � ��������� ������", EModelType.Protection },
            { "5. ���������� � ������������ � ���������������", EModelType.Tool },
            { "6. ���������� �����", EModelType.WorkStep }
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