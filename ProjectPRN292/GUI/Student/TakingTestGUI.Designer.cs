namespace ProjectPRN292.GUI
{
    partial class TakingTest
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
            this.components = new System.ComponentModel.Container();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlQuestionControl = new System.Windows.Forms.Panel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlQuestionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(722, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(46, 16);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "label1";
            // 
            // pnlQuestionControl
            // 
            this.pnlQuestionControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlQuestionControl.Location = new System.Drawing.Point(13, 35);
            this.pnlQuestionControl.Name = "pnlQuestionControl";
            this.pnlQuestionControl.Size = new System.Drawing.Size(775, 532);
            this.pnlQuestionControl.TabIndex = 0;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(660, 680);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlQuestionButtons
            // 
            this.pnlQuestionButtons.AutoScroll = true;
            this.pnlQuestionButtons.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlQuestionButtons.Location = new System.Drawing.Point(13, 573);
            this.pnlQuestionButtons.Name = "pnlQuestionButtons";
            this.pnlQuestionButtons.Size = new System.Drawing.Size(775, 101);
            this.pnlQuestionButtons.TabIndex = 4;
            // 
            // TakingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 715);
            this.Controls.Add(this.pnlQuestionButtons);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlQuestionControl);
            this.Name = "TakingTest";
            this.Text = "Taking Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel pnlQuestionControl;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel pnlQuestionButtons;
    }
}

