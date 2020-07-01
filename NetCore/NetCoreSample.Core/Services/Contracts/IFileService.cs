using System.Threading.Tasks;

namespace NetCoreSample.Core.Services.Contracts
{
    public interface IFileService
    {
        Task<string> Save(byte[] bytes, string fileName);
    }
}
