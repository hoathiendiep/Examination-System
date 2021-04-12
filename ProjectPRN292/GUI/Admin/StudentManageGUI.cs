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
    public partial class StudentManageGUI : Form
    {
        int add;

        public StudentManageGUI()
        {
            InitializeComponent();
            display(0);
            dataGridView1.DataSource = StudentDAO.GetDataTable();
            dataGridView1.Columns["Password"].Visible = false;
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = "yyyy-MM-dd ";
        }



        private void display(int status)
        {
            switch (status)
            {
                case 0:
                    add = -1;

                    txtID.Enabled = false;
                    txtEmail.Enabled = false;
                    txtFirstName.Enabled = false;
                    radFemale.Enabled = false;
                    radMale.Enabled = false;
                    txtLastName.Enabled = false;
                    dtpDOB.Enabled = false;
                    dataGridView1.Enabled = true;
                    txtPhone.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtPassword.Enabled = false;
                    cbxShow.Enabled = true;
                    break;
                case 1:
                    txtID.Enabled = false;
                    txtEmail.Enabled = true;
                    txtFirstName.Enabled = true;
                    radFemale.Enabled = true;
                    txtLastName.Enabled = true;
                    radMale.Enabled = true;
                    dataGridView1.Enabled = false;
                    txtPhone.Enabled = true;
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnRemove.Enabled = false;
                    dataGridView1.Enabled = false;
                    dtpDOB.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    txtPassword.Enabled = true;
                    cbxShow.Enabled = true;
                    break;
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblNo.Text = Convert.ToInt32(dataGridView1.Rows.Count.ToString())-1+"";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dataGridView1.Rows.Count)
            {
                MessageBox.Show("A selected student required!");
                return;
            }
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();
            txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells["Gender"].Value.ToString() == "True")
            {
                radMale.Checked = true;
                radFemale.Checked = false;
            }
            else
            {
                radFemale.Checked = true;
                radMale.Checked = false;
            }
            dtpDOB.Text = dataGridView1.Rows[e.RowIndex].Cells["DOB"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = 1;
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            radFemale.Checked = false;
            radMale.Checked = false;
            display(1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("A selected student required!");
                return;
            }
            add = 0;
            display(1);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("A selected student required!");
                return;
            }

            DialogResult dr = MessageBox.Show("You want to delete this selected student?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            Student f = new Student();
            f.Student_ID = dataGridView1.SelectedRows[0].Cells["Student_ID"].Value.ToString();
            if (StudentDAO.Delete(f))
                MessageBox.Show("Deleted");
            else
                MessageBox.Show("Error");
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            radFemale.Checked = false;
            radMale.Checked = false;
            dataGridView1.DataSource = StudentDAO.GetDataTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student f = new Student();
            if (txtPassword.Text == "" || txtPassword.Text == null || txtLastName.Text == "" || txtLastName.Text == null || txtFirstName.Text == "" || txtFirstName.Text == null || txtEmail.Text == "" || txtEmail.Text == null || txtPhone.Text == "" || txtPhone.Text == null || (radFemale.Checked == false && radMale.Checked == false))
            {
                MessageBox.Show("Empty string");
                display(1);
                return;
            }
            else
            {
                f.FirstName = txtFirstName.Text;
                f.LastName = txtLastName.Text;
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Email address not valid");
                    return;
                }
                f.Email = txtEmail.Text;
                int phone;
                if (int.TryParse(txtPhone.Text, out phone) && txtPhone.Text.ToCharArray().Length == 10)
                {
                    f.PhoneNumber = int.Parse(txtPhone.Text);
                }
                else
                {
                    MessageBox.Show("Phone number not valid");
                    return;
                }
                f.Password = txtPassword.Text;
            }
            f.Student_ID = txtID.Text;
            if (radFemale.Checked)
            {
                f.Gender = false;
            }
            else if (radMale.Checked)
            {
                f.Gender = true;
            }
            else
            {
                MessageBox.Show("Gender error");
                return;
            }
            f.DOB = dtpDOB.Value.Date;
            f.Student_ID = "0";
            if (add == 1)
            {
                if (StudentDAO.Add(f))
                    MessageBox.Show("Added");
                else
                    MessageBox.Show("Error while adding");
            }
            else
            {
                f.Student_ID = dataGridView1.SelectedRows[0].Cells["Student_ID"].Value.ToString();
                if (StudentDAO.Edit(f))
                    MessageBox.Show("Edited");
                else
                    MessageBox.Show("Error while editing");
            }
            dataGridView1.DataSource = StudentDAO.GetDataTable();

            display(0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            display(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text.Trim());
            dataGridView1.DataSource = StudentDAO.Search(textBox1.Text.Trim());
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StudentDAO.GetDataTable();
            dataGridView1.Columns["Password"].Visible = false;
        }

        private void cbxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else txtPassword.PasswordChar = '*';
        }
    }
}
