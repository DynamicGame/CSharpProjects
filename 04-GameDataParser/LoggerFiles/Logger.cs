using System.Text.Json;


namespace _04_GameDataParser.LoggerFiles;
public class Logger : ILogger
{
    const string fileName = "log.txt";
    private readonly IDataRepository _dataRepository;

    public Logger(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }
    public void Log(JsonException ex, DateTime exceptionTime)
    {
        _dataRepository.AppendSave(fileName, $"[{exceptionTime}], Exception message: {ex.Message}, Stack trace: {ex.StackTrace}");
    }
}