using benProj.ViewModels;

namespace benProj.Views;

public partial class PersonalGoal : ContentPage
{
	public PersonalGoal()
	{
		InitializeComponent();
        BindingContext = new PersonalGoalViewModel();
    }
}