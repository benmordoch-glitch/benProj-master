using benProj.Views;

namespace benProj
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new AboutMe();
            //MainPage = new PlayGround();
            MainPage = new RegisterPage();

        }
    }
}
