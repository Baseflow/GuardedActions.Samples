using System;
using System.IO;
using System.Threading.Tasks;
using GuardedActions.Commands.Actions;
using NetCoreSample.Core.Commands.Actions.Contracts;
using NetCoreSample.Core.Enums;
using NetCoreSample.Core.Models;
using NetCoreSample.Core.Services.Contracts;

namespace NetCoreSample.Core.Commands.Actions
{
    public class DetermineDownloadFilenameAction : GuardedDataContextAction<DownloadableUrl>, IDetermineDownloadFilenameAction
    {
        private readonly IDialogService _dialogService;

        public DetermineDownloadFilenameAction(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        protected override async Task Execute()
        {
            if (DataContext.State == DownloadableUrlState.Error)
                return;

            string filename;
            bool invalidFilename;
            do
            {
                filename = await _dialogService.Prompt($"Please provide a filename for download: \n{DataContext.Url}");

                invalidFilename = filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;

                if (invalidFilename)
                    await _dialogService.Alert("You've entered an invalid filename! Please try again.", "Filename");
            }
            while (invalidFilename);

            DataContext.Filename = filename;
        }
    }
}
