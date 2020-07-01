using System;
using AsyncAwaitBestPractices.MVVM;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Enums;

namespace NetCoreSample.Core.Models
{
    public class DownloadableUrl : NotifyPropertyChanged
    {
        private DownloadableUrlState _state;
        private string? _errorMessage;
        private byte[]? _data;
        private string? _fileName;
        private string? _filePath;

        public DownloadableUrl(string url, IDownloadCommandBuilder downloadCommandBuilder)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));

            if (downloadCommandBuilder == null)
                throw new ArgumentNullException(nameof(downloadCommandBuilder));

            DownloadCommand = downloadCommandBuilder.RegisterDataContext(this).BuildCommand();
        }

        public IAsyncCommand DownloadCommand { get; }

        public string Url { get; }

        public DownloadableUrlState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public byte[]? Data
        {
            get => _data;
            set
            {
                SetProperty(ref _data, value);
                State = DownloadableUrlState.Downloaded;
            }
        }

        public string? Filename
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        public string? FilePath
        {
            get => _filePath;
            set
            {
                SetProperty(ref _filePath, value);
                State = DownloadableUrlState.Saved;
            }
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                SetProperty(ref _errorMessage, value);
                State = DownloadableUrlState.Error;
            }
        }
    }
}
