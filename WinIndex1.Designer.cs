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
            lblInformVer = new Label();
            lblIinformProgramName = new Label();
            groupBox1 = new GroupBox();
            gbxInformation.SuspendLayout();
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
            // lblInformVer
            // 
            lblInformVer.AutoSize = true;
            lblInformVer.Location = new Point(23, 79);
            lblInformVer.Name = "lblInformVer";
            lblInformVer.Size = new Size(74, 20);
            lblInformVer.TabIndex = 0;
            lblInformVer.Text = "Версия: 0";
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
            // groupBox1
            // 
            groupBox1.Location = new Point(23, 189);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // WinIndex1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(gbxInformation);
            Name = "WinIndex1";
            Text = "WinIndex1";
            gbxInformation.ResumeLayout(false);
            gbxInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxInformation;
        private Label lblIinformProgramName;
        private Label lblInformVer;
        private GroupBox groupBox1;
    }
}