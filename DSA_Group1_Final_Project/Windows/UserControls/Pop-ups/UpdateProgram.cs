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

namespace DSA_Group1_Final_Project.Windows.Pop_ups
{
    public partial class UpdateProgram : UserControl
    {
        string prevProgram;
        public UpdateProgram(StudentDocument studentDocument)
        {
            InitializeComponent();
            prevProgram = studentDocument.Program;
            Dictionary<string, int> curriculumMapping = new Dictionary<string, int>
                {
                    { "BS Computer Engineering" ,1 },
                    { "BS Electrical Engineering", 2 },
                    {"BS Electronics and Communications Engineering" , 3 },

                };

            string[] programs = { "BS Computer Engineering", "BS Electrical Engineering", "BS Electronics and Communications Engineering" };

            cmbProgram.Items.Clear();
            // 🔹 Populate ComboBox with Curriculum
            foreach (var item in programs)
            {
                cmbProgram.Items.Add(item);
            }
            name.Text = "Student: " + studentDocument.Name;
            cmbProgram.SelectedIndex = curriculumMapping[studentDocument.Program] - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(prevProgram== cmbProgram.SelectedItem.ToString())
            {
                MessageBox.Show("No changes made");
            }
            else
            {
                MessageBox.Show("Program Updated");
            }
        }
    }
}
