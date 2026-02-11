using benProj.ViewModels;

namespace benProj.Views;

public partial class CoursePage : ContentPage
{
	public CoursePage()
	{
		InitializeComponent();
		BindingContext = new CourseViewModel();
		//this.Title = "айоерйннн";    
    }
}