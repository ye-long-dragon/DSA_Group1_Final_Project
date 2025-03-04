using DSA_Group1_Final_Project.Classes.Connection;
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
        private FirestoreServices firestoreServices;
        private CourseGraph courseGraph;

        private ComboBox termDropdown;
        private ListBox availableCoursesListBox;
        private Label studentEmailLabel;
        private int selectedTerm = 1; // Default term

        public AdminNextAvailableCourses(StudentDocument student)
        {
            InitializeComponent();
            this.student = student;
            this.firestoreServices = new FirestoreServices();
            //this.courseGraph = new CourseGraph();

        }
    }
}
