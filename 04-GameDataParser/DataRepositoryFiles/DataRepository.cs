public class DataRepository : IDataRepository
{
    public string Read(string path)
    {
       return  File.ReadAllText(path);
    }

    public void AppendSave(string path, string fileToAppend)
    {
        File.AppendAllText(path, fileToAppend);
    }
}