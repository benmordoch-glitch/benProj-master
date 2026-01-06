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

        public CourseViewModel()
        {
            InitAsyncMethods();
        }

        #region Functions
        public async Task InitAsyncMethods()
        {
            bool success = await AppService.GetInstance().GetCoursesFromFirebaseAsync();
            if (!success)
            {
                // TODO: handle error
                // ErrLabelMsg.Text = errMsg
                return;
            }
            Courses = new ObservableCollection<Course>(AppService.GetInstance().GetCourses());
        }
        #endregion
        // In a common app this function would be called from a dedicated page

    }
}
