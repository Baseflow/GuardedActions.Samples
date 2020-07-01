using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _errorMessage;

        private ObservableCollection<DownloadableUrl> _downloads;

        private readonly IInitializeCommandBuilder _initializeCommandBuilder;
        private readonly IDownloadAllCommandBuilder _downloadAllCommandBuilder;

        private ICommand _initializeCommand;
        private ICommand _downloadAllCommand;

        public MainViewModel(IInitializeCommandBuilder initializeCommandBuilder, IDownloadAllCommandBuilder downloadAllCommandBuilder)
        {
            _initializeCommandBuilder = initializeCommandBuilder ?? throw new ArgumentNullException(nameof(initializeCommandBuilder));
            _downloadAllCommandBuilder = downloadAllCommandBuilder ?? throw new ArgumentNullException(nameof(downloadAllCommandBuilder));
        }

        public ICommand InitializeCommand => _initializeCommand ??= _initializeCommandBuilder?.RegisterDataContext(this).BuildCommand();
        public ICommand DownloadAllCommand => _downloadAllCommand ??= _downloadAllCommandBuilder?.RegisterDataContext(this).BuildCommand();

        public bool ShowErrorMessage => ErrorMessage != null;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value, () => RaisePropertyChanged(nameof(ShowErrorMessage)));
        }

        public ObservableCollection<DownloadableUrl> Downloads
        {
            get => _downloads;
            set => SetProperty(ref _downloads, value);
        }
    }
}
