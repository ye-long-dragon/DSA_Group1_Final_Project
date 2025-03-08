using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private readonly Dictionary<int, string> curriculums = new Dictionary<int, string>
    {
        {1, "BS Computer Engineering 2022-2023"},
        {2, "BS Electrical Engineering 2024-2025"},
        {3, "BS Computer Engineering 2021-2022"},
        {4, "BS Electronics and Communications Engineering 2022-2023"}
    };

        public UpdateCurriculum(StudentDocument studentDocument, StudentMasterList parentUserControl)
        {
            InitializeComponent();
            this.parentUserControl = parentUserControl ?? throw new ArgumentNullException(nameof(parentUserControl));
            this.student = studentDocument ?? throw new ArgumentNullException(nameof(studentDocument));

            // Try parsing curriculum and validate it
            if (!int.TryParse(studentDocument.Curriculum, out prevCurriculum) || !curriculums.ContainsKey(prevCurriculum))
            {
                MessageBox.Show("Invalid curriculum data found. Please select the correct curriculum.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prevCurriculum = 1; // Fallback to the first valid curriculum
            }

            // Populate the combo box
            cmbCurriculum.Items.Clear();
            foreach (var item in curriculums.Values)
            {
                cmbCurriculum.Items.Add(item);
            }

            name.Text = studentDocument.Name;
            cmbCurriculum.SelectedIndex = Math.Max(0, prevCurriculum - 1); // Ensure valid selection
        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            newCurriculum = cmbCurriculum.SelectedIndex + 1; // Match index with curriculum keys
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (prevCurriculum == newCurriculum)
            {
                MessageBox.Show("No changes made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ParentForm?.Close();
                return;
            }

            try
            {
                await firestoreService.UpdateStudentField(student.StudentID, "curriculum", newCurriculum.ToString());
                string updatedCurriculum = curriculums.ContainsKey(newCurriculum) ? curriculums[newCurriculum] : "Unknown Curriculum";

                MessageBox.Show($"{student.Name}'s curriculum updated to {updatedCurriculum}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (parentUserControl != null)
                {
                    await parentUserControl.LoadStudents();
                }
                this.ParentForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update curriculum: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
