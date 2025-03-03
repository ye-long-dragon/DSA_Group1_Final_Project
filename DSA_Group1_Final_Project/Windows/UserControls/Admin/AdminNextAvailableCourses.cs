using DSA_Group1_Final_Project.Classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.UserControls.Admin
{
    public partial class AdminNextAvailableCourses : UserControl
    {
        private StudentDocument student; // Store student data

        public AdminNextAvailableCourses(StudentDocument student)
        {
            InitializeComponent();
            this.student = student;

            // Populate labels dynamically
            lblStudentName.Text = $"Name: {student.Name}";
            lblProgram.Text = $"Program: {student.Program}";
            lblCurriculum.Text = $"Curriculum: {student.Curriculum}";
        }
    }
}
