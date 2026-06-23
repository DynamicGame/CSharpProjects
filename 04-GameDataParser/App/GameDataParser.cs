

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
        
        var validFileName = GetValidatedFileName();
        var gameData = _gameDataReader.Read(validFileName);
        _gameDataPrinter.Print(gameData);


    }

    private string GetValidatedFileName()
    {
        var isFileNameValid = false;
        var userInputedFileName = "";
        do
        {
           userInputedFileName = _userInteractor.ReadLine();
            if (userInputedFileName is null)
            {
                _userInteractor.WriteLine("File name cannot be null");
            }
            else if (string.IsNullOrWhiteSpace(userInputedFileName))
            {
                _userInteractor.WriteLine("File name cannot be empty");
            }
            else if (!File.Exists(userInputedFileName))
            {
                _userInteractor.WriteLine("File not found");
            }
            else
            {
                isFileNameValid = true;
            }

        } while (!isFileNameValid);
        return userInputedFileName!;
    }
}
