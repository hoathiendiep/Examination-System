
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
    public partial class AddQuestion : Form
    {
        QuestionManagement parent;

        public AddQuestion(QuestionManagement parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        List<AnswerControl> answerControls = new List<AnswerControl>();
        private void btnMoreAnswer_Click(object sender, EventArgs e)
        {
            AnswerControl ac = new AnswerControl(answerControls.Count + 1);
            answerControls.Add(ac);
            pnAnswers.Controls.Add(ac);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            q.Chapter.Id = Convert.ToInt32(txt.Text);
            q.Content = txtContent.Text;
            q.Time = Convert.ToInt32(txtTime.Text);
            q.Answers = new List<Answer>();

            foreach (AnswerControl ac in answerControls)
            {
               Answer a = ac.getAnswer();
                q.Answers.Add(a);
            }

            QuestionDAO db = new QuestionDAO();
            db.insertQuestion(q);

            int chapID = Convert.ToInt32(parent.DgvChap.SelectedRows[0].Cells["Chapter_ID"].Value);
            parent.DgvQuestion.DataSource = QuestionDAO.GetDataByChapterID(chapID);
            parent.Enabled = true;
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
