

using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class Register
    {
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblProgram;

        private void InitializeComponent()
        {
            btnRegister = new Button();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            txtProgram = new TextBox();
            lblEmail = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            lblProgram = new Label();

            SuspendLayout();

            // lblEmail
            lblEmail.Location = new Point(50, 50);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.Text = "Email:";

            // txtEmail
            txtEmail.Location = new Point(150, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 31);

            // lblPassword
            lblPassword.Location = new Point(50, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.Text = "Password:";

            // txtPassword
            txtPassword.Location = new Point(150, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 31);
            txtPassword.PasswordChar = '*'; // Hide password input

            // lblRole
            lblRole.Location = new Point(50, 150);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.Text = "Role:";

            // cmbRole
            cmbRole.Location = new Point(150, 150);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 33);
            cmbRole.Items.AddRange(new string[] { "Student", "Admin" });

            // lblProgram
            lblProgram.Location = new Point(50, 200);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(100, 23);
            lblProgram.Text = "Program:";

            // txtProgram
            txtProgram.Location = new Point(150, 200);
            txtProgram.Name = "txtProgram";
            txtProgram.Size = new Size(200, 31);

            // btnRegister
            btnRegister.Location = new Point(150, 250);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 30);
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;

            // Add controls to the form
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblProgram);
            Controls.Add(txtProgram);
            Controls.Add(btnRegister);

            // Form settings
            ClientSize = new Size(400, 350);
            Name = "Register";
            Text = "User Registration";
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
