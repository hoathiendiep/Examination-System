using ProjectPRN292;
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

namespace ProjectPRN292.GUI
{
    public partial class TakingTest : Form
    {
        List<Question> lsQuestion;
        string ecode;
        string sid;
        StudentOperation parent;
        List<Button> questionButtons = new List<Button>();
        List<QuestionControl> questionControls = new List<QuestionControl>();
        float score;
        public Dictionary<int, List<string>> userAnswers { get;  }
        int RemainingTime = 0;
        public Dictionary<int, List<int>> stdResult { get; set; }
        public TakingTest(string ecode,string sid, StudentOperation parent)
        {
            InitializeComponent();
            this.ecode = ecode;
            this.sid = sid;
            this.parent = parent;
            score = 0;
            lsQuestion = QuestionDAO.getQuestionsByExamCode(ecode);
            userAnswers = new Dictionary<int, List<string>>();
            stdResult = new Dictionary<int, List<int>>();

            for (int i = 0; i < lsQuestion.Count; i++)
            {
                Button questionButton = new Button();
                questionButton.Text = (i + 1).ToString();
                questionButtons.Add(questionButton);
                pnlQuestionButtons.Controls.Add(questionButton);
                questionButton.Click += questionButton_Click;
                questionButton.BackColor = Color.White;

                QuestionControl qc = new QuestionControl(lsQuestion[i], this);
                questionControls.Add(qc);

                userAnswers.Add(lsQuestion[i].Id, new List<string>());
                    stdResult.Add(lsQuestion[i].Id, new List<int>());
            }
            DataTable dt = ExamDAO.GetDataTable("SELECT [Time]  FROM[ProjectPRN292].[dbo].[Exam] where Exam_Code="+ecode.Trim());
            RemainingTime = Convert.ToInt32(dt.Rows[0][0].ToString())*60;
            display(questionControls[0]);
            loadtime();
            timer1.Enabled = true;

        }

        private void loadtime()
        {
            int hour = RemainingTime / 3600;
            int minute = (RemainingTime / 60) % 60;
            int second = (RemainingTime) % 60;
            lblTime.Text = hour + ":" + minute + ":" + second;
        }

        private void display(QuestionControl qc)
        {
            pnlQuestionControl.Controls.Clear();
            pnlQuestionControl.Controls.Add(qc);
        }
        public void MarkedAsAnswered(Question q, bool isAnswered)
        {
            for(int i = 0; i < lsQuestion.Count; i++)
            {
                if(lsQuestion[i] == q)
                {
                    if (isAnswered)
                    {
                        questionButtons[i].BackColor = Color.Green;
                    }
                    else
                    {
                        questionButtons[i].BackColor = Color.White;
                    }
                }
            }
        }

        private void questionButton_Click(object sender, EventArgs e)
        {
            Button btnQuestion = (Button)sender;
            for(int i = 0; i < questionButtons.Count; i++)
            {
                if(questionButtons[i] == btnQuestion)
                {
                    display(questionControls[i]);
                    return;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            RemainingTime--;
            loadtime();
            if (RemainingTime < 0)
            {
                timer1.Enabled = false;
                finish();
            }
        }

        private void calculateScore()
        {

            bool correct;
            for (int i = 0; i < lsQuestion.Count; i++)
            {
                correct = false;
                List<string> answ = userAnswers[lsQuestion[i].Id];
                int qid = lsQuestion[i].Id;
                int aid = -1;
                if (lsQuestion[i].isMultipleChoice && answ.Count > 1)
                {
                    foreach (Answer ans in lsQuestion[i].Answers)
                    {
                        if (ans.IsCorrect)
                        {
                            aid = ans.Id;
                            if (answ.Contains(ans.Content))
                            {
                                correct = true;
                            }
                            else
                            {
                                correct = false;
                                break;
                            }
                        }
                    }
                }
                else if (!lsQuestion[i].isMultipleChoice && answ.Count == 1)
                {
                    foreach (Answer ans in lsQuestion[i].Answers)
                    {
                        if (ans.IsCorrect)
                        {
                            aid = ans.Id;

                            if (ans.Content.Equals(answ[0]))
                            {
                                correct = true;
                            }
                            else
                            {
                                correct = false;
                            }
                            break;
                        }
                    }
                }

                if (correct)
                {
                    ++score;
                }
            }
        }
        private void finish()
        {
            calculateScore();
            score = score / lsQuestion.Count * 10;
            parent.addForm(new Result(score,parent));
            ExamResultDAO.insertResult(stdResult,sid, ecode, score, DateTime.Now);
        }
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            finish();
        }
    }
}
