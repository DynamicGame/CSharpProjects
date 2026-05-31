public class DiceGame
{
    private readonly Dice _dice;
    private const int MaxTries = 3;
    private int _winningNumber { get; set; }
    public DiceGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        _winningNumber = _dice.Roll();
        var tries = MaxTries;
        int userGuess;

        Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");
        while (tries > 0)
        {
            Console.WriteLine("Enter number: ");
            var userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Incorrect input.");
                continue;
            }else if( !int.TryParse(userInput, out userGuess))
            {
                Console.WriteLine("Wrong number");
            }
            else if( userGuess == _winningNumber)
            {
                
                return GameResult.Win;
            }
           

            tries--;    
        }
        return GameResult.Lost;
    }

    internal void PrintResult(GameResult gameResult)
    {
        var result = gameResult == GameResult.Win ? "You win!" : "You lost!";
        Console.WriteLine(result);
    }
}
