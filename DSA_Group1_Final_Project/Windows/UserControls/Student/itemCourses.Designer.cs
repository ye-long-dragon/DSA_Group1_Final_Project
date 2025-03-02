namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    partial class itemCourses
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
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCourseCode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblUnits = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPrerquisites = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCorequisites = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(47, 53);
            lblName.Name = "lblName";
            lblName.Size = new Size(121, 22);
            lblName.TabIndex = 0;
            lblName.Text = "guna2HtmlLabel1";
            // 
            // lblCourseCode
            // 
            lblCourseCode.BackColor = Color.Transparent;
            lblCourseCode.Location = new Point(47, 81);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.Size = new Size(121, 22);
            lblCourseCode.TabIndex = 1;
            lblCourseCode.Text = "guna2HtmlLabel1";
            // 
            // lblUnits
            // 
            lblUnits.BackColor = Color.Transparent;
            lblUnits.Location = new Point(47, 109);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(121, 22);
            lblUnits.TabIndex = 2;
            lblUnits.Text = "guna2HtmlLabel1";
            // 
            // lblPrerquisites
            // 
            lblPrerquisites.BackColor = Color.Transparent;
            lblPrerquisites.Location = new Point(47, 137);
            lblPrerquisites.Name = "lblPrerquisites";
            lblPrerquisites.Size = new Size(121, 22);
            lblPrerquisites.TabIndex = 3;
            lblPrerquisites.Text = "guna2HtmlLabel1";
            // 
            // lblCorequisites
            // 
            lblCorequisites.BackColor = Color.Transparent;
            lblCorequisites.Location = new Point(47, 165);
            lblCorequisites.Name = "lblCorequisites";
            lblCorequisites.Size = new Size(121, 22);
            lblCorequisites.TabIndex = 4;
            lblCorequisites.Text = "guna2HtmlLabel1";
            // 
            // itemCourseList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCorequisites);
            Controls.Add(lblPrerquisites);
            Controls.Add(lblUnits);
            Controls.Add(lblCourseCode);
            Controls.Add(lblName);
            Name = "itemCourseList";
            Size = new Size(500, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCourseCode;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUnits;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPrerquisites;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCorequisites;
    }
}
