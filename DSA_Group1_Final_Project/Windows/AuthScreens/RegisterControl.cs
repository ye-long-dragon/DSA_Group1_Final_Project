using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class RegisterControl : UserControl
    {
        public event Action OnLoginRequested;

        private Guna.UI2.WinForms.Guna2CheckBox showPasswordCheckBox;
        private Guna.UI2.WinForms.Guna2CheckBox showConfirmPasswordCheckBox;
        private int parentWidth;
        private int parentHeight;


        public RegisterControl(int width, int height)
        {
            InitializeComponent();

            parentWidth = width;
            parentHeight = height;

            ResizeRegisterControl();
            InitializeRoleComboBox();

            txtEmail.KeyPress += TextBox_KeyPress;
            txtPassword.KeyPress += TextBox_KeyPress;
            txtConfirmPassword.KeyPress += TextBox_KeyPress;

        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; 
            }
        }
        private void InitializeRoleComboBox()
        {
            cmbRole.Items.AddRange(new object[] { "Student", "Admin" });
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            InitializeProgramComboBox();
        }
       

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '●'; 
        }

        private void ShowConfirmPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = showConfirmPasswordCheckBox.Checked ? '\0' : '●';
        }

        private void InitializeProgramComboBox()
        {
            cmbProgram.Items.AddRange(new object[]
            {
                "BS Computer Engineering",
                "BS Electrical Engineering",
                "BS Electronics and Communications Engineering"
            });
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem?.ToString() == "Admin")
            {
                cmbProgram.Enabled = false; 
            }
            else
            {
                cmbProgram.Enabled = true;
            }
        }

        private void ResizeRegisterControl()
        {
            this.Size = new Size(parentWidth, parentHeight);
            CenterControls();
        }


        private void CenterControls()
        {
            int padding = 60;
            int controlSpacing = 20;
            int containerWidth = parentWidth - 100;
            int containerHeight = parentHeight - 100;

            Panel containerPanel = new Panel
            {
                Size = new Size(containerWidth, containerHeight),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

            containerPanel.Location = new Point((this.Width - containerPanel.Width) / 2, (this.Height - containerPanel.Height) / 2);

            // --- Title Label ---
            Label lblTitle = new Label
            {
                Text = "Sign Up",
                Font = new Font("Arial", 24, FontStyle.Bold), 
                AutoSize = true
            };
            int programWidth = 540;

   
            lblTitle.Location = new Point((containerPanel.Width - programWidth + 200) / 2, padding);
            containerPanel.Controls.Add(lblTitle);

            int yOffset = padding + lblTitle.Height + (controlSpacing * 2);

            List<Control> orderedControls = new List<Control>
    {
        CreateLabeledControl(lblEmail, txtEmail, lblEmailError),
        CreateLabeledControl(lblPassword, txtPassword, lblPasswordError),
        showPasswordCheckBox,
        CreateLabeledControl(lblConfirmPassword, txtConfirmPassword, lblConfirmPasswordError),
        showConfirmPasswordCheckBox
    };

            foreach (Control ctrl in orderedControls)
            {
                if (ctrl != null)
                {
                    ctrl.Width = containerPanel.Width - (2 * padding);
                    ctrl.Location = new Point(padding, yOffset);
                    yOffset += ctrl.Height + controlSpacing;
                    containerPanel.Controls.Add(ctrl);
                }
            }

            // --- Role & Program Panel ---
            int roleWidth = 180;
            int inputHeight = 45;

            Panel roleProgramPanel = new Panel
            {
                Size = new Size(roleWidth + programWidth + controlSpacing, inputHeight * 2),
                Location = new Point((containerPanel.Width - (roleWidth + programWidth + controlSpacing + 115)) / 2, yOffset),
                BackColor = Color.Transparent
            };

            cmbRole.Size = new Size(roleWidth, inputHeight);
            cmbProgram.Size = new Size(programWidth, inputHeight);

            lblRole.AutoSize = true;
            lblProgram.AutoSize = true;

            lblRole.Location = new Point(0, 0);
            cmbRole.Location = new Point(0, lblRole.Height + 5);

            lblProgram.Location = new Point(roleWidth + controlSpacing, 0);
            cmbProgram.Location = new Point(roleWidth + controlSpacing, lblProgram.Height + 5);

            roleProgramPanel.Controls.Add(lblRole);
            roleProgramPanel.Controls.Add(cmbRole);
            roleProgramPanel.Controls.Add(lblProgram);
            roleProgramPanel.Controls.Add(cmbProgram);

            containerPanel.Controls.Add(roleProgramPanel);

            yOffset += roleProgramPanel.Height + controlSpacing;

            // --- Buttons ---
            btnRegister.Size = new Size(programWidth - 200, inputHeight);
            btnBackToLogin.Size = new Size(programWidth - 200, inputHeight);

            btnRegister.Location = new Point((containerPanel.Width - programWidth + 100) / 2, yOffset);
            yOffset += btnRegister.Height + controlSpacing;

            btnBackToLogin.Location = new Point((containerPanel.Width - programWidth + 100) / 2, yOffset);

            containerPanel.Controls.Add(btnRegister);
            containerPanel.Controls.Add(btnBackToLogin);

            this.Controls.Clear();
            this.Controls.Add(containerPanel);
        }



        private Panel CreateLabeledControl(Control label, Control inputControl, Label errorLabel)
        {
            Panel panel = new Panel { BackColor = Color.Transparent, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            label.Location = new Point(0, 0);
            inputControl.Location = new Point(0, label.Height);
            inputControl.Size = new Size(panel.Width + 540, 50);
            errorLabel.Location = new Point(0, inputControl.Location.Y + inputControl.Height);
            errorLabel.ForeColor = Color.Red;
            errorLabel.AutoSize = true;
            errorLabel.Visible = false;
            panel.Controls.Add(label);
            panel.Controls.Add(inputControl);
            panel.Controls.Add(errorLabel);
            return panel;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();
                string role = cmbRole.SelectedItem?.ToString();
                string program = cmbProgram.Enabled ? cmbProgram.SelectedItem?.ToString() : null; // Get program only if enabled

                // Reset borders
                ResetBorders();
                ResetErrorLabels();
                bool hasError = false;

                if (string.IsNullOrEmpty(email))
                {
                    txtEmail.BorderColor = Color.Red;
                    lblEmailError.Text = "Email is required.";
                    lblEmailError.Visible = true;
                    hasError = true;
                }
                if (string.IsNullOrEmpty(password))
                {
                    txtPassword.BorderColor = Color.Red;
                    lblPasswordError.Text = "Password cannot be empty.";
                    lblPasswordError.Visible = true;
                    hasError = true;
                }
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    txtConfirmPassword.BorderColor = Color.Red;
                    lblConfirmPasswordError.Text = "Confirm Password cannot be empty.";
                    lblConfirmPasswordError.Visible = true;
                    hasError = true;
                }
                if (password != confirmPassword)
                {
                    txtConfirmPassword.BorderColor = Color.Red;
                    lblConfirmPasswordError.Text = "Passwords do not match.";
                    lblConfirmPasswordError.Visible = true;
                    hasError = true;
                }
                if (string.IsNullOrEmpty(role))
                {
                    cmbRole.BorderColor = Color.Red;
                    hasError = true;

                }
                if (role != "Admin" && string.IsNullOrEmpty(program))
                {
                    cmbProgram.BorderColor = Color.Red;
                    hasError = true;
                }
                if (hasError)
                {
                    return;
                }

                btnRegister.Enabled = false;
                Authentication auth = await Authentication.CreateAsync();
                string result = await auth.RegisterUser(email, password, role, program);

                if (result == "Email already registered." || result == "Failed to send OTP. Please try again.")
                {
                    lblEmailError.Text = result;
                    lblEmailError.Visible = true;
                    btnRegister.Enabled = true;
                    return;
                }

                MessageBox.Show("OTP Sent! Please verify.");
                VerifyOTPForm otpForm = new VerifyOTPForm(email, password, role, program);
                otpForm.ShowDialog();
                OnLoginRequested?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }

        private void ResetBorders()
        {
            txtEmail.BorderColor = Color.Gray;
            txtPassword.BorderColor = Color.Gray;
            txtConfirmPassword.BorderColor = Color.Gray;
            cmbRole.BorderColor = Color.Gray;
            cmbProgram.BorderColor = Color.Gray;
        }
        private void ResetErrorLabels()
        {
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;
            txtEmail.BorderColor = Color.Gray;
            txtPassword.BorderColor = Color.Gray;
            txtConfirmPassword.BorderColor = Color.Gray;
            cmbRole.BorderColor = Color.Gray;
            cmbProgram.BorderColor = Color.Gray;
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            OnLoginRequested?.Invoke();
        }
    }
}