namespace benProj.Views;
using benProj.ViewModels;
using System;
using System.Text.RegularExpressions;

public partial class LoginPage : ContentPage
{
    public LoginPage() {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}