using benProj.Models;
using benProj.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       

        public TrainingViewModel()
        {
            InitAsyncMethods();
        }
        #region Functions
        public async Task InitAsyncMethods()
        {
            List<Training> t = await AppService.GetInstance().GetTrainingsFromFirebaseAsync();
            Trainings = new ObservableCollection<Training>(t);
        }
        #endregion
    }


}