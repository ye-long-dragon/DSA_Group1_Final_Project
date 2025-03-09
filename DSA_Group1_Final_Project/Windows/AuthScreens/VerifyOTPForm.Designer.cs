namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class VerifyOTPForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnVerify;

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
            lblOTP = new Label();
            txtOTP = new TextBox();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // lblOTP
            // 
            lblOTP.AutoSize = true;
            lblOTP.Font = new Font("Segoe UI", 10F);
            lblOTP.Location = new Point(17, 34);
            lblOTP.Name = "lblOTP";
            lblOTP.Size = new Size(73, 19);
            lblOTP.TabIndex = 0;
            lblOTP.Text = "Enter OTP:";
            // 
            // txtOTP
            // 
            txtOTP.Font = new Font("Segoe UI", 10F);
            txtOTP.Location = new Point(96, 34);
            txtOTP.MaxLength = 6;
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(145, 25);
            txtOTP.TabIndex = 1;
            // 
            // btnVerify
            // 
            btnVerify.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVerify.Location = new Point(153, 91);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(88, 28);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "Verify";
            btnVerify.Click += btnVerify_Click;
            // 
            // VerifyOTPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 141);
            Controls.Add(lblOTP);
            Controls.Add(txtOTP);
            Controls.Add(btnVerify);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "VerifyOTPForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Verify OTP";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}