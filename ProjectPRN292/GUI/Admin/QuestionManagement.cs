using ProjectPRN292.DAL;
using ProjectPRN292.dao;
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
    public partial class QuestionManagement : Form
    {
        public QuestionManagement()
        {
            InitializeComponent();
            cbxSubjectName.DataSource = SubjectDAO.GetDataTable();
            cbxSubjectName.ValueMember = "Subject_ID";
            cbxSubjectName.DisplayMember = "SubjectName";
            cbxSubjectName.SelectedIndex = 0;
            txtSubjectID.Text = cbxSubjectName.SelectedValue.ToString();

            dgvChap.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubjectName.SelectedValue.ToString()));
            if (dgvChap.Rows.Count!=0)
            {

                int chapID = Convert.ToInt32(dgvChap.Rows[0].Cells["Chapter_ID"].Value);
                dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
                dgvQuestion.Columns["Answer_ID"].Visible = false;
                dgvChap.Rows[0].Selected = true;
                lblNo.Text = dgvQuestion.Rows.Count-1 + "";

                DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
                Editlink.UseColumnTextForLinkValue = true;
                Editlink.HeaderText = "Edit";
                Editlink.DataPropertyName = "lnkColumn";
                Editlink.LinkBehavior = LinkBehavior.SystemDefault;
                Editlink.Text = "Edit";
                dgvQuestion.Columns.Add(Editlink);

                //Delete link

                DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
                Deletelink.UseColumnTextForLinkValue = true;
                Deletelink.HeaderText = "Delete";
                Deletelink.DataPropertyName = "lnkColumn";
                Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
                Deletelink.Text = "Delete";
                
                dgvQuestion.Columns.Add(Deletelink);
            }
        }

        private void CbxSubjectName_DropDownClosed(object sender, EventArgs e)
        {
            txtSubjectID.Text = cbxSubjectName.SelectedValue.ToString();

            dgvChap.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubjectName.SelectedValue.ToString()));
            if (dgvChap.Rows.Count != 0)
            {
                dgvChap.Rows[0].Selected = true;

                int chapID = Convert.ToInt32(dgvChap.Rows[0].Cells["Chapter_ID"].Value);
                dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
                dgvQuestion.Columns["Answer_ID"].Visible = false;
            }
        }

        private void DgvQuestion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = dgvQuestion.Rows.Count - 1 + "";
        }
        public int chapID { get; set; }

        private void DgvChap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex+1 == dgvChap.Rows.Count)
            {
                return;
            }
            chapID = Convert.ToInt32(dgvChap.Rows[e.RowIndex].Cells["Chapter_ID"].Value);
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
            btnAddQuestion.Enabled = true;
        }

        private void BtnAddChap_Click(object sender, EventArgs e)
        {
            AddNewChapter frm = new AddNewChapter(this);
            this.Enabled = false;
            frm.Show();
        }

        private void DgvChap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int chapID = Convert.ToInt32(dgvChap.Rows[0].Cells["Chapter_ID"].Value);
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
        }

        public int quesid { get; set; }
        private void DgvQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex+1 == DgvQuestion.Rows.Count|| e.ColumnIndex < 0 || e.ColumnIndex + 1 == DgvQuestion.Columns.Count)
            {
                return;
            }
            string opt = "";
            quesid = Convert.ToInt32(dgvQuestion.Rows[e.RowIndex].Cells["ID"].Value);
            opt = dgvQuestion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (opt.Equals("Delete"))
            {
                DialogResult dr = MessageBox.Show("You want to delete this selected question?", "Confirm", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                if (QuestionDAO.DeletebyID(quesid))
                {
                    MessageBox.Show("Delete successful!");
                    int chapID = Convert.ToInt32(dgvChap.Rows[0].Cells["Chapter_ID"].Value);
                    dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
                    dgvQuestion.Columns["Answer_ID"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else if (opt.Equals("Edit"))
            {
                AddEditQuestion aq = new AddEditQuestion(this, false);
                aq.ShowDialog();
            }
        }

        private void BtnAddQuestion_Click(object sender, EventArgs e)
        {
            AddEditQuestion aq = new AddEditQuestion(this,true);
            aq.ShowDialog();
        }
    }
}
