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
        private List<Cours> courses;
        private List<Models.Path> paths;
        //private List<Path> paths;


        static FirebaseAuthClient? auth;
        static FirebaseClient? client;
        static public AuthCredential? loginAuthUser;

        public void InitAuth()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyASL79815CVSL3kouvG0oIJkFp2cFPuFqk", //  אייפיאיי שלי ורק שליייייייייייייייייייי
                AuthDomain = "benproject26-57e58.firebaseapp.com", //כתובת התחברות
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
            courses = new List<Cours>()
            {
                 new Cours { Id = "1", CourseName = "ריצה בים", Difficulty = 3, Distance = 8 },
                 new Cours { Id = "2", CourseName = "ריצה בטיילת", Difficulty = 2, Distance = 5 },
                 new Cours { Id = "3", CourseName = "מרוץ אייל 25", Difficulty = 5, Distance = 15 }
            };
            //cours = new List<Path>()
            //{
            //     new Path { Id = "1", PathName = "ריצה בים" ,Distance = 8 },
            //     new Path { Id = "2", PathName = "ריצה בטיילת" ,Distance = 5 },
            //     new Path { Id = "3", PathName = "מרוץ אייל 25", Distance = 15 }
            //};
        }
        public async Task<List<Cours>> GetCourses()
        {
            return courses;
        }
        public bool AddCourse(Cours cours)
        {
            // Will add in DB
            courses.Add(cours);
            return true;
        }
        public bool DeleteCourse(Cours cours)
        {
            courses.Remove(cours);
            return true;
        }


    }
}
