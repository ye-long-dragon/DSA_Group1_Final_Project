﻿using DSA_Group1_Final_Project.Classes.DLLs;
using DSA_Group1_Final_Project.Windows.AuthScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    public partial class Login : Form
    {
        public Login()
        {
            //InitializeComponent();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
           // Register registerForm = new Register();
            //registerForm.Show();
            this.Hide(); // Hide login form
        }
    }
}
