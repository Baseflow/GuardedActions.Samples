using System.Net;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;
using MvvmCrossSample.Core.Commands.Actions.Contracts;
using MvvmCrossSample.Core.Models;

namespace MvvmCrossSample.Core.Commands.Actions.ExceptionHandlers
{
    [ExceptionHandlerFor(typeof(IDownloadUrlAction))]
    public class DownloadUrlActionWebExceptionHandler : ContextExceptionHandler<WebException, Download>
    {
        public override Task Handle(IExceptionHandlingAction<WebException, Download> exceptionHandlingAction)
        {
            if (exceptionHandlingAction?.DataContext != null)
            {
                exceptionHandlingAction.DataContext.ErrorMessage = exceptionHandlingAction?.Exception?.Message;
            }

            return Task.CompletedTask;
        }
    }
}
