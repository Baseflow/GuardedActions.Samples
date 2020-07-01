using System;
using System.Threading.Tasks;
using GuardedActions.Commands.Actions;
using NetCoreSample.Core.Commands.Actions.Contracts;
using NetCoreSample.Core.Enums;
using NetCoreSample.Core.Models;
using NetCoreSample.Core.Services.Contracts;

namespace NetCoreSample.Core.Commands.Actions
{
    public class SaveDownloadAction : GuardedDataContextAction<DownloadableUrl>, ISaveDownloadAction
    {
        private readonly IFileService _fileService;

        public SaveDownloadAction(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        protected override async Task Execute()
        {
            if (DataContext.State == DownloadableUrlState.Error)
                return;

            DataContext.FilePath = await _fileService.Save(DataContext.Data, DataContext.Filename);
        }
    }
}
