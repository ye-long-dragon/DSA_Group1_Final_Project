using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.Pop_ups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    public partial class itemMasterList : UserControl
    {

        
        private FirestoreServices firestoreService = new FirestoreServices();
        StudentDocument student;
        StudentMasterList parentUserControl;
        MainScreen mainScreen;
        public itemMasterList(StudentDocument s, StudentMasterList parentUserControl, MainScreen mainScreen)
        {
            InitializeComponent();
            this.parentUserControl = parentUserControl;
            this.mainScreen = mainScreen;

            student = s;
            Dictionary<string, string> curriculumMapping = new Dictionary<string, string>
                {
                    { "1", "BS Computer Engineering 2022-2023" },
                    { "2", "BS Electrical Engineering 2024-2025" },
                    { "3", "BS Computer Engineering 2021-2022" },
                    { "4", "BS Electronics and Communications Engineering 2022-2023" }
                };
            string cur;
            if (student.Curriculum != null && curriculumMapping.TryGetValue(student.Curriculum.ToString(), out cur))
            {
                cur = curriculumMapping[student.Curriculum.ToString()];

            }
            else
            {
                cur = "Curriculum not found";
            }
            lblName.Text = "Student: " + student.Name;
            lblEmail.Text = "Email: " + student.Email;
            lblProgram.Text = "Program: " + student.Program;
            lblCurriculum.Text = "Current Curriculum: " + cur;
            lblStatus.Text = "Approval Status: " + student.ApprovalStatus;
        }

        public event EventHandler btnProgramClick;
        public event EventHandler btnStatusClick;
        public event EventHandler btncurriculumClick;
        public event EventHandler btnRemoveClick;




        private void btnProgram_Click(object sender, EventArgs e)
        {
            
            MainPopUpWindow mainPopUpWindow = new MainPopUpWindow("Program",student, parentUserControl);
            mainPopUpWindow.Show();
            


            /* // Create ContextMenuStrip (dropdown)
             ContextMenuStrip menu = new ContextMenuStrip();

             // List of programs
             string[] programs = { "BS Computer Engineering", "BS Electronics and Communications Engineering", "BS Electrical Engineering" };


            
             foreach (string program in programs)
             {
                 ToolStripMenuItem item = new ToolStripMenuItem(program);
                 item.Click += async (s, ev) => await ChangeProgram(student, program, e); // Attach click event
                 menu.Items.Add(item);
             }

             // Show dropdown below the clicked button
             if (sender is Button btn)
             {
                 Point location = new Point(0, btn.Height);
                 menu.Show(btn, location); // Show below button
             }*/
        }



        //Unused function
        //private async Task ChangeProgram(StudentDocument student, string newProgram, EventArgs e)
        //{
        //    if (student.Program != newProgram)
        //    {
        //        await firestoreService.UpdateStudentField(student.StudentID, "program", newProgram);
        //        MessageBox.Show($"{student.Name}'s program updated to {newProgram}.", "Success");
        //        btnProgramClick?.Invoke(this, e);

        //    }
        //}

        private void btnStatus_Click(object sender, EventArgs e)
        {
            
            MainPopUpWindow mainPopUpWindow = new MainPopUpWindow("Status", student, parentUserControl);
            mainPopUpWindow.Show();
            


            /*// Create ContextMenuStrip (dropdown)
            ContextMenuStrip menu = new ContextMenuStrip();

            // List of approval Status
            string[] approvalStatus = { "Approved", "Pending" };

            foreach (string status in approvalStatus)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(status);
                item.Click += async (s, ev) => await ChangeApprovalStatus(student, status); // Attach click event
                menu.Items.Add(item);
            }

            // Show dropdown below the clicked button
            if (sender is Button btn)
            {
                menu.Show(btn, new Point(0, btn.Height)); // Show below button
            }

            btnStatusClick?.Invoke(this, e);*/
        }

        private async Task ChangeApprovalStatus(StudentDocument student, string newApprovalStatus)
        {
            if (student.ApprovalStatus != newApprovalStatus)
            {
                await firestoreService.UpdateStudentField(student.StudentID, "approvalStatus", newApprovalStatus);
                MessageBox.Show($"{student.Name}'s approval status updated to {newApprovalStatus}.", "Success");


            }
        }

        private void btnCuriculum_Click(object sender, EventArgs e)
        {
            
            MainPopUpWindow mainPopUpWindow = new MainPopUpWindow("Curriculum", student, parentUserControl);
            mainPopUpWindow.Show();

            /* // Create ContextMenuStrip (dropdown)
            ContextMenuStrip menu = new ContextMenuStrip();

            // 🔥 List of Curriculums (User-friendly Names)
            string[] curriculums = {
                "BS Computer Engineering 2022-2023",
                "BS Electrical Engineering 2024-2025",
                "BS Computer Engineering 2021-2022",
                "BS Electronics and Communications Engineering 2022-2023"
            };

            foreach (string curriculum in curriculums)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(curriculum);
                item.Click += async (s, ev) => await ChangeCurriculum(student, curriculum); // Pass name, not ID
                menu.Items.Add(item);
            }

            // Show dropdown below the clicked button
            if (sender is Button btn)
            {
                menu.Show(btn, new Point(0, btn.Height)); // Show below button
            }
            btncurriculumClick?.Invoke(this, e);*/
        }


        private async Task ChangeCurriculum(StudentDocument student, string newCurriculumName)
        {
            // 🔥 Map curriculum name to its corresponding ID
            Dictionary<string, string> curriculumMapping = new Dictionary<string, string>
            {
                { "BS Computer Engineering 2022-2023", "1" },
                { "BS Electrical Engineering 2024-2025", "2" },
                { "BS Computer Engineering 2021-2022", "3" },
                { "BS Electronics and Communications Engineering 2022-2023", "4" }
            };

            if (curriculumMapping.TryGetValue(newCurriculumName, out string newCurriculumId))
            {
                if (student.Curriculum != newCurriculumId) // Check if different
                {
                    await firestoreService.UpdateStudentField(student.StudentID, "curriculum", newCurriculumId);
                    MessageBox.Show($"{student.Name}'s curriculum updated to {newCurriculumName}.", "Success");

                }

                else
                {
                    MessageBox.Show("Invalid curriculum selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to remove {student.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted;
                isDeleted = await DeleteStudent(student.StudentID); // Await the asynchronous method
                if (isDeleted)
                {
                    MessageBox.Show($"{student.Name} has been removed successfully!", "Student Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 🔥 Refresh the UI to remove the student
                }
                else
                {
                    MessageBox.Show("Failed to remove student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnRemoveClick?.Invoke(this, e);
        }

        private async Task<bool> DeleteStudent(string studentId)
        {
            return await firestoreService.DeleteStudent(studentId); // Ensure you pass the correct parameter
        }

        public event EventHandler btnDetailsClick;
        private void btnDetails_Click(object sender, EventArgs e)
        {
            // 🔥 Create new ViewCurriculumDetails UserControl
            ViewCurriculumDetails curriculumDetailsControl = new ViewCurriculumDetails(student);

            // 🔥 Call LoadUserControl() from TestForm to switch screens
            mainScreen.LoadUserControl(curriculumDetailsControl);

            btnDetailsClick?.Invoke(this, e);
        }

        public event EventHandler btnAvailableCoursesClick;

        private void btnAvailableCourses_Click(object sender, EventArgs e)
        {
            AdminNextAvailableCourses adminNextAvailableCourses = new AdminNextAvailableCourses(student);
            mainScreen.LoadUserControl(adminNextAvailableCourses);

            btnAvailableCoursesClick?.Invoke(this, e);
        }
    }
}
