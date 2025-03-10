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
        MainScreen mainScreen;
        public homeStudent(MainScreen mainScreen, StudentDocument student, string role)
        {
            InitializeComponent();
            lblName.Text = student.Name;
            this.mainScreen = mainScreen;
            r = role;
            s = student;
        }

        private void btnAvailableCourses_Click(object sender, EventArgs e)
        {
            AdminNextAvailableCourses adminNextAvailableCourses = new AdminNextAvailableCourses(s, r);
            adminNextAvailableCourses.Dock = DockStyle.Fill;
            mainScreen.LoadUserControl(adminNextAvailableCourses);//bugged


        }

        private void btnCouseList_Click(object sender, EventArgs e)
        {
            StudentCurriculum studentCurriculum = new StudentCurriculum(s,r);
            studentCurriculum.Dock = DockStyle.Fill;
            mainScreen.LoadUserControl(studentCurriculum);//bugged
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
