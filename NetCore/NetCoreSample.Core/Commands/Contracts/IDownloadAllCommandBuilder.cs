using GuardedActions.Commands.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands.Contracts
{
    public interface IDownloadAllCommandBuilder : IAsyncGuardedDataContextCommandBuilder<MainViewModel>
    {
    }
}
