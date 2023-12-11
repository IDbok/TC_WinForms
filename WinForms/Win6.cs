
using TC_WinForms.DataProcessing;
using TcModels.Models;
using TcModels.Models.TcContent;

namespace TC_WinForms.WinForms
{
    public partial class Win6 : Form
    {
        List<Staff> staffs = new();
        DbConnector db = new DbConnector();
        public Win6(object sender)
        {

            if (sender is not Button) this.Close();

            InitializeComponent();

            /////////////////////////////

            //Program.ExistingProcces = db.GetList<TechnologicalProcess>();
            //Program.CurrentTp = Program.ExistingProcces[0];
            //Program.ExistingCatds = Program.CurrentTp.TechnologicalCards;
            //Program.CurrentTc = Program.ExistingCatds[0];

            ////////////////////////////////////

            //todo - ???? maybe better make unable to change TechProcessName in this form

            foreach (var item in Program.ExistingProcces)
            {
                cmbTechProcessName.Items.Add(item.Name);
            }
            cmbTechProcessName.Text = Program.CurrentTp.Name;

            Button btn = (Button)sender;
            if (btn.Name == "btnUpdateTC")
            {
                db.UpdateCurrentTc(Program.CurrentTc.Id);

                foreach (var item in Program.ExistingCatds)
                {
                    cmbTechCardName.Items.Add(item.Article);
                }
                cmbTechCardName.Text = Program.CurrentTc.Article;
            }
            else if (btn.Name == "btnAddNewTC")
            {
                cmbTechCardName.Visible = false;
                pnlNavigationTC.Controls.Add(new Label() { Name = "lblNewTc", Text = "Артикул ТК:", Location = new Point(350, 8) });
                // todo - add сheck if tbxNewTcName.Text already exists in db
                pnlNavigationTC.Controls.Add(new TextBox() { Name = "tbxNewTcName", Location = new Point(450, 4), Size = new Size(180, 28) });

                Program.CurrentTc = new TechnologicalCard();
            }
            btnShowStaffs_Click(null, null);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            WinProcessing.BackFormBtn(this);
        }

        private void Win6_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinProcessing.CloseingApp(e);
        }

        private void cmbTechCardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.CurrentTc != null && Program.CurrentTc.Article == cmbTechCardName.Text) return;
            else
            {
                db.UpdateCurrentTc(Program.ExistingCatds[cmbTechCardName.SelectedIndex].Id);
                //MessageBox.Show("Выбрана новая ТК: " + Program.CurrentTc.Article);
                btnShowStaffs_Click(null, null);
            }
        }

        private void cmbTechProcessName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShowStaffs_Click(object sender, EventArgs e)
        {
            // todo - save changes in dgvTcObjects if they are
            DGVStaffStructure();

            staffs = Program.CurrentTc.Staffs;
            for (int i = 0; i < staffs.Count; i++)
            {
                dgvTcObjects.Rows.Add(i + 1, staffs[i].Name, staffs[i].Type, staffs[i].CombineResponsibility, staffs[i].Competence/*, staffs[i].Symbol*/); // todo - fix it
            }
        }

        private void btnShowComponents_Click(object sender, EventArgs e)
        {
            DGVNormalStructure();
            var obj = Program.CurrentTc.Components;
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(i + 1, obj[i].Name, obj[i].Type, obj[i].Unit, obj[i].Amount);
            }
        }

        private void btnShowMachines_Click(object sender, EventArgs e)
        {
            DGVNormalStructure();
            var obj = Program.CurrentTc.Machines;
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(i + 1, obj[i].Name, obj[i].Type, obj[i].Unit, obj[i].Amount);
            }
        }

        private void btnShowProtections_Click(object sender, EventArgs e)
        {
            DGVNormalStructure();
            var obj = Program.CurrentTc.Protections;
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(i + 1, obj[i].Name, obj[i].Type, obj[i].Unit, obj[i].Amount);
            }
        }

        private void btnShowTools_Click(object sender, EventArgs e)
        {
            DGVNormalStructure();
            var obj = Program.CurrentTc.Tools;
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(i + 1, obj[i].Name, obj[i].Type, obj[i].Unit, obj[i].Amount);
            }
        }

        private void btnShowWorkSteps_Click(object sender, EventArgs e)
        {
            DGVWorkStepStructure();
        }
        private void DGVStructure(Dictionary<string, string> columnNames)
        {
            dgvTcObjects.Columns.Clear();
            foreach (var item in columnNames)
            {
                dgvTcObjects.Columns.Add(item.Key, item.Value);
            }
        }
        private void DGVNormalStructure()
        {
            Dictionary<string, string> data = new()
            {
                { "Num", "Порядковый номер" },
                { "Name", "Наименование" },
                { "Type", "Тип" },
                { "Unit", "Ед.Изм." },
                { "Quantity", "Кол-во" },
                { "Price", "Стоимость, руб. без НДС" }

            };

            DGVStructure(data);
        }
        private void DGVStaffStructure()
        {
            Dictionary<string, string> data = new()
            {
                { "Num", "Порядковый номер" },
                { "Name", "Наименование" },
                { "Type", "Тип" },
                { "СombineResponsibility", "Совмещение обазанностей" },
                { "Competence", "Квалификация" },
                { "Symbol", "Обознаяение в ТК" }
            };
            DGVStructure(data);
        }
        private void DGVWorkStepStructure()
        {
            Dictionary<string, string> data = new()
            {
                { "Num", "Порядковый номер" },
                { "Operation", "Технологические операции" },
                { "Name", "Наименование" },
                { "StepTime", "Время выполнения действия, мин" },
                { "Staff", "Персонал" },
                { "Component", "Материалы и комплектующие" },
                { "Machine", "Механизмы" },
                { "Protection", "Средства защиты" },
                { "Tool", "Инструменты и приспособления" }
            };
            DGVStructure(data);
        }

    }
}
