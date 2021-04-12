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
    public partial class ExamManageGUI : Form
    {
        int add;


        public ExamManageGUI()
        {
            InitializeComponent();
            display(0);
            dgvExam.DataSource = ExamDAO.GetDataTable();
            dgvExam.Columns["Exam_Code"].Visible = false;
            dgvExam.Columns["Subject_ID"].Visible = false;

            cbxSubject.ValueMember = "Subject_ID";
            cbxSubject.DisplayMember = "SubjectName";
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;

            dgvQuestion.AllowUserToAddRows = false;
            dgvExam.AllowUserToAddRows = false;


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
                    txtTime.Enabled = false;
                    txtExamName.Enabled = false;
                    cbxSubject.Enabled = false;
                    btnRandom.Enabled = false;
                    nudQues.Enabled = false;
                    lbChapter.Enabled = false;
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
                    lbChapter.Enabled = true;
                    txtTime.Enabled = true;
                    break;
            }

        }
        private void CbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {            
            lbChapter.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubject.SelectedValue.ToString()));
            lbChapter.ValueMember = "Chapter_ID";
            lbChapter.DisplayMember = "ChapterName";
            dgvQuestion.DataSource = null;
            lblSelected.Text = "0";
            nudQues.Value = 0;
            for (int i = 0; i < lbChapter.Items.Count; i++)
            {
                lbChapter.SetItemCheckState(i, (CheckState.Unchecked));

            }
        }
        private void CbxSubject_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            display(1);
            add = 1;
            nudQues.Value = 0;
            txtExamCode.Text = "";
            txtExamName.Text = "";
            txtTime.Text = "";
            lblSelected.Text = "0";
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;

            for (int i = 0; i < lbChapter.Items.Count; i++)
            {
                lbChapter.SetItemCheckState(i, (CheckState.Unchecked));

            }
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
            editedExam.Total = Convert.ToInt32(lblSelected.Text);
            editedExam.Time = Convert.ToInt32(txtTime.Text);
            editedExam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            editedExam.lstQuesID = ExamQuestionDAO.quesList(txtExamCode.Text); ;
        }

        private void CbxChapter_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void DgvQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dgvQuestion.Rows.Count - 1)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                ((DataGridViewCheckBoxCell)dgvQuestion.Rows[e.RowIndex].Cells[0]).Value = !Convert.ToBoolean(dgvQuestion.Rows[e.RowIndex].Cells[0].Value);
                //if (!selectedID.ContainsKey(cbxChapter.SelectedIndex))
                //{
                //    selectedID[cbxChapter.SelectedIndex] = new List<int>();
                //}
                //if (Convert.ToBoolean(dgvQuestion.Rows[e.RowIndex].Cells[0].Value))
                //{
                //    selectedID[cbxChapter.SelectedIndex].Add((int)dgvQuestion.Rows[e.RowIndex].Cells["ID"].Value);
                //}
                //else
                //{
                //    selectedID[cbxChapter.SelectedIndex].Remove((int)dgvQuestion.Rows[e.RowIndex].Cells["ID"].Value);
                //}
                //int cnt = 0;
                //foreach (KeyValuePair<int, List<int>> entry in selectedID)
                //{
                //    cnt += entry.Value.Count;
                //}
                ////lblSelected.Text = cnt + "";
                //dgvQuestion.EndEdit();
            }
        }

        Dictionary<int, List<int>> selectedQuesforChap;
        List<int> selectedQuesID;
        private void BtnRandom_Click(object sender, EventArgs e)
        {
            int totalQues = 0;
            int j = 0;
            selectedQuesforChap = new Dictionary<int, List<int>>();
            selectedQuesID = new List<int>();
            for (int i = 0; i < lbChapter.Items.Count; i++)
            {
                if (lbChapter.GetItemChecked(i))
                {
                    var row = (lbChapter.Items[i] as DataRowView).Row;
                    List<int> quesID = QuestionDAO.getQuesByChap(Convert.ToInt32(row["Chapter_ID"]));
                    totalQues += quesID.Count;
                    selectedQuesforChap.Add(j++, quesID);
                }
            }

            int numSelect = Convert.ToInt32(nudQues.Value.ToString());
            if (numSelect < 1 || numSelect > totalQues)
            {
                MessageBox.Show("Please enter number within the scope!");
                return;
            }


            int avgTotal = (int)Math.Ceiling(decimal.Parse(numSelect.ToString()) / selectedQuesforChap.Count);
            Random rnd;
            for (int index = 0; selectedQuesID.Count < numSelect; index++)
            {
                List<int> ques = selectedQuesforChap.ElementAt(index).Value;
                if(ques.Count <= avgTotal)
                {
                    if(!selectedQuesID.Contains(ques[0]))
                    selectedQuesID.AddRange(ques);
                }
                else
                {
                    int quesID;
                    do
                    {
                        rnd = new Random();
                        quesID = ques[rnd.Next(ques.Count)];
                    } while (selectedQuesID.IndexOf(quesID) != -1);
                    selectedQuesID.Add(quesID);
                }
                

                if (index + 1 == selectedQuesforChap.Count)
                {
                    index = -1;
                }
            }
            dgvQuestion.DataSource = ExamQuestionDAO.displayRandomQuestion(selectedQuesID);

            lblSelected.Text = selectedQuesID.Count + "";
            //editedExam.lstQuesID = selectedQuesID;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExamCode.Text) || string.IsNullOrEmpty(txtExamName.Text) || string.IsNullOrEmpty(txtTime.Text))
            {
                MessageBox.Show("Please enter full information before saving!");
                return;
            }
            if (int.TryParse(txtTime.Text, out int output))
            {
                int time = Convert.ToInt32(txtTime.Text);
                if (time <=0)
                {
                    MessageBox.Show("Time must be bigger than 0!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Time is not a string");
                return;
            }
            if (Convert.ToInt32(lblSelected.Text) == 0)
            {
                MessageBox.Show("Please select questions before saving!");
                return;
            }
            if (add == 1 && ExamDAO.checkExistExamCode(txtExamCode.Text))
            {
                MessageBox.Show("Exam code already existed!");
                return;
            }
            Exam exam = new Exam();
            exam.ExamCode = txtExamCode.Text;
            exam.ExamName = txtExamName.Text;
            exam.Total = Convert.ToInt32(lblSelected.Text);
            exam.Time = Convert.ToInt32(txtTime.Text);
            exam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            foreach(int i in selectedQuesID){
                exam.lstQuesID.Add(i);
            }
            if (add == 1)
            {
                if (ExamDAO.insertExam(exam, false))
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
                ExamDAO.deleteExam(editedExam, true);
                editedExam = null;
                if (ExamDAO.insertExam(exam, true))
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

        }

        private void DgvQuestion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            display(0);
            if (add != 1)
            {
                editedExam = null;
            }
            //selectedID.Clear();
            //dgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(Convert.ToInt32(cbxChapter.SelectedValue.ToString()));
            //dgvExam.Rows[dgvExam.SelectedCells[0].RowIndex].Selected = false;
            nudQues.Value = 0;
            txtExamCode.Text = "";
            txtExamName.Text = "";
            txtTime.Text = "0";
            lblSelected.Text = "0"; 
            cbxSubject.DataSource = SubjectDAO.GetDataTable();
            cbxSubject.SelectedIndex = 0;
            dgvQuestion.DataSource = null;
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
            lblSelected.Text = "0";
            Exam exam = new Exam();
            exam.ExamCode = txtExamCode.Text;
            exam.ExamName = txtExamName.Text;
            exam.Subject.Id = Convert.ToInt32(cbxSubject.SelectedValue);
            
            DialogResult dr = MessageBox.Show("You want to delete this selected exam?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;
            if (ExamDAO.deleteExam(exam, false))
                MessageBox.Show("Deleted");
            else
                MessageBox.Show("Error");
            dgvExam.DataSource = ExamDAO.GetDataTable();
        }

        private void BtnLoadQuestion_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void NudQues_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void LblSelected_Click(object sender, EventArgs e)
        {

        }

        private void BtnRandom_Click_1(object sender, EventArgs e)
        {

        }

        private void DgvExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 )
            {
                return;
            }

            txtExamCode.Text = dgvExam.SelectedRows[0].Cells["Exam_Code"].Value.ToString();
            txtExamName.Text = dgvExam.SelectedRows[0].Cells["ExamName"].Value.ToString();
            lblSelected.Text = dgvExam.SelectedRows[0].Cells["TotalQuestion"].Value.ToString();
            txtTime.Text = dgvExam.SelectedRows[0].Cells["Time"].Value.ToString(); 
            cbxSubject.SelectedValue = dgvExam.SelectedRows[0].Cells["Subject_ID"].Value.ToString();
            selectedQuesID = ExamQuestionDAO.quesList(txtExamCode.Text);
            lblSelected.Text = selectedQuesID.Count+"";
            lbChapter.DataSource = ChapterDAO.GetDataBySubjectID(Convert.ToInt32(cbxSubject.SelectedValue.ToString()));
            lbChapter.ValueMember = "Chapter_ID";
            lbChapter.DisplayMember = "ChapterName";
            lbChapter.SelectedIndex = 0;
            
            dgvQuestion.DataSource = QuestionDAO.GetDataByExamCode(txtExamCode.Text);
            dgvQuestion.EndEdit();

            DataTable selectedChap = ExamQuestionDAO.chapterList(txtExamCode.Text.Trim());

            for (int i = 0; i < lbChapter.Items.Count; i++)
            {
                DataRowView drv = lbChapter.Items[i] as DataRowView;

                int id = Convert.ToInt16(drv["Chapter_ID"]);
                foreach (DataRow dr in selectedChap.Rows)
                {
                    if (Convert.ToInt16(dr["Chapter_ID"]) == id)
                    {
                        lbChapter.SetItemChecked(i, true);  //true means set it to checked
                    }
                }
            }


        }
        
        private void LbChapter_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void DgvQuestion_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvQuestion.Columns["ID"].Visible = false;
            dgvQuestion.Columns["Answer_ID"].Visible = false;
        }
    }
}
