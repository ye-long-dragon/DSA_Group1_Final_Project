using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Classes.Connection; // Import FirestoreServices
using DSA_Group1_Final_Project.Classes.Models; // Import Student model

namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    public partial class StudentMasterList : UserControl
    {
        private FirestoreServices firestoreService;
        private TestForm mainForm; // Store reference to TestForm
        public StudentMasterList()
        {
            InitializeComponent();
            firestoreService = new FirestoreServices();// 🔥 Store reference to TestForm
        }

        private async void StudentMasterList_Load(object sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async Task LoadStudents()
        {
            flpStudentList.Controls.Clear(); // Clear previous entries

            List<StudentDocument> students = await firestoreService.GetAllStudentsAsync();

            foreach (var student in students)
            {

                itemMasterList itemMasterList = new itemMasterList(student);
                itemMasterList.btnProgramClick += ItemMasterList_btnProgramClick;// 🔥 Add event handler
                itemMasterList.btnStatusClick += ItemMasterList_btnStatusClick;// 🔥 Add event handler
                itemMasterList.btncurriculumClick += ItemMasterList_btncurriculumClick;// 🔥 Add event handler
                itemMasterList.btnRemoveClick += ItemMasterList_btnRemoveClick;// 🔥 Add event handler
                itemMasterList.btnAvailableCoursesClick += (s, e) => ItemMasterList_btnDetailsClick(s, e, student);
                itemMasterList.btnAvailableCoursesClick += (s, e) => ItemMasterList_btnAvailableCoursesClick(s, e, student); 
                flpStudentList.Controls.Add(itemMasterList);


                /*

                // Create a main panel for each student
                Panel studentPanel = new Panel
                {
                    BackColor = Color.WhiteSmoke,
                    Padding = new Padding(10),
                    Size = new Size(flpStudentList.Width - 50, 220),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Create a TableLayoutPanel for better alignment
                TableLayoutPanel layout = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    RowCount = 6,
                    Dock = DockStyle.Fill,
                    AutoSize = true
                };
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F)); // Student Info
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Buttons

                // 🔥 Curriculum Mapping: Convert stored curriculum ID to full name
                Dictionary<string, string> curriculumMapping = new Dictionary<string, string>
                {
                    { "1", "BS Computer Engineering 2022-2023" },
                    { "2", "BS Electrical Engineering 2024-2025" },
                    { "3", "BS Computer Engineering 2021-2022" },
                    { "4", "BS Electronics and Communications Engineering 2022-2023" }
                };

                // Get the mapped curriculum name (if exists)
                string curriculumName = curriculumMapping.TryGetValue(student.Curriculum, out string mappedName) ? mappedName : "Unknown Curriculum";

                // Student Info Label (Now correctly displays Curriculum Name)
                Label lblStudentInfo = new Label
                {
                    Text = $"{student.Name}\n" +
                           $"Email: {student.Email}\n" +
                           $"Program: {student.Program}\n" +
                           $"Current Curriculum: {curriculumName}\n" + // 🔥 Uses mapped curriculum name
                           $"Approval Status: {student.ApprovalStatus}",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Padding = new Padding(5)
                };

                // Buttons
                Button btnUpdateProgram = new Button { Text = "Update Program", Dock = DockStyle.Fill, BackColor = Color.LightGray };
                Button btnUpdateApproval = new Button { Text = "Update Approval Status", Dock = DockStyle.Fill, BackColor = Color.LightGray };
                Button btnUpdateCurriculum = new Button { Text = "Update Curriculum", Dock = DockStyle.Fill, BackColor = Color.LightGray };
                Button btnViewCurriculumDetails = new Button { Text = "View Curriculum Details", Dock = DockStyle.Fill, BackColor = Color.LightGray };
                Button btnNextAvailableCourses = new Button
                {
                    Text = "Next Available Courses",
                    Dock = DockStyle.Fill,
                    BackColor = student.ApprovalStatus.ToLower() == "pending" ? Color.Gray : Color.LightGray, // 🔥 Change color when disabled
                    Enabled = student.ApprovalStatus.ToLower() != "pending" // 🔥 Disable if approval is pending
                };
                Button btnRemove = new Button { Text = "Remove Student", Dock = DockStyle.Fill, BackColor = Color.Red, ForeColor = Color.White };

                // Add click events
                btnUpdateProgram.Click += (s, e) => UpdateProgram(s, e, student);
                btnUpdateApproval.Click += (s, e) => UpdateApprovalStatus(s,e,student);
                btnUpdateCurriculum.Click += (s, e) => UpdateCurriculum(s,e,student);
                btnViewCurriculumDetails.Click += (s, e) => ViewCurriculumDetails(s, e, student);
                // Add click events (only if the button is enabled)
                if (btnNextAvailableCourses.Enabled)
                {
                    btnNextAvailableCourses.Click += (s, e) => NextAvailableCourses(s, e, student);
                }
                btnRemove.Click += (s, e) => RemoveStudent(s,e,student);

                // Add to TableLayoutPanel
                layout.Controls.Add(lblStudentInfo, 0, 0);
                layout.SetRowSpan(lblStudentInfo, 4); // Make label span multiple rows

                layout.Controls.Add(btnUpdateProgram, 1, 0);
                layout.Controls.Add(btnUpdateApproval, 1, 1);
                layout.Controls.Add(btnUpdateCurriculum, 1, 2);
                layout.Controls.Add(btnViewCurriculumDetails, 1, 3);
                layout.Controls.Add(btnNextAvailableCourses, 1, 4);
                layout.Controls.Add(btnRemove, 1, 5);

                // Add layout to student panel
                studentPanel.Controls.Add(layout);

                // Add panel to FlowLayoutPanel
                flpStudentList.Controls.Add(studentPanel);*/
            }
        }

        private async void ItemMasterList_btnProgramClick(object? sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async void ItemMasterList_btnStatusClick(object? sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async void ItemMasterList_btncurriculumClick(object? sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async void ItemMasterList_btnRemoveClick(object? sender, EventArgs e)
        {
            await LoadStudents();
        }

        // Button Click Event Handlers
        private void UpdateProgram(object sender, EventArgs e, StudentDocument student)
        {
            // Create ContextMenuStrip (dropdown)
            ContextMenuStrip menu = new ContextMenuStrip();

            // List of programs
            string[] programs = { "BS Computer Engineering", "BS Electronics and Communications Engineering", "BS Electrical Engineering" };

            foreach (string program in programs)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(program);
                item.Click += async (s, ev) => await ChangeProgram(student, program); // Attach click event
                menu.Items.Add(item);
            }

            // Show dropdown below the clicked button
            Button btn = sender as Button;
            menu.Show(btn, new Point(0, btn.Height)); // Show below button
        }

        // Update Firestore when selecting a new program
        private async Task ChangeProgram(StudentDocument student, string newProgram)
        {
            if (student.Program != newProgram)
            {
                await firestoreService.UpdateStudentField(student.StudentID, "program", newProgram);
                MessageBox.Show($"{student.Name}'s program updated to {newProgram}.", "Success");

                await LoadStudents(); // Refresh UI
            }
        }

        private void UpdateApprovalStatus(object sender, EventArgs e, StudentDocument student)
        {
            // Create ContextMenuStrip (dropdown)
            ContextMenuStrip menu = new ContextMenuStrip();

            // List of approval Status
            string[] approvalStatus = { "Approved", "Pending"};

            foreach (string status in approvalStatus)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(status);
                item.Click += async (s, ev) => await ChangeApprovalStatus(student, status); // Attach click event
                menu.Items.Add(item);
            }

            // Show dropdown below the clicked button
            Button btn = sender as Button;
            menu.Show(btn, new Point(0, btn.Height)); // Show below button
        }

        private async Task ChangeApprovalStatus(StudentDocument student, string newApprovalStatus)
        {
            if (student.ApprovalStatus != newApprovalStatus)
            {
                await firestoreService.UpdateStudentField(student.StudentID, "approvalStatus", newApprovalStatus);
                MessageBox.Show($"{student.Name}'s approval status updated to {newApprovalStatus}.", "Success");

                await LoadStudents(); // Refresh UI
            }
        }


        private void UpdateCurriculum(object sender, EventArgs e, StudentDocument student)
        {
            // Create ContextMenuStrip (dropdown)
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
            Button btn = sender as Button;
            menu.Show(btn, new Point(0, btn.Height)); // Show below button
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

                    await LoadStudents(); // Refresh UI
                }
            }
            else
            {
                MessageBox.Show("Invalid curriculum selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void RemoveStudent(object sender, EventArgs e, StudentDocument student)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to remove {student.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = await firestoreService.DeleteStudent(student.StudentID);

                if (isDeleted)
                {
                    MessageBox.Show($"{student.Name} has been removed successfully!", "Student Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadStudents(); // 🔥 Refresh the UI to remove the student
                }
                else
                {
                    MessageBox.Show("Failed to remove student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void flpStudentList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ItemMasterList_btnDetailsClick(object? sender, EventArgs e, StudentDocument student)
        {
            ViewCurriculumDetails(sender, e, student);
        }

        private void ItemMasterList_btnAvailableCoursesClick(object? sender, EventArgs e, StudentDocument student)
        {
            NextAvailableCourses(sender, e, student);
        }

        private void ViewCurriculumDetails(object sender, EventArgs e, StudentDocument student)
        {
            // 🔥 Create new ViewCurriculumDetails UserControl
            ViewCurriculumDetails curriculumDetailsControl = new ViewCurriculumDetails(student);

            // 🔥 Call LoadUserControl() from TestForm to switch screens
            //mainForm.LoadUserControl(curriculumDetailsControl);
            
        }

        private void NextAvailableCourses(object sender, EventArgs e, StudentDocument student)
        {
            // 🔥 Create new ViewCurriculumDetails UserControl
            AdminNextAvailableCourses nextAvailableCoursesControl = new AdminNextAvailableCourses(student);

            // 🔥 Call LoadUserControl() from TestForm to switch screens
            //mainForm.LoadUserControl(nextAvailableCoursesControl);
        }
    }
    
}

