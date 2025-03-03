namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class AuthForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Panel brandingPanel;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelContainer = new Panel();
            this.brandingPanel = new Panel();

            // Get the screen resolution dynamically
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Form settings
            this.ClientSize = new Size(screenWidth, screenHeight);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // Branding Panel (Left Side - 50% Width)
            this.brandingPanel.Dock = DockStyle.Left;
            this.brandingPanel.Width = screenWidth / 2; // 50% Width
            this.brandingPanel.BackColor = Color.Navy;
            this.Controls.Add(this.brandingPanel);



            // Auth Panel (Right Side - 50% Width)
            this.panelContainer.Dock = DockStyle.Right; // Fix: Dock to Right instead of Fill
            this.panelContainer.Width = screenWidth / 2; // Ensure it's only 50% width
            this.panelContainer.BackColor = Color.White;
            this.Controls.Add(this.panelContainer);

            this.ResumeLayout(false);
        }
        #endregion
    }
}
