using System;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent(); // Calls the designer file to initialize UI controls
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
                    return;
                }

                Hide();
                VerifyOTPForm otpForm = new VerifyOTPForm(email, password, role, program);
                otpForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                btnRegister.Enabled = true; // Re-enable button after process completes
            }
        }

    }
}
