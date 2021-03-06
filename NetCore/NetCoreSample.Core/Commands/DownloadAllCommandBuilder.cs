﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GuardedActions.Commands;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.ViewModels;

namespace NetCoreSample.Core.Commands
{
    public class DownloadAllCommandBuilder : AsyncGuardedDataContextCommandBuilder<MainViewModel>, IDownloadAllCommandBuilder
    {
        protected override Task ExecuteCommandAction()
        {
            var commands = new List<Task>();
            foreach (var download in DataContext.Downloads)
            {
                commands.Add(download.DownloadCommand.ExecuteAsync());
            }
            return Task.WhenAll(commands.ToArray());
        }
    }
}
