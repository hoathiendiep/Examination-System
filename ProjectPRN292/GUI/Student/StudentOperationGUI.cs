using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.GUI
{
    public partial class StudentOperation : Form
    {
        public StudentOperation(string ecode, string sid)
        {
            InitializeComponent();
            addForm(new TakingTest(ecode, sid,this));
        }
        public void addForm(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(f);
        }

        private void StudentOperation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            new Start().ShowDialog();
        }
    }
}
