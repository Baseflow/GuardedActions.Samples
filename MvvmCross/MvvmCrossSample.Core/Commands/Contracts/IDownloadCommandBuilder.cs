using GuardedActions.Commands.Contracts;
using MvvmCrossSample.Core.Models;

namespace MvvmCrossSample.Core.Commands.Contracts
{
    public interface IDownloadCommandBuilder : IAsyncGuardedDataContextCommandBuilder<Download>
    {
    }
}
