namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    partial class CourseList
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
            flpList = new FlowLayoutPanel();
            lblCourseList = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // flpList
            // 
            flpList.Location = new Point(36, 88);
            flpList.Name = "flpList";
            flpList.Size = new Size(1065, 760);
            flpList.TabIndex = 3;
            // 
            // lblCourseList
            // 
            lblCourseList.BackColor = Color.Transparent;
            lblCourseList.Location = new Point(59, 49);
            lblCourseList.Name = "lblCourseList";
            lblCourseList.Size = new Size(74, 22);
            lblCourseList.TabIndex = 2;
            lblCourseList.Text = "Course List";
            // 
            // CourseList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpList);
            Controls.Add(lblCourseList);
            Name = "CourseList";
            Size = new Size(1136, 896);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpList;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCourseList;
    }
}
