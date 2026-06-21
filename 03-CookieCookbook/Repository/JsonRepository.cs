using System.Text.Json;

public class JsonRepository : StringsRepository
{
    public override string StringsToText(IEnumerable<string> value)
    {
        return JsonSerializer.Serialize(value);
    }

    public override IEnumerable<string> TextToStrings(string content)
    {
        return JsonSerializer.Deserialize<List<string>>(content)!;
    }
}