using System;
using System.Drawing;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    public partial class StudentPending : UserControl
    {
        public StudentPending()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "Waiting for Admin Approval",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Red,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((this.Width - 300) / 2, 150),
                Anchor = AnchorStyles.Top
            };

            Label messageLabel = new Label
            {
                Text = "Sit back and relax while the admin reviews your curriculum. " +
                       "This process ensures that your academic progress is accurately verified and aligned with program requirements.",
                Font = new Font("Arial", 12, FontStyle.Regular),
                ForeColor = Color.Blue,
                AutoSize = false,
                Width = 400,
                Height = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((this.Width - 400) / 2, 200),
                Anchor = AnchorStyles.Top
            };

            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(messageLabel);
            this.Controls.Add(mainPanel);
        }
    }
}
