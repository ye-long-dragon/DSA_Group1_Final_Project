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
            flpStudentList = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpStudentList
            // 
            flpStudentList.AutoScroll = true;
            flpStudentList.BackColor = SystemColors.ActiveCaption;
            flpStudentList.Dock = DockStyle.Fill;
            flpStudentList.Location = new Point(0, 0);
            flpStudentList.Name = "flpStudentList";
            flpStudentList.Size = new Size(836, 690);
            flpStudentList.TabIndex = 0;
            // 
            // StudentMasterList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpStudentList);
            Name = "StudentMasterList";
            Size = new Size(836, 690);
            Load += StudentMasterList_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpStudentList;
    }
}
