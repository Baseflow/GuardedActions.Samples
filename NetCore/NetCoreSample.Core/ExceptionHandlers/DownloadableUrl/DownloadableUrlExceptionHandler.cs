using System;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;

namespace NetCoreSample.Core.ExceptionHandlers.DownloadableUrl
{
    [DefaultExceptionHandler]
    public class DownloadExceptionHandler : ContextExceptionHandler<Exception, Models.DownloadableUrl>
    {
        public override Task Handle(IExceptionHandlingAction<Exception, Models.DownloadableUrl> exceptionHandlingAction)
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
