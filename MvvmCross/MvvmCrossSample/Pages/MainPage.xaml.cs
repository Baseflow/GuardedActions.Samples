using System.ComponentModel;
using MvvmCross.Forms.Views;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MvxContentPage<MainViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
