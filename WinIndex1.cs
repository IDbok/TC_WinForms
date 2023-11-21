
namespace TC_WinForms
{
    public partial class WinIndex1 : Form
    {
        public WinIndex1()
        {
            InitializeComponent();

        }

        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            try 
            { 
                txtName.Text = txtName.Text.Trim();
                txtSurname.Text = txtSurname.Text.Trim();
                if (txtName.Text.Length > 0 && txtSurname.Text.Length > 0)
                {
                    if (DataProcessing.Authorizator.IsUserExust(txtName.Text, txtSurname.Text))
                    {
                        gbxAuthorizationForm.Visible = false;
                        pnlControlPanel.Enabled = true;
                    }
                    else MessageBox.Show("Пользователь не найден!");
                }
                else MessageBox.Show("Заполните все поля!");
            }
            catch { MessageBox.Show("Произошла ошибка при авторизации!"); }
        }
    }
}
