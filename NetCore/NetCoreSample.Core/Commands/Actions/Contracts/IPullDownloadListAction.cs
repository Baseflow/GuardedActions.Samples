using GuardedActions.Commands.Actions.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands.Actions.Contracts
{
    public interface IPullDownloadListAction : IGuardedDataContextAction<MainViewModel>
    {
    }
}
