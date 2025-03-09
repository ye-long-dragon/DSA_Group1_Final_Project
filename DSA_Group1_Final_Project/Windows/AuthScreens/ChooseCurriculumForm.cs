using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class ChooseCurriculumForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private string userId;
        private FirestoreDb db;

        // Declare control variables at class level
        /*private TextBox nameTextBox;
         private TextBox lastNameTextBox;
         private ComboBox curriculumComboBox;*/
        private Button logoutButton;

        private Dictionary<string, string> curriculumOptions = new Dictionary<string, string>
        {
            { "BS Computer Engineering 2022-2023", "1" },
            { "BS Computer Engineering 2021-2022", "3" },
            { "BS Electronics and Communications Engineering 2022-2023", "4" },
            { "BS Electrical Engineering 2024-2025", "2" }
        };

        public ChooseCurriculumForm(string userId)
        {
            this.userId = userId;
            db = FirestoreDb.Create("mmcm-curriculum-tracker-app");

            InitializeComponent();
            CreateControls();
            InitializeUI();
            PopulateCurriculumDropdown();

            _cancellationTokenSource = new CancellationTokenSource();
        }

        // Separate method to create controls to avoid any duplicates
        private void CreateControls()
        {
            // Create controls only once
            nameTextBox = new TextBox
            {
                Name = "nameTextBox",
                Width = 400,
                Height = 30,
                Font = new Font("Arial", 10)
            };
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            nameTextBox.KeyPress += NameTextBox_KeyPress;

            lastNameTextBox = new TextBox
            {
                Name = "lastNameTextBox",
                Width = 400,
                Height = 30,
                Font = new Font("Arial", 10)
            };
            lastNameTextBox.TextChanged += NameTextBox_TextChanged;
            lastNameTextBox.KeyPress += NameTextBox_KeyPress;
            curriculumComboBox = new ComboBox
            {
                Name = "curriculumComboBox",
                Width = 400,
                Height = 30,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10)
            };

            saveButton = new Button
            {
                Name = "saveButton",
                Text = "Save",
                Size = new Size(150, 35),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            saveButton.Click += saveButton_Click;

            logoutButton = new Button
            {
                Name = "logoutButton",
                Text = "Logout",
                Size = new Size(150, 35),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            logoutButton.Click += btnLogout_Click;
        }
        // Prevent leading spaces
        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true; // Block leading space
            }
        }

        // Ensure only one space at a time
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = System.Text.RegularExpressions.Regex.Replace(textBox.Text, @"\s{2,}", " ");
            textBox.SelectionStart = textBox.Text.Length; // Keep cursor at the end
        }

        private void InitializeUI()
        {
            this.Size = new Size(550, 500); // Increased size to ensure all content fits
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Text = "Choose Curriculum";

            // First, remove any existing controls to prevent duplicates
            this.Controls.Clear();

            // Main container panel
            Panel containerPanel = new Panel
            {
                Size = new Size(500, 430),
                Location = new Point(25, 25),
                BackColor = Color.LightGray,
                Padding = new Padding(20),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Create a table layout panel for structured layout
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 8, // Increased row count to fit all elements
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = new Padding(10)
            };

            // Set row styles to give proper spacing
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // First Name Label and TextBox
            table.Controls.Add(new Label
            {
                Text = "First Name:",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 5)
            }, 0, 0);

            table.Controls.Add(nameTextBox, 0, 1);

            // Last Name Label and TextBox
            table.Controls.Add(new Label
            {
                Text = "Last Name:",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 5)
            }, 0, 2);

            table.Controls.Add(lastNameTextBox, 0, 3);

            // Curriculum Label and ComboBox
            table.Controls.Add(new Label
            {
                Text = "Select Curriculum:",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 5)
            }, 0, 4);

            table.Controls.Add(curriculumComboBox, 0, 5);

            // Button Panel for Save and Logout buttons
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 100,
                Margin = new Padding(0, 20, 0, 0)
            };

            saveButton.Location = new Point(0, 0);
            logoutButton.Location = new Point(0, 45); // Position below save button with spacing

            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(logoutButton);

            table.Controls.Add(buttonPanel, 0, 6);

            containerPanel.Controls.Add(table);
            this.Controls.Add(containerPanel);
        }

        private void PopulateCurriculumDropdown()
        {
            curriculumComboBox.Items.Clear();
            foreach (var curriculum in curriculumOptions.Keys)
            {
                curriculumComboBox.Items.Add(curriculum);
            }
            curriculumComboBox.SelectedIndex = 0; // Set default selection
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            string firstName = nameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string selectedCurriculum = curriculumComboBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(selectedCurriculum))
            {
                MessageBox.Show("Please fill all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = $"{firstName} {lastName}".Trim();
            string curriculumId = curriculumOptions[selectedCurriculum];

            await UpdateFirestore(fullName, curriculumId);
        }

        private async Task UpdateFirestore(string fullName, string curriculumId)
        {
            try
            {
                DocumentReference studentRef = db.Collection("students").Document(userId);
                await studentRef.SetAsync(new Dictionary<string, object>
                {
                    { "name", fullName },
                    { "curriculum", curriculumId }
                }, SetOptions.MergeAll);

                MessageBox.Show("Curriculum updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form authForm = Application.OpenForms.OfType<AuthForm>().FirstOrDefault();
                authForm?.Hide();

                MainScreen mainScreen = new MainScreen("Student", userId);
                mainScreen.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Firestore: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserId = "";
            Properties.Settings.Default.Save();

            AuthForm authForm = new AuthForm();
            authForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}