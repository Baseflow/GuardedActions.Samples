using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCrossSample.Core;

namespace MvvmCrossSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<MvxApp, App>, MvxApp, App>
    {
    }
}
