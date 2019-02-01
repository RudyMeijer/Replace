using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Replace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lblLog.Text = Program.Replace(txtSRC.Text, txtDST.Text, txtInfile.Text, txtOutfile.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInfile.Text = txtOutfile.Text = openFileDialog1.FileName;
            }
        }

        private void txtInfile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start("notepad", (sender as TextBox).Text);
        }
    }
}
