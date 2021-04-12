using ProjectPRN292.DAL;
using ProjectPRN292.GUI.Admin;
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
    public partial class AdminLogin : Form
    {
        string name;
        Start startPage;
        public AdminLogin(Start startPage)
        {
            InitializeComponent();
            this.startPage = startPage;
        }

        public string Name1 { get => name; set => name = value; }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            name = txtUsername.Text;
            string pass = txtPassword.Text;
            if (AdminDAO.checkLogin(name, pass))
            {
                AdminManage admin = new AdminManage(this);
                admin.Show();
                startPage.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect input!");
            }
        }
    }
}
