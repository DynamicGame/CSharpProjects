public class GameDataPrinter : IGameDataPrinter
{
    private readonly IUserInteractor _userInteractor;
    public GameDataPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }
    public void Print(List<GameData> gameDatas)
    {
        if (gameDatas.Count > 0)
        {
            _userInteractor.WriteLine("Loaded games are: ");
            var formatedGameData = gameDatas.Select(x => $"{x.Title}, released in {x.ReleaseYear}, rating: {x.Rating}");
            foreach (var gameData in formatedGameData)
            {
                _userInteractor.WriteLine(gameData);
            }
        }
        else
        {
            _userInteractor.WriteLine("No games are present in the input file.");
        }
    }
}