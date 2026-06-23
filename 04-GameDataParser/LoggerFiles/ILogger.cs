using System.Text.Json;


namespace _04_GameDataParser.LoggerFiles;
public interface ILogger
{
    void Log(JsonException ex, DateTime now);
}