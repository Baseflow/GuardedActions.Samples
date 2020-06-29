using GuardedActions.MvvmCross;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCrossSample.Core.Factories;
using MvvmCrossSample.Core.Factories.Contracts;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Core
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            ConfigureIoC();

            RegisterAppStart<MainViewModel>();
        }

        private void ConfigureIoC()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IDownloadFactory>(new DownloadFactory());

            new GuardedActionIoCSetup().Configure(Mvx.IoCProvider, nameof(MvvmCrossSample));
        }
    }
}
