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
    public partial class AdminManage : Form
    {
        AdminLogin ad;
        string user;
        public string User { get => user; set => user = value; }
        public AdminManage(AdminLogin ad)
        {
            InitializeComponent();
            this.ad = ad;
            user = ad.Name1;
        }

        private void ViewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new StudentInfo());
        }

        private void addForm(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            this.toolStripContainer1.ContentPanel.Controls.Clear();
            this.toolStripContainer1.ContentPanel.Controls.Add(f);
        }

        private void ViewScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new StudentScore());
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new AccountSettings(this));

        }

        private void CourseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CreateExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new ExamManagement());

        }


        private void AdminManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ViewQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new QuestionManagement());

        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Start().ShowDialog();
        }

        private void ViewScoreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addForm(new ViewScore());
        }

        private void SubjectManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm(new SubjectManagement());

        }
    }
}
