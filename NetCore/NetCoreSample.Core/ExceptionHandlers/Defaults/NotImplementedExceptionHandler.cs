using System;
using System.Threading.Tasks;
using GuardedActions.ExceptionHandlers;
using GuardedActions.ExceptionHandlers.Attributes;
using GuardedActions.ExceptionHandlers.Contracts;
using GuardedActions.IoC;
using NetCoreSample.Core.Services.Contracts;

namespace NetCoreSample.Core.ExceptionHandlers.Defaults
{
    [DefaultExceptionHandler]
    public class NotImplementedExceptionHandler : ExceptionHandler<NotImplementedException>
    {
        private IDialogService _dialogService;

        // TODO: add ability to load use DI
        //public NotImplementedExceptionHandler(IDialogService dialogService)
        //{
        //    _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        //}

        protected IDialogService DialogService => _dialogService ??= IoCRegistration.Instance.GetService<IDialogService>();

        public override Task Handle(IExceptionHandlingAction<NotImplementedException> exceptionHandlingAction)
        {
            if (exceptionHandlingAction == null) throw new ArgumentNullException(nameof(exceptionHandlingAction));

            exceptionHandlingAction.HandlingShouldFinish = true;

            var message = exceptionHandlingAction?.Exception?.Message ?? "This is not implemented yet!";

            return DialogService.Alert(message, "Coming soon™", "Ok, I will wait");
        }
    }
}
