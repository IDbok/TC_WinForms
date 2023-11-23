namespace TC_WinForms
{
    partial class Win2
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
            gbxInformation = new GroupBox();
            lblWinInformantion = new Label();
            gbxProjectNameForm = new GroupBox();
            lblProjectName = new Label();
            txtProjectName = new TextBox();
            btnTcTransPoint = new Button();
            btnNext = new Button();
            gbxFunctionalityChoice = new GroupBox();
            btnOpenSwitchgear = new Button();
            btnTcOilSub = new Button();
            pnlControlPanel = new Panel();
            btnBack = new Button();
            gbxInformation.SuspendLayout();
            gbxProjectNameForm.SuspendLayout();
            gbxFunctionalityChoice.SuspendLayout();
            pnlControlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gbxInformation
            // 
            gbxInformation.Controls.Add(lblWinInformantion);
            gbxInformation.Location = new Point(20, 26);
            gbxInformation.Name = "gbxInformation";
            gbxInformation.Size = new Size(356, 54);
            gbxInformation.TabIndex = 0;
            gbxInformation.TabStop = false;
            gbxInformation.Text = "Информационное окно";
            // 
            // lblWinInformantion
            // 
            lblWinInformantion.AutoSize = true;
            lblWinInformantion.Location = new Point(6, 23);
            lblWinInformantion.Name = "lblWinInformantion";
            lblWinInformantion.Size = new Size(219, 20);
            lblWinInformantion.TabIndex = 1;
            lblWinInformantion.Text = "Выбор объекта строительства";
            // 
            // gbxProjectNameForm
            // 
            gbxProjectNameForm.Controls.Add(lblProjectName);
            gbxProjectNameForm.Controls.Add(txtProjectName);
            gbxProjectNameForm.Enabled = false;
            gbxProjectNameForm.Location = new Point(18, 26);
            gbxProjectNameForm.Name = "gbxProjectNameForm";
            gbxProjectNameForm.Size = new Size(330, 360);
            gbxProjectNameForm.TabIndex = 1;
            gbxProjectNameForm.TabStop = false;
            // 
            // lblProjectName
            // 
            lblProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProjectName.AutoSize = true;
            lblProjectName.Location = new Point(18, 23);
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(176, 20);
            lblProjectName.TabIndex = 2;
            lblProjectName.Text = "Наименование объекта";
            lblProjectName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(35, 46);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(283, 27);
            txtProjectName.TabIndex = 1;
            // 
            // btnTcTransPoint
            // 
            btnTcTransPoint.Location = new Point(19, 26);
            btnTcTransPoint.Name = "btnTcTransPoint";
            btnTcTransPoint.Size = new Size(140, 90);
            btnTcTransPoint.TabIndex = 2;
            btnTcTransPoint.Text = "Точка трансформации";
            btnTcTransPoint.UseVisualStyleBackColor = true;
            btnTcTransPoint.Click += btnTcTransPoint_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(190, 395);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(160, 45);
            btnNext.TabIndex = 4;
            btnNext.Text = "Далее";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // gbxFunctionalityChoice
            // 
            gbxFunctionalityChoice.Controls.Add(btnOpenSwitchgear);
            gbxFunctionalityChoice.Controls.Add(btnTcOilSub);
            gbxFunctionalityChoice.Controls.Add(btnTcTransPoint);
            gbxFunctionalityChoice.Location = new Point(20, 81);
            gbxFunctionalityChoice.Name = "gbxFunctionalityChoice";
            gbxFunctionalityChoice.Size = new Size(356, 354);
            gbxFunctionalityChoice.TabIndex = 5;
            gbxFunctionalityChoice.TabStop = false;
            gbxFunctionalityChoice.Text = "Выбор функционала";
            // 
            // btnOpenSwitchgear
            // 
            btnOpenSwitchgear.Location = new Point(19, 228);
            btnOpenSwitchgear.Name = "btnOpenSwitchgear";
            btnOpenSwitchgear.Size = new Size(140, 90);
            btnOpenSwitchgear.TabIndex = 4;
            btnOpenSwitchgear.Text = "Подстанция\n ОРУ \nна реклоузерах";
            btnOpenSwitchgear.UseVisualStyleBackColor = true;
            // 
            // btnTcOilSub
            // 
            btnTcOilSub.Location = new Point(19, 127);
            btnTcOilSub.Name = "btnTcOilSub";
            btnTcOilSub.Size = new Size(140, 90);
            btnTcOilSub.TabIndex = 3;
            btnTcOilSub.Text = "Нефтяная подстанция";
            btnTcOilSub.UseVisualStyleBackColor = true;
            // 
            // pnlControlPanel
            // 
            pnlControlPanel.Controls.Add(btnBack);
            pnlControlPanel.Controls.Add(btnNext);
            pnlControlPanel.Controls.Add(gbxProjectNameForm);
            pnlControlPanel.Dock = DockStyle.Right;
            pnlControlPanel.Location = new Point(403, 0);
            pnlControlPanel.Name = "pnlControlPanel";
            pnlControlPanel.Size = new Size(379, 453);
            pnlControlPanel.TabIndex = 8;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(18, 395);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 45);
            btnBack.TabIndex = 5;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Win2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(pnlControlPanel);
            Controls.Add(gbxFunctionalityChoice);
            Controls.Add(gbxInformation);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Win2";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            Text = "Выбор объекта строительства";
            Load += Win2_Load;
            gbxInformation.ResumeLayout(false);
            gbxInformation.PerformLayout();
            gbxProjectNameForm.ResumeLayout(false);
            gbxProjectNameForm.PerformLayout();
            gbxFunctionalityChoice.ResumeLayout(false);
            pnlControlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxInformation;
        private Label lblWinInformantion;
        private GroupBox gbxProjectNameForm;
        private Button btnTcTransPoint;
        private Button button2;
        private Button btnNext;
        private GroupBox gbxFunctionalityChoice;
        private Button btnTcOilSub;
        private Label lblProjectName;
        private TextBox txtProjectName;
        private Panel pnlControlPanel;
        private Button btnBack;
        private Button btnOpenSwitchgear;
    }
}