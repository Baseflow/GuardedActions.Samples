using NetCoreSample.Core.Commands.Contracts;
using NetCoreSample.Core.Models;

namespace NetCoreSample.Core.Factories.Contracts
{
    public interface IDownloadFactory
    {
        Download Create(string url);
    }
}
