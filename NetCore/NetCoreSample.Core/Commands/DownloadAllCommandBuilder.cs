using System;
using System.Threading.Tasks;
using GuardedActions.Commands;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands
{
    public class DownloadAllCommandBuilder : AsyncGuardedDataContextCommandBuilder<MainViewModel>, IDownloadAllCommandBuilder
    {
        protected override Task ExecuteCommandAction()
        {
            throw new NotImplementedException("The download all feature has not been implemented.. yet!");
        }
    }
}
