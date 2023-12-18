using OfficeOpenXml.Style;
using TC_WinForms.DataProcessing;
using TcDbConnector;
using TcModels.Models;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;

namespace TC_WinForms
{
    internal static class WinProcessing
    {
        private static Author author = new();
        public static bool isDataToSave { get; set; } = false;
        private static void SaveData() 
        {

            // todo - save data from all forms
            Form[] allForms = Program.FormsBack.Concat(Program.FormsForward).ToArray();
            foreach (Form form in allForms)
            {
                if (form is Win2)
                { 
                    Win2 saveableForm = (Win2)form;
                    //DataJsonSerializer.Serialize<TcData>(saveableForm.tp, saveableForm.GetPath());
                }
            }
            //Form[] allForms = Program.FormsBack.Concat(Program.FormsForward).ToArray();
            //foreach (Form form in allForms)
            //{
            //    if (form is ISaveableForm)
            //    {
            //        ISaveableForm saveableForm = (ISaveableForm)form;
            //        DataJsonSerializer.Serialize(saveableForm.DataToSave(), saveableForm.GetPath());
            //    }
            //}
            MessageBox.Show("Данные сохранены", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void SaveDataFromDGV(DataGridView dgvTcObjects, EModelType activeModelType) // todo - ??? mb beter catch changes and save them in Program.CurrentTc
        {

            if (dgvTcObjects.Rows.Count == 1 || dgvTcObjects.Columns.Count == 0) return;

            int id = 0;
            int order = 0;

            if (activeModelType == EModelType.Staff)
            {
                for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                {

                    int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                    int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                    string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                    string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                    string combineResponsibility = dgvTcObjects.Rows[i].Cells["СombineResponsibility"].Value.ToString();
                    string competence = dgvTcObjects.Rows[i].Cells["Competence"].Value.ToString();

                    string symbol = dgvTcObjects.Rows[i].Cells["Symbol"].Value.ToString();

                    // check if staff is already exists in db
                    var staff = db.GetObject<Staff>(id);
                    Staff newStaff = new Staff()
                    {
                        Id = staff.Id != null ? staff.Id : 0,
                        Name = name,
                        Type = type,
                        CombineResponsibility = combineResponsibility,
                        Competence = competence,
                    };

                    if (staff == null)
                    {
                        db.Add(newStaff); // todo - make an storege of new staffs to add them all at once
                        staff = newStaff;
                    }
                    else
                    {
                        if (!(staff.Id == newStaff.Id &&
                            staff.Name == newStaff.Name &&
                            staff.Type == newStaff.Type &&
                            staff.CombineResponsibility == newStaff.CombineResponsibility &&
                            staff.Comment == newStaff.Comment &&
                            staff.Competence == newStaff.Competence &&
                            staff.ElSaftyGroup == newStaff.ElSaftyGroup &&
                            staff.Grade == newStaff.Grade))
                        {
                            db.Update(staff); // todo - update objects in object related to TurrentTc
                        }
                        else return; // end of method if staff is not changed
                    }

                    // Check if staff is already connected to TC. If not - add new Staff_TC object to db
                    var sttc = db.GetObject<Staff_TC, Staff>(Program.CurrentTc.Id, staff.Id);
                    if (sttc == null)
                    {
                        Program.CurrentTc.Staff_TCs.Add(new Staff_TC()
                        {
                            Order = order,
                            Child = staff,
                            Symbol = symbol
                        });
                    }
                    else
                    {
                        sttc.Order = order;
                        sttc.Symbol = symbol;
                        db.Update(sttc);
                    }
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
            else
            {
                int quantity = 0;
                int price = 0;

                if (activeModelType == EModelType.Component)
                {
                    //Program.CurrentTc.Component_TCs.Clear();
                    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                    {
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                        string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                        string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                        string unit = dgvTcObjects.Rows[i].Cells["Unit"].Value.ToString();

                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Quantity"].Value.ToString(), out quantity);
                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Price"].Value.ToString(),out price);

                        // check if object is already exists in db
                        var obj = db.GetObject<TcModels.Models.TcContent.Component>(id);
                        TcModels.Models.TcContent.Component newobj = new TcModels.Models.TcContent.Component()
                        {
                            Id = obj.Id != null ? obj.Id : 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                        };

                        if (obj == null)
                        {
                            db.Add(newobj); // todo - make an storege of new staffs to add them all at once
                            obj = newobj;
                        }
                        else
                        {
                            if (!(obj.Id == newobj.Id &&
                                obj.Name == newobj.Name &&
                                obj.Type == newobj.Type &&
                                obj.Unit == newobj.Unit))
                            {
                                db.Update(obj); // todo - update objects in object related to TurrentTc
                            }
                            else return; // end of method if staff is not changed
                        }

                    }
                }
                else if (activeModelType == EModelType.Machine)
                {
                    //Program.CurrentTc.Machine_TCs.Clear();
                    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                    {
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                        string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                        string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                        string unit = dgvTcObjects.Rows[i].Cells["Unit"].Value.ToString();

                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Quantity"].Value.ToString(), out quantity);
                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Price"].Value.ToString(), out price);

                        // check if object is already exists in db
                        var obj = db.GetObject<Machine>(id);
                        Machine newobj = new Machine()
                        {
                            Id = obj.Id != null ? obj.Id : 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                        };

                        if (obj == null)
                        {
                            db.Add(newobj); // todo - make an storege of new staffs to add them all at once
                            obj = newobj;
                        }
                        else
                        {
                            if (!(obj.Id == newobj.Id &&
                                obj.Name == newobj.Name &&
                                obj.Type == newobj.Type &&
                                obj.Unit == newobj.Unit))
                            {
                                db.Update(obj); // todo - update objects in object related to TurrentTc
                            }
                            else return; // end of method if staff is not changed
                        }

                    }
                }
                else if (activeModelType == EModelType.Protection)
                {
                    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                    {
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                        string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                        string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                        string unit = dgvTcObjects.Rows[i].Cells["Unit"].Value.ToString();

                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Quantity"].Value.ToString(), out quantity);
                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Price"].Value.ToString(), out price);

                        // check if object is already exists in db
                        var obj = db.GetObject<Protection>(id);
                        Protection newobj = new Protection()
                        {
                            Id = obj.Id != null ? obj.Id : 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                        };

                        if (obj == null)
                        {
                            db.Add(newobj); // todo - make an storege of new staffs to add them all at once
                            obj = newobj;
                        }
                        else
                        {
                            if (!(obj.Id == newobj.Id &&
                                obj.Name == newobj.Name &&
                                obj.Type == newobj.Type &&
                                obj.Unit == newobj.Unit))
                            {
                                db.Update(obj); // todo - update objects in object related to TurrentTc
                            }
                            else return; // end of method if staff is not changed
                        }

                    }
                }
                else if (activeModelType == EModelType.Tool)
                {
                    for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
                    {
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                        int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                        string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                        string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                        string unit = dgvTcObjects.Rows[i].Cells["Unit"].Value.ToString();

                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Quantity"].Value.ToString(), out quantity);
                        //int.TryParse(dgvTcObjects.Rows[i].Cells["Price"].Value.ToString(), out price);

                        // check if object is already exists in db
                        var obj = db.GetObject<Tool>(id);
                        Tool newobj = new Tool()
                        {
                            Id = obj.Id != null ? obj.Id : 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                        };

                        if (obj == null)
                        {
                            db.Add(newobj); // todo - make an storege of new staffs to add them all at once
                            obj = newobj;
                        }
                        else
                        {
                            if (!(obj.Id == newobj.Id &&
                                obj.Name == newobj.Name &&
                                obj.Type == newobj.Type &&
                                obj.Unit == newobj.Unit))
                            {
                                db.Update(obj); // todo - update objects in object related to TurrentTc
                            }
                            else return; // end of method if staff is not changed
                        }

                    }
                }
            }
        }

        private static List<T> SaveDataFromDGVToTC<T>(DataGridView dgvTcObjects) where T : class, IModelStructure, new()
        {
            DbConnector db = new DbConnector();

            List<T> objects = new List<T>();
            int quantity = 0;
            int price = 0;

            int id, order;

            for (int i = 0; i < dgvTcObjects.Rows.Count - 1; i++)
            {
                int.TryParse(dgvTcObjects.Rows[i].Cells["Id"].Value.ToString(), out id);
                int.TryParse(dgvTcObjects.Rows[i].Cells["Num"].Value.ToString(), out order);

                string name = dgvTcObjects.Rows[i].Cells["Title"].Value.ToString(); // todo - make null values enable to be in dgvTcObjects in not null columns
                string type = dgvTcObjects.Rows[i].Cells["Type"].Value.ToString();
                string unit = dgvTcObjects.Rows[i].Cells["Unit"].Value.ToString();

                // check if object is already exists in db
                var obj = db.GetObject<T>(id);
                T newobj = new T()
                {
                    Id = obj.Id != null ? obj.Id : 0,
                    Name = name,
                    Type = type,
                    Unit = unit,
                };

                if (obj == null)
                {
                    db.Add(newobj); // todo - make an storege of new staffs to add them all at once
                    obj = newobj;
                }
                else
                {
                    if (!(obj.Id == newobj.Id &&
                        obj.Name == newobj.Name &&
                        obj.Type == newobj.Type &&
                        obj.Unit == newobj.Unit))
                    {
                        db.Update(obj); // todo - update objects in object related to TurrentTc
                    }
                }
                objects.Add(obj);
            }
            return objects;
        }
        public static T GetObjFromDbOrAdd<T>(int id,string name, string type, string unit) where T: class, IModelStructure, new()
        {
            DbConnector db = new DbConnector();

            var objFromDb = db.GetObject<T>(id);
            T newobj = new T()
            {
                Id = objFromDb.Id != null ? objFromDb.Id : 0,
                Name = name,
                Type = type,
                Unit = unit,
            };

            if (objFromDb == null)
            {
                db.Add(newobj);
                objFromDb = newobj;
            }
            else
            {
                if (!(objFromDb.Id == newobj.Id &&
                                       objFromDb.Name == newobj.Name &&
                                                          objFromDb.Type == newobj.Type &&
                                                                             objFromDb.Unit == newobj.Unit))
                {
                    db.Update(objFromDb);
                }
            }
            return objFromDb;
        }
        public static T GetObjFromDbOrAdd<T,C>(int tcId, int objId, TechnologicalCard tc, C childObj) 
            where T : class, IIntermediateTable<TechnologicalCard,C>, new()
            where C : class, IModelStructure
        {
            DbConnector db = new DbConnector();

            var obj = db.GetObject<Tool_TC, Tool>(tc.Id, childObj.Id);

            if (obj == null)
            {
                Program.CurrentTc.Tool_TCs.Add(new Tool_TC()
                {
                    Order = order,
                    Child = childObj,
                    Quantity = quantity,
                });
            }
            else
            {
                obj.Order = order;
                obj.Quantity = quantity;
                db.Update(sttc);
            }
        }

        public static bool CloseAppMessage(FormClosingEventArgs e, out bool saveDate)
        {
            saveDate = false;
            bool closeApp = true;
            //if (Program.testMode) return closeApp;
            if (isDataToSave)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Сохранить промежуточные результаты перед выходом?", 
                    "Выход из программы", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) 
                { 
                    saveDate = true;
                    closeApp = true;
                }
                else if (dialogResult == DialogResult.No) closeApp = true;
                else closeApp = false;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) closeApp = false;
                
            }
            return closeApp;
        }
        public static void CloseingApp(FormClosingEventArgs e) 
        {
            bool closeApp = CloseAppMessage(e, out bool saveData);
            e.Cancel = !closeApp;
            if (saveData)
            {
                SaveData();
            }
            if (closeApp) Application.ExitThread();
        }
        // todo - ovverload colorization method with except buttons array (not change their color) (default olny one button)

        public static void ColorizeOnlyChosenButton(object sender, GroupBox gbx)
        {   
            foreach (Control btn2 in gbx.Controls)
            { btn2.BackColor = Color.FromArgb(255, 255, 255); }
            ColorizeChosenButton(sender, Color.FromArgb(128, 255, 191));
        }
        public static void ColorizeChosenButton(object sender, Color btnColor)
        {
            Button btn = (Button)sender;
            btn.BackColor = btnColor;
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control enableControl)
        {
            ColorizeBtnAndEnableControl(sender,  gbxButtons, new Control[] { enableControl });
        }
        public static void ColorizeBtnAndEnableControl(object sender, GroupBox gbxButtons, Control[] enableControl)
        {
            WinProcessing.ColorizeOnlyChosenButton(sender, gbxButtons);
            foreach (Control control in enableControl) control.Enabled = true;
        }
        public static bool CheckAllTextBoxes(GroupBox gbx)
        {
            foreach (Control txt in gbx.Controls)
            {
                if (txt is TextBox)
                {
                    if (txt.Text == "")
                    {
                        MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }
        public static Author GetAuthUser()
        {
            return Authorizator.author;
        }
        public static void NextFormBtn(Form newForm, Form thisForm)
        {
            Program.FormsBack.Add(thisForm);
            Program.MainForm = newForm;
            Program.MainForm.Show();
            thisForm.Hide();
        }
        public static void NextFormBtn(Form thisForm)
        {
            Program.FormsBack.Add(thisForm);
            Program.MainForm = Program.FormsForward.Last();
            Program.MainForm.Show();
            thisForm.Hide();
        }
        public static void BackFormBtn(Form thisForm)
        {
            Program.FormsForward.Add(thisForm);
            Program.MainForm = Program.FormsBack.Last();
            Program.FormsBack.RemoveAt(Program.FormsBack.Count - 1);
            Program.MainForm.Show();
            thisForm.Hide();
        }

        public static void AddItemsToListBox(ListBox listBox, List<string> items)
        {
            foreach (var item in items)
            {
                listBox.Items.Add(item);
            }
        }
    }
}
