using benProj.ViewModels;

namespace benProj.Views;

public partial class Paths : ContentPage
{
	public Paths()
	{
		InitializeComponent();
        BindingContext = new PathViewModel();
    }
}