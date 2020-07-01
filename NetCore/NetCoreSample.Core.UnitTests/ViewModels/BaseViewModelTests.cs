using System.ComponentModel;
using NetCoreSample.Core.ViewModels;
using Xunit;

namespace NetCoreSample.Core.UnitTests.ViewModels
{
    public class BaseViewModelTests
    {
        [Fact]
        public void BaseViewModel_ImplementsNotifyPropertyChanged()
        {
            //Arrange
            var notifyPropertyChangedInterfaceType = typeof(INotifyPropertyChanged); 
            var baseViewModelType = typeof(BaseViewModel);

            //Act
            var result= notifyPropertyChangedInterfaceType.IsAssignableFrom(baseViewModelType);

            //Assert
            Assert.True(result);
        }
    }
}
