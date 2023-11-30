namespace TC_WinForms.WinForms
{
    partial class Win6
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
            cmbTechProcessName = new ComboBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            lblTechProcessName = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            comboBox1 = new ComboBox();
            label1 = new Label();
            btnBack = new Button();
            btnSaveChanges = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            pnlNavigationTC = new Panel();
            pnlControls = new Panel();
            pnlTable = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            pnlNavigationTC.SuspendLayout();
            pnlControls.SuspendLayout();
            pnlTable.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbTechProcessName
            // 
            cmbTechProcessName.FormattingEnabled = true;
            cmbTechProcessName.Location = new Point(6, 4);
            cmbTechProcessName.Name = "cmbTechProcessName";
            cmbTechProcessName.Size = new Size(307, 28);
            cmbTechProcessName.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(540, 334);
            dataGridView1.TabIndex = 22;
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
            // lblTechProcessName
            // 
            lblTechProcessName.AutoSize = true;
            lblTechProcessName.Location = new Point(2, 4);
            lblTechProcessName.Name = "lblTechProcessName";
            lblTechProcessName.Size = new Size(268, 20);
            lblTechProcessName.TabIndex = 21;
            lblTechProcessName.Text = "Выберите Технологический процесс:";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(782, 27);
            toolStrip1.TabIndex = 19;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(442, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(307, 28);
            comboBox1.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 4);
            label1.Name = "label1";
            label1.Size = new Size(268, 20);
            label1.TabIndex = 24;
            label1.Text = "Выберите Технологический процесс:";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Location = new Point(181, 8);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(176, 45);
            btnBack.TabIndex = 26;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(362, 8);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(176, 45);
            btnSaveChanges.TabIndex = 25;
            btnSaveChanges.Text = "Сохранить";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(5, 4);
            button1.Name = "button1";
            button1.Size = new Size(230, 50);
            button1.TabIndex = 27;
            button1.Text = "Требования к составу бригады и квалификации";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(5, 60);
            button2.Name = "button2";
            button2.Size = new Size(230, 50);
            button2.TabIndex = 28;
            button2.Text = " Требования к материалам и комплектующим";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(5, 116);
            button3.Name = "button3";
            button3.Size = new Size(230, 50);
            button3.TabIndex = 29;
            button3.Text = "Требования к механизмам";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(5, 172);
            button4.Name = "button4";
            button4.Size = new Size(230, 50);
            button4.TabIndex = 30;
            button4.Text = "Требования к средствам защиты";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(5, 228);
            button5.Name = "button5";
            button5.Size = new Size(230, 50);
            button5.TabIndex = 31;
            button5.Text = "Требования к инструментам и приспособлениям";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(5, 284);
            button6.Name = "button6";
            button6.Size = new Size(230, 50);
            button6.TabIndex = 32;
            button6.Text = "Требования к инструментам и приспособлениям";
            button6.UseVisualStyleBackColor = true;
            // 
            // pnlNavigationTC
            // 
            pnlNavigationTC.Controls.Add(comboBox1);
            pnlNavigationTC.Controls.Add(label1);
            pnlNavigationTC.Controls.Add(cmbTechProcessName);
            pnlNavigationTC.Controls.Add(lblTechProcessName);
            pnlNavigationTC.Dock = DockStyle.Top;
            pnlNavigationTC.Location = new Point(0, 27);
            pnlNavigationTC.Name = "pnlNavigationTC";
            pnlNavigationTC.Size = new Size(782, 36);
            pnlNavigationTC.TabIndex = 33;
            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(button6);
            pnlControls.Controls.Add(button5);
            pnlControls.Controls.Add(button4);
            pnlControls.Controls.Add(button3);
            pnlControls.Controls.Add(button2);
            pnlControls.Controls.Add(button1);
            pnlControls.Dock = DockStyle.Left;
            pnlControls.Location = new Point(0, 63);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(242, 390);
            pnlControls.TabIndex = 34;
            // 
            // pnlTable
            // 
            pnlTable.Controls.Add(dataGridView1);
            pnlTable.Dock = DockStyle.Fill;
            pnlTable.Location = new Point(242, 63);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(540, 390);
            pnlTable.TabIndex = 35;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(btnSaveChanges);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(242, 394);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 59);
            panel1.TabIndex = 36;
            // 
            // Win6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(panel1);
            Controls.Add(pnlTable);
            Controls.Add(pnlControls);
            Controls.Add(pnlNavigationTC);
            Controls.Add(toolStrip1);
            Name = "Win6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Win6";
            FormClosing += Win6_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlNavigationTC.ResumeLayout(false);
            pnlNavigationTC.PerformLayout();
            pnlControls.ResumeLayout(false);
            pnlTable.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTechProcessName;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Label lblTechProcessName;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ComboBox comboBox1;
        private Label label1;
        private Button btnBack;
        private Button btnSaveChanges;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel pnlNavigationTC;
        private Panel pnlControls;
        private Panel pnlTable;
        private Panel panel1;
    }
}