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
    public partial class AdminNextAvailableCourses : UserControl
    {
        private string studentId;
        private FirestoreServices firestoreService = new();
        private StudentDocument student;
        private ComboBox termDropdown;
        private FlowLayoutPanel coursesPanel;
        private Label studentEmailLabel;
        private int selectedTerm = 1; // Default term

        public AdminNextAvailableCourses(StudentDocument student)
        {
            this.student = student;
            InitializeUI();
            LoadStudentData();
        }

        private void InitializeUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // ✅ Container Panel for Vertical Layout
            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // ✅ FlowLayoutPanel for stacking components top-down
            FlowLayoutPanel mainLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };
            //Back Button
            Button btnBack = new Button
            {
                Text = "Back",
                BackColor = Color.White,
                ForeColor = Color.Black,
                AutoSize = true,
                Margin = new Padding(5)
            };
            btnBack.Click += (s, e) => GoBack();

            // ✅ Title Label
            Label titleLabel = new Label
            {
                Text = "Next Available Courses",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true,
                Padding = new Padding(10, 10, 10, 10) // Spacing
            };

            // ✅ Student Email Label
            studentEmailLabel = new Label
            {
                Text = "Fetching Email...",
                Font = new Font("Arial", 10),
                AutoSize = true,
                Padding = new Padding(5)
            };

            // ✅ Term Dropdown (Fixed)
            Label lblTermDropDown = new Label
            {
                Text = "Select Term:",
                Font = new Font("Arial", 10),
                AutoSize = true,
                Padding = new Padding(5)
            };

            termDropdown = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,  // ✅ Set Width instead of Dock
                Margin = new Padding(5, 5, 5, 10),
            };
            termDropdown.Items.AddRange(new object[] { 1, 2, 3 });
            termDropdown.SelectedIndex = 0;
            termDropdown.SelectedIndexChanged += async (s, e) => await LoadAvailableCourses();

            // ✅ Course Panel (FlowLayoutPanel)
            coursesPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                Dock = DockStyle.Fill,
                AutoSize = true,
                MinimumSize = new Size(500, 500)  // ✅ Set a minimum width if needed
            };


            // ✅ Add Components in the Correct Order
            mainLayout.Controls.Add(btnBack);
            mainLayout.Controls.Add(titleLabel);
            mainLayout.Controls.Add(studentEmailLabel);
            mainLayout.Controls.Add(lblTermDropDown);
            mainLayout.Controls.Add(termDropdown);
            mainLayout.Controls.Add(coursesPanel);

            // ✅ Add to Container Panel and to Main Control
            containerPanel.Controls.Add(mainLayout);
            this.Controls.Add(containerPanel);
        }


        private async void LoadStudentData()
        {
            Debug.WriteLine($"AdminNextAvailableCoursesScreen: Fetching student data for Student: {student.Name}");

            if (student != null)
            {
                studentEmailLabel.Text = $"Available Courses for Student: {student.Email}";
                Debug.WriteLine($"AdminNextAvailableCoursesScreen: Completed courses loaded for Student: {student.Name}");
                await LoadAvailableCourses();
            }
            else
            {
                Debug.WriteLine("AdminNextAvailableCoursesScreen: Failed to fetch student data.");
            }
        }

        private async Task LoadAvailableCourses()
        {
            if (student == null)
            {
                Debug.WriteLine("AdminNextAvailableCoursesScreen: Student data not loaded.");
                return;
            }
            selectedTerm = (int)termDropdown.SelectedItem;
            Debug.WriteLine($"AdminNextAvailableCoursesScreen: Fetching available courses for Student ID: {student.Name}, term: {selectedTerm}");

            var availableCourses = await firestoreService.GetAvailableCoursesStudent(student, selectedTerm);

            coursesPanel.Controls.Clear(); // Clear old courses

            if (availableCourses == null || availableCourses.Count == 0)
            {
                Label noCoursesLabel = new Label
                {
                    Text = "No available courses found.",
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Padding = new Padding(10)
                };
                coursesPanel.Controls.Add(noCoursesLabel);
                Debug.WriteLine("AdminNextAvailableCoursesScreen: No available courses found.");
            }
            else
            {   
                Debug.WriteLine($"AdminNextAvailableCoursesScreen: Found {availableCourses.Count} available courses for student {student.Name}");

                foreach (var (course, color) in availableCourses)
                {
                    coursesPanel.Controls.Add(CreateCourseItem(course, color));
                }
            }
        }

        private Panel CreateCourseItem(CourseNode course, string colorCode)
        {
            Panel coursePanel = new Panel
            {
                BackColor = GetColorFromCode(colorCode),
                AutoSize = true,
                Padding = new Padding(10),
                Margin = new Padding(5),
                Width = coursesPanel.Width - 20
            };

            Label courseLabel = new Label
            {
                Text = $"{course.Name} ({course.Code})",
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true
            };
            coursePanel.Controls.Add(courseLabel);

            if (colorCode == "green")
            {
                Button shareButton = new Button
                {
                    Text = "Share",
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Margin = new Padding(5)
                };
                shareButton.Click += (s, e) => CopyToClipboard($"{course.Name} ({course.Code})");
                coursePanel.Controls.Add(shareButton);
            }

            return coursePanel;
        }

        private void CopyToClipboard(string text)
        {
            Clipboard.SetText(text);
            MessageBox.Show($"Copied: {text}", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Color GetColorFromCode(string colorCode)
        {
            return colorCode switch
            {
                "green" => Color.FromArgb(129, 199, 132),
                "orange" => Color.FromArgb(255, 183, 77),
                "blue" => Color.FromArgb(100, 181, 246),
                _ => Color.FromArgb(229, 115, 115) // Default error color
            };
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
