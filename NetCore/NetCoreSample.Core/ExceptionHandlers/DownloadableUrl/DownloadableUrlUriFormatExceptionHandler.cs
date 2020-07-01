using System;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands.Actions.DownloadableUrl
{
    [DefaultExceptionHandler]
    public class DownloadableUrlUriFormatExceptionHandler : ContextExceptionHandler<UriFormatException, Models.DownloadableUrl>
    {
        public override Task Handle(IExceptionHandlingAction<UriFormatException, Models.DownloadableUrl> exceptionHandlingAction)
        {
            if (exceptionHandlingAction?.DataContext != null)
            {
                exceptionHandlingAction.DataContext.ErrorMessage = "Not an valid URL.";

                // If after this handler the exception handling should finish you can undo the code below
                // exceptionHandlingAction.HandlingShouldFinish = true;
            }
            return Task.CompletedTask;
        }
    }
}
