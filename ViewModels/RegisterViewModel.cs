using benProj.Views;
using benProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using benProj.Service;


namespace benProj.ViewModels
{
    internal class RegisterViewModel : ViewModelBase
    {

        #region Get&Set
        private bool isRegisterEnable;
        public bool IsRegisterEnable
        {
            get { return isRegisterEnable; }
            set
            {
                isRegisterEnable =! value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// RegisterField
        /// </summary>

        private string entryPrivateName = string.Empty;
        public string EntryPrivateName
        {
            get { return entryPrivateName; }
            set
            {
                if (value != null)
                {
                    entryPrivateName = value;
                    if (value.Length < 2)
                    {
                        LblErrorPrivateName = "Private Name too Short";
                    }
                    else
                    {
                        LblErrorPrivateName = "";
                    }
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorPrivateName = string.Empty;
        public string LblErrorPrivateName
        {
            get { return lblErrorPrivateName; }
            set
            {
                if (value != null)
                {

                    lblErrorPrivateName = value;
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// PrivateNameField
        /// </summary>


        private string entryFamilyName = string.Empty;
        public string EntryFamilyName
        {
            get { return entryFamilyName; }
            set
            {
                if (value != null)
                {
                    entryFamilyName = value;

                    if (value.Length < 2)
                    {
                        LblErrorFamilyName = "Family Name too short";
                    }
                    else
                    {
                        LblErrorFamilyName = "";
                    }
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorFamilyName = string.Empty;
        public string LblErrorFamilyName
        {
            get { return lblErrorFamilyName; }
            set
            {
                if (value != null)
                {
                    lblErrorFamilyName = value;
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// FamilyNameField
        /// </summary>

        private string entryUserName = string.Empty;
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
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorUserName = string.Empty;
        public string LblErrorUserName
        {
            get { return lblErrorUserName; }
            set
            {
                if (value != null)
                {
                    lblErrorUserName = value;
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// UserNameField
        /// </summary>


        private string entryEmail = string.Empty;
        public string EntryEmail
        {
            get { return entryEmail; }
            set
            {
                if (value != null)
                {
                    entryEmail = value;
                   
                    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                    bool isPasswordOk = Regex.IsMatch(entryEmail, pattern);
                    if (!(isPasswordOk || value == string.Empty))
                    {
                        LblErrorEmail = "Email not valid!";
                    }
                    else
                    {
                        LblErrorEmail = string.Empty;
                    }
                   
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string lblErrorEmail = string.Empty;
        public string LblErrorEmail
        {
            get { return lblErrorEmail; }
            set
            {
                if (value != null)
                {
                    lblErrorEmail = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// FamilyNameField
        /// </summary>

        private DatePicker entryBirthDate;
        public DatePicker EntryBirthDate
        {
            get { return entryBirthDate; }
            set
            {
                entryBirthDate = value;
                OnPropertyChanged();
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
        /// <summary>
        /// FamilyNameField
        /// </summary>


        private string entryPassword = string.Empty;
        public string EntryPassword
        {
            get { return entryPassword; }
            set
            {
                if (value != null)
                {
                    entryPassword = value;
                    string pattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
                    bool isPasswordOk = Regex.IsMatch(value, pattern) ;
                    if (!(isPasswordOk || value == string.Empty) )
                    {
                        ErrorPassword = "Password not valid!";
                    }
                    else
                    {
                        ErrorPassword = "";
                    }
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string errorPassword = string.Empty;
        public string ErrorPassword
        {
            get { return errorPassword; }
            set
            {
                if (value != null)
                {
                    errorPassword = value;
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// FamilyNameField
        /// </summary>

        private bool hidePass;
        public bool HidePass
        {
            get { return hidePass; }
            set
            {
                hidePass = value;
                HandleButtonRegister();
                OnPropertyChanged();
            }
        }

        private string reTypePass = string.Empty;
        public string ReTypePass
        {
            get { return reTypePass; }
            set
            {
                if (value != null)
                {
                    reTypePass = value;
                    if (reTypePass != entryPassword)
                        ErrorReTypePass = "Password not identical!";
                    else
                    {
                        ErrorReTypePass = "";
                    }
                    HandleButtonRegister();
                    OnPropertyChanged();
                }
            }
        }

        private string errorReTypePass = string.Empty;

        public string ErrorReTypePass
        {
            get { return errorReTypePass; }
            set
            {
                if (value != null)
                {
                    errorReTypePass = value;
                    OnPropertyChanged();
                }
                
            }
        }

        private string footer;
        /// <summary>
        /// FamilyNameField
        /// </summary>
        /// 
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

        #endregion

        public ICommand ResetCommand { get; set; }
        public ICommand GoToLoginCommand { get; set; }
        public ICommand TryRegisterCommand { get; set; }

        public ICommand ShowPassCommand { get; set; }


        // constructor
        public RegisterViewModel()
        {
            GoToLoginCommand = new Command(async () => await GoToLogin());
            ResetCommand = new Command(ResetField);
            TryRegisterCommand = new Command(TryRegister);
            ShowPassCommand = new Command(() =>
            {
                HidePass = !HidePass;
            });
            IsRegisterEnable = true;

            HidePass = true;
        }

        public async Task GoToLogin()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private void ResetField()
        {
            EntryPrivateName = string.Empty;
            LblErrorPrivateName = string.Empty;
            EntryFamilyName = string.Empty;
            LblErrorFamilyName = string.Empty;
            EntryUserName = string.Empty;
            LblErrorUserName = string.Empty;
            EntryEmail = string.Empty;
            LblErrorEmail = string.Empty;
            EntryPassword = string.Empty;
            errorPassword = string.Empty;
            ReTypePass = string.Empty;
            errorReTypePass = string.Empty;
            //TODO try to fix
            //EntryBirthDate.Date = new DateTime(2018, 6, 21);

        }

        /// <summary>
        /// check if can Register
        /// </summary>
        private void HandleButtonRegister()
        {
            if (string.Empty.Equals(LblErrorPrivateName) &&
                string.Empty.Equals(LblErrorFamilyName) &&
                string.Empty.Equals(LblErrorUserName )&&
                string.Empty.Equals(LblErrorEmail)&&
                string.Empty.Equals(ErrorPassword)&&  
                string.Empty.Equals(ErrorReTypePass))
            {
                IsRegisterEnable = false;
            }
            else
            {
                IsRegisterEnable = true;
            }
        }

        private void TryRegister()
        {
            if (IsRegisterEnable)
            {
                User u = new User() { UserName = EntryUserName, Password = EntryPassword };
                AppService.GetInstance().AddRegisteredUser(u);
            }
            
        }


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
