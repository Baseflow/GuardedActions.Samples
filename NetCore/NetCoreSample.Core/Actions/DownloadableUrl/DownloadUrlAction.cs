using System;
using System.Net.Http;
using System.Threading.Tasks;
using GuardedActions.Commands.Actions;
using NetCoreSample.Core.Actions.DownloadableUrl.Contracts;
using NetCoreSample.Core.Enums;

namespace NetCoreSample.Core.Actions.DownloadableUrl
{
    public class DownloadUrlAction : GuardedDataContextAction<Models.DownloadableUrl>, IDownloadUrlAction
    {
        protected override async Task Execute()
        {
            DataContext.State = DownloadableUrlState.Downloading;

            var url = new Uri(DataContext.Url, UriKind.Absolute);

            using var client = new HttpClient();

            DataContext.Data = await client.GetByteArrayAsync(url);
        }
    }
}
