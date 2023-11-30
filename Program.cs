using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using TC_WinForms.Models;

namespace TC_WinForms
{
    internal static class Program
    {
        public static bool testMode = true;//false;//
        public static Form MainForm { get; set; }
        public static List<Form> FormsBack { get; set; } = new List<Form>();
        public static List<Form> FormsForward { get; set; } = new List<Form>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            MainForm = new Win1();
            Application.Run(MainForm);

        }

    }
}