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
        
        // ����� ���� �� ���� ��� ������ ������� ����� ���
        var loginPage = new LoginPage();

        // ����� ������
        await Navigation.PushAsync(loginPage);
    }


}