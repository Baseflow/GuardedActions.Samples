using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Models;
using NetCoreSample.Core.ViewModels;
using Xunit;

namespace NetCoreSample.Core.UnitTests.ViewModels
{
    public class MainViewModelTests
    {
        [Fact]
        public void MainViewModel_InheritsBaseViewModel()
        {
            // Arrange
            var baseViewModelType = typeof(BaseViewModel);
            var mainViewModelType = typeof(MainViewModel);

            // Act
            var result = baseViewModelType.IsAssignableFrom(mainViewModelType);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MainViewModel_CheckNotifyPropertyChanged()
        {
            // Arrange
            var initializeCommandBuilder = Mock.Of<IInitializeCommandBuilder>();
            var downloadAllCommandBuilder = Mock.Of<IDownloadAllCommandBuilder>();
            var viewModel = new MainViewModel(initializeCommandBuilder, downloadAllCommandBuilder);

            var lastChangedPropertyName = string.Empty;
            viewModel.PropertyChanged += (sender, args) => lastChangedPropertyName = args.PropertyName;

            // Act
            viewModel.Downloads = new ObservableCollection<DownloadableUrl>();

            // Assert
            Assert.Equal(nameof(viewModel.Downloads), lastChangedPropertyName);
        }

        [Fact]
        // Check if the view receives a notification that also the ShowErrorMessage has been updated after setting the value of the ErrorMessage
        public void MainViewModel_EditErrorMessage()
        {
            // Arrange
            var initializeCommandBuilder = Mock.Of<IInitializeCommandBuilder>();
            var downloadAllCommandBuilder = Mock.Of<IDownloadAllCommandBuilder>();
            var viewModel =  new MainViewModel(initializeCommandBuilder, downloadAllCommandBuilder);

            var propertyChanges = new List<string>();
            viewModel.PropertyChanged += (sender, args) => propertyChanges.Add(args.PropertyName);

            // Act
            viewModel.ErrorMessage = "Foo";

            // Assert
            Assert.Equal(2, propertyChanges.Count);
            Assert.Contains(nameof(viewModel.ErrorMessage), propertyChanges);
            Assert.Contains(nameof(viewModel.ShowErrorMessage), propertyChanges);
        }
    }
}
