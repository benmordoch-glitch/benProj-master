using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace benProj.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {

        private string entryUserName;
        public string EntryPrivateName
        {
            get { return entryUserName; }
            set {
                if (value != null)
                {
                    entryUserName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorUserName;
        public string LblErrorUsereName
        {
            get { return lblErrorUserName; }
            set {
                if (value != null)
                {
                    lblErrorUserName = value;
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
                    OnPropertyChanged();
                }
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get { return passwordError; }
            set { 
                if(value != null)   
                passwordError = value;
                OnPropertyChanged();
            }
        }


        private bool showPassword;
        public bool ShowPassword
        {
            get { return showPassword; }
            set {             
                showPassword = value;
                OnPropertyChanged();
                }
        }


        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set {
                isValid = value;
                OnPropertyChanged();
            }
        }
        //// הצבת הנתונים שהתקבלו ב-Label
        //WelcomeLabel.Text = $"ברוך הבא, {userName}!";

        public LoginViewModel()
        {
            ShowPassword = false;
            IsValid = false;
        }



       // private bool isValid;
        //public LoginPage()
        //{
        //    InitializeComponent();
        //    EntryPrivateName.Text = "";
        //    EntryPassword.Text = "";
        //}
        //private void ResetErrors()
        //{
        //    EntryPrivateName.Text = "";
        //    LblErrorPassword.Text = "";
        //}
        //private void ButtonRegister_Clicked(object sender, EventArgs e)
        //{
        //    ResetErrors();
        //    isValid = true;

        //    if (EntryPrivateName.Text.Length < 5)
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
    }
}
