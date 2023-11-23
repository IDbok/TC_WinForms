using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TC_WinForms
{
    public partial class Win3 : Form
    {
        public Win3()
        {
            InitializeComponent();
        }
        private void Win3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            Program.MainForm.Show();
        }
    }
}
