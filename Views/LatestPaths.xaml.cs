using benProj.ViewModels;

namespace benProj.Views;

public partial class LatestPaths : ContentPage
{
	public LatestPaths()
	{
		InitializeComponent();
        BindingContext = new LatestsPathsViewModel();
    }
}