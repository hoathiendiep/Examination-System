using ProjectPRN292.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.GUI.Admin
{
    public partial class AccountSettingsGUI : Form
    {
        AdminManageGUI am;
        string user;
        public AccountSettingsGUI(AdminManageGUI am)
        {
            InitializeComponent();
            display(0);
            this.am = am;
            user = am.User;
        }
        private void display(int status)
        {
            switch (status)
            {
                case 0:
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    btnChangePass.Enabled = true;
                    break;
                case 1:
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnChangePass.Enabled = false;
                    break;
            }

        }
        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            display(1);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == null || textBox2.Text == "" || textBox1.Text == null || textBox1.Text == "" || textBox3.Text == null || textBox3.Text == "")
            {
                MessageBox.Show("Input empty");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Your new password doesn't match");
                return;
            }
            if (AdminDAO.checkpassword(user, textBox1.Text) == false)
            {
                MessageBox.Show("Your old password doesn't match");
                return;
            }
            AdminDAO.EditPassword(user, textBox2.Text);
            MessageBox.Show("Password changed");
            display(0);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            display(0);
        }
    }
}
