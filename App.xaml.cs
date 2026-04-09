using benProj.Views;

namespace benProj
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // default is unauthenticated shell
            MainPage = new AppShellNotAuth();
        }
        public void SetAuthenticatedShell()
        {
            MainPage = new AppShellAuth();
        }

        public void SetUnauthenticatedShell()
        {
            MainPage = new AppShellNotAuth(); ;
        }
    }   
}
