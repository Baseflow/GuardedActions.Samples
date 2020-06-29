using NetCoreSample.Pages;
using Xamarin.Forms;

namespace NetCoreSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Startup.Init();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
