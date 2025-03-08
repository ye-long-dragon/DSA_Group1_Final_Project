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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Initialize Guna2TextBox for email
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail.Location = new System.Drawing.Point(20, 20); // Set appropriate location
            this.txtEmail.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.txtEmail.PlaceholderText = "Enter your email"; // Optional placeholder text
            this.Controls.Add(this.txtEmail);
            // Initialize btnChange using Guna2Button
            this.btnChange = new Guna.UI2.WinForms.Guna2Button();
            this.btnChange.Location = new System.Drawing.Point(20, 70); // Set appropriate location
            this.btnChange.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.btnChange.Text = "Change Password";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            this.Controls.Add(this.btnChange);

            // Initialize btnBackToLogin using Guna2Button
            this.btnBackToLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackToLogin.Location = new System.Drawing.Point(20, 120); // Set appropriate location
            this.btnBackToLogin.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.btnBackToLogin.Text = "Back to Login";
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);
            this.Controls.Add(this.btnBackToLogin);
        }


        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnChange;
        private Guna.UI2.WinForms.Guna2Button btnBackToLogin;
    }
}
