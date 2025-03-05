﻿using DSA_Group1_Final_Project.Classes.Models;
using DSA_Group1_Final_Project.Windows.UserControls.Pop_ups;
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
    public partial class MainPopUpWindow : Form
    {
        public MainPopUpWindow(string s, StudentDocument studentDocument)
        {
            InitializeComponent();

            if (s == "Program")
            {
                UpdateProgram updateProgram = new UpdateProgram(studentDocument);
                updateProgram.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(updateProgram);
            }
            else if (s == "Status")
            {
                UpdateApproval updateStatus = new UpdateApproval(studentDocument);  
                updateStatus.Dock = DockStyle.Fill;
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(updateStatus);
            }
            else if (s == "Curriculum")
            {
                UpdateCurriculum updateCurriculum = new UpdateCurriculum(studentDocument);
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
    }
}
