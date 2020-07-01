using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GuardedActions.Commands;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Factories.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands
{
    // This is an example of a CommandBuilder without actions
    public class InitializeCommandBuilder : AsyncGuardedDataContextCommandBuilder<MainViewModel>, IInitializeCommandBuilder
    {
        private readonly IDownloadFactory _downloadFactory;

        // This is an example of a CommandBuilder without actions
        public InitializeCommandBuilder(IDownloadFactory downloadFactory)
        {
            _downloadFactory = downloadFactory ?? throw new ArgumentNullException(nameof(downloadFactory));
        }

        // This is an example of a CommandBuilder without actions
        protected override Task ExecuteCommandAction()
        {
            DataContext.Downloads = new ObservableCollection<Models.DownloadableUrl>
            {
                _downloadFactory.Create("https://www.google.com/"),
                _downloadFactory.Create("https://www.facebook.com/"),
                _downloadFactory.Create("This is not an URL")
            };
            return Task.CompletedTask;
        }
    }
}
