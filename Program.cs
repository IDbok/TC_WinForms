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
            ApplicationConfiguration.Initialize();
            //MainForm = new Win1();
            MainForm = new WinExParser();
            Application.Run(MainForm);
        }
    }
}