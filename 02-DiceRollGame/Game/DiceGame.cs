using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("02-DiceRollGameTests")]
namespace DiceRollGame.Game;


public class DiceGame
{
    private readonly IDice _dice;
    private readonly IUserInteractor _userInteractor;
    public const int MaxTries = 3;
    private int _winningNumber { get; set; }
    public DiceGame(IDice dice, IUserInteractor userInteractor)
    {
        _dice = dice;
        _userInteractor = userInteractor;
    }

    public GameResult Play()
    {
        _winningNumber = _dice.Roll();
        var tries = MaxTries;
    

        _userInteractor.ShowMessage("Dice rolled. Guess what number it shows in 3 tries.");
        while (tries > 0)
        {

            int userGuess = _userInteractor.ReadIntegar("Enter number: ");

            if (userGuess == _winningNumber)
            {
                return GameResult.Win;
            }
            _userInteractor.ShowMessage("Wrong number");
            tries--;
        }
        return GameResult.Lost;
    }

    internal void PrintResult(GameResult gameResult)
    {
        var result = gameResult == GameResult.Win ? "You win!" : "You lost!";
        _userInteractor.ShowMessage(result);
    }
}
