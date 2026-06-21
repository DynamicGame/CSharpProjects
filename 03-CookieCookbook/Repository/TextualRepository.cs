public class TextualRepository : StringsRepository
{
    public override IEnumerable<string> TextToStrings(string content)
    {
        return content.Split(Environment.NewLine);
    }

    public override string StringsToText(IEnumerable<string> value)
    {
        return string.Join(Environment.NewLine, value);
    }
}