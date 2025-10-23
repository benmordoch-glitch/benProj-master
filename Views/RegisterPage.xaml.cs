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
    

}