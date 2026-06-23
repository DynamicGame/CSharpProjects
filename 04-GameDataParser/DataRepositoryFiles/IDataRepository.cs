public interface IDataRepository
{
    string Read(string path);
    void AppendSave(string path, string fileToAppend);
}
