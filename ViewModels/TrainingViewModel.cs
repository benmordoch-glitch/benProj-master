using benProj.Components;
using benProj.Models;
using benProj.Service;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using benProj.Components;

namespace benProj.ViewModels
{
    class TrainingViewModel : ViewModelBase
    {
        private ObservableCollection<Training> trainings;
        public ObservableCollection<Training> Trainings
        {
            get { return trainings; }
            set
            {
                trainings = value;
                OnPropertyChanged();
            }
        }
        private List<string> coursesOption;

        public List<string> CoursesOption
        {
            get { return 
                    coursesOption; }
            set { coursesOption = value;
                OnPropertyChanged();
            }
        }


        // public ICommand AlertNewCourseCommand { get; set; }
        public TrainingViewModel()
        {
            InitAsyncMethods();
            //AlertNewCourseCommand = new Command(async () => await GoToRegister());
        }
        #region Functions


       
        public async Task InitAsyncMethods()
        {
            CoursesOption = AppService.GetInstance().GetCoursesForPicker();
            List <Training> t = await AppService.GetInstance().GetTrainingsFromFirebaseAsync();
            Trainings = new ObservableCollection<Training>(t);

        }
        #endregion
    }


}