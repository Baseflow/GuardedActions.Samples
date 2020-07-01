using System;
using System.Net.Http;
using System.Threading.Tasks;
using GuardedActions.Commands.Actions;
using NetCoreSample.Core.Commands.Actions.Contracts;
using NetCoreSample.Core.Enums;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands.Actions
{
    public class DownloadUrlAction : GuardedDataContextAction<DownloadableUrl>, IDownloadUrlAction
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
