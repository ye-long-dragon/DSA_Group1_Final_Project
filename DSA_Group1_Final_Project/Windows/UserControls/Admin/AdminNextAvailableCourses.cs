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
            this.BackColor = MMCMColors.White;

            // 🔹 Top Bar (MMCM Blue)
            Panel topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = MMCMColors.Blue
            };
            this.Controls.Add(topBar);

            // 🔹 Title Label (Inside Top Bar)
            Label titleLabel = new Label
            {
                Text = "Next Available Courses",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = MMCMColors.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            topBar.Controls.Add(titleLabel);

            // 🔹 Main Container Panel (Fixed Layout)
            Panel containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 60, 10, 10), // ✅ Prevents overlap with top bar
                AutoScroll = false // ✅ Disable to avoid double scrollbars
            };

            // 🔹 FlowLayoutPanel for Layout Management
            FlowLayoutPanel mainLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Margin = new Padding(30),
                AutoScroll = true // ✅ Only this panel should have scrolling
            };

            // 🔹 Student Email Label
            studentEmailLabel = new Label
            {
                Text = "Fetching Email...",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = MMCMColors.Red,
                AutoSize = true,
                Padding = new Padding(5)
            };

            // 🔹 Term Dropdown Label
            Label lblTermDropDown = new Label
            {
                Text = "Select Term:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = MMCMColors.Black,
                AutoSize = true,
                Padding = new Padding(5)
            };

            // 🔹 Term Dropdown (Dropdown Selection)
            termDropdown = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150,
                Margin = new Padding(5, 5, 5, 10),
            };
            termDropdown.Items.AddRange(new object[] { 1, 2, 3 });
            termDropdown.SelectedIndex = 0;
            termDropdown.SelectedIndexChanged += async (s, e) => await LoadAvailableCourses();

            // 🔹 Course Panel (Fixed Width)
            coursesPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                Dock = DockStyle.Fill,
                AutoSize = true,
                MaximumSize = new Size(1200, 0), 
            };

            // 🔹 Add Components to Main Layout
            mainLayout.Controls.Add(studentEmailLabel);
            mainLayout.Controls.Add(lblTermDropDown);
            mainLayout.Controls.Add(termDropdown);
            mainLayout.Controls.Add(coursesPanel);

            // 🔹 Back Button (Fixed at Bottom)
            Button btnBack = new Button
            {
                Text = "Back",
                BackColor = MMCMColors.Red,
                ForeColor = MMCMColors.White,
                Height = 50,
                Dock = DockStyle.Bottom, // ✅ Now stays fixed at bottom
                FlatStyle = FlatStyle.Flat
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => GoBack();

            // 🔹 Add to Container Panel and Main Control
            containerPanel.Controls.Add(mainLayout);
            this.Controls.Add(containerPanel);
            this.Controls.Add(btnBack); // ✅ Back button is now outside scrolling area
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
                Padding = new Padding(15, 15, 15, 15),
                Margin = new Padding(5,5,5,5),
                Width = coursesPanel.Width - 20
            };

            Label courseLabel = new Label
            {
                Text = $"{course.Name} ({course.Code})",
                ForeColor = MMCMColors.White,
                Font = new Font("Poppins", 13, FontStyle.Bold),
                AutoSize = true
            };
            coursePanel.Controls.Add(courseLabel);

            if (colorCode == "green")
            {
                Button shareButton = new Button
                {
                    Text = "Share",
                    BackColor = MMCMColors.White,
                    ForeColor = MMCMColors.Black,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = true,

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
