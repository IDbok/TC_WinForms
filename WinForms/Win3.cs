using TC_WinForms.WinForms;

namespace TC_WinForms
{
    public partial class Win3 : Form
    {
        public Win3()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WinProcessing.BackFormBtn(this);
        }

        private void Win3_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinProcessing.CloseingApp(e);
        }

        private void btnUpdateTC_Click(object sender, EventArgs e)
        {
            WinProcessing.NextFormBtn(new Win6(), this);
        }
    }
}
