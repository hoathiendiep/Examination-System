using ProjectPRN292.DAL;
using ProjectPRN292.dao;
using ProjectPRN292.MODEL;
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
    public partial class ExamManagement : Form
    {
        int add;
        Dictionary<int, List<int>> selectedID;
        
        public ExamManagement()
        {
            InitializeComponent();
            display(0);
            selectedID = new Dictionary<int, List<int>>();
            dgvExam.DataSource = ExamDAO.GetDataTable();
            dgvExam.Columns["Exam_Code"].Visible = false;
            dgvExam.Columns["Subject_ID"].Visible = false;

            cbxSubject.ValueMember = "Subject_ID";
            cbxSubject.DisplayMember = "SubjectName";
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;

            dgvQuestion.AllowUserToAddRows = false;

            //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();

            //checkColumn.HeaderText = "Select";
            //checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //checkColumn.TrueValue = true;
            //checkColumn.FalseValue = false;
            //dgvQuestion.Columns.Add(checkColumn);

        }

        private void DgvExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex + 1 >= dgvExam.Rows.Count||e.ColumnIndex !=-1)
            {
                return;
            }
            selectedID.Clear();
            txtExamCode.Text = dgvExam.SelectedRows[0].Cells["Exam_Code"].Value.ToString();
            txtExamName.Text = dgvExam.SelectedRows[0].Cells["ExamName"].Value.ToString();
            cbxSubject.SelectedValue = dgvExam.SelectedRows[0].Cells["Subject_ID"].Value.ToString();

            cbxChapter.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubject.SelectedValue.ToString()));

            cbxChapter.SelectedIndex = 0;
            selectedID = ExamDAO.GetChapterAndQuestion(txtExamCode.Text,this);
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));
            dgvQuestion.EndEdit();

            int cnt = 0;
            foreach (KeyValuePair<int, List<int>> entry in selectedID)
            {
                cnt += entry.Value.Count;
            }
            lblSelected.Text = cnt + "";
        }
        private void display(int status)
        {
            switch (status)
            {
                case 0:
                    add = -1;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = true;
                    dgvExam.Enabled = true;
                    dgvQuestion.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtExamCode.Enabled = false;
                    txtExamName.Enabled = false;
                    cbxSubject.Enabled = false;
                    btnRandom.Enabled = false;
                    nudQues.Enabled = false;
                    break;
                case 1:
                    dgvExam.Enabled = false;
                    dgvQuestion.Enabled = true;
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnRemove.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    txtExamCode.Enabled = true;
                    txtExamName.Enabled = true;
                    cbxSubject.Enabled = true;
                    btnRandom.Enabled = true;
                    nudQues.Enabled = true;
                    break;
            }

        }
        private void CbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxChapter.ValueMember = "Chapter_ID";
            cbxChapter.DisplayMember = "ChapterName";
            cbxChapter.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubject.SelectedValue.ToString()));
            if (cbxChapter.Items.Count != 0)
            {
                cbxChapter.SelectedIndex = 0;
                selectedID.Clear();
                for (int i = 0; i < cbxChapter.Items.Count; i++)
                {
                    selectedID.Add(i, new List<int>());
                }
            }
        }
        private void CbxSubject_DropDownClosed(object sender, EventArgs e)
        {
            cbxChapter.ValueMember = "Chapter_ID";
            cbxChapter.DisplayMember = "ChapterName";
            cbxChapter.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubject.SelectedValue.ToString()));
            if (cbxChapter.Items.Count != 0)
            {
                cbxChapter.SelectedIndex = 0;
                selectedID.Clear();
                for (int i = 0; i < cbxChapter.Items.Count; i++)
                {
                    selectedID.Add(i, new List<int>());
                }
                lblSelected.Text = "0";
                dgvQuestion.Enabled = true;
                BtnRandom.Enabled = true;
            }
            else
            {
                BtnRandom.Enabled = false;
                dgvQuestion.Enabled = false;
                MessageBox.Show("There are no chapter for the chosen subject");
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            display(1);
            add = 1;
            selectedID = new Dictionary<int, List<int>>();
            nudQues.Value = 0;
            txtExamCode.Text = "";
            txtExamName.Text = "";
            lblSelected.Text = "0";
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;

        }

        Exam editedExam;
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExam.SelectedRows.Count <= 0)
            {
                MessageBox.Show("A selected exam required!");
                return;
            }
            display(1);
            add = -1;
            nudQues.Value = 0;
            editedExam = new Exam();
            editedExam.ExamCode = txtExamCode.Text;
            editedExam.ExamName = txtExamName.Text;
            editedExam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            foreach (KeyValuePair<int, List<int>> entry in selectedID)
            {
                foreach (int i in entry.Value)
                {
                    editedExam.lstQuesID.Add(i);
                }
            }
        }

        private void CbxChapter_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxChapter.Text.Length!=0)
            {
                dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));

                dgvQuestion.Columns["Answer_ID"].Visible = false;
            }

        }

        private void DgvQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvQuestion.Rows.Count-1)
            {
                return;
            }
            if(e.ColumnIndex == 0)
            {
                ((DataGridViewCheckBoxCell)dgvQuestion.Rows[e.RowIndex].Cells[0]).Value = !Convert.ToBoolean(dgvQuestion.Rows[e.RowIndex].Cells[0].Value);
                if (!selectedID.ContainsKey(cbxChapter.SelectedIndex))
                {
                    selectedID[cbxChapter.SelectedIndex] = new List<int>();
                }
                if (Convert.ToBoolean(dgvQuestion.Rows[e.RowIndex].Cells[0].Value))
                {
                    selectedID[cbxChapter.SelectedIndex].Add((int)dgvQuestion.Rows[e.RowIndex].Cells["ID"].Value);
                }
                else
                {
                    selectedID[cbxChapter.SelectedIndex].Remove((int)dgvQuestion.Rows[e.RowIndex].Cells["ID"].Value);
                }
                int cnt = 0;
                foreach (KeyValuePair<int, List<int>> entry in selectedID)
                {
                    cnt += entry.Value.Count;
                }
                lblSelected.Text = cnt + "";
                dgvQuestion.EndEdit();
            }
        }

        private void BtnRandom_Click(object sender, EventArgs e)
        {
            int numSelect = Convert.ToInt32(nudQues.Value.ToString());
            int total = dgvQuestion.Rows.Count ;
            if (numSelect < 1 || numSelect > total)
            {
                MessageBox.Show("Please enter number within the scope!");
                return;
            }
                selectedID[cbxChapter.SelectedIndex].Clear();
                for (int j = 0; j < dgvQuestion.Rows.Count; j++)
                {
                    dgvQuestion.Rows[j].Cells[0].Value = false;
                }
                List<int> selectIndex = new List<int>();
                Random rand = new Random();
                for (int i = 0; i < numSelect; i++)
                {
                    int random;
                    do
                    {
                        random = rand.Next(0, total);
                    } while (selectIndex.Contains(random));
                    selectIndex.Add(random);
                    dgvQuestion.Rows[random].Cells[0].Value = true;
                    selectedID[cbxChapter.SelectedIndex].Add(Convert.ToInt32(dgvQuestion.Rows[random].Cells["ID"].Value));
                }
            int cnt = 0;
            foreach (KeyValuePair<int, List<int>> entry in selectedID)
            {
                cnt += entry.Value.Count;
            }
            lblSelected.Text = cnt + "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtExamCode.Text.Trim().Length == 0||txtExamName.Text.Trim().Length == 0 || Convert.ToInt32(lblSelected.Text) == 0)
            {
                MessageBox.Show("Please enter full information before saving!");
                return;
            }
            if(Convert.ToInt32(lblSelected.Text) == 0)
            {
                MessageBox.Show("Please select questions before saving!");
                return;
            }
            if (add==1 && ExamDAO.checkExistExamCode(txtExamCode.Text))
            {
                MessageBox.Show("Exam code already existed!");
                return;
            }
            Exam exam = new Exam();
            exam.ExamCode = txtExamCode.Text;
            exam.ExamName = txtExamName.Text;
            exam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            foreach (KeyValuePair<int, List<int>> entry in selectedID)
            {
                foreach (int i in entry.Value)
                {
                    exam.lstQuesID.Add(i);
                }
            }
            if (add == 1)
            {
                if (ExamDAO.insertExam(exam,false))
                {
                    MessageBox.Show("Inserted!");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                dgvExam.DataSource = ExamDAO.GetDataTable();
                add = -1;
                display(0);
            }
            else
            {
                ExamDAO.deleteExam(editedExam,true);
                editedExam = null;
                if (ExamDAO.insertExam(exam,true))
                {
                    MessageBox.Show("Updated!");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                dgvExam.DataSource = ExamDAO.GetDataTable();
                display(0);
            }
            selectedID.Clear();
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));
        }

        private void DgvQuestion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (selectedID.ContainsKey(cbxChapter.SelectedIndex))
            {
                foreach(int i in selectedID[cbxChapter.SelectedIndex])
                {
                    for(int j = 0; j < dgvQuestion.Rows.Count; j++)
                    {
                        if((int)dgvQuestion.Rows[j].Cells["ID"].Value == i)
                        {
                            dgvQuestion.Rows[j].Cells[0].Value = true;
                            break;
                        }
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            display(0);
            if (add != 1)
            {
                editedExam = null;
            }
                selectedID.Clear();
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));
            dgvExam.Rows[dgvExam.SelectedCells[0].RowIndex].Selected = false;
            nudQues.Value = 0;
            txtExamCode.Text = "";
            txtExamName.Text = "";
            lblSelected.Text = "0";
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvExam.SelectedRows.Count <= 0)
            {
                MessageBox.Show("A selected exam required!");
                return;
            }
            //add = -1;
            nudQues.Value = 0;
            Exam exam = new Exam();
            exam.ExamCode = txtExamCode.Text;
            exam.ExamName = txtExamName.Text;
            exam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            foreach (KeyValuePair<int, List<int>> entry in selectedID)
            {
                foreach (int i in entry.Value)
                {
                    exam.lstQuesID.Add(i);
                }
            }
            DialogResult dr = MessageBox.Show("You want to delete this selected exam?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;
            if (ExamDAO.deleteExam(exam,false))
                MessageBox.Show("Deleted");
            else
                MessageBox.Show("Error");
            selectedID.Clear();
            dgvExam.DataSource = ExamDAO.GetDataTable();
            dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));
        }

        private void DgvExam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
