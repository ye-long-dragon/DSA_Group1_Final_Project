using DSA_Group1_Final_Project.Windows.UserControls.Auth;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class LoginControl : UserControl // Change Form → UserControl
    {
        public event Action OnRegisterRequested;

        private int parentWidth;
        private int parentHeight;

        public LoginControl(int width, int height)
        {
            InitializeComponent();

            parentWidth = width;
            parentHeight = height;

            ResizeLoginControl();
        }

        private void ResizeLoginControl()
        {
          
            this.Size = new Size(parentWidth, parentHeight);
            CenterControls();
        }
        // FOR UI PPORPUSE ---------------------------------
        private void CenterControls()
        {
            int padding = 60;
            int controlSpacing = 30;  // Reduced spacing for better alignment
            int containerWidth = parentWidth - 100; // Adjust width to fit within the parent
            int containerHeight = parentHeight - 100; // Adjust height to fit within the parent

            // Create a container panel to hold the controls
            Panel containerPanel = new Panel
            {
                Size = new Size(containerWidth, containerHeight),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

            // Center the container panel
            containerPanel.Location = new Point(
                (this.Width - containerPanel.Width) / 2,
                (this.Height - containerPanel.Height) / 2
            );

            // Remove existing parent before adding to new container
            if (txtEmail.Parent != null) txtEmail.Parent.Controls.Remove(txtEmail);
            if (txtPassword.Parent != null) txtPassword.Parent.Controls.Remove(txtPassword);
            if (label1.Parent != null) label1.Parent.Controls.Remove(label1);
            if (label2.Parent != null) label2.Parent.Controls.Remove(label2);

            // 🔹 Adjusted panel height to fit the textbox
            Panel emailPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            label1.Location = new Point(0, 0);
            txtEmail.Location = new Point(0, label1.Height + 5);
            txtEmail.Size = new Size(containerWidth, 50); // Set proper height
            emailPanel.Controls.Add(label1);
            emailPanel.Controls.Add(txtEmail);

            // 🔹 Adjusted panel height to fit the textbo
            Panel passwordPanel = new Panel { Size = new Size(containerWidth, 100), BackColor = Color.Transparent };
            label2.Location = new Point(0, 0);
            txtPassword.Location = new Point(0, label2.Height + 5);
            txtPassword.Size = new Size(containerWidth, 50); // Set proper height
            passwordPanel.Controls.Add(label2);
            passwordPanel.Controls.Add(txtPassword);

            // Add controls in the right order
            List<Control> orderedControls = new List<Control>
    {
        emailPanel,
        passwordPanel,
        showPassRadioButton,
        btnLogin,
        btnForgotPassword,
        btnRegister
    };

            int yOffset = padding;

            // Position controls inside container panel
            foreach (Control ctrl in orderedControls)
            {
                ctrl.Width = containerPanel.Width - (2 * padding);
                ctrl.Location = new Point(padding, yOffset);
                yOffset += ctrl.Height + controlSpacing;
                containerPanel.Controls.Add(ctrl);
            }

            // Clear previous controls and add container panel
            this.Controls.Clear();
            this.Controls.Add(containerPanel);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OnRegisterRequested?.Invoke();
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forgot Password Clicked!"); // You will replace this with navigation logic
        }

        private void showPassRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            txtPassword.UseSystemPasswordChar = !showPassRadioButton.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Example login logic
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Login Click!");


        }
    }
}
