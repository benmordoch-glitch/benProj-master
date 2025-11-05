using benProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.ViewModels
{
    class CoursViewModel : ViewModelBase
    {
        private List<Cours> courses;

        public List<Cours> Courses
        {
            get { return courses; }
            set { courses = value;
                OnPropertyChanged();
                }
        }

        public CoursViewModel()
        {
            Courses = new List<Cours>()
            {
                 new Cours { Id = "1", CourseName = "ריצה בים", Difficulty = 3, Distance = 5 },
                 new Cours { Id = "2", CourseName = "ריצה בטיילת", Difficulty = 2, Distance = 4 }
            };
        }
    }
}
