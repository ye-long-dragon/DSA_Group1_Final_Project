using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class VerifyOtpPasswordControl : UserControl
    {
        private string email;

        public event Action OnPasswordChanged;
        private int parentWidth;
        private int parentHeight;

        public VerifyOtpPasswordControl(string email, int width, int height)
        {
            InitializeComponent();
            this.email = email;

            parentWidth = width;
            parentHeight = height;
            txtNewPassword.KeyPress += TextBox_KeyPress;

            ResizeVerifyOtpControl();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void ResizeVerifyOtpControl()
        {
            this.Size = new Size(parentWidth, parentHeight); 
            CenterControls();
        }

        private void CenterControls()
        {
            int padding = 60;
            int controlSpacing = 30; 
            int containerWidth = parentWidth - 100; 
            int containerHeight = parentHeight - 100;

    
            Panel containerPanel = new Panel
            {
                Size = new Size(containerWidth, containerHeight),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

    
            containerPanel.Location = new Point(
                (this.Width - containerPanel.Width) / 2,
                (this.Height - containerPanel.Height) / 2
            );

            Label titleLabel = new Label
            {
                Text = "Change Password",
                Font = new Font("Arial", 24, FontStyle.Bold),
                Size = new Size(containerWidth, 60), 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(0, padding)
            };

            Panel otpPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            Label otpLabel = new Label { Text = "Enter OTP", Location = new Point(0, 0) };
            txtOTP.Location = new Point(0, otpLabel.Height + 5);
            txtOTP.Size = new Size(containerWidth, 50); 
            otpPanel.Controls.Add(otpLabel);
            otpPanel.Controls.Add(txtOTP);

            Panel passwordPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            Label passwordLabel = new Label { Text = "New Password", Location = new Point(0, 0) };
            txtNewPassword.Location = new Point(0, passwordLabel.Height + 5);
            txtNewPassword.Size = new Size(containerWidth, 50);
            passwordPanel.Controls.Add(passwordLabel);
            passwordPanel.Controls.Add(txtNewPassword);

            Panel buttonPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            btnVerify.Location = new Point(0, 0);
            btnVerify.Size = new Size(containerWidth, 36);
            btnVerify.Click += btnVerify_Click; 
            buttonPanel.Controls.Add(btnVerify);

            btnBackToLogin.Location = new Point(0, btnVerify.Height + controlSpacing);
            btnBackToLogin.Size = new Size(containerWidth, 36);
            btnBackToLogin.Click += btnBackToLogin_Click;
            buttonPanel.Controls.Add(btnBackToLogin);

            List<Control> orderedControls = new List<Control>
            {
                titleLabel,
                otpPanel,
                passwordPanel,
                buttonPanel
            };

            int yOffset = padding + titleLabel.Height + controlSpacing; // Adjust yOffset for the title label

            // Position controls inside container panel
            foreach (Control ctrl in orderedControls)
            {
                ctrl.Width = containerPanel.Width - (2 * padding);
                ctrl.Location = new Point(padding, yOffset);
                yOffset += ctrl.Height + controlSpacing; 
                containerPanel.Controls.Add(ctrl); 
            }

            this.Controls.Clear();
            this.Controls.Add(containerPanel);
        }


        private async void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOTP.Text;
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(enteredOtp) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter the OTP and new password.");
                return;
            }

            Authentication auth = await Authentication.CreateAsync();
            string verificationResult = await auth.VerifyOtpForPasswordChange(email, enteredOtp);

            if (verificationResult == "OTP verified successfully.")
            {
                await auth.ChangePassword(email, newPassword);
                MessageBox.Show("Password changed successfully!");
                OnPasswordChanged?.Invoke();
            }
            else
            {
                MessageBox.Show(verificationResult);
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            OnPasswordChanged?.Invoke();
        }
    }
}