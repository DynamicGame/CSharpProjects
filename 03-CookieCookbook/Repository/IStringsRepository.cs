public interface IStringsRepository
{
    void Save(string path, IEnumerable<string> value);

    IEnumerable<string>? GetAll(string path);
}