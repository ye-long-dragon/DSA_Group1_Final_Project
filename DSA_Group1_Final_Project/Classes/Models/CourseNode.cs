using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.Models
{
    using System.Collections.Generic;
    using Google.Cloud.Firestore;

    [FirestoreData] // 🔥 Required to map the class to Firestore
    public class CourseNode
    {
        [FirestoreProperty]
        public string Code { get; set; } = "";

        [FirestoreProperty]
        public string Name { get; set; } = "";

        [FirestoreProperty]
        public int Units { get; set; } = 0;

        [FirestoreProperty]
        public int YearLevel { get; set; } = 0;

        [FirestoreProperty]
        public int Term { get; set; } = 0;

        [FirestoreProperty]
        public List<string> Prerequisites { get; set; } = new List<string>();

        [FirestoreProperty]
        public List<string> CoRequisites { get; set; } = new List<string>();

        [FirestoreProperty]
        public List<int> RegularTerms { get; set; } = new List<int>();

        [FirestoreProperty]
        public bool Taken { get; set; } = false;

        // Default constructor (needed for Firestore deserialization)
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
