using NetCoreSample.Core.Commands;
using NetCoreSample.Core.Commands.Actions;
using NetCoreSample.Core.Factories.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Factories
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
