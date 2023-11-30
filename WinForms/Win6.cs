
namespace TC_WinForms.WinForms
{
    public partial class Win6 : Form
    {
        public Win6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WinProcessing.BackFormBtn(this);
        }

        private void Win6_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinProcessing.CloseingApp(e);
        }
    }
}
