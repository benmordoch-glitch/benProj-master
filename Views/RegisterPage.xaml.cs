namespace benProj.Views;

using benProj.Service;
using benProj.ViewModels;
using System.Text.RegularExpressions;

public partial class RegisterPage : ContentPage
{
    //private bool isValid;
    public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
    public async void OnGoToLoginButtonClicked(object sender, EventArgs e)
    {
        
        // יצירת מופע של המסך הבא והעברת הנתונים בבנאי שלו
        var loginPage = new LoginPage();

        // ביצוע הניווט
        await Navigation.PushAsync(loginPage);
    }


}