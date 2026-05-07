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
                isLoginEnable = !value;
                OnPropertyChanged();
            }
        }

        private string emailEntry;
        public string EmailEntry
        {
            get { return emailEntry; }
            set
            {
                if (value != null)
                {

                    emailEntry = value;
                    if (value.Length < 2)
                    {
                        LblErrorEmail = "Email too short";
                    }
                    else
                    {
                        LblErrorEmail = "";
                    }
                    HandleButtonLogin();
                    OnPropertyChanged();
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

                    lblErrorEmail = value;
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
                    HandleButtonLogin();
                    OnPropertyChanged();
                }
            }
        }

        //private string passwordEntry = string.Empty;
        //public string PasswordEntry
        //{
        //    get { return passwordEntry; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            passwordEntry = value;

        //            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";
        //            bool isPasswordOk = Regex.IsMatch(value, pattern);
        //            if(value != string.Empty || )

        //            if (!isPasswordOk && value != string.Empty)
        //            {
        //                PasswordError = "Password must be at least 6 characters and include uppercase, lowercase, a number, and a special character";
        //            }
        //            else
        //            {
        //                PasswordError = string.Empty;
        //            }
        //            HandleButtonLogin();
        //            OnPropertyChanged();
        //        }
        //    }
        //}

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
        #region Commands Section
        public ICommand GoToRegisterCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand EnterAppCommand { get; set; }
        public ICommand ViewPassCommand { get; set; }

        #endregion
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

            EmailEntry = "ben@gmail.com";
            PasswordEntry = "123456";
        }

        private void ResetField()
        {
            EmailEntry = string.Empty;
            PasswordEntry = string.Empty;
            LblErrorEmail = string.Empty;
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
            bool success = await AppService.GetInstance().TryLoginAsync(EmailEntry, PasswordEntry);
            if (success)
            {
                LblErrorEmail = "נכנסת בהצלחה";
                ((App)Application.Current).SetAuthenticatedShell();
                //await Shell.Current.GoToAsync("//CreatingPath");
            }
            else
            {
                LblErrorEmail = "מייל או סיסמה אינם נכונים";
            }
        }

    }
}
