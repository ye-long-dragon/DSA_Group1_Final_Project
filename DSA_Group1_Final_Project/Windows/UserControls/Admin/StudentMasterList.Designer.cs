namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    partial class StudentMasterList
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
            lblStudentMasterList = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblStudentMasterList
            // 
            lblStudentMasterList.BackColor = Color.Transparent;
            lblStudentMasterList.Location = new Point(56, 55);
            lblStudentMasterList.Name = "lblStudentMasterList";
            lblStudentMasterList.Size = new Size(129, 22);
            lblStudentMasterList.TabIndex = 0;
            lblStudentMasterList.Text = "Student Master List";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(33, 94);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1065, 760);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // StudentMasterList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblStudentMasterList);
            Name = "StudentMasterList";
            Size = new Size(1136, 896);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblStudentMasterList;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
