using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA_Group1_Final_Project.Classes.Models;
using System.Diagnostics;
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace DSA_Group1_Final_Project.Classes.Connection
{
    public class FirestoreServices
    {
        private FirestoreDb db;

        public FirestoreServices()
        {
            // Ensure Firebase is initialized using Authentication.cs
            if (!FirebaseApp.DefaultInstance.Equals(null))
            {
                db = FirestoreDb.Create("mmcm-curriculum-tracker-app");
                Debug.WriteLine("Connected to Firestore.");
            }
            else
            {
                throw new Exception("Firebase has not been initialized. Ensure Authentication.CreateAsync() is called first.");
            }
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

        public static string GetCurriculumString(string curriculumId)
        {
            if (CurriculumMap.TryGetValue(curriculumId, out string curriculumName))
            {
                return curriculumName;
            }
            return "Unknown Curriculum"; // Default value if ID is not found
        }

        public async Task<bool> DeleteStudent(string studentId)
        {
            try
            {
                // 1️⃣ Delete from Firestore (Students Collection)
                DocumentReference studentRef = db.Collection("students").Document(studentId);
                await studentRef.DeleteAsync();

                // 2️⃣ Delete from Firestore (Users Collection, if applicable)
                DocumentReference userRef = db.Collection("users").Document(studentId);
                await userRef.DeleteAsync();

                Debug.WriteLine($"Student ID {studentId} successfully deleted from Firestore.");

                // 3️⃣ Delete from Firebase Authentication
                await FirebaseAuth.DefaultInstance.DeleteUserAsync(studentId);
                Debug.WriteLine($"User ID {studentId} successfully deleted from Firebase Authentication.");

                return true; // Success
            }
            catch (FirebaseAuthException authEx)
            {
                Debug.WriteLine($"Error deleting Firebase Auth user: {authEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting student: {ex.Message}");
                return false; // Failure
            }
        }

        public async Task<CourseGraph> GetCurriculumCourses(string curriculumId)
        {
            var groupedCourses = new Dictionary<int, Dictionary<int, List<CourseNode>>>();
            var electiveCourses = new List<CourseNode>();
            var studentCurriculum = GetCurriculumString(curriculumId);

            // 🔹 Years & Terms as stored in Firestore
            List<int> years = new List<int> { 1, 2, 3, 4 };
            List<int> terms = new List<int> { 1, 2, 3 };

            // 🔹 Map of elective categories based on curriculumId
            Dictionary<string, List<string>> electiveCategories = new Dictionary<string, List<string>>
            {
                { "1", new List<string> { "AWS171P", "EMSY171P", "GEN_ED", "MACH171P", "MICR172P", "NETA172P", "SDEV173P", "SNAD174P" } },
                { "2", new List<string> { "ADVANCED_ELECTRICAL_SYSTEMS_DESIGN", "ADVANCED_POWER_SYSTEMS", "ADVANCED_SYSTEM_DESIGN", "AGRICULTURAL_ENGINEERING", "GEN_ED", "MECHATRONICS", "OPEN_ELECTIVE" } },
                { "3", new List<string> { "AWS171P", "EMSY171P", "GEN_ED", "MACH171P", "MICR172P", "NETA172P", "SDEV173P", "SNAD174P" } },
                { "4", new List<string> { "ECE137P", "ECE110P", "ECE154P", "ECE152P", "SNAD175P", "NETA172P", "AWS171P", "ECE194", "NETA173P", "ECE166P", "ECE153", "ECE118P", "ECE127", "AENG", "GEN_ED" } }
            };

            try
            {
                // 🔹 Fetch regular courses (Loop through all years & terms)
                foreach (int year in years)
                {
                    foreach (int term in terms)
                    {
                        CollectionReference termRef = db.Collection("curriculums").Document(studentCurriculum).Collection(year.ToString()).Document($"term_{term}").Collection("courses");
                        QuerySnapshot snapshot = await termRef.GetSnapshotAsync();

                        List<CourseNode> courses = new List<CourseNode>();

                        foreach (var doc in snapshot.Documents)
                        {
                            Dictionary<string, object> data = doc.ToDictionary(); // Get raw document data

                            CourseNode course = new CourseNode
                            {
                                Code = data.ContainsKey("code") ? data["code"].ToString() : "",
                                Name = data.ContainsKey("name") ? data["name"].ToString() : "",
                                Units = data.ContainsKey("units") ? Convert.ToInt32(data["units"]) : 0,
                                YearLevel = data.ContainsKey("yearLevel") ? Convert.ToInt32(data["yearLevel"]) : 0,
                                Term = data.ContainsKey("term") ? Convert.ToInt32(data["term"]) : 0,

                                // Handling lists safely
                                Prerequisites = data.ContainsKey("prerequisites") && data["prerequisites"] is List<object> prereqList
                                    ? prereqList.Select(p => p.ToString()).ToList()
                                    : new List<string>(),

                                CoRequisites = data.ContainsKey("coRequisites") && data["coRequisites"] is List<object> coreqList
                                    ? coreqList.Select(c => c.ToString()).ToList()
                                    : new List<string>(),

                                RegularTerms = data.ContainsKey("regularTerms") && data["regularTerms"] is List<object> termList
                                    ? termList.Select(t => Convert.ToInt32(t)).ToList()
                                    : new List<int>(),

                                Taken = data.ContainsKey("taken") ? Convert.ToBoolean(data["taken"]) : false
                            };

                            courses.Add(course);
                        }


                        if (courses.Any())
                        {
                            if (!groupedCourses.ContainsKey(year))
                                groupedCourses[year] = new Dictionary<int, List<CourseNode>>();

                            if (!groupedCourses[year].ContainsKey(term))
                                groupedCourses[year][term] = new List<CourseNode>();

                            groupedCourses[year][term].AddRange(courses);
                        }
                    }
                }

                if (!electiveCategories.ContainsKey(curriculumId))
                {
                    Debug.WriteLine($"No electives found for curriculumId: {curriculumId}");
                    return null;
                }

                var electiveCategory = electiveCategories[curriculumId].Distinct().ToList(); // Remove duplicates
                var fetchTasks = electiveCategory.Select(async category =>
                {
                    CollectionReference electiveRef = db.Collection("curriculums").Document(studentCurriculum).Collection("electives").Document(category).Collection("courses");
                    QuerySnapshot snapshot = await electiveRef.GetSnapshotAsync();

                    if (snapshot.Documents.Count == 0)
                    {
                        Debug.WriteLine($"No elective courses found for category: {category}");
                        return;
                    }

                    var courses = snapshot.Documents.Select(doc =>
                    {
                        var data = doc.ToDictionary();
                        return new CourseNode
                        {
                            Code = data.ContainsKey("code") ? data["code"].ToString() : "",
                            Name = data.ContainsKey("name") ? data["name"].ToString() : "",
                            Units = data.ContainsKey("units") ? Convert.ToInt32(data["units"]) : 0,
                            YearLevel = data.ContainsKey("yearLevel") ? Convert.ToInt32(data["yearLevel"]) : 0,
                            Term = data.ContainsKey("term") ? Convert.ToInt32(data["term"]) : 0,
                            Prerequisites = data.TryGetValue("prerequisites", out object prereqObj) && prereqObj is List<object> prereqList ? prereqList.Select(p => p.ToString()).ToList() : new List<string>(),
                            CoRequisites = data.TryGetValue("coRequisites", out object coreqObj) && coreqObj is List<object> coreqList ? coreqList.Select(c => c.ToString()).ToList() : new List<string>(),
                            RegularTerms = data.TryGetValue("regularTerms", out object termObj) && termObj is List<object> termList ? termList.Select(t => Convert.ToInt32(t)).ToList() : new List<int>(),
                            Taken = false
                        };
                    }).ToList();

                    electiveCourses.AddRange(courses);
                });

                await Task.WhenAll(fetchTasks); // Fetch all electives in parallel


                // 🔹 Return the structured course graph
                return new CourseGraph(groupedCourses, electiveCourses);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching curriculum courses: {ex.Message}");
                return null;
            }
        }

        public async Task UpdateCompletedCourses(string studentId, string courseCode, bool isChecked)
        {
            try
            {
                DocumentReference studentRef = db.Collection("students").Document(studentId);
                DocumentSnapshot snapshot = await studentRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    // 🔹 Fetch existing completedCourses or initialize if empty
                    List<string> completedCourses = snapshot.ContainsField("completedCourses")
                        ? snapshot.GetValue<List<string>>("completedCourses")
                        : new List<string>();

                    // 🔹 Add or Remove the course based on isChecked
                    if (isChecked)
                        completedCourses.Add(courseCode);
                    else
                        completedCourses.Remove(courseCode);

                    // 🔹 Update Firestore with modified list
                    await studentRef.UpdateAsync("completedCourses", completedCourses);
                    Debug.WriteLine($"✅ Updated completedCourses for {studentId}: {string.Join(", ", completedCourses)}");
                }
                else
                {
                    Debug.WriteLine($"⚠ Student {studentId} not found in Firestore.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating completed courses: {ex.Message}");
            }
        }

        //Functions for getting next available courses...
        private CourseGraph courseGraph;
        private List<(CourseNode, string)> availableCourses = new();

        public async Task<List<(CourseNode, string)>> GetAvailableCoursesStudent(StudentDocument student, int selectedTerm)
        {
            Debug.WriteLine($"FirestoreService: Starting computeAvailableCourses() for Student:{student.Name}, Term: {selectedTerm}");

            // Ensure courseGraph is available
            if (courseGraph == null)
            {
                Debug.WriteLine("FirestoreService: Course graph is null, retrieving from Firestore...");
                courseGraph = await GetCurriculumCourses(student.Curriculum); // Fetch curriculum graph from Firestore
            }

            if (courseGraph != null)
            {
                Debug.WriteLine($"FirestoreService: Course graph for student {student.Name} successfully retrieved.");

                // Fetch completed courses for the student from the student object
                var studentCompletedCourses = new HashSet<string>(student.CompletedCourses);
                Debug.WriteLine($"FirestoreService: Retrieved completed courses for Student ID: {student.Name} from local reference.");
                Debug.WriteLine($"FirestoreService: Student {student.Name}'s Completed Courses: {string.Join(", ", studentCompletedCourses)}");

                // Fetch next available courses based on completed courses and selected term
                Debug.WriteLine($"FirestoreService: Fetching next available courses for Term {selectedTerm}...");
                availableCourses = courseGraph.GetNextAvailableCourses(selectedTerm, studentCompletedCourses);
            }
            else
            {
                Debug.WriteLine("FirestoreService: Course graph is null even after waiting, returning empty list.");
                availableCourses = new List<(CourseNode, string)>();
            }

            return availableCourses;
        }
        

    }
}