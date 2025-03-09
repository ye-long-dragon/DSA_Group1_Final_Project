using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.UserControls.Pop_ups
{
    public partial class UpdateCurriculum : UserControl
    {
        private readonly FirestoreServices firestoreService = new FirestoreServices();
        private int prevCurriculum, newCurriculum;
        private readonly StudentDocument student;
        private readonly StudentMasterList parentUserControl;

        private readonly Dictionary<int, string> curriculums = new()
    {
        { 1, "BS Computer Engineering 2022-2023" },
        { 2, "BS Electrical Engineering 2024-2025" },
        { 3, "BS Computer Engineering 2021-2022" },
        { 4, "BS Electronics and Communications Engineering 2022-2023" }
    };

        public UpdateCurriculum(StudentDocument studentDocument, StudentMasterList parentUserControl)
        {
            InitializeComponent();
            this.parentUserControl = parentUserControl ?? throw new ArgumentNullException(nameof(parentUserControl));
            this.student = studentDocument ?? throw new ArgumentNullException(nameof(studentDocument));

            try
            {
                // ✅ Ensure curriculums exist before proceeding
                if (curriculums == null || curriculums.Count == 0)
                {
                    MessageBox.Show("No curriculum data available. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ParentForm?.Close();
                    return;
                }

                // ✅ Validate and parse the student's curriculum safely
                if (!int.TryParse(studentDocument.Curriculum, out prevCurriculum) || !curriculums.ContainsKey(prevCurriculum))
                {
                    Debug.WriteLine($"Warning: Invalid curriculum found for student {studentDocument.Name}. Defaulting to first available.");
                    MessageBox.Show("Invalid curriculum data detected. Selecting default curriculum.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prevCurriculum = curriculums.Keys.First(); // Fallback to the first valid curriculum
                }

                // ✅ Populate the ComboBox safely
                cmbCurriculum.Items.Clear();
                foreach (var item in curriculums.Values)
                {
                    cmbCurriculum.Items.Add(item);
                }

                name.Text = studentDocument.Name;

                // ✅ Ensure the index is valid before setting it
                int index = curriculums.Keys.ToList().IndexOf(prevCurriculum);
                cmbCurriculum.SelectedIndex = index >= 0 ? index : 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing UpdateCurriculum: {ex.Message}");
                MessageBox.Show("An unexpected error occurred while loading curriculum data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ParentForm?.Close();
            }
        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✅ Prevent invalid selection
            if (cmbCurriculum.SelectedIndex >= 0 && cmbCurriculum.SelectedIndex < curriculums.Count)
            {
                newCurriculum = curriculums.Keys.ElementAt(cmbCurriculum.SelectedIndex);
            }
            else
            {
                Debug.WriteLine($"Warning: Invalid curriculum selection index {cmbCurriculum.SelectedIndex}");
                newCurriculum = prevCurriculum; // Fallback to previous selection
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                Debug.WriteLine($"Updating curriculum for student {student.Name} ({student.StudentID}) to {newCurriculum}");

                await firestoreService.UpdateStudentField(student.StudentID, "curriculum", newCurriculum.ToString());

                string updatedCurriculum = curriculums.TryGetValue(newCurriculum, out var curriculumName) ? curriculumName : "Unknown Curriculum";

                MessageBox.Show($"{student.Name}'s curriculum updated to {updatedCurriculum}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (parentUserControl != null)
                {
                    await parentUserControl.LoadStudents();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Failed to update curriculum for {student.Name} ({student.StudentID}): {ex}");
                MessageBox.Show($"Failed to update curriculum. Please try again later.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ParentForm?.Close();
            }
        }
    }
}
