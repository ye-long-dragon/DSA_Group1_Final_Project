

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblRole = new Label();
            cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            lblProgram = new Label();
            cmbProgram = new Guna.UI2.WinForms.Guna2ComboBox();
            btnRegister = new Guna.UI2.WinForms.Guna2Button();
            btnBackToLogin = new Guna.UI2.WinForms.Guna2Button();

            SuspendLayout();

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 45);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";

            // txtEmail
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new Point(0, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 50);
            txtEmail.TabIndex = 1;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblPassword.Location = new Point(0, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(165, 45);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";

            // txtPassword
            txtPassword.CustomizableEdges = customizableEdges2;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new Point(0, 50);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 50);
            txtPassword.TabIndex = 3;

            // lblConfirmPassword
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(0, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(235, 45);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm Password:";

            // txtConfirmPassword
            txtConfirmPassword.CustomizableEdges = customizableEdges7;
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(0, 50);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(300, 50);
            txtConfirmPassword.TabIndex = 5;

            // Show Password Checkbox
            showPasswordCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            showPasswordCheckBox.Text = "Show Password";
            showPasswordCheckBox.Font = new System.Drawing.Font("Segoe UI", 10);
            showPasswordCheckBox.CheckedState.BorderThickness = 0;
            showPasswordCheckBox.UncheckedState.BorderThickness = 0;
            showPasswordCheckBox.CheckedState.FillColor = Color.Transparent;
            showPasswordCheckBox.UncheckedState.FillColor = Color.Transparent;
            showPasswordCheckBox.CheckedState.BorderColor = Color.Transparent;
            showPasswordCheckBox.UncheckedState.BorderColor = Color.Transparent;
            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
            showPasswordCheckBox.AutoSize = true;

            // Show Confirm Password Checkbox
            showConfirmPasswordCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            showConfirmPasswordCheckBox.Text = "Show Confirm Password";
            showConfirmPasswordCheckBox.Font = new System.Drawing.Font("Segoe UI", 10);
            showConfirmPasswordCheckBox.CheckedState.BorderThickness = 0;
            showConfirmPasswordCheckBox.UncheckedState.BorderThickness = 0;
            showConfirmPasswordCheckBox.CheckedState.FillColor = Color.Transparent;
            showConfirmPasswordCheckBox.UncheckedState.FillColor = Color.Transparent;
            showConfirmPasswordCheckBox.CheckedState.BorderColor = Color.Transparent;
            showConfirmPasswordCheckBox.UncheckedState.BorderColor = Color.Transparent;
            showConfirmPasswordCheckBox.CheckedChanged += ShowConfirmPasswordCheckBox_CheckedChanged;
            showConfirmPasswordCheckBox.AutoSize = true;


            // lblRole
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblRole.Location = new Point(0, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(106, 45);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role:";

            // cmbRole
            cmbRole.CustomizableEdges = customizableEdges3;
            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbRole.Location = new Point(0, 50);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(300, 50);

            // lblProgram
            lblProgram.AutoSize = true;
            lblProgram.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            lblProgram.Location = new Point(0, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(165, 45);
            lblProgram.TabIndex = 7;
            lblProgram.Text = "Program:";

            // txtProgram
            cmbProgram.CustomizableEdges = customizableEdges4;
            cmbProgram.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbProgram.Location = new Point(0, 50);
            cmbProgram.Name = "txtProgram";
            cmbProgram.Size = new Size(300, 50);
            cmbProgram.TabIndex = 8;

            // btnRegister
            btnRegister.CustomizableEdges = customizableEdges5;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.Location = new Point(50, 560);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(1804, 40);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;

            // btnBackToLogin
            btnBackToLogin.CustomizableEdges = customizableEdges6;
            btnBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackToLogin.Location = new Point(50, 610);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(300, 40);
            btnBackToLogin.TabIndex = 10;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.FillColor = Color.LightGray;
            btnBackToLogin.ForeColor = Color.Black;     
            btnBackToLogin.BorderColor = Color.DarkGray; 
            btnBackToLogin.BorderThickness = 1;
            btnBackToLogin.Click += btnBackToLogin_Click;

            // Initialize error labels
            lblEmailError = new System.Windows.Forms.Label();
            lblEmailError.ForeColor = System.Drawing.Color.Red;
            lblEmailError.AutoSize = true;
            lblEmailError.Visible = false;
            lblEmailError.Location = new System.Drawing.Point(50, 200); // Set appropriate location
            this.Controls.Add(lblEmailError);

            lblPasswordError = new System.Windows.Forms.Label();
            lblPasswordError.ForeColor = System.Drawing.Color.Red;
            lblPasswordError.AutoSize = true;
            lblPasswordError.Visible = false;
            lblPasswordError.Location = new System.Drawing.Point(50, 300); // Set appropriate location
            this.Controls.Add(lblPasswordError);

            lblConfirmPasswordError = new System.Windows.Forms.Label();
            lblConfirmPasswordError.ForeColor = System.Drawing.Color.Red;
            lblConfirmPasswordError.AutoSize = true;
            lblConfirmPasswordError.Visible = false;
            lblConfirmPasswordError.Location = new System.Drawing.Point(50, 400); // Set appropriate location
            this.Controls.Add(lblConfirmPasswordError);
        }

        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRole;
        private System.Windows.Forms.Label lblProgram;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProgram;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2Button btnBackToLogin;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblConfirmPasswordError;
    }
}
