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
                 new Cours { Id = "1", CourseName = ":ריצה בים", Difficulty = 3, Distance = 5 },
                 new Cours { Id = "2", CourseName = ":ריצה בטיילת", Difficulty = 2, Distance = 4 },
                 new Cours { Id = "3", CourseName = ":ריצה dsfsdf", Difficulty = 1, Distance = 4 }
            };
        }
        public List<Cours> GetCours()
        {
            return cours;
        }

    }
}
