using benProj.Models;
using benProj.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace benProj.ViewModels
{
    class PersonalGoalViewModel : ViewModelBase
    {
        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                OnPropertyChanged();

            }
        }



        //private string entryTimeRunning;
        //public string EntryTimeRunning
        //{
        //    get { return entryTimeRunning; }
        //    set { entryTimeRunning = value; }
        //}


        private string entryGoal;
        public string EntryGoal
        {
            get { return entryGoal; }
            set
            {
                entryGoal = value;
                OnPropertyChanged();

            }
        }

        private string entryWeight;
        public string EntryWeight
        {
            get { return entryWeight; }
            set
            {
                entryWeight = value;
                OnPropertyChanged();
            }
        }

        private string entryImprovingWhat;
        public string EntryImprovingWhat
        {
            get { return entryImprovingWhat; }
            set
            {
                entryImprovingWhat = value;
                OnPropertyChanged();

            }
        }

        //private string entryRunFailes = string.Empty;
        //public string EntryRunFailes
        //{
        //    get { return entryRunFailes; }
        //    set
        //    {
        //        entryRunFailes = value;
        //        OnPropertyChanged();

        //    }
        //}

        //private string entryHowKnowUs;
        //public string EntryHowKnowUs
        //{
        //    get { return entryHowKnowUs; }
        //    set
        //    {
        //        entryHowKnowUs = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ICommand SendCmd { get; set; }

        public PersonalGoalViewModel()
        {
            FullName = AppService.GetInstance().fullDetaillsLoggedInUser.privateName + " " + AppService.GetInstance().fullDetaillsLoggedInUser.familyName;

            SendCmd = new Command(async () =>
            {
                PersonalGoalInfo personalGoalInfo = new()
                {
                    Goal = EntryGoal,
                    Weight = EntryWeight,
                    Improving = EntryImprovingWhat,
                };

                await AppService.GetInstance().SetPersonalGoal(personalGoalInfo);
            });
            //int weight;
            //bool valid = int.TryParse(EntryStartWeight, out weight);
        }
    }
}
