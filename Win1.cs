
using static TC_WinForms.DataProcessing.Authorizator;

namespace TC_WinForms
{
    public partial class Win1 : Form
    {
        private void TestMode()
        {
            //Program.dataToSave = true;
            AfterAuthorization();
        }

        bool isTcDesign = false;
        bool isTcEditng = false;
        public Win1()
        {
            InitializeComponent();
            if (Program.testMode) TestMode();
        }

        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            PerformAuthorization();
        }

        private void btnTcDesign_Click(object sender, EventArgs e)
        {
            DisingOrEdingActive(sender);
        }
        private void btnTcEditng_Click(object sender, EventArgs e)
        {
            DisingOrEdingActive(sender);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (isTcDesign)
            {
                Win2 win2 = new Win2();
                win2.Show();
                this.Hide();
            }
            else if (isTcEditng)
            {
                Win3 win3 = new Win3();
                win3.Show();
                this.Hide();
            }

            // todo - make app closable from other forms

        }
        private void Win1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !WinProcessing.CloseAppMessage(e, out bool saveData);
            if (saveData)
            {
                // todo - save data before closing
            }
        }
        private void PerformAuthorization()
        {
            try
            {
                txtLogin.Text = txtLogin.Text.Trim();
                txtPassword.Text = txtPassword.Text.Trim();
                if (txtLogin.Text.Length > 0 && txtPassword.Text.Length > 0)
                {
                    if (IsUserExust(txtLogin.Text, txtPassword.Text))
                    {
                        AfterAuthorization();
                    }
                    else MessageBox.Show("Пользователь не найден!");
                }
                else MessageBox.Show("Заполните все поля!");
            }
            catch { MessageBox.Show("Произошла ошибка при авторизации!"); }
        }
        private void DisingOrEdingActive(object sender)
        {
            Button btn = (Button)sender;
            if (btn.Name == "btnTcDesign") isTcDesign = true;
            else if (btn.Name == "btnTcEditng") isTcDesign = false;
            isTcEditng = !isTcDesign;
            WinProcessing.ColorizeBtnAndEnableControl(sender, gbxFunctionalityChoice, btnNext);
        }

        private void AfterAuthorization()
        {
            gbxAuthorizationForm.Visible = false;
            pnlControlPanel.Enabled = true;
            gbxFunctionalityChoice.Enabled = true;
        }


    }
}
