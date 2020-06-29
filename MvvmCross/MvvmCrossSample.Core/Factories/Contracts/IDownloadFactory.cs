using MvvmCrossSample.Core.Commands.Contracts;
using MvvmCrossSample.Core.Models;

namespace MvvmCrossSample.Core.Factories.Contracts
{
    public interface IDownloadFactory
    {
        Download Create(string url);
    }
}
