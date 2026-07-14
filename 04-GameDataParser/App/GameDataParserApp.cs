

using _04_GameDataParser.UserInteractorFiles;

namespace _04_GameDataParser.App;

public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGameDataReader _gameDataReader;
    private readonly IGameDataPrinter _gameDataPrinter;

    public GameDataParserApp(IUserInteractor userInteractor, IGameDataReader gameDataReader, IGameDataPrinter gameDataPrinter)
    {
        _userInteractor = userInteractor;
        _gameDataReader = gameDataReader;
        _gameDataPrinter = gameDataPrinter;
    }
    public void Run()
    {
        _userInteractor.WriteLine(Resource.EnterFileNameMessage);
        
        var validFileName = _userInteractor.ReadValidFilePath();
        var gameData = _gameDataReader.Read(validFileName);
        _gameDataPrinter.Print(gameData);


    }

    
}
