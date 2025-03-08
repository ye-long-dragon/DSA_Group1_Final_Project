namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class VerifyOtpPasswordControl
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

            // Initialize Guna2TextBox for OTP
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOTP.Location = new System.Drawing.Point(20, 20); // Set appropriate location
            this.txtOTP.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.txtOTP.PlaceholderText = "Enter OTP"; // Optional placeholder text
            this.Controls.Add(this.txtOTP);

            // Initialize Guna2TextBox for new password
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPassword.Location = new System.Drawing.Point(20, 70); // Set appropriate location
            this.txtNewPassword.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.txtNewPassword.PlaceholderText = "Enter new password"; // Optional placeholder text
            this.Controls.Add(this.txtNewPassword);

            // Initialize btnVerify using Guna2Button
            this.btnVerify = new Guna.UI2.WinForms.Guna2Button();
            this.btnVerify.Location = new System.Drawing.Point(20, 120); // Set appropriate location
            this.btnVerify.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.btnVerify.Text = "Change Password";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            this.Controls.Add(this.btnVerify);

            // Initialize btnBackToLogin using Guna2Button
            this.btnBackToLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackToLogin.Location = new System.Drawing.Point(20, 170); // Set appropriate location
            this.btnBackToLogin.Size = new System.Drawing.Size(200, 36); // Set appropriate size
            this.btnBackToLogin.Text = "Back to Login";
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);
            this.Controls.Add(this.btnBackToLogin);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2Button btnVerify;
        private Guna.UI2.WinForms.Guna2Button btnBackToLogin;
    }
}
