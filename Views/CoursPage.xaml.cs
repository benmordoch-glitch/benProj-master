using benProj.ViewModels;

namespace benProj.Views;

public partial class CoursPage : ContentPage
{
	public CoursPage()
	{
		InitializeComponent();
		BindingContext = new CoursViewModel();

    }
}