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

        private string pathName;

        public string PathName
        {
            get { return pathName; }
            set {
                pathName = value;
                OnPropertyChanged(nameof(PathName));
            }
        }

        private double pathDistance;

        public double PathDistance
        {
            get { return pathDistance; }
            set {
                pathDistance = value;
                OnPropertyChanged(nameof(PathDistance));
            }
        }

        private int pathDifficulty;

        public int PathDifficulty
        {
            get { return pathDifficulty; }
            set {
                pathDifficulty = value;
                OnPropertyChanged(nameof(PathDifficulty));
            }
        }



        #region commands
        public ICommand DeleteItemCommand { get; set; }
        public ICommand AddCourseCommand { get; set; }

        //  public ICommand AddMessageCommand { get; set; }
        #endregion

        public CoursViewModel()
        {

            Courses = new ObservableCollection<Cours>(AppService.GetInstance().Getcourses());

            DeleteItemCommand = new Command((item) => DeleteItem(item)); // Currently this is a sync function , we will change it to async later
            AddCourseCommand = new Command(AddItem); // Currently this is a sync function , we will change it to async later
        }

        #region Functions
        public void DeleteItem(object obgMsg)
        {
            Cours c = (Cours)obgMsg;
            bool tf = AppService.GetInstance().DeleteCourse(c);
            if (tf)
            {
                Courses.Remove(c);
            }
        }
        public void AddItem()
        {
            Cours c = new Cours()
            {
                Distance = PathDistance,
                CourseName = PathName,
                Difficulty= PathDifficulty
            };
            bool tf = AppService.GetInstance().AddCourse(c);
            if (tf)
            {
                Courses.Add(c);
            }
        }

        #endregion

        // In a common app this function would be called from a dedicated page

    }
}
