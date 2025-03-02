using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using DSA_Group1_Final_Project.Classes.User_Class;

namespace DSA_Group1_Final_Project.Classes.Connection
{
    public class Authentication
    {
        private FirestoreDb db;
        private FirebaseAuth auth;
        private static bool firebaseInitialized = false;

        private Authentication() { } // Private constructor to prevent direct instantiation

        public static async Task<Authentication> CreateAsync()
        {
            Authentication instance = new Authentication();
            await instance.InitializeAsync();
            return instance;
        }

        private async Task InitializeAsync()
        {
            try
            {
                string projectId = "mmcm-curriculum-tracker-app";

                // 🔹 Fetch credentials asynchronously
                string base64Credentials = await FetchCredentialsFromFirestore();
                if (string.IsNullOrEmpty(base64Credentials))
                {
                    throw new Exception("Failed to retrieve Firebase credentials from Firestore.");
                }

                // 🔹 Decode and set credentials
                string jsonCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials));
                string tempJsonPath = Path.Combine(Path.GetTempPath(), "firebase_credentials.json");
                File.WriteAllText(tempJsonPath, jsonCredentials);
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", tempJsonPath);

                // ✅ Log output
                Console.WriteLine("Firebase credentials saved at: " + tempJsonPath);

                // 🔹 Initialize FirebaseApp only once
                if (!firebaseInitialized)
                {
                    var credential = GoogleCredential.FromJson(jsonCredentials)
                        .CreateScoped(new[] { "https://www.googleapis.com/auth/cloud-platform" });

                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = credential,
                        ProjectId = projectId
                    });

                    firebaseInitialized = true;
                }

                // 🔹 Initialize Firestore
                db = FirestoreDb.Create(projectId);
                auth = FirebaseAuth.DefaultInstance;

                Console.WriteLine("Firebase successfully initialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Firebase Initialization Error: " + ex.Message);
                throw;
            }
        }

        private async Task<string> FetchCredentialsFromFirestore()
        {
            try
            {
                string projectId = "mmcm-curriculum-tracker-app";
                string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/configs/firebase_credentials";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                        return data.fields.credentials.stringValue;
                    }
                    else
                    {
                        Console.WriteLine("Failed to fetch credentials: " + jsonResponse);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching credentials: " + ex.Message);
                return null;
            }
        }

        public async Task<string> RegisterUser(string email, string password, string role, string program)
        {
            try
            {
                // Check if email is already registered
                Query query = db.Collection("users").WhereEqualTo("email", email);
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                if (snapshot.Documents.Count > 0) // Fixed query check
                {
                    return "Email already registered.";
                }

                // Send OTP
                bool otpSent = await SendOtp(email);
                if (!otpSent)
                {
                    return "Failed to send OTP. Please try again.";
                }

                return "OTP sent. Please verify.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<bool> SendOtp(string email)
        {
            try
            {
                Random random = new Random();
                string otp = random.Next(100000, 999999).ToString();

                Dictionary<string, object> otpData = new Dictionary<string, object>
        {
            { "otp", otp },
            { "expiresAt", Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(5)) }
        };

                DocumentReference otpDoc = db.Collection("otps").Document(email);
                await otpDoc.SetAsync(otpData);

                // Send OTP via Firebase Function
                var jsonPayload = JsonConvert.SerializeObject(new { email, otp });
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (HttpClient httpClient = new HttpClient()) // ✅ Fix: Declare it inside the method
                {
                    HttpResponseMessage response = await httpClient.PostAsync(
                        "https://us-central1-mmcm-curriculum-tracker-app.cloudfunctions.net/sendOtpEmail", content
                    );

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending OTP: " + ex.Message);
                return false;
            }
        }


        public async Task<string> VerifyOtp(string email, string enteredOtp, string password, string role, string program)
        {
            try
            {
                DocumentReference otpDoc = db.Collection("otps").Document(email);
                DocumentSnapshot snapshot = await otpDoc.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    string storedOtp = snapshot.GetValue<string>("otp");
                    Timestamp expiresAt = snapshot.GetValue<Timestamp>("expiresAt");

                    if (storedOtp == enteredOtp && expiresAt.ToDateTime() > DateTime.UtcNow)
                    {
                        return await RegisterNewUser(email, password, role, program);
                    }
                }

                return "Invalid or expired OTP.";
            }
            catch (Exception ex)
            {
                return "Error verifying OTP: " + ex.Message;
            }
        }

        private async Task<string> RegisterNewUser(string email, string password, string role, string program)
        {
            try
            {
                UserRecordArgs userArgs = new UserRecordArgs
                {
                    Email = email,
                    Password = password
                };
                UserRecord userRecord = await auth.CreateUserAsync(userArgs);

                Dictionary<string, object> userData = new Dictionary<string, object>
                {
                    { "email", email },
                    { "role", role },
                    { "createdAt", Timestamp.GetCurrentTimestamp() }
                };

                DocumentReference userDoc = db.Collection("users").Document(userRecord.Uid);
                await userDoc.SetAsync(userData);

                if (role == "Student")
                {
                    Dictionary<string, object> studentData = new Dictionary<string, object>
                    {
                        { "userID", userRecord.Uid },
                        { "email", email },
                        { "approvalStatus", "pending" },
                        { "name", "" },
                        { "studentNumber", "" },
                        { "program", program },
                        { "curriculum", "" },
                        { "completedCourses", new List<string>() },
                        { "termEnrolling", 1 }
                    };

                    await db.Collection("students").Document(userRecord.Uid).SetAsync(studentData);
                }
                else
                {
                    Dictionary<string, object> adminData = new Dictionary<string, object>
                    {
                        { "userID", userRecord.Uid },
                        { "email", email },
                        { "name", "" },
                        { "permission", "admin" }
                    };

                    await db.Collection("admins").Document(userRecord.Uid).SetAsync(adminData);
                }

                return "Registration successful.";
            }
            catch (Exception ex)
            {
                return "Error during registration: " + ex.Message;
            }
        }


        public async Task<List<Course>> ReturnCourses()
        {
            try
            {
                List<Course> courses = new List<Course>();

                // Await the asynchronous call to get the snapshot
                QuerySnapshot snapshot = await db.Collection("courses").GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists) // Check if the document exists
                    {
                        Course course = new Course
                        {
                            name = document.GetValue<string>("name"),
                            code = document.GetValue<string>("code"),
                            preReq = document.GetValue<string[]>("preReq"),
                            term = document.GetValue<int>("term"),
                            regularTerm = document.GetValue<int[]>("regularTerm"),
                            units = document.GetValue<int>("units"),
                            yearLevel = document.GetValue<int>("yearLevel")
                        };

                        courses.Add(course);
                    }
                }

                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching courses: " + ex.Message);
                return null;
            }
        }





    }
}
