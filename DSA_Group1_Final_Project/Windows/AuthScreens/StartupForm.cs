using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class StartupForm : Form
    {
        private PictureBox logoPictureBox;
        private ProgressBar progressBar;
        private Label titleLabel; // Add a label for the title
        private int progressValue = 0;

        public StartupForm()
        {
            InitializeComponent();
            SetupUI();
            Shown += async (s, e) => await StartProgressBar(); // Start progress bar when the form is shown
        }

        private void SetupUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Size = new Size(400, 300);

            // Padding values
            int padding = 20; // You can adjust this value as needed

            // Logo Image
            logoPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(200, 100),
                Location = new Point((Width - 200) / 2, padding) // Position logo with padding
            };

            // Load logo image with error handling
            try
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pictures", "mmcm_logo.png");
                logoPictureBox.Image = Image.FromFile(imagePath); // Ensure logo is in the executable folder
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logo: " + ex.Message);
            }

            this.Controls.Add(logoPictureBox);

            // Title Labels
            titleLabel = new Label // Use the class-level titleLabel instead of creating a new one
            {
                Text = "MMCM CURRICULUM TRACKER",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, logoPictureBox.Bottom + padding), // Position below the logo with padding
                Width = this.Width // Center the label based on the form's width
            };
            titleLabel.Font = new Font("Arial", 12, FontStyle.Bold); // Decrease font size
            titleLabel.ForeColor = Color.Red;
            titleLabel.BackColor = Color.White;

            this.Controls.Add(titleLabel);

            // Progress Bar
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Size = new Size(300, 20),
                Location = new Point((Width - 300) / 2, titleLabel.Bottom + padding), // Position below the title with padding
                Value = 0
            };
            this.Controls.Add(progressBar);
        }

        private async Task StartProgressBar()
        {
            while (progressValue < 100)
            {
                await Task.Delay(50); // Asynchronously wait for 50 milliseconds
                progressValue += 2;
                progressBar.Value = progressValue;
            }
            await InitializeApp(); // Call the next form after progress finishes
        }

        private async Task InitializeApp()
        {
            var initialForm = await Program.GetInitialForm();
            initialForm.Show();
            this.Hide(); // Hide the StartupForm instead of closing it
        }
    }
}