using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Graph_Processing
{
    public class CourseNode // Change from internal to public
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public int Units { get; set; } = 0;
        public int YearLevel { get; set; } = 0;
        public int Term { get; set; } = 0;
        public List<string> Prerequisites { get; set; } = new List<string>();
        public List<string> CoRequisites { get; set; } = new List<string>();
        public List<int> RegularTerms { get; set; } = new List<int>();
        public bool Taken { get; set; } = false;

        // Default constructor (needed for serialization)
        public CourseNode() { }

        // Constructor with parameters
        public CourseNode(string code, string name, int units, int yearLevel, int term,
                          List<string> prerequisites, List<string> coRequisites,
                          List<int> regularTerms, bool taken)
        {
            Code = code;
            Name = name;
            Units = units;
            YearLevel = yearLevel;
            Term = term;
            Prerequisites = prerequisites;
            CoRequisites = coRequisites;
            RegularTerms = regularTerms;
            Taken = taken;
        }

        // Helper method to display course info
        public override string ToString()
        {
            return $"{Code}: {Name} ({Units} units, Year {YearLevel}, Term {Term})";
        }
    }
}
