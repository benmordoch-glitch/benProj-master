using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using benProj.Models;
using Firebase.Auth.Repository;
using Firebase.Database;
using Firebase.Database.Query;
using benProj.Views;

// name collision
using FirebaseUser = Firebase.Auth.User;
using User = benProj.Models.User;

namespace benProj.Service
{
    class AppService
    {
        public static AppService serviceRegister;
        private User user;
        private List<Course> CoursesFromFirebase;
        private List<Training> Trainings;
        private List<Models.Path> paths;
        //private List<Path> paths;


        static FirebaseAuthClient? auth;
        static FirebaseClient? client;
        static public AuthCredential? loginAuthUser;

        public static AppService GetInstance()
        {
            if (serviceRegister == null)
            {
                serviceRegister = new AppService();
                serviceRegister.InitAuth();
                //serviceRegister.CreateFakeData();
            }
            return serviceRegister;
        }
        public void InitAuth()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyDAIwCb7vp-MBOrhIFW0EiXLLqo0tx5iCI", //  אייפיאיי שלי ורק שליייייייייייייייייייי
                AuthDomain = "benproject26-57e58.firebaseapp.com", //כתובת התחברות
                Providers = new FirebaseAuthProvider[] //רשימת אפשריות להתחבר
                {
                    new EmailProvider() //אנחנו נשתמש בשירות חינמי של התחברות עם מייל
                },
                //UserRepository = new FileUserRepository("appUserData") //לא חובה, שם של קובץ בטלפון הפרטי שאפשר לשמור בו את מזהה ההתחברות כדי לא הכניס כל פעם את הסיסמא 
            };
            auth = new FirebaseAuthClient(config); //ההתחברות

            client =
              new FirebaseClient(@"https://benproject26-57e58-default-rtdb.europe-west1.firebasedatabase.app/", //כתובת מסד הנתונים
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth.User.Credential.IdToken)// מזהה ההתחברות של המשתמש עם השרת, הנתון נשמר במכשיר
              });
        }

        /// <summary>
        /// Try Registerrrr 
        /// </summary>
        /// <param name="userNameString"></param>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        //public async Task<bool> TryRegister(string userNameString, string passwordString, string privateName,string familyName)
        //{
        //    try
        //    {
        //        // 1: Create a user in Firebase with an Email and Password.
        //        var respond = await auth.CreateUserWithEmailAndPasswordAsync(userNameString, passwordString);
        //        // 2: User was created and also user is also Logged in
        //        // 3: We Store the Uid of the user
        //        fullDetaillsLoggedInUser = new AuthUser()
        //        {
        //            Email = respond.User.Info.Email,
        //            Id = respond.User.Uid,
        //            FullName = fullName
        //        };
        //        // 3: We can continue and add more details about the user but this time in the firebase Database
        //        // Example: saving the full name
        //        await client
        //            .Child("users")
        //            .Child(fullDetaillsLoggedInUser.Id)
        //            .PutAsync(new
        //            {
        //                fullName = fullName
        //            });

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error",
        //            ex.Message,
        //            "OK"
        //        );

        //        return false;
        //    }
        //}
        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="userNameString"></param>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        /// 
        class FirebasePrivateData()
        {
            public string? privateName {  get; set; }
            public string? familyName {  get; set; }
        }
        public async Task<bool> TryLoginAsync(string userNameString, string passwordString)
        {
            if (userNameString == null || passwordString == null)
            {
                return false;
            }
            try
            {
                var authUser = await auth.SignInWithEmailAndPasswordAsync(userNameString, passwordString);
                loginAuthUser = authUser.AuthCredential;
                string uid = authUser.User.Uid;

                //var userData = await client.Child("users").Child(uid).Child("privateData").OnceAsync<FirebasePrivateData>();
                var userData = await client.Child("users").Child(uid).Child("privateData").OnceSingleAsync<FirebasePrivateData>();
                // Authentication successful 
                // We keep the token or Credential in loginAuthUser, so we can erase it later in logout
                // You can access the authenticated user's details via authUser.User
                // you should create a new user or person
                // Person person = new Person(){Email=authUser.User.info.Email, ...
                // Don't put the password in the Person :)

                // ((App)Application.Current).SetAuthenticatedShell();

                return true;
            }
            catch (FirebaseAuthException e)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   e.Message,
                   "OK"
               );
                return false;
            }
        }
        public bool Logout()
        {
            try
            {
                auth.SignOut();
                loginAuthUser = null;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void AddRegisteredUser(User u)
        {
            user = u;
        }
        public User GetUser()
        {
            return user;
        }



       

        class FirebaseCourse
        {
            public string CourseName { get; set; }
            public int Difficulty { get; set; }
            public double Distance { get; set; }
        }
        
        public async Task<List<Course>> GetCoursesFromFirebaseAsync()
        {
            try
            {
                var fbCourses = await client.Child("users").Child(auth.User.Uid).Child("courses").OnceAsync<FirebaseCourse>();

                List<Course> parsedCourses = new();
                foreach (var fbCourse in fbCourses)
                {
                    Course course = new Course
                    {
                        Id = fbCourse.Key,
                        CourseName = fbCourse.Object.CourseName,
                        Difficulty = fbCourse.Object.Difficulty,
                        Distance = fbCourse.Object.Distance,
                    };
                    parsedCourses.Add(course);
                }
                CoursesFromFirebase = parsedCourses;
                return CoursesFromFirebase;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    e.Message,
                    "OK"
                );
                return new List<Course>();
            }
        }

        class FirebaseTraining
        {
            public string CourseID { get; set; }
            public int StartDate { get; set; }
            public int Duration { get; set; }
        }
        private Course GetCourseNameAccordingCourseID(string courseIDFromJson)
        {
            // look in CoursesFromFirebase for a class Course with the uid of courseID
  
            foreach (Course c in CoursesFromFirebase)
            {
                if (c.Id == courseIDFromJson)
                {
                    return c;
                }
            }

            return null;
        }
        public async Task<List<Training>> GetTrainingsFromFirebaseAsync()
        {
            try
            {
                var result = await client.Child("users").Child(auth.User.Uid).Child("trainings").OnceAsync<FirebaseTraining>();
                Trainings =  new List<Training>();
                foreach (var t in result)
                {
                    Training training = new Training()
                    {
                        Id = t.Key,
                        CourseRef = GetCourseNameAccordingCourseID(t.Object.CourseID), // we get uid of Course (t.Object.CourseID) and we have to find the Course class
                        StartDate = DateTimeOffset.FromUnixTimeSeconds(t.Object.StartDate).DateTime,
                        Duration =  TimeSpan.FromSeconds(t.Object.Duration)

                    };
                    Trainings.Add(training);
                }

                return Trainings;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    e.Message,
                    "OK"
                );
                return new List<Training>();
            }
    
        }

        
        //public bool AddCourse(Cours cours)
        //{
        //    // Will add in DB
        //    courses.Add(cours);
        //    return true;
        //}

        //public bool DeleteCourse(Cours cours)
        //{
        //    courses.Remove(cours);
        //    return true;
        //}
    }
}
