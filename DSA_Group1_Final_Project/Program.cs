using DSA_Group1_Final_Project.Classes.Connection;
using Google.Cloud.Firestore;
using DSA_Group1_Final_Project.Windows.AuthScreens;
using System.Diagnostics;
using System.Threading;

namespace DSA_Group1_Final_Project
{
    internal static class Program
    {
        private static Mutex mutex;
        [STAThread]
        static void Main()
        {



            const string appName = "DSA_Group1_Final_Project";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("The application is already running.");
                return; 
            }
            ApplicationConfiguration.Initialize();

            var auth = Authentication.Instance; // Use the singleton instance

            Application.Run(new StartupForm());
        }

        public static async Task<Form> GetInitialForm()
        {
            var savedUserId = Properties.Settings.Default.UserId;

            if (!string.IsNullOrEmpty(savedUserId))
            {
                string role = await GetUserRole(savedUserId);
                if (role == "Admin")
                    return new MainScreen(role, savedUserId);

                if (role == "Student")
                {
                    string curriculum = await GetStudentCurriculum(savedUserId);
                    Debug.WriteLine($"Fetched curriculum from Firestore: '{curriculum}'");  

                    if (string.IsNullOrWhiteSpace(curriculum)) 
                    {
                        Debug.WriteLine("No curriculum found, redirecting to ChooseCurriculumForm.");
                        return new ChooseCurriculumForm(savedUserId);
                    }
                    else
                    {
                        Debug.WriteLine($"Curriculum found: {curriculum}, redirecting to MainScreen.");
                        return new MainScreen(role, savedUserId);
                    }
                }
            }

            return new AuthForm();
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
                    string curriculum = snapshot.GetValue<string>("curriculum")?.Trim() ?? ""; 
                    Debug.WriteLine($"Retrieved curriculum: '{curriculum}'");  
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
                    Debug.WriteLine($"User role: {role}");  
                    return role;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user role: " + ex.Message);
                return "Unknown"; 
            }
        }
    }
}
