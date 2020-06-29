using GuardedActions.Commands.Actions.Contracts;
using MvvmCrossSample.Core.ViewModels;

namespace MvvmCrossSample.Core.Commands.Actions.Contracts
{
    public interface IPullDownloadListAction : IGuardedDataContextAction<MainViewModel>
    {
    }
}
