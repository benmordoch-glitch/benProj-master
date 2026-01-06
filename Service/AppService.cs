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
        private List<Models.Path> paths;
        //private List<Path> paths;


        static FirebaseAuthClient? auth;
        static FirebaseClient? client;
        static public AuthCredential? loginAuthUser;
        /*
         
        // Import the functions you need from the SDKs you need
        import { initializeApp } from "firebase/app";
        // TODO: Add SDKs for Firebase products that you want to use
        // https://firebase.google.com/docs/web/setup#available-libraries

        // Your web app's Firebase configuration
        const firebaseConfig = {
          apiKey: "AIzaSyDAIwCb7vp-MBOrhIFW0EiXLLqo0tx5iCI",
          authDomain: "benproject26-57e58.firebaseapp.com",
          databaseURL: "https://benproject26-57e58-default-rtdb.europe-west1.firebasedatabase.app",
          projectId: "benproject26-57e58",
          storageBucket: "benproject26-57e58.firebasestorage.app",
          messagingSenderId: "1064153240992",
          appId: "1:1064153240992:web:4980bdcf74a0a0ab5840c5"
        };

        // Initialize Firebase
        const app = initializeApp(firebaseConfig);
         
         */

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
                //ApiKey = "AIzaSyASL79815CVSL3kouvG0oIJkFp2cFPuFqk", //  אייפיאיי שלי ורק שליייייייייייייייייייי
                ApiKey = "AIzaSyDAIwCb7vp-MBOrhIFW0EiXLLqo0tx5iCI", //  אייפיאיי שלי ורק שליייייייייייייייייייי
                AuthDomain = "benproject26-57e58.firebaseapp.com", //כתובת התחברות
                //AuthDomain = "benproject26-57e58.firebaseapp.com", //כתובת התחברות
                Providers = new FirebaseAuthProvider[] //רשימת אפשריות להתחבר
                {
                    new EmailProvider() //אנחנו נשתמש בשירות חינמי של התחברות עם מייל
                },
                UserRepository = new FileUserRepository("appUserData") //לא חובה, שם של קובץ בטלפון הפרטי שאפשר לשמור בו את מזהה ההתחברות כדי לא הכניס כל פעם את הסיסמא 
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
        public async Task<bool> TryRegister(string userNameString, string passwordString)
        {
            try
            {
                var respond = await auth.CreateUserWithEmailAndPasswordAsync(userNameString, passwordString);
                // User is signed up and logged in
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="userNameString"></param>
        /// <param name="passwordString"></param>
        /// <returns></returns>
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
                // Authentication successful 
                // We keep the token or Credential in loginAuthUser, so we can erase it later in logout
                // You can access the authenticated user's details via authUser.User
                // you should create a new user or person
                // Person person = new Person(){Email=authUser.User.info.Email, ...
                // Don't put the password in the Person :)

                // ((App)Application.Current).SetAuthenticatedShell();

                return true;
            }
            catch (FirebaseAuthException ex)
            {
                // Authentication failed
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
        private void CreateFakeData()
        {
            CoursesFromFirebase = new List<Course>()
            {
                 new Course { Id = "1", CourseName = "ריצה בים", Difficulty = 3, Distance = 8 },
                 new Course { Id = "2", CourseName = "ריצה בטיילת", Difficulty = 2, Distance = 5 },
                 new Course { Id = "3", CourseName = "מרוץ אייל 25", Difficulty = 5, Distance = 15 }
            };
            //cours = new List<Path>()
            //{
            //     new Path { Id = "1", PathName = "ריצה בים" ,Distance = 8 },
            //     new Path { Id = "2", PathName = "ריצה בטיילת" ,Distance = 5 },
            //     new Path { Id = "3", PathName = "מרוץ אייל 25", Distance = 15 }
            //};
        }



        public List<Course> GetCourses()
        {
            return CoursesFromFirebase;
        }

        class FirebaseCourse
        {
            public string CourseName { get; set; }
            public int Difficulty { get; set; }
            public double Distance { get; set; }
        }

        public async Task<bool> GetCoursesFromFirebaseAsync()
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
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
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
