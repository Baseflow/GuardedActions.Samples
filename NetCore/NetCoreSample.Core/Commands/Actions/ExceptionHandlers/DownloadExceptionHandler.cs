using System;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands.Actions.ExceptionHandlers
{
    [DefaultExceptionHandler]
    public class DownloadExceptionHandler : ContextExceptionHandler<Exception, DownloadableUrl>
    {
        public override Task Handle(IExceptionHandlingAction<Exception, DownloadableUrl> exceptionHandlingAction)
        {
            if (exceptionHandlingAction?.DataContext != null && exceptionHandlingAction.DataContext.ErrorMessage == null)
            {
                exceptionHandlingAction.DataContext.ErrorMessage = "An error occured please contact the service desk.";

                // If after this handler the exception handling should finish you can undo the code below
                // exceptionHandlingAction.HandlingShouldFinish = true;
            }
            return Task.CompletedTask;
        }
    }
}
