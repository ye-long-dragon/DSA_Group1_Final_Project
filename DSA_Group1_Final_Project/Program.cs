using DSA_Group1_Final_Project.Classes.Connection;
using Google.Cloud.Firestore;

namespace DSA_Group1_Final_Project.Windows.AuthScreens
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
                if (role == "Admin" || role == "Student")
                    return new MainScreen(role);
            }

            return new AuthForm(); // Default to login screen if no user is found
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

                    return snapshot.Exists && snapshot.ContainsField("role") ? snapshot.GetValue<string>("role") : "Unknown";
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

