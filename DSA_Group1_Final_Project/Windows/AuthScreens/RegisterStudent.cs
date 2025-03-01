using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Windows.AuthScreens;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project
{
    public partial class RegisterStudent : Form
    {
        public RegisterStudent()
        {
            InitializeComponent();
        }

        private async void Setup_Load(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string role = "Student";
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
