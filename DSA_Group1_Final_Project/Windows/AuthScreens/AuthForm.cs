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

            // Clear existing controls
            panelContainer.Controls.Clear();

            // Create LoginControl
            LoginControl loginControl = new LoginControl(authPanelWidth, authPanelHeight)
            {
                Dock = DockStyle.Fill // Ensure it fully fills panelContainer
            };

            // Attach the event to handle redirection
            loginControl.OnRegisterRequested += ShowRegister;

            // Add LoginControl to panelContainer
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


    }
}
