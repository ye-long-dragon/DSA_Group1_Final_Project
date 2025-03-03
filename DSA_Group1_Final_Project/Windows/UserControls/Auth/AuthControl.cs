using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSA_Group1_Final_Project.Windows.AuthScreens;

namespace DSA_Group1_Final_Project.Windows.UserControls.Auth
{
    public partial class AuthControl : UserControl
    {
        public AuthControl()
        {
            InitializeComponent();
            ShowLogin();
        }

        private void ShowLogin()
        {
            LoginControl login = new LoginControl(this.Width, this.Height);
            login.OnRegisterRequested += ShowRegister;
            SwitchControl(login);
        }

        private void ShowRegister()
        {
            RegisterControl register = new RegisterControl(this.Width, this.Height);
            register.OnLoginRequested += ShowLogin;
            SwitchControl(register);
        }

        private void SwitchControl(UserControl newControl)
        {
            this.Controls.Clear();
            this.Controls.Add(newControl);
            newControl.Dock = DockStyle.Fill;
        }
    }
}
