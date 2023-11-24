using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_WinForms
{
    internal static class WinProcessing
    {
        
        public static bool CloseAppMessage(FormClosingEventArgs e, out bool saveDate)
        {
            saveDate = false;
            bool closeApp = true;
            if (Program.testMode) return closeApp;
            if (Program.dataToSave)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Сохранить промежуточные результаты перед выходом?", 
                    "Выход из программы", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) saveDate = true;
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
                // todo - save data before closing
            }
            if (closeApp) Application.ExitThread();
        }

        public static void ColorizeChosenButton(object sender, GroupBox gbx)
        {
            Button btn = (Button)sender;
            foreach (Control btn2 in gbx.Controls)
            { btn2.BackColor = Color.FromArgb(255, 255, 255); }
            btn.BackColor = Color.FromArgb(128, 255, 191);
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control enableControl)
        {
            ColorizeBtnAndEnableControl(sender,  gbxButtons, new Control[] { enableControl });
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control[] enableControl)
        {
            WinProcessing.ColorizeChosenButton(sender, gbxButtons);
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
    }
}
