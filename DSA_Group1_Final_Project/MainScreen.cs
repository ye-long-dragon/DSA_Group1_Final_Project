
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using DSA_Group1_Final_Project.Windows.UserControls.General_Screens;
using DSA_Group1_Final_Project.Windows.UserControls.Student;
using DSA_Group1_Final_Project.Classes.Connection;
using System.Runtime.InteropServices;
using DSA_Group1_Final_Project.Windows.AuthScreens;
using System.Threading;


namespace DSA_Group1_Final_Project
{

    public partial class MainScreen : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr one, int two, int three, int four);
        private CancellationTokenSource _cancellationTokenSource;

        private static MainScreen instance;

        // 🔥 Function to Switch Screens (Replaces mainPanel's content)
        public void LoadUserControl(UserControl newControl)
        {
            pnlMain.Controls.Clear(); // Remove existing controls
            newControl.Dock = DockStyle.Fill; // Ensure it fills the entire panel
            pnlMain.Controls.Add(newControl); // Add new UserControl
        }

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        string role;
        public MainScreen(string r)
        {
            InitializeComponent();
            instance = this;
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
        public static MainScreen Instance => instance;

        private void btnDevelopers_Click(object sender, EventArgs e)
        {
            Developers developers = new Developers();
            LoadUserControl(developers);
        }

        private void btnStudentMasterList_Click(object sender, EventArgs e)
        {
            StudentMasterList studentMasterList = new StudentMasterList(MainScreen.Instance);
            LoadUserControl(studentMasterList);
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel the progress task if the form is closing
            _cancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Perform any necessary cleanup before closing
            Authentication.Instance?.Cleanup(); // Call cleanup if needed

            // Optionally, you can confirm the exit with the user
            var confirmResult = MessageBox.Show("Are you sure you want to exit?",
                                                 "Confirm Exit",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close(); // Close the MainScreen
                Application.Exit();
            }
        }

    }
}
