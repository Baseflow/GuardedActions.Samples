using GuardedActions.Commands.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands.Contracts
{
    public interface IDownloadCommandBuilder : IAsyncGuardedDataContextCommandBuilder<Download>
    {
    }
}
