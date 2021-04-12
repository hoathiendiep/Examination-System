using System.Windows.Forms;

namespace ProjectPRN292.GUI.Admin
{
    partial class AddEditQuestion
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
            this.txtTime = new System.Windows.Forms.NumericUpDown();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChapterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMoreAnswer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChapterName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnMoreAnswer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSubName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 269);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question Info";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(111, 222);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(120, 22);
            this.txtTime.TabIndex = 13;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(111, 119);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(241, 73);
            this.txtContent.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Content:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // txtChapterName
            // 
            this.txtChapterName.Enabled = false;
            this.txtChapterName.Location = new System.Drawing.Point(111, 73);
            this.txtChapterName.Name = "txtChapterName";
            this.txtChapterName.Size = new System.Drawing.Size(241, 22);
            this.txtChapterName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chapter Name:";
            // 
            // btnMoreAnswer
            // 
            this.btnMoreAnswer.Location = new System.Drawing.Point(349, 230);
            this.btnMoreAnswer.Name = "btnMoreAnswer";
            this.btnMoreAnswer.Size = new System.Drawing.Size(102, 33);
            this.btnMoreAnswer.TabIndex = 8;
            this.btnMoreAnswer.Text = "More Answer";
            this.btnMoreAnswer.UseVisualStyleBackColor = true;
            this.btnMoreAnswer.Click += new System.EventHandler(this.btnMoreAnswer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Time (sec):";
            // 
            // txtSubName
            // 
            this.txtSubName.Enabled = false;
            this.txtSubName.Location = new System.Drawing.Point(111, 28);
            this.txtSubName.Name = "txtSubName";
            this.txtSubName.Size = new System.Drawing.Size(241, 22);
            this.txtSubName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Name:";
            // 
            // pnAnswers
            // 
            this.pnAnswers.AutoScroll = true;
            this.pnAnswers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnAnswers.Location = new System.Drawing.Point(10, 287);
            this.pnAnswers.Name = "pnAnswers";
            this.pnAnswers.Size = new System.Drawing.Size(457, 345);
            this.pnAnswers.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(402, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 39);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 689);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnAnswers);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddQuestion";
            this.Text = "AddQuestion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMoreAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnAnswers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtChapterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.NumericUpDown txtTime;

        public GroupBox GroupBox1 { get => groupBox1; set => groupBox1 = value; }
        public Button BtnMoreAnswer { get => btnMoreAnswer; set => btnMoreAnswer = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox TxtSubName { get => txtSubName; set => txtSubName = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public FlowLayoutPanel PnAnswers { get => pnAnswers; set => pnAnswers = value; }
        public Button BtnSave { get => btnSave; set => btnSave = value; }
        public TextBox TxtChapterName { get => txtChapterName; set => txtChapterName = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public TextBox TxtContent { get => txtContent; set => txtContent = value; }
        public NumericUpDown TxtTime { get => txtTime; set => txtTime = value; }
    }
}