﻿
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using DSA_Group1_Final_Project.Windows.UserControls.General_Screens;
using DSA_Group1_Final_Project.Windows.UserControls.Student;
using DSA_Group1_Final_Project.Classes.Connection;
using System.Runtime.InteropServices;
using DSA_Group1_Final_Project.Windows.AuthScreens;


namespace DSA_Group1_Final_Project
{
    public partial class MainScreen : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr one, int two, int three, int four);


        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        string role;
        public MainScreen(string r)
        {
            InitializeComponent();
            role = r;

            if (role == "Admin")
            {
                btnAvailableCourses.Visible = false;
                btnCourseList.Visible = false;
                lblScreenView.Text = "Admin Dashboard";

                btnStudentMasterList.Location = new Point(0, 335);
                btnManageCurriculums.Location = new Point(0, 335+62);
                btnDevelopers.Location = new Point(0, 397+62);
                lblSettings.Location = new Point(6, 481 + 62);
                btnProfile.Location = new Point(0, 531 + 62);
                btnSettings.Location = new Point(0, 593 + 62);
                btnLogout.Location = new Point(0, 655 + 62);
            }
            else
            {
                lblScreenView.Text = "Student Dashboard";
                btnSettings.Text = "Settings";
                btnManageCurriculums.Visible = false;
                btnStudentMasterList.Visible = false;

                btnAvailableCourses.Location = new Point(0, 273);
                btnCourseList.Location = new Point(0, 335);
                btnDevelopers.Location = new Point(0, 397);
                lblSettings.Location = new Point(6, 481);
                btnProfile.Location = new Point(0, 531);
                btnSettings.Location = new Point(0, 593);
                btnLogout.Location = new Point(0, 655);
            }

        }

        private void btnDevelopers_Click(object sender, EventArgs e)
        {
            Developers developers = new Developers();
            developers.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(developers);
        }

        private void btnStudentMasterList_Click(object sender, EventArgs e)
        {
            StudentMasterList studentMasterList = new StudentMasterList();
            studentMasterList.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(studentMasterList);
        }

        private void btnCourseList_Click_1(object sender, EventArgs e)
        {
            CourseList courseList = new CourseList();
            courseList.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(courseList);
        }

        private void btnAvailableCourses_Click(object sender, EventArgs e)
        {
            //AvailableCourses availableCourses = new AvailableCourses();
            //availableCourses.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            //pnlMain.Controls.Add(availableCourses);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.Show();
            // 🔹 Clear saved session
            Properties.Settings.Default.UserId = "";
            Properties.Settings.Default.Save();

            AuthForm authForm = new AuthForm();
            authForm.Show(); // Show the AuthForm

            this.Close();
        }
        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {

            Authentication.Instance?.Cleanup(); // Call cleanup before exiting

            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
