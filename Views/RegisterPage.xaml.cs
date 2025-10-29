namespace benProj.Views;

using benProj.Service;
using benProj.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Input;

public partial class RegisterPage : ContentPage
{
    public ICommand GotoLoginCommand { get; set; }
    //private bool isValid;
    public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel();
    }

}