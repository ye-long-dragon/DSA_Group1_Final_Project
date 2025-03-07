using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class ChooseCurriculumForm : Form
    {
        private string userId;
        private FirestoreDb db;

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

            // ✅ Initialize UI elements
            InitializeComponent(); // Call the designer's InitializeComponent method
            PopulateCurriculumDropdown();
        }

        private void PopulateCurriculumDropdown()
        {
            curriculumComboBox.Items.Clear();
            foreach (var curriculum in curriculumOptions.Keys)
            {
                curriculumComboBox.Items.Add(curriculum);
            }
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

                // Close AuthForm explicitly if it's still open
                Form authForm = Application.OpenForms.OfType<AuthForm>().FirstOrDefault();
                authForm?.Close(); // 🔥 Ensure AuthForm is properly closed

                // Close ChooseCurriculumForm and open MainScreen
                this.Hide();
                MainScreen mainScreen = new MainScreen("Student");
                mainScreen.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Firestore: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}