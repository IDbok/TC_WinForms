using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using TC_WinForms.WinForms;
using TcModels.Models;

namespace TC_WinForms
{
    internal static class Program
    {
        public static bool testMode = true; //false;//
        public static Form MainForm { get; set; }
        public static List<Form> FormsBack { get; set; } = new List<Form>();
        public static List<Form> FormsForward { get; set; } = new List<Form>();
        public static List<TechnologicalCard> ExistingCatds { get; set; } = new List<TechnologicalCard>();
        public static List<TechnologicalProcess> ExistingProcces { get; set; } = new List<TechnologicalProcess>();
        public static TechnologicalCard? CurrentTc { get; set; }
        public static TechnologicalProcess CurrentTp { get; set; }
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            MainForm = new Win6(new Button { Name = "btnUpdateTC" /*"btnAddNewTC"*/ });//new Win1();//new Win3();//
            Application.Run(MainForm);
        }

    }
}