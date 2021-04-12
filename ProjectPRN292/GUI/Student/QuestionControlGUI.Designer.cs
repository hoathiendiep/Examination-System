namespace ProjectPRN292.GUI
{
    partial class QuestionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtQuestionContent = new System.Windows.Forms.TextBox();
            this.pnAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtQuestionContent
            // 
            this.txtQuestionContent.BackColor = System.Drawing.Color.Gray;
            this.txtQuestionContent.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestionContent.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtQuestionContent.Location = new System.Drawing.Point(3, 3);
            this.txtQuestionContent.Multiline = true;
            this.txtQuestionContent.Name = "txtQuestionContent";
            this.txtQuestionContent.Size = new System.Drawing.Size(774, 136);
            this.txtQuestionContent.TabIndex = 0;
            // 
            // pnAnswers
            // 
            this.pnAnswers.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnAnswers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnAnswers.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnAnswers.Location = new System.Drawing.Point(3, 146);
            this.pnAnswers.Name = "pnAnswers";
            this.pnAnswers.Size = new System.Drawing.Size(774, 346);
            this.pnAnswers.TabIndex = 1;
            // 
            // QuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnAnswers);
            this.Controls.Add(this.txtQuestionContent);
            this.Name = "QuestionControl";
            this.Size = new System.Drawing.Size(782, 498);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestionContent;
        private System.Windows.Forms.FlowLayoutPanel pnAnswers;
    }
}
