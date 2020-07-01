using System;
using System.Reflection;
using GuardedActions.Extensions;
using GuardedActions.NetCore;
using GuardedActions.NetCore.Extensions;
using NetCoreSample.Core.Factories;
using NetCoreSample.Core.Factories.Contracts;
using NetCoreSample.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;
using NetCoreSample.Core.Services.Contracts;
using NetCoreSample.Services;
using Acr.UserDialogs;

namespace NetCoreSample
{
    public class Startup
    {
        public static IServiceProvider Services { get; set; }

        public static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.appsettings.json");

            var iocSetup = new GuardedActionIoCSetup();

#pragma warning disable IDISP001 // Dispose created.
            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    c.AddJsonStream(stream);
                })
                .ConfigureLogging((l) => l.AddConsole(o =>
                {
                    o.DisableColors = true;
                }))
                .ConfigureServices(ConfigureServices)
                .ConfigureGuardedActions(iocSetup, nameof(NetCoreSample))
                .Build()
                .ConnectGuardedActions(iocSetup);
#pragma warning restore IDISP001 // Dispose created.

            //Save our service provider so we can use it later.
            Services = host.Services;
        }

        private static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection serviceCollection)
        {
            ConfigureViewModels(serviceCollection);
            ConfigureFactories(serviceCollection);
            ConfigureServices(serviceCollection);
        }

        private static void ConfigureViewModels(IServiceCollection serviceCollection)
        {
            foreach (var viewModel in AppDomain.CurrentDomain.GetAssemblies().GetCreatableTypes(typeof(BaseViewModel)))
            {
                serviceCollection.AddTransient(viewModel);
            }
        }

        private static void ConfigureFactories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDownloadFactory, DownloadFactory>();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton((_) => UserDialogs.Instance);
            serviceCollection.AddSingleton<IDialogService, DialogService>();
            serviceCollection.AddSingleton<IFileService, FileService>();
        }
    }
}
