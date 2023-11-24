
namespace TC_WinForms
{
    public partial class Win2 : Form
    {
        static string titleTC = "Технологическая карта";

        public Win2()
        {
            InitializeComponent();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Program.MainForm.Show();
        }

        private void Win2_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinProcessing.CloseingApp(e);
        }
        private Control[] GetEnableAfterChoise() => new Control[] { gbxProjectData, btnNext };
        private void btnTcTransPoint_Click(object sender, EventArgs e)
        {
            WinProcessing.ColorizeBtnAndEnableControl(sender, gbxFunctionalityChoice, GetEnableAfterChoise());
        }

        private void btnTcOilSub_Click(object sender, EventArgs e)
        {
            WinProcessing.ColorizeBtnAndEnableControl(sender, gbxFunctionalityChoice, GetEnableAfterChoise());
        }

        private void btnOpenSwitchgear_Click(object sender, EventArgs e)
        {
            WinProcessing.ColorizeBtnAndEnableControl(sender, gbxFunctionalityChoice, GetEnableAfterChoise());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool dataCompleted = WinProcessing.CheckAllTextBoxes(gbxProjectData);
            if (dataCompleted)
            {
                // todo - save data win2 before closing
                new Win4().Show();
                this.Hide();
            }
        }

        // fullfilling project data
        // when all data is filled, btnNext becomes enabled


    }
}
