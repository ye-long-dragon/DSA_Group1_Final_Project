using DSA_Group1_Final_Project.Classes.Connection;
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

namespace DSA_Group1_Final_Project.Windows.UserControls.Pop_ups
{    
    public partial class UpdateApproval : UserControl
    {
        private FirestoreServices firestoreService = new FirestoreServices();
        string prevStatus;
        StudentDocument s = new StudentDocument();
        StudentMasterList parentUserControl;

        public UpdateApproval(StudentDocument studentDocument, StudentMasterList parentUserControl)
        {
            InitializeComponent();
            prevStatus = studentDocument.ApprovalStatus;
            name.Text = studentDocument.Name;
            s = studentDocument;
            this.parentUserControl = parentUserControl;


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
            s.ApprovalStatus = "approved";
            
            //add code to update the status in the database
        }


        private void rbtnPending_CheckedChanged(object sender, EventArgs e)
        {
            s.ApprovalStatus = "pending";
            
            //add code to update the status in the database
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if(prevStatus != s.ApprovalStatus)
            {
                await firestoreService.UpdateStudentField(s.StudentID, "approvalStatus", s.ApprovalStatus);
                MessageBox.Show($"{s.Name}'s approval status updated to {s.ApprovalStatus}.", "Success");
                await parentUserControl.LoadStudents();
                this.ParentForm?.Close();
            }
            else
            {
                MessageBox.Show("No changes made");
            }
        }
    }
}
