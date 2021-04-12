using System.Windows.Forms;

namespace ProjectPRN292.GUI.Admin
{
    partial class ExamManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvExam = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxSubject = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.txtExamCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRandom = new System.Windows.Forms.Button();
            this.nudQues = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxChapter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvExam);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of exams";
            // 
            // dgvExam
            // 
            this.dgvExam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExam.Location = new System.Drawing.Point(7, 37);
            this.dgvExam.Name = "dgvExam";
            this.dgvExam.RowHeadersWidth = 51;
            this.dgvExam.RowTemplate.Height = 24;
            this.dgvExam.Size = new System.Drawing.Size(317, 229);
            this.dgvExam.TabIndex = 0;
            this.dgvExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvExam_CellClick);
            this.dgvExam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvExam_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxSubject);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtExamName);
            this.groupBox2.Controls.Add(this.txtExamCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 190);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exam Details";
            // 
            // cbxSubject
            // 
            this.cbxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubject.Enabled = false;
            this.cbxSubject.FormattingEnabled = true;
            this.cbxSubject.Location = new System.Drawing.Point(111, 117);
            this.cbxSubject.Name = "cbxSubject";
            this.cbxSubject.Size = new System.Drawing.Size(200, 24);
            this.cbxSubject.TabIndex = 7;
            this.cbxSubject.SelectedIndexChanged += new System.EventHandler(this.CbxSubject_SelectedIndexChanged);
            this.cbxSubject.DropDownClosed += new System.EventHandler(this.CbxSubject_DropDownClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Subject:";
            // 
            // txtExamName
            // 
            this.txtExamName.Enabled = false;
            this.txtExamName.Location = new System.Drawing.Point(111, 74);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(200, 22);
            this.txtExamName.TabIndex = 4;
            // 
            // txtExamCode
            // 
            this.txtExamCode.Enabled = false;
            this.txtExamCode.Location = new System.Drawing.Point(111, 32);
            this.txtExamCode.Name = "txtExamCode";
            this.txtExamCode.Size = new System.Drawing.Size(200, 22);
            this.txtExamCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exam Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam Code:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSelected);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnRandom);
            this.groupBox3.Controls.Add(this.nudQues);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbxChapter);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dgvQuestion);
            this.groupBox3.Location = new System.Drawing.Point(383, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 487);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List of questions";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(156, 111);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(16, 16);
            this.lblSelected.TabIndex = 33;
            this.lblSelected.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Selected questions:";
            // 
            // btnRandom
            // 
            this.btnRandom.Enabled = false;
            this.btnRandom.Location = new System.Drawing.Point(286, 60);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 23);
            this.btnRandom.TabIndex = 31;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.BtnRandom_Click);
            // 
            // nudQues
            // 
            this.nudQues.Enabled = false;
            this.nudQues.Location = new System.Drawing.Point(219, 63);
            this.nudQues.Name = "nudQues";
            this.nudQues.Size = new System.Drawing.Size(43, 22);
            this.nudQues.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Number of random questions:";
            // 
            // cbxChapter
            // 
            this.cbxChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChapter.FormattingEnabled = true;
            this.cbxChapter.Location = new System.Drawing.Point(388, 19);
            this.cbxChapter.Name = "cbxChapter";
            this.cbxChapter.Size = new System.Drawing.Size(210, 24);
            this.cbxChapter.TabIndex = 2;
            this.cbxChapter.SelectedIndexChanged += new System.EventHandler(this.CbxChapter_DropDownClosed);
            this.cbxChapter.DropDownClosed += new System.EventHandler(this.CbxChapter_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Chapter:";
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dgvQuestion.Location = new System.Drawing.Point(7, 139);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.RowHeadersWidth = 51;
            this.dgvQuestion.RowTemplate.Height = 24;
            this.dgvQuestion.Size = new System.Drawing.Size(591, 327);
            this.dgvQuestion.TabIndex = 0;
            this.dgvQuestion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQuestion_CellClick);
            this.dgvQuestion.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvQuestion_DataBindingComplete);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(873, 519);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(747, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(219, 520);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(71, 520);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(367, 519);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 30;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // ExamManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 555);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExamManagement";
            this.Text = "Exam Management";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvExam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.TextBox txtExamCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.ComboBox cbxSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxChapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.NumericUpDown nudQues;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private DataGridViewCheckBoxColumn Select;

        public GroupBox GroupBox1 { get => groupBox1; set => groupBox1 = value; }
        public DataGridView DgvExam { get => dgvExam; set => dgvExam = value; }
        public GroupBox GroupBox2 { get => groupBox2; set => groupBox2 = value; }
        public TextBox TxtExamName { get => txtExamName; set => txtExamName = value; }
        public TextBox TxtExamCode { get => txtExamCode; set => txtExamCode = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public GroupBox GroupBox3 { get => groupBox3; set => groupBox3 = value; }
        public DataGridView DgvQuestion { get => dgvQuestion; set => dgvQuestion = value; }
        public ComboBox CbxSubject { get => cbxSubject; set => cbxSubject = value; }
        public Label Label6 { get => label6; set => label6 = value; }
        public ComboBox CbxChapter { get => cbxChapter; set => cbxChapter = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label LblSelected { get => lblSelected; set => lblSelected = value; }
        public Label Label8 { get => label8; set => label8 = value; }
        public Button BtnRandom { get => btnRandom; set => btnRandom = value; }
        public NumericUpDown NudQues { get => nudQues; set => nudQues = value; }
        public Label Label7 { get => label7; set => label7 = value; }
        public Button BtnCancel { get => btnCancel; set => btnCancel = value; }
        public Button BtnSave { get => btnSave; set => btnSave = value; }
        public Button BtnEdit { get => btnEdit; set => btnEdit = value; }
        public Button BtnAdd { get => btnAdd; set => btnAdd = value; }
        public Button BtnRemove { get => btnRemove; set => btnRemove = value; }
    }
}