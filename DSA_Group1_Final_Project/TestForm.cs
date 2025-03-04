using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Windows.UserControls.Admin;

namespace DSA_Group1_Final_Project
{
    public partial class TestForm : Form
    {
        private Panel mainPanel; // 🔥 Panel for dynamic UserControl loading
        public TestForm()
        {
            InitializeComponent();

            // 🔥 Initialize mainPanel
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill // Fill entire form
            };

            this.Controls.Add(mainPanel); // Add mainPanel to form

            // 🔥 Initialize and add StudentMasterList to mainPanel
            StudentMasterList studentMasterList = new StudentMasterList(); // Pass TestForm reference
            studentMasterList.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(studentMasterList); // Add to mainPanel
        }

        // 🔥 Function to Switch Screens (Replaces mainPanel's content)
        public void LoadUserControl(UserControl newControl)
        {
            mainPanel.Controls.Clear(); // Remove existing controls
            newControl.Dock = DockStyle.Fill; // Ensure it fills the entire panel
            mainPanel.Controls.Add(newControl); // Add new UserControl
        }
    }
}
