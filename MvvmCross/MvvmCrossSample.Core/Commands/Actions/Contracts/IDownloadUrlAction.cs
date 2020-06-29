using GuardedActions.Commands.Actions.Contracts;
using MvvmCrossSample.Core.Models;

namespace MvvmCrossSample.Core.Commands.Actions.Contracts
{
    public interface IDownloadUrlAction : IGuardedDataContextAction<Download>
    {
    }
}
