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
            this.brandingPanel.Width = screenWidth / 2; 
            this.brandingPanel.BackColor = Color.Navy;
            this.Controls.Add(this.brandingPanel);

            // Auth Panel (Right Side - 50% Width)
            this.panelContainer.Dock = DockStyle.Right; 
            this.panelContainer.Width = screenWidth / 2;
            this.panelContainer.BackColor = Color.White;
            this.Controls.Add(this.panelContainer);

            // Create TableLayoutPanel to stack image and label
            TableLayoutPanel brandingLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            brandingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            brandingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Move up to the main project folder (adjust as needed)
            string imagePath = Path.Combine(projectDirectory, "Pictures", "mmcm_logo.png");

            // Ensure the file exists before loading
            if (File.Exists(imagePath))
            {
                PictureBox brandingImage = new PictureBox
                {
                    Image = Image.FromFile(imagePath),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };
                brandingLayout.Controls.Add(brandingImage, 0, 0);
            }
            else
            {
                MessageBox.Show("Image file not found: " + imagePath);
            }
            // Branding Label (MMCM CURRICULUM TRACKER)
            Label brandingLabel = new Label
            {
                Text = "MMCM\nCOURSE TRACKER",
                ForeColor = Color.Red,
                Font = new Font("Arial", 36, FontStyle.Bold), // Large font
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            // Add Image and Label to TableLayoutPane
            brandingLayout.Controls.Add(brandingLabel, 0, 1);

            // Add TableLayoutPanel to brandingPanel
            this.brandingPanel.Controls.Add(brandingLayout);

            this.ResumeLayout(false);
        }
        #endregion
    }
}
