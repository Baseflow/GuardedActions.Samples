using GuardedActions.Commands.Actions.Contracts;

namespace NetCoreSample.Core.Actions.DownloadableUrl.Contracts
{
    public interface IDownloadUrlAction : IGuardedDataContextAction<Models.DownloadableUrl>
    {
    }
}
