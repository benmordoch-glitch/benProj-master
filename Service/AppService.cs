using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using benProj.Models;

namespace benProj.Service
{
    internal class AppService
    {
        public static AppService serviceRegister;

        private User user;
        private List<Cours> cours;
        //private List<Path> paths;
        

        public static AppService GetInstance()
        {
            if (serviceRegister == null) { 
                serviceRegister = new AppService();
                serviceRegister.CreateFakeData();
            }
            return serviceRegister;
        }

        public void  AddRegisteredUser(User u)
        {
            user = u;
        }
        public User GetUser()
        {
            return user;
        }
        private void CreateFakeData()
        {
            cours = new List<Cours>()
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
        public List<Cours> GetCours()
        {
            return cours;
        }

    }
}
