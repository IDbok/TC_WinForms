namespace TC_WinForms
{
    partial class Win1
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
            panel1 = new Panel();
            button1 = new Button();
            gbxAuthorizationForm.SuspendLayout();
            gbxFunctionalityChoice.SuspendLayout();
            pnlControlPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbxAuthorizationForm
            // 
            gbxAuthorizationForm.Controls.Add(lblAuthSurname);
            gbxAuthorizationForm.Controls.Add(txtSurname);
            gbxAuthorizationForm.Controls.Add(lblAuthName);
            gbxAuthorizationForm.Controls.Add(txtName);
            gbxAuthorizationForm.Controls.Add(btnAuthorization);
            gbxAuthorizationForm.Location = new Point(39, 30);
            gbxAuthorizationForm.Name = "gbxAuthorizationForm";
            gbxAuthorizationForm.Size = new Size(360, 195);
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
            btnTcDesign.Location = new Point(19, 28);
            btnTcDesign.Name = "btnTcDesign";
            btnTcDesign.Size = new Size(140, 90);
            btnTcDesign.TabIndex = 2;
            btnTcDesign.Text = "Создать новой";
            btnTcDesign.UseVisualStyleBackColor = true;
            btnTcDesign.Click += btnTcDesign_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(537, 363);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(160, 45);
            btnNext.TabIndex = 4;
            btnNext.Text = "Далее";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // gbxFunctionalityChoice
            // 
            gbxFunctionalityChoice.Controls.Add(btnTcEditng);
            gbxFunctionalityChoice.Controls.Add(btnTcDesign);
            gbxFunctionalityChoice.Location = new Point(39, 26);
            gbxFunctionalityChoice.Name = "gbxFunctionalityChoice";
            gbxFunctionalityChoice.Size = new Size(337, 127);
            gbxFunctionalityChoice.TabIndex = 5;
            gbxFunctionalityChoice.TabStop = false;
            gbxFunctionalityChoice.Text = "Выбор функционала";
            // 
            // btnTcEditng
            // 
            btnTcEditng.Location = new Point(166, 28);
            btnTcEditng.Name = "btnTcEditng";
            btnTcEditng.Size = new Size(140, 90);
            btnTcEditng.TabIndex = 3;
            btnTcEditng.Text = "Редактировать";
            btnTcEditng.UseVisualStyleBackColor = true;
            btnTcEditng.Click += btnTcEditng_Click;
            // 
            // lbxPreviousActionsTC
            // 
            lbxPreviousActionsTC.FormattingEnabled = true;
            lbxPreviousActionsTC.ItemHeight = 20;
            lbxPreviousActionsTC.Location = new Point(394, 25);
            lbxPreviousActionsTC.Name = "lbxPreviousActionsTC";
            lbxPreviousActionsTC.Size = new Size(337, 204);
            lbxPreviousActionsTC.TabIndex = 6;
            // 
            // pnlControlPanel
            // 
            pnlControlPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlControlPanel.Controls.Add(btnNext);
            pnlControlPanel.Controls.Add(gbxFunctionalityChoice);
            pnlControlPanel.Controls.Add(lbxPreviousActionsTC);
            pnlControlPanel.Enabled = false;
            pnlControlPanel.Location = new Point(21, 231);
            pnlControlPanel.Name = "pnlControlPanel";
            pnlControlPanel.Size = new Size(755, 177);
            pnlControlPanel.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 24);
            panel1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(720, 0);
            button1.Name = "button1";
            button1.Size = new Size(64, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Win1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 438);
            ControlBox = false;
            Controls.Add(pnlControlPanel);
            Controls.Add(gbxAuthorizationForm);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Win1";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Форма авторизации";
            gbxAuthorizationForm.ResumeLayout(false);
            gbxAuthorizationForm.PerformLayout();
            gbxFunctionalityChoice.ResumeLayout(false);
            pnlControlPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
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
        private Panel panel1;
        private Button button1;
    }
}