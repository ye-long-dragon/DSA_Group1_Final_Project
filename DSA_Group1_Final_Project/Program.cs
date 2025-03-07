using DSA_Group1_Final_Project.Classes.Connection;
using Google.Cloud.Firestore;
using DSA_Group1_Final_Project.Windows.AuthScreens;
using System.Diagnostics;

namespace DSA_Group1_Final_Project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Ensure Firebase initializes before starting
            var auth = Authentication.Instance; // Use the singleton instance

            // Run on the UI Thread
            Application.Run(new StartupForm());
        }

        // 🔥 Make this method PUBLIC so StartupForm can access it
        public static async Task<Form> GetInitialForm()
        {
            var savedUserId = Properties.Settings.Default.UserId;

            if (!string.IsNullOrEmpty(savedUserId))
            {
                string role = await GetUserRole(savedUserId);
                if (role == "Admin")
                    return new MainScreen(role);

                if (role == "Student")
                {
                    string curriculum = await GetStudentCurriculum(savedUserId);
                    Debug.WriteLine($"Fetched curriculum from Firestore: '{curriculum}'");  // 🔍 Debugging

                    if (string.IsNullOrWhiteSpace(curriculum)) // ✅ Fix: Checks empty & spaces
                    {
                        Debug.WriteLine("No curriculum found, redirecting to ChooseCurriculumForm.");
                        return new ChooseCurriculumForm(savedUserId);
                    }
                    else
                    {
                        Debug.WriteLine($"Curriculum found: {curriculum}, redirecting to MainScreen.");
                        return new MainScreen(role);
                    }
                }
            }

            return new AuthForm(); // Default to login screen if no user is found
        }

        public static async Task<string> GetStudentCurriculum(string userId)
        {
            try
            {
                DocumentReference studentRef = FirestoreDb.Create("mmcm-curriculum-tracker-app")
                                                          .Collection("students")
                                                          .Document(userId);
                DocumentSnapshot snapshot = await studentRef.GetSnapshotAsync();

                if (snapshot.Exists && snapshot.ContainsField("curriculum"))
                {
                    string curriculum = snapshot.GetValue<string>("curriculum")?.Trim() ?? ""; // ✅ Trim spaces
                    Debug.WriteLine($"Retrieved curriculum: '{curriculum}'");  // 🔍 Debugging
                    return curriculum;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving curriculum: {ex.Message}");
            }

            return ""; // Return empty string if not found
        }

        public static async Task<string> GetUserRole(string userId)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    FirestoreDb db = FirestoreDb.Create("mmcm-curriculum-tracker-app");
                    DocumentReference userDoc = db.Collection("users").Document(userId);
                    DocumentSnapshot snapshot = await userDoc.GetSnapshotAsync();

                    string role = snapshot.Exists && snapshot.ContainsField("role") ? snapshot.GetValue<string>("role") : "Unknown";
                    Debug.WriteLine($"User role: {role}");  // 🔍 Debugging
                    return role;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user role: " + ex.Message);
                return "Unknown"; // Default if role is not found
            }
        }
    }
}
