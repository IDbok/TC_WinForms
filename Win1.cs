
using static TC_WinForms.DataProcessing.Authorizator;

namespace TC_WinForms
{
    public partial class Win1 : Form
    {
        bool testMode = true;//false;//
        private void TestMode()
        {
            gbxAuthorizationForm.Visible = false;
            pnlControlPanel.Enabled = true;
        }

        bool isTcDesign = false;
        bool isTcEditng = false;
        public Win1()
        {
            InitializeComponent();
            if (testMode) TestMode();

            // realise pattern Model-View-ViewModel

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
            //activation Win2 form and hide Win1 form
            if (isTcDesign)
            {
                Win2 win2 = new Win2();
                win2.Show();
            }
            else if (isTcEditng)
            {
                Win3 win3 = new Win3();
                win3.Show();
            }
            this.Hide();
            // todo - make app closable from other forms

        }

        private void PerformAuthorization()
        {
            try
            {
                txtName.Text = txtName.Text.Trim();
                txtSurname.Text = txtSurname.Text.Trim();
                if (txtName.Text.Length > 0 && txtSurname.Text.Length > 0)
                {
                    if (IsUserExust(txtName.Text, txtSurname.Text))
                    {
                        MessageBox.Show($"Авторизация прошла успешно!\nДобро пожаловать, {AuthUserName()}!");
                        gbxAuthorizationForm.Visible = false;
                        pnlControlPanel.Enabled = true;
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
            Colorize(sender);
            btnNext.Enabled = true;
        }
        private void Colorize(object sender)
        {
            Button btn = (Button)sender;
            //btn.BackColor = Color.FromArgb(128, 255, 191);
            foreach (Control btn2 in gbxFunctionalityChoice.Controls)
            { btn2.BackColor = Color.FromArgb(255, 255, 255); }
            btn.BackColor = Color.FromArgb(128, 255, 191);

            //if (btn.Name == "btnTcDesign") btnTcEditng.BackColor = Color.FromArgb(255, 255, 255);
            //else if (btn.Name == "btnTcEditng") btnTcDesign.BackColor = Color.FromArgb(255, 255, 255);
        }

    }
}
