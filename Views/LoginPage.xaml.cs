namespace benProj.Views;
using benProj.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

public partial class LoginPage : ContentPage
{
    public LoginPage() {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}