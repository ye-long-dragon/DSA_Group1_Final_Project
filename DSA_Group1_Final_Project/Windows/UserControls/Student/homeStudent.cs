using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.UserControls.Student
{
    public partial class homeStudent : UserControl
    {
        string r;
        StudentDocument s;
        public homeStudent(StudentDocument student, string role)
        {
            InitializeComponent();
            lblName.Text = student.Name;
            r = role;
            s = student;
        }

        private void btnAvailableCourses_Click(object sender, EventArgs e)
        {
            AdminNextAvailableCourses adminNextAvailableCourses = new AdminNextAvailableCourses(s, r);
            adminNextAvailableCourses.Dock = DockStyle.Fill;
            MainScreen mainScreen = (MainScreen)Parent.Parent.Parent.Parent;
            mainScreen.LoadUserControl(adminNextAvailableCourses);//bugged


        }

        private void btnCouseList_Click(object sender, EventArgs e)
        {
            ViewCurriculumDetails viewCurriculumDetails = new ViewCurriculumDetails(s, r);
            viewCurriculumDetails.Dock = DockStyle.Fill;
            MainScreen mainScreen = (MainScreen)Parent.Parent.Parent.Parent;
            mainScreen.LoadUserControl(viewCurriculumDetails);//bugged
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
