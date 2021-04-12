using System.Windows.Forms;

namespace ProjectPRN292.GUI.Admin
{
    partial class QuestionManagement
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
            this.cbxSubjectName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubjectID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChap = new System.Windows.Forms.DataGridView();
            this.btnAddChap = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChap)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSubjectName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSubjectID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subject";
            // 
            // cbxSubjectName
            // 
            this.cbxSubjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubjectName.FormattingEnabled = true;
            this.cbxSubjectName.Location = new System.Drawing.Point(118, 79);
            this.cbxSubjectName.Name = "cbxSubjectName";
            this.cbxSubjectName.Size = new System.Drawing.Size(245, 24);
            this.cbxSubjectName.TabIndex = 3;
            this.cbxSubjectName.DropDownClosed += new System.EventHandler(this.CbxSubjectName_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject Name:";
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.Enabled = false;
            this.txtSubjectID.Location = new System.Drawing.Point(118, 35);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(245, 22);
            this.txtSubjectID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChap);
            this.groupBox2.Controls.Add(this.btnAddChap);
            this.groupBox2.Location = new System.Drawing.Point(30, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 329);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chapter";
            // 
            // dgvChap
            // 
            this.dgvChap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChap.Location = new System.Drawing.Point(13, 26);
            this.dgvChap.Name = "dgvChap";
            this.dgvChap.RowHeadersWidth = 51;
            this.dgvChap.RowTemplate.Height = 24;
            this.dgvChap.Size = new System.Drawing.Size(367, 220);
            this.dgvChap.TabIndex = 5;
            this.dgvChap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvChap_CellClick);
            this.dgvChap.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvChap_DataBindingComplete);
            // 
            // btnAddChap
            // 
            this.btnAddChap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChap.Location = new System.Drawing.Point(187, 282);
            this.btnAddChap.Name = "btnAddChap";
            this.btnAddChap.Size = new System.Drawing.Size(204, 34);
            this.btnAddChap.TabIndex = 4;
            this.btnAddChap.Text = "Add New Chapter";
            this.btnAddChap.UseVisualStyleBackColor = true;
            this.btnAddChap.Click += new System.EventHandler(this.BtnAddChap_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnAddQuestion);
            this.groupBox3.Controls.Add(this.dgvQuestion);
            this.groupBox3.Location = new System.Drawing.Point(456, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 503);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Question";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(471, 426);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(16, 16);
            this.lblNo.TabIndex = 15;
            this.lblNo.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Number of Questions:";
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Enabled = false;
            this.btnAddQuestion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuestion.Location = new System.Drawing.Point(348, 456);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(166, 34);
            this.btnAddQuestion.TabIndex = 8;
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.BtnAddQuestion_Click);
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Location = new System.Drawing.Point(10, 21);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.RowHeadersWidth = 51;
            this.dgvQuestion.RowTemplate.Height = 24;
            this.dgvQuestion.Size = new System.Drawing.Size(504, 399);
            this.dgvQuestion.TabIndex = 11;
            this.dgvQuestion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQuestion_CellClick);
            this.dgvQuestion.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvQuestion_DataBindingComplete);
            // 
            // QuestionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 538);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QuestionManagement";
            this.Text = "ViewQuestion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChap)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxSubjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddChap;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.DataGridView dgvChap;

        public GroupBox GroupBox1 { get => groupBox1; set => groupBox1 = value; }
        public ComboBox CbxSubjectName { get => cbxSubjectName; set => cbxSubjectName = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtSubjectID { get => txtSubjectID; set => txtSubjectID = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public GroupBox GroupBox2 { get => groupBox2; set => groupBox2 = value; }
        public Button BtnAddChap { get => btnAddChap; set => btnAddChap = value; }
        public GroupBox GroupBox3 { get => groupBox3; set => groupBox3 = value; }
        public Label LblNo { get => lblNo; set => lblNo = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Button BtnAddQuestion { get => btnAddQuestion; set => btnAddQuestion = value; }
        public DataGridView DgvQuestion { get => dgvQuestion; set => dgvQuestion = value; }
        public DataGridView DgvChap { get => dgvChap; set => dgvChap = value; }
    }
}