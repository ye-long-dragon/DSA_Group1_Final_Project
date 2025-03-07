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

namespace DSA_Group1_Final_Project.Windows.UserControls.Pop_ups
{
    public partial class UpdateCurriculum : UserControl
    {
        private FirestoreServices firestoreService = new FirestoreServices();
        int prevCurriculum,newCurriculum;
        StudentDocument s = new StudentDocument();
        public UpdateCurriculum(StudentDocument studentDocument)
        {
            InitializeComponent();
            string[] curriculums = {
                "BS Computer Engineering 2022-2023",
                "BS Electrical Engineering 2024-2025",
                "BS Computer Engineering 2021-2022",
                "BS Electronics and Communications Engineering 2022-2023"
            };
            prevCurriculum = Convert.ToInt32(studentDocument.Curriculum); // must be number

            s = studentDocument;

            cmbCurriculum.Items.Clear();
            foreach (var item in curriculums)
            {
                cmbCurriculum.Items.Add(item);
            }

            name.Text = studentDocument.Name;
            cmbCurriculum.SelectedIndex = Convert.ToInt32(studentDocument.Curriculum) - 1; // must be number


        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurriculum.SelectedIndex == 0)
            {
                newCurriculum = 1;
            }
            else if (cmbCurriculum.SelectedIndex == 1)
            {
                newCurriculum = 2;
            }
            else if (cmbCurriculum.SelectedIndex == 2)
            {
                newCurriculum = 3;
            }
            else if (cmbCurriculum.SelectedIndex == 3)
            {
                newCurriculum = 4;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (prevCurriculum == cmbCurriculum.SelectedIndex + 1)
            {
                MessageBox.Show("No changes made");
            }
            else
            {
                await firestoreService.UpdateStudentField(s.StudentID, "curriculum", Convert.ToString(newCurriculum));
                MessageBox.Show($"{s.Name}'s curriculum updated to {Convert.ToString(newCurriculum)}.", "Success");
                MessageBox.Show("Curriculum Updated");// add code to update the curriculum in the database
                
            }
        }
    }
}
