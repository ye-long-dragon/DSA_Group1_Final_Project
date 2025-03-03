

using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Drawing;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class RegisterControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblRole = new Label();
            cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            lblProgram = new Label();
            txtProgram = new Guna.UI2.WinForms.Guna2TextBox();
            btnRegister = new Guna.UI2.WinForms.Guna2Button();
            btnBackToLogin = new Guna.UI2.WinForms.Guna2Button();

            SuspendLayout();

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 45);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new Point(0, 50); // Adjusted to align with label
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 50); // Increased height
            txtEmail.TabIndex = 1;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblPassword.Location = new Point(0, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(165, 45);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";

            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges2;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new Point(0, 50); // Adjusted to align with label
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 50); // Increased height
            txtPassword.TabIndex = 3;

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblRole.Location = new Point(0, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(106, 45);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role:";

            // 
            // cmbRole
            // 
            cmbRole.CustomizableEdges = customizableEdges3;
            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbRole.Location = new Point(0, 50); // Adjusted to align with label
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(300, 50); // Increased height
            cmbRole.Items.AddRange(new object[] { "Student", "Admin" });

            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblProgram.Location = new Point(0, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(165, 45);
            lblProgram.TabIndex = 5;
            lblProgram.Text = "Program:";

            // 
            // txtProgram
            // 
            txtProgram.CustomizableEdges = customizableEdges4;
            txtProgram.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtProgram.Location = new Point(0, 50); // Adjusted to align with label
            txtProgram.Name = "txtProgram";
            txtProgram.Size = new Size(300, 50); // Increased height
            txtProgram.TabIndex = 6;

            // 
            // btnRegister
            // 
            btnRegister.CustomizableEdges = customizableEdges5;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.Location = new Point(50, 460);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(300, 40);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;

            // 
            // btnBackToLogin
            // 
            btnBackToLogin.CustomizableEdges = customizableEdges6;
            btnBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackToLogin.Location = new Point(50, 510); // Position below the register button
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(300, 40);
            btnBackToLogin.TabIndex = 8;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.Click += btnBackToLogin_Click;

            // 
            // RegisterControl
            // 
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblProgram);
            Controls.Add(txtProgram);
            Controls.Add(btnRegister);
            Controls.Add(btnBackToLogin);
            Name = "RegisterControl";
            Size = new Size(400, 600); // Adjusted height to accommodate new button
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRole;
        private System.Windows.Forms.Label lblProgram;
        private Guna.UI2.WinForms.Guna2TextBox txtProgram;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2Button btnBackToLogin;
    }
}
