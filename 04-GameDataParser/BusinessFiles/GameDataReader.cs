public class GameDataReader : IGameDataReader
{
    private readonly IDataRepository _dataRepository;
    private readonly IJsonDeserializer _jsonDeserializer;
    public GameDataReader (IDataRepository dataRepository, IJsonDeserializer jsonDeserializer)
    {
        _dataRepository = dataRepository;
        _jsonDeserializer = jsonDeserializer;
    }

    public List<GameData> Read(string path)
    {
        var rawData = _dataRepository.Read(path);
        List<GameData> gameData = _jsonDeserializer.Deserialize<List<GameData>>(rawData);
        return gameData;
    }
}
