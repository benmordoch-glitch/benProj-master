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
        LblErrorFullName.Text = "";
        LblErrorPassword.Text = "";
    }
    private void ButtonRegister_Clicked(object sender, EventArgs e)
    {
        ResetErrors();
        isValid = true;

        if (EntryPrivateName.Text.Length < 5)
        {
            LblErrorFullName.Text = "Too short must be above 5 chars";
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
}