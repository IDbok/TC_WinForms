
using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using System.Windows.Forms;
using TC_WinForms.DataProcessing;
using TcModels.Models;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TC_WinForms.WinForms
{
    public partial class Win6 : Form
    {
        DbConnector db = new DbConnector();
        EModelType activeModelType; 
        public Win6(object sender)
        {

            if (sender is not Button) this.Close();

            InitializeComponent();

            /////////////////////////////

            if (Program.ExistingCatds.Count == 0)
            {
                Program.ExistingProcces = db.GetList<TechnologicalProcess>();
                Program.CurrentTp = Program.ExistingProcces[0];
                Program.ExistingCatds = Program.CurrentTp.TechnologicalCards;
                Program.CurrentTc = Program.ExistingCatds[0];
            }

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
            btnSaveChanges.Enabled = true;
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


        private void btnShowStaffs_Click(object sender, EventArgs e)
        {
            // todo - save changes in dgvTcObjects if they are
            SaveDataFromDGV();
            DGVNewStructure(EModelType.Staff);

            var obj = Program.CurrentTc.Staff_TCs.OrderBy(x => x.Order).ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add((int)obj[i].Order, obj[i].Staff.Name, obj[i].Staff.Type, obj[i].Staff.CombineResponsibility, obj[i].Staff.Competence, obj[i].Symbol); // todo - fix it
            }
        }

        private void btnShowComponents_Click(object sender, EventArgs e)
        {

            
            DGVNormalStructure();
            var obj = Program.CurrentTc.Component_TCs.OrderBy(x => x.Order).ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(obj[i].Order, obj[i].Component.Name, obj[i].Component.Type, obj[i].Component.Unit, obj[i].Quantity);
            }
        }

        private void btnShowMachines_Click(object sender, EventArgs e)
        {
            SaveDataFromDGV();
            DGVNewStructure(EModelType.Machine);

            var obj = Program.CurrentTc.Machine_TCs.OrderBy(x => x.Order).ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(obj[i].Order, obj[i].Machine.Name, obj[i].Machine.Type, obj[i].Machine.Unit, obj[i].Quantity);
            }
        }

        private void btnShowProtections_Click(object sender, EventArgs e)
        {
            DGVNormalStructure();
            var obj = Program.CurrentTc.Protection_TCs.OrderBy(x => x.Order).ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(obj[i].Order, obj[i].Protection.Name, obj[i].Protection.Type, obj[i].Protection.Unit, obj[i].Quantity);
            }
        }

        private void btnShowTools_Click(object sender, EventArgs e)
        {
            // save to tc changes from dgvTcObjects
            
            DGVNormalStructure();
            var obj = Program.CurrentTc.Tool_TCs.OrderBy(x => x.Order).ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                dgvTcObjects.Rows.Add(obj[i].Order, obj[i].Tool.Name, obj[i].Tool.Type, obj[i].Tool.Unit, obj[i].Quantity);
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
        // save data from dgvTcObjects to Program.CurrentTc
        private void SaveDataFromDGV() 
        {
            if (dgvTcObjects.Rows.Count == 1) return;
            if (activeModelType == EModelType.Staff)
            {
                Program.CurrentTc.Staff_TCs.Clear();

                for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                {
                    int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(),out int order);

                    Program.CurrentTc.Staff_TCs.Add(new Staff_TC()
                    {
                        Order = order,//(int)dgvTcObjects.Rows[i].Cells["Num"].Value,
                        Staff = new Staff()
                        {
                            Name = dgvTcObjects.Rows[i].Cells["Name"].Value.ToString(), // todo - make null values enable to be in dgvTcObjects in not null columns
                            Type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString(),
                            CombineResponsibility = dgvTcObjects.Rows[i].Cells["СombineResponsibility"].Value.ToString(),
                            Competence = dgvTcObjects.Rows[i].Cells["Competence"].Value.ToString(),
                        },
                        Symbol = dgvTcObjects.Rows[i].Cells["Symbol"].Value.ToString()
                    });
                }
            }
            //else if (activeModelType == EModelType.WorkStep)
            //{
            //    Program.CurrentTc.WorkSteps.Clear();
            //    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
            //    {
            //        int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out int order);
            //        Program.CurrentTc.WorkSteps.Add(new WorkStep()
            //        {
            //            Order = order,
            //            Operation = dgvTcObjects.Rows[i].Cells["Operation"].Value.ToString(),
            //            Name = dgvTcObjects.Rows[i].Cells["Name"].Value.ToString(),
            //            StepTime = (int)dgvTcObjects.Rows[i].Cells["StepTime"].Value,
            //            Staff_TCs = new List<Staff_TC>(),
            //            Component_TCs = new List<Component_TC>(),
            //            Machine_TCs = new List<Machine_TC>(),
            //            Protection_TCs = new List<Protection_TC>(),
            //            Tool_TCs = new List<Tool_TC>()
            //        });
            //    }
            //}
            //else if (activeModelType == EModelType.Component)
            //{
            //    Program.CurrentTc.Component_TCs.Clear();
            //    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
            //    {
                    //int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out int order);
            //        Program.CurrentTc.Component_TCs.Add(new Component_TC()
            //        {
            //            Order = order,
            //            Component = new Component()
            //            {
            //                Name = dgvTcObjects.Rows[i].Cells
            //            }
            //        });

                //    }
                //}
            else if (activeModelType == EModelType.Machine)
            {
                Program.CurrentTc.Machine_TCs.Clear();
                for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                {
                    int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out int order);
                    Program.CurrentTc.Machine_TCs.Add(new Machine_TC()
                    {
                        Order = order,
                        Quantity = (int)dgvTcObjects.Rows[i].Cells["Quantity"].Value,
                        Machine = new Machine()
                        {
                            Name = dgvTcObjects.Rows[i].Cells["Name"].Value.ToString(),
                            Type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString(),
                            Unit = dgvTcObjects.Rows[i].Cells["Units"].Value.ToString(),
                        },
                    });

                }
            }
            else if (activeModelType == EModelType.Protection)
            {
                Program.CurrentTc.Protection_TCs.Clear();
                for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                {
                    int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out int order);
                    Program.CurrentTc.Protection_TCs.Add(new Protection_TC()
                    {
                        Order = order,
                        Quantity = (int)dgvTcObjects.Rows[i].Cells["Quantity"].Value,
                        Protection = new Protection()
                        {
                            Name = dgvTcObjects.Rows[i].Cells["Name"].Value.ToString(),
                            Type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString(),
                            Unit = dgvTcObjects.Rows[i].Cells["Units"].Value.ToString(),
                        },
                    });

                }
            }
            else if (activeModelType == EModelType.Tool)
            {
                Program.CurrentTc.Tool_TCs.Clear();
                for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                {
                    int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out int order);
                    Program.CurrentTc.Tool_TCs.Add(new Tool_TC()
                    {
                        Order = order,
                        Quantity = (int)dgvTcObjects.Rows[i].Cells["Quantity"].Value,
                        Tool = new Tool()
                        {
                            Name = dgvTcObjects.Rows[i].Cells["Name"].Value.ToString(),
                            Type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString(),
                            Unit = dgvTcObjects.Rows[i].Cells["Units"].Value.ToString(),
                        },
                    });

                }
            }
        }
        private void DGVNewStructure(EModelType modelType)
        {
            
            Dictionary<string, string> data = null;
            if (modelType == EModelType.Staff)
            {
                data = new()
                {
                    { "Num", "Порядковый номер" },
                    { "Name", "Наименование" },
                    { "Type", "Тип" },
                    { "СombineResponsibility", "Совмещение обазанностей" },
                    { "Competence", "Квалификация" },
                    { "Symbol", "Обознаяение в ТК" }
                };
            }
            else if (modelType == EModelType.WorkStep)
            {
                data = new()
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
            }
            else
            {
                data = new()
                {
                    { "Num", "Порядковый номер" },
                    { "Name", "Наименование" },
                    { "Type", "Тип" },
                    { "Unit", "Ед.Изм." },
                    { "Quantity", "Кол-во" },
                    { "Price", "Стоимость, руб. без НДС" }

                };
            }
            if (data != null)
            {
                DGVStructure(data);
                activeModelType = modelType;
            }
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

        private void dgvTcObjects_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTcObjects.Columns[e.ColumnIndex].Name == "Num")
            {
                dgvTcObjects.Columns[e.ColumnIndex].ValueType = typeof(int);

                //dgvTcObjects.Sort(dgvTcObjects.Columns["Num"], ListSortDirection.Ascending);
                //Int32.TryParse
                //bool x = Int32.TryParse(str, out int x);

                Array.Sort(Array.ConvertAll(dgvTcObjects.Rows.Cast<DataGridViewRow>().ToArray(), x => x.Index + 1));
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveDataFromDGV();
            var db = new DbConnector();
            if (Program.CurrentTc.Id == 0)
            {
                MessageBox.Show("ТК не сохранена в БД. Сохранение невозможно.");
                //Program.CurrentTc.Article = ((TextBox)pnlNavigationTC.Controls["tbxNewTcName"]).Text;
                //Program.CurrentTc.TechnologicalProcessId = Program.CurrentTp.Id;
                //db.Add(Program.CurrentTc);
                //Program.ExistingCatds.Add(Program.CurrentTc);
                //Program.CurrentTp.TechnologicalCards.Add(Program.CurrentTc);
                //Program.CurrentTc = Program.ExistingCatds[Program.ExistingCatds.Count - 1];
                //cmbTechCardName.Items.Add(Program.CurrentTc.Article);
                //cmbTechCardName.Text = Program.CurrentTc.Article;
            }
            else
            {
                db.Update(Program.CurrentTc);
                MessageBox.Show("Изменения сохранены в БД.");
            }
        }

        private void ChangeRowsOrder(DataGridViewRow[] rows, int indexToInsert) // todo - can make from contextmenustrip in right mouse up on row (select all row) 
        {
            rows = rows.OfType<DataGridViewRow>().OrderBy(x => x.Index).ToArray();
            // create array of selected row's indexes
            int[] indexes = new int[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                indexes[i] = rows[i].Index;
            }
            foreach (DataGridViewRow row in rows)
            {
                dgvTcObjects.Rows.Remove(row);
            }
            //for (int i = 0; i < rows.Count(); i++)// (DataGridViewRow row in rows)
            //{
            //    dgvTcObjects.Rows.Insert(indexToInsert, rows[i]);
            //}
            //if (indexToInsert > dgvTcObjects.Rows.Count - 1) indexToInsert = dgvTcObjects.Rows.Count - 1;
            if(indexToInsert > (dgvTcObjects.Rows.Count - rows.Length)) indexToInsert = indexToInsert - rows.Length;
            for (int i = rows.Count() - 1; i >= 0; i--)// (DataGridViewRow row in rows)
            {
                dgvTcObjects.Rows.Insert(indexToInsert, rows[i]);
            }
        }

        //method to change dgvTcObjects Num row's values
        private void ChangeNumValues()
        {
            for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
            {
                dgvTcObjects.Rows[i].Cells["Num"].Value = i + 1;
            }
        }

        bool mouseDown = false;
        DataGridViewRow[] selectedRows;

        private void dgvTcObjects_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show($"CellMouseUp in {e.RowIndex}");
            if (mouseDown)
            {
                ChangeRowsOrder(selectedRows,e.RowIndex);
                foreach (DataGridViewRow item in selectedRows)
                {
                    item.Selected = true;
                }
                selectedRows = null;
            }
        }
        private void dgvTcObjects_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var point = dgvTcObjects.PointToClient(MousePosition);
            //var info = dgvTcObjects.HitTest(point.X, point.Y);
            // check if mouse down on selected rows
            if (dgvTcObjects.SelectedRows.Count != 0 && 
                dgvTcObjects.SelectedRows.Contains(dgvTcObjects.Rows[e.RowIndex]) && 
                e.Button == MouseButtons.Left)
            {
                selectedRows = new DataGridViewRow[dgvTcObjects.SelectedRows.Count];
                
                for (int i = 0; i < dgvTcObjects.SelectedRows.Count; i++)
                {
                    selectedRows[i] = dgvTcObjects.SelectedRows[i];
                }
                
                
                mouseDown = true;
                Cursor.Current = Cursors.Hand;
                // make time delay to check if mouse is still down
                Thread.Sleep(500);
                foreach (DataGridViewRow item in selectedRows)
                {
                    item.Selected = true;
                }
            }
        }
    }

}

