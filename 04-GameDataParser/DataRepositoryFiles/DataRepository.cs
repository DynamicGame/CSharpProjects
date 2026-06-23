public class DataRepository : IDataRepository
{
    public string Read(string path)
    {
       return  File.ReadAllText(path);
    }

    public void AppendSave(string path, string fileToAppend)
    {
        if (File.Exists(path))
        {
            var currentData = File.ReadAllLines(path).ToList();
            currentData.Add(fileToAppend);
            File.WriteAllLines(path, currentData);
        }
        else
        {
            File.WriteAllText(path, fileToAppend);
        }

    }
}