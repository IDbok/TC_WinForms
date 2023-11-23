using TC_WinForms.Models;

namespace TC_WinForms
{
    internal static class Program
    {
        public static Win1 MainForm { get; set; }

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
            MainForm = new Win1();
            Application.Run(MainForm);
        }
    }
}