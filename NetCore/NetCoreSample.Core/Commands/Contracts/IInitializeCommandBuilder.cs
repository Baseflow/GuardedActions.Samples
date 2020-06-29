using GuardedActions.Commands.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands.Contracts
{
    public interface IInitializeCommandBuilder : IAsyncGuardedDataContextCommandBuilder<MainViewModel>
    {
    }
}
