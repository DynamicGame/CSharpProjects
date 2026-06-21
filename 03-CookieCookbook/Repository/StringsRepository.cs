using System.Text.Json.Nodes;

public abstract class StringsRepository : IStringsRepository
{
    public IEnumerable<string>? GetAll(string path)
    {
        if (File.Exists(path))
        {
            var content = File.ReadAllText(path);
            return TextToStrings(content);
        }
        return null;

    }

    public abstract IEnumerable<string> TextToStrings(string content);


    public void Save(string path, IEnumerable<string> value)
    {
        var contentToSave = StringsToText(value);
     


        File.WriteAllText(path, contentToSave);


    }

    public abstract string StringsToText(IEnumerable<string> value);

 
}
