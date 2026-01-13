using benProj.ViewModels;

namespace benProj.Views;

public partial class TrainingListPage : ContentPage
{
	public TrainingListPage()
	{
		InitializeComponent();
        BindingContext = new TrainingViewModel();
    }
}