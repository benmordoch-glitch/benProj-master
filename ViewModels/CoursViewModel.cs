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

        #region commands
        public ICommand DeleteItemCommand { get; set; }
        //  public ICommand AddMessageCommand { get; set; }
        #endregion

        public CoursViewModel()
        {

            Courses = new ObservableCollection<Cours>(AppService.GetInstance().Getcourses());

            DeleteItemCommand = new Command((item) => DeleteItem(item)); // Currently this is a sync function , we will change it to async later
            //AddCouCommand = new Command(AddMessage); // Currently this is a sync function , we will change it to async later
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
        #endregion

        // In a common app this function would be called from a dedicated page

    }
}
