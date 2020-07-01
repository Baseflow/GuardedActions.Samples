using System;
using System.IO;
using System.Threading.Tasks;
using NetCoreSample.Core.Services.Contracts;
using Xamarin.Essentials;

namespace NetCoreSample.Services
{
    public class FileService : IFileService
    {
        public async Task<string> Save(byte[] bytes, string fileName)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            var path = $"{FileSystem.AppDataDirectory}/{fileName}";

            using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            await fs.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);

            return path;
        }
    }
}
