using MvvmCrossSample.Core.Commands;
using MvvmCrossSample.Core.Commands.Actions;
using MvvmCrossSample.Core.Factories.Contracts;
using MvvmCrossSample.Core.Models;

namespace MvvmCrossSample.Core.Factories
{
    public class DownloadFactory : IDownloadFactory
    {
        public Download Create(string url)
        {
            var action = new DownloadUrlAction();
            var commandBuilder = new DownloadCommandBuilder(action);
            var download = new Download(url, commandBuilder);
            return download;
        }
    }
}
