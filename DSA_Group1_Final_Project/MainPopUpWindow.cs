using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;
using DSA_Group1_Final_Project.Windows.UserControls.Pop_ups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.Pop_ups
{
    public partial class MainPopUpWindow : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr one, int two, int three, int four);

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        private CancellationTokenSource _cancellationTokenSource;
        public MainPopUpWindow(string s, StudentDocument studentDocument, StudentMasterList parentUserControl)
        {
            InitializeComponent();

            if (s == "Program")
            {
                UpdateProgram updateProgram = new UpdateProgram(studentDocument, parentUserControl);
                updateProgram.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(updateProgram);
            }
            else if (s == "Status")
            {
                UpdateApproval updateStatus = new UpdateApproval(studentDocument, parentUserControl);
                updateStatus.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(updateStatus);
            }
            else if (s == "Curriculum")
            {
                UpdateCurriculum updateCurriculum = new UpdateCurriculum(studentDocument, parentUserControl);
                updateCurriculum.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(updateCurriculum);
            }
            else if (s == "Remove")
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ----------------- TO REMOVE BACKGROUND APPLICATION WHEN CLOSING-----------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel the progress task if the form is closing
            _cancellationTokenSource?.Cancel();
            base.OnFormClosing(e);
        }

        
        // ----------------- TO REMOVE BACKGROUND APPLICATION WHEN CLOSING-----------------
    }
}
