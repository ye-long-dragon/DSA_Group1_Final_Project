namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    partial class StudentCurriculum
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

        #region Component Designer generated code*/

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            lblStudentInfo = new Label();
            SuspendLayout();
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Location = new Point(22, 78);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(50, 20);
            lblStudentInfo.TabIndex = 0;
            lblStudentInfo.Text = "label1";
            // 
            // ViewCurriculumDetails
              // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStudentInfo);
            Name = "ViewCurriculumDetails";
            Size = new Size(799, 707);
            ResumeLayout(false);
            PerformLayout();
        }

          #endregion

        private Label label1;
        private Label lblStudentInfo;
    }
}
