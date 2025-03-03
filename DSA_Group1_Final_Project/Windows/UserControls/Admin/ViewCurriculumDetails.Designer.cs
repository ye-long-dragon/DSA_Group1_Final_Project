namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    partial class ViewCurriculumDetails
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
            lblStudentName = new Label();
            lblProgram = new Label();
            lblCurriculum = new Label();
            SuspendLayout();
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Location = new Point(75, 59);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(50, 20);
            lblStudentName.TabIndex = 0;
            lblStudentName.Text = "label1";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(92, 124);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(50, 20);
            lblProgram.TabIndex = 1;
            lblProgram.Text = "label2";
            // 
            // lblCurriculum
            // 
            lblCurriculum.AutoSize = true;
            lblCurriculum.Location = new Point(101, 186);
            lblCurriculum.Name = "lblCurriculum";
            lblCurriculum.Size = new Size(50, 20);
            lblCurriculum.TabIndex = 2;
            lblCurriculum.Text = "label3";
            // 
            // ViewCurriculumDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCurriculum);
            Controls.Add(lblProgram);
            Controls.Add(lblStudentName);
            Name = "ViewCurriculumDetails";
            Size = new Size(527, 487);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentName;
        private Label lblProgram;
        private Label lblCurriculum;
    }
}
