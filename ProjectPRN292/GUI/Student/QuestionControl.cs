using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.GUI
{
    public partial class QuestionControl : UserControl
    {
        Question question;
        TakingTest parent;
        List<RadioButton> radAnswers = new List<RadioButton>();
        List<CheckBox> cbxAnswers = new List<CheckBox>();

        public QuestionControl(Question question, TakingTest parent)
        {
            InitializeComponent();
            this.question = question;
            this.parent = parent;
            txtQuestionContent.Padding = new Padding(5, 5, 5, 5);
            txtQuestionContent.Text = question.Content;
            if (question.isMultipleChoice)
            {
                for(int i = 0;i<question.Answers.Count;i++)
                {
                    CheckBox cbxAnswer = new CheckBox();

                    cbxAnswer.AutoSize = false;

                    cbxAnswer.Height = cbxAnswer.Height * 3; // or however many lines you may need
                    cbxAnswer.Width = 300;
                    // style the control as you want..
                    Answer a = question.Answers[i];
                    cbxAnswer.Text = a.Content;
                    cbxAnswers.Add(cbxAnswer);
                    pnAnswers.Controls.Add(cbxAnswer);
                    cbxAnswer.CheckedChanged += cbxAnswer_CheckChanged;
                }
            }
            else
            {
                for(int i = 0; i < question.Answers.Count; i++)
                {
                    RadioButton radAnswer = new RadioButton();
                    radAnswer.AutoSize = false;
                    radAnswer.Height = radAnswer.Height * 3; // or however many lines you may need
                    radAnswer.Width = 300;
                    Answer a = question.Answers[i];
                    radAnswer.Text = a.Content;
                    radAnswers.Add(radAnswer);
                    pnAnswers.Controls.Add(radAnswer);
                    radAnswer.CheckedChanged += cbxAnswer_CheckChanged;
                }
            }
        }

        private void cbxAnswer_CheckChanged(object sender, EventArgs e)
        {
            if (question.isMultipleChoice)
            {
                bool isChecked = false;
                foreach(CheckBox cbx in cbxAnswers)
                {
                    if (cbx.Checked)
                    {
                        isChecked = true;
                        if (!parent.userAnswers[question.Id].Contains(cbx.Text))
                        {
                            parent.userAnswers[question.Id].Add(cbx.Text);
                        }
                    }
                    else
                    {
                        parent.userAnswers[question.Id].Remove(cbx.Text);
                    }
                }
               
                parent.MarkedAsAnswered(question, isChecked);
            }
            else
            {
                bool isChecked = false;
                foreach (RadioButton cbx in radAnswers)
                {
                    if (cbx.Checked)
                    {
                        isChecked = true;
                        if (!parent.userAnswers[question.Id].Contains(cbx.Text))
                        {
                            parent.userAnswers[question.Id].Add(cbx.Text);
                        }
                    }
                    else
                    {
                        parent.userAnswers[question.Id].Remove(cbx.Text);
                    }
                }
                parent.MarkedAsAnswered(question, isChecked);
            }
        }
    }
}
