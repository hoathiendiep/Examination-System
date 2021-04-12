
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
    public partial class AddEditQuestionGUI : Form
    {
        QuestionManageGUI parent;
        bool isAdd;
        List<AnswerControlGUI> answerControls = new List<AnswerControlGUI>();
        List<Answer> answLs;
        public int numOfavailable { get; set; }
        public List<AnswerControlGUI> AnswerControls { get => answerControls; set => answerControls = value; }
        public bool IsAdd { get => isAdd; set => isAdd = value; }
        public List<Answer> AnswLs { get => answLs; set => answLs = value; }

        public AddEditQuestionGUI(QuestionManageGUI parent, bool isAdd)
        {
            InitializeComponent();
            answLs = new List<Answer>();
            this.parent = parent;
            this.isAdd = isAdd;
            txtSubName.Text = parent.CbxSubjectName.Text;
            if (parent.DgvChap.SelectedRows.Count == 0)
            {
                txtChapterName.Text = parent.DgvChap.Rows[0].Cells["ChapterName"].Value.ToString();
            }
            else
            {
                txtChapterName.Text = parent.DgvChap.SelectedRows[0].Cells["ChapterName"].Value.ToString();
            }
            if (!isAdd)
            {
                this.Text = "Edit";
                answLs = AnswerDAO.getAnswers(parent.quesid);
                numOfavailable = answLs.Count;
                TxtContent.Text = answLs[0].Q.Content;
                foreach (Answer ans in answLs)
                {
                    AnswerControlGUI ac = new AnswerControlGUI(answerControls.Count + 1, isAdd, this);
                    ac.TxtContent.Text = ans.Content;
                    ac.Id = ans.Id;
                    ac.CbxIsCorrected.Checked = ans.IsCorrect;
                    answerControls.Add(ac);
                    pnAnswers.Controls.Add(ac);
                }
            }
        }

        private void btnMoreAnswer_Click(object sender, EventArgs e)
        {
            AnswerControlGUI ac = new AnswerControlGUI(answerControls.Count + 1, isAdd, this);
            ac.Id = 0;
            answerControls.Add(ac);
            pnAnswers.Controls.Add(ac);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            if (parent.DgvChap.SelectedRows.Count == 0)
            {
                q.Chapter.Id = Convert.ToInt32(parent.DgvChap.Rows[0].Cells["Chapter_ID"].Value.ToString());
            }
            else
            {
                q.Chapter.Id = Convert.ToInt32(parent.DgvChap.SelectedRows[0].Cells["Chapter_ID"].Value.ToString());
            }
            do
            {
                try
                {
                    q.Content = txtContent.Text;
                    if (q.Content.Trim().Length == 0) throw new Exception();
                    if (answerControls.Count < 2) throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter correct input of both question and answer!");
                    return;
                }
            } while (true);

            q.Answers = new List<Answer>();
            bool containTrue = false;

            if (isAdd)
            {
                foreach (AnswerControlGUI ac in answerControls)
                {
                    if (ac.TxtContent.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please enter content of answer!");
                        return;
                    }

                    if (ac.CbxIsCorrected.Checked)
                        containTrue = true;
                    Answer a = ac.getAnswer();
                    q.Answers.Add(a);
                }
                if (!containTrue)
                {
                    MessageBox.Show("Please input the true answer!");
                    return;
                }
                QuestionDAO.insertQuestion(q);
            }
            else
            {
                for (int i = 0; i < answerControls.Count; i++)
                {
                    Answer a = null;
                    if (answerControls[i].Id != 0)
                    {
                        a = new Answer();
                        a.Id = answerControls[i].Id;
                        a.Content = answerControls[i].TxtContent.Text;
                        a.IsCorrect = answerControls[i].CbxIsCorrected.Checked;
                    }
                    else
                    {
                        a = answerControls[i].getAnswer();
                    }
                    if (answerControls[i].TxtContent.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please enter content of answer!");
                        return;
                    }

                    if (answerControls[i].CbxIsCorrected.Checked)
                        containTrue = true;
                    q.Answers.Add(a);
                }
                if (!containTrue)
                {
                    MessageBox.Show("Please input the true answer!");
                    return;
                }
                q.Id = parent.quesid;
                QuestionDAO.updateQuestion(q);
            }
            int chapID;
            if (parent.DgvChap.SelectedRows.Count == 0)
            {
                chapID = Convert.ToInt32(parent.DgvChap.Rows[0].Cells["Chapter_ID"].Value.ToString());
            }
            else
            {
                chapID = Convert.ToInt32(parent.DgvChap.SelectedRows[0].Cells["Chapter_ID"].Value.ToString());
            }
            parent.DgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
            parent.Enabled = true;
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
