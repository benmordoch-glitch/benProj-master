using benProj.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.ViewModels
{
    class UserInfoViewModel : ViewModelBase
    {
        private string fullName;
        public string FullName
        {
            get {
                return fullName;
            }
            set
            {
                fullName = value;
                OnPropertyChanged();

            }
        }



        private string entryTimeRunning;
        public string EntryTimeRunning
        {
            get { return entryTimeRunning; }
            set { entryTimeRunning = value; }
        }
        private int myVar;


        private string entryGoal = string.Empty;
        public string EntryGoal
        {
            get { return entryGoal; }
            set
            {
                entryGoal = value;
                OnPropertyChanged();

            }
        }
        private int entryStartWeight;
        public int EntryStartWeight
        {
            get { return entryStartWeight; }
            set
            {
                entryStartWeight = value;
                OnPropertyChanged();
            }
        }

        public UserInfoViewModel()
        {
            FullName =  AppService.GetInstance().fullDetaillsLoggedInUser.privateName + " " + AppService.GetInstance().fullDetaillsLoggedInUser.familyName;
        }
    }

}
