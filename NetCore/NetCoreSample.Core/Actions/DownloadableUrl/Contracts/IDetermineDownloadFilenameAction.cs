using GuardedActions.Commands.Actions.Contracts;

namespace NetCoreSample.Core.Actions.DownloadableUrl.Contracts
{
    public interface IDetermineDownloadFilenameAction : IGuardedDataContextAction<Models.DownloadableUrl>
    {
    }
}
