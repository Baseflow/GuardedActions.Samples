using GuardedActions.Commands.Actions.Contracts;

namespace NetCoreSample.Core.Actions.DownloadableUrl.Contracts
{
    public interface ISaveDownloadAction : IGuardedDataContextAction<Models.DownloadableUrl>
    {
    }
}
