
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using DSA_Group1_Final_Project.Windows.UserControls.General_Screens;
using DSA_Group1_Final_Project.Windows.UserControls.Student;
using DSA_Group1_Final_Project.Classes.Connection;
using System.Runtime.InteropServices;
using DSA_Group1_Final_Project.Windows.AuthScreens;
using System.Threading;
using DSA_Group1_Final_Project.Classes.Models;


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
        string userId;

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


        string r;
        FirestoreServices db = new FirestoreServices();
        StudentDocument student = new StudentDocument();
        StudentDocument studentLive = new StudentDocument();
        public MainScreen(string role, string userId)
        {
            InitializeComponent();
            instance = this;
            this.userId = userId;
            r = role;
            student = db.GetCurrentStudentAsync(userId).Result;

            // real-time listener for approvalStatus
            db.ListenForStudentStatusChanges(userId, studentData =>
            {
                studentLive = studentData;

                // Refresh UI when approval status updates
                this.Invoke((MethodInvoker)delegate
                {
                    RefreshUI();//bugged
                });
            });

            if (role == "Admin")
            {
                btnAvailableCourses.Visible = false;
                btnCourseList.Visible = false;
                lblScreenView.Text = "Admin Dashboard";

                btnStudentMasterList.Location = new Point(0, 205 + 56);

                btnDevelopers.Location = new Point(0, 251 + 56);
                lblSettings.Location = new Point(3, 306 + 56);
                btnProfile.Location = new Point(0, 338 + 56);
                btnSettings.Location = new Point(0, 384 + 56);
                btnLogout.Location = new Point(0, 430 + 56);

                homeAdmin homeAdmin = new homeAdmin(instance, userId);
                homeAdmin.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(homeAdmin);
            }
            else
            {
                lblScreenView.Text = "Student Dashboard";
                btnSettings.Text = "Settings";

                btnStudentMasterList.Visible = false;

                btnAvailableCourses.Location = new Point(0, 204 + 56);
                btnCourseList.Location = new Point(0, 250 + 56);
                btnDevelopers.Location = new Point(0, 296 + 56);
                lblSettings.Location = new Point(3, 351 + 56);
                btnProfile.Location = new Point(0, 382 + 56);
                btnSettings.Location = new Point(0, 428 + 56);
                btnLogout.Location = new Point(0, 474 + 56);

                homeStudent homeStudent = new homeStudent(instance, student, r);
                homeStudent.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(homeStudent);
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
            if (studentLive.ApprovalStatus == "pending")
            {
                LoadUserControl(new StudentPending());
            }
            else
            {
                // actual Course List screen
                StudentCurriculum courseList = new StudentCurriculum(studentLive, "Student");
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(courseList);
            }
        }

        private void btnAvailableCourses_Click(object sender, EventArgs e)
        {
            if (studentLive.ApprovalStatus == "pending")
            {
                LoadUserControl(new StudentPending());
            }
            else
            {
                //  actual Available Courses screen
                AdminNextAvailableCourses adminNextAvailableCourses = new AdminNextAvailableCourses(studentLive, "");
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(adminNextAvailableCourses);
            }
        }
        private void RefreshUI()
        {
            if (studentLive.ApprovalStatus == "pending")
            {
                LoadUserControl(new StudentPending());
            }
            else
            {
                LoadUserControl(new homeStudent(instance, student, r));
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.Show();
            // 🔹 Clear saved session
            Properties.Settings.Default.UserId = "";
            Properties.Settings.Default.Save();
            db.StopListening();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (r == "Admin")
            {
                homeAdmin homeAdmin = new homeAdmin(instance, userId);
                homeAdmin.Dock = DockStyle.Fill;
                instance.LoadUserControl(homeAdmin);
            }
            else
            {
                homeStudent homeStudent = new homeStudent(instance, student, r);
                homeStudent.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(homeStudent);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This functionality is under construction.");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This functionality is under construction.");
        }
    }
}
