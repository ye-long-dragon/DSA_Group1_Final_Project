using DSA_Group1_Final_Project.Classes;
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
        private ProgressBar progressBar;

        public ViewCurriculumDetails(StudentDocument student)
        {
            InitializeComponent();
            this.student = student;
            this.firestoreService = new FirestoreServices();

            // 🔥 Setup UI dynamically
            InitializeUI();
            LoadCurriculum();
        }

        private void InitializeUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = MMCMColors.White; // Set background color

            // 🔹 Top Bar (MMCM Blue)
            Panel topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = MMCMColors.Blue
            };
            this.Controls.Add(topBar);

            // 🔹 Title Label (Inside Top Bar)
            Label lblTitle = new Label
            {
                Text = "Curriculum Overview",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = MMCMColors.White, // White text
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            topBar.Controls.Add(lblTitle);

            // 🔹 Container Panel (Ensures Proper Layout)
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // 🔹 Label for Student Information
            lblStudentInfo.Text = $"Showing Curriculum Checklist for Student: {student.Name}";
            lblStudentInfo.Font = new Font("Arial", 14, FontStyle.Italic);
            lblStudentInfo.ForeColor = MMCMColors.Red;
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Padding = new Padding(5);


            // 🔹 TableLayoutPanel for Courses (Centered & Starts AFTER Label)
            tableCourses = new TableLayoutPanel
            {
                AutoScroll = true,
                ColumnCount = 2,
                Padding = new Padding(10),
                Margin = new Padding(0, 10, 0, 0), // ✅ Ensure No Extra Margin
                AutoSize = true,
                MaximumSize = new Size(1500, 0)

            };


            // ✅ Ensure column styles are set BEFORE adding controls
            tableCourses.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // 🔹 First Column (Course Name)
            tableCourses.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // 🔹 Second Column (Checkbox)



            // 🔹 Progress Bar (Centered)
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Width = 500,
                Height = 30,
                Visible = true
            };

            // 🔹 Panel to Center Progress Bar

            progressBar.Anchor = AnchorStyles.Top;
            progressBar.Location = new Point((contentPanel.Width - progressBar.Width) / 2, 100); // ✅ Centered

            // 🔹 Add Components to Content Panel (ENSURE PROPER ORDER)
            // Manually position the label
            lblStudentInfo.Location = new Point(20, 60); // X = 20, Y = 20
            contentPanel.Controls.Add(lblStudentInfo);

            // Position the loading
            contentPanel.Controls.Add(progressBar);

            // Position the tableCourses below the loading panel
            tableCourses.Location = new Point(20, 100);
            contentPanel.Controls.Add(tableCourses);

            // 🔹 Back Button (Fixed at Bottom)
            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = MMCMColors.Red,
                ForeColor = MMCMColors.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => GoBack();

            // 🔹 Add Components to Form
            this.Controls.Add(contentPanel);
            this.Controls.Add(btnBack);
        }


        private async void LoadCurriculum()
        {
            progressBar.Visible = true; // ✅ Show progress indicator
            tableCourses.Visible = false; // ✅ Hide table until loaded

            var courseData = await firestoreService.GetCurriculumCourses(student.Curriculum);

            if (courseData == null)
            {
                Debug.WriteLine("Failed to fetch curriculum data.");
                progressBar.Visible = false;
                return;
            }

            var completedCourses = new HashSet<string>(student.CompletedCourses); // ✅ HashSet for fast lookup

            // ✅ Run UI updates in the background
            await Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    tableCourses.SuspendLayout(); // ✅ Freeze layout updates for performance
                    tableCourses.Controls.Clear();
                    tableCourses.RowStyles.Clear();
                    tableCourses.ColumnCount = 2;
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
                            Font = new Font("Arial", 18, FontStyle.Bold),
                            ForeColor = MMCMColors.Blue,
                            Anchor = AnchorStyles.Left,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };
                        tableCourses.Controls.Add(lblYear, 0, row++);

                        // 🔹 Loop through Terms
                        foreach (var (term, courses) in terms)
                        {
                            Label lblTerm = new Label
                            {
                                Text = $"Term {term}",
                                Font = new Font("Arial", 15, FontStyle.Bold),
                                ForeColor = MMCMColors.Red,
                                Anchor = AnchorStyles.Left,
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
                            Font = new Font("Arial", 18, FontStyle.Bold),
                            ForeColor = MMCMColors.Blue,
                            Anchor = AnchorStyles.Left,
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

                    tableCourses.ResumeLayout(); // ✅ Resume layout updates for performance
                    tableCourses.BringToFront();
                    tableCourses.Visible = true; // ✅ Show courses after everything is added
                    progressBar.Visible = false; // ✅ Hide progress bar when done
                }));
            });
        }





        // 🔥 Helper Method to Add a Course Row (Handles Regular & Elective Courses)
        private void AddCourseRow(CourseNode course, HashSet<string> completedCourses, ref int row)
        {
            Label lblCourse = new Label
            {
                Text = course.Name,
                Font = new Font("Arial", 13),
                AutoSize = true,
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
