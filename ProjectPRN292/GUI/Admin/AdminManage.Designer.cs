namespace ProjectPRN292.GUI.Admin
{
    partial class AdminManage
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1095, 531);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 30);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1095, 556);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewQuestionsToolStripMenuItem,
            this.createExamToolStripMenuItem,
            this.viewScoreToolStripMenuItem,
            this.subjectManagementToolStripMenuItem});
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.courseToolStripMenuItem.Text = "Exam";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.CourseToolStripMenuItem_Click);
            // 
            // viewQuestionsToolStripMenuItem
            // 
            this.viewQuestionsToolStripMenuItem.Name = "viewQuestionsToolStripMenuItem";
            this.viewQuestionsToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.viewQuestionsToolStripMenuItem.Text = "Question Management";
            this.viewQuestionsToolStripMenuItem.Click += new System.EventHandler(this.ViewQuestionsToolStripMenuItem_Click);
            // 
            // createExamToolStripMenuItem
            // 
            this.createExamToolStripMenuItem.Name = "createExamToolStripMenuItem";
            this.createExamToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.createExamToolStripMenuItem.Text = "Exam Management";
            this.createExamToolStripMenuItem.Click += new System.EventHandler(this.CreateExamToolStripMenuItem_Click);
            // 
            // viewScoreToolStripMenuItem
            // 
            this.viewScoreToolStripMenuItem.Name = "viewScoreToolStripMenuItem";
            this.viewScoreToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.viewScoreToolStripMenuItem.Text = "View Score";
            this.viewScoreToolStripMenuItem.Click += new System.EventHandler(this.ViewScoreToolStripMenuItem_Click_1);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInformationToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // viewInformationToolStripMenuItem
            // 
            this.viewInformationToolStripMenuItem.Name = "viewInformationToolStripMenuItem";
            this.viewInformationToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.viewInformationToolStripMenuItem.Text = "View Information";
            this.viewInformationToolStripMenuItem.Click += new System.EventHandler(this.ViewInformationToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.accountSettingsToolStripMenuItem.Text = "Account";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // subjectManagementToolStripMenuItem
            // 
            this.subjectManagementToolStripMenuItem.Name = "subjectManagementToolStripMenuItem";
            this.subjectManagementToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.subjectManagementToolStripMenuItem.Text = "Subject Management";
            this.subjectManagementToolStripMenuItem.Click += new System.EventHandler(this.SubjectManagementToolStripMenuItem_Click);
            // 
            // AdminManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 592);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminManage";
            this.Text = "Admin Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminManage_FormClosed);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectManagementToolStripMenuItem;
    }
}