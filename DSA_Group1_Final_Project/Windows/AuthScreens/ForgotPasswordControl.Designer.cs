namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class ForgotPasswordControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            btnChange = new Guna.UI2.WinForms.Guna2Button();
            btnBackToLogin = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(20, 20);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderText = "Enter your email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(200, 36);
            txtEmail.TabIndex = 0;
            // 
            // btnChange
            // 
            btnChange.CustomizableEdges = customizableEdges3;
            btnChange.Font = new Font("Segoe UI", 9F);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(20, 70);
            btnChange.Name = "btnChange";
            btnChange.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnChange.Size = new Size(200, 36);
            btnChange.TabIndex = 1;
            btnChange.Text = "Change Password";
            btnChange.Click += btnChange_Click;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.CustomizableEdges = customizableEdges5;
            btnBackToLogin.Font = new Font("Segoe UI", 9F);
            btnBackToLogin.ForeColor = Color.White;
            btnBackToLogin.Location = new Point(20, 120);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBackToLogin.Size = new Size(200, 36);
            btnBackToLogin.TabIndex = 2;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.Click += btnBackToLogin_Click;
            // 
            // ForgotPasswordControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtEmail);
            Controls.Add(btnChange);
            Controls.Add(btnBackToLogin);
            Name = "ForgotPasswordControl";
            Size = new Size(242, 177);
            ResumeLayout(false);
        }


        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnChange;
        private Guna.UI2.WinForms.Guna2Button btnBackToLogin;
    }
}
