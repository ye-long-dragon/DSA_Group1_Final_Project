using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.Text;
using Newtonsoft.Json;
using DSA_Group1_Final_Project.Classes.User_Class;
using Firebase.Auth.Providers;

namespace DSA_Group1_Final_Project.Classes.Connection
{
    public class Authentication
    {
        private static Authentication _instance;
        private static readonly object _lock = new object();

        private FirestoreDb db;
        private FirebaseAuthClient authProvider;
        private static bool firebaseInitialized = false;
        private static FirebaseAuth authAdmin;

        private Authentication() { } // Private constructor to prevent direct instantiation

        public static async Task<Authentication> CreateAsync()
        {
            Authentication instance = new Authentication();
            await instance.InitializeAsync();
            return instance;
        }
        public static Authentication Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authentication();
                        _instance.InitializeAsync().Wait(); // Initialize synchronously
                    }
                    return _instance;
                }
            }
        }
        public FirebaseAuthClient AuthProvider => authProvider;

        private async Task InitializeAsync()
        {
            try
            {
                string projectId = "mmcm-curriculum-tracker-app";
                string apiKey = "AIzaSyCNQSEw2JZFg4u8rEvKs29_cOnum9ACoF4"; // ✅ Needed for FirebaseAuthentication.net

                // 🔹 Fetch credentials from Firestore
                string base64Credentials = await FetchCredentialsFromFirestore();
                if (string.IsNullOrEmpty(base64Credentials))
                {
                    throw new Exception("Failed to retrieve Firebase credentials.");
                }

                string jsonCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials));
                string tempJsonPath = Path.Combine(Path.GetTempPath(), "firebase_credentials.json");
                File.WriteAllText(tempJsonPath, jsonCredentials);
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", tempJsonPath);

                // ✅ Initialize Firebase Admin SDK only once
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

                // 🔹 Initialize Firestore & FirebaseAuth Admin
                db = FirestoreDb.Create(projectId);
                authAdmin = FirebaseAuth.DefaultInstance;

                // ✅ Initialize FirebaseAuthProvider for client authentication
                authProvider = new FirebaseAuthClient(new FirebaseAuthConfig
                {
                    ApiKey = apiKey,
                    AuthDomain = $"{projectId}.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    }

                });

                Console.WriteLine("Firebase successfully initialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Firebase Initialization Error: " + ex.Message);
                throw;
            }
        }

        public async Task<string> LoginUser(string email, string password)
        {
            try
            {
                // ✅ FIXED: Use correct method for authentication
                var userCredential = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                string userId = userCredential.User.Uid;
                string idToken = await userCredential.User.GetIdTokenAsync(); // ✅ Corrected Token Retrieval

                return $"Login successful! User ID: {userId}, Token: {idToken}";
            }
            catch (Firebase.Auth.FirebaseAuthException ex) // ✅ Explicitly specify Firebase.Auth
            {
                return "Login failed: " + ex.Message;
            }
        }

        

        public async Task LogoutUser()
        {
            // ✅ Firebase Authentication SDK does not maintain sessions, but we can revoke tokens
            await authAdmin.RevokeRefreshTokensAsync(authProvider.User.Uid);
        }
        public void Cleanup()
        {
            authProvider = null; // Remove reference to authentication client
            db = null; // Remove reference to Firestore
            Console.WriteLine("Authentication resources cleaned up.");
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
                UserRecord userRecord = await authAdmin.CreateUserAsync(userArgs);

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
        /*public async Task<string> GetCurrentUserId(string firebaseToken)
    {
        try
        {
            if (string.IsNullOrEmpty(firebaseToken))
            {
                return "Invalid token. User not authenticated.";
            }

            var user = await authAdmin.VerifyIdTokenAsync(firebaseToken);
            return user.Uid; // ✅ Returns correct Firebase UID
        }
        catch (Exception ex)
        {
            return "Error fetching user: " + ex.Message;
        }
    }*/


    }
}
