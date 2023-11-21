namespace TC_WinForms
{
    partial class WinIndex1
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
            lblIinformProgramName = new Label();
            lblInformVer = new Label();
            gbxAuthorizationForm = new GroupBox();
            lblAuthSurname = new Label();
            txtSurname = new TextBox();
            lblAuthName = new Label();
            txtName = new TextBox();
            btnAuthorization = new Button();
            btnTcDesign = new Button();
            btnNext = new Button();
            gbxFunctionalityChoice = new GroupBox();
            btnTcEditng = new Button();
            lbxPreviousActionsTC = new ListBox();
            pnlControlPanel = new Panel();
            gbxInformation.SuspendLayout();
            gbxAuthorizationForm.SuspendLayout();
            gbxFunctionalityChoice.SuspendLayout();
            pnlControlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gbxInformation
            // 
            gbxInformation.Controls.Add(lblIinformProgramName);
            gbxInformation.Controls.Add(lblInformVer);
            gbxInformation.Location = new Point(23, 26);
            gbxInformation.Name = "gbxInformation";
            gbxInformation.Size = new Size(392, 125);
            gbxInformation.TabIndex = 0;
            gbxInformation.TabStop = false;
            gbxInformation.Text = "Информационное окно";
            // 
            // lblIinformProgramName
            // 
            lblIinformProgramName.AutoSize = true;
            lblIinformProgramName.Location = new Point(23, 39);
            lblIinformProgramName.Name = "lblIinformProgramName";
            lblIinformProgramName.Size = new Size(164, 20);
            lblIinformProgramName.TabIndex = 1;
            lblIinformProgramName.Text = "Название программы";
            // 
            // lblInformVer
            // 
            lblInformVer.AutoSize = true;
            lblInformVer.Location = new Point(23, 79);
            lblInformVer.Name = "lblInformVer";
            lblInformVer.Size = new Size(74, 20);
            lblInformVer.TabIndex = 0;
            lblInformVer.Text = "Версия: 0";
            // 
            // gbxAuthorizationForm
            // 
            gbxAuthorizationForm.Controls.Add(lblAuthSurname);
            gbxAuthorizationForm.Controls.Add(txtSurname);
            gbxAuthorizationForm.Controls.Add(lblAuthName);
            gbxAuthorizationForm.Controls.Add(txtName);
            gbxAuthorizationForm.Controls.Add(btnAuthorization);
            gbxAuthorizationForm.Location = new Point(23, 189);
            gbxAuthorizationForm.Name = "gbxAuthorizationForm";
            gbxAuthorizationForm.Size = new Size(392, 195);
            gbxAuthorizationForm.TabIndex = 1;
            gbxAuthorizationForm.TabStop = false;
            gbxAuthorizationForm.Text = "Форма авторизации";
            // 
            // lblAuthSurname
            // 
            lblAuthSurname.AutoSize = true;
            lblAuthSurname.Location = new Point(62, 84);
            lblAuthSurname.Name = "lblAuthSurname";
            lblAuthSurname.Size = new Size(73, 20);
            lblAuthSurname.TabIndex = 4;
            lblAuthSurname.Text = "Фамилия";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(141, 81);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(200, 27);
            txtSurname.TabIndex = 3;
            // 
            // lblAuthName
            // 
            lblAuthName.AutoSize = true;
            lblAuthName.Location = new Point(96, 32);
            lblAuthName.Name = "lblAuthName";
            lblAuthName.Size = new Size(39, 20);
            lblAuthName.TabIndex = 2;
            lblAuthName.Text = "Имя";
            // 
            // txtName
            // 
            txtName.Location = new Point(141, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 1;
            // 
            // btnAuthorization
            // 
            btnAuthorization.Location = new Point(181, 130);
            btnAuthorization.Name = "btnAuthorization";
            btnAuthorization.Size = new Size(160, 45);
            btnAuthorization.TabIndex = 0;
            btnAuthorization.Text = "Авторизация";
            btnAuthorization.UseVisualStyleBackColor = true;
            btnAuthorization.Click += btnAuthorization_Click;
            // 
            // btnTcDesign
            // 
            btnTcDesign.Location = new Point(19, 42);
            btnTcDesign.Name = "btnTcDesign";
            btnTcDesign.Size = new Size(140, 90);
            btnTcDesign.TabIndex = 2;
            btnTcDesign.Text = "Создать новой";
            btnTcDesign.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(190, 395);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(160, 45);
            btnNext.TabIndex = 4;
            btnNext.Text = "Далее";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // gbxFunctionalityChoice
            // 
            gbxFunctionalityChoice.Controls.Add(btnTcEditng);
            gbxFunctionalityChoice.Controls.Add(btnTcDesign);
            gbxFunctionalityChoice.Location = new Point(13, 26);
            gbxFunctionalityChoice.Name = "gbxFunctionalityChoice";
            gbxFunctionalityChoice.Size = new Size(337, 145);
            gbxFunctionalityChoice.TabIndex = 5;
            gbxFunctionalityChoice.TabStop = false;
            gbxFunctionalityChoice.Text = "Выбор функционала";
            // 
            // btnTcEditng
            // 
            btnTcEditng.Location = new Point(166, 42);
            btnTcEditng.Name = "btnTcEditng";
            btnTcEditng.Size = new Size(140, 90);
            btnTcEditng.TabIndex = 3;
            btnTcEditng.Text = "Редактировать";
            btnTcEditng.UseVisualStyleBackColor = true;
            // 
            // lbxPreviousActionsTC
            // 
            lbxPreviousActionsTC.FormattingEnabled = true;
            lbxPreviousActionsTC.ItemHeight = 20;
            lbxPreviousActionsTC.Location = new Point(13, 200);
            lbxPreviousActionsTC.Name = "lbxPreviousActionsTC";
            lbxPreviousActionsTC.Size = new Size(337, 184);
            lbxPreviousActionsTC.TabIndex = 6;
            // 
            // pnlControlPanel
            // 
            pnlControlPanel.Controls.Add(btnNext);
            pnlControlPanel.Controls.Add(gbxFunctionalityChoice);
            pnlControlPanel.Controls.Add(lbxPreviousActionsTC);
            pnlControlPanel.Dock = DockStyle.Right;
            pnlControlPanel.Enabled = false;
            pnlControlPanel.Location = new Point(421, 0);
            pnlControlPanel.Name = "pnlControlPanel";
            pnlControlPanel.Size = new Size(379, 452);
            pnlControlPanel.TabIndex = 8;
            // 
            // WinIndex1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(pnlControlPanel);
            Controls.Add(gbxAuthorizationForm);
            Controls.Add(gbxInformation);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "WinIndex1";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            Text = "Форма авторизации";
            gbxInformation.ResumeLayout(false);
            gbxInformation.PerformLayout();
            gbxAuthorizationForm.ResumeLayout(false);
            gbxAuthorizationForm.PerformLayout();
            gbxFunctionalityChoice.ResumeLayout(false);
            pnlControlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxInformation;
        private Label lblIinformProgramName;
        private Label lblInformVer;
        private GroupBox gbxAuthorizationForm;
        private Button btnTcDesign;
        private Button button2;
        private Button btnNext;
        private GroupBox gbxFunctionalityChoice;
        private Button btnTcEditng;
        private ListBox lbxPreviousActionsTC;
        private Label lblAuthName;
        private TextBox txtName;
        private Button btnAuthorization;
        private Label lblAuthSurname;
        private TextBox txtSurname;
        private Panel pnlControlPanel;
    }
}