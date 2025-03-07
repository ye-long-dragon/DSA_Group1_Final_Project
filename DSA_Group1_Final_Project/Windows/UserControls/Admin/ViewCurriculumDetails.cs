using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Classes.Models;
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

namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    public partial class ViewCurriculumDetails : UserControl
    {
        private StudentDocument student;
        private FirestoreServices firestoreService;
        private TableLayoutPanel tableCourses = new TableLayoutPanel(); // 🔹 Initialize here

        public ViewCurriculumDetails(StudentDocument student)
        {
            InitializeComponent();
            this.student = student;
            this.firestoreService = new FirestoreServices();

            // Use student.CompletedCourses directly instead of calling Firestore

            // 🔥 Setup UI dynamically
            InitializeUI();
            LoadCurriculum();
        }

        private void InitializeUI()
        {
            this.Dock = DockStyle.Fill;

            // 🔹 Title Label
            Label lblTitle = new Label
            {
                Text = "Curriculum Overview",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };
            this.Controls.Add(lblTitle);

            // 🔹 TableLayoutPanel for Courses
            tableCourses = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoScroll = true
            };
            this.Controls.Add(tableCourses);

            // 🔹 Back Button
            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnBack.Click += (s, e) => GoBack();
            this.Controls.Add(btnBack);
        }

        private async void LoadCurriculum()
        {
            var courseData = await firestoreService.GetCurriculumCourses(student.Curriculum);

            if (courseData == null)
            {
                Debug.WriteLine("Failed to fetch curriculum data.");
                return;
            }

            Debug.WriteLine("Course Data:");
            foreach (var (year, terms) in courseData.groupedCourses)
            {
                Debug.WriteLine($"Year {year}");
                foreach (var (term, courses) in terms)
                {
                    Debug.WriteLine($"  Term {term}");
                    foreach (var course in courses)
                    {
                        Debug.WriteLine($"    {course.Code} - {course.Name}");
                    }
                }
            }

            // 🔹 Print Electives
            if (courseData.electives.Any())
            {
                Debug.WriteLine("Elective Courses:");
                foreach (var elective in courseData.electives)
                {
                    Debug.WriteLine($"  {elective.Code} - {elective.Name}");
                }
            }
            else { 
                Debug.WriteLine("No Elective Courses"); 
            }

            var completedCourses = new HashSet<string>(student.CompletedCourses); // Convert to HashSet for fast lookup

            // Reset table layout to avoid old data stacking
            tableCourses.Controls.Clear();
            tableCourses.RowStyles.Clear();
            tableCourses.ColumnCount = 2; // One for course name, one for checkbox
            tableCourses.AutoSize = true;
            tableCourses.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableCourses.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            int row = 0;

            // 🔹 Loop through Years
            foreach (var (year, terms) in courseData.groupedCourses)
            {
                Label lblYear = new Label
                {
                    Text = $"Year {year}",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Blue,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Padding = new Padding(10)
                };
                tableCourses.Controls.Add(lblYear, 0, row++);

                // 🔹 Loop through Terms
                foreach (var (term, courses) in terms)
                {
                    Label lblTerm = new Label
                    {
                        Text = $"Term {term}",
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.Red,
                        Dock = DockStyle.Top,
                        AutoSize = true,
                        Padding = new Padding(5)
                    };
                    tableCourses.Controls.Add(lblTerm, 0, row++);
                    tableCourses.SetColumnSpan(lblTerm, 2);

                    // 🔹 Loop through Courses
                    foreach (var course in courses)
                    {
                        AddCourseRow(course, completedCourses, ref row);
                    }
                }
            }

            // 🔹 Display Electives
            if (courseData.electives.Any())
            {
                Label lblElectives = new Label
                {
                    Text = "Elective Courses",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.DarkGreen,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Padding = new Padding(10)
                };
                tableCourses.Controls.Add(lblElectives, 0, row++);
                tableCourses.SetColumnSpan(lblElectives, 2);

                foreach (var elective in courseData.electives)
                {
                    AddCourseRow(elective, completedCourses, ref row);
                }
            }
        }

        // 🔥 Helper Method to Add a Course Row (Handles Regular & Elective Courses)
        private void AddCourseRow(CourseNode course, HashSet<string> completedCourses, ref int row)
        {
            Label lblCourse = new Label
            {
                Text = course.Name,
                AutoSize = true,
                MaximumSize = new Size(400, 0), // Restrict width, allow multiline
                Padding = new Padding(5),
                TextAlign = ContentAlignment.MiddleLeft
            };

            CheckBox chkCourse = new CheckBox
            {
                AutoSize = true,
                Padding = new Padding(5),
                Checked = completedCourses.Contains(course.Code), // ✅ Check if course is completed
                Dock = DockStyle.Left
            };

            chkCourse.CheckedChanged += async (s, e) =>
            {
                await firestoreService.UpdateCompletedCourses(student.StudentID, course.Code, chkCourse.Checked);
            };

            tableCourses.Controls.Add(lblCourse, 0, row); // Add Label to first column
            tableCourses.Controls.Add(chkCourse, 1, row); // Add Checkbox to second column
            row++; // Move to next row
        }


        // 🔹 Go back to previous screen
        private void GoBack()
        {
            // Find the parent form and cast it to TestForm
            MainScreen mainScreen = this.FindForm() as MainScreen;

            if (mainScreen != null) // ✅ Ensure the form is found
            {
                // 🔹 Switch back to StudentMasterList and pass `parentForm`
                mainScreen.LoadUserControl(new StudentMasterList(mainScreen));
            }
            else
            {
                Debug.WriteLine("❌ Parent form not found. Cannot go back.");
            }
        }
    }



}
