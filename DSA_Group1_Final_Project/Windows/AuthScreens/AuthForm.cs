
namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class AuthForm : Form
    {
        private int authPanelWidth;
        private int authPanelHeight;

        public AuthForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.Load += AuthForm_Load; // Ensure UI is ready before adding controls
            authPanelWidth = panelContainer.Width;
            authPanelHeight = panelContainer.Height;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            authPanelWidth = panelContainer.Width;
            authPanelHeight = panelContainer.Height;
            ShowLogin();
        }

        public void ShowLogin()
        {
            if (panelContainer == null) return;

            panelContainer.Controls.Clear();

            LoginControl loginControl = new LoginControl(authPanelWidth, authPanelHeight)
            {
                Dock = DockStyle.Fill
            };

            // Attach event handlers
            loginControl.OnRegisterRequested += ShowRegister;
            loginControl.OnLoginSuccess += OpenMainScreen; // Handle login success
            loginControl.OnForgotPasswordRequested += ShowForgotPassword;

            panelContainer.Controls.Add(loginControl);
        }

        private void ShowRegister()
        {
            if (panelContainer == null) return;

            // Clear existing controls
            panelContainer.Controls.Clear();

            // Create RegisterControl
            RegisterControl registerControl = new RegisterControl(authPanelHeight, authPanelHeight)
            {
                Dock = DockStyle.Fill
            };

            // Attach event to go back to login
            registerControl.OnLoginRequested += ShowLogin;

            // Add RegisterControl to panelContainer
            panelContainer.Controls.Add(registerControl);
        }

        // This method will switch to the main screen
        private void OpenMainScreen(string role)
        {
            this.Invoke(new Action(() =>
            {
                this.Hide(); // Hide AuthForm
                MainScreen mainScreen = new MainScreen(role, "userId");
                mainScreen.Show();
                mainScreen.FormClosed += (s, e) => this.Close(); // Close AuthForm only when MainScreen is closed
            }));
        }

        public void ShowForgotPassword()
        {
            if (panelContainer == null) return;

            panelContainer.Controls.Clear();

            ForgotPasswordControl forgotPasswordControl = new ForgotPasswordControl(authPanelWidth, authPanelHeight)
            {
                Dock = DockStyle.Fill
            };

            forgotPasswordControl.OnOtpSent += ShowVerifyOtp;
            forgotPasswordControl.OnBackToLogin += ShowLogin;

            panelContainer.Controls.Add(forgotPasswordControl);
        }

        private void ShowVerifyOtp(string email)
        {
            if (panelContainer == null) return;

            panelContainer.Controls.Clear();

            VerifyOtpPasswordControl verifyOtpControl = new VerifyOtpPasswordControl(email, authPanelWidth, authPanelHeight)
            {
                Dock = DockStyle.Fill
            };

            verifyOtpControl.OnPasswordChanged += ShowLogin;

            panelContainer.Controls.Add(verifyOtpControl);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unsubscribe from events to prevent memory leaks
            foreach (Control control in panelContainer.Controls)
            {
                if (control is LoginControl loginControl)
                {
                    loginControl.OnRegisterRequested -= ShowRegister;
                    loginControl.OnLoginSuccess -= OpenMainScreen;
                    loginControl.OnForgotPasswordRequested -= ShowForgotPassword;
                }
                else if (control is RegisterControl registerControl)
                {
                    registerControl.OnLoginRequested -= ShowLogin;
                }
                else if (control is ForgotPasswordControl forgotPasswordControl)
                {
                    forgotPasswordControl.OnOtpSent -= ShowVerifyOtp;
                    forgotPasswordControl.OnBackToLogin -= ShowLogin;
                }
                else if (control is VerifyOtpPasswordControl verifyOtpControl)
                {
                    verifyOtpControl.OnPasswordChanged -= ShowLogin;
                }
            }

            base.OnFormClosing(e);
            Application.Exit(); // Ensure the application exits completely
        }
    }
}