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
            btnBack = new Button();
            btnNext = new Button();
            listBox1 = new ListBox();
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
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(593, 395);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(160, 45);
            btnNext.TabIndex = 6;
            btnNext.Text = "Далее";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(28, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(725, 344);
            listBox1.TabIndex = 8;
            // 
            // Win3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(listBox1);
            Controls.Add(btnBack);
            Controls.Add(btnNext);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Win3";
            ShowIcon = false;
            Text = "Выбор объекта редактирования";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBack;
        private Button btnNext;
        private ListBox listBox1;
    }
}