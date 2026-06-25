

using _04_GameDataParser.UserInteractorFiles;

namespace _04_GameDataParser.App;

public class GameDataParser
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGameDataReader _gameDataReader;
    private readonly IGameDataPrinter _gameDataPrinter;

    public GameDataParser(IUserInteractor userInteractor, IGameDataReader gameDataReader, IGameDataPrinter gameDataPrinter)
    {
        _userInteractor = userInteractor;
        _gameDataReader = gameDataReader;
        _gameDataPrinter = gameDataPrinter;
    }
    public void Run()
    {
        _userInteractor.WriteLine("Enter the name of the file you want to read: ");
        
        var validFileName = _userInteractor.ReadValidFilePath();
        var gameData = _gameDataReader.Read(validFileName);
        _gameDataPrinter.Print(gameData);


    }

    
}
