using System;
using System.Threading.Tasks;
using GuardedActions.Commands.Actions;
using NetCoreSample.Core.Actions.DownloadableUrl.Contracts;
using NetCoreSample.Core.Enums;
using NetCoreSample.Core.Services.Contracts;

namespace NetCoreSample.Core.Actions.DownloadableUrl
{
    public class SaveDownloadAction : GuardedDataContextAction<Models.DownloadableUrl>, ISaveDownloadAction
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
