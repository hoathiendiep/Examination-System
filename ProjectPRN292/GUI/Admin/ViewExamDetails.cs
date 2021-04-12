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
    public partial class ViewExamDetails : Form
    {

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public ViewExamDetails(int sid,int eid)
        {
            InitializeComponent();

            dataGridView1.DataSource = ExamResultDAO.getDetails(sid, eid);

        }
    }
}
