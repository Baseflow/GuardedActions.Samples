﻿using System;
using System.Threading.Tasks;
using GuardedActions.Commands;
using GuardedActions.Commands.Contracts;
using NetCoreSample.Core.Actions.DownloadableUrl.Contracts;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Commands
{
    // This is an example of a CommandBuilder with actions. In this example it's taken to the extreme and created some micro actions for demo purpose.
    public class DownloadCommandBuilder : AsyncGuardedDataContextCommandBuilder<DownloadableUrl>, IDownloadCommandBuilder
    {
        // This is an example of a CommandBuilder with actions. In this example it's taken to the extreme and created some micro actions for demo purpose.
        private readonly IDownloadUrlAction _downloadUrlAction;
        private readonly IDetermineDownloadFilenameAction _determineDownloadFilenameAction;
        private readonly ISaveDownloadAction _saveDownloadAction;

        // This is an example of a CommandBuilder with actions. In this example it's taken to the extreme and created some micro actions for demo purpose.
        public DownloadCommandBuilder(
            IDownloadUrlAction downloadUrlAction,
            IDetermineDownloadFilenameAction determineDownloadFilenameAction,
            ISaveDownloadAction saveDownloadAction)
        {
            _downloadUrlAction = downloadUrlAction ?? throw new ArgumentNullException(nameof(downloadUrlAction));
            _determineDownloadFilenameAction = determineDownloadFilenameAction ?? throw new ArgumentNullException(nameof(determineDownloadFilenameAction));
            _saveDownloadAction = saveDownloadAction ?? throw new ArgumentNullException(nameof(downloadUrlAction));
        }

        // This is an example of a CommandBuilder with actions. In this example it's taken to the extreme and created some micro actions for demo purpose.
        protected override async Task ExecuteCommandAction()
        {
            await _downloadUrlAction.ExecuteGuarded();
            await _determineDownloadFilenameAction.ExecuteGuarded();
            await _saveDownloadAction.ExecuteGuarded();
        }

        // This is an example of a CommandBuilder with actions. In this example it's taken to the extreme and created some micro actions for demo purpose.
        public override IAsyncGuardedDataContextCommandBuilder<DownloadableUrl> RegisterDataContext(DownloadableUrl dataContext)
        {
            _downloadUrlAction.RegisterDataContext(dataContext);
            _determineDownloadFilenameAction.RegisterDataContext(dataContext);
            _saveDownloadAction.RegisterDataContext(dataContext);

            return base.RegisterDataContext(dataContext);
        }
    }
}
