using System.ComponentModel;
using NetCoreSample.Core.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreSample.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = Startup.Services.GetService<MainViewModel>();
        }
    }
}
