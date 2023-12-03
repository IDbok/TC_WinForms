using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_WinForms.DataProcessing;

namespace TC_WinForms
{
    internal static class WinProcessing
    {

        public static bool isDataToSave { get; set; } = false;
        private static void SaveData() 
        {

            // todo - save data from all forms
            Form[] allForms = Program.FormsBack.Concat(Program.FormsForward).ToArray();
            foreach (Form form in allForms)
            {
                if (form is Win2)
                { 
                    Win2 saveableForm = (Win2)form;
                    DataJsonSerializer.Serialize<TcData>(saveableForm.createdTcData, saveableForm.GetPath());
                }
            }
            //Form[] allForms = Program.FormsBack.Concat(Program.FormsForward).ToArray();
            //foreach (Form form in allForms)
            //{
            //    if (form is ISaveableForm)
            //    {
            //        ISaveableForm saveableForm = (ISaveableForm)form;
            //        DataJsonSerializer.Serialize(saveableForm.DataToSave(), saveableForm.GetPath());
            //    }
            //}
            MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool CloseAppMessage(FormClosingEventArgs e, out bool saveDate)
        {
            saveDate = false;
            bool closeApp = true;
            //if (Program.testMode) return closeApp;
            if (isDataToSave)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Сохранить промежуточные результаты перед выходом?", 
                    "Выход из программы", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) 
                { 
                    saveDate = true;
                    closeApp = true;
                }
                else if (dialogResult == DialogResult.No) closeApp = true;
                else closeApp = false;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) closeApp = false;
                
            }
            return closeApp;
        }
        public static void CloseingApp(FormClosingEventArgs e) 
        {
            bool closeApp = CloseAppMessage(e, out bool saveData);
            e.Cancel = !closeApp;
            if (saveData)
            {
                SaveData();
            }
            if (closeApp) Application.ExitThread();
        }
        // todo - ovverload colorization method with except buttons array (not change their color) (default olny one button)

        public static void ColorizeOnlyChosenButton(object sender, GroupBox gbx)
        {   
            foreach (Control btn2 in gbx.Controls)
            { btn2.BackColor = Color.FromArgb(255, 255, 255); }
            ColorizeChosenButton(sender, Color.FromArgb(128, 255, 191));
        }
        public static void ColorizeChosenButton(object sender, Color btnColor)
        {
            Button btn = (Button)sender;
            btn.BackColor = btnColor;
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control enableControl)
        {
            ColorizeBtnAndEnableControl(sender,  gbxButtons, new Control[] { enableControl });
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control[] enableControl)
        {
            WinProcessing.ColorizeOnlyChosenButton(sender, gbxButtons);
            foreach (Control control in enableControl) control.Enabled = true;
        }
        public static bool CheckAllTextBoxes(GroupBox gbx)
        {
            foreach (Control txt in gbx.Controls)
            {
                if (txt is TextBox)
                {
                    if (txt.Text == "")
                    {
                        MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }
        public static void NextFormBtn(Form newForm, Form thisForm)
        {
            Program.FormsBack.Add(thisForm);
            Program.MainForm = newForm;
            Program.MainForm.Show();
            thisForm.Hide();
        }
        public static void NextFormBtn(Form thisForm)
        {
            Program.FormsBack.Add(thisForm);
            Program.MainForm = Program.FormsForward.Last();
            Program.MainForm.Show();
            thisForm.Hide();
        }
        public static void BackFormBtn(Form thisForm)
        {
            Program.FormsForward.Add(thisForm);
            Program.MainForm = Program.FormsBack.Last();
            Program.FormsBack.RemoveAt(Program.FormsBack.Count - 1);
            Program.MainForm.Show();
            thisForm.Hide();
        }
    }
}
