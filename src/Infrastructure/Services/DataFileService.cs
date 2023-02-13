using ApplicationCore.Constants;
using ApplicationCore.Interfaces;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Services;

public class DataFileService<T> : IDataFileService<T>
{

    public async Task<IReadOnlyCollection<T>> ReadFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        using var fileStream = File.OpenRead(filePath);
        var data = await JsonSerializer.DeserializeAsync<IReadOnlyCollection<T>>(fileStream);
        if (data == null)
        {
            throw new Exception(AppConstants.ErrorMessages.DataRead);
        }
        return data;
    }
}
