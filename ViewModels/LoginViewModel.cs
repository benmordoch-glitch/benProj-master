using benProj.Service;
using benProj.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace benProj.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        #region get and set

        private bool isLoginEnable;
        public bool IsLoginEnable
        {
            get { return isLoginEnable; }
            set
            {
                isLoginEnable =! value;
                OnPropertyChanged();
            }
        }

        private string entryUserName;
        public string EntryUserName
        {
            get { return entryUserName; }
            set
            {
                if (value != null)
                {

                    entryUserName = value;
                    if (value.Length < 2)
                    {
                        LblErrorUserName = "User Name too short";
                    }
                    else
                    {
                        LblErrorUserName = "";
                    }
                    HandleButtonLogin();
                    OnPropertyChanged();
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

                    lblErrorUserName = value;
                    HandleButtonLogin();
                    OnPropertyChanged();
                }
            }
        }

        private string passwordEntry = string.Empty;
        public string PasswordEntry
        {
            get { return passwordEntry; }
            set
            {
                if (value != null)
                {
                    passwordEntry = value;
                    string pattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
                    bool isPasswordOk = Regex.IsMatch(value, pattern);
                    if (!isPasswordOk)
                    {
                        PasswordError = "Password not valid!";
                    }
                    else
                    {
                        PasswordError = "";
                    }
                    HandleButtonLogin();
                    OnPropertyChanged();
                }
            }
        }

        private string passwordError;
        public string PasswordError
        {
            get { return passwordError; }
            set
            {
                if (value != null)
                    passwordError = value;
                HandleButtonLogin();
                OnPropertyChanged();
            }
        }


        private bool showPassword;
        public bool ShowPassword
        {
            get { return showPassword; }
            set
            {
                showPassword = value;
                HandleButtonLogin();
                OnPropertyChanged();
            }
        }


        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set
            {
                isValid = value;

                OnPropertyChanged();
            }
        }
        #endregion
        #region command declaration
        public ICommand GoToRegisterCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand EnterAppCommand { get; set; }
        public ICommand ViewPassCommand { get; set; }

        #endregion
        //// הצבת הנתונים שהתקבלו ב-Label
        //WelcomeLabel.Text = $"ברוך הבא, {userName}!";
        // constructor


        public LoginViewModel()
        {

            GoToRegisterCommand = new Command(async () => await GoToRegister());
            ResetCommand = new Command(ResetField);
            EnterAppCommand = new Command(async () => await TryLogin());
            ViewPassCommand = new Command(() =>
                {
                    ShowPassword = !ShowPassword;
                });
            IsLoginEnable = true;
            ShowPassword = true;
        }

        private void ResetField()
        {
            EntryUserName = string.Empty;
            PasswordEntry = string.Empty;
            LblErrorUserName = string.Empty;
            PasswordError = string.Empty;


        }
        private void HandleButtonLogin()
        {
            IsLoginEnable = true;
            //if (string.Empty.Equals(LblErrorUserName) &&
            //    string.Empty.Equals(PasswordError) )
            //{
            //    IsLoginEnable = false;
            //}
            //else
            //{
            //    IsLoginEnable = true;
            //}
        }


        public async Task GoToRegister()
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }
        private async Task TryLogin()
        {
            Console.WriteLine(  333);
            if (await AppService.GetInstance().TryLoginAsync(EntryUserName, PasswordEntry))
            {
                LblErrorUserName = "It works";
                await Shell.Current.GoToAsync("//CoursePage");
            }
            else
            {
                LblErrorUserName = "zibi";
            }
        }

    }
}
