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
    public partial class UpdateApproval : UserControl
    {
        string prevStatus;
        StudentDocument s = new StudentDocument();
        public UpdateApproval(StudentDocument studentDocument)
        {
            InitializeComponent();
            prevStatus = studentDocument.ApprovalStatus;
            name.Text = studentDocument.Name;
            s = studentDocument;

            if (studentDocument.ApprovalStatus == "Approved")
            {
                rbtnApproved.Checked = true;
                rbtnPending.Checked = false;
                
            }
            else if (studentDocument.ApprovalStatus == "Pending")
            {
                rbtnPending.Checked = true;
                rbtnApproved.Checked = false;
                
                
            }

        }

        private void rbtnApproved_CheckedChanged(object sender, EventArgs e)
        {
            s.ApprovalStatus = "Approved";
            
            //add code to update the status in the database
        }


        private void rbtnPending_CheckedChanged(object sender, EventArgs e)
        {
            s.ApprovalStatus = "Pending";
            
            //add code to update the status in the database
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(prevStatus != s.ApprovalStatus)
            {
                MessageBox.Show("Status Updated");
            }
            else
            {
                MessageBox.Show("No changes made");
            }
        }
    }
}
