using benProj.Models;

namespace benProj.Components;

public partial class CourseDrawer : ContentView
{
	public CourseDrawer()
	{
		InitializeComponent();
    }

    public static readonly BindableProperty PointsProperty =
          BindableProperty.Create(
              propertyName: nameof(Points),
              returnType: typeof(List<Coordinate>),
              declaringType: typeof(CourseDrawer),
              defaultValue: null,
              defaultBindingMode: BindingMode.TwoWay,
              propertyChanged: OnPointsChanged
          );

    public List<Coordinate> Points
    {
        get => (List<Coordinate>)GetValue(PointsProperty);
        set => SetValue(PointsProperty, value);
    }

    private static void OnPointsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var toggleButton = (CourseDrawer)bindable;

    }
}