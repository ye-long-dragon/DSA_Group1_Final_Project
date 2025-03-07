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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMasterList));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            btnRefresh = new Guna.UI2.WinForms.Guna2ImageButton();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flpStudentList = new FlowLayoutPanel();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(btnRefresh);
            guna2CustomGradientPanel1.Controls.Add(lblTitle);
            guna2CustomGradientPanel1.Controls.Add(flpStudentList);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges5;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2CustomGradientPanel1.Size = new Size(1136, 896);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0, 0, 64);
            btnRefresh.CheckedState.ImageSize = new Size(64, 64);
            btnRefresh.HoverState.ImageSize = new Size(64, 64);
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageOffset = new Point(0, 0);
            btnRefresh.ImageRotate = 0F;
            btnRefresh.Location = new Point(946, 31);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedState.ImageSize = new Size(64, 64);
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRefresh.Size = new Size(80, 68);
            btnRefresh.TabIndex = 3;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.Location = new Point(44, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(407, 62);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Student Master List";
            // 
            // flpStudentList
            // 
            flpStudentList.AutoScroll = true;
            flpStudentList.BackColor = SystemColors.ActiveCaption;
            flpStudentList.Location = new Point(44, 120);
            flpStudentList.Name = "flpStudentList";
            flpStudentList.Size = new Size(1037, 736);
            flpStudentList.TabIndex = 1;
            // 
            // StudentMasterList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2CustomGradientPanel1);
            Name = "StudentMasterList";
            Size = new Size(1136, 896);
            Load += StudentMasterList_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private FlowLayoutPanel flpStudentList;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2ImageButton btnRefresh;
    }
}
