using GuardedActions.Commands.Actions.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands.Actions.Contracts
{
    public interface IDownloadUrlAction : IGuardedDataContextAction<Download>
    {
    }
}
