namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    partial class homeAdmin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnStudentMasterList = new Guna.UI2.WinForms.Guna2Button();
            pcbStudentMasterList = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcbStudentMasterList).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(520, 257);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(74, 33);
            guna2HtmlLabel1.TabIndex = 8;
            guna2HtmlLabel1.Text = "To The";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(353, 309);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(432, 39);
            guna2HtmlLabel2.TabIndex = 7;
            guna2HtmlLabel2.Text = "MMCM Student Courses Tracker";
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblName.Location = new Point(447, 184);
            lblName.Name = "lblName";
            lblName.Size = new Size(233, 39);
            lblName.TabIndex = 6;
            lblName.Text = "guna2HtmlLabel1";
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(393, 57);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(352, 108);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Welcome";
            // 
            // btnStudentMasterList
            // 
            btnStudentMasterList.AutoRoundedCorners = true;
            btnStudentMasterList.BorderRadius = 27;
            btnStudentMasterList.CustomizableEdges = customizableEdges1;
            btnStudentMasterList.DisabledState.BorderColor = Color.DarkGray;
            btnStudentMasterList.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStudentMasterList.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStudentMasterList.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStudentMasterList.Font = new Font("Segoe UI", 9F);
            btnStudentMasterList.ForeColor = Color.White;
            btnStudentMasterList.Location = new Point(338, 699);
            btnStudentMasterList.Name = "btnStudentMasterList";
            btnStudentMasterList.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnStudentMasterList.Size = new Size(462, 56);
            btnStudentMasterList.TabIndex = 10;
            btnStudentMasterList.Text = "Go To Available Courses";
            btnStudentMasterList.Click += btnStudentMasterList_Click;
            // 
            // pcbStudentMasterList
            // 
            pcbStudentMasterList.CustomizableEdges = customizableEdges3;
            pcbStudentMasterList.ImageRotate = 0F;
            pcbStudentMasterList.Location = new Point(338, 380);
            pcbStudentMasterList.Name = "pcbStudentMasterList";
            pcbStudentMasterList.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pcbStudentMasterList.Size = new Size(462, 313);
            pcbStudentMasterList.SizeMode = PictureBoxSizeMode.Zoom;
            pcbStudentMasterList.TabIndex = 9;
            pcbStudentMasterList.TabStop = false;
            // 
            // homeAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnStudentMasterList);
            Controls.Add(pcbStudentMasterList);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(lblName);
            Controls.Add(lblWelcome);
            Name = "homeAdmin";
            Size = new Size(1136, 896);
            ((System.ComponentModel.ISupportInitialize)pcbStudentMasterList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnStudentMasterList;
        private Guna.UI2.WinForms.Guna2PictureBox pcbStudentMasterList;
    }
}
