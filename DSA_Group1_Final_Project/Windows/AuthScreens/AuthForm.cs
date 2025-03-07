using DSA_Group1_Final_Project.Windows.UserControls.Auth;
using System;
using System.Drawing;
using System.Windows.Forms;

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
                MainScreen mainScreen = new MainScreen(role);
                mainScreen.Show();
                mainScreen.FormClosed += (s, e) => this.Close(); // Close AuthForm only when MainScreen is closed
            }));
        }

    }
}
