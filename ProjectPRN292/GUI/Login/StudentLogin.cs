using ProjectPRN292.DAL;
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
    public partial class StudentLogin : Form
    {
        Start startPage;

        public StudentLogin(Start startPage)
        {
            InitializeComponent();
            this.startPage = startPage;

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StudentLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (StudentDAO.checkLogin(txtUsername.Text, txtPassword.Text, txtCode.Text))
            {
                StudentOperation form = new StudentOperation(txtCode.Text, txtUsername.Text);
                form.Show();
                startPage.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect input!");
            }
        }
    }
}
