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
    public partial class AddNewChapter : Form
    {
        QuestionManagement parent;
        public AddNewChapter(QuestionManagement parent)
        {
            InitializeComponent();
            this.parent = parent;
            txtSubjectName.Text = parent.CbxSubjectName.Text;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string chap = txtChapter.Text;
            if (chap.Trim().Length == 0)
            {
                MessageBox.Show("Please enter chapter's name");
                return;
            }
            int subid = Convert.ToInt32(parent.TxtSubjectID.Text);
            if(!ChapterDAO.AddDataBySubjectID(subid, chap))
            {
                return;
            }
            parent.DgvChap.DataSource = ChapterDAO.GetDataBySubjectID(subid);
            parent.Enabled = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;

            this.Close();

        }

        private void AddNewChapter_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Enabled = true;

        }
    }
}
