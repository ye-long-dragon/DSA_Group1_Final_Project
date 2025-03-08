namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class LoginControl
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
            label1 = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            showPassCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            btnRegister = new Button();
            btnForgotPassword = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            label1.Location = new Point(50, 80);
            label1.Name = "label1";
            label1.Size = new Size(106, 45);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(50, 120);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(1804, 40);
            txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            label2.Location = new Point(50, 180);
            label2.Name = "label2";
            label2.Size = new Size(165, 45);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(50, 220);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(1804, 40);
            txtPassword.TabIndex = 3;
            // 
            // showPassCheckBox
            // 
            showPassCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            showPassCheckBox.AutoSize = true;
            showPassCheckBox.Font = new Font("Segoe UI", 9F);
            showPassCheckBox.Location = new Point(50, 270);
            showPassCheckBox.Name = "showPassCheckBox";
            showPassCheckBox.Size = new Size(161, 29);
            showPassCheckBox.TabIndex = 4;
            showPassCheckBox.Text = "Show Password";
            showPassCheckBox.CheckedState.BorderThickness = 0;
            showPassCheckBox.UncheckedState.BorderThickness = 0;
            showPassCheckBox.CheckedState.FillColor = Color.Transparent;
            showPassCheckBox.UncheckedState.FillColor = Color.Transparent;
            showPassCheckBox.CheckedState.BorderColor = Color.Transparent;
            showPassCheckBox.UncheckedState.BorderColor = Color.Transparent;
            showPassCheckBox.CheckedChanged += showPassCheckBox_CheckedChanged;
            this.Controls.Add(showPassCheckBox);
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 310);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(1804, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegister.Location = new Point(50, 400);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(1804, 40);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Create Account";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnForgotPassword.Font = new Font("Segoe UI", 9F);
            btnForgotPassword.Location = new Point(50, 360);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(1804, 30);
            btnForgotPassword.TabIndex = 6;
            btnForgotPassword.Text = "Forgot Password?";
            btnForgotPassword.Click += btnForgotPassword_Click;
            // Initialize error labels
            lblEmailError = CreateErrorLabel();
/*            lblEmailError.Location = new Point(50, 200);*/ // Set appropriate location
            this.Controls.Add(lblEmailError);

            lblPasswordError = CreateErrorLabel();
/*            lblPasswordError.Location = new Point(50, 300);*/ // Set appropriate location
            this.Controls.Add(lblPasswordError);
            // 
            // LoginControl
            // 
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(showPassCheckBox);
            Controls.Add(btnLogin);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnRegister);
            Controls.Add(lblEmailError); // Add the error label to the control
            Controls.Add(lblPasswordError);
            Name = "LoginControl";
            Size = new Size(1504, 880);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnForgotPassword;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2CheckBox showPassCheckBox;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblPasswordError;
    }
}