using benProj.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace benProj.ViewModels
{
    internal class RegisterViewModel : ViewModelBase
    {

        #region Get&Set
        private string entryPrivateName;
		public string EntryPrivateName
        {
			get { return entryPrivateName; }
			set
			{
				if (value != null)
				{
					entryPrivateName = value;
                    OnPropertyChanged();
                }
			}
		}

		private string lblErrorPrivateName;

		public string LblErrorPrivateName
        {
			get { return lblErrorPrivateName; }
			set
			{
				if (value != null)
				{ 
					lblErrorPrivateName = value; 
					OnPropertyChanged(); }
			}
		}

        private string entryFamilyName;
        public string EntryFamilyName
        {
            get { return entryFamilyName; }
            set
            {
                if (value != null)
                {
                    entryFamilyName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorFamilyName;  
        public string LblErrorFamilyName
        {
            get { return lblErrorFamilyName; }
            set
            {
                if (value != null)
                {
                    lblErrorFamilyName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string entryUserName;
        public string EntryUserName
        {
            get { return entryUserName; }
            set {
                if (value != null)
                {
                    entryUserName = value; OnPropertyChanged();
                }
            }
        }

        private string lblErrorUserName;
        public string LblErrorUserName
        {
            get { return lblErrorUserName; }
            set
            {
                if (value != null)
                {
                    lblErrorUserName = value; OnPropertyChanged();
                }
            }
        }

        private string entryEmail;
        public string EntryEmail
        {
            get { return entryEmail; }
            set
            {
                if (value != null)
                {
                    entryEmail = value; OnPropertyChanged();
                }
            }
        }
        
        private string lblErrorEmail;
        public string LblErrorEmail
        {
            get { return lblErrorEmail; }
            set
            {
                if (value != null)
                {
                    lblErrorEmail = value; OnPropertyChanged();
                }
            }
        }

        private DatePicker entryBirthDate;
        public DatePicker EntryBirthDate
        {
            get { return entryBirthDate; }
            set
            {
                if (value != null)
                {
                    entryBirthDate = value; OnPropertyChanged();
                }
            }
        }

        private DatePicker errorBirthDate;
        public DatePicker ErrorBirthDate
        {
            get { return errorBirthDate; }
            set
            {
                if (value != null)
                {
                    errorBirthDate = value; OnPropertyChanged();
                }
            }
        }

        private string entryPassword;
        public string EntryPassword
        {
            get { return entryPassword; }
            set {
                if (value != null)
                {
                    entryPassword = value; OnPropertyChanged();
                }
            }
        }

        private string errorPassword;
        public string ErrorPassword
        {
            get { return errorPassword; }
            set
            {
                if (value != null)
                {
                    errorPassword = value; OnPropertyChanged();
                }
            }
        }

        private string seePassword;
        public string SeePassword
        {
            get { return seePassword; }
            set
            {
                if (value != null)
                {
                    seePassword = value; OnPropertyChanged();
                }
               
            }
        }

        private string reTypePass;
        public string ReTypePass
        {
            get { return reTypePass; }
            set
            {
                if (value != null)
                {
                    reTypePass = value; OnPropertyChanged();
                }
            }
        }
        private string footer;
        public string Footer
        {
            get { return footer; }
            set
            {
                if (value != null)
                {
                    footer = value; OnPropertyChanged();
                }
            }
        }
        // get and set for MessageForBen
        private string messageForBen;
        public string MessageForBen
        {
            get { return messageForBen; }
            set
            {
                if (value != null)
                {
                    messageForBen = value;
                    OnPropertyChanged();
                }
            }
        }
      
        #endregion

        public ICommand ResetCommand { get; set; }
        public ICommand GotoLoginCommand { get; set; }


        // constructor
        public RegisterViewModel()
        {
            //ButtonResetCommand = new Command(ResetField);
            GotoLoginCommand = new Command(async () => await GoToLogin());
            ResetCommand = new Command(ResetField);
        }

        public async Task GoToLogin()
        {
            // יצירת מופע של המסך הבא והעברת הנתונים בבנאי שלו
            var loginPage = new LoginPage();

            // ביצוע הניווט
            await Application.Current.MainPage.Navigation.PushAsync(loginPage);
        }
        private void ResetField()
        {
            EntryPrivateName = "";
            EntryFamilyName = "";
            EntryUserName = "";
            EntryEmail = "";
            EntryPassword = "";
            ReTypePass = "";
            EntryBirthDate.Date = DateTime.Now;

        }

        //private void OnSaveButtonClicked(object sender, EventArgs e)
        //{
        //    // לקיחת הנתונים משדה הקלט
        //    string userName = UserNameEntry.Text;

        //    // בדיקה אם שדה הקלט ריק
        //    if (string.IsNullOrWhiteSpace(userName))
        //    {
        //        DisplayAlert("שגיאה", "נא להכניס שם", "אישור");
        //    }
        //    else
        //    {
        //        // הצגת הודעה עם הנתונים שנשמרו
        //        DisplayAlert("הנתונים נשמרו", $"שלום, {userName}!", "אישור");
        //    }
        //}

        //private async void OnNavigateButtonClicked(object sender, EventArgs e)
        //{
        //    // לקיחת הנתונים משדה הקלט לפני המעבר
        //    string userName = NameEntry.Text;

        //    // בדיקה שוב כדי לוודא שיש נתונים לפני הניווט
        //    if (string.IsNullOrWhiteSpace(userName))
        //    {
        //        await DisplayAlert("שגיאה", "נא להכניס שם לפני המעבר", "אישור");
        //        return;
        //    }

        //    // יצירת מופע של המסך הבא והעברת הנתונים בבנאי שלו
        //    var secondPage = new SecondPage(userName);

        //    // ביצוע הניווט
        //    await Navigation.PushAsync(secondPage);
        //}










        


        //private void ResetErrors()
        //{
        //    LblErrorPrivateName.Text = "";
        //    LblErrorPassword.Text = "";
        //}
        //private void ButtonRegister_Clicked(object sender, EventArgs e)
        //{
        //    ResetErrors();
        //    isValid = true;

        //    if (EntryUserName.Text.Length < 5)
        //    {
        //        LblErrorPrivateName.Text = "Too short must be above 5 chars";
        //        isValid = false;
        //    }

        //    string pattern = @"^(?=.*[A-Z])(?=.*@).{8,}$";
        //    bool isPasswordOk = Regex.IsMatch(EntryPassword.Text, pattern);

        //    if (!isPasswordOk)
        //    {
        //        LblErrorPassword.Text = "Password must be at least 8 chars, contain an uppercase letter and a special char (@)";
        //        isValid = false;
        //    }

        //}
        //private void Button_TogglePassword_Clicked(object sender, EventArgs e)
        //{
        //    EntryPassword.IsPassword = !EntryPassword.IsPassword;
        //}
        //// Button_GoToLogin_Clicked
        //private void Button_GoToLogin_Clicked(object sender, EventArgs e)
        //{
        //    AppService sr = AppService.GetInstance();
        //    sr.Name = EntryUserName.Text;
        //    sr.FamilyName = EntryFamilyName.Text;
        //    sr.UserName = EntryUserName.Text;
        //    sr.Password = EntryPassword.Text;
        //    sr.BirthDate = new DateOnly(EntryBirthDate.Date.Year, EntryBirthDate.Date.Month, EntryBirthDate.Date.Day);
        //}
        //private async void ButtonlinkToLogin_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new LoginPage());
        //}
    }
}
