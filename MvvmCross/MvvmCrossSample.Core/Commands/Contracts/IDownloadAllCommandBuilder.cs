using GuardedActions.Commands.Contracts;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Core.Commands.Contracts
{
    public interface IDownloadAllCommandBuilder : IAsyncGuardedDataContextCommandBuilder<MainViewModel>
    {
    }
}
