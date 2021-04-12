using ProjectPRN292.DAL;
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
    public partial class SubjectManagement : Form
    {
        int add;
        string Subject_ID;
        string Chapter_ID;
        string choose;
        int remove;
        public SubjectManagement()
        {
            InitializeComponent();
            dgvSubject.DataSource = SubjectDAO.GetDataTable();
            dgvSubject.Columns["Subject_ID"].Visible = false;
            display(3);
        }
        private void display(int status)
        {
            switch (status)
            {
                case 0:
                    add = -1;

                    txtChapter.Enabled = false;
                    txtSubject.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEditt.Enabled = true;
                    btnRemove.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancle.Enabled = false;
                    btnChooseSubject.Visible = false;
                    btnChooseChapter.Visible = false;
                    break;
                case 1:
                    txtChapter.Enabled = false;
                    txtSubject.Enabled = false;
                    btnAdd.Enabled = false;
                    btnEditt.Enabled = false;
                    btnRemove.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancle.Enabled = true;
                    btnChooseSubject.Visible = true;
                    btnChooseChapter.Visible = true;
                    break;
                case 2:
                    if (choose == "subject")
                    {
                        txtSubject.Enabled = true;
                    }
                    else txtChapter.Enabled = true;
                    btnAdd.Enabled = false;
                    btnEditt.Enabled = false;
                    btnRemove.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancle.Enabled = true;
                    btnChooseSubject.Visible = false;
                    btnChooseChapter.Visible = false;
                    break;
                case 3:
                    add = -1;
                    txtChapter.Enabled = false;
                    txtSubject.Enabled = false;
                    btnAdd.Enabled = false;
                    btnEditt.Enabled = false;
                    btnRemove.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancle.Enabled = false;
                    btnChooseSubject.Visible = false;
                    btnChooseChapter.Visible = false;
                    break;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = 1;
            if (choose == "subject")
            {
                txtChapter.Text = "";
                txtSubject.Text = "";
            }
            else txtChapter.Text = "";
            
            display(1);
        }

        private void dgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvSubject.Rows.Count)
            {
                MessageBox.Show("Please select a subject");
                return;
            }
            Subject_ID = dgvSubject.Rows[e.RowIndex].Cells["Subject_ID"].Value.ToString();
            txtSubject.Text = dgvSubject.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString();
            dgvChapter.DataSource = ChapterDAO.GetDataBySubjectID(int.Parse(Subject_ID));
            dgvChapter.Columns["Chapter_ID"].Visible = false;
            txtChapter.Text = "";
            display(0);
        }

        private void dgvChapter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtChapter.Text = dgvChapter.Rows[e.RowIndex].Cells["ChapterName"].Value.ToString();
            display(0);
        }

        private void btnChooseSubject_Click(object sender, EventArgs e)
        {
            if (dgvSubject.SelectedRows.Count == 0 && add != 1)
            {
                MessageBox.Show("A selected subject required!");
                display(0);
                return;
            }
            choose = "subject";
            if (remove == 1)
            {
                ConfirmationDelete();
                display(0);
                return;
            }
            display(2);
        }

        private void btnChooseChapter_Click(object sender, EventArgs e)
        {
            if (dgvChapter.SelectedRows.Count == 0 && add != 1)
            {
                MessageBox.Show("A selected chapter required!");
                display(0);
                return;
            }
            choose = "chapter";
            if (remove == 1)
            {
                ConfirmationDelete();
                display(0);
                return;
            }
            display(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtSubject.Text == "" || txtSubject.Text == null) && choose == "subject" || (txtChapter.Text == "" || txtChapter.Text == null) && choose == "chapter")
            {
                MessageBox.Show("Empty string");
                display(1);
                return;
            }
            else
            {
                if (choose == "subject")
                {
                    Subject s = new Subject();
                    s.Name = txtSubject.Text;
                    if (add == 1)
                    {
                        if (SubjectDAO.Add(s))
                            MessageBox.Show("Added");
                        else
                            MessageBox.Show("Error while adding");
                    }
                    else
                    {
                        s.Id = int.Parse(dgvSubject.SelectedRows[0].Cells["Subject_ID"].Value.ToString());
                        if (SubjectDAO.Edit(s))
                            MessageBox.Show("Edited");
                        else
                            MessageBox.Show("Error while editing");
                    }
                    dgvSubject.DataSource = SubjectDAO.GetDataTable();

                }
                else
                {
                    Chapter s = new Chapter();
                    s.Name = txtChapter.Text;
                    if (add == 1)
                    {
                        if (ChapterDAO.AddDataBySubjectID(int.Parse(Subject_ID), s.Name))
                            MessageBox.Show("Added");
                        else
                            MessageBox.Show("Error while adding");
                    }
                    else
                    {
                        s.Id = int.Parse(dgvChapter.SelectedRows[0].Cells["Chapter_ID"].Value.ToString());
                        if (ChapterDAO.Edit(s))
                            MessageBox.Show("Edited");
                        else
                            MessageBox.Show("Error while editing");
                    }
                    dgvChapter.DataSource = ChapterDAO.GetDataBySubjectID(int.Parse(Subject_ID));
                }
                display(0);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            display(0);
            txtChapter.Text = "";
            txtSubject.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            remove = 1;
            display(1);
        }

        private void btnEditt_Click(object sender, EventArgs e)
        {
            add = 0;
            display(1);
        }
        private void ConfirmationDelete()
        {
            DialogResult dr = MessageBox.Show("You want to delete this ?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) {
                display(0);
                remove = 0;
                return; 
            }
            if (choose == "subject")
            {
                Subject f = new Subject();
                f.Id = int.Parse(dgvSubject.SelectedRows[0].Cells["Subject_ID"].Value.ToString());
                if (ChapterDAO.DeleteAllChapter(Subject_ID) && SubjectDAO.Delete(f))
                {
                    MessageBox.Show("Deleted a subject");
                    dgvChapter.DataSource = null;
                }
                else
                    MessageBox.Show("Error while deleting subject");
            }
            else
            {
                Chapter f = new Chapter();
                f.Id = int.Parse(dgvChapter.SelectedRows[0].Cells["Chapter_ID"].Value.ToString());
                if (ChapterDAO.Delete(f))
                    MessageBox.Show("Deleted a chapter");
                else
                    MessageBox.Show("Error while deleting chapter");
            }
            txtChapter.Text = "";
            txtSubject.Text = "";
            if (choose == "subject")
            {
                dgvSubject.DataSource = SubjectDAO.GetDataTable();
            }
            else dgvChapter.DataSource = ChapterDAO.GetDataBySubjectID(int.Parse(Subject_ID));
            display(0);
            remove = 0;
        }

        private void TxtSubject_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
