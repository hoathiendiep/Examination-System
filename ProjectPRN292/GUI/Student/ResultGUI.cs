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
    public partial class Result : Form
    {
        StudentOperation parent;

        public Result(float score, StudentOperation parent)
        {
            InitializeComponent();
            lblScore.Text = score.ToString();
            this.parent = parent;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void Result_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            parent.Dispose();
            new Start().ShowDialog();
        }
    }
}
