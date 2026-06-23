using System.Text.Json;

public class JsonDeserializer : IJsonDeserializer
{
    private readonly IUserInteractor _userInteractor;
    private readonly ILogger _logger;
    public JsonDeserializer(IUserInteractor userInteractor, ILogger logger)
    {
        _userInteractor = userInteractor;
        _logger = logger;
    }
    public T Deserialize<T>(string data)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(data)!;
        }
        catch (JsonException ex)
        {
            _userInteractor.WriteLine($"JSON is not valid format. JSON body: {Environment.NewLine} {data}");
            _logger.Log(ex, DateTime.Now);
            throw;
        }
       
        
    }
}
