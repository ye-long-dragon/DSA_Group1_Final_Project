using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA_Group1_Final_Project.Classes;
using DSA_Group1_Final_Project.Classes.Models;
using System.Diagnostics;

namespace DSA_Group1_Final_Project.Classes.Connection
{
    public class FirestoreServices
    {
        private FirestoreDb db;

        public FirestoreServices()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\Jameel Mamogkat\Documents\AY24-25, 2nd Term\DSA\PROJECT\DSA_Group1_Final_Project\mmcm-curriculum-tracker-app-firebase-adminsdk-fbsvc-04fba75862.json"); //Replace with your json file path
            db = FirestoreDb.Create("mmcm-curriculum-tracker-app"); // Replace with your Firebase project ID
            Debug.WriteLine("Connected to Firestore.");
        }

        public async Task<List<StudentDocument>> GetAllStudentsAsync()
        {
            Debug.WriteLine("Fetching all students from Firestore...");
            List<StudentDocument> students = new List<StudentDocument>();

            try
            {
                CollectionReference studentsCollection = db.Collection("students");
                QuerySnapshot snapshot = await studentsCollection.GetSnapshotAsync();

                Debug.WriteLine($"Successfully fetched {snapshot.Count} students.");

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    try
                    {
                        StudentDocument student = new StudentDocument
                        {
                            StudentID = document.Id, // Firestore Document ID
                            UserID = document.ContainsField("userID") ? document.GetValue<string>("userID") : "",
                            Name = document.ContainsField("name") ? document.GetValue<string>("name") : "Unknown",
                            Email = document.ContainsField("email") ? document.GetValue<string>("email") : "",
                            StudentNumber = document.ContainsField("studentNumber") ? document.GetValue<string>("studentNumber") : "",
                            Program = document.ContainsField("program") ? document.GetValue<string>("program") : "",
                            TermEnrolling = document.ContainsField("termEnrolling") ? document.GetValue<int>("termEnrolling") : 1,
                            Curriculum = document.ContainsField("curriculum") ? document.GetValue<string>("curriculum") : "",
                            CompletedCourses = document.ContainsField("completedCourses") ? document.GetValue<List<string>>("completedCourses") : new List<string>(),
                            ApprovalStatus = document.ContainsField("approvalStatus") ? document.GetValue<string>("approvalStatus") : ""
                        };

                        Debug.WriteLine($"Fetched Student ID: {student.StudentID}, Name: {student.Name}, Email: {student.Email}, ApprovalStatus: {student.ApprovalStatus}");

                        students.Add(student);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Failed to map student fields: {document.Id}, Error: {e.Message}");
                    }

                    Debug.WriteLine($"Total students after filtering: {students.Count}");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error fetching students: {e.Message}");
            }

            return students;
        }

        // 🔥 Function to update a specific student field
        public async Task UpdateStudentField(string studentId, string fieldName, object newValue)
        {
            try
            {
                DocumentReference docRef = db.Collection("students").Document(studentId);

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { fieldName, newValue } // Dynamically update any field
                };

                await docRef.UpdateAsync(updates);

                Console.WriteLine($"Successfully updated {fieldName} for Student ID: {studentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating {fieldName} for Student ID: {studentId} - {ex.Message}");
            }
        }

        // 🔥 Curriculum ID to Firestore Document ID Mapping
        private static readonly Dictionary<string, string> CurriculumMap = new Dictionary<string, string>
        {
            { "1", "bscpe_2022_2023" }, // BS Computer Engineering 2022-2023
            { "2", "bsee_2024_2025" },  // BS Electrical Engineering 2024-2025
            { "3", "bscpe_2021_2022" }, // BS Computer Engineering 2021-2022
            { "4", "bsece_2022_2023" }  // BS Electronics Engineering 2022-2023
        };

        public async Task<bool> DeleteStudent(string studentId)
        {
            try
            {
                DocumentReference docRef = db.Collection("students").Document(studentId);
                await docRef.DeleteAsync(); // Delete the student document

                Debug.WriteLine($"Student ID {studentId} successfully deleted from Firestore.");
                return true; // Success
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting student: {ex.Message}");
                return false; // Failure
            }
        }

    }
}