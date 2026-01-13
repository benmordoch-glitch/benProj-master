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
    class CourseViewModel : ViewModelBase
    {
        #region Get&Set
        private ObservableCollection<Course> courses;
        public ObservableCollection<Course> Courses
        {
            get { return courses; }
            set
            {
                courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public List<Coordinate> path;

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

        public ICommand GoToTrainingCommand { get; set; }
        public CourseViewModel()
        {
            InitAsyncMethods();
            //GoToPathCommand = new Command(async () => await GoToPathPage());
        }

        #region Functions
        public async Task InitAsyncMethods()
        {
            List<Course> c = await AppService.GetInstance().GetCoursesFromFirebaseAsync();
            Courses = new ObservableCollection<Course>(c);
        }
        //public async Task GoToPathPage()
        //{
        //    await Shell.Current.GoToAsync("//Paths");
        //}
        #endregion
        // In a common app this function would be called from a dedicated page

    }
}
