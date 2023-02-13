namespace ApplicationCore.Interfaces;

public interface IDataFileService<T>
{
    Task<IReadOnlyCollection<T>> ReadFile(string filePath);
}
