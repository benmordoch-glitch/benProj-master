using benProj.Models;
using benProj.Service;
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
            courses = AppService.GetInstance().GetCours();
        }
    }
}
