using benProj.ViewModels;

namespace benProj.Views;

public partial class UserInfo : ContentPage
{
	public UserInfo()
	{
		InitializeComponent();
        BindingContext = new UserInfoViewModel();
    }
}