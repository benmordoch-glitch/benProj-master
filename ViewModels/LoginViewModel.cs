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

        private string entryPassword;
        public string EntryPassword
        {
            get { return entryPassword; }
            set
            {
                if (value != null)
                {
                    bool isOk = true;
                    entryPassword = value;
                    if (entryPassword.Length < 5)
                    {
                        PasswordError = "Too Short";
                        isOk = false;
                    }
                    else
                    {
                        isOk = true;
                        PasswordError = "";
                    }
                    IsValid = isOk;
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
            ShowPassword = false;
            IsValid = false;
            GoToRegisterCommand = new Command(async () => await GoToRegister());
            ResetCommand = new Command(ResetField);
            EnterAppCommand = new Command(TryLogin);
            ViewPassCommand = new Command(() =>
                {
                    ShowPassword = !ShowPassword;
                });
            IsLoginEnable = true;
            ShowPassword = true;
        }

        private void ResetField()
        {
            EntryUserName = "";
            EntryPassword = "";
            LblErrorUserName = "";
            PasswordError = "";


        }
        private void HandleButtonLogin()
        {
            if (EntryUserName != "" || EntryPassword != "" || LblErrorUserName != "" || PasswordError != "")
            {
                IsLoginEnable = false;
            }
            else
            {
                IsLoginEnable = true;
            }
        }


        public async Task GoToRegister()
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }
        private void TryLogin()
        {
            if (EntryUserName == AppService.GetInstance().GetUser().UserName && EntryPassword == AppService.GetInstance().GetUser().Password)
            {
                LblErrorUserName = "It works";
            }
            else
            {
                LblErrorUserName = "zibi";
            }
        }

    }
}
