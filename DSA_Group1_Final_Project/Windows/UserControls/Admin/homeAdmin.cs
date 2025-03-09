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
    public partial class homeAdmin : UserControl
    {
        StudentDocument s;
        string r;
        MainScreen mainScreen;
        string userId;
        FirestoreServices firestoreServices = new FirestoreServices();
        public homeAdmin(MainScreen mainScreen, string userId)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.userId = userId;
            LoadUserEmail();
            btnStudentMasterList.Text = "Go To Student Master List";
            string imagePath = Path.Combine(Application.StartupPath, "Pictures", "mmcm_logo.png");
            if (File.Exists(imagePath))
            {
                pcbStudentMasterList.Image = Image.FromFile(imagePath);
            }
            else
            {
                Debug.WriteLine($"[ERROR] Image not found at: {imagePath}");
            }
            

        }

        private async void LoadUserEmail()
        {
            string email = await firestoreServices.GetCurrentUserEmailAsync(userId);
            lblName.Text = email ?? "Admin"; // Handle null case safely
        }

        private void btnStudentMasterList_Click(object sender, EventArgs e)
        {
            StudentMasterList studentMasterList = new StudentMasterList(mainScreen);
            studentMasterList.Dock = DockStyle.Fill;
            mainScreen.LoadUserControl(studentMasterList);
        }
    }
}
