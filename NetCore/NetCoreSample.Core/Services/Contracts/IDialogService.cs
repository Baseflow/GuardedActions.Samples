using System.Threading.Tasks;

namespace NetCoreSample.Core.Services.Contracts
{
    public interface IDialogService
    {
        Task<string> Prompt(string message);

        Task Alert(string message, string title, string okText = "OK");
    }
}
