using System;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class VerifyOTPForm : Form
    {
        private string email;
        private string password;
        private string role;
        private string program;

        public VerifyOTPForm(string email, string password, string role, string program)
        {
            this.email = email;
            this.password = password;
            this.role = role;
            this.program = program;

            InitializeComponent();
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOTP.Text;

            if (string.IsNullOrEmpty(enteredOtp))
            {
                MessageBox.Show("Please enter the OTP.");
                return;
            }

            Authentication auth = await Authentication.CreateAsync();
            string result = await auth.VerifyOtp(email, enteredOtp, password, role, program);

            if (result == "Registration successful.")
            {
                MessageBox.Show("Registration successful! You can now log in.");
                this.Close(); 

                AuthForm mainForm = Application.OpenForms.OfType<AuthForm>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.ShowLogin();
                }
            }
            else
            {
                MessageBox.Show(result);
            }
        }

    }
}
