using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectPRN292.DAL;

namespace ProjectPRN292.GUI.Admin
{
    public partial class AnswerControl : UserControl
    {
        AddEditQuestion parent;
        bool isAdd;
        public AnswerControl(int index, bool isAdd, AddEditQuestion parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.isAdd = isAdd;
            lblIndex.Text = "Asnwer " + index.ToString();
        }

        public int Id { get; set; }

        public Answer getAnswer()
        {
            Answer a = new Answer();
            a.Id = Id;
            a.Content = txtContent.Text;
            a.IsCorrect = cbxIsCorrected.Checked;
            return a;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            parent.PnAnswers.Controls.Remove(this);
            parent.AnswerControls.Remove(this);
            if (!isAdd)
            {
                AnswerDAO.deleteAns(Id);
            }
        }
    }
}
