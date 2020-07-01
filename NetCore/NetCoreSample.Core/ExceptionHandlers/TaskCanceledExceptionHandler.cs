using System;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;

namespace NetCoreSample.Core.ExceptionHandlers
{
    [DefaultExceptionHandler]
    public class TaskCanceledExceptionHandler : ExceptionHandler<TaskCanceledException>
    {
        public override Task Handle(IExceptionHandlingAction<TaskCanceledException> exceptionHandlingAction)
        {
            if (exceptionHandlingAction == null) throw new ArgumentNullException(nameof(exceptionHandlingAction));

            exceptionHandlingAction.HandlingShouldFinish = true;

            return Task.CompletedTask; // just ignore the error
        }
    }
}
