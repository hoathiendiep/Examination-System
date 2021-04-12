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
    public partial class ViewScore : Form
    {
        public ViewScore()
        {
            InitializeComponent();
            dgvExam.DataSource = ExamDAO.GetDataTableForScore();
            dgvExam.AutoGenerateColumns = false;
            dgvExam.Columns["Exam_Code"].Visible = false;
            display(0);
            txtStudentID.Enabled = false;
            txtFname.Enabled = false;
            txtLname.Enabled = false;
            dtpTestDate.Enabled = false;
            
        }

        private void display(int status)
        {
            switch (status)
            {
                case 0:
                    txtScore.Enabled = false;
                    btnRemove.Enabled = true;
                    btnEdit.Enabled = true;
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                    dgvExam.Enabled = true;
                    dgvResults.Enabled = true;
                    break;
                case 1:
                    txtScore.Enabled = true;
                    btnRemove.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                    dgvExam.Enabled = false;
                    dgvResults.Enabled = false;

                    break;
            }

        }
        private void TxtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgvExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string code = dgvExam.Rows[e.RowIndex].Cells["Exam_Code"].Value.ToString();
            dgvResults.DataSource = ExamDAO.selectByExamCode(code);
        }

        private void DgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            txtStudentID.Text = dgvResults.SelectedRows[0].Cells["Student_ID"].Value.ToString();
            txtFname.Text = dgvResults.SelectedRows[0].Cells["FirstName"].Value.ToString();
            txtLname.Text = dgvResults.SelectedRows[0].Cells["LastName"].Value.ToString();

            dtpTestDate.Value = DateTime.Parse(dgvResults.SelectedRows[0].Cells["testDate"].Value.ToString());
            txtScore.Text = dgvResults.SelectedRows[0].Cells["Score"].Value.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a exam result!");
                return;
            }
            display(1);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            float score;
            try
            {
                 score = float.Parse(txtScore.Text);
            }
            catch
            {
                MessageBox.Show("Please input full and in correct format");
                return;
            }
            DateTime testDate= DateTime.Parse(dgvResults.SelectedRows[0].Cells["testDate"].Value.ToString());
            string code = dgvExam.SelectedRows[0].Cells["Exam_Code"].Value.ToString();
            int sid = Convert.ToInt32(txtStudentID.Text);
            if (ExamResultDAO.updateScoreandDate(score, testDate, code,sid))
            {
                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
            display(0);
            dgvResults.ClearSelection();
            dgvResults.DataSource = ExamDAO.selectByExamCode(code);


        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a exam result!");
                return;
            }
            DialogResult dr = MessageBox.Show("You want to delete this selected result?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            string code = dgvExam.SelectedRows[0].Cells["Exam_Code"].Value.ToString();
            int sid = Convert.ToInt32(txtStudentID.Text);
            DateTime testDate = DateTime.Parse(dgvResults.SelectedRows[0].Cells["testDate"].Value.ToString());

            if (ExamResultDAO.deleteScoreandDate(code, sid, testDate))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Error!");
            }
            display(0);
            dgvResults.ClearSelection();
            dgvResults.DataSource = ExamDAO.selectByExamCode(code);

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            display(0);
            dgvResults.ClearSelection();
        }
    }
}
