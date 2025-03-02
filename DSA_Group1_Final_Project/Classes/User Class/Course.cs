using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.User_Class
{
    public class Course
    {
        public string name { get; set; }
        public string code { get; set; }
        public string[] preReq { get; set; }
        public int term { get; set; }
        public int[] regularTerm { get; set; }
        public int units { get; set; }
        public int yearLevel { get; set; }


    }
}
