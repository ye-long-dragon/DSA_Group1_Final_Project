using FirebaseAdmin.Auth;
using DSA_Group1_Final_Project.Classes.Connection;
using System.Diagnostics;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class LoginControl : UserControl // Change Form → UserControl
    {
        public event Action OnRegisterRequested;
        public event Action<string> OnLoginSuccess;
        public event Action OnForgotPasswordRequested;

        private int parentWidth;
        private int parentHeight;

        public LoginControl(int width, int height)
        {
            InitializeComponent();

            parentWidth = width;
            parentHeight = height;
            txtEmail.KeyPress += TextBox_KeyPress;
            txtPassword.KeyPress += TextBox_KeyPress;
            ResizeLoginControl();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private Label CreateErrorLabel()
        {
            return new Label
            {
                ForeColor = Color.Red,
                Visible = false
                
            };
        }

        private void ResizeLoginControl()
        {
          
            this.Size = new Size(parentWidth, parentHeight);
            CenterControls();
        }
        // FOR UI PPORPUSE ---------------------------------
        private void CenterControls()
        {
            int padding = 60;
            int controlSpacing = 30;  // Reduced spacing for better alignment
            int containerWidth = parentWidth - 100; // Adjust width to fit within the parent
            int containerHeight = parentHeight - 100; // Adjust height to fit within the parent


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

            int buttonWidth = 340;
            int buttonHeight = 45;

            Label loginLabel = new Label
            {
                Text = "Welcome",
                Font = new Font("Arial", 24, FontStyle.Bold),
                Size = new Size(buttonWidth, 60), 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point((containerPanel.Width - buttonWidth) / 2, padding) 
            };

            // Remove existing parent before adding to new container
            if (txtEmail.Parent != null) txtEmail.Parent.Controls.Remove(txtEmail);
            if (txtPassword.Parent != null) txtPassword.Parent.Controls.Remove(txtPassword);
            if (label1.Parent != null) label1.Parent.Controls.Remove(label1);
            if (label2.Parent != null) label2.Parent.Controls.Remove(label2);

          
            Panel emailPanel = new Panel
            {
                Size = new Size(containerWidth, 125), 
                BackColor = Color.Transparent
            };

            label1.Location = new Point(0, 0);
            txtEmail.Location = new Point(0, label1.Height + 5);
            txtEmail.Size = new Size(containerWidth, 50); 

            lblEmailError.Location = new Point(0, txtEmail.Bottom);
            lblEmailError.Size = new Size(containerWidth, 50);
            emailPanel.Controls.Add(label1);
            emailPanel.Controls.Add(txtEmail);
            emailPanel.Controls.Add(lblEmailError);
            lblEmailError.BringToFront();

            Panel passwordPanel = new Panel { Size = new Size(containerWidth, 125), BackColor = Color.Transparent };
            label2.Location = new Point(0, 0);
            txtPassword.Location = new Point(0, label2.Height + 5);
            txtPassword.Size = new Size(containerWidth, 50); 
            lblPasswordError.Location = new Point(0, txtPassword.Bottom);
            lblPasswordError.Size = new Size(containerWidth, 50); 
            passwordPanel.Controls.Add(label2);
            passwordPanel.Controls.Add(txtPassword);
            passwordPanel.Controls.Add(lblPasswordError);
            passwordPanel.Controls.Add(showPassCheckBox);
            showPassCheckBox.Location = new Point(txtPassword.Width - 100, txtPassword.Top + 15);


            List<Control> orderedControls = new List<Control>
    {
        loginLabel, // Add the login label first
        emailPanel,
        passwordPanel,
        showPassCheckBox,
        btnLogin,
        btnForgotPassword,
        btnRegister
    };

            int yOffset = padding + loginLabel.Height + controlSpacing; // Adjust yOffset for the label

      
            foreach (Control ctrl in orderedControls)
            {
            
                if (ctrl == btnLogin || ctrl == btnForgotPassword || ctrl == btnRegister)
                {
                    ctrl.Width = buttonWidth;
                    ctrl.Height = buttonHeight;

                    // Center the button
                    ctrl.Location = new Point(
                        (containerPanel.Width - ctrl.Width) / 2, 
                        yOffset // Keep the same vertical position
                    );
                }
                else
                {
                    // For other controls, set their width
                    ctrl.Width = containerPanel.Width - (2 * padding);
                    ctrl.Location = new Point(padding, yOffset); // Keeping the same location for non-buttons
                }

                // Update the yOffset for the next control
                yOffset += ctrl.Height + controlSpacing;
                containerPanel.Controls.Add(ctrl);
            }

            this.Controls.Clear();
            this.Controls.Add(containerPanel);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OnRegisterRequested?.Invoke();
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            OnForgotPasswordRequested?.Invoke();
        }
        private void showPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            txtPassword.PasswordChar = showPassCheckBox.Checked ? '\0' : '●';
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;
            ResetBorders();

            if (string.IsNullOrWhiteSpace(email))
            {
                txtEmail.BorderColor = Color.Red;
                lblEmailError.Text = "Email is required";
                lblEmailError.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                txtPassword.BorderColor = Color.Red;
                lblPasswordError.Text = "Password is required";
                lblPasswordError.Visible = true;
                return;
            }

            try
            {
                var authInstance = await Authentication.CreateAsync();
                var authClient = authInstance.AuthProvider;
                // Check if the email exists in the database
                bool emailExists = await authInstance.CheckEmailExists(email);

                if (!emailExists)
                {
                    txtEmail.BorderColor = Color.Red;
                    lblEmailError.Text = "Email is not registered.";
                    lblEmailError.Visible = true;
                    return;
                }

                var userCredential = await authClient.SignInWithEmailAndPasswordAsync(email, password);
                var user = userCredential.User;

                if (user != null)
                {
                    string userId = user.Uid;
                    string role = await Program.GetUserRole(userId);

                    //Save user session locally
                    Properties.Settings.Default.UserId = userId;
                    Properties.Settings.Default.Save();

                    if (role == "Student")
                    {
                        string curriculum = await Program.GetStudentCurriculum(userId);
                        if (string.IsNullOrWhiteSpace(curriculum))
                        {
                            Debug.WriteLine("No curriculum found, opening ChooseCurriculumForm.");

                            //  Close AuthForm before opening ChooseCurriculumForm
                            Form authForm = this.FindForm();
                            authForm?.Hide();

                            ChooseCurriculumForm chooseCurriculumForm = new ChooseCurriculumForm(userId);
                            chooseCurriculumForm.Show();

                            authForm?.Hide(); // Close AuthForm after curriculum selection
                            return; // Stop execution to prevent opening MainScreen prematurely
                        }
                    }

                    // Close AuthForm and open MainScreen
                    Form parentForm = this.FindForm();
                    parentForm?.Hide();

                    MainScreen mainScreen = new MainScreen(role, userId);
                    mainScreen.Show();
                }
            }
            catch (Firebase.Auth.FirebaseAuthException ex)
            {
                // Check if the error is due to incorrect password
                if (ex.Message.Contains("INVALID_LOGIN_CREDENTIALS"))
                {
                    txtPassword.BorderColor = Color.Red;
                    lblPasswordError.Text = "Incorrect password.";
                    lblPasswordError.Visible = true;
                }
                else
                {
                    MessageBox.Show("Login failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ResetBorders()
        {
            txtEmail.BorderColor = Color.Gray;
            txtPassword.BorderColor = Color.Gray;
        }
    }
}
