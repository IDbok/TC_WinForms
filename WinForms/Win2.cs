

using TC_WinForms.DataProcessing;

namespace TC_WinForms
{
    public partial class Win2 : Form//, ISaveableForm
    {
        static string titleTC = "Технологическая карта";
        public string ProjectType { get; set; }
        public TcData createdTcData;
        public string GetPath() => @"Temp\ProjectData.json";
        public TcData DataToSave()
        {
            return createdTcData;
        }
        public Win2()
        {
            InitializeComponent();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UpdateProjectData();
            WinProcessing.BackFormBtn(this);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            bool dataCompleted = WinProcessing.CheckAllTextBoxes(gbxProjectData);
            if (dataCompleted)
            {
                UpdateProjectData();
                WinProcessing.NextFormBtn(new Win4(), this);
            }
        }
        private void Win2_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinProcessing.CloseingApp(e);
        }
        private Control[] GetEnableAfterChoise() => new Control[] { gbxProjectData, btnNext };
        private void btnTcTransPoint_Click(object sender, EventArgs e)
        {
            newProjectCreation(sender);
        }

        private void btnTcOilSub_Click(object sender, EventArgs e)
        {
            newProjectCreation(sender);
        }

        private void btnOpenSwitchgear_Click(object sender, EventArgs e)
        {
            newProjectCreation(sender);
        }


        private void newProjectCreation(object sender)
        {
            Button btn = (Button)sender;
            ProjectType = btn.Text;
            FillProjectData();
            WinProcessing.ColorizeBtnAndEnableControl(sender, gbxFunctionalityChoice, GetEnableAfterChoise());
        }
        private void FillProjectData()
        {
            createdTcData = new();
            txtProjectNum.Text = createdTcData.ProjectNumber;
            txtProjectOperator.Text = createdTcData.ProjectAuthorName + " " + createdTcData.ProjectAuthorSurname;
            txtProjectCreationDate.Text = createdTcData.ProjectDateCreated;
            txtProjectVersion.Text = createdTcData.ProjectVersion;

            WinProcessing.isDataToSave = true;
        }
        private void UpdateProjectData()
        {
            if (createdTcData != null)
            {
                createdTcData.ProjectType = ProjectType;
                createdTcData.ProjectNumber = txtProjectNum.Text;
                createdTcData.ProjectName = txtProjectName.Text;
                createdTcData.ProjectAuthorName = txtProjectOperator.Text;
                createdTcData.ProjectDateCreated = txtProjectCreationDate.Text;
                createdTcData.ProjectVersion = txtProjectVersion.Text;
            }
        }


        // fullfilling project data
        // when all data is filled, btnNext becomes enabled


    }
}
