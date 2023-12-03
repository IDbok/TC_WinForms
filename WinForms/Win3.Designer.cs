using TcModels.Models.TcContent;

namespace TC_WinForms
{
    partial class Win3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnBack = new Button();
            btnSaveChanges = new Button();
            pnlToolBar = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            cmbTechProcessName = new ComboBox();
            lblTechProcessName = new Label();
            btnAddNewTC = new Button();
            btnUpdateTC = new Button();
            btnDeleteTC = new Button();
            dataGridView1 = new DataGridView();
            staffBindingSource = new BindingSource(components);
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            pnlToolBar.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)staffBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(421, 395);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 45);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(593, 395);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(160, 45);
            btnSaveChanges.TabIndex = 6;
            btnSaveChanges.Text = "Сохранить";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // pnlToolBar
            // 
            pnlToolBar.Controls.Add(toolStrip1);
            pnlToolBar.Dock = DockStyle.Top;
            pnlToolBar.Location = new Point(0, 0);
            pnlToolBar.Name = "pnlToolBar";
            pnlToolBar.Size = new Size(782, 25);
            pnlToolBar.TabIndex = 12;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(782, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(49, 24);
            toolStripButton1.Text = "Файл";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(69, 24);
            toolStripButton2.Text = "Главная";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(71, 24);
            toolStripButton3.Text = "Справка";
            // 
            // cmbTechProcessName
            // 
            cmbTechProcessName.FormattingEnabled = true;
            cmbTechProcessName.Location = new Point(22, 47);
            cmbTechProcessName.Name = "cmbTechProcessName";
            cmbTechProcessName.Size = new Size(307, 28);
            cmbTechProcessName.TabIndex = 13;
            // 
            // lblTechProcessName
            // 
            lblTechProcessName.AutoSize = true;
            lblTechProcessName.Location = new Point(21, 27);
            lblTechProcessName.Name = "lblTechProcessName";
            lblTechProcessName.Size = new Size(268, 20);
            lblTechProcessName.TabIndex = 14;
            lblTechProcessName.Text = "Выберите Технологический процесс:";
            // 
            // btnAddNewTC
            // 
            btnAddNewTC.Location = new Point(379, 47);
            btnAddNewTC.Name = "btnAddNewTC";
            btnAddNewTC.Size = new Size(94, 29);
            btnAddNewTC.TabIndex = 15;
            btnAddNewTC.Text = "Добавить новую карту";
            btnAddNewTC.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTC
            // 
            btnUpdateTC.Location = new Point(512, 47);
            btnUpdateTC.Name = "btnUpdateTC";
            btnUpdateTC.Size = new Size(94, 29);
            btnUpdateTC.TabIndex = 16;
            btnUpdateTC.Text = "Редактировать";
            btnUpdateTC.UseVisualStyleBackColor = true;
            btnUpdateTC.Click += btnUpdateTC_Click;
            // 
            // btnDeleteTC
            // 
            btnDeleteTC.Location = new Point(659, 47);
            btnDeleteTC.Name = "btnDeleteTC";
            btnDeleteTC.Size = new Size(94, 29);
            btnDeleteTC.TabIndex = 17;
            btnDeleteTC.Text = "Удалить";
            btnDeleteTC.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(22, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(731, 289);
            dataGridView1.TabIndex = 18;
            // 
            // staffBindingSource
            // 
            staffBindingSource.DataSource = typeof(Staff);
            // 
            // Column1
            // 
            Column1.HeaderText = "Порядковый номер";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Наименование";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 300;
            // 
            // Column3
            // 
            Column3.HeaderText = "Номер ТК";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Win3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(cmbTechProcessName);
            Controls.Add(dataGridView1);
            Controls.Add(btnDeleteTC);
            Controls.Add(btnUpdateTC);
            Controls.Add(btnAddNewTC);
            Controls.Add(lblTechProcessName);
            Controls.Add(pnlToolBar);
            Controls.Add(btnBack);
            Controls.Add(btnSaveChanges);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Win3";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор объекта редактирования";
            FormClosing += Win3_FormClosing;
            pnlToolBar.ResumeLayout(false);
            pnlToolBar.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)staffBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnSaveChanges;
        private Panel pnlToolBar;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ComboBox cmbTechProcessName;
        private Label lblTechProcessName;
        private Button btnAddNewTC;
        private Button btnUpdateTC;
        private Button btnDeleteTC;
        private DataGridView dataGridView1;
        private BindingSource staffBindingSource;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}