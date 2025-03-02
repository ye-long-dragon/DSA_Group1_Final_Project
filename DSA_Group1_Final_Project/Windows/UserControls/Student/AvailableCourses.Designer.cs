namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    partial class AvailableCourses
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
            flpCourses = new FlowLayoutPanel();
            lblAvailableCourses = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // flpCourses
            // 
            flpCourses.Location = new Point(36, 88);
            flpCourses.Name = "flpCourses";
            flpCourses.Size = new Size(1065, 760);
            flpCourses.TabIndex = 5;
            // 
            // lblAvailableCourses
            // 
            lblAvailableCourses.BackColor = Color.Transparent;
            lblAvailableCourses.Location = new Point(59, 49);
            lblAvailableCourses.Name = "lblAvailableCourses";
            lblAvailableCourses.Size = new Size(120, 22);
            lblAvailableCourses.TabIndex = 4;
            lblAvailableCourses.Text = "Available Courses";
            // 
            // AvailableCourses
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpCourses);
            Controls.Add(lblAvailableCourses);
            Name = "AvailableCourses";
            Size = new Size(1136, 896);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpCourses;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvailableCourses;
    }
}
