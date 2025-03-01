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
            this.lblOTP = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblOTP
            this.lblOTP.AutoSize = true;
            this.lblOTP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOTP.Location = new System.Drawing.Point(30, 20);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(75, 20);
            this.lblOTP.Text = "Enter OTP:";

            // txtOTP
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOTP.Location = new System.Drawing.Point(30, 50);
            this.txtOTP.MaxLength = 6;
            this.txtOTP.Size = new System.Drawing.Size(200, 25);

            // btnVerify
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerify.Location = new System.Drawing.Point(30, 90);
            this.btnVerify.Size = new System.Drawing.Size(100, 30);
            this.btnVerify.Text = "Verify";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // VerifyOTPForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.lblOTP);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.btnVerify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VerifyOTPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify OTP";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}