using DSA_Group1_Final_Project.Classes.DLLs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Group1_Final_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashTable hash = new HashTable(10);
            hash.insertElement(9, "CS100L");
            hash.insertElement(1, "CPE001L");
            hash.insertElement(5, "CPE141L");

            MessageBox.Show(hash.returnElement(9));

            hash.deleteElement(9);

            MessageBox.Show(hash.returnElement(9));
        }
    }
}
