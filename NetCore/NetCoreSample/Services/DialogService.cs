using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using NetCoreSample.Core.Services.Contracts;

namespace NetCoreSample.Services
{
    public class DialogService : IDialogService
    {
        private readonly IUserDialogs _userDialogs;

        public DialogService(IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));
        }

        public async Task<string> Prompt(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var result = await _userDialogs.PromptAsync(message).ConfigureAwait(false);

            return result.Value;
        }

        public Task Alert(string message, string title, string okText  = "OK")
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (title == null) throw new ArgumentNullException(nameof(title));

            return _userDialogs.AlertAsync(message, title, okText);
        }
    }
}
