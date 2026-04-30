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
using System.Windows.Input;
//using benProj.Components;

namespace benProj.ViewModels
{
    [QueryProperty(nameof(SelectedCourse), "Filter")]
    class TrainingViewModel : ViewModelBase
    {
        private string TextForAllCourses = "All Courses";
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
            get
            {
                return
                    coursesOption;
            }
            set
            {
                coursesOption = value;
                OnPropertyChanged();
            }
        }
       

        public string Filter
        {
     
            set
            {
                if (Trainings != null)
                {
                    SelectedCourse = value;
                }

            }
        }
        private string selectedCourse;
        public string SelectedCourse
        {
            get
            {
                return selectedCourse;
            }
            set
            {
                if (selectedCourse == value)
                    return;

                selectedCourse = value;

                if (value == TextForAllCourses)
                {
                    List<Training> tempTrain = AppService.GetInstance().GetAllTrainingFromMemory();
                    Trainings = new ObservableCollection<Training>(tempTrain);
                }
                else
                {
                    List<Training> tempTrain = AppService.GetInstance().GetFilteredTraining(selectedCourse);
                    Trainings = new ObservableCollection<Training>(tempTrain);
                }

                OnPropertyChanged();
            }
        }

        //public ICommand TrainingSelectedCommand { get; }
        // public ICommand AlertNewCourseCommand { get; set; }
        public TrainingViewModel()
        {
            //TrainingSelectedCommand = new Command<Training>(OnTrainingSelected);
            InitAsyncMethods();

            //AlertNewCourseCommand = new Command(async () => await GoToRegister());

        }
        #region Functions


        public async Task InitAsyncMethods()
        {
            CoursesOption = AppService.GetInstance().GetCoursesForPicker();         
            List<Training> t = await AppService.GetInstance().GetTrainingsFromFirebaseAsync();
            Trainings = new ObservableCollection<Training>(t);

            SelectedCourse = TextForAllCourses;
         


        }

        //private async void OnTrainingSelected(Training training)
        //{
        //    if (training == null)
        //        return;

        //    // מעבר עמוד עם פרמטר
        //    await Shell.Current.GoToAsync($"trainingListPage?courseName={training.CourseRef.CourseName}");
        //}

        #endregion
    }


}