using GuardedActions.IoC;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Factories.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Factories
{
    public class DownloadFactory : IDownloadFactory
    {
        public DownloadableUrl Create(string url)
        {
            var commandBuilder = IoCRegistration.Instance.GetService<IDownloadCommandBuilder>();

            var download = new DownloadableUrl(url, commandBuilder);
            return download;
        }
    }
}
