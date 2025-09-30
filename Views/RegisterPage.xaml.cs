namespace benProj.Views;
using System.Text.RegularExpressions;

public partial class RegisterPage : ContentPage
{
    bool isValid;
    public RegisterPage()
	{
		InitializeComponent();
        //EntryFullName.Text = "";
        EntryPrivateName.Text = "";
        EntryPassword.Text = "";
    }
    private void ResetErrors()
    {
        LblErrorPrivateName.Text = "";
        LblErrorPassword.Text = "";
    }
    private void ButtonRegister_Clicked(object sender, EventArgs e)
    {
        ResetErrors();
        isValid = true;

        if (EntryPrivateName.Text.Length < 5)
        {
            LblErrorPrivateName.Text = "Too short must be above 5 chars";
            isValid = false;
        }

        string pattern = @"^(?=.*[A-Z])(?=.*@).{8,}$";
        bool isPasswordOk = Regex.IsMatch(EntryPassword.Text, pattern);

        if (!isPasswordOk)
        {
            LblErrorPassword.Text = "Password must be at least 8 chars, contain an uppercase letter and a special char (@)";
            isValid = false;
        }

    }
    private void Button_TogglePassword_Clicked(object sender, EventArgs e)
    {
        EntryPassword.IsPassword = !EntryPassword.IsPassword;
    }
    // Button_GoToLogin_Clicked
    private void Button_GoToLogin_Clicked(object sender, EventArgs e)
    {
        ServiceRegister sr = ServiceRegister.GetInstance();
        sr.Name = EntryPrivateName.Text;
        sr.FamilyName = EntryFamilyName.Text;
        sr.UserName = EntryUserName.Text;
        sr.Password = EntryPassword.Text;
        sr.BirthDate = new DateOnly(EntryBirthDate.Date.Year, EntryBirthDate.Date.Month, EntryBirthDate.Date.Day);
    }
    private async void ButtonlinkToLogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}