using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class ForgotPasswordControl : UserControl
    {
        public event Action<string> OnOtpSent;
        public event Action OnBackToLogin;

        private int parentWidth;
        private int parentHeight;

        public ForgotPasswordControl(int width, int height)
        {
            InitializeComponent();

            parentWidth = width;
            parentHeight = height;

            ResizeForgotPasswordControl();
        }

        private void ResizeForgotPasswordControl()
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
                Text = "Forgot Password",
                Font = new Font("Arial", 24, FontStyle.Bold),
                Size = new Size(containerWidth, 60), 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(0, padding) 
            };

            // Create email input panel
            Panel emailPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            Label emailLabel = new Label { Text = "Email", Location = new Point(0, 0) };
            txtEmail.Location = new Point(0, emailLabel.Height + 5);
            txtEmail.Size = new Size(containerWidth, 50); 
            emailPanel.Controls.Add(emailLabel);
            emailPanel.Controls.Add(txtEmail);

            // Create buttons panel
            Panel buttonPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            btnChange.Location = new Point(0, 0);
            btnChange.Size = new Size(containerWidth, 36);
            btnBackToLogin.Location = new Point(0, btnChange.Height + controlSpacing);
            btnBackToLogin.Size = new Size(containerWidth, 36);
            buttonPanel.Controls.Add(btnChange);
            buttonPanel.Controls.Add(btnBackToLogin);

            List<Control> orderedControls = new List<Control>
    {
        titleLabel, 
        emailPanel,
        buttonPanel
    };

            int yOffset = padding + titleLabel.Height + controlSpacing;

            // Position controls inside container panel
            foreach (Control ctrl in orderedControls)
            {
                ctrl.Width = containerPanel.Width - (2 * padding);
                ctrl.Location = new Point(padding, yOffset);
                yOffset += ctrl.Height + controlSpacing;
                containerPanel.Controls.Add(ctrl);
            }

            // Clear previous controls and add container panel
            this.Controls.Clear();
            this.Controls.Add(containerPanel);
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            // Disable the button to prevent multiple clicks
            btnChange.Enabled = false;

            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email.");
                btnChange.Enabled = true; // Re-enable the button before returning
                return;
            }

            try
            {
                Authentication auth = await Authentication.CreateAsync();
                bool otpSent = await auth.SendOtp(email); // This returns a bool
                                                          // Check if the email exists in the database
                bool emailExists = await auth.CheckEmailExists(email);

                if (!emailExists)
                {
                    MessageBox.Show("Email is not registered.");
                    return;
                }

                if (otpSent)
                {
                    MessageBox.Show("OTP sent. Please verify.");
                    OnOtpSent?.Invoke(email);
                }
                else
                {
                    MessageBox.Show("Failed to send OTP. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Re-enable the button in the finally block
                btnChange.Enabled = true;
            }
        }
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            OnBackToLogin?.Invoke();
        }
    }
}