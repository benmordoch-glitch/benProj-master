using benProj.Models;
using benProj.Service;
using benProj.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace benProj.ViewModels
{
    class CoursViewModel : ViewModelBase
    {
        #region Get&Set
        private ObservableCollection<Cours> courses;
        public ObservableCollection<Cours> Courses
        {
            get { return courses; }
            set
            {
                courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        private string courseName;
        public string CourseName
        {
            get { return courseName; }
            set {
                courseName = value;
                OnPropertyChanged(nameof(courseName));
            }
        }

        private double courseDistance;
        public double CourseDistance
        {
            get { return courseDistance; }
            set {
                courseDistance = value;
                if(courseDistance != 0)
                    OnPropertyChanged(nameof(courseDistance));
            }
        }
        private int courseDifficulty;
        public int CourseDifficulty
        {
            get { return courseDifficulty; }
            set {
                courseDifficulty = value;
                if (courseDifficulty != 0)
                    OnPropertyChanged(nameof(courseDifficulty));
                else
                    courseDifficulty = 0;

            }
        }
        #endregion
        #region commands
        public ICommand DeleteItemCommand { get; set; }
        public ICommand AddCourseCommand { get; set; }

        //  public ICommand AddMessageCommand { get; set; }
        #endregion
        public CoursViewModel()
        {
            DeleteItemCommand = new Command((item) => DeleteItem(item)); // Currently this is a sync function , we will change it to async later
           /* AddCourseCommand = new Command(AddItem);*/ // Currently this is a sync function , we will change it to async later
            InitAsyncMethods();
        }
        #region Functions
        public async Task InitAsyncMethods()
        {
            Courses = new ObservableCollection<Cours>(await AppService.GetInstance().GetCourses());
        }
        public void DeleteItem(object obgMsg)
        {
            Cours c = (Cours)obgMsg;
            bool tf = AppService.GetInstance().DeleteCourse(c);
            if (tf)
            {
                Courses.Remove(c);
            }
        }
        //public void AddItem()
        //{

        //    Cours c = new Cours()
        //    {
        //        CourseName = CourseName,
        //        Distance = CourseDistance,
        //        Difficulty= CourseDifficulty
        //    };
        //    bool tf = AppService.GetInstance().AddCourse(c);
        //    if (tf)
        //    {
        //        Courses.Add(c);
                
        //    }
            
        //}
        #endregion
        // In a common app this function would be called from a dedicated page

    }
}
