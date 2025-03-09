
using DSA_Group1_Final_Project.Classes;
using DSA_Group1_Final_Project.Classes.Connection;
using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using DSA_Group1_Final_Project.Windows.UserControls.Student;
using System.Diagnostics;

namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    public partial class StudentCurriculum : UserControl
    {
        private StudentDocument student;
        private FirestoreServices firestoreService;
        private TableLayoutPanel tableCourses = new TableLayoutPanel(); // 🔹 Initialize here
        private ProgressBar progressBar;
        string r;

        public StudentCurriculum(StudentDocument student, string role)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.student = student;
            this.firestoreService = new FirestoreServices();
            r = role;

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

            var curriculumName =  FirestoreServices.GetCurriculumString(student.Curriculum);

            // 🔹 Title Label (Inside Top Bar)
            Label lblTitle = new Label
            {
                Text = $"Curriculum Overview: {curriculumName}", // replace this with the curriculum name
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
            lblStudentInfo.Text = $"Student: {student.Name}";
            lblStudentInfo.Font = new Font("Arial", 14, FontStyle.Italic);
            lblStudentInfo.ForeColor = MMCMColors.Red;
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Padding = new Padding(5);


            tableCourses = new TableLayoutPanel
             {
                    AutoScroll = false,
                    ColumnCount = 1,
                    Padding = new Padding(10),
                    Margin = new Padding(0, 10, 0, 0), // ✅ Ensure No Extra Margin
                    AutoSize = true,
                    MaximumSize = new Size(1500, 0)
             };
            
             tableCourses.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // 🔹 First Column (Course Name)                

            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Width = 500,
                Height = 30,
                Visible = true
            };

            progressBar.Anchor = AnchorStyles.Top;
            progressBar.Location = new Point((contentPanel.Width - progressBar.Width) / 2, 100);

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

            this.Controls.Add(contentPanel);
            this.Controls.Add(btnBack);
        }


        private async void LoadCurriculum()
        {
            progressBar.Visible = true;
            tableCourses.Visible = false;

            var courseData = await firestoreService.GetCurriculumCourses(student.Curriculum);

            if (courseData == null)
            {
                Debug.WriteLine("Failed to fetch curriculum data.");
                progressBar.Visible = false;
                return;
            }

            var completedCourses = new HashSet<string>(student.CompletedCourses); // ✅ HashSet for fast lookup

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
                        bool allYearCompleted = terms.All(term => term.Value.All(course => completedCourses.Contains(course.Code)));

                        Label lblYear = new Label
                        {
                            Text = $"Year {year}",
                            Font = new Font("Arial", 18, FontStyle.Bold),
                            ForeColor = allYearCompleted ? Color.Green : Color.Black, // ✅ Green if all courses are completed
                            Anchor = AnchorStyles.Left,
                            AutoSize = true,
                            Padding = new Padding(5)
                        };
                        tableCourses.Controls.Add(lblYear, 0, row++);

                        // 🔹 Loop through Terms
                        foreach (var (term, courses) in terms)
                        {
                            bool allTermCompleted = courses.All(course => completedCourses.Contains(course.Code));

                            Label lblTerm = new Label
                            {
                                Text = $"Term {term}",
                                Font = new Font("Arial", 15, FontStyle.Bold),
                                ForeColor = allTermCompleted ? Color.Green : Color.Black, // ✅ Green if all term courses are completed
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
            bool isCompleted = completedCourses.Contains(course.Code);

            // Panel to act as a "Card"
            Panel courseCard = new Panel
            {
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None, // No border for the main card
                Padding = new Padding(10),
                Margin = new Padding(5),
                Size = new Size(1200, 100), // Set a fixed size for all cards
                MinimumSize = new Size(200, 100)
            };

            // Add shadow effect
            courseCard.Paint += (s, e) =>
            {
                // Draw shadow
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)),
                    new Rectangle(5, 5, courseCard.Width, courseCard.Height));

                // Draw border
                ControlPaint.DrawBorder(e.Graphics, courseCard.ClientRectangle,
                    Color.Gray, 2, ButtonBorderStyle.Solid, // Left border
                    Color.Gray, 2, ButtonBorderStyle.Solid, // Top border
                    Color.DarkGray, 4, ButtonBorderStyle.Solid, // Right border
                    Color.DarkGray, 4, ButtonBorderStyle.Solid); // Bottom border
            };

            // Course Name Label
            Label lblCourse = new Label
            {
                Text = isCompleted ? $"{course.Name} (Completed)" : course.Name, // ✅ Add "Completed" text
                Font = new Font("Arial", 13, FontStyle.Bold),
                AutoSize = true,
                ForeColor = isCompleted ? Color.Green : Color.Black
            };

            // Course Code Label
            Label lblCode = new Label
            {
                Text = $"Code: {course.Code}",
                Font = new Font("Arial", 12, FontStyle.Italic),
                AutoSize = true,
                ForeColor = Color.DarkGray
            };

            // Course Unit Label
            Label lblUnit = new Label
            {
                Text = $"Units: {course.Units}",
                Font = new Font("Arial", 12),
                AutoSize = true,
                ForeColor = Color.DarkGray
            };

            // Add labels to the card
            courseCard.Controls.Add(lblCourse);
            courseCard.Controls.Add(lblCode);
            courseCard.Controls.Add(lblUnit);

            // Arrange labels in vertical layout
            lblCourse.Location = new Point(10, 10);
            lblCode.Location = new Point(10, lblCourse.Bottom);
            lblUnit.Location = new Point(10, lblCode.Bottom);

            // Add card to the table
            tableCourses.Controls.Add(courseCard, 0, row);
            tableCourses.SetColumnSpan(courseCard, 2);

            row++; // Move to next row
        }


        private void GoBack()
        {
            // Find the parent form and cast it to TestForm
            MainScreen mainScreen = this.FindForm() as MainScreen;

            if (mainScreen != null) // ✅ Ensure the form is found
            {
                if (r == "Admin")
                { // 🔹 Switch back to StudentMasterList and pass `parentForm`
                    mainScreen.LoadUserControl(new StudentMasterList(mainScreen));
                }
                else
                {
                    mainScreen.LoadUserControl(new homeStudent(student, r));
                }
            }
            else
            {
                Debug.WriteLine("❌ Parent form not found. Cannot go back.");
            }
        }
    }
}   