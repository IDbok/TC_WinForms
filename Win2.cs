
namespace TC_WinForms
{
    public partial class Win2 : Form
    {
        static string titleTC = "Технологическая карта";

        public Win2()
        {
            InitializeComponent();

        }
        private void Win2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            Program.MainForm.Show();
        }

        private void btnTcTransPoint_Click(object sender, EventArgs e)
        {

        }

        private void Win2_Load(object sender, EventArgs e)
        {

        }
    }
}
