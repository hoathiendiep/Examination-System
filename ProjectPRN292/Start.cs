using ProjectPRN292.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void ButtonAdmin_Click(object sender, EventArgs e)
        {
            addForm(new AdminLogin(this));
        }
        private void addForm(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(f);
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            addForm(new StudentLogin(this));
        }

        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
