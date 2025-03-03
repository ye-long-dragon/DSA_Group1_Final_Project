using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.Models
{
    using System;
    using System.Collections.Generic;
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class StudentDocument
    {
        [FirestoreProperty]
        public string UserID { get; set; } = ""; // Maps to Firebase user ID

        [FirestoreProperty]
        public string StudentID { get; set; } = ""; // Unique identifier for the student

        [FirestoreProperty]
        public string Name { get; set; } = ""; // Student's name

        [FirestoreProperty]
        public string Email { get; set; } = ""; // Student's email

        [FirestoreProperty]
        public string StudentNumber { get; set; } = ""; // Student number

        [FirestoreProperty]
        public string Program { get; set; } = ""; // Program (e.g., "BS Computer Engineering")

        [FirestoreProperty]
        public int TermEnrolling { get; set; } = 1; // The term the student is enrolling in

        [FirestoreProperty]
        public string Curriculum { get; set; } = null; // Curriculum ID or name

        [FirestoreProperty]
        public List<string> CompletedCourses { get; set; } = new List<string>(); // List of completed course IDs

        [FirestoreProperty]
        public string ApprovalStatus { get; set; } = ""; // Approval status (e.g., "Pending", "Approved", "Rejected")

        // No-argument constructor required for Firestore deserialization
        public StudentDocument() { }

        // Constructor to initialize fields
        public StudentDocument(string userID, string studentID, string name, string email, string studentNumber,
                       string program, int termEnrolling, string curriculum, List<string> completedCourses,
                       string approvalStatus)
        {
            UserID = userID;
            StudentID = studentID;
            Name = name;
            Email = email;
            StudentNumber = studentNumber;
            Program = program;
            TermEnrolling = termEnrolling;
            Curriculum = curriculum;
            CompletedCourses = completedCourses ?? new List<string>();
            ApprovalStatus = approvalStatus;
        }
    }

}
