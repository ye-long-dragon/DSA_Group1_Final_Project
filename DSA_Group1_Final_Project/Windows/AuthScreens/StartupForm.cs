using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class StartupForm : Form
    {
        private PictureBox logoPictureBox;
        private ProgressBar progressBar;
        private Label titleLabel;
        private int progressValue = 0;
        private CancellationTokenSource _cancellationTokenSource;

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
            int padding = 20;

            // Logo Image
            logoPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(200, 100),
                Location = new Point((Width - 200) / 2, padding + 30)
            };

            // Load logo image with error handling
            try
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pictures", "mmcm_logo.png");
                logoPictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logo: " + ex.Message);
            }

            this.Controls.Add(logoPictureBox);

            // Title Labels
            titleLabel = new Label
            {
                Text = "MMCM CURRICULUM TRACKER",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(75, logoPictureBox.Bottom + padding + 30),
                Width = this.Width
            };
            titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            titleLabel.ForeColor = Color.Red;
            titleLabel.BackColor = Color.White;

            this.Controls.Add(titleLabel);

            // Progress Bar
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Size = new Size(300, 20),
                Location = new Point((Width - 290) / 2, titleLabel.Bottom + padding),
                Value = 0
            };
            this.Controls.Add(progressBar);
        }

        private async Task StartProgressBar()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                while (progressValue < 100)
                {
                    await Task.Delay(50, _cancellationTokenSource.Token); // Asynchronously wait for 50 milliseconds
                    progressValue += 2;
                    progressBar.Value = progressValue;
                }
                await InitializeApp(); // Call the next form after progress finishes
            }
            catch (TaskCanceledException)
            {
                // Handle cancellation if needed
            }
        }

        private async Task InitializeApp()
        {
            var initialForm = await Program.GetInitialForm();
            initialForm.Show();
            this.Hide(); // Hide the StartupForm instead of closing it
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel the progress task if the form is closing
            _cancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {

        }
    }
}