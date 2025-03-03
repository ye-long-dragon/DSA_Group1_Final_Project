using System;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class RegisterControl : UserControl
    {
        public event Action OnLoginRequested;

        private int parentWidth;
        private int parentHeight;

        public RegisterControl(int width, int height)
        {
            InitializeComponent();

            parentWidth = width;
            parentHeight = height;

            ResizeRegisterControl();
        }

        private void ResizeRegisterControl()
        {
            this.Size = new Size(parentWidth, parentHeight);
            CenterControls();
        }

        private void CenterControls()
        {
            int padding = 60;
            int controlSpacing = 20;  // Reduced spacing for better alignment
            int containerWidth = parentWidth - 100; // Adjust width to fit within the parent
            int containerHeight = parentHeight - 100; // Adjust height to fit within the parent

            // Create a container panel to hold the controls
            Panel containerPanel = new Panel
            {
                Size = new Size(containerWidth, containerHeight),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

            // Center the container panel
            containerPanel.Location = new Point(
                (this.Width - containerPanel.Width) / 2,
                (this.Height - containerPanel.Height) / 2
            );

            // Remove existing parent before adding to new container
            if (txtEmail.Parent != null) txtEmail.Parent.Controls.Remove(txtEmail);
            if (txtPassword.Parent != null) txtPassword.Parent.Controls.Remove(txtPassword);
            if (cmbRole.Parent != null) cmbRole.Parent.Controls.Remove(cmbRole);
            if (txtProgram.Parent != null) txtProgram.Parent.Controls.Remove(txtProgram);
            if (btnRegister.Parent != null) btnRegister.Parent.Controls.Remove(btnRegister);
            if (btnBackToLogin.Parent != null) btnBackToLogin.Parent.Controls.Remove(btnBackToLogin);

            // Add controls in the right order
            List<Control> orderedControls = new List<Control>
        {
            CreateLabeledControl(lblEmail, txtEmail),
            CreateLabeledControl(lblPassword, txtPassword),
            CreateLabeledControl(lblRole, cmbRole),
            CreateLabeledControl(lblProgram, txtProgram),
            btnRegister,
            btnBackToLogin
        };

            int yOffset = padding;

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

        private Panel CreateLabeledControl(Control label, Control inputControl)
        {
            Panel panel = new Panel { BackColor = Color.Transparent, Height = 80 }; // Adjust height as needed
            label.Location = new Point(0, 0);
            inputControl.Location = new Point(0, label.Height + 5); // 5 pixels gap between label and input
            inputControl.Size = new Size(panel.Width, 50); // Set proper height for input control

            panel.Controls.Add(label);
            panel.Controls.Add(inputControl);
            return panel;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string role = cmbRole.SelectedItem?.ToString();
                string program = txtProgram.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(program))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                btnRegister.Enabled = false; // Disable button to prevent multiple clicks
                Authentication auth = await Authentication.CreateAsync(); // Async initialization
                string result = await auth.RegisterUser(email, password, role, program);

                if (result == "Email already registered." || result == "Failed to send OTP. Please try again.")
                {
                    MessageBox.Show(result);
                    btnRegister.Enabled = true; // Re-enable button
                    return;
                }

                MessageBox.Show("OTP Sent! Please verify.");

                // Open VerifyOTPForm
                VerifyOTPForm otpForm = new VerifyOTPForm(email, password, role, program);
                otpForm.ShowDialog(); // Open OTP verification as a modal

                // If OTP verification is successful, return to login
                OnLoginRequested?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                btnRegister.Enabled = true; // Re-enable button
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            OnLoginRequested?.Invoke(); // Trigger the login request event
        }
    }
}
