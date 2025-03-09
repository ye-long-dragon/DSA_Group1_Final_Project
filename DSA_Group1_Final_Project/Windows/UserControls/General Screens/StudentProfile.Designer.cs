namespace DSA_Group1_Final_Project.Windows.UserControls.General_Screens
{
    partial class StudentProfile
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
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblProgram = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblDepartment = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCurriculum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnChangeProfile = new Guna.UI2.WinForms.Guna2Button();
            name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            program = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Department = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Curriculum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(480, 92);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(151, 147);
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(114, 309);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 22);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // lblProgram
            // 
            lblProgram.BackColor = Color.Transparent;
            lblProgram.Location = new Point(114, 389);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(63, 22);
            lblProgram.TabIndex = 2;
            lblProgram.Text = "Program:";
            // 
            // lblDepartment
            // 
            lblDepartment.BackColor = Color.Transparent;
            lblDepartment.Location = new Point(114, 468);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(86, 22);
            lblDepartment.TabIndex = 3;
            lblDepartment.Text = "Department:";
            // 
            // lblCurriculum
            // 
            lblCurriculum.BackColor = Color.Transparent;
            lblCurriculum.Location = new Point(114, 546);
            lblCurriculum.Name = "lblCurriculum";
            lblCurriculum.Size = new Size(77, 22);
            lblCurriculum.TabIndex = 4;
            lblCurriculum.Text = "Curriculum:";
            // 
            // btnChangeProfile
            // 
            btnChangeProfile.CustomizableEdges = customizableEdges2;
            btnChangeProfile.DisabledState.BorderColor = Color.DarkGray;
            btnChangeProfile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChangeProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChangeProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChangeProfile.Font = new Font("Segoe UI", 9F);
            btnChangeProfile.ForeColor = Color.White;
            btnChangeProfile.Location = new Point(114, 667);
            btnChangeProfile.Name = "btnChangeProfile";
            btnChangeProfile.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnChangeProfile.Size = new Size(898, 42);
            btnChangeProfile.TabIndex = 5;
            btnChangeProfile.Text = "Change Profile";
            // 
            // name
            // 
            name.BackColor = Color.Transparent;
            name.Location = new Point(270, 310);
            name.Name = "name";
            name.Size = new Size(121, 22);
            name.TabIndex = 6;
            name.Text = "guna2HtmlLabel1";
            // 
            // program
            // 
            program.BackColor = Color.Transparent;
            program.Location = new Point(270, 389);
            program.Name = "program";
            program.Size = new Size(46, 22);
            program.TabIndex = 7;
            program.Text = "Name:";
            // 
            // Department
            // 
            Department.BackColor = Color.Transparent;
            Department.Location = new Point(270, 468);
            Department.Name = "Department";
            Department.Size = new Size(46, 22);
            Department.TabIndex = 8;
            Department.Text = "Name:";
            // 
            // Curriculum
            // 
            Curriculum.BackColor = Color.Transparent;
            Curriculum.Location = new Point(270, 546);
            Curriculum.Name = "Curriculum";
            Curriculum.Size = new Size(46, 22);
            Curriculum.TabIndex = 9;
            Curriculum.Text = "Name:";
            // 
            // StudentProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Curriculum);
            Controls.Add(Department);
            Controls.Add(program);
            Controls.Add(name);
            Controls.Add(btnChangeProfile);
            Controls.Add(lblCurriculum);
            Controls.Add(lblDepartment);
            Controls.Add(lblProgram);
            Controls.Add(lblName);
            Controls.Add(guna2CirclePictureBox1);
            Name = "StudentProfile";
            Size = new Size(1136, 896);
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProgram;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartment;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCurriculum;
        private Guna.UI2.WinForms.Guna2Button btnChangeProfile;
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
        private Guna.UI2.WinForms.Guna2HtmlLabel program;
        private Guna.UI2.WinForms.Guna2HtmlLabel Department;
        private Guna.UI2.WinForms.Guna2HtmlLabel Curriculum;
    }
}
